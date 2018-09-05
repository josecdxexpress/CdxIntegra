﻿// <auto-generated />
using System;
using CDX.NF.Domain.Infraestrutura.Conexao;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CDX.NF.Domain.Migrations
{
    [DbContext(typeof(Contexto))]
    [Migration("20180815012034_140820181")]
    partial class _140820181
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("dbo")
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("Relational:Sequence:.SequenceNotaFiscal", "'SequenceNotaFiscal', '', '11000', '1', '', '', 'Int64', 'False'")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CDX.NF.Domain.Models.Autorizar", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("DataAlteracao");

                    b.Property<DateTime?>("DataCadastro");

                    b.Property<string>("Data_emissao")
                        .HasMaxLength(30);

                    b.Property<string>("Natureza_operacao")
                        .HasMaxLength(50);

                    b.Property<string>("Optante_simples_nacional")
                        .HasMaxLength(30);

                    b.Property<int?>("PrestadorId");

                    b.Property<int?>("ServicoId");

                    b.Property<int>("Situacao");

                    b.Property<int?>("TomadorId");

                    b.Property<int?>("UsuarioId");

                    b.HasKey("Id");

                    b.HasIndex("PrestadorId");

                    b.HasIndex("ServicoId");

                    b.HasIndex("TomadorId");

                    b.ToTable("Autorizar");
                });

            modelBuilder.Entity("CDX.NF.Domain.Models.Cidade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Codigo")
                        .IsRequired();

                    b.Property<DateTime?>("DataAlteracao");

                    b.Property<DateTime?>("DataCadastro");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(60);

                    b.Property<int>("Situacao");

                    b.Property<int?>("UsuarioId");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Cidade");
                });

            modelBuilder.Entity("CDX.NF.Domain.Models.Endereco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Bairro")
                        .HasMaxLength(100);

                    b.Property<string>("Cep")
                        .HasMaxLength(20);

                    b.Property<string>("Complemento")
                        .HasMaxLength(100);

                    b.Property<DateTime?>("DataAlteracao");

                    b.Property<DateTime?>("DataCadastro");

                    b.Property<string>("Logradouro")
                        .HasMaxLength(50);

                    b.Property<string>("Numero")
                        .HasMaxLength(10);

                    b.Property<int>("Situacao");

                    b.Property<string>("Uf")
                        .HasMaxLength(20);

                    b.Property<int?>("UsuarioId");

                    b.HasKey("Id");

                    b.ToTable("Endereco");
                });

            modelBuilder.Entity("CDX.NF.Domain.Models.NotaFiscalAutorizada", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CaminhoNfe")
                        .HasMaxLength(200);

                    b.Property<string>("CodigoVerificacao")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("DataAlteracao");

                    b.Property<DateTime?>("DataCadastro");

                    b.Property<DateTime>("DataEmissao");

                    b.Property<byte[]>("ImagemNfe")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Numero")
                        .HasMaxLength(50);

                    b.Property<string>("PrestadorCnpj")
                        .HasMaxLength(20);

                    b.Property<string>("Referencia")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int?>("ServicoWsSoapId");

                    b.Property<int>("Situacao");

                    b.Property<string>("Status")
                        .HasMaxLength(50);

                    b.Property<string>("UrlPrefeitura")
                        .HasMaxLength(200);

                    b.Property<int?>("UsuarioId");

                    b.HasKey("Id");

                    b.HasIndex("ServicoWsSoapId");

                    b.ToTable("NotaFiscalAutorizada");
                });

            modelBuilder.Entity("CDX.NF.Domain.Models.NotaFiscalSolicitada", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AutorizarId");

                    b.Property<DateTime?>("DataAlteracao");

                    b.Property<DateTime?>("DataCadastro");

                    b.Property<bool>("Homologacao");

                    b.Property<int>("Identificador_nota");

                    b.Property<int>("Situacao");

                    b.Property<int?>("UsuarioId");

                    b.HasKey("Id");

                    b.HasIndex("AutorizarId");

                    b.ToTable("NotaFiscalSolicitada");
                });

            modelBuilder.Entity("CDX.NF.Domain.Models.Parametros", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("Alicota");

                    b.Property<bool>("BloqueioEmissao");

                    b.Property<int>("CidadeId");

                    b.Property<DateTime?>("DataAlteracao");

                    b.Property<DateTime?>("DataCadastro");

                    b.Property<int>("PrestadorId");

                    b.Property<int?>("ServicoWSoapId");

                    b.Property<int?>("ServicoWsSoapId");

                    b.Property<int>("Situacao");

                    b.Property<int?>("UsuarioId");

                    b.HasKey("Id");

                    b.HasIndex("CidadeId");

                    b.HasIndex("PrestadorId");

                    b.HasIndex("ServicoWsSoapId");

                    b.ToTable("Parametros");
                });

            modelBuilder.Entity("CDX.NF.Domain.Models.Prestador", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Cnpj")
                        .HasMaxLength(20);

                    b.Property<string>("Codigo_municipio")
                        .HasMaxLength(20);

                    b.Property<DateTime?>("DataAlteracao");

                    b.Property<DateTime?>("DataCadastro");

                    b.Property<string>("Inscricao_municipal")
                        .HasMaxLength(20);

                    b.Property<int>("Situacao");

                    b.Property<int?>("UsuarioId");

                    b.HasKey("Id");

                    b.ToTable("Prestador");
                });

            modelBuilder.Entity("CDX.NF.Domain.Models.Requisicao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CidadeId");

                    b.Property<DateTime?>("DataAlteracao");

                    b.Property<DateTime?>("DataCadastro");

                    b.Property<int>("Etapa");

                    b.Property<int?>("NotaFiscalAutorizadaId");

                    b.Property<string>("Observacao");

                    b.Property<string>("Prestador")
                        .HasMaxLength(20);

                    b.Property<int>("Referencia")
                        .HasMaxLength(50);

                    b.Property<int?>("ServicoWsSoapId");

                    b.Property<int>("Situacao");

                    b.Property<int>("Status");

                    b.Property<float?>("TempoExecucao");

                    b.Property<int>("TipoOperacao");

                    b.Property<int?>("UsuarioId");

                    b.Property<float>("ValorNota");

                    b.Property<string>("erro");

                    b.HasKey("Id");

                    b.HasIndex("CidadeId");

                    b.HasIndex("NotaFiscalAutorizadaId");

                    b.HasIndex("ServicoWsSoapId");

                    b.ToTable("Requisicao");
                });

            modelBuilder.Entity("CDX.NF.Domain.Models.Servico", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Codigo_cnae")
                        .HasMaxLength(20);

                    b.Property<DateTime?>("DataAlteracao");

                    b.Property<DateTime?>("DataCadastro");

                    b.Property<string>("Discriminacao")
                        .HasMaxLength(200);

                    b.Property<string>("Iss_retido")
                        .HasMaxLength(20);

                    b.Property<string>("Item_lista_servico")
                        .HasMaxLength(200);

                    b.Property<int>("Situacao");

                    b.Property<int?>("UsuarioId");

                    b.Property<string>("Valor_iss")
                        .HasMaxLength(20);

                    b.Property<string>("Valor_servicos")
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.ToTable("Servico");
                });

            modelBuilder.Entity("CDX.NF.Domain.Models.ServicoWsSoap", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Codigo")
                        .HasMaxLength(10);

                    b.Property<DateTime?>("DataAlteracao");

                    b.Property<DateTime?>("DataCadastro");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(60);

                    b.Property<string>("Namespace")
                        .HasMaxLength(60);

                    b.Property<int>("Situacao");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasMaxLength(60);

                    b.Property<int?>("UsuarioId");

                    b.HasKey("Id");

                    b.ToTable("ServicoWsSoap");
                });

            modelBuilder.Entity("CDX.NF.Domain.Models.Tomador", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Cpf")
                        .HasMaxLength(20);

                    b.Property<DateTime?>("DataAlteracao");

                    b.Property<DateTime?>("DataCadastro");

                    b.Property<string>("Email")
                        .HasMaxLength(50);

                    b.Property<int?>("EnderecoId");

                    b.Property<string>("Razao_social")
                        .HasMaxLength(200);

                    b.Property<int>("Situacao");

                    b.Property<string>("Telefone")
                        .HasMaxLength(20);

                    b.Property<int?>("UsuarioId");

                    b.HasKey("Id");

                    b.HasIndex("EnderecoId");

                    b.ToTable("Tomador");
                });

            modelBuilder.Entity("CDX.NF.Domain.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("DataAlteracao");

                    b.Property<DateTime?>("DataCadastro");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.Property<int>("Situacao");

                    b.Property<int?>("UsuarioId");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.HasKey("Id");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("CDX.NF.Domain.Models.UsuarioPermissao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("BloqueioEmissao");

                    b.Property<int>("CidadeId");

                    b.Property<DateTime?>("DataAlteracao");

                    b.Property<DateTime?>("DataCadastro");

                    b.Property<int?>("PrestadorId");

                    b.Property<int>("Situacao");

                    b.Property<int>("UsuarioId");

                    b.HasKey("Id");

                    b.HasIndex("CidadeId");

                    b.HasIndex("PrestadorId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("UsuarioPermissao");
                });

            modelBuilder.Entity("CDX.NF.Domain.Models.Autorizar", b =>
                {
                    b.HasOne("CDX.NF.Domain.Models.Prestador", "Prestador")
                        .WithMany()
                        .HasForeignKey("PrestadorId");

                    b.HasOne("CDX.NF.Domain.Models.Servico", "Servico")
                        .WithMany()
                        .HasForeignKey("ServicoId");

                    b.HasOne("CDX.NF.Domain.Models.Tomador", "Tomador")
                        .WithMany()
                        .HasForeignKey("TomadorId");
                });

            modelBuilder.Entity("CDX.NF.Domain.Models.Cidade", b =>
                {
                    b.HasOne("CDX.NF.Domain.Models.Usuario")
                        .WithMany("Cidades")
                        .HasForeignKey("UsuarioId");
                });

            modelBuilder.Entity("CDX.NF.Domain.Models.NotaFiscalAutorizada", b =>
                {
                    b.HasOne("CDX.NF.Domain.Models.ServicoWsSoap", "ServicoWsSoap")
                        .WithMany()
                        .HasForeignKey("ServicoWsSoapId");
                });

            modelBuilder.Entity("CDX.NF.Domain.Models.NotaFiscalSolicitada", b =>
                {
                    b.HasOne("CDX.NF.Domain.Models.Autorizar", "Autorizar")
                        .WithMany()
                        .HasForeignKey("AutorizarId");
                });

            modelBuilder.Entity("CDX.NF.Domain.Models.Parametros", b =>
                {
                    b.HasOne("CDX.NF.Domain.Models.Cidade", "Cidade")
                        .WithMany()
                        .HasForeignKey("CidadeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CDX.NF.Domain.Models.Prestador", "Prestador")
                        .WithMany()
                        .HasForeignKey("PrestadorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CDX.NF.Domain.Models.ServicoWsSoap", "ServicoWsSoap")
                        .WithMany()
                        .HasForeignKey("ServicoWsSoapId");
                });

            modelBuilder.Entity("CDX.NF.Domain.Models.Requisicao", b =>
                {
                    b.HasOne("CDX.NF.Domain.Models.Cidade", "Cidade")
                        .WithMany()
                        .HasForeignKey("CidadeId");

                    b.HasOne("CDX.NF.Domain.Models.NotaFiscalAutorizada", "NotaFiscalAutorizada")
                        .WithMany("Requisicoes")
                        .HasForeignKey("NotaFiscalAutorizadaId")
                        .HasConstraintName("ForeignKey_Requisicao_NotaFiscalAutorizada");

                    b.HasOne("CDX.NF.Domain.Models.ServicoWsSoap", "ServicoWsSoap")
                        .WithMany()
                        .HasForeignKey("ServicoWsSoapId");
                });

            modelBuilder.Entity("CDX.NF.Domain.Models.Tomador", b =>
                {
                    b.HasOne("CDX.NF.Domain.Models.Endereco", "Endereco")
                        .WithMany()
                        .HasForeignKey("EnderecoId");
                });

            modelBuilder.Entity("CDX.NF.Domain.Models.UsuarioPermissao", b =>
                {
                    b.HasOne("CDX.NF.Domain.Models.Cidade", "Cidade")
                        .WithMany()
                        .HasForeignKey("CidadeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CDX.NF.Domain.Models.Prestador", "Prestador")
                        .WithMany()
                        .HasForeignKey("PrestadorId");

                    b.HasOne("CDX.NF.Domain.Models.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
