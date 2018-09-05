using System.Threading.Tasks;

namespace CDX.NF.Core.Infraestrutura.Interfaces
{
    public interface IUow
    {
        Task CommitAsync();
        void Rollback();
    }
}
