namespace B.Application.SecurityServiceHelper;

public interface IIsinProcessHelper
{
    Task<decimal> GetIsinPrice(Isin isin);
}
