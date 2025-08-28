using FluentResults;

namespace MinimalAPI.Application.Errors
{
    public class NotFoundError(string message) : Error(message)
    {
    }
}
