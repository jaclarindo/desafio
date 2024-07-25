using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using System.Net;

namespace Domain.Shared;

public class Response<T>
{
    public T Data { get; set; }
    public List<string> Errors { get; set; } = new List<string>();
    public int StatusCode { get; private set; } = 201;

    public Response()
    {
    }

    public Response(T data,  ValidationResult validationResult)
    {
        Data = data;
        AddErrors(validationResult);
        SetStatusCode();
    }

    public void AddErrors(ValidationResult validationResult)
    {
        foreach (var error in validationResult.Errors)
        {
            Errors.Add($"{error.ErrorMessage} - {error.PropertyName} : {error.AttemptedValue}");
        }
    }

    public void SetStatusCode()
    {
        if (HasError())
            StatusCode = (int)HttpStatusCode.BadRequest;
        else
            StatusCode = (int)HttpStatusCode.Created;
    }

    public void SetNotFound()
    {
        StatusCode = (int)HttpStatusCode.NotFound;
    }

    public void SetOk()
    {
        StatusCode = (int)HttpStatusCode.OK;
    }   

    public bool HasError() => Errors.Any();
}
