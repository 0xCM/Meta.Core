//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Reflection;
    using static metacore;

    /// <summary>
    /// Represents a connection string to a SQL server/database
    /// </summary>
    public class SqlConnectionString : IConvertible
    {
        public static readonly SqlConnectionString Empty 
            = new SqlConnectionString("devnull");

        public static readonly int DefultMaxPoolSize 
            = 100;

        public static SqlConnectionString Local
            => Build().LocalConnection(SqlDatabaseName.Master());

        public static SqlConnectionString Parse(string cs)
            => new SqlConnectionString(cs);
        
        /// <summary>
        /// Implements utilities for constructing a connection string
        /// </summary>
        public class Builder
        {
            /// <summary>
            /// Implicilty extracts the text of the constructed connection string
            /// </summary>
            /// <param name="csb">The builder</param>
            public static implicit operator string(Builder csb) 
                => csb.ToString();

            /// <summary>
            /// Implicilty constucts a builder from a connection string
            /// </summary>
            /// <param name="cs">The builder</param>
            public static implicit operator Builder(string cs) 
                => new Builder(cs);

            public static implicit operator SqlConnectionString(Builder csb) 
                => csb.ToString();

            readonly SqlConnectionStringBuilder AdaptedBuilder;

            public Builder(string cs = "")
            {
                AdaptedBuilder = new SqlConnectionStringBuilder(cs);
                if (isBlank(AdaptedBuilder.ApplicationName))
                    AdaptedBuilder.ApplicationName = Assembly.GetEntryAssembly().GetSimpleName();
            }

            public Builder(SqlServerName server, SqlDatabaseName database = null)
            {
                AdaptedBuilder = new SqlConnectionStringBuilder();
                ConnectTo(server, database);
            }

            public Builder ConnectToFile(SqlServerName server, string path, bool integratedSecurity = true)
            {
                AdaptedBuilder.DataSource = server;
                AdaptedBuilder.AttachDBFilename = path;
                if (integratedSecurity)
                    return UsingIntegratedSecurity();
                else
                    return this;
            }

            public Builder OnPort(int? Port)
            {
                if (Port != null)
                    AdaptedBuilder.DataSource = $"{AdaptedBuilder.DataSource},{Port}";
                return this;
            }

            public Builder ConnectTo(SqlServerName server, SqlDatabaseName database = null)
            {
                AdaptedBuilder.DataSource = server;
                if(database != null)
                    AdaptedBuilder.InitialCatalog = database;
                return this;
            }

            public Builder LocalConnection(SqlDatabaseName database = null, bool integratedSecurity = true)
            {
                AdaptedBuilder.DataSource = "localhost";
                if(database != null)
                    AdaptedBuilder.InitialCatalog = database;
                if (integratedSecurity)
                    return UsingIntegratedSecurity();
                else
                    return this;
            }

            public Builder UsingCredentials(string user, string password)
            {
                
                AdaptedBuilder.IntegratedSecurity = false;
                AdaptedBuilder.UserID = user;
                AdaptedBuilder.Password = password;
                return this;
            }

            public Builder UsingCredentials(SqlUserCredentials credentials)
                => UsingCredentials(credentials.UserName, credentials.Password);

            public Builder UsingCredentials(SqlConnectionCredentials credentials)
                => UsingCredentials(credentials.Username, credentials.Password);

            public Builder UsingAppName(string AppName)
            {
                AdaptedBuilder.ApplicationName = AppName;

                return this;
            }

            public Builder UsingIntegratedSecurity()
            {
                AdaptedBuilder.IntegratedSecurity = true;

                if (!String.IsNullOrWhiteSpace(AdaptedBuilder.UserID))
                    AdaptedBuilder.UserID = String.Empty;

                if (!String.IsNullOrWhiteSpace(AdaptedBuilder.Password))
                    AdaptedBuilder.Password = String.Empty;

                return this;
            }

            public Builder Database(SqlDatabaseName database)
            {
                AdaptedBuilder.InitialCatalog = database.UnquotedLocalName;
                if (not(database.ServerName.IsEmpty()))
                    AdaptedBuilder.DataSource = database.UnquotedLocalName;
                return this;
            }

            public Builder WithMaxPoolSize(int max)
            {
                AdaptedBuilder.MaxPoolSize = max;
                return this;
            }

            public Builder WithMARS(bool mars)
            {
                AdaptedBuilder.MultipleActiveResultSets = mars;
                return this;
            }


            public SqlConnectionString Finish()
                => this;

            public override string ToString() 
                => AdaptedBuilder.ToString();


        }

        public static Builder Build(string cs = "") 
            => new Builder(cs);

        public static Builder Build(SqlServerAlias server, SqlDatabaseName database = null)
            => new Builder(server.AliasName, database);

        public static Builder Build(SqlServerName server, SqlDatabaseName database = null)
            => new Builder(server, database);

        /// <summary>
        /// Converts a <see cref="SqlConnectionString"/> instance to text
        /// </summary>
        /// <param name="cs">The instance to convert</param>
        public static implicit operator string(SqlConnectionString cs) 
            => cs.Text;

        /// <summary>
        /// Converts text representing a connection string to a <see cref="SqlConnectionString"/> instance
        /// </summary>
        /// <param name="Text"></param>
        public static implicit operator SqlConnectionString(string Text) 
            => new SqlConnectionString(Text);

        /// <summary>
        /// The connection string text
        /// </summary>
        public readonly string Text;

        /// <summary>
        /// Initializes a new <see cref="SqlConnectionString"/> instance
        /// </summary>
        /// <param name="Text"></param>
        public SqlConnectionString(string Text)
        {
            this.Text = Text;
        }

        public Builder Rebuild() 
            => new Builder(this.Text);

        public bool IsEmpty
            => this.ServerName == "devnull";

        /// <summary>
        /// The name of the server specified by the connection string
        /// </summary>
        public SqlServerName ServerName
            => (new SqlConnectionStringBuilder(Text)).DataSource;

        /// <summary>
        /// The name of the database specified by the connection string
        /// </summary>
        public string DatabaseName 
            => (new SqlConnectionStringBuilder(Text)).InitialCatalog;


        /// <summary>
        /// Extracts the qualified name of the database specified by the connection string, if applicable
        /// </summary>
        /// <returns></returns>
        public SqlDatabaseName QualifiedDatabaseName
            => new SqlDatabaseName(ServerName, DatabaseName);

        /// <summary>
        /// The Username specified by the connection string
        /// </summary>
        public string Username 
            => (new SqlConnectionStringBuilder(Text)).UserID;

        /// <summary>
        /// The Password specified by the connection string
        /// </summary>
        public string Password 
            => (new SqlConnectionStringBuilder(Text)).Password;

        /// <summary>
        /// Removes the specified <see cref="DatabaseName"/>, if eny
        /// </summary>
        /// <returns></returns>
        public SqlConnectionString TrimCatalog()
        {
            if (String.IsNullOrWhiteSpace(DatabaseName))
                return this;
            else
            {
                var csb = new SqlConnectionStringBuilder(Text);
                csb.InitialCatalog = String.Empty;
                return new SqlConnectionString(csb.ToString());
            }
        }

        /// <summary>
        /// Replaces the current database with a specified database
        /// </summary>
        /// <param name="LocalDatabaseName">The new database</param>
        /// <returns></returns>
        public SqlConnectionString ChangeDatabase(string LocalDatabaseName)
        {
            var csb = new SqlConnectionStringBuilder(Text);
            csb.InitialCatalog = LocalDatabaseName;
            return new SqlConnectionString(csb.ToString());

        }



        /// <summary>
        /// Verify that a connection can be made with the configured parameters
        /// </summary>
        /// <returns></returns>
        public SqlOutcome<int> Verify()
        {
            try
            {
                using (var c = new SqlConnection(this))
                {
                    c.Open();

                    return 1;

                }
            }
            catch(SqlException e)
            {
                return SqlOutcome.Failure<int>(e);
            }
            catch (InvalidOperationException e)
            {
                return SqlOutcome.Failure<int>(e);
            }
            catch (Exception e)
            {
                return SqlOutcome.Failure<int>(e);
            }
        }

        public override string ToString()
            => Text;

        #region IConvertible
        TypeCode IConvertible.GetTypeCode()
        {
            return Text.GetTypeCode();
        }

        bool IConvertible.ToBoolean(IFormatProvider provider)
        {
            return ((IConvertible)Text).ToBoolean(provider);
        }

        char IConvertible.ToChar(IFormatProvider provider)
        {
            return ((IConvertible)Text).ToChar(provider);
        }

        sbyte IConvertible.ToSByte(IFormatProvider provider)
        {
            return ((IConvertible)Text).ToSByte(provider);
        }

        byte IConvertible.ToByte(IFormatProvider provider)
        {
            return ((IConvertible)Text).ToByte(provider);
        }

        short IConvertible.ToInt16(IFormatProvider provider)
        {
            return ((IConvertible)Text).ToInt16(provider);
        }

        ushort IConvertible.ToUInt16(IFormatProvider provider)
        {
            return ((IConvertible)Text).ToUInt16(provider);
        }

        int IConvertible.ToInt32(IFormatProvider provider)
        {
            return ((IConvertible)Text).ToInt32(provider);
        }

        uint IConvertible.ToUInt32(IFormatProvider provider)
        {
            return ((IConvertible)Text).ToUInt32(provider);
        }

        long IConvertible.ToInt64(IFormatProvider provider)
        {
            return ((IConvertible)Text).ToInt64(provider);
        }

        ulong IConvertible.ToUInt64(IFormatProvider provider)
        {
            return ((IConvertible)Text).ToUInt64(provider);
        }

        float IConvertible.ToSingle(IFormatProvider provider)
        {
            return ((IConvertible)Text).ToSingle(provider);
        }

        double IConvertible.ToDouble(IFormatProvider provider)
        {
            return ((IConvertible)Text).ToDouble(provider);
        }

        decimal IConvertible.ToDecimal(IFormatProvider provider)
        {
            return ((IConvertible)Text).ToDecimal(provider);
        }

        DateTime IConvertible.ToDateTime(IFormatProvider provider)
        {
            return ((IConvertible)Text).ToDateTime(provider);
        }

        string IConvertible.ToString(IFormatProvider provider)
        {
            return Text.ToString(provider);
        }

        object IConvertible.ToType(Type conversionType, IFormatProvider provider)
        {
            return ((IConvertible)Text).ToType(conversionType, provider);
        }
        #endregion
    }



}