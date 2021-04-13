using System;

namespace ArsAfiliados.Dtos
{
    public class CrearAfiliadosDto
    {
        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public DateTime Fecha { get; set; }

        public string Nacimiento { get; set; }

        public char Sexo { get; set; }

        public string Cedula { get; set; }

        public string NumeroSeguroSocial { get; set; }

        public DateTime FechaRegistro { get; set; }

        public decimal MontoConsumido { get; set; }

        public int EstatusId { get; set; }

        public int PlanId { get; set; }
    }

    public class ActualizarAfiliadoDto : CrearAfiliadosDto
    {
        public int Id { get; set; }
    }

    public class MostrarAfiliadosDto : ActualizarAfiliadoDto
    {
        public MostrarEstatusDto Estatus_ { get; set; }

        public string Estatus => Estatus_.Estatus_;

        public MostrarPlanesDto Plan_ { get; set; }

        public string Plan => Plan_.Estatus_;

    }
}
