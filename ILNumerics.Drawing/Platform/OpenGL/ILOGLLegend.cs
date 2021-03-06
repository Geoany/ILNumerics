#region Copyright GPLv3
//
//  This file is part of ILNumerics.Net. 
//
//  ILNumerics.Net supports numeric application development for .NET 
//  Copyright (C) 2007, H. Kutschbach, http://ilnumerics.net 
//
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
//
//  You should have received a copy of the GNU General Public License
//   along with this program.  If not, see <http://www.gnu.org/licenses/>.
// 
//  Non-free licenses are also available. Contact info@ilnumerics.net 
//  for details. 
//
#endregion

using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing; 
using ILNumerics.Drawing.Labeling; 
using ILNumerics.Drawing.Controls;
using ILNumerics.Drawing.Interfaces; 
using ILNumerics.Drawing.Misc; 
using ILNumerics.Drawing.Graphs; 
using OpenTK.Graphics; 

namespace ILNumerics.Drawing.Platform.OpenGL {
    public class ILOGLLegend : ILLegend {

        #region attributes 

        #endregion

        #region constructor
        internal ILOGLLegend (ILPanel panel) : base (panel) {}
        #endregion

        #region abstract overloads 
        /// <summary>
        /// draw legend into opengl context
        /// </summary>
        /// <param name="p">rendering properties</param>
        /// <param name="area">area to draw the content into, if g is null, this will be ignored also</param>
        public override void Draw(ILRenderProperties p, System.Drawing.Rectangle area) {
            if (!m_visible) return; 
            // handle drawing to bitmap 
            if (p.Graphics != null) {
                base.Draw(p, area);
                return; 
            }
            // draw to OpenGL context
            if (GraphicsContext.CurrentContext == null)
                throw new GraphicsContextException("No OpenGL GraphicsContext current is selected for the calling thread.");

            #region set 2D projection   
            float[] viewport = new float[4]; 
            GL.GetFloat(GetPName.Viewport, viewport);
            GL.MatrixMode(MatrixMode.Projection);
            GL.PushMatrix();     
            GL.LoadIdentity();
            GL.Ortho(viewport[0], viewport[2], viewport[3], viewport[1], -1.0, 1.0);

            GL.MatrixMode(MatrixMode.Modelview);
            GL.PushMatrix();
            GL.LoadIdentity();

            //GL.PushAttrib(AttribMask.TextureBit | AttribMask.EnableBit | AttribMask.ColorBufferBit);

            //GL.Enable(EnableCap.Texture2D);
            GL.Enable(EnableCap.Blend);
            GL.BlendFunc(BlendingFactorSrc.SrcAlpha, BlendingFactorDest.OneMinusSrcAlpha);
            
            GL.Disable(EnableCap.DepthTest);
            #endregion

            #region draw bounding box + bg
            Size labelSize = Size.Empty, boxSize = Size.Empty; 
            Rectangle sampleRect = Rectangle.Empty, labelRect = Rectangle.Empty; 
            List<IILLegendRenderer> renderer = getRenderers(ref labelSize); 
            // automatically size the box 
            boxSize.Width = m_padding.Horizontal+labelSize.Width + 30; // <- default width for sample
            boxSize.Height = m_padding.Bottom+labelSize.Height+m_padding.Top*renderer.Count; 
            if (!m_size.IsEmpty) {
                // prefer given size, with limitations
                boxSize.Width = Math.Max(boxSize.Width,m_size.Width); 
                boxSize.Height = Math.Max(boxSize.Height,m_size.Height); 
            }
            Point location = Point.Empty; 
            if (m_location.IsEmpty) {
                int minx = m_panel.ClientSize.Width - boxSize.Width - m_border.Width * 2;
                int miny = m_panel.ClientSize.Height - boxSize.Height - m_border.Width * 2; 
                // by default: place legend at upper right corner
                location.X = m_panel.ClientSize.Width - boxSize.Width - m_panel.Padding.Right - m_border.Width * 2;
                if (location.X < 0) location.X = 0;
                if (location.X > minx) location.X = minx; 
                location.Y = m_panel.Padding.Top;
                if (location.Y < 0) location.Y = 0; 
                if (location.Y > miny) location.Y = miny; 
            } else 
                location = new Point((int)(m_location.X * (float)m_panel.ClientSize.Width)
                            ,(int)(m_location.Y * (float)m_panel.ClientSize.Height)); 

            float offsX = Math.Max(m_border.Width / 2.0f,1.0f); 
            m_bgColor = Color.FromArgb((int)(m_opacity * 255),m_bgColor); 
            GL.Color4(m_bgColor);
            GL.ShadeModel(ShadingModel.Flat); 
            GL.Begin(BeginMode.Quads); 
                GL.Vertex2(location.X + offsX,              location.Y + offsX);
                GL.Vertex2(location.X + boxSize.Width-offsX,location.Y + offsX); 
                GL.Vertex2(location.X + boxSize.Width-offsX,location.Y + boxSize.Height - offsX); 
                GL.Vertex2(location.X + offsX,              location.Y + boxSize.Height - offsX);
                GL.Vertex2(location.X + offsX,              location.Y + offsX); 
            GL.End(); 
            
            ILNumerics.Drawing.Platform.OpenGL.ILOGLPanel.SetupLineStyle(m_border); 
            GL.Begin(BeginMode.LineStrip); 
                GL.Vertex2(location.X + offsX,              location.Y + offsX);
                GL.Vertex2(location.X + boxSize.Width-offsX,location.Y + offsX); 
                GL.Vertex2(location.X + boxSize.Width-offsX,location.Y + boxSize.Height - offsX); 
                GL.Vertex2(location.X + offsX,              location.Y + boxSize.Height - offsX);
                GL.Vertex2(location.X + offsX,              location.Y + offsX); 
            GL.End(); 
            #endregion
            
            sampleRect.Y = location.Y+m_padding.Top; 
            sampleRect.Width = boxSize.Width - 2 * m_padding.Right - labelSize.Width; 
            sampleRect.X = location.X + m_padding.Left; 
            
            labelRect.Y = location.Y+m_padding.Top; 
            labelRect.Width = labelSize.Width; 
            labelRect.X = sampleRect.Right + m_padding.Right;
            
            for (int i = 0; i < renderer.Count; i++) {
                IILLegendRenderer rend = renderer[i]; 
                sampleRect.Height = rend.LabelSize.Height; 
                labelRect.Height = sampleRect.Height; 
                try {
                    rend.DrawToLegend(p,sampleRect,labelRect); 
                } catch (Exception) {}
                sampleRect.Y = sampleRect.Bottom + m_padding.Top; 
                labelRect.Y = sampleRect.Y;
            }

            #region restore previous projection
            //GL.PopAttrib();
            GL.MatrixMode(MatrixMode.Modelview);
            GL.PopMatrix();
            GL.MatrixMode(MatrixMode.Projection);
            GL.PopMatrix();
            #endregion
        }
        #endregion
    }
}
