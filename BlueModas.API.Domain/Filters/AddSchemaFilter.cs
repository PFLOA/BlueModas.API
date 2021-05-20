using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;

namespace BlueModas.API.Domain.Filters
{
    public class AddSchemaFilter : ISchemaFilter
    {
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            schema.Example = GetExampleOrNullFor(context.Type);
        }

        private IOpenApiAny GetExampleOrNullFor(Type type)
        {
            switch (type.Name)
            {
                case "Cliente":
                    return new OpenApiObject
                    {
                        ["name"] = new OpenApiString("Vanessa Santos Gonçalves"),
                        ["userName"] = new OpenApiString("vanessa"),
                        ["password"] = new OpenApiString("Mudar@123"),
                        ["email"] = new OpenApiString("vanessa@email.com.br"),
                        ["telefones"] = new OpenApiArray
                        {
                            new OpenApiObject
                            {
                                ["numero"] = new OpenApiString("1133256548"),
                                ["tipoTelefone"] = new OpenApiString("Residencial")
                            },
                            new OpenApiObject
                            {
                                ["numero"] = new OpenApiString("11933256548"),
                                ["tipoTelefone"] = new OpenApiString("Celular")
                            }
                        },
                        ["enderecos"] = new OpenApiArray
                        {
                            new OpenApiObject
                            {
                                ["rua"] = new OpenApiString("Rua da Sé"),
                                ["numero"] = new OpenApiString("3"),
                                ["complemento"] = new OpenApiString("Esquina"),
                                ["bairro"] = new OpenApiString("Centro"),
                                ["cep"] = new OpenApiString("01124100"),
                                ["cidade"] = new OpenApiString("São Paulo"),
                                ["estado"] = new OpenApiString("SP"),
                                ["observacoes"] = new OpenApiString("Entregar para Julia"),
                                ["tipoEndereco"] = new OpenApiString("Entrega")
                            }
                        }
                    };
                case "Login":
                    return new OpenApiObject
                    {
                        ["userName"] = new OpenApiString("vanessa"),
                        ["password"] = new OpenApiString("Mudar@123")
                    };
                case "Produto":
                    return new OpenApiObject
                    {
                        ["nome"] = new OpenApiString("Prancha de Surf"),
                        ["preco"] = new OpenApiFloat(199.99f),
                        ["categoriaId"] = new OpenApiInteger(1),
                        ["descricao"] = new OpenApiString("Item especial para você que adora pegar onda."),
                        ["imagem"] = new OpenApiString("urlImagem"),
                    };
                case "Venda":
                    return new OpenApiObject
                    {
                        ["clienteId"] = new OpenApiString(Guid.NewGuid().ToString()),
                        ["itens"] = new OpenApiArray
                        {
                            new OpenApiObject
                            {
                                ["idProduto"] = new OpenApiInteger(1),
                                ["quantidade"] = new OpenApiFloat(199.99f),
                                ["produto"] = new OpenApiObject {
                                    ["nome"]= new OpenApiString("Prancha de Surf"),
                                    ["preco"]= new OpenApiFloat(199.99f),
                                    ["categoriaId"]= new OpenApiInteger(1),
                                    ["descricao"] = new OpenApiString("Prancha de Surf")
                                },
                            }
                        }

                    };
                case "Users":
                    return new OpenApiObject
                    {
                        ["name"] = new OpenApiString("Vanessa Santos Gonçalves"),
                        ["userName"] = new OpenApiString("vanessa"),
                        ["password"] = new OpenApiString("Mudar@123"),
                        ["email"] = new OpenApiString("vanessa@email.com.br"),
                        ["nivelAcesso"] = new OpenApiString("Administrador")
                    };
                case "Categorias":
                    return new OpenApiObject
                    {
                        ["nome"] = new OpenApiString("Esporte")
                    };
                default:
                    return null;
            }
        }
    }
}
