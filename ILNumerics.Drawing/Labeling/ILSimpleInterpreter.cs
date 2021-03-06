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
using System.Text;
using System.Drawing; 
using System.Collections.Generic;
using ILNumerics.Drawing; 
using ILNumerics.Drawing.Interfaces; 

namespace ILNumerics.Drawing.Labeling {
    /// <summary>
    /// Transforms characters into bitmaps (1:1)
    /// </summary>
    /// <remarks>this is the base class for most IILTextInterpreter implementations</remarks>
    public class ILSimpleInterpreter : IILTextInterpreter {

#region attributes
        static Graphics m_measGraphics; 
        static Bitmap m_measBitmap; 
        protected Font m_normalFont; 
        protected Size m_size;
#endregion

#region constructor
        
        /// <summary>
        /// create a new instance of this text interpreter
        /// </summary>
        public ILSimpleInterpreter () : base () {
            resizeMeasureBMP(20,20);
        }

#endregion

#region helper functions 

        protected void resizeMeasureBMP(int width, int height) {
            if (m_measBitmap != null) 
                m_measBitmap.Dispose(); 
            if (m_measGraphics != null)
                m_measGraphics.Dispose(); 
            m_measBitmap = new Bitmap(width+1,height+1); 
            m_measGraphics = Graphics.FromImage(m_measBitmap); 
        }

        protected virtual void parseString (string expression, Font font, Point offset, Color color, 
                                    IILTextRenderer renderer, ref Size size, 
                                    ref List<ILRenderQueueItem> queue) {
            int pos = 0;
            string key, itemText; 
            RectangleF bmpSize = new RectangleF(); 
            int curHeigth = 0, curWidth = 0; 
            Bitmap itemBMP = null; 
            int lineHeight = 0, lineWidth = 0; 
            Size itemSize = Size.Empty; 
            while (pos < expression.Length) {
                itemText = expression.Substring(pos++,1);
                key = ILHashCreator.Hash(font,itemText); 
                
                if (renderer.TryGetSize(key, ref itemSize)) {
                    queue.Add(new ILRenderQueueItem(key,offset,color));
                    if (itemSize.Height > lineHeight) lineHeight = itemSize.Height; 
                    lineWidth += (int)itemSize.Width;
                } else {
                    lock (this) {
                        itemBMP = transformItem(itemText,font,out bmpSize); 
                        renderer.Cache(key,itemBMP,bmpSize); 
                        queue.Add(new ILRenderQueueItem(key,offset,color)); 
                        // update size
                        if (bmpSize.Height > lineHeight) 
                            lineHeight = (int)bmpSize.Height; 
                        lineWidth += (int)bmpSize.Width;
                    }
                }
            }
            size.Width += ((curWidth>lineWidth)?curWidth:lineWidth);
            size.Height = curHeigth + lineHeight; 
        }

        /// <summary>
        /// Render a string onto a bitmap and measure exact size
        /// </summary>
        /// <param name="item">item to be rendered</param>
        /// <param name="font">font used for rendering</param>
        /// <param name="size">[output] size of the rendered item</param>
        /// <returns>bitmap containing the item</returns>
        public Bitmap TransformItem (string item, Font font, out RectangleF size) {
            Bitmap ret = transformItem(item,font,out size); 
            return ret.Clone(Rectangle.Round(size),ret.PixelFormat); 
        }

        /// <summary>
        /// Render a string onto a bitmap and measure exact size
        /// </summary>
        /// <param name="item">item to be rendered</param>
        /// <param name="font">font used for rendering</param>
        /// <param name="size">[output] size of the rendered item</param>
        /// <returns>bitmap containing the item</returns>
        protected Bitmap transformItem(string item, Font font, out RectangleF size) {
            if (String.IsNullOrEmpty(item)) {
                size = new RectangleF(0,0,1,1);    
                return m_measBitmap; 
            }
            if (item == " ") {
                size = new RectangleF (new PointF(0,0),m_measGraphics.MeasureString(item,font));
                if (size.Right >= m_measBitmap.Width || size.Bottom >= m_measBitmap.Height) {
                    resizeMeasureBMP((int)size.Right+15,(int)size.Bottom+15);     
                    return transformItem(item,font,out size);
                }
                m_measGraphics.Clear(Color.Transparent); 
                return m_measBitmap;
            }
            StringFormat sformat = StringFormat.GenericDefault; 
            sformat.FormatFlags = StringFormatFlags.NoWrap 
                                | StringFormatFlags.NoClip 
                                | StringFormatFlags.MeasureTrailingSpaces; 
            sformat.SetMeasurableCharacterRanges(new CharacterRange[]{new CharacterRange(0,item.Length)});

            // draw the text
            if (font.SizeInPoints < 16) {
                m_measGraphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            } else {
                m_measGraphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias; 
            }
            RectangleF layout = new RectangleF(0,0,m_measBitmap.Width,m_measBitmap.Height);
            m_measGraphics.Clear(Color.Transparent); 
            m_measGraphics.DrawString(item,font,Brushes.White,layout,sformat);
            // measure bounds 
            Region[] reg = m_measGraphics.MeasureCharacterRanges(item,font,layout,sformat); 
            size = reg[0].GetBounds(m_measGraphics);
            size.Width += 1; 
            size.Height += 1; 
            // compensate 
            //size = new RectangleF((size.Left>0)?size.Left-1:size.Left,size.Top,size.Width,size.Height);
#if EXPORTBMP   // debug support only 
            if (true) {
                Bitmap debBitmap = (Bitmap)m_measBitmap.Clone(); 
                Graphics debGrap = Graphics.FromImage(debBitmap); 
                //debGrap.Clear(Color.White); 
                //debGrap.DrawString(item,font,Brushes.Black,layout,sformat);
                debGrap.DrawRectangle(new Pen(Brushes.Red),Rectangle.Round(size));
                debBitmap.Save("EXPORTBMP_transformItemResult.bmp",System.Drawing.Imaging.ImageFormat.Bmp); 
            }
#endif
            if (size.Right >= m_measBitmap.Width || size.Bottom >= m_measBitmap.Height) {
                resizeMeasureBMP((int)size.Right+15,(int)size.Bottom+15);     
                return transformItem(item,font,out size);
            }
            return m_measBitmap; 
        }

#endregion

#region IILTextInterpreter Member

        /// <summary>
        /// Transforms an expression into render queue definition
        /// </summary>
        /// <param name="expression">expression to be transformed</param>
        /// <param name="font">font may used for transformation</param>
        /// <param name="color">standard color used for transformation</param>
        /// <param name="renderer">IILTextRenderer instance used for caching (and later rendering)</param>
        /// <returns>render queue, later used to render the visual representation of the expression</returns>
        /// <remarks>the expression may contain markups. See the online help at http://ilnumerics.net
        /// for a detailed descriptioin of known symbols and their syntax.</remarks>
        public ILRenderQueue Transform(string expression, Font font, Color color, 
                                       IILTextRenderer renderer) {
            List<ILRenderQueueItem> ret = new List<ILRenderQueueItem>(); 
            Size size = Size.Empty; 
            m_normalFont = font; 
            parseString(expression,font,new Point(),color,renderer,ref size,ref ret); 
            return new ILRenderQueue(expression, ret, size); 
        }
        /// <summary>
        /// Render text expression into bitmap
        /// </summary>
        /// <param name="expression">text expression</param>
        /// <param name="font">font used for rendering</param>
        /// <returns>Bitmap with rendered expression</returns>
        /// <remarks>The size of the bitmap returned will tightly fit around the rendered content.</remarks>
        public virtual Bitmap Transform(string expression, Font font) {
            RectangleF size; 
            Bitmap ret = transformItem(expression, font, out size); 
            return ret.Clone(size,ret.PixelFormat); 
        }
        /// <summary>
        /// Render text expression into bitmap
        /// </summary>
        /// <param name="expression">text expression</param>
        /// <returns>Bitmap with rendered expression</returns>
        /// <remarks>The size of the bitmap returned will tightly fit around the rendered content. 
        /// <para>A generic sans serif font of size 10em will be used. </para></remarks>
        public virtual Bitmap Transform(string expression) {
            Font font = new Font(FontFamily.GenericSansSerif,10f,FontStyle.Regular); 
            RectangleF size; 
            Bitmap ret = transformItem(expression, font, out size); 
            return ret.Clone(size,ret.PixelFormat); 
        }
#endregion
    }
}
