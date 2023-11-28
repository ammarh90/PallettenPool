﻿namespace SendGridAPI.Models.Response;

public class ApiResponse<T>
{
    public bool Success { get; set; }
    public T Payload { get; set; }
}