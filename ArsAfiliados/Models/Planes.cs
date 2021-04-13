using System;

namespace ArsAfiliados.Models
{
    public class Planes
    {
        public int Id { get; set; }
        public string Plan { get; set; }
        public decimal MontoCobertura { get; set; }
        public DateTime FechaRegistro { get; set; }
        public bool Estatus_ { get; set; }
    }
}
