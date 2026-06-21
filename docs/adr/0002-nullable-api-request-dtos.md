# ADR 0002: Use nullable API request DTOs for externally supplied values

Status: Accepted  
Date: 2026-06-20

## Context

API request DTOs describe untrusted HTTP input. Before model binding and validation run, values may be missing, malformed, or outside the valid range for the domain model.

For example:

```csharp
public sealed class GetSupplyListByKeyRequest
{
    [Required]
    public string? School { get; init; }

    [Required]
    public string? Grade { get; init; }

    [Required]
    [Range(...)]
    public int? AcademicYear { get; init; }
}
```

The nullable CLR types represent the pre-validation request state. Missing values are possible input, even though they are not valid application data. ASP.NET Core validation rejects invalid Minimal API requests with `400 Bad Request` validation problem details before endpoint code maps them into domain types.

## Decision

API request DTOs should model externally supplied values as nullable when the client can omit them or binding can fail to produce a value. Requiredness and range rules should be expressed with validation attributes such as `[Required]` and `[Range]`.

Endpoint code should convert request DTOs into domain/application types only after ASP.NET Core has successfully bound and validated the request. Mapping helpers should stay scoped to the API boundary, and may use the null-forgiving operator for validation-protected fields:

```csharp
public SupplyListKey ToKey()
{
    return new SupplyListKey(
        new School(School!),
        new Grade(Grade!),
        new AcademicYear(AcademicYear!.Value));
}
```

## Consequences

Request DTO nullability represents the external input boundary, not domain validity. Domain objects and application commands/queries should continue to use non-nullable, validated value objects where possible.

If request mapping is needed outside the validated endpoint flow, introduce explicit validation or a separate validated input type instead of relying on this convention.
