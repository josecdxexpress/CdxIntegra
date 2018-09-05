namespace CDX.NF.Core.Infraestrutura.Interfaces
{
    /// <summary>
    /// Interface de repositório base
    /// </summary>
    /// <typeparam name="T">Informe o objeto IEntidade</typeparam>
    /// <typeparam name="J">Informe o tipo do campo ID</typeparam>
    public interface IRepositorio<T, J> where T : IEntidade
    {
        //void Adicionar(T entidade);
        //void Editar(T entidade);
        //IQueryable<T> SetEmpresaId(Guid id);     
        //void Remover(J id);
        //Task<bool> ExisteAsync(J id);
        //Task<T> AdicionarAsync(T entidade);
        //Task<T> EditarAsync(T entidade);
        ////IQueryable<T> SetEmpresaId(Guid id);     
        //Task RemoverAsync(Guid id);
    }
}
