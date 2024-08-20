namespace B.Application.SecuritySevice;

public interface ISecurityService
{
    Task<bool> ProcessIsinsAsync(IEnumerable<Security> securityList);
}
