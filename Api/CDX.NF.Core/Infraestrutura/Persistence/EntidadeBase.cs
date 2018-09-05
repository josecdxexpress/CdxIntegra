using CDX.NF.Core.Infraestrutura.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace CDX.NF.Core.Infraestrutura.Persistence
{
    public interface IEntidadeAuditada
    {
        DateTime DataInclusao { get; set; }

        DateTime DataAlteracao { get; set; }

        int IdUsuarioInclusao { get; set; }

        int IdUsuarioAlteracao { get; set; }

        bool Excluido { get; set; }
    }

    /// <summary>
    /// Entidade base
    /// </summary>
    /// <typeparam name="T">Tipo da entidade base</typeparam>
    public abstract class EntidadeBase<T> : IEntidadeAuditada
    {
        /// <summary>
        /// Identificador de registro na base de dados
        /// </summary>
        public abstract T Id { get; set; }

        [Column("DATA_INCLUSAO")]
        public DateTime DataInclusao { get; set; }

        [Column("DATA_ALTERACAO")]
        public DateTime DataAlteracao { get; set; }

        [Column("ID_USUARIO_INCLUSAO")]
        public int IdUsuarioInclusao { get; set; }

        [Column("ID_USUARIO_ALTERACAO")]
        public int IdUsuarioAlteracao { get; set; }

        public bool Excluido { get; set; }
    }

    public abstract class EntidadeBaseIdAuto : EntidadeBase<int>
    {
        /// <summary>
        /// Identificador de registro na base de dados
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override int Id { get; set; }
    }

    //public abstract class BaseMapping<T, TID> : IEntityMapping, INamedTableMapping
    //    where T : EntidadeBase<TID>
    //{
    //    public string MappedTableName
    //    {
    //        get
    //        {
    //            var configType = this.GetType().GetModuleConfigurationType();

    //            return string.Format("{0}{1}", configType.GetDbPrefix() ?? string.Empty, TableName);
    //        }
    //    }

    //    public string SchemmaName
    //    {
    //        get
    //        {
    //            var configType = this.GetType().GetModuleConfigurationType();

    //            return configType.GetDbSchemma();
    //        }
    //    }

    //    public abstract string TableName { get; }

    //    void IEntityMapping.Map(DbModelBuilder modelBuilder)
    //    {
    //        // var entityConfiguration = new TcpEntityTypeConfiguration<T>();
    //        var entityConfiguration = modelBuilder.Entity<T>();

    //        if (!string.IsNullOrWhiteSpace(TableName))
    //        {
    //            entityConfiguration.ToTable(this.MappedTableName, this.SchemmaName);
    //        }

    //        entityConfiguration.HasTableAnnotation("GRANT_DEPENDENTS", "REFERENCES");

    //        Map(entityConfiguration);

    //        // modelBuilder.Configurations.Add(entityConfiguration);
    //    }

    //    public abstract void Map(EntityTypeConfiguration<T> mapper);
    //}

    //internal interface IEntityMapping
    //{
    //    void Map(DbModelBuilder modelBuilder);
    //}

    internal interface INamedTableMapping
    {
        string MappedTableName { get; }

        string TableName { get; }

        string SchemmaName { get; }
    }
}
