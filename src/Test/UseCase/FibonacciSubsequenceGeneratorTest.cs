using Moq;
using Repository.Abstraction.FibonacciSubsequence;
using Microsoft.Extensions.Logging;
using Entity.Model;
using UseCase.Abstraction.FibonacciSubsequence;
using Entity.DTO.FibonacciSubsequence;
using Entity.DTO;

namespace Test.UseCase;

[TestFixture]
public sealed class FibonacciSubsequenceGeneratorTest
{
    Mock<IFibonacciSubsequenceRepository> _repository;
    ILogger<FibonacciSubsequenceGeneratorInteractor> _logger;

    [SetUp]
    public void Setup()
    {
        _repository = new Mock<IFibonacciSubsequenceRepository>();
        _logger = Mock.Of<ILogger<FibonacciSubsequenceGeneratorInteractor>>();
    }

    [Test]
    [TestCase(20, 55, 10)]
    [TestCase(5, 21, 10)]
    [TestCase(15, 40, 10)]
    public async Task Generator_ExecuteAsync_ShouldGenerateSubsequenceSuccessfully_Scenario
        (int firstIndex, int lastIndex, int timeout)
    {
        // Creating mock repository and set it behavior
        _repository
            .Setup(x => x.InsertFibonacciSubsequenceAsync(
                It.IsAny<FibonacciSubsequence>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(true);

        // Creating generator interactor
        var generatorUseCase = new FibonacciSubsequenceGeneratorInteractor(
            _repository.Object,
            _logger);
        var generatorResponse = await generatorUseCase.ExecuteAsync(
            new FibonacciSubsequenceRequest() {
                FirstIndex = firstIndex,
                LastIndex = lastIndex,
                TimeoutInMilliseconds = timeout
            },
            CancellationToken.None
        );

        // Checking code
        Assert.AreEqual(generatorResponse.Code, ErrorCode.Approved);
    }
}
