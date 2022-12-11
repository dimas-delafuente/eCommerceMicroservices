using Common.Primitives.Domain.ValueObjects;

namespace Orders.Application.Services;

public interface IEmailService
{
    Task<bool> SendEmail(Email email);
}
