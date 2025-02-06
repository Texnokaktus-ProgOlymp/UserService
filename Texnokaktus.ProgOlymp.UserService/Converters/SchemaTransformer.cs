using Microsoft.AspNetCore.OpenApi;
using Microsoft.OpenApi.Models;

namespace Texnokaktus.ProgOlymp.UserService.Converters;

public class SchemaTransformer : IOpenApiSchemaTransformer
{
    public Task TransformAsync(OpenApiSchema schema, OpenApiSchemaTransformerContext context, CancellationToken cancellationToken)
    {
        if (context.JsonTypeInfo.Type.IsEnum)
        {
            schema.Type = "string";
        }

        return Task.CompletedTask;
    }
}
