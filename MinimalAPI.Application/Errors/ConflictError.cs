using FluentResults;

namespace MinimalAPI.Application.Errors
{
    public class ConflictError(string message) : Error(message)
    {
    }
}
