//////////////////////////////////////////////////////////////////
//                                                              //
//  This is an auto - manipulated source file.                  //
//  Edits inside regions of HYCALPER AUTO GENERATED CODE        //
//  will be lost and overwritten on the next build!             //
//                                                              //
//////////////////////////////////////////////////////////////////
#region LGPL License
/*    
    This file is part of ILNumerics.Net Core Module.

    ILNumerics.Net Core Module is free software: you can redistribute it 
    and/or modify it under the terms of the GNU Lesser General Public 
    License as published by the Free Software Foundation, either version 3
    of the License, or (at your option) any later version.

    ILNumerics.Net Core Module is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU Lesser General Public License for more details.

    You should have received a copy of the GNU Lesser General Public License
    along with ILNumerics.Net Core Module.  
    If not, see <http://www.gnu.org/licenses/>.
*/
#endregion

using System;
using System.Collections.Generic;
using System.Text;
using ILNumerics.Storage;
using ILNumerics.Misc;
using ILNumerics.Exceptions;
/*!HC:TYPELIST:
<hycalper>
<type>
    <source locate="after">
        inCls1
    </source>
    <destination><![CDATA[ILArray<float>]]></destination>
    <destination><![CDATA[ILArray<Int16>]]></destination>
    <destination><![CDATA[ILArray<Int32>]]></destination>
    <destination><![CDATA[ILArray<Int64>]]></destination>
    <destination><![CDATA[ILArray<UInt16>]]></destination>
    <destination><![CDATA[ILArray<UInt32>]]></destination>
    <destination><![CDATA[ILArray<UInt64>]]></destination>
    <destination><![CDATA[ILArray<char>]]></destination>
    <destination><![CDATA[ILArray<byte>]]></destination>
</type>
<type>
    <source locate="after">
        inArr1
    </source>
    <destination>float</destination>
    <destination>Int16</destination>
    <destination>Int32</destination>
    <destination>Int64</destination>
    <destination>UInt16</destination>
    <destination>UInt32</destination>
    <destination>UInt64</destination>
    <destination>char</destination>
    <destination>byte</destination>
</type>
</hycalper>
 */

namespace ILNumerics.BuiltInFunctions  {
    public partial class ILMath {
        #region HYCALPER LOOPSTART
        /// <summary>
        /// real part of complex array
        /// </summary>
        /// <param name="X">complex input array</param>
        /// <returns>real part of complex array</returns>
        public static ILArray<fcomplex> real2fcomplex (/*!HC:inCls1*/ ILArray<double> X) {
            int nrX = X.m_dimensions.NumberOfElements; 
            fcomplex [] retArr = new fcomplex [nrX]; 
            ILArray<fcomplex> ret = new ILArray<fcomplex> (retArr,X.m_dimensions); 
            for (int i= 0; i < nrX; i++) {
                retArr[i] = new  fcomplex ((float) X.GetValue(i),(float) 0.0); 
            }
            return ret; 
        }

        /// <summary>
        /// create complex array out of real and imaginary part
        /// </summary>
        /// <param name="real">real array for real part</param>
        /// <param name="imag">real array for imaginary part</param>
        /// <returns>complex array having the real- and part imaginary parts constructed out of 
        /// real and imag.</returns>
        /// <remarks>real and imag must be the same length. Eather one may be a row- or a column vector.
        /// The array returned will be the same size as real.</remarks>
        public static ILArray<fcomplex> real2fcomplex (/*!HC:inCls1*/ ILArray<double> real,/*!HC:inCls1*/ ILArray<double> imag) {
            int nrX = real.m_dimensions.NumberOfElements; 
            fcomplex [] retArr = new fcomplex [nrX]; 
            ILArray<fcomplex> ret = new ILArray<fcomplex> (retArr,real.m_dimensions); 
            for (int i= 0; i < nrX; i++) {
                retArr[i] = new  fcomplex ((float) real.GetValue(i),(float) imag.GetValue(i)); 
            }
            return ret; 
        }
       
        #endregion HYCALPER LOOPEND
#region HYCALPER AUTO GENERATED CODE
// DO NOT EDIT INSIDE THIS REGION !! CHANGES WILL BE LOST !! 
        /// <summary>
        /// real part of complex array
        /// </summary>
        /// <param name="X">complex input array</param>
        /// <returns>real part of complex array</returns>
        public static ILArray<fcomplex> real2fcomplex ( ILArray<byte> X) {
            int nrX = X.m_dimensions.NumberOfElements; 
            fcomplex [] retArr = new fcomplex [nrX]; 
            ILArray<fcomplex> ret = new ILArray<fcomplex> (retArr,X.m_dimensions); 
            for (int i= 0; i < nrX; i++) {
                retArr[i] = new  fcomplex ((float) X.GetValue(i),(float) 0.0); 
            }
            return ret; 
        }

        /// <summary>
        /// create complex array out of real and imaginary part
        /// </summary>
        /// <param name="real">real array for real part</param>
        /// <param name="imag">real array for imaginary part</param>
        /// <returns>complex array having the real- and part imaginary parts constructed out of 
        /// real and imag.</returns>
        /// <remarks>real and imag must be the same length. Eather one may be a row- or a column vector.
        /// The array returned will be the same size as real.</remarks>
        public static ILArray<fcomplex> real2fcomplex ( ILArray<byte> real, ILArray<byte> imag) {
            int nrX = real.m_dimensions.NumberOfElements; 
            fcomplex [] retArr = new fcomplex [nrX]; 
            ILArray<fcomplex> ret = new ILArray<fcomplex> (retArr,real.m_dimensions); 
            for (int i= 0; i < nrX; i++) {
                retArr[i] = new  fcomplex ((float) real.GetValue(i),(float) imag.GetValue(i)); 
            }
            return ret; 
        }
       
        /// <summary>
        /// real part of complex array
        /// </summary>
        /// <param name="X">complex input array</param>
        /// <returns>real part of complex array</returns>
        public static ILArray<fcomplex> real2fcomplex ( ILArray<char> X) {
            int nrX = X.m_dimensions.NumberOfElements; 
            fcomplex [] retArr = new fcomplex [nrX]; 
            ILArray<fcomplex> ret = new ILArray<fcomplex> (retArr,X.m_dimensions); 
            for (int i= 0; i < nrX; i++) {
                retArr[i] = new  fcomplex ((float) X.GetValue(i),(float) 0.0); 
            }
            return ret; 
        }

        /// <summary>
        /// create complex array out of real and imaginary part
        /// </summary>
        /// <param name="real">real array for real part</param>
        /// <param name="imag">real array for imaginary part</param>
        /// <returns>complex array having the real- and part imaginary parts constructed out of 
        /// real and imag.</returns>
        /// <remarks>real and imag must be the same length. Eather one may be a row- or a column vector.
        /// The array returned will be the same size as real.</remarks>
        public static ILArray<fcomplex> real2fcomplex ( ILArray<char> real, ILArray<char> imag) {
            int nrX = real.m_dimensions.NumberOfElements; 
            fcomplex [] retArr = new fcomplex [nrX]; 
            ILArray<fcomplex> ret = new ILArray<fcomplex> (retArr,real.m_dimensions); 
            for (int i= 0; i < nrX; i++) {
                retArr[i] = new  fcomplex ((float) real.GetValue(i),(float) imag.GetValue(i)); 
            }
            return ret; 
        }
       
        /// <summary>
        /// real part of complex array
        /// </summary>
        /// <param name="X">complex input array</param>
        /// <returns>real part of complex array</returns>
        public static ILArray<fcomplex> real2fcomplex ( ILArray<UInt64> X) {
            int nrX = X.m_dimensions.NumberOfElements; 
            fcomplex [] retArr = new fcomplex [nrX]; 
            ILArray<fcomplex> ret = new ILArray<fcomplex> (retArr,X.m_dimensions); 
            for (int i= 0; i < nrX; i++) {
                retArr[i] = new  fcomplex ((float) X.GetValue(i),(float) 0.0); 
            }
            return ret; 
        }

        /// <summary>
        /// create complex array out of real and imaginary part
        /// </summary>
        /// <param name="real">real array for real part</param>
        /// <param name="imag">real array for imaginary part</param>
        /// <returns>complex array having the real- and part imaginary parts constructed out of 
        /// real and imag.</returns>
        /// <remarks>real and imag must be the same length. Eather one may be a row- or a column vector.
        /// The array returned will be the same size as real.</remarks>
        public static ILArray<fcomplex> real2fcomplex ( ILArray<UInt64> real, ILArray<UInt64> imag) {
            int nrX = real.m_dimensions.NumberOfElements; 
            fcomplex [] retArr = new fcomplex [nrX]; 
            ILArray<fcomplex> ret = new ILArray<fcomplex> (retArr,real.m_dimensions); 
            for (int i= 0; i < nrX; i++) {
                retArr[i] = new  fcomplex ((float) real.GetValue(i),(float) imag.GetValue(i)); 
            }
            return ret; 
        }
       
        /// <summary>
        /// real part of complex array
        /// </summary>
        /// <param name="X">complex input array</param>
        /// <returns>real part of complex array</returns>
        public static ILArray<fcomplex> real2fcomplex ( ILArray<UInt32> X) {
            int nrX = X.m_dimensions.NumberOfElements; 
            fcomplex [] retArr = new fcomplex [nrX]; 
            ILArray<fcomplex> ret = new ILArray<fcomplex> (retArr,X.m_dimensions); 
            for (int i= 0; i < nrX; i++) {
                retArr[i] = new  fcomplex ((float) X.GetValue(i),(float) 0.0); 
            }
            return ret; 
        }

        /// <summary>
        /// create complex array out of real and imaginary part
        /// </summary>
        /// <param name="real">real array for real part</param>
        /// <param name="imag">real array for imaginary part</param>
        /// <returns>complex array having the real- and part imaginary parts constructed out of 
        /// real and imag.</returns>
        /// <remarks>real and imag must be the same length. Eather one may be a row- or a column vector.
        /// The array returned will be the same size as real.</remarks>
        public static ILArray<fcomplex> real2fcomplex ( ILArray<UInt32> real, ILArray<UInt32> imag) {
            int nrX = real.m_dimensions.NumberOfElements; 
            fcomplex [] retArr = new fcomplex [nrX]; 
            ILArray<fcomplex> ret = new ILArray<fcomplex> (retArr,real.m_dimensions); 
            for (int i= 0; i < nrX; i++) {
                retArr[i] = new  fcomplex ((float) real.GetValue(i),(float) imag.GetValue(i)); 
            }
            return ret; 
        }
       
        /// <summary>
        /// real part of complex array
        /// </summary>
        /// <param name="X">complex input array</param>
        /// <returns>real part of complex array</returns>
        public static ILArray<fcomplex> real2fcomplex ( ILArray<UInt16> X) {
            int nrX = X.m_dimensions.NumberOfElements; 
            fcomplex [] retArr = new fcomplex [nrX]; 
            ILArray<fcomplex> ret = new ILArray<fcomplex> (retArr,X.m_dimensions); 
            for (int i= 0; i < nrX; i++) {
                retArr[i] = new  fcomplex ((float) X.GetValue(i),(float) 0.0); 
            }
            return ret; 
        }

        /// <summary>
        /// create complex array out of real and imaginary part
        /// </summary>
        /// <param name="real">real array for real part</param>
        /// <param name="imag">real array for imaginary part</param>
        /// <returns>complex array having the real- and part imaginary parts constructed out of 
        /// real and imag.</returns>
        /// <remarks>real and imag must be the same length. Eather one may be a row- or a column vector.
        /// The array returned will be the same size as real.</remarks>
        public static ILArray<fcomplex> real2fcomplex ( ILArray<UInt16> real, ILArray<UInt16> imag) {
            int nrX = real.m_dimensions.NumberOfElements; 
            fcomplex [] retArr = new fcomplex [nrX]; 
            ILArray<fcomplex> ret = new ILArray<fcomplex> (retArr,real.m_dimensions); 
            for (int i= 0; i < nrX; i++) {
                retArr[i] = new  fcomplex ((float) real.GetValue(i),(float) imag.GetValue(i)); 
            }
            return ret; 
        }
       
        /// <summary>
        /// real part of complex array
        /// </summary>
        /// <param name="X">complex input array</param>
        /// <returns>real part of complex array</returns>
        public static ILArray<fcomplex> real2fcomplex ( ILArray<Int64> X) {
            int nrX = X.m_dimensions.NumberOfElements; 
            fcomplex [] retArr = new fcomplex [nrX]; 
            ILArray<fcomplex> ret = new ILArray<fcomplex> (retArr,X.m_dimensions); 
            for (int i= 0; i < nrX; i++) {
                retArr[i] = new  fcomplex ((float) X.GetValue(i),(float) 0.0); 
            }
            return ret; 
        }

        /// <summary>
        /// create complex array out of real and imaginary part
        /// </summary>
        /// <param name="real">real array for real part</param>
        /// <param name="imag">real array for imaginary part</param>
        /// <returns>complex array having the real- and part imaginary parts constructed out of 
        /// real and imag.</returns>
        /// <remarks>real and imag must be the same length. Eather one may be a row- or a column vector.
        /// The array returned will be the same size as real.</remarks>
        public static ILArray<fcomplex> real2fcomplex ( ILArray<Int64> real, ILArray<Int64> imag) {
            int nrX = real.m_dimensions.NumberOfElements; 
            fcomplex [] retArr = new fcomplex [nrX]; 
            ILArray<fcomplex> ret = new ILArray<fcomplex> (retArr,real.m_dimensions); 
            for (int i= 0; i < nrX; i++) {
                retArr[i] = new  fcomplex ((float) real.GetValue(i),(float) imag.GetValue(i)); 
            }
            return ret; 
        }
       
        /// <summary>
        /// real part of complex array
        /// </summary>
        /// <param name="X">complex input array</param>
        /// <returns>real part of complex array</returns>
        public static ILArray<fcomplex> real2fcomplex ( ILArray<Int32> X) {
            int nrX = X.m_dimensions.NumberOfElements; 
            fcomplex [] retArr = new fcomplex [nrX]; 
            ILArray<fcomplex> ret = new ILArray<fcomplex> (retArr,X.m_dimensions); 
            for (int i= 0; i < nrX; i++) {
                retArr[i] = new  fcomplex ((float) X.GetValue(i),(float) 0.0); 
            }
            return ret; 
        }

        /// <summary>
        /// create complex array out of real and imaginary part
        /// </summary>
        /// <param name="real">real array for real part</param>
        /// <param name="imag">real array for imaginary part</param>
        /// <returns>complex array having the real- and part imaginary parts constructed out of 
        /// real and imag.</returns>
        /// <remarks>real and imag must be the same length. Eather one may be a row- or a column vector.
        /// The array returned will be the same size as real.</remarks>
        public static ILArray<fcomplex> real2fcomplex ( ILArray<Int32> real, ILArray<Int32> imag) {
            int nrX = real.m_dimensions.NumberOfElements; 
            fcomplex [] retArr = new fcomplex [nrX]; 
            ILArray<fcomplex> ret = new ILArray<fcomplex> (retArr,real.m_dimensions); 
            for (int i= 0; i < nrX; i++) {
                retArr[i] = new  fcomplex ((float) real.GetValue(i),(float) imag.GetValue(i)); 
            }
            return ret; 
        }
       
        /// <summary>
        /// real part of complex array
        /// </summary>
        /// <param name="X">complex input array</param>
        /// <returns>real part of complex array</returns>
        public static ILArray<fcomplex> real2fcomplex ( ILArray<Int16> X) {
            int nrX = X.m_dimensions.NumberOfElements; 
            fcomplex [] retArr = new fcomplex [nrX]; 
            ILArray<fcomplex> ret = new ILArray<fcomplex> (retArr,X.m_dimensions); 
            for (int i= 0; i < nrX; i++) {
                retArr[i] = new  fcomplex ((float) X.GetValue(i),(float) 0.0); 
            }
            return ret; 
        }

        /// <summary>
        /// create complex array out of real and imaginary part
        /// </summary>
        /// <param name="real">real array for real part</param>
        /// <param name="imag">real array for imaginary part</param>
        /// <returns>complex array having the real- and part imaginary parts constructed out of 
        /// real and imag.</returns>
        /// <remarks>real and imag must be the same length. Eather one may be a row- or a column vector.
        /// The array returned will be the same size as real.</remarks>
        public static ILArray<fcomplex> real2fcomplex ( ILArray<Int16> real, ILArray<Int16> imag) {
            int nrX = real.m_dimensions.NumberOfElements; 
            fcomplex [] retArr = new fcomplex [nrX]; 
            ILArray<fcomplex> ret = new ILArray<fcomplex> (retArr,real.m_dimensions); 
            for (int i= 0; i < nrX; i++) {
                retArr[i] = new  fcomplex ((float) real.GetValue(i),(float) imag.GetValue(i)); 
            }
            return ret; 
        }
       
        /// <summary>
        /// real part of complex array
        /// </summary>
        /// <param name="X">complex input array</param>
        /// <returns>real part of complex array</returns>
        public static ILArray<fcomplex> real2fcomplex ( ILArray<float> X) {
            int nrX = X.m_dimensions.NumberOfElements; 
            fcomplex [] retArr = new fcomplex [nrX]; 
            ILArray<fcomplex> ret = new ILArray<fcomplex> (retArr,X.m_dimensions); 
            for (int i= 0; i < nrX; i++) {
                retArr[i] = new  fcomplex ((float) X.GetValue(i),(float) 0.0); 
            }
            return ret; 
        }

        /// <summary>
        /// create complex array out of real and imaginary part
        /// </summary>
        /// <param name="real">real array for real part</param>
        /// <param name="imag">real array for imaginary part</param>
        /// <returns>complex array having the real- and part imaginary parts constructed out of 
        /// real and imag.</returns>
        /// <remarks>real and imag must be the same length. Eather one may be a row- or a column vector.
        /// The array returned will be the same size as real.</remarks>
        public static ILArray<fcomplex> real2fcomplex ( ILArray<float> real, ILArray<float> imag) {
            int nrX = real.m_dimensions.NumberOfElements; 
            fcomplex [] retArr = new fcomplex [nrX]; 
            ILArray<fcomplex> ret = new ILArray<fcomplex> (retArr,real.m_dimensions); 
            for (int i= 0; i < nrX; i++) {
                retArr[i] = new  fcomplex ((float) real.GetValue(i),(float) imag.GetValue(i)); 
            }
            return ret; 
        }
       

#endregion HYCALPER AUTO GENERATED CODE
    }

}
