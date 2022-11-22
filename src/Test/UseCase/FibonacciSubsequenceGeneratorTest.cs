using UseCase.Implementation.FibonacciSubsequence;

namespace Test.UseCase;

[TestFixture]
public sealed class FibonacciSubsequenceGeneratorTest
{
    [Test]
    [TestCase(20, 55)]
    // [TestCase(5, 21)]
    // [TestCase(15, 40)]
    // [TestCase(20, 55)]
    public void Generator_ExecuteAsync_ShouldGenerateSubsequenceSuccessfully_Scenario(int firstIndex, int lastIndex)
    {
        Assert.Pass();
    }
}
