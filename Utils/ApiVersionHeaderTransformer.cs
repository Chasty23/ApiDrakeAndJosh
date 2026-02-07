using Microsoft.AspNetCore.OpenApi;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;

public class ApiVersionHeaderTransformer : IOpenApiDocumentTransformer
{
    public Task TransformAsync(OpenApiDocument document, OpenApiDocumentTransformerContext context, CancellationToken cancellationToken)
    {
        foreach (var path in document.Paths.Values)
        {
            foreach (var operation in path.Operations.Values)
            {

                var existingParam = operation.Parameters
                    .FirstOrDefault(p => p.Name.Equals("X-Version", StringComparison.OrdinalIgnoreCase));

                if (existingParam != null)
                {
                    operation.Parameters.Remove(existingParam);
                }

                // 2. Agregamos nuestra versión limpia y configurada
                operation.Parameters.Add(new OpenApiParameter
                {
                    Name = "X-Version",
                    In = ParameterLocation.Header,
                    Required = true, // Cámbialo a true si quieres que Scalar te obligue a ponerlo
                    Schema = new OpenApiSchema
                    {
                        Type = "string",
                        Default = new OpenApiString("1.0")
                    },
                    Description = "Versión de la API"
                });
            }
        }
        return Task.CompletedTask;
    }
}