using B.Application.SecurityServiceHelper;

namespace B.Application.SecuritySevice;

public sealed class SecurityService : ISecurityService
{
    private readonly IIsinProcessHelper _isinProcessHelper;
    private readonly IRepository _repository;

    public SecurityService(IIsinProcessHelper isinProcessHelper, IRepository repository)
    {
        _isinProcessHelper = isinProcessHelper;
        _repository = repository;
    }

    public async Task<bool> ProcessIsinsAsync(IEnumerable<Security> securityList)
    {
        if (!securityList.Any())
        {
            throw new ArgumentException("security list is empty");
        }

        foreach (var security in securityList)
        {
            await this.GetsIsinPriceAndSaveAsync(security);
        }

        return true;
    }

    private async Task GetsIsinPriceAndSaveAsync(Security security)
    {
        if (security?.Isin is null)
            return;

        var isinPrice = await _isinProcessHelper.GetIsinPrice(security.Isin);
        security.ChangePrice(isinPrice);

        _repository.Save(security);
    }
}