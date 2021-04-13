﻿using System.Data.SqlClient;
using System.Configuration;

namespace ArsAfiliados.Data
{
    public class DataAccess
    {

        #region Propiedades

        public readonly SqlConnection _sqlConnnection;
        public readonly SqlCommand _sqlCommnd;

        #endregion

        #region Singletom

        public static DataAccess Instance { get; set; }

        public static DataAccess GetInstance()
        {
            if (Instance == null)
                Instance = new DataAccess();

            return Instance;
        }
        #endregion


        public DataAccess()
        {
            _sqlConnnection = new SqlConnection
            {
                ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString
            };

            _sqlCommnd = new SqlCommand
            {
                Connection = _sqlConnnection
            };

        }


        public DataAccess OpenConnection()
        {
            _sqlConnnection.Open();

            return this;
        }

        public SqlCommand UserStoreProcedure(string NameStoreProcedure, SqlParameter[] sqlParameters)
        {
            _sqlCommnd.CommandText = NameStoreProcedure;
            _sqlCommnd.CommandType = System.Data.CommandType.StoredProcedure;

            _sqlCommnd.Parameters.AddRange(sqlParameters);

            return _sqlCommnd;
        }

        public SqlCommand UserStoreProcedure(string NameStoreProcedure)
        {
            _sqlCommnd.CommandText = NameStoreProcedure;
            _sqlCommnd.CommandType = System.Data.CommandType.StoredProcedure;

            return _sqlCommnd;
        }

        public void CloseConnection()
        {
            _sqlConnnection.Close();
        }

    }
}
