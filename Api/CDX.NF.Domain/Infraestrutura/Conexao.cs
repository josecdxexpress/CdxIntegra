using Microsoft.EntityFrameworkCore;
using CDX.NF.Domain.Models;
using CDX.NF.Domain.Models.Enum;
using System.Threading.Tasks;
using CDX.NF.Core.Infraestrutura.Interfaces;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace CDX.NF.Domain.Infraestrutura.Conexao
{
    public class Contexto : DbContext
    {
        public DbSet<NotaFiscalSolicitada> NotaFiscalSolicitada { get; set; }
        public DbSet<Requisicao> Requisicao { get; set; }
        public DbSet<Cidade> Cidade { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Parametros> Parametros { get; set; }
        public DbSet<UsuarioPermissao> UsuarioPermissao { get; set; }
        public DbSet<NotaFiscalAutorizada> NotaFiscalAutorizada { get; set; }
        public DbSet<ServicoWsSoap> ServicoWsSoap { get; set; }
        public DbSet<LogEvento> LogEvento { get; set; }

        public DbSet<Prestador> Prestador { get; set; }

        //public IEnumerable<object> Prestador { get; internal set; }

        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {

        }

        #region Filtros e Configurações
        private void ConfigurarSistema(ModelBuilder builder)
        {
            #region NotaFiscal
            //builder.Entity<NotaFiscal>()
            //    .HasQueryFilter(p => p.Situacao != SituacaoEnum.Excluido);
            #endregion
        }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("dbo");

            modelBuilder.HasSequence("SequenceNotaFiscal").StartsAt(11000).IncrementsBy(1);

            modelBuilder.Entity<Requisicao>()
                .HasOne(p => p.NotaFiscalAutorizada)
                .WithMany(b => b.Requisicoes)
                .HasForeignKey(p => p.NotaFiscalAutorizadaId)
                .HasConstraintName("ForeignKey_Requisicao_NotaFiscalAutorizada");

            ConfigurarSistema(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-TSM74VM\SQLEXPRESS;Initial Catalog=CDXNF;Integrated Security=True;");
        //}

        public int GetReferencia()
        {
            SqlParameter result = new SqlParameter("@result", System.Data.SqlDbType.Int)
            {
                Direction = System.Data.ParameterDirection.Output
            };

            Database.ExecuteSqlCommand(
                       "SELECT @result = (NEXT VALUE FOR SequenceNotaFiscal)", result);

            return (int)result.Value;
        }

        public async Task<int> GetReferenciaAsync()
        {
            SqlParameter result = new SqlParameter("@result", System.Data.SqlDbType.Int)
            {
                Direction = System.Data.ParameterDirection.Output
            };

            await Database.ExecuteSqlCommandAsync(
                       "SELECT @result = (NEXT VALUE FOR SequenceNotaFiscal)", result);

            return (int)result.Value;
        }
    }
    public class Uow : IUow
    {
        private readonly Contexto _context;

        public Uow(Contexto context)
        {
            _context = context;
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Rollback()
        {
            // Do nothing :)
        }
    }
}