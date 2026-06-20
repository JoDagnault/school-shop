# ADR 0001: Use strict JSON number handling

Status: Accepted  
Date: 2026-06-19

## Context

The API uses `Microsoft.AspNetCore.OpenApi` to generate an OpenAPI 3.1 document, and Swagger UI to browse that document locally.

By default, ASP.NET allows JSON numbers to be read from strings. Because of that, the Microsoft OpenAPI generator can describe numeric values as both numbers and strings:

```json
{
  "type": ["integer", "string"],
  "format": "int32"
}
```

Swagger UI 5.x does not fully support OpenAPI 3.1 / JSON Schema 2020-12 parameter validation for this shape. In practice, a required numeric query parameter can show as `integer | string` and still fail validation with "Required field is not provided" after entering a value like `2026`.

## Decision

Configure HTTP JSON number handling as strict:

```csharp
builder.Services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.NumberHandling = JsonNumberHandling.Strict;
});
```

This keeps generated numeric schemas as plain numeric OpenAPI types, such as `type: "integer"`, which Swagger UI handles correctly.

## Consequences

JSON request bodies must send numbers as JSON numbers, not quoted strings.

This avoids custom OpenAPI rewriting and keeps the API contract stricter. Revisit this if Swagger UI fully supports OpenAPI 3.1 parameter validation for `type` arrays, or if ASP.NET changes the generated schema behavior.

## References

- ASP.NET Core issue for `AddOpenApi()` generating `type: ["integer", "string"]`: https://github.com/dotnet/aspnetcore/issues/65243
- Swagger UI issue for OpenAPI 3.1 parameter validation using JSON Schema 2020-12: https://github.com/swagger-api/swagger-ui/issues/9134
