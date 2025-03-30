namespace Jira.Application.Common.Exceptions;

public class NotFoundException : Exception
{
    public NotFoundException(string name, object key) 
        : base($"The entity: \"{name}\" ({key}) not found.") {}
}