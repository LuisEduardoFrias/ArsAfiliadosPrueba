using System;

namespace ArsAfiliados.Models
{
    public class Afiliados
    {
        public int Id { get; set; }

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

        public Estatus Estatus { get; set; }

        public Planes Planes { get; set; }

    }
}
