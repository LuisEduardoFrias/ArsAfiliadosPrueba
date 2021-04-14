using System;

namespace ArsAfiliados.Dtos
{
    public class CrearPlanesDto : ErrorDto
    {
        public string Plan { get; set; }
        public decimal MontoCobertura { get; set; }
        public DateTime FechaRegistro { get; set; }
        public bool Estatus { get; set; }
    }

    public class ActualizarPlanesDto : CrearPlanesDto
    {
        public int Id { get; set; }
    }

    public class MostrarPlanesDto : ActualizarPlanesDto
    {
        public string Estatus_ => Estatus == true ? "Activo" : "Inactivo";
    }
}
