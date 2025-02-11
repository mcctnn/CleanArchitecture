﻿using System.Text.Json.Serialization;

namespace CleanArchitecture.Domain.Dtos;

public sealed class ErrorResponseDto
{
    [JsonPropertyName("error")]
    public string Field { get; set; } = default!;
    [JsonPropertyName("errorMessage")]
    public string ErrorMessage { get; set; }=default!;
}