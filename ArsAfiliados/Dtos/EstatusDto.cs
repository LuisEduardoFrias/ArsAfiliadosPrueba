using System;

namespace ArsAfiliados.Dtos
{
    public class CrearEstatusDto
    {
        public bool Estatus { get; set; }
    }

    public class ActualizarEstatusDto : CrearEstatusDto
    {
        public int Id { get; set; }
    }

    public class MostrarEstatusDto : ActualizarEstatusDto
    {
        public string Estatus_ => Estatus == true ? "Activo" : "Inactivo";
    }
}
