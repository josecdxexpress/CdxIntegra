using CDX.NF.Domain.Models.Enum;

namespace CDX.NF.Domain.Models.To.Extensoes
{
    public static class AutorizacaoNfeToExtensoes
    {
        internal static WsMobLinkService.CapaAutorizacaoNfse ToWsAutorizarService(this AutorizacaoNfeTo re, WsSoapServices wsSoapServices)
        {
            if (wsSoapServices == WsSoapServices.MobLink)
            {
                return new WsMobLinkService.CapaAutorizacaoNfse()
                {
                    homologacao = false,
                    identificador_nota = re.Nfe.CapaAutorizacaoNfse.Identificador_nota,
                    autorizar = new WsMobLinkService.Autorizar()
                    {                        
                        data_emissao = re.Nfe.CapaAutorizacaoNfse.Autorizar.Data_emissao,
                        natureza_operacao = re.Nfe.CapaAutorizacaoNfse.Autorizar.Natureza_operacao,
                        optante_simples_nacional = re.Nfe.CapaAutorizacaoNfse.Autorizar.Optante_simples_nacional,
                        prestador = new WsMobLinkService.Prestador()
                        {
                            cnpj = re.Nfe.CapaAutorizacaoNfse.Autorizar.Prestador.Cnpj,
                            inscricao_municipal = re.Nfe.CapaAutorizacaoNfse.Autorizar.Prestador.Inscricao_municipal,
                            codigo_municipio = re.Nfe.CapaAutorizacaoNfse.Autorizar.Prestador.Codigo_municipio
                        },
                        tomador = new WsMobLinkService.Tomador()
                        {
                            cpf = re.Nfe.CapaAutorizacaoNfse.Autorizar.Tomador.Cpf,
                            razao_social = re.Nfe.CapaAutorizacaoNfse.Autorizar.Tomador.Razao_social,
                            telefone = re.Nfe.CapaAutorizacaoNfse.Autorizar.Tomador.Telefone,
                            email = re.Nfe.CapaAutorizacaoNfse.Autorizar.Tomador.Email,
                            endereco = new WsMobLinkService.Endereco()
                            {
                                logradouro = re.Nfe.CapaAutorizacaoNfse.Autorizar.Tomador.Endereco.Logradouro,
                                numero = re.Nfe.CapaAutorizacaoNfse.Autorizar.Tomador.Endereco.Numero,
                                complemento = re.Nfe.CapaAutorizacaoNfse.Autorizar.Tomador.Endereco.Complemento,
                                bairro = re.Nfe.CapaAutorizacaoNfse.Autorizar.Tomador.Endereco.Bairro,
                                uf = re.Nfe.CapaAutorizacaoNfse.Autorizar.Tomador.Endereco.Uf,
                                cep = re.Nfe.CapaAutorizacaoNfse.Autorizar.Tomador.Endereco.Cep
                            }
                        },
                        servico = new WsMobLinkService.Servico()
                        {
                            discriminacao = re.Nfe.CapaAutorizacaoNfse.Autorizar.Servico.Discriminacao,
                            iss_retido = re.Nfe.CapaAutorizacaoNfse.Autorizar.Servico.Iss_retido,
                            valor_iss = re.Nfe.CapaAutorizacaoNfse.Autorizar.Servico.Valor_iss,
                            codigo_cnae = re.Nfe.CapaAutorizacaoNfse.Autorizar.Servico.Codigo_cnae,
                            item_lista_servico = re.Nfe.CapaAutorizacaoNfse.Autorizar.Servico.Item_lista_servico,
                            valor_servicos = re.Nfe.CapaAutorizacaoNfse.Autorizar.Servico.Valor_servicos
                        }
                    }
                };
            }

            return null;
        }

        internal static NotaFiscalSolicitada ToNotaFiscalSolicitada(this AutorizacaoNfeTo re, int usuarioId)
        {
            return new NotaFiscalSolicitada()
            {
                Homologacao = re.Nfe.CapaAutorizacaoNfse.Homologacao,
                Identificador_nota = re.Nfe.CapaAutorizacaoNfse.Identificador_nota,
                UsuarioId = usuarioId,
                Autorizar = new Autorizar()
                {
                    Data_emissao = re.Nfe.CapaAutorizacaoNfse.Autorizar.Data_emissao,
                    Natureza_operacao = re.Nfe.CapaAutorizacaoNfse.Autorizar.Natureza_operacao,
                    Optante_simples_nacional = re.Nfe.CapaAutorizacaoNfse.Autorizar.Optante_simples_nacional,
                    UsuarioId = usuarioId,
                    Prestador = new Prestador()
                    {
                        Cnpj = re.Nfe.CapaAutorizacaoNfse.Autorizar.Prestador.Cnpj,
                        Inscricao_municipal = re.Nfe.CapaAutorizacaoNfse.Autorizar.Prestador.Inscricao_municipal,
                        Codigo_municipio = re.Nfe.CapaAutorizacaoNfse.Autorizar.Prestador.Codigo_municipio,
                        UsuarioId = usuarioId
                    },
                    Tomador = new Tomador()
                    {
                        Cpf = re.Nfe.CapaAutorizacaoNfse.Autorizar.Tomador.Cpf,
                        Razao_social = re.Nfe.CapaAutorizacaoNfse.Autorizar.Tomador.Razao_social,
                        Telefone = re.Nfe.CapaAutorizacaoNfse.Autorizar.Tomador.Telefone,
                        Email = re.Nfe.CapaAutorizacaoNfse.Autorizar.Tomador.Email,
                        UsuarioId = usuarioId,
                        Endereco = new Endereco()
                        {
                            Logradouro = re.Nfe.CapaAutorizacaoNfse.Autorizar.Tomador.Endereco.Logradouro,
                            Numero = re.Nfe.CapaAutorizacaoNfse.Autorizar.Tomador.Endereco.Numero,
                            Complemento = re.Nfe.CapaAutorizacaoNfse.Autorizar.Tomador.Endereco.Complemento,
                            Bairro = re.Nfe.CapaAutorizacaoNfse.Autorizar.Tomador.Endereco.Bairro,
                            Uf = re.Nfe.CapaAutorizacaoNfse.Autorizar.Tomador.Endereco.Uf,
                            Cep = re.Nfe.CapaAutorizacaoNfse.Autorizar.Tomador.Endereco.Cep,
                            UsuarioId = usuarioId
                        }
                    },
                    Servico = new Servico()
                    {
                        Discriminacao = re.Nfe.CapaAutorizacaoNfse.Autorizar.Servico.Discriminacao,
                        Iss_retido = re.Nfe.CapaAutorizacaoNfse.Autorizar.Servico.Iss_retido,
                        Valor_iss = re.Nfe.CapaAutorizacaoNfse.Autorizar.Servico.Valor_iss,
                        Codigo_cnae = re.Nfe.CapaAutorizacaoNfse.Autorizar.Servico.Codigo_cnae,
                        Item_lista_servico = re.Nfe.CapaAutorizacaoNfse.Autorizar.Servico.Item_lista_servico,
                        Valor_servicos = re.Nfe.CapaAutorizacaoNfse.Autorizar.Servico.Valor_servicos,
                        UsuarioId = usuarioId
                    }
                }
            };
        }
    }
}

