using FluentResults;

namespace MinimalAPI.Application.Errors
{
    public class ValidationError(string message) : Error(message)
    {
    }
}
