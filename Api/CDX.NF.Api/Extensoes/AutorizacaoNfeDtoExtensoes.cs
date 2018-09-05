using CDX.NF.Api.Dto;
using CDX.NF.Domain.Models.To;

namespace CDX.NF.Api.Extensoes
{
    public static class AutorizacaoNfeDtoExtensoes
    {
        internal static AutorizacaoNfeTo ToTransferObject(this AutorizacaoNfeDto re)
        {
            return new AutorizacaoNfeTo()
            {
                FormaRetorno = re.FormaRetorno,
                Autenticacao = new AutenticacaoTo() { Usuario = re.Autenticacao.Usuario, Senha = re.Autenticacao.Senha, Token = re.Autenticacao.Token },
                Nfe = new NfeTo()
                {
                    CapaAutorizacaoNfse = new AutorizacaoTo()
                    {
                        Autorizar = new AutorizarTo()
                        {
                            Data_emissao = re.Nfe.Emissao.Autorizar.Data_emissao,
                            Natureza_operacao = re.Nfe.Emissao.Autorizar.Natureza_operacao,
                            Optante_simples_nacional = re.Nfe.Emissao.Autorizar.Optante_simples_nacional,
                            Prestador = new PrestadorTo()
                            {
                                Cnpj = re.Nfe.Emissao.Autorizar.Prestador.Cnpj,
                                Inscricao_municipal = re.Nfe.Emissao.Autorizar.Prestador.Inscricao_municipal,
                                Codigo_municipio = re.Nfe.Emissao.Autorizar.Prestador.Codigo_municipio
                            },
                            Tomador = new TomadorTo()
                            {
                                Cpf = re.Nfe.Emissao.Autorizar.Tomador.Cpf,
                                Razao_social = re.Nfe.Emissao.Autorizar.Tomador.Razao_social,
                                Telefone = re.Nfe.Emissao.Autorizar.Tomador.Telefone,
                                Email = re.Nfe.Emissao.Autorizar.Tomador.Email,
                                Endereco = new EnderecoTo()
                                {
                                    Logradouro = re.Nfe.Emissao.Autorizar.Tomador.Endereco.Logradouro,
                                    Numero = re.Nfe.Emissao.Autorizar.Tomador.Endereco.Numero,
                                    Complemento = re.Nfe.Emissao.Autorizar.Tomador.Endereco.Complemento,
                                    Bairro = re.Nfe.Emissao.Autorizar.Tomador.Endereco.Bairro,
                                    Uf = re.Nfe.Emissao.Autorizar.Tomador.Endereco.Uf,
                                    Cep = re.Nfe.Emissao.Autorizar.Tomador.Endereco.Cep
                                }
                            },
                            Servico = new ServicoTo()
                            {
                                Discriminacao = re.Nfe.Emissao.Autorizar.Servico.Discriminacao,
                                Iss_retido = re.Nfe.Emissao.Autorizar.Servico.Iss_retido,
                                Valor_iss = re.Nfe.Emissao.Autorizar.Servico.Valor_iss,
                                Codigo_cnae = re.Nfe.Emissao.Autorizar.Servico.Codigo_cnae,
                                Item_lista_servico = re.Nfe.Emissao.Autorizar.Servico.Item_lista_servico,
                                Valor_servicos = re.Nfe.Emissao.Autorizar.Servico.Valor_servicos
                            }
                        }
                    }
                }
            };
        }
    }
}

