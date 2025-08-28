using FluentResults;

namespace MinimalAPI.Application.Errors
{
    public class DeleteFailedError(string message) : Error(message)
    {
    }
}
