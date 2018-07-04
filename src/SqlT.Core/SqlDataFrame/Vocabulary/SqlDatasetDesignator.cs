//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using System;
    using System.Linq;

    using SqlT.Core;

    using static metacore;

    /// <summary>
    /// Defines a unique key for a <see cref="SqlDataset"/>
    /// </summary>
    public class SqlDatasetDesignator : ValueObject<SqlDatasetDesignator>
    {
        public SqlDatasetDesignator(SqlContentType ContentType, Date? ProductionDate = null)
        {
            this.ContentType = ContentType;
            this.ProductionDate = ProductionDate ?? now();
        }

        public SqlDatasetDesignator(SqlContentType ContentType, Date? ProductionDate, DateRange? ContentPeriod, Date? PerspectiveDate = null)
        {
            this.ContentType = ContentType;
            this.ProductionDate = ProductionDate ?? now();
            this.ContentPeriod = ContentPeriod;
            this.PerspectiveDate = PerspectiveDate;
        }

        public SqlDatasetDesignator(SqlContentType ContentType, Date? ProductionDate, Date? ContentDate, Date? PerspectiveDate = null)
        {
            this.ContentType = ContentType;
            this.ProductionDate = ProductionDate ?? now();
            this.ContentDate = ContentDate;
            this.PerspectiveDate = PerspectiveDate;
        }

        public SqlContentType ContentType { get; }

        public Date ProductionDate { get; }

        public DateRange? ContentPeriod { get; }

        public Date? ContentDate { get; }

        public Date? PerspectiveDate { get; }

        public string CanonicalName
        {
            get
            {
                var name = $"{ProductionDate.ToIsoString()}.{ContentType}";
                ContentPeriod.OnValue(p => name += $".{p.ToIntervalString()}");
                ContentDate.OnValue(d => name += $".{d.ToIsoString()}");
                PerspectiveDate.OnValue(x => name += $".Perspective({x.ToIsoString()})");
                name += ".dataset";
                return name;
            }
        }

        public override string ToString()
            => CanonicalName;
    }


}