using Data.Entidades;

namespace Data.EF.Interfaces
{
    public interface ICliente : IBaseRepository<Cliente>
    {
        Cliente LastId();
    }
}
