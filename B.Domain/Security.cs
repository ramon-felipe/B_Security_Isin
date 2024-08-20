namespace B;

public sealed class Security
{
    public Isin? Isin { get; set; }
    public decimal IsinPrice { get; set; }

    public Security ChangePrice(decimal price)
    {
        if (price == 0)
            throw new ArgumentException("invalid price");

        this.IsinPrice = price;
        return this;
    }
}
