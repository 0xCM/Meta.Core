//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using SqlT.Core;
    using sxc = contracts;

    /// <summary>
    /// Defines sql data type taxonomy
    /// </summary>
    public static class data_types
    {
        /// <summary>
        /// Supertype for numeric data type classifiers
        /// </summary>
        public abstract class numeric<T> : data_type<T>, sxc.numeric_type
            where T : numeric<T>
        {
            internal numeric(SqlDataTypeName TypeName)
                : base(TypeName, DataTypeCategory.Number)
            {

            }
        }

        /// <summary>
        /// Supertype for fractional numeric data type classifiers
        /// </summary>
        public abstract class fractional<T> : numeric<T>, sxc.fractional_type
            where T : fractional<T>
        {
            internal fractional(SqlDataTypeName TypeName)
                : base(TypeName)
            {

            }
        }

        /// <summary>
        /// Supertype for integer data type classifiers
        /// </summary>
        public abstract class integer<T> : numeric<T>, sxc.integer_type
            where T : integer<T>
        {
            internal integer(SqlDataTypeName TypeName)
                : base(TypeName)
            {

            }

            public override bool CanSpecifyPrecision
                => false;

            public override bool CanSpecifyScale
                => false;
        }

        /// <summary>
        /// Supertype for non-FP fractional numeric data type classifiers
        /// </summary>
        public abstract class precise_fractional<T> : fractional<T>, sxc.precise_fractional_type
            where T : precise_fractional<T>
        {
            internal precise_fractional(SqlDataTypeName TypeName)
                : base(TypeName)
            {

            }
        }


        /// <summary>
        /// Supertype for floating-point numeric data type classifiers
        /// </summary>
        public abstract class floating<T> : fractional<T>, sxc.floating_fractional_type
            where T : floating<T>
        {
            internal floating(SqlDataTypeName TypeName)
                : base(TypeName)
            {

            }
        }


        /// <summary>
        /// Supertype for currency data type models
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public abstract class currency<T> : precise_fractional<T>, sxc.currency_type
            where T : currency<T>
        {
            internal currency(SqlDataTypeName TypeName)
                : base(TypeName)
            {

            }

        }

        /// <summary>
        /// Supertype for clr data type models
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public abstract class clr_type<T> : data_type<T>, sxc.clr_type
            where T : clr_type<T>
        {
            internal clr_type(SqlDataTypeName TypeName)
                : base(TypeName, DataTypeCategory.Clr)
            {

            }
        }

        /// <summary>
        /// Supertype for binary data type models
        /// </summary>
        public abstract class binary<T> : data_type<T>, sxc.binary_type
            where T : binary<T>
        {
            internal binary(SqlDataTypeName TypeName)
                : base(TypeName, DataTypeCategory.Binary)
            {

            }

            public virtual bool IsFixedLength
                => false;
        }

        /// <summary>
        /// Supertype for date/type-related type models
        /// </summary>
        public abstract class chronology<T> : data_type<T>, sxc.chronology_type
           where T : chronology<T>

        {
            internal chronology(SqlDataTypeName TypeName)
                : base(TypeName, DataTypeCategory.Chronology)
            {

            }

        }

        /// <summary>
        /// Supertype for text data type classifiers
        /// </summary>
        public abstract class text<T> : data_type<T>, sxc.text_type
            where T : text<T>
        {
            internal text(SqlDataTypeName TypeName)
                : base(TypeName, DataTypeCategory.Text)
            {

            }

            public abstract bool IsFixedLength { get; }

            public override bool IsTextType
                => true;
        }

        /// <summary>
        /// Supertype for fixed text type models
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public abstract class fixed_text<T> : text<T>, sxc.fixed_text_type
            where T : fixed_text<T>
        {
            internal fixed_text(SqlDataTypeName TypeName)
                : base(TypeName)
            {

            }

            public override bool IsFixedLength
                => true;

            public override bool CanSpecifyLength
                => true;
        }
    }
}