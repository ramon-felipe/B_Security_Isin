using CSharpFunctionalExtensions;
using System.Runtime.CompilerServices;
using System.Transactions;

namespace B;

public sealed class Isin : ValueObject
{
    public const int IsinSize = 15;
    public string Code { get; private set; }

    private Isin(string isinCode)
    {
        this.Code = isinCode;
    }

    public static Result<Isin> Create(string isin)
    {
        if (string.IsNullOrWhiteSpace(isin))
            return Result.Failure<Isin>("Isin cant be null or whitespace");

        if (isin.Length != IsinSize)
            return Result.Failure<Isin>($"Isin size must be: {IsinSize}");

        return Result.Success(new Isin(isin));
    }

    protected override IEnumerable<IComparable> GetEqualityComponents()
    {
        yield return this.Code;
    }
}
    