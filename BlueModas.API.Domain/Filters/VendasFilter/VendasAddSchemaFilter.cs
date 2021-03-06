using BlueModas.API.Domain.Entidades;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;

namespace BlueModas.API.Filters.Vendas
{
    public class VendasAddSchemaFilter : ISchemaFilter
    {
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
                schema.Example = GetExampleOrNullFor(context.Type);
        }

        private IOpenApiAny GetExampleOrNullFor(Type type)
        {
            switch (type.Name)
            {
                case "Venda":
                    return new OpenApiObject
                    {
                        ["clienteId"] = new OpenApiString(Guid.NewGuid().ToString()),
                        ["itens"] = new OpenApiObject
                        {
                            ["idProduto"] = new OpenApiInteger(1),
                            ["quantidade"] = new OpenApiFloat(199.99f)
                        }
                        
                    };
                default:
                    return null;
            }
        }
    }
}
