using ArsAfiliados.Data;
using ArsAfiliados.Dtos;
using ArsAfiliados.ExtensionMethod;
using ArsAfiliados.Interface;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace ArsAfiliados.Repository
{
    public class RepositoryAfiliados : IRepository<CrearAfiliadosDto, ActualizarAfiliadoDto, MostrarAfiliadosDto>
    {
        #region Singletom

        public static RepositoryAfiliados Instantice { get; set; }

        public static RepositoryAfiliados GetInstance()
        {
            if (Instantice == null)
                Instantice = new RepositoryAfiliados();

            return Instantice;
        }

        #endregion

        public async Task<List<MostrarAfiliadosDto>> Mostrar()
        {
            SqlDataReader reader = await DataAccess.GetInstance().OpenConnection().UserStoreProcedure(
                "MostrarAfiliado").ExecuteReaderAsync();

            List<MostrarAfiliadosDto> afiliados = new List<MostrarAfiliadosDto>();

            while (await reader.ReadAsync())
            {
                afiliados.Add( new MostrarAfiliadosDto
                {
                    Id = reader["Id"].ToInt(),
                    Nombre = reader["Nombre"].ToString(),
                    Apellido = reader["Apellido"].ToString(),
                    Fecha = reader["Fecha"].ToDateTime(),
                    Nacimiento = reader["Nacimiento"].ToString(),
                    Sexo = reader["Sexo"].Tochar(),
                    Cedula = reader["Cedula"].ToString(),
                    NumeroSeguroSocial = reader["NumeroSeguroSocial"].ToString(),
                    FechaRegistro = reader["FechaRegistro"].ToDateTime(),
                    MontoConsumido = reader["MontoConsumido"].ToDecimal(),
                    EstatusId = reader["EstatusId"].ToInt(),
                    PlanId = reader["PlanId"].ToInt(),
                    Plan_ = new MostrarPlanesDto
                    {
                        Plan = reader["Plan"].ToString(),
                        MontoCobertura = reader["MontoCobertura"].ToInt(),
                        FechaRegistro = reader["FechaRegistro"].ToDateTime(),
                        Estatus = reader["Estatus"].ToBool()
                    },
                    Estatus_ = new MostrarEstatusDto
                    {
                        Id = reader["Id"].ToInt(),
                        Estatus = reader["Estatus"].ToBool()
                    }
                });
            }

            DataAccess.GetInstance().CloseConnection();

            return afiliados;
        }

        public async Task<bool> Crear(CrearAfiliadosDto afiliadosDto)
        {
            var result = await DataAccess.GetInstance().OpenConnection().UserStoreProcedure("CrearAfiliado",
                new SqlParameter[]
                {
                    new SqlParameter
                    {
                        ParameterName = "@Nombre",
                        DbType = System.Data.DbType.String,
                        Value = afiliadosDto.Nombre
                    },
                    new SqlParameter
                    {
                        ParameterName = "@Apellido",
                        DbType = System.Data.DbType.String,
                        Value = afiliadosDto.Apellido
                    },
                    new SqlParameter
                    {
                        ParameterName = "@Cedula",
                        DbType = System.Data.DbType.String,
                        Value = afiliadosDto.Cedula
                    },
                    new SqlParameter
                    {
                        ParameterName = "@Fecha",
                        DbType = System.Data.DbType.DateTime,
                        Value = afiliadosDto.Fecha
                    },
                    new SqlParameter
                    {
                        ParameterName = "@Nacimiento",
                        DbType = System.Data.DbType.String,
                        Value = afiliadosDto.Nacimiento
                    },new SqlParameter
                    {
                        ParameterName = "@Sexo",
                        DbType = System.Data.DbType.String,
                        Value = afiliadosDto.Sexo
                    },new SqlParameter
                    {
                        ParameterName = "@NumeroSeguroSocial",
                        DbType = System.Data.DbType.String,
                        Value = afiliadosDto.NumeroSeguroSocial
                    },new SqlParameter
                    {
                        ParameterName = "@FechaRegistro",
                        DbType = System.Data.DbType.DateTime,
                        Value = afiliadosDto.FechaRegistro
                    },new SqlParameter
                    {
                        ParameterName = "@MontoConsumido",
                        DbType = System.Data.DbType.Decimal,
                        Value = afiliadosDto.MontoConsumido
                    },new SqlParameter
                    {
                        ParameterName = "@EstatusId",
                        DbType = System.Data.DbType.Int32,
                        Value = afiliadosDto.EstatusId
                    },new SqlParameter
                    {
                        ParameterName = "@PlanId",
                        DbType = System.Data.DbType.Int32,
                        Value = afiliadosDto.PlanId
                    },
                }).ExecuteNonQueryAsync() != -1;

            DataAccess.GetInstance().CloseConnection();

            return result;

        }

        public async Task<bool> Actualizar(ActualizarAfiliadoDto afiliadosDto)
        {
            var result = await DataAccess.GetInstance().OpenConnection().UserStoreProcedure("ActualizarAfiliado",
                new SqlParameter[]
                {
                    new SqlParameter
                    {
                        ParameterName = "@Id",
                        DbType = System.Data.DbType.Int32,
                        Value = afiliadosDto.Id
                    },
                    new SqlParameter
                    {
                        ParameterName = "@Nombre",
                        DbType = System.Data.DbType.String,
                        Value = afiliadosDto.Nombre
                    },
                    new SqlParameter
                    {
                        ParameterName = "@Apellido",
                        DbType = System.Data.DbType.String,
                        Value = afiliadosDto.Apellido
                    },
                    new SqlParameter
                    {
                        ParameterName = "@Cedula",
                        DbType = System.Data.DbType.String,
                        Value = afiliadosDto.Cedula
                    },
                    new SqlParameter
                    {
                        ParameterName = "@Fecha",
                        DbType = System.Data.DbType.DateTime,
                        Value = afiliadosDto.Fecha
                    },
                    new SqlParameter
                    {
                        ParameterName = "@Nacimiento",
                        DbType = System.Data.DbType.String,
                        Value = afiliadosDto.Nacimiento
                    },new SqlParameter
                    {
                        ParameterName = "@Sexo",
                        DbType = System.Data.DbType.String,
                        Value = afiliadosDto.Sexo
                    },new SqlParameter
                    {
                        ParameterName = "@NumeroSeguroSocial",
                        DbType = System.Data.DbType.String,
                        Value = afiliadosDto.NumeroSeguroSocial
                    },new SqlParameter
                    {
                        ParameterName = "@FechaRegistro",
                        DbType = System.Data.DbType.DateTime,
                        Value = afiliadosDto.FechaRegistro
                    },new SqlParameter
                    {
                        ParameterName = "@MontoConsumido",
                        DbType = System.Data.DbType.Decimal,
                        Value = afiliadosDto.MontoConsumido
                    },new SqlParameter
                    {
                        ParameterName = "@EstatusId",
                        DbType = System.Data.DbType.Int32,
                        Value = afiliadosDto.EstatusId
                    },new SqlParameter
                    {
                        ParameterName = "@PlanId",
                        DbType = System.Data.DbType.Int32,
                        Value = afiliadosDto.PlanId
                    },
                }).ExecuteNonQueryAsync() != -1;

            DataAccess.GetInstance().CloseConnection();

            return result;

        }

        public async Task<MostrarAfiliadosDto> Buscar(string cedula)
        {
            SqlDataReader reader = await DataAccess.GetInstance().OpenConnection().UserStoreProcedure(
                "BuscarAfiliado", new SqlParameter[]
                {
                    new SqlParameter
                    {
                        ParameterName = "@Cedula",
                        DbType = System.Data.DbType.String,
                        Value = cedula
                    }
                }).ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                return new MostrarAfiliadosDto
                {
                    Id = reader["Id"].ToInt(),
                    Nombre = reader["Nombre"].ToString(),
                    Apellido = reader["Apellido"].ToString(),
                    Fecha = reader["Fecha"].ToDateTime(),
                    Nacimiento = reader["Nacimiento"].ToString(),
                    Sexo = reader["Sexo"].Tochar(),
                    Cedula = reader["Cedula"].ToString(),
                    NumeroSeguroSocial = reader["NumeroSeguroSocial"].ToString(),
                    FechaRegistro = reader["FechaRegistro"].ToDateTime(),
                    MontoConsumido = reader["MontoConsumido"].ToDecimal(),
                    EstatusId = reader["EstatusId"].ToInt(),
                    PlanId = reader["PlanId"].ToInt(),
                    Plan_ = new MostrarPlanesDto
                    {
                        Plan = reader["Plan"].ToString(),
                        MontoCobertura = reader["MontoCobertura"].ToInt(),
                        FechaRegistro = reader["FechaRegistro"].ToDateTime(),
                        Estatus = reader["Estatus"].ToBool()
                    },
                    Estatus_ = new MostrarEstatusDto
                    {
                        Id = reader["Id"].ToInt(),
                        Estatus = reader["Estatus"].ToBool()
                    }
                };
            }

            DataAccess.GetInstance().CloseConnection();

            return new MostrarAfiliadosDto();
        }

        public async Task<bool> Inactivar(int id, int inactivar)
        {
           var result = await DataAccess.GetInstance().OpenConnection().UserStoreProcedure("InactivarAfiliado",
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
