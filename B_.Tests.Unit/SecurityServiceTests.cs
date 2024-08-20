using B.Application.SecurityServiceHelper;
using B;
using B.Application.SecuritySevice;
using NSubstitute;
using FluentAssertions;

namespace B_.Tests.Unit;

public sealed class SecurityServiceTests
{
	private readonly SecurityService _service;
    private readonly IIsinProcessHelper _isinProcessHelper;
    private readonly IRepository _repository;

    public SecurityServiceTests()
    {
        this._isinProcessHelper = Substitute.For<IIsinProcessHelper>();
        this._repository = Substitute.For<IRepository>();
        this._service = new(this._isinProcessHelper, this._repository);
    }

    [Theory]
    [InlineData("123456789012345", 10.5)]
	public async Task Should_ProcessIsins_Successfully(string isinCode, decimal isinPrice)
	{
        // Arrange
        var isin = Isin.Create(isinCode);
        var security = new Security { Isin = isin.Value };
        var securityList = new List<Security> { security };

        this._isinProcessHelper.GetIsinPrice(isin.Value).Returns(isinPrice);
        this._repository.Save(security).Returns(true);

        // Act
        var result = await this._service.ProcessIsinsAsync(securityList);

		// Assert
        result.Should().BeTrue();
	}
}
