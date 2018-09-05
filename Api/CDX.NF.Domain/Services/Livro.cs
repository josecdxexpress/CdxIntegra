using CDX.NF.Core.Infraestrutura.Persistence;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CDX.NF.Domain.Services
{
    public class Livro : EntidadeBaseIdAuto
    {
        [Required]
        [MaxLength(255)]
        public string Titulo { get; set; }
    }

    //public class LivroMapping : BaseMapping<Livro, int>
    //{
    //    public override string TableName
    //    {
    //        get { return "LIVRO"; }
    //    }

    //    public override void Map(EntityTypeConfiguration<Livro> mapper)
    //    {
    //        mapper.Property(x => x.Id)
    //            .HasColumnName("LIVRO_ID");

    //        mapper.Property(x => x.Titulo)
    //            .HasColumnName("TITULO")
    //            .HasMaxLength(255);
    //    }
    //}
}