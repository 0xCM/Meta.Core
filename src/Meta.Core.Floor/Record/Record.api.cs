//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Linq;
using System.Collections.Generic;

using Meta.Core;

partial class metacore
{

    /// <summary>
    /// Constructs a record with 1 field
    /// </summary>
    /// <typeparam name="X1">The data type of the first column</typeparam>
    /// <param name="x1">The value in column 01</param>
    /// <returns></returns>
    public static Record<X1> record<X1>(X1 x1)
        => new Record<X1>(x1);

    /// <summary>
    /// Constructs a record with 2 fields from an explicit listing of respective field values
    /// </summary>
    /// <typeparam name="X1">The data type of the first column</typeparam>
    /// <typeparam name="X2">The data type of the second column</typeparam>
    /// <param name="x1">The value in column 01</param>
    /// <param name="x2">The value in column 02</param>
    /// <returns></returns>
    public static Record<X1, X2> record<X1, X2>(X1 x1, X2 x2)
        => Record.make(x1, x2);

    /// <summary>
    /// Constructs a record with 3 fields from an explicit listing of respective field values
    /// </summary>
    /// <typeparam name="X1">The data type of the first field</typeparam>
    /// <typeparam name="X2">The data type of the second field</typeparam>
    /// <typeparam name="X3">The data type of the third attribute</typeparam>
    /// <param name="x1">The value of field 1</param>
    /// <param name="x2">The value of field 2</param>
    /// <param name="x3">The value of field 3</param>
    /// <returns></returns>
    public static Record<X1, X2, X3> record<X1, X2, X3>(X1 x1, X2 x2, X3 x3)
        => Record.make(x1, x2, x3);

    /// <summary>
    /// Constructs a record with 4 fields from an explicit listing of respective field values
    /// </summary>
    /// <typeparam name="X1">The data type of the first field</typeparam>
    /// <typeparam name="X2">The data type of the second field</typeparam>
    /// <typeparam name="X3">The data type of the third field</typeparam>
    /// <typeparam name="X4">The data type of the fourth field</typeparam>
    /// <param name="x1">The value of field 1</param>
    /// <param name="x2">The value of field 2</param>
    /// <param name="x3">The value of field 3</param>
    /// <param name="x4">The value of field 4</param>
    /// <returns></returns>
    public static Record<X1, X2, X3, X4> record<X1, X2, X3, X4>(X1 x1, X2 x2, X3 x3, X4 x4)
        => Record.make(x1, x2, x3, x4);

    /// <summary>
    /// Constructs a record with 5 fields from an explicit listing of respective field values
    /// </summary>
    /// <typeparam name="X1">The data type of the first field</typeparam>
    /// <typeparam name="X2">The data type of the second field</typeparam>
    /// <typeparam name="X3">The data type of the third field</typeparam>
    /// <typeparam name="X4">The data type of the fourth field</typeparam>
    /// <typeparam name="X5">The data type of the fifth field</typeparam>
    /// <param name="x1">The value of field 1</param>
    /// <param name="x2">The value of field 2</param>
    /// <param name="x3">The value of field 3</param>
    /// <param name="x4">The value of field 4</param>
    /// <param name="x5">The value of field 5</param>
    /// <returns></returns>
    public static Record<X1, X2, X3, X4, X5> record<X1, X2, X3, X4, X5>(X1 x1, X2 x2, X3 x3, X4 x4, X5 x5)
        => Record.make(x1, x2, x3, x4, x5);

    /// <summary>
    /// Constructs a record with 6 fields from an explicit listing of respective field values
    /// </summary>
    /// <typeparam name="X1">The data type of the first field</typeparam>
    /// <typeparam name="X2">The data type of the second field</typeparam>
    /// <typeparam name="X3">The data type of the third field</typeparam>
    /// <typeparam name="X4">The data type of the fourth field</typeparam>
    /// <typeparam name="X5">The data type of the fifth field</typeparam>
    /// <typeparam name="X6">The data type of the sixth field</typeparam>
    /// <param name="x1">The value of field 1</param>
    /// <param name="x2">The value of field 2</param>
    /// <param name="x3">The value of field 3</param>
    /// <param name="x4">The value of field 4</param>
    /// <param name="x5">The value of field 5</param>
    /// <param name="x6">The value of field 6</param>
    /// <returns></returns>
    public static Record<X1, X2, X3, X4, X5, X6> record<X1, X2, X3, X4, X5, X6>(X1 x1, X2 x2, X3 x3, X4 x4, X5 x5, X6 x6)
        => Record.make(x1, x2, x3, x4, x5, x6);

    /// <summary>
    /// Consructs record with 7 fields from an explicit listing of respective field values
    /// </summary>
    /// <typeparam name="X1">The data type of the first field</typeparam>
    /// <typeparam name="X2">The data type of the second field</typeparam>
    /// <typeparam name="X3">The data type of the third field</typeparam>
    /// <typeparam name="X4">The data type of the fourth field</typeparam>
    /// <typeparam name="X5">The data type of the fifth field</typeparam>
    /// <typeparam name="X6">The data type of the sixth field</typeparam>
    /// <typeparam name="X7">The data type of the sixth field</typeparam>
    /// <param name="x1">The value of field 1</param>
    /// <param name="x2">The value of field 2</param>
    /// <param name="x3">The value of field 3</param>
    /// <param name="x4">The value of field 4</param>
    /// <param name="x5">The value of field 5</param>
    /// <param name="x6">The value of field 6</param>
    /// <param name="x7">The value of field 7</param>
    /// <returns></returns>
    public static Record<X1, X2, X3, X4, X5, X6, X7> record<X1, X2, X3, X4, X5, X6, X7>(X1 x1, X2 x2, X3 x3, X4 x4, X5 x5, X6 x6, X7 x7)
        => Record.make(x1, x2, x3, x4, x5, x6, x7);

    /// <summary>
    /// Joins 2 1-records to produce a 2-record
    /// </summary>
    /// <typeparam name="X1">The type of the first attribute in the joined record</typeparam>
    /// <typeparam name="X2">The type of the second attribute in the joined record</typeparam>
    /// <param name="r1">The first input record</param>
    /// <param name="r2">The second input record</param>
    /// <returns></returns>
    public static Record<X1, X2> join<X1, X2>(Record<X1> r1, Record<X2> r2)
        => new Record<X1, X2>(r1.x1, r2.x1);

    /// <summary>
    /// Joins a 1-record and a 2-record to produce a 3-record
    /// </summary>
    /// <typeparam name="X1">The type of the first attribute in the joined record</typeparam>
    /// <typeparam name="X2">The type of the second attribute in the joined record</typeparam>
    /// <typeparam name="X3">The type of the third attribute in the joined record</typeparam>
    /// <param name="r1">The first input record</param>
    /// <param name="r2">The second input record</param>
    /// <returns></returns>
    public static Record<X1, X2, X3> join<X1, X2, X3>(Record<X1> r1, Record<X2, X3> r2)
        => new Record<X1, X2, X3>(r1.x1, r2.x1, r2.x2);

    /// <summary>
    /// Joines a 1-record and a 3-record to produce a 4-record
    /// </summary>
    /// <typeparam name="X1">The type of the first attribute in the joined record</typeparam>
    /// <typeparam name="X2">The type of the second attribute in the joined record</typeparam>
    /// <typeparam name="X3">The type of the third attribute in the joined record</typeparam>
    /// <typeparam name="X4">The type of the fourth attribute in the joined record</typeparam>
    /// <param name="r1">The first input record</param>
    /// <param name="r2">The second input record</param>
    /// <returns></returns>
    public static Record<X1, X2, X3, X4> join<X1, X2, X3, X4>(Record<X1> r1, Record<X2, X3, X4> r2)
        => new Record<X1, X2, X3, X4>(r1.x1, r2.x1, r2.x2, r2.x3);

    /// <summary>
    /// Joins a 1-record and a 4-record to produce a 5-record
    /// </summary>
    /// <typeparam name="X1">The type of the first attribute in the joined record</typeparam>
    /// <typeparam name="X2">The type of the second attribute in the joined record</typeparam>
    /// <typeparam name="X3">The type of the third attribute in the joined record</typeparam>
    /// <typeparam name="X4">The type of the fourth attribute in the joined record</typeparam>
    /// <typeparam name="X5">The type of the fifth attribute in the joined record</typeparam>
    /// <param name="r1">The first input record</param>
    /// <param name="r2">The second input record</param>
    /// <returns></returns>
    public static Record<X1, X2, X3, X4, X5> join<X1, X2, X3, X4, X5>(Record<X1> r1, Record<X2, X3, X4, X5> r2)
        => new Record<X1, X2, X3, X4, X5>(r1.x1, r2.x1, r2.x2, r2.x3, r2.x4);

    /// <summary>
    /// Joins a 1-record and a 5-record to produce a 6-record
    /// </summary>
    /// <typeparam name="X1">The type of the first attribute in the joined record</typeparam>
    /// <typeparam name="X2">The type of the second attribute in the joined record</typeparam>
    /// <typeparam name="X3">The type of the third attribute in the joined record</typeparam>
    /// <typeparam name="X4">The type of the fourth attribute in the joined record</typeparam>
    /// <typeparam name="X5">The type of the fifth attribute in the joined record</typeparam>
    /// <typeparam name="X6">The type of the sixth attribute in the joined record</typeparam>
    /// <param name="r1">The first input record</param>
    /// <param name="r2">The second input record</param>
    /// <returns></returns>
    public static Record<X1, X2, X3, X4, X5, X6> join<X1, X2, X3, X4, X5, X6>(Record<X1> r1, Record<X2, X3, X4, X5, X6> r2)
        => new Record<X1, X2, X3, X4, X5, X6>(r1.x1, r2.x1, r2.x2, r2.x3, r2.x4, r2.x5);

    /// <summary>
    /// Joins a 1-record and a 6-record to produce a 7-record
    /// </summary>
    /// <typeparam name="X1">The type of the first attribute in the joined record</typeparam>
    /// <typeparam name="X2">The type of the second attribute in the joined record</typeparam>
    /// <typeparam name="X3">The type of the third attribute in the joined record</typeparam>
    /// <typeparam name="X4">The type of the fourth attribute in the joined record</typeparam>
    /// <typeparam name="X5">The type of the fifth attribute in the joined record</typeparam>
    /// <typeparam name="X6">The type of the sixth attribute in the joined record</typeparam>
    /// <typeparam name="X7">The type of the seventh attribute in the joined record</typeparam>
    /// <param name="r1">The first input record</param>
    /// <param name="r2">The second input record</param>
    /// <returns></returns>
    public static Record<X1, X2, X3, X4, X5, X6, X7> join<X1, X2, X3, X4, X5, X6, X7>(Record<X1> r1, Record<X2, X3, X4, X5, X6, X7> r2)
        => new Record<X1, X2, X3, X4, X5, X6, X7>(r1.x1, r2.x1, r2.x2, r2.x3, r2.x4, r2.x5, r2.x6);

    /// <summary>
    /// Joins a 2 record and a 1-record to produce a 3-record
    /// </summary>
    /// <typeparam name="X1">The type of the first attribute in the joined record</typeparam>
    /// <typeparam name="X2">The type of the second attribute in the joined record</typeparam>
    /// <typeparam name="X3">The type of the third attribute in the joined record</typeparam>
    /// <param name="r1">The first input record</param>
    /// <param name="r2">The second input record</param>
    /// <returns></returns>
    public static Record<X1, X2, X3> join<X1, X2, X3>(Record<X1, X2> r1, Record<X3> r2)
        => new Record<X1, X2, X3>(r1.x1, r1.x2, r2.x1);

    /// <summary>
    /// Joins 2 2-records to produce a 4-record
    /// </summary>
    /// <typeparam name="X1">The type of the first attribute in the joined record</typeparam>
    /// <typeparam name="X2">The type of the second attribute in the joined record</typeparam>
    /// <typeparam name="X3">The type of the third attribute in the joined record</typeparam>
    /// <typeparam name="X4">The type of the fourth attribute in the joined record</typeparam>
    /// <param name="r1">The first input record</param>
    /// <param name="r2">The second input record</param>
    /// <returns></returns>
    public static Record<X1, X2, X3, X4> join<X1, X2, X3, X4>(Record<X1, X2> r1, Record<X3, X4> r2)
        => new Record<X1, X2, X3, X4>(r1.x1, r1.x2, r2.x1, r2.x2);

    /// <summary>
    /// Joins a 2-record and a 3-record to produce a 5-record
    /// </summary>
    /// <typeparam name="X1">The type of the first attribute in the joined record</typeparam>
    /// <typeparam name="X2">The type of the second attribute in the joined record</typeparam>
    /// <typeparam name="X3">The type of the third attribute in the joined record</typeparam>
    /// <typeparam name="X4">The type of the fourth attribute in the joined record</typeparam>
    /// <typeparam name="X5">The type of the fifth attribute in the joined record</typeparam>
    /// <param name="r1">The first input record</param>
    /// <param name="r2">The second input record</param>
    /// <returns></returns>
    public static Record<X1, X2, X3, X4, X5> join<X1, X2, X3, X4, X5>(Record<X1, X2> r1, Record<X3, X4, X5> r2)
        => new Record<X1, X2, X3, X4, X5>(r1.x1, r1.x2, r2.x1, r2.x2, r2.x3);

    /// <summary>
    /// Joins a 2-record and a 4-record to produce a 6 record
    /// </summary>
    /// <typeparam name="X1">The type of the first attribute in the joined record</typeparam>
    /// <typeparam name="X2">The type of the second attribute in the joined record</typeparam>
    /// <typeparam name="X3">The type of the third attribute in the joined record</typeparam>
    /// <typeparam name="X4">The type of the fourth attribute in the joined record</typeparam>
    /// <typeparam name="X5">The type of the fifth attribute in the joined record</typeparam>
    /// <typeparam name="X6">The type of the sixth attribute in the joined record</typeparam>
    /// <param name="r1">The first input record</param>
    /// <param name="r2">The second input record</param>
    /// <returns></returns>
    public static Record<X1, X2, X3, X4, X5, X6> join<X1, X2, X3, X4, X5, X6>(Record<X1, X2> r1, Record<X3, X4, X5, X6> r2)
        => new Record<X1, X2, X3, X4, X5, X6>(r1.x1, r1.x2, r2.x1, r2.x2, r2.x3, r2.x4);

    /// <summary>
    /// Joins a 2-record and a 5-record to produce a 7-record
    /// </summary>
    /// <typeparam name="X1">The type of the first attribute in the joined record</typeparam>
    /// <typeparam name="X2">The type of the second attribute in the joined record</typeparam>
    /// <typeparam name="X3">The type of the third attribute in the joined record</typeparam>
    /// <typeparam name="X4">The type of the fourth attribute in the joined record</typeparam>
    /// <typeparam name="X5">The type of the fifth attribute in the joined record</typeparam>
    /// <typeparam name="X6">The type of the sixth attribute in the joined record</typeparam>
    /// <typeparam name="X7">The type of the seventh attribute in the joined record</typeparam>
    /// <param name="r1">The first input record</param>
    /// <param name="r2">The second input record</param>
    /// <returns></returns>
    public static Record<X1, X2, X3, X4, X5, X6, X7> join<X1, X2, X3, X4, X5, X6, X7>(Record<X1, X2> r1, Record<X3, X4, X5, X6, X7> r2)
        => new Record<X1, X2, X3, X4, X5, X6, X7>(r1.x1, r1.x2, r2.x1, r2.x2, r2.x3, r2.x4, r2.x5);

    /// <summary>
    /// Joins a 3-record and a 1-record to produce a 4-record
    /// </summary>
    /// <typeparam name="X1">The type of the first attribute in the joined record</typeparam>
    /// <typeparam name="X2">The type of the second attribute in the joined record</typeparam>
    /// <typeparam name="X3">The type of the third attribute in the joined record</typeparam>
    /// <typeparam name="X4">The type of the fourth attribute in the joined record</typeparam>
    /// <param name="r1">The first input record</param>
    /// <param name="r2">The second input record</param>
    /// <returns></returns>
    public static Record<X1, X2, X3, X4> join<X1, X2, X3, X4>(Record<X1, X2, X3> r1, Record<X4> r2)
        => new Record<X1, X2, X3, X4>(r1.x1, r1.x2, r1.x3, r2.x1);

    /// <summary>
    /// Joins a 3-record and a 2-record to produce a 5-record
    /// </summary>
    /// <typeparam name="X1">The type of the first attribute in the joined record</typeparam>
    /// <typeparam name="X2">The type of the second attribute in the joined record</typeparam>
    /// <typeparam name="X3">The type of the third attribute in the joined record</typeparam>
    /// <typeparam name="X4">The type of the fourth attribute in the joined record</typeparam>
    /// <typeparam name="X5">The type of the fifth attribute in the joined record</typeparam>
    /// <param name="r1">The first input record</param>
    /// <param name="r2">The second input record</param>
    /// <returns></returns>
    public static Record<X1, X2, X3, X4, X5> join<X1, X2, X3, X4, X5>(Record<X1, X2, X3> r1, Record<X4, X5> r2)
        => new Record<X1, X2, X3, X4, X5>(r1.x1, r1.x2, r1.x3, r2.x1, r2.x2);

    /// <summary>
    /// Joins 2 3-reocrds to produce a 6-record
    /// </summary>
    /// <typeparam name="X1">The type of the first attribute in the joined record</typeparam>
    /// <typeparam name="X2">The type of the second attribute in the joined record</typeparam>
    /// <typeparam name="X3">The type of the third attribute in the joined record</typeparam>
    /// <typeparam name="X4">The type of the fourth attribute in the joined record</typeparam>
    /// <typeparam name="X5">The type of the fifth attribute in the joined record</typeparam>
    /// <typeparam name="X6">The type of the sixth attribute in the joined record</typeparam>
    /// <param name="r1">The first input record</param>
    /// <param name="r2">The second input record</param>
    /// <returns></returns>
    public static Record<X1, X2, X3, X4, X5, X6> join<X1, X2, X3, X4, X5, X6>(Record<X1, X2, X3> r1, Record<X4, X5, X6> r2)
        => new Record<X1, X2, X3, X4, X5, X6>(r1.x1, r1.x2, r1.x3, r2.x1, r2.x2, r2.x3);

    /// <summary>
    /// Joins a 3-record and a 1-record to produce a 7-record
    /// </summary>
    /// <typeparam name="X1">The type of the first attribute in the joined record</typeparam>
    /// <typeparam name="X2">The type of the second attribute in the joined record</typeparam>
    /// <typeparam name="X3">The type of the third attribute in the joined record</typeparam>
    /// <typeparam name="X4">The type of the fourth attribute in the joined record</typeparam>
    /// <typeparam name="X5">The type of the fifth attribute in the joined record</typeparam>
    /// <typeparam name="X6">The type of the sixth attribute in the joined record</typeparam>
    /// <typeparam name="X7">The type of the seventh attribute in the joined record</typeparam>
    /// <param name="r1">The first input record</param>
    /// <param name="r2">The second input record</param>
    /// <returns></returns>
    public static Record<X1, X2, X3, X4, X5, X6, X7> join<X1, X2, X3, X4, X5, X6, X7>(Record<X1, X2, X3> r1, Record<X4, X5, X6, X7> r2)
        => new Record<X1, X2, X3, X4, X5, X6, X7>(r1.x1, r1.x2, r1.x3, r2.x1, r2.x2, r2.x3, r2.x4);

    /// <summary>
    /// Joins a 4-recorda and a 1-record to produce a 5-record
    /// </summary>
    /// <typeparam name="X1">The type of the first attribute in the joined record</typeparam>
    /// <typeparam name="X2">The type of the second attribute in the joined record</typeparam>
    /// <typeparam name="X3">The type of the third attribute in the joined record</typeparam>
    /// <typeparam name="X4">The type of the fourth attribute in the joined record</typeparam>
    /// <typeparam name="X5">The type of the fifth attribute in the joined record</typeparam>
    /// <typeparam name="X6">The type of the sixth attribute in the joined record</typeparam>
    /// <param name="r1">The first input record</param>
    /// <param name="r2">The second input record</param>
    /// <returns></returns>
    public static Record<X1, X2, X3, X4, X5> join<X1, X2, X3, X4, X5, X6>(Record<X1, X2, X3, X4> r1, Record<X5> r2)
        => new Record<X1, X2, X3, X4, X5>(r1.x1, r1.x2, r1.x3, r1.x4, r2.x1);

    /// <summary>
    /// Joins a 4-record and a 2-record to produce a 6-record
    /// </summary>
    /// <typeparam name="X1">The type of the first attribute in the joined record</typeparam>
    /// <typeparam name="X2">The type of the second attribute in the joined record</typeparam>
    /// <typeparam name="X3">The type of the third attribute in the joined record</typeparam>
    /// <typeparam name="X4">The type of the fourth attribute in the joined record</typeparam>
    /// <typeparam name="X5">The type of the fifth attribute in the joined record</typeparam>
    /// <typeparam name="X6">The type of the sixth attribute in the joined record</typeparam>
    /// <param name="r1">The first input record</param>
    /// <param name="r2">The second input record</param>
    /// <returns></returns>
    public static Record<X1, X2, X3, X4, X5, X6> join<X1, X2, X3, X4, X5, X6>(Record<X1, X2, X3, X4> r1, Record<X5, X6> r2)
        => new Record<X1, X2, X3, X4, X5, X6>(r1.x1, r1.x2, r1.x3, r1.x4, r2.x1, r2.x2);

    /// <summary>
    /// Joins a 4-record and a 3-record to prouce a 7-record
    /// </summary>
    /// <typeparam name="X1">The type of the first attribute in the joined record</typeparam>
    /// <typeparam name="X2">The type of the second attribute in the joined record</typeparam>
    /// <typeparam name="X3">The type of the third attribute in the joined record</typeparam>
    /// <typeparam name="X4">The type of the fourth attribute in the joined record</typeparam>
    /// <typeparam name="X5">The type of the fifth attribute in the joined record</typeparam>
    /// <typeparam name="X6">The type of the sixth attribute in the joined record</typeparam>
    /// <typeparam name="X7">The type of the seventh attribute in the joined record</typeparam>
    /// <param name="r1">The first input record</param>
    /// <param name="r2">The second input record</param>
    /// <returns></returns>
    public static Record<X1, X2, X3, X4, X5, X6, X7> join<X1, X2, X3, X4, X5, X6, X7>(Record<X1, X2, X3, X4> r1, Record<X5, X6, X7> r2)
        => new Record<X1, X2, X3, X4, X5, X6, X7>(r1.x1, r1.x2, r1.x3, r1.x4, r2.x1, r2.x2, r2.x3);

    public static Record<X1, X2, X3, X4, X5, X6> join<X1, X2, X3, X4, X5, X6>(Record<X1, X2, X3, X4, X5> r1, Record<X6> r2)
        => new Record<X1, X2, X3, X4, X5, X6>(r1.x1, r1.x2, r1.x3, r1.x4, r1.x5, r2.x1);

    public static Record<X1, X2, X3, X4, X5, X6, X7> join<X1, X2, X3, X4, X5, X6, X7>(Record<X1, X2, X3, X4, X5> r1, Record<X6, X7> r2)
        => new Record<X1, X2, X3, X4, X5, X6, X7>(r1.x1, r1.x2, r1.x3, r1.x4, r1.x5, r2.x1, r2.x2);


}