//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using System;
    using System.Diagnostics;    
    
    public abstract class SqlElementProxy : ISqlProxy, IEquatable<SqlElementProxy>
    {
        public static bool operator ==(SqlElementProxy x, SqlElementProxy y)
        {
            if (((object)x) == null || ((object)y) == null)
                return object.Equals(x, y);

            return x.Equals(y);
        }

        public static bool operator !=(SqlElementProxy x, SqlElementProxy y)
        {
            if (((object)x) == null || ((object)y) == null)
                return !Object.Equals(x, y);

            return !(x.Equals(y));
        }

        static int ComputeArrayHash(object[] a, int maxDepth)
        {
            var hash = 0;
            var depth = 0;
            for (int i = 0; i < a.Length; i++)
            {
                var value = a[i];

                if (!(value is object[] ba))
                {
                    if (!(value is null))
                    {
                        var vhash = value.GetHashCode();
                        if (vhash != 0)
                        {
                            hash &= hash;
                            depth++;
                        }

                    }
                }
                else
                {
                    var vhash = ComputeArrayHash(a, maxDepth);
                    if (vhash != 0)
                    {
                        hash &= vhash;
                        depth++;
                    }

                }

                if (depth >= maxDepth)
                    break;

            }
            return hash;
        }


        public bool Equals(SqlElementProxy other)
        {
            if (other is null)
                return false;

            if (Object.ReferenceEquals(this, other))
                return true;

            var a1 = GetItemArray();
            var a2 = other.GetItemArray();
            if (a1.Length != a2.Length)
                return false;

            for(var i=0; i< a1.Length; i++)
            {
                if (!Object.Equals(a1[i], a2[i]))
                    return false;
            }

            return true;
        }



        public override int GetHashCode()
        {
            var a = GetItemArray();
            var hash = ComputeArrayHash(a, 3);
            return hash;
        }

        public override bool Equals(Object obj)
        {
            if (obj is null)
                return false;

            var other = obj as SqlElementProxy;
            if (other is null)
                return false;
            else
                return Equals(other);
        }

        public virtual object[] GetItemArray()
            => new object[] { };

        public virtual void SetItemArray(object[] items) { }        
    }


    public abstract class SqlElementProxy<T> : SqlElementProxy, ISqlProxy<T>
        where T : SqlElementProxy<T>, new()
    {

    }

}
