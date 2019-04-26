/*
 * float.h
 * This file has no copyright assigned and is placed in the Public Domain.
 * This file is part of the mingw-runtime package.
 * No warranty is given; refer to the file DISCLAIMER.PD within the package.
 *
 * Constants related to floating point arithmetic.
 *
 * Also included here are some non-ANSI bits for accessing the floating
 * point controller.
 *
 */

#if defined(__LIBMSVCRT__)
/* When building mingw-w64, this should be blank.  */
#define _SECIMP
#else
#ifndef _SECIMP
#define _SECIMP __declspec(dllimport)
#endif /* _SECIMP */
#endif /* defined(_CRTBLD) || defined(__LIBMSVCRT__) */

#if (defined (__GNUC__) && defined (__GNUC_MINOR__)) \
    || (defined(__clang__) && defined(__clang_major__))
#if (__GNUC__ < 4  || (__GNUC__ == 4 && __GNUC_MINOR__ < 6)) \
    || (__clang_major__ >=3)
#if !defined(_FLOAT_H___) && !defined(__FLOAT_H)
/* Copyright (C) 2002-2018 Free Software Foundation, Inc.

This file is part of GCC.

GCC is free software; you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation; either version 3, or (at your option)
any later version.

GCC is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

Under Section 7 of GPL version 3, you are granted additional
permissions described in the GCC Runtime Library Exception, version
3.1, as published by the Free Software Foundation.

You should have received a copy of the GNU General Public License and
a copy of the GCC Runtime Library Exception along with this program;
see the files COPYING3 and COPYING.RUNTIME respectively.  If not, see
<http://www.gnu.org/licenses/>.  */

/*
 * ISO C Standard:  5.2.4.2.2  Characteristics of floating types <float.h>
 */

#ifndef _FLOAT_H___
#define _FLOAT_H___

/* Radix of exponent representation, b. */
#undef FLT_RADIX
#define FLT_RADIX	__FLT_RADIX__

/* Number of base-FLT_RADIX digits in the significand, p.  */
#undef FLT_MANT_DIG
#undef DBL_MANT_DIG
#undef LDBL_MANT_DIG
#define FLT_MANT_DIG	__FLT_MANT_DIG__
#define DBL_MANT_DIG	__DBL_MANT_DIG__
#define LDBL_MANT_DIG	__LDBL_MANT_DIG__

/* Number of decimal digits, q, such that any floating-point number with q
   decimal digits can be rounded into a floating-point number with p radix b
   digits and back again without change to the q decimal digits,

	p * log10(b)			if b is a power of 10
	floor((p - 1) * log10(b))	otherwise
*/
#undef FLT_DIG
#undef DBL_DIG
#undef LDBL_DIG
#define FLT_DIG		__FLT_DIG__
#define DBL_DIG		__DBL_DIG__
#define LDBL_DIG	__LDBL_DIG__

/* Minimum int x such that FLT_RADIX**(x-1) is a normalized float, emin */
#undef FLT_MIN_EXP
#undef DBL_MIN_EXP
#undef LDBL_MIN_EXP
#define FLT_MIN_EXP	__FLT_MIN_EXP__
#define DBL_MIN_EXP	__DBL_MIN_EXP__
#define LDBL_MIN_EXP	__LDBL_MIN_EXP__

/* Minimum negative integer such that 10 raised to that power is in the
   range of normalized floating-point numbers,

	ceil(log10(b) * (emin - 1))
*/
#undef FLT_MIN_10_EXP
#undef DBL_MIN_10_EXP
#undef LDBL_MIN_10_EXP
#define FLT_MIN_10_EXP	__FLT_MIN_10_EXP__
#define DBL_MIN_10_EXP	__DBL_MIN_10_EXP__
#define LDBL_MIN_10_EXP	__LDBL_MIN_10_EXP__

/* Maximum int x such that FLT_RADIX**(x-1) is a representable float, emax.  */
#undef FLT_MAX_EXP
#undef DBL_MAX_EXP
#undef LDBL_MAX_EXP
#define FLT_MAX_EXP	__FLT_MAX_EXP__
#define DBL_MAX_EXP	__DBL_MAX_EXP__
#define LDBL_MAX_EXP	__LDBL_MAX_EXP__

/* Maximum integer such that 10 raised to that power is in the range of
   representable finite floating-point numbers,

	floor(log10((1 - b**-p) * b**emax))
*/
#undef FLT_MAX_10_EXP
#undef DBL_MAX_10_EXP
#undef LDBL_MAX_10_EXP
#define FLT_MAX_10_EXP	__FLT_MAX_10_EXP__
#define DBL_MAX_10_EXP	__DBL_MAX_10_EXP__
#define LDBL_MAX_10_EXP	__LDBL_MAX_10_EXP__

/* Maximum representable finite floating-point number,

	(1 - b**-p) * b**emax
*/
#undef FLT_MAX
#undef DBL_MAX
#undef LDBL_MAX
#define FLT_MAX		__FLT_MAX__
#define DBL_MAX		__DBL_MAX__
#define LDBL_MAX	__LDBL_MAX__

/* The difference between 1 and the least value greater than 1 that is
   representable in the given floating point type, b**1-p.  */
#undef FLT_EPSILON
#undef DBL_EPSILON
#undef LDBL_EPSILON
#define FLT_EPSILON	__FLT_EPSILON__
#define DBL_EPSILON	__DBL_EPSILON__
#define LDBL_EPSILON	__LDBL_EPSILON__

/* Minimum normalized positive floating-point number, b**(emin - 1).  */
#undef FLT_MIN
#undef DBL_MIN
#undef LDBL_MIN
#define FLT_MIN		__FLT_MIN__
#define DBL_MIN		__DBL_MIN__
#define LDBL_MIN	__LDBL_MIN__

/* Addition rounds to 0: zero, 1: nearest, 2: +inf, 3: -inf, -1: unknown.  */
/* ??? This is supposed to change with calls to fesetround in <fenv.h>.  */
#undef FLT_ROUNDS
#define FLT_ROUNDS 1

#if (defined (__STDC_VERSION__) && __STDC_VERSION__ >= 199901L) \
     || (defined (__cplusplus) && __cplusplus >= 201103L)
/* The floating-point expression evaluation method.  The precise
   definitions of these values are generalised to include support for
   the interchange and extended types defined in ISO/IEC TS 18661-3.
   Prior to this (for C99/C11) the definitions were:

	-1  indeterminate
	 0  evaluate all operations and constants just to the range and
	    precision of the type
	 1  evaluate operations and constants of type float and double
	    to the range and precision of the double type, evaluate
	    long double operations and constants to the range and
	    precision of the long double type
	 2  evaluate all operations and constants to the range and
	    precision of the long double type

   The TS 18661-3 definitions are:

	-1  indeterminate
	 0  evaluate all operations and constants, whose semantic type has
	    at most the range and precision of float, to the range and
	    precision of float; evaluate all other operations and constants
	    to the range and precision of the semantic type.
	 1  evaluate all operations and constants, whose semantic type has
	    at most the range and precision of double, to the range and
	    precision of double; evaluate all other operations and constants
	    to the range and precision of the semantic type.
	 2  evaluate all operations and constants, whose semantic type has
	    at most the range and precision of long double, to the range and
	    precision of long double; evaluate all other operations and
	    constants to the range and precision of the semantic type.
	 N  where _FloatN  is a supported interchange floating type
	    evaluate all operations and constants, whose semantic type has
	    at most the range and precision of the _FloatN type, to the
	    range and precision of the _FloatN type; evaluate all other
	    operations and constants to the range and precision of the
	    semantic type.
	 N + 1, where _FloatNx is a supported extended floating type
	    evaluate operations and constants, whose semantic type has at
	    most the range and precision of the _FloatNx type, to the range
	    and precision of the _FloatNx type; evaluate all other
	    operations and constants to the range and precision of the
	    semantic type.

   The compiler predefines two macros:

      __FLT_EVAL_METHOD__
      Which, depending on the value given for
      -fpermitted-flt-eval-methods, may be limited to only those values
      for FLT_EVAL_METHOD defined in C99/C11.

     __FLT_EVAL_METHOD_TS_18661_3__
      Which always permits the values for FLT_EVAL_METHOD defined in
      ISO/IEC TS 18661-3.

     Here we want to use __FLT_EVAL_METHOD__, unless
     __STDC_WANT_IEC_60559_TYPES_EXT__ is defined, in which case the user
     is specifically asking for the ISO/IEC TS 18661-3 types, so we use
     __FLT_EVAL_METHOD_TS_18661_3__.

   ??? This ought to change with the setting of the fp control word;
   the value provided by the compiler assumes the widest setting.  */
#undef FLT_EVAL_METHOD
#ifdef __STDC_WANT_IEC_60559_TYPES_EXT__
#define FLT_EVAL_METHOD __FLT_EVAL_METHOD_TS_18661_3__
#else
#define FLT_EVAL_METHOD	__FLT_EVAL_METHOD__
#endif

/* Number of decimal digits, n, such that any floating-point number in the
   widest supported floating type with pmax radix b digits can be rounded
   to a floating-point number with n decimal digits and back again without
   change to the value,

	pmax * log10(b)			if b is a power of 10
	ceil(1 + pmax * log10(b))	otherwise
*/
#undef DECIMAL_DIG
#define DECIMAL_DIG	__DECIMAL_DIG__

#endif /* C99 */

#if defined (__STDC_VERSION__) && __STDC_VERSION__ >= 201112L
/* Versions of DECIMAL_DIG for each floating-point type.  */
#undef FLT_DECIMAL_DIG
#undef DBL_DECIMAL_DIG
#undef LDBL_DECIMAL_DIG
#define FLT_DECIMAL_DIG		__FLT_DECIMAL_DIG__
#define DBL_DECIMAL_DIG		__DBL_DECIMAL_DIG__
#define LDBL_DECIMAL_DIG	__LDBL_DECIMAL_DIG__

/* Whether types support subnormal numbers.  */
#undef FLT_HAS_SUBNORM
#undef DBL_HAS_SUBNORM
#undef LDBL_HAS_SUBNORM
#define FLT_HAS_SUBNORM		__FLT_HAS_DENORM__
#define DBL_HAS_SUBNORM		__DBL_HAS_DENORM__
#define LDBL_HAS_SUBNORM	__LDBL_HAS_DENORM__

/* Minimum positive values, including subnormals.  */
#undef FLT_TRUE_MIN
#undef DBL_TRUE_MIN
#undef LDBL_TRUE_MIN
#define FLT_TRUE_MIN	__FLT_DENORM_MIN__
#define DBL_TRUE_MIN	__DBL_DENORM_MIN__
#define LDBL_TRUE_MIN	__LDBL_DENORM_MIN__

#endif /* C11 */

#ifdef __STDC_WANT_IEC_60559_BFP_EXT__
/* Number of decimal digits for which conversions between decimal
   character strings and binary formats, in both directions, are
   correctly rounded.  */
#define CR_DECIMAL_DIG	__UINTMAX_MAX__
#endif

#ifdef __STDC_WANT_IEC_60559_TYPES_EXT__
/* Constants for _FloatN and _FloatNx types from TS 18661-3.  See
   comments above for their semantics.  */

#ifdef __FLT16_MANT_DIG__
#undef FLT16_MANT_DIG
#define FLT16_MANT_DIG		__FLT16_MANT_DIG__
#undef FLT16_DIG
#define FLT16_DIG		__FLT16_DIG__
#undef FLT16_MIN_EXP
#define FLT16_MIN_EXP		__FLT16_MIN_EXP__
#undef FLT16_MIN_10_EXP
#define FLT16_MIN_10_EXP	__FLT16_MIN_10_EXP__
#undef FLT16_MAX_EXP
#define FLT16_MAX_EXP		__FLT16_MAX_EXP__
#undef FLT16_MAX_10_EXP
#define FLT16_MAX_10_EXP	__FLT16_MAX_10_EXP__
#undef FLT16_MAX
#define FLT16_MAX		__FLT16_MAX__
#undef FLT16_EPSILON
#define FLT16_EPSILON		__FLT16_EPSILON__
#undef FLT16_MIN
#define FLT16_MIN		__FLT16_MIN__
#undef FLT16_DECIMAL_DIG
#define FLT16_DECIMAL_DIG	__FLT16_DECIMAL_DIG__
#undef FLT16_TRUE_MIN
#define FLT16_TRUE_MIN		__FLT16_DENORM_MIN__
#endif /* __FLT16_MANT_DIG__.  */

#ifdef __FLT32_MANT_DIG__
#undef FLT32_MANT_DIG
#define FLT32_MANT_DIG		__FLT32_MANT_DIG__
#undef FLT32_DIG
#define FLT32_DIG		__FLT32_DIG__
#undef FLT32_MIN_EXP
#define FLT32_MIN_EXP		__FLT32_MIN_EXP__
#undef FLT32_MIN_10_EXP
#define FLT32_MIN_10_EXP	__FLT32_MIN_10_EXP__
#undef FLT32_MAX_EXP
#define FLT32_MAX_EXP		__FLT32_MAX_EXP__
#undef FLT32_MAX_10_EXP
#define FLT32_MAX_10_EXP	__FLT32_MAX_10_EXP__
#undef FLT32_MAX
#define FLT32_MAX		__FLT32_MAX__
#undef FLT32_EPSILON
#define FLT32_EPSILON		__FLT32_EPSILON__
#undef FLT32_MIN
#define FLT32_MIN		__FLT32_MIN__
#undef FLT32_DECIMAL_DIG
#define FLT32_DECIMAL_DIG	__FLT32_DECIMAL_DIG__
#undef FLT32_TRUE_MIN
#define FLT32_TRUE_MIN		__FLT32_DENORM_MIN__
#endif /* __FLT32_MANT_DIG__.  */

#ifdef __FLT64_MANT_DIG__
#undef FLT64_MANT_DIG
#define FLT64_MANT_DIG		__FLT64_MANT_DIG__
#undef FLT64_DIG
#define FLT64_DIG		__FLT64_DIG__
#undef FLT64_MIN_EXP
#define FLT64_MIN_EXP		__FLT64_MIN_EXP__
#undef FLT64_MIN_10_EXP
#define FLT64_MIN_10_EXP	__FLT64_MIN_10_EXP__
#undef FLT64_MAX_EXP
#define FLT64_MAX_EXP		__FLT64_MAX_EXP__
#undef FLT64_MAX_10_EXP
#define FLT64_MAX_10_EXP	__FLT64_MAX_10_EXP__
#undef FLT64_MAX
#define FLT64_MAX		__FLT64_MAX__
#undef FLT64_EPSILON
#define FLT64_EPSILON		__FLT64_EPSILON__
#undef FLT64_MIN
#define FLT64_MIN		__FLT64_MIN__
#undef FLT64_DECIMAL_DIG
#define FLT64_DECIMAL_DIG	__FLT64_DECIMAL_DIG__
#undef FLT64_TRUE_MIN
#define FLT64_TRUE_MIN		__FLT64_DENORM_MIN__
#endif /* __FLT64_MANT_DIG__.  */

#ifdef __FLT128_MANT_DIG__
#undef FLT128_MANT_DIG
#define FLT128_MANT_DIG		__FLT128_MANT_DIG__
#undef FLT128_DIG
#define FLT128_DIG		__FLT128_DIG__
#undef FLT128_MIN_EXP
#define FLT128_MIN_EXP		__FLT128_MIN_EXP__
#undef FLT128_MIN_10_EXP
#define FLT128_MIN_10_EXP	__FLT128_MIN_10_EXP__
#undef FLT128_MAX_EXP
#define FLT128_MAX_EXP		__FLT128_MAX_EXP__
#undef FLT128_MAX_10_EXP
#define FLT128_MAX_10_EXP	__FLT128_MAX_10_EXP__
#undef FLT128_MAX
#define FLT128_MAX		__FLT128_MAX__
#undef FLT128_EPSILON
#define FLT128_EPSILON		__FLT128_EPSILON__
#undef FLT128_MIN
#define FLT128_MIN		__FLT128_MIN__
#undef FLT128_DECIMAL_DIG
#define FLT128_DECIMAL_DIG	__FLT128_DECIMAL_DIG__
#undef FLT128_TRUE_MIN
#define FLT128_TRUE_MIN		__FLT128_DENORM_MIN__
#endif /* __FLT128_MANT_DIG__.  */

#ifdef __FLT32X_MANT_DIG__
#undef FLT32X_MANT_DIG
#define FLT32X_MANT_DIG		__FLT32X_MANT_DIG__
#undef FLT32X_DIG
#define FLT32X_DIG		__FLT32X_DIG__
#undef FLT32X_MIN_EXP
#define FLT32X_MIN_EXP		__FLT32X_MIN_EXP__
#undef FLT32X_MIN_10_EXP
#define FLT32X_MIN_10_EXP	__FLT32X_MIN_10_EXP__
#undef FLT32X_MAX_EXP
#define FLT32X_MAX_EXP		__FLT32X_MAX_EXP__
#undef FLT32X_MAX_10_EXP
#define FLT32X_MAX_10_EXP	__FLT32X_MAX_10_EXP__
#undef FLT32X_MAX
#define FLT32X_MAX		__FLT32X_MAX__
#undef FLT32X_EPSILON
#define FLT32X_EPSILON		__FLT32X_EPSILON__
#undef FLT32X_MIN
#define FLT32X_MIN		__FLT32X_MIN__
#undef FLT32X_DECIMAL_DIG
#define FLT32X_DECIMAL_DIG	__FLT32X_DECIMAL_DIG__
#undef FLT32X_TRUE_MIN
#define FLT32X_TRUE_MIN		__FLT32X_DENORM_MIN__
#endif /* __FLT32X_MANT_DIG__.  */

#ifdef __FLT64X_MANT_DIG__
#undef FLT64X_MANT_DIG
#define FLT64X_MANT_DIG		__FLT64X_MANT_DIG__
#undef FLT64X_DIG
#define FLT64X_DIG		__FLT64X_DIG__
#undef FLT64X_MIN_EXP
#define FLT64X_MIN_EXP		__FLT64X_MIN_EXP__
#undef FLT64X_MIN_10_EXP
#define FLT64X_MIN_10_EXP	__FLT64X_MIN_10_EXP__
#undef FLT64X_MAX_EXP
#define FLT64X_MAX_EXP		__FLT64X_MAX_EXP__
#undef FLT64X_MAX_10_EXP
#define FLT64X_MAX_10_EXP	__FLT64X_MAX_10_EXP__
#undef FLT64X_MAX
#define FLT64X_MAX		__FLT64X_MAX__
#undef FLT64X_EPSILON
#define FLT64X_EPSILON		__FLT64X_EPSILON__
#undef FLT64X_MIN
#define FLT64X_MIN		__FLT64X_MIN__
#undef FLT64X_DECIMAL_DIG
#define FLT64X_DECIMAL_DIG	__FLT64X_DECIMAL_DIG__
#undef FLT64X_TRUE_MIN
#define FLT64X_TRUE_MIN		__FLT64X_DENORM_MIN__
#endif /* __FLT64X_MANT_DIG__.  */

#ifdef __FLT128X_MANT_DIG__
#undef FLT128X_MANT_DIG
#define FLT128X_MANT_DIG	__FLT128X_MANT_DIG__
#undef FLT128X_DIG
#define FLT128X_DIG		__FLT128X_DIG__
#undef FLT128X_MIN_EXP
#define FLT128X_MIN_EXP		__FLT128X_MIN_EXP__
#undef FLT128X_MIN_10_EXP
#define FLT128X_MIN_10_EXP	__FLT128X_MIN_10_EXP__
#undef FLT128X_MAX_EXP
#define FLT128X_MAX_EXP		__FLT128X_MAX_EXP__
#undef FLT128X_MAX_10_EXP
#define FLT128X_MAX_10_EXP	__FLT128X_MAX_10_EXP__
#undef FLT128X_MAX
#define FLT128X_MAX		__FLT128X_MAX__
#undef FLT128X_EPSILON
#define FLT128X_EPSILON		__FLT128X_EPSILON__
#undef FLT128X_MIN
#define FLT128X_MIN		__FLT128X_MIN__
#undef FLT128X_DECIMAL_DIG
#define FLT128X_DECIMAL_DIG	__FLT128X_DECIMAL_DIG__
#undef FLT128X_TRUE_MIN
#define FLT128X_TRUE_MIN	__FLT128X_DENORM_MIN__
#endif /* __FLT128X_MANT_DIG__.  */

#endif /* __STDC_WANT_IEC_60559_TYPES_EXT__.  */

#ifdef __STDC_WANT_DEC_FP__
/* Draft Technical Report 24732, extension for decimal floating-point
   arithmetic: Characteristic of decimal floating types <float.h>.  */

/* Number of base-FLT_RADIX digits in the significand, p.  */
#undef DEC32_MANT_DIG
#undef DEC64_MANT_DIG
#undef DEC128_MANT_DIG
#define DEC32_MANT_DIG	__DEC32_MANT_DIG__
#define DEC64_MANT_DIG	__DEC64_MANT_DIG__
#define DEC128_MANT_DIG	__DEC128_MANT_DIG__

/* Minimum exponent. */
#undef DEC32_MIN_EXP
#undef DEC64_MIN_EXP
#undef DEC128_MIN_EXP
#define DEC32_MIN_EXP	__DEC32_MIN_EXP__
#define DEC64_MIN_EXP	__DEC64_MIN_EXP__
#define DEC128_MIN_EXP	__DEC128_MIN_EXP__

/* Maximum exponent. */
#undef DEC32_MAX_EXP
#undef DEC64_MAX_EXP
#undef DEC128_MAX_EXP
#define DEC32_MAX_EXP	__DEC32_MAX_EXP__
#define DEC64_MAX_EXP	__DEC64_MAX_EXP__
#define DEC128_MAX_EXP	__DEC128_MAX_EXP__

/* Maximum representable finite decimal floating-point number
   (there are 6, 15, and 33 9s after the decimal points respectively). */
#undef DEC32_MAX
#undef DEC64_MAX
#undef DEC128_MAX
#define DEC32_MAX   __DEC32_MAX__
#define DEC64_MAX   __DEC64_MAX__
#define DEC128_MAX  __DEC128_MAX__

/* The difference between 1 and the least value greater than 1 that is
   representable in the given floating point type. */
#undef DEC32_EPSILON
#undef DEC64_EPSILON
#undef DEC128_EPSILON
#define DEC32_EPSILON	__DEC32_EPSILON__
#define DEC64_EPSILON	__DEC64_EPSILON__
#define DEC128_EPSILON	__DEC128_EPSILON__

/* Minimum normalized positive floating-point number. */
#undef DEC32_MIN
#undef DEC64_MIN
#undef DEC128_MIN
#define DEC32_MIN	__DEC32_MIN__
#define DEC64_MIN	__DEC64_MIN__
#define DEC128_MIN	__DEC128_MIN__

/* Minimum subnormal positive floating-point number. */
#undef DEC32_SUBNORMAL_MIN
#undef DEC64_SUBNORMAL_MIN
#undef DEC128_SUBNORMAL_MIN
#define DEC32_SUBNORMAL_MIN       __DEC32_SUBNORMAL_MIN__
#define DEC64_SUBNORMAL_MIN       __DEC64_SUBNORMAL_MIN__
#define DEC128_SUBNORMAL_MIN      __DEC128_SUBNORMAL_MIN__

/* The floating-point expression evaluation method.
         -1  indeterminate
         0  evaluate all operations and constants just to the range and
            precision of the type
         1  evaluate operations and constants of type _Decimal32 
	    and _Decimal64 to the range and precision of the _Decimal64 
            type, evaluate _Decimal128 operations and constants to the 
	    range and precision of the _Decimal128 type;
	 2  evaluate all operations and constants to the range and
	    precision of the _Decimal128 type.  */

#undef DEC_EVAL_METHOD
#define DEC_EVAL_METHOD	__DEC_EVAL_METHOD__

#endif /* __STDC_WANT_DEC_FP__ */

#endif /* _FLOAT_H___ */

#endif
#elif !defined (_FLOAT_H___)
#if (__GNUC__ < 4)
#error Corrupt install of gcc-s internal headers, or search order was changed.
#else
	/* #include_next <float_ginclude.h> */
	
   	/* Number of decimal digits, q, such that any floating-point number with q
   	   decimal digits can be rounded into a floating-point number with p radix b
	   digits and back again without change to the q decimal digits,

	   p * log10(b)			if b is a power of 10
	   floor((p - 1) * log10(b))	otherwise
	*/
	#undef FLT_DIG
	#undef DBL_DIG
	#undef LDBL_DIG
	#define FLT_DIG		__FLT_DIG__
	#define DBL_DIG		__DBL_DIG__
	#define LDBL_DIG	__LDBL_DIG__
	
	
	/* Maximum representable finite floating-point number,

	   (1 - b**-p) * b**emax
	*/
	#undef FLT_MAX
	#undef DBL_MAX
	#undef LDBL_MAX
	#define FLT_MAX		__FLT_MAX__
	#define DBL_MAX		__DBL_MAX__
	#define LDBL_MAX	__LDBL_MAX__
	
	
	/* Minimum normalized positive floating-point number, b**(emin - 1).  */
	#undef FLT_MIN
	#undef DBL_MIN
	#undef LDBL_MIN
	#define FLT_MIN		__FLT_MIN__
	#define DBL_MIN		__DBL_MIN__
	#define LDBL_MIN	__LDBL_MIN__
	
	/* Needed for libjava building - Victor K. */

	/* Radix of exponent representation, b. */
    #undef FLT_RADIX
    #define FLT_RADIX	__FLT_RADIX__
    
    /* Minimum int x such that FLT_RADIX**(x-1) is a normalized float, emin */
	#undef FLT_MIN_EXP
	#undef DBL_MIN_EXP
	#undef LDBL_MIN_EXP
	#define FLT_MIN_EXP	__FLT_MIN_EXP__
	#define DBL_MIN_EXP	__DBL_MIN_EXP__
	#define LDBL_MIN_EXP	__LDBL_MIN_EXP__

	/* Minimum negative integer such that 10 raised to that power is in the
   	range of normalized floating-point numbers,

	ceil(log10(b) * (emin - 1))
	*/
	#undef FLT_MIN_10_EXP
	#undef DBL_MIN_10_EXP
	#undef LDBL_MIN_10_EXP
	#define FLT_MIN_10_EXP	__FLT_MIN_10_EXP__
	#define DBL_MIN_10_EXP	__DBL_MIN_10_EXP__
	#define LDBL_MIN_10_EXP	__LDBL_MIN_10_EXP__

	/* Maximum int x such that FLT_RADIX**(x-1) is a representable float, emax.  */
	#undef FLT_MAX_EXP
	#undef DBL_MAX_EXP
	#undef LDBL_MAX_EXP
	#define FLT_MAX_EXP	__FLT_MAX_EXP__
	#define DBL_MAX_EXP	__DBL_MAX_EXP__
	#define LDBL_MAX_EXP	__LDBL_MAX_EXP__

	/* Maximum integer such that 10 raised to that power is in the range of
   	representable finite floating-point numbers,

	floor(log10((1 - b**-p) * b**emax))
	*/
	#undef FLT_MAX_10_EXP
	#undef DBL_MAX_10_EXP
	#undef LDBL_MAX_10_EXP
	#define FLT_MAX_10_EXP	__FLT_MAX_10_EXP__
	#define DBL_MAX_10_EXP	__DBL_MAX_10_EXP__
	#define LDBL_MAX_10_EXP	__LDBL_MAX_10_EXP__

	/* Addition rounds to 0: zero, 1: nearest, 2: +inf, 3: -inf, -1: unknown.  */
	/* ??? This is supposed to change with calls to fesetround in <fenv.h>.  */
	#undef FLT_ROUNDS
	#define FLT_ROUNDS 1
    
	#define _FLOAT_H___
#endif
#endif
#endif

#ifndef _MINGW_FLOAT_H_
#define _MINGW_FLOAT_H_

/* All the headers include this file. */
#include <crtdefs.h>

/*
 * Functions and definitions for controlling the FPU.
 */
#ifndef	__STRICT_ANSI__

/* TODO: These constants are only valid for x86 machines */

/* Control word masks for unMask */
#define	_MCW_DN  	0x03000000  	/* Denormal control */
#define	_MCW_EM		0x0008001F	/* Error masks */
#define	_MCW_IC		0x00040000	/* Infinity */
#define	_MCW_RC		0x00000300	/* Rounding */
#define	_MCW_PC		0x00030000	/* Precision */

/* Number of base-FLT_RADIX digits in the significand, p.  */
#undef FLT_MANT_DIG
#undef DBL_MANT_DIG
#undef LDBL_MANT_DIG
#define FLT_MANT_DIG   __FLT_MANT_DIG__
#define DBL_MANT_DIG   __DBL_MANT_DIG__
#define LDBL_MANT_DIG  __LDBL_MANT_DIG__

#if defined (__STDC_VERSION__) && __STDC_VERSION__ >= 199901L
/* The floating-point expression evaluation method.
      -1  indeterminate
       0  evaluate all operations and constants just to the range and
	  precision of the type
       1  evaluate operations and constants of type float and double
	  to the range and precision of the double type, evaluate
	  long double operations and constants to the range and
	  precision of the long double type
       2  evaluate all operations and constants to the range and
	  precision of the long double type

   ??? This ought to change with the setting of the fp control word;
   the value provided by the compiler assumes the widest setting.  */
#undef FLT_EVAL_METHOD
#define FLT_EVAL_METHOD	__FLT_EVAL_METHOD__

#endif /* C99 */


/* Control word values for unNew (use with related unMask above) */
#define	_DN_SAVE	0x00000000
#define	_DN_FLUSH	0x01000000
#define	_EM_INVALID	0x00000010
#define	_EM_DENORMAL	0x00080000
#define	_EM_ZERODIVIDE	0x00000008
#define	_EM_OVERFLOW	0x00000004
#define	_EM_UNDERFLOW	0x00000002
#define	_EM_INEXACT	0x00000001
#define	_IC_AFFINE	0x00040000
#define	_IC_PROJECTIVE	0x00000000
#define	_RC_CHOP	0x00000300
#define	_RC_UP		0x00000200
#define	_RC_DOWN	0x00000100
#define	_RC_NEAR	0x00000000
#define	_PC_24		0x00020000
#define	_PC_53		0x00010000
#define	_PC_64		0x00000000

/* These are also defined in Mingw math.h, needed to work around
   GCC build issues.  */
/* Return values for fpclass. */
#ifndef __MINGW_FPCLASS_DEFINED
#define __MINGW_FPCLASS_DEFINED 1
#define	_FPCLASS_SNAN	0x0001	/* Signaling "Not a Number" */
#define	_FPCLASS_QNAN	0x0002	/* Quiet "Not a Number" */
#define	_FPCLASS_NINF	0x0004	/* Negative Infinity */
#define	_FPCLASS_NN	0x0008	/* Negative Normal */
#define	_FPCLASS_ND	0x0010	/* Negative Denormal */
#define	_FPCLASS_NZ	0x0020	/* Negative Zero */
#define	_FPCLASS_PZ	0x0040	/* Positive Zero */
#define	_FPCLASS_PD	0x0080	/* Positive Denormal */
#define	_FPCLASS_PN	0x0100	/* Positive Normal */
#define	_FPCLASS_PINF	0x0200	/* Positive Infinity */
#endif /* __MINGW_FPCLASS_DEFINED */

/* invalid subconditions (_SW_INVALID also set) */
#define _SW_UNEMULATED		0x0040  /* unemulated instruction */
#define _SW_SQRTNEG		0x0080  /* square root of a neg number */
#define _SW_STACKOVERFLOW	0x0200  /* FP stack overflow */
#define _SW_STACKUNDERFLOW	0x0400  /* FP stack underflow */

/*  Floating point error signals and return codes */
#define _FPE_INVALID		0x81
#define _FPE_DENORMAL		0x82
#define _FPE_ZERODIVIDE		0x83
#define _FPE_OVERFLOW		0x84
#define _FPE_UNDERFLOW		0x85
#define _FPE_INEXACT		0x86
#define _FPE_UNEMULATED		0x87
#define _FPE_SQRTNEG		0x88
#define _FPE_STACKOVERFLOW	0x8a
#define _FPE_STACKUNDERFLOW	0x8b
#define _FPE_EXPLICITGEN	0x8c    /* raise( SIGFPE ); */

#define CW_DEFAULT _CW_DEFAULT
#define MCW_PC  _MCW_PC
#define PC_24   _PC_24
#define PC_53   _PC_53
#define PC_64   _PC_64

#if defined(_M_IX86)
#define _CW_DEFAULT (_RC_NEAR+_PC_53+_EM_INVALID+_EM_ZERODIVIDE+_EM_OVERFLOW+_EM_UNDERFLOW+_EM_INEXACT+_EM_DENORMAL)
#elif defined(_M_IA64)
#define _CW_DEFAULT (_RC_NEAR+_PC_64+_EM_INVALID+_EM_ZERODIVIDE+_EM_OVERFLOW+_EM_UNDERFLOW+_EM_INEXACT+_EM_DENORMAL)
#elif defined(_M_AMD64)
#define _CW_DEFAULT (_RC_NEAR+_EM_INVALID+_EM_ZERODIVIDE+_EM_OVERFLOW+_EM_UNDERFLOW+_EM_INEXACT+_EM_DENORMAL)
#endif

#ifndef RC_INVOKED

#ifdef	__cplusplus
extern "C" {
#endif

/* Set the FPU control word as cw = (cw & ~unMask) | (unNew & unMask),
 * i.e. change the bits in unMask to have the values they have in unNew,
 * leaving other bits unchanged. */
_CRTIMP unsigned int __cdecl __MINGW_NOTHROW _controlfp (unsigned int unNew, unsigned int unMask) __MINGW_ATTRIB_DEPRECATED_SEC_WARN;
_SECIMP errno_t __cdecl _controlfp_s(unsigned int *_CurrentState, unsigned int _NewValue, unsigned int _Mask);
_CRTIMP unsigned int __cdecl __MINGW_NOTHROW _control87 (unsigned int unNew, unsigned int unMask);


_CRTIMP unsigned int __cdecl __MINGW_NOTHROW _clearfp (void);	/* Clear the FPU status word */
_CRTIMP unsigned int __cdecl __MINGW_NOTHROW _statusfp (void);	/* Report the FPU status word */
#define		_clear87	_clearfp
#define		_status87	_statusfp


/*
   MSVCRT.dll _fpreset initializes the control register to 0x27f,
   the status register to zero and the tag word to 0FFFFh.
   This differs from asm instruction finit/fninit which set control
   word to 0x37f (64 bit mantissa precison rather than 53 bit).
   By default, the mingw version of _fpreset sets fp control as
   per fninit. To use the MSVCRT.dll _fpreset, include CRT_fp8.o when
   building your application.	 
*/
void __cdecl __MINGW_NOTHROW _fpreset (void);
void __cdecl __MINGW_NOTHROW fpreset (void);

/* Global 'variable' for the current floating point error code. */
_CRTIMP int * __cdecl __MINGW_NOTHROW __fpecode(void);
#define	_fpecode	(*(__fpecode()))

/*
 * IEEE recommended functions.  MS puts them in float.h
 * but they really belong in math.h.
 */

#ifndef _SIGN_DEFINED
#define _SIGN_DEFINED
_CRTIMP double __cdecl __MINGW_NOTHROW _chgsign (double _X);
_CRTIMP double __cdecl __MINGW_NOTHROW _copysign (double _Number,double _Sign);
_CRTIMP double __cdecl __MINGW_NOTHROW _logb (double);
_CRTIMP double __cdecl __MINGW_NOTHROW _nextafter (double, double);
_CRTIMP double __cdecl __MINGW_NOTHROW _scalb (double, long);

_CRTIMP int __cdecl __MINGW_NOTHROW _finite (double);
_CRTIMP int __cdecl __MINGW_NOTHROW _fpclass (double);
_CRTIMP int __cdecl __MINGW_NOTHROW _isnan (double);

#define _copysignl copysignl
extern long double __cdecl _chgsignl (long double);
#endif /* _SIGN_DEFINED */

#ifdef	__cplusplus
}
#endif

#endif	/* Not RC_INVOKED */

#endif	/* Not __STRICT_ANSI__ */

#endif /* _MINGW_FLOAT_H_ */

