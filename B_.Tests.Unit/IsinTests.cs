using B;
using FluentAssertions;

namespace B_.Tests.Unit;

public sealed class IsinTests
{

	[Theory]
	[InlineData("123456789012345")]
	public void Should_CreateIsin_Successfully(string isinCode)
	{
		// Act
		var isin = Isin.Create(isinCode);

		// Assert
		isin.Should().Succeed();
		var result = isin.Value;

		result.Code.Should().Be(isinCode);
	}

	[Theory]
	[InlineData("abc")]
	public void Should_NotCreateIsin_When_IsinCodeIsInvalid(string isinCode)
	{
        // Act
        var isin = Isin.Create(isinCode);

		// Assert
		isin.Should().FailWith($"Isin size must be: {Isin.IsinSize}");
    }
}
