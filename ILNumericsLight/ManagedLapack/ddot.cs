﻿#region ORIGINS, COPYRIGHTS, AND LICENSE
/*

This C# version of LAPACK is derivied from http://www.netlib.org/clapack/,
and the original copyright and license is as follows:

Copyright (c) 1992-2008 The University of Tennessee.  All rights reserved.
$COPYRIGHT$ Additional copyrights may follow $HEADER$

Redistribution and use in source and binary forms, with or without
modification, are permitted provided that the following conditions are
met:

- Redistributions of source code must retain the above copyright
  notice, this list of conditions and the following disclaimer. 
  
- Redistributions in binary form must reproduce the above copyright
  notice, this list of conditions and the following disclaimer listed
  in this license in the documentation and/or other materials
  provided with the distribution.
  
- Neither the name of the copyright holders nor the names of its
  contributors may be used to endorse or promote products derived from
  this software without specific prior written permission.
  
THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS
"AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT  
LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR
A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT 
OWNER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL,
SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT
LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE,
DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY
THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT  
(INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE
OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
 */
#endregion

public partial class ManagedLapack
{
    public static unsafe double ddot(int n, double* dx, int incx, double* dy, int incy)
    {
        /* System generated locals */
        int i__1;
        double ret_val;

        /* Local variables */
        int i__, m, ix, iy, mp1;
        double dtemp;

        /* Parameter adjustments */
        --dy;
        --dx;

        /* Function Body */
        ret_val = 0;
        dtemp = 0;
        if (n <= 0) {
	    return ret_val;
        }
        if (incx == 1 && incy == 1) {
	    goto L20;
        }

        /*        code for unequal increments or equal increments */
        /*          not equal to 1 */

        ix = 1;
        iy = 1;
        if (incx < 0) {
	    ix = (-(n) + 1) * incx + 1;
        }
        if (incy < 0) {
	    iy = (-(n) + 1) * incy + 1;
        }
        i__1 = n;
        for (i__ = 1; i__ <= i__1; ++i__) {
	    dtemp += dx[ix] * dy[iy];
	    ix += incx;
	    iy += incy;
/* L10: */
        }
        ret_val = dtemp;
        return ret_val;

    /*        code for both increments equal to 1 */


    /*        clean-up loop */

L20:
        m = n % 5;
        if (m == 0) {
	    goto L40;
        }
        i__1 = m;
        for (i__ = 1; i__ <= i__1; ++i__) {
	    dtemp += dx[i__] * dy[i__];
    /* L30: */
        }
        if (n < 5) {
	    goto L60;
        }
L40:
        mp1 = m + 1;
        i__1 = n;
        for (i__ = mp1; i__ <= i__1; i__ += 5) {
	    dtemp = dtemp + dx[i__] * dy[i__] + dx[i__ + 1] * dy[i__ + 1] + dx[
		    i__ + 2] * dy[i__ + 2] + dx[i__ + 3] * dy[i__ + 3] + dx[i__ + 
		    4] * dy[i__ + 4];
/* L50: */
        }
L60:
        ret_val = dtemp;
        return ret_val;
    } 
}

