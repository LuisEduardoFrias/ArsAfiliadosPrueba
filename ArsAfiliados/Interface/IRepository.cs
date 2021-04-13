using System.Collections.Generic;
using System.Threading.Tasks;

namespace ArsAfiliados.Interface
{
    interface IRepository<T, J ,P> where T : class
    {
        Task<List<P>> Mostrar();

        Task<bool> Crear(T afiliadosDto);

        Task<bool> Actualizar(J afiliadosDto);

        Task<P> Buscar(string cedula);

        Task<bool> Inactivar(int id, int inactivar);
    }
}
