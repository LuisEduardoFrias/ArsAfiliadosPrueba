using ArsAfiliados.Data;
using ArsAfiliados.Dtos;
using ArsAfiliados.ExtensionMethod;
using ArsAfiliados.Interface;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace ArsAfiliados.Repository
{
    public class RepositoryPlanes : IRepository<CrearPlanesDto, ActualizarPlanesDto, MostrarPlanesDto>
    {

        #region Singletom

        private static RepositoryPlanes Instance;

        public static RepositoryPlanes GetInstance()
        {
            if (Instance == null)
                Instance = new RepositoryPlanes();

            return Instance;
        }

        #endregion

        public async Task<List<MostrarPlanesDto>> Mostrar()
        {
            SqlDataReader reader = await DataAccess.GetInstance().OpenConnection().UserStoreProcedure(
                "MostrarAfiliado").ExecuteReaderAsync();

            List<MostrarPlanesDto> planes = new List<MostrarPlanesDto>();

            while (await reader.ReadAsync())
            {
                planes.Add(new MostrarPlanesDto
                {
                    Id = reader["Id"].ToInt(),
                    Plan = reader["Plan"].ToString(),
                    MontoCobertura = reader["MontoCobertura"].ToDecimal(),
                    FechaRegistro = reader["FechaRegistro"].ToDateTime(),
                    Estatus = reader["Estatus"].ToBool(),
                });
            }

            DataAccess.GetInstance().CloseConnection();

            return planes;
        }

        public async Task<bool> Crear(CrearPlanesDto PlanesDto)
        {
           bool resul = await DataAccess.GetInstance().OpenConnection().UserStoreProcedure("CrearPlanes",
                new SqlParameter[]
                {
                    new SqlParameter
                    {
                        ParameterName = "@Plan",
                        DbType = System.Data.DbType.String,
                        Value = PlanesDto.Plan
                    },
                    new SqlParameter
                    {
                        ParameterName = "@MontoCobertura",
                        DbType = System.Data.DbType.Decimal,
                        Value = PlanesDto.MontoCobertura
                    },
                    new SqlParameter
                    {
                        ParameterName = "@FechaRegistro",
                        DbType = System.Data.DbType.DateTime,
                        Value = PlanesDto.FechaRegistro
                    },
                    new SqlParameter
                    {
                        ParameterName = "@Estatus",
                        DbType = System.Data.DbType.Boolean,
                        Value = PlanesDto.Estatus
                    },
                }).ExecuteNonQueryAsync() != -1;

            DataAccess.GetInstance().CloseConnection();

            return resul;
        }
            
        public async Task<bool> Actualizar(ActualizarPlanesDto PlanesDto)
        {
            var result = await DataAccess.GetInstance().OpenConnection().UserStoreProcedure("ActualizarPlanes",
                new SqlParameter[]
                {
                    new SqlParameter
                    {
                        ParameterName = "@Id",
                        DbType = System.Data.DbType.Int32,
                        Value = PlanesDto.Id
                    },
                    new SqlParameter
                    {
                        ParameterName = "@Plan",
                        DbType = System.Data.DbType.String,
                        Value = PlanesDto.Plan
                    },
                    new SqlParameter
                    {
                        ParameterName = "@MontoCobertura",
                        DbType = System.Data.DbType.Decimal,
                        Value = PlanesDto.MontoCobertura
                    },
                    new SqlParameter
                    {
                        ParameterName = "@FechaRegistro",
                        DbType = System.Data.DbType.DateTime,
                        Value = PlanesDto.FechaRegistro
                    },
                    new SqlParameter
                    {
                        ParameterName = "@Estatus",
                        DbType = System.Data.DbType.Boolean,
                        Value = PlanesDto.Estatus
                    },
                }).ExecuteNonQueryAsync() != -1;

            DataAccess.GetInstance().CloseConnection();

            return result;
        }
            
        public async Task<MostrarPlanesDto> Buscar(string plan)
        {
            SqlDataReader reader = await DataAccess.GetInstance().OpenConnection().UserStoreProcedure(
                "BuscarPlanes", new SqlParameter[]
                {
                    new SqlParameter
                    {
                        ParameterName = "@Plan",
                        DbType = System.Data.DbType.String,
                        Value = plan
                    }
                }).ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                return new MostrarPlanesDto
                {
                    Id = reader["Id"].ToInt(),
                    Plan = reader["Plan"].ToString(),
                    MontoCobertura = reader["MontoCobertura"].ToDecimal(),
                    FechaRegistro = reader["FechaRegistro"].ToDateTime(),
                    Estatus = reader["Estatus"].ToBool(),
                };
            }

            DataAccess.GetInstance().CloseConnection();

            return new MostrarPlanesDto();
        }

        public async Task<bool> Inactivar(int id, int inactivar)
        {
            var result = await DataAccess.GetInstance().OpenConnection().UserStoreProcedure("InactivarPlanes",
                new SqlParameter[]
                {
                    new SqlParameter
                    {
                        ParameterName = "@Id",
                        DbType = System.Data.DbType.Int32,
                        Value = id
                    },
                    new SqlParameter
                    {
                        ParameterName = "@Estatus",
                        DbType = System.Data.DbType.Int32,
                        Value = inactivar
                    }
                }).ExecuteNonQueryAsync() != -1;

            DataAccess.GetInstance().CloseConnection();

            return result;
        }

    }
}
