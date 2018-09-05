using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CDX.NF.Domain.Migrations
{
    public partial class _140820181 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateSequence(
                name: "SequenceNotaFiscal",
                schema: "dbo",
                startValue: 11000L);

            migrationBuilder.CreateTable(
                name: "Endereco",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UsuarioId = table.Column<int>(nullable: true),
                    DataCadastro = table.Column<DateTime>(nullable: true),
                    DataAlteracao = table.Column<DateTime>(nullable: true),
                    Situacao = table.Column<int>(nullable: false),
                    Logradouro = table.Column<string>(maxLength: 50, nullable: true),
                    Numero = table.Column<string>(maxLength: 10, nullable: true),
                    Complemento = table.Column<string>(maxLength: 100, nullable: true),
                    Bairro = table.Column<string>(maxLength: 100, nullable: true),
                    Uf = table.Column<string>(maxLength: 20, nullable: true),
                    Cep = table.Column<string>(maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Endereco", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Prestador",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UsuarioId = table.Column<int>(nullable: true),
                    DataCadastro = table.Column<DateTime>(nullable: true),
                    DataAlteracao = table.Column<DateTime>(nullable: true),
                    Situacao = table.Column<int>(nullable: false),
                    Cnpj = table.Column<string>(maxLength: 20, nullable: true),
                    Inscricao_municipal = table.Column<string>(maxLength: 20, nullable: true),
                    Codigo_municipio = table.Column<string>(maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prestador", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Servico",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UsuarioId = table.Column<int>(nullable: true),
                    DataCadastro = table.Column<DateTime>(nullable: true),
                    DataAlteracao = table.Column<DateTime>(nullable: true),
                    Situacao = table.Column<int>(nullable: false),
                    Discriminacao = table.Column<string>(maxLength: 200, nullable: true),
                    Iss_retido = table.Column<string>(maxLength: 20, nullable: true),
                    Valor_iss = table.Column<string>(maxLength: 20, nullable: true),
                    Codigo_cnae = table.Column<string>(maxLength: 20, nullable: true),
                    Item_lista_servico = table.Column<string>(maxLength: 200, nullable: true),
                    Valor_servicos = table.Column<string>(maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servico", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ServicoWsSoap",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UsuarioId = table.Column<int>(nullable: true),
                    DataCadastro = table.Column<DateTime>(nullable: true),
                    DataAlteracao = table.Column<DateTime>(nullable: true),
                    Situacao = table.Column<int>(nullable: false),
                    Codigo = table.Column<int>(maxLength: 10, nullable: false),
                    Descricao = table.Column<string>(maxLength: 60, nullable: false),
                    Url = table.Column<string>(maxLength: 60, nullable: false),
                    Namespace = table.Column<string>(maxLength: 60, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServicoWsSoap", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UsuarioId = table.Column<int>(nullable: true),
                    DataCadastro = table.Column<DateTime>(nullable: true),
                    DataAlteracao = table.Column<DateTime>(nullable: true),
                    Situacao = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(maxLength: 50, nullable: false),
                    Login = table.Column<string>(maxLength: 10, nullable: false),
                    Senha = table.Column<string>(maxLength: 10, nullable: false),
                    email = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tomador",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UsuarioId = table.Column<int>(nullable: true),
                    DataCadastro = table.Column<DateTime>(nullable: true),
                    DataAlteracao = table.Column<DateTime>(nullable: true),
                    Situacao = table.Column<int>(nullable: false),
                    Cpf = table.Column<string>(maxLength: 20, nullable: true),
                    Razao_social = table.Column<string>(maxLength: 200, nullable: true),
                    Telefone = table.Column<string>(maxLength: 20, nullable: true),
                    Email = table.Column<string>(maxLength: 50, nullable: true),
                    EnderecoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tomador", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tomador_Endereco_EnderecoId",
                        column: x => x.EnderecoId,
                        principalSchema: "dbo",
                        principalTable: "Endereco",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NotaFiscalAutorizada",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UsuarioId = table.Column<int>(nullable: true),
                    DataCadastro = table.Column<DateTime>(nullable: true),
                    DataAlteracao = table.Column<DateTime>(nullable: true),
                    Situacao = table.Column<int>(nullable: false),
                    PrestadorCnpj = table.Column<string>(maxLength: 20, nullable: true),
                    Referencia = table.Column<string>(maxLength: 50, nullable: false),
                    ServicoWsSoapId = table.Column<int>(nullable: true),
                    Numero = table.Column<string>(maxLength: 50, nullable: true),
                    CodigoVerificacao = table.Column<string>(maxLength: 50, nullable: true),
                    UrlPrefeitura = table.Column<string>(maxLength: 200, nullable: true),
                    CaminhoNfe = table.Column<string>(maxLength: 200, nullable: true),
                    Status = table.Column<string>(maxLength: 50, nullable: true),
                    ImagemNfe = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    DataEmissao = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotaFiscalAutorizada", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NotaFiscalAutorizada_ServicoWsSoap_ServicoWsSoapId",
                        column: x => x.ServicoWsSoapId,
                        principalSchema: "dbo",
                        principalTable: "ServicoWsSoap",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cidade",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UsuarioId = table.Column<int>(nullable: true),
                    DataCadastro = table.Column<DateTime>(nullable: true),
                    DataAlteracao = table.Column<DateTime>(nullable: true),
                    Situacao = table.Column<int>(nullable: false),
                    Codigo = table.Column<string>(nullable: false),
                    Descricao = table.Column<string>(maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cidade", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cidade_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalSchema: "dbo",
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Autorizar",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UsuarioId = table.Column<int>(nullable: true),
                    DataCadastro = table.Column<DateTime>(nullable: true),
                    DataAlteracao = table.Column<DateTime>(nullable: true),
                    Situacao = table.Column<int>(nullable: false),
                    Data_emissao = table.Column<string>(maxLength: 30, nullable: true),
                    Natureza_operacao = table.Column<string>(maxLength: 50, nullable: true),
                    Optante_simples_nacional = table.Column<string>(maxLength: 30, nullable: true),
                    PrestadorId = table.Column<int>(nullable: true),
                    TomadorId = table.Column<int>(nullable: true),
                    ServicoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autorizar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Autorizar_Prestador_PrestadorId",
                        column: x => x.PrestadorId,
                        principalSchema: "dbo",
                        principalTable: "Prestador",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Autorizar_Servico_ServicoId",
                        column: x => x.ServicoId,
                        principalSchema: "dbo",
                        principalTable: "Servico",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Autorizar_Tomador_TomadorId",
                        column: x => x.TomadorId,
                        principalSchema: "dbo",
                        principalTable: "Tomador",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Parametros",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UsuarioId = table.Column<int>(nullable: true),
                    DataCadastro = table.Column<DateTime>(nullable: true),
                    DataAlteracao = table.Column<DateTime>(nullable: true),
                    Situacao = table.Column<int>(nullable: false),
                    CidadeId = table.Column<int>(nullable: false),
                    PrestadorId = table.Column<int>(nullable: false),
                    ServicoWSoapId = table.Column<int>(nullable: true),
                    ServicoWsSoapId = table.Column<int>(nullable: true),
                    Alicota = table.Column<float>(nullable: false),
                    BloqueioEmissao = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parametros", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Parametros_Cidade_CidadeId",
                        column: x => x.CidadeId,
                        principalSchema: "dbo",
                        principalTable: "Cidade",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Parametros_Prestador_PrestadorId",
                        column: x => x.PrestadorId,
                        principalSchema: "dbo",
                        principalTable: "Prestador",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Parametros_ServicoWsSoap_ServicoWsSoapId",
                        column: x => x.ServicoWsSoapId,
                        principalSchema: "dbo",
                        principalTable: "ServicoWsSoap",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Requisicao",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UsuarioId = table.Column<int>(nullable: true),
                    DataCadastro = table.Column<DateTime>(nullable: true),
                    DataAlteracao = table.Column<DateTime>(nullable: true),
                    Situacao = table.Column<int>(nullable: false),
                    Referencia = table.Column<int>(maxLength: 50, nullable: false),
                    ServicoWsSoapId = table.Column<int>(nullable: true),
                    NotaFiscalAutorizadaId = table.Column<int>(nullable: true),
                    TipoOperacao = table.Column<int>(nullable: false),
                    Prestador = table.Column<string>(maxLength: 20, nullable: true),
                    ValorNota = table.Column<float>(nullable: false),
                    CidadeId = table.Column<int>(nullable: true),
                    Etapa = table.Column<int>(nullable: false),
                    TempoExecucao = table.Column<float>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    erro = table.Column<string>(nullable: true),
                    Observacao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requisicao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Requisicao_Cidade_CidadeId",
                        column: x => x.CidadeId,
                        principalSchema: "dbo",
                        principalTable: "Cidade",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "ForeignKey_Requisicao_NotaFiscalAutorizada",
                        column: x => x.NotaFiscalAutorizadaId,
                        principalSchema: "dbo",
                        principalTable: "NotaFiscalAutorizada",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Requisicao_ServicoWsSoap_ServicoWsSoapId",
                        column: x => x.ServicoWsSoapId,
                        principalSchema: "dbo",
                        principalTable: "ServicoWsSoap",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioPermissao",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DataCadastro = table.Column<DateTime>(nullable: true),
                    DataAlteracao = table.Column<DateTime>(nullable: true),
                    Situacao = table.Column<int>(nullable: false),
                    UsuarioId = table.Column<int>(nullable: false),
                    CidadeId = table.Column<int>(nullable: false),
                    PrestadorId = table.Column<int>(nullable: true),
                    BloqueioEmissao = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioPermissao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsuarioPermissao_Cidade_CidadeId",
                        column: x => x.CidadeId,
                        principalSchema: "dbo",
                        principalTable: "Cidade",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsuarioPermissao_Prestador_PrestadorId",
                        column: x => x.PrestadorId,
                        principalSchema: "dbo",
                        principalTable: "Prestador",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UsuarioPermissao_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalSchema: "dbo",
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NotaFiscalSolicitada",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UsuarioId = table.Column<int>(nullable: true),
                    DataCadastro = table.Column<DateTime>(nullable: true),
                    DataAlteracao = table.Column<DateTime>(nullable: true),
                    Situacao = table.Column<int>(nullable: false),
                    Homologacao = table.Column<bool>(nullable: false),
                    Identificador_nota = table.Column<int>(nullable: false),
                    AutorizarId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotaFiscalSolicitada", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NotaFiscalSolicitada_Autorizar_AutorizarId",
                        column: x => x.AutorizarId,
                        principalSchema: "dbo",
                        principalTable: "Autorizar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Autorizar_PrestadorId",
                schema: "dbo",
                table: "Autorizar",
                column: "PrestadorId");

            migrationBuilder.CreateIndex(
                name: "IX_Autorizar_ServicoId",
                schema: "dbo",
                table: "Autorizar",
                column: "ServicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Autorizar_TomadorId",
                schema: "dbo",
                table: "Autorizar",
                column: "TomadorId");

            migrationBuilder.CreateIndex(
                name: "IX_Cidade_UsuarioId",
                schema: "dbo",
                table: "Cidade",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_NotaFiscalAutorizada_ServicoWsSoapId",
                schema: "dbo",
                table: "NotaFiscalAutorizada",
                column: "ServicoWsSoapId");

            migrationBuilder.CreateIndex(
                name: "IX_NotaFiscalSolicitada_AutorizarId",
                schema: "dbo",
                table: "NotaFiscalSolicitada",
                column: "AutorizarId");

            migrationBuilder.CreateIndex(
                name: "IX_Parametros_CidadeId",
                schema: "dbo",
                table: "Parametros",
                column: "CidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_Parametros_PrestadorId",
                schema: "dbo",
                table: "Parametros",
                column: "PrestadorId");

            migrationBuilder.CreateIndex(
                name: "IX_Parametros_ServicoWsSoapId",
                schema: "dbo",
                table: "Parametros",
                column: "ServicoWsSoapId");

            migrationBuilder.CreateIndex(
                name: "IX_Requisicao_CidadeId",
                schema: "dbo",
                table: "Requisicao",
                column: "CidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_Requisicao_NotaFiscalAutorizadaId",
                schema: "dbo",
                table: "Requisicao",
                column: "NotaFiscalAutorizadaId");

            migrationBuilder.CreateIndex(
                name: "IX_Requisicao_ServicoWsSoapId",
                schema: "dbo",
                table: "Requisicao",
                column: "ServicoWsSoapId");

            migrationBuilder.CreateIndex(
                name: "IX_Tomador_EnderecoId",
                schema: "dbo",
                table: "Tomador",
                column: "EnderecoId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioPermissao_CidadeId",
                schema: "dbo",
                table: "UsuarioPermissao",
                column: "CidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioPermissao_PrestadorId",
                schema: "dbo",
                table: "UsuarioPermissao",
                column: "PrestadorId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioPermissao_UsuarioId",
                schema: "dbo",
                table: "UsuarioPermissao",
                column: "UsuarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NotaFiscalSolicitada",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Parametros",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Requisicao",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "UsuarioPermissao",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Autorizar",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "NotaFiscalAutorizada",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Cidade",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Prestador",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Servico",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Tomador",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "ServicoWsSoap",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Usuario",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Endereco",
                schema: "dbo");

            migrationBuilder.DropSequence(
                name: "SequenceNotaFiscal",
                schema: "dbo");
        }
    }
}
