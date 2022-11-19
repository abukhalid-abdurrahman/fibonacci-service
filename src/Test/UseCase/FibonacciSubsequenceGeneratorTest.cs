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
            var subsequenceList = new List<long>();

            long fibonacciNumberA = 0;
            long fibonacciNumberB = 1;
            for(int i = 2; i < lastIndex + 1; i++)
            {
                var fibonacciNumber = fibonacciNumberA + fibonacciNumberB;
                if(i >= firstIndex && i <= lastIndex)
                    subsequenceList.Add(fibonacciNumber);

                fibonacciNumberA = fibonacciNumberB;
                fibonacciNumberB = fibonacciNumber;
            }

        foreach(var i in subsequenceList)
        {
            Console.WriteLine(i);
        }

        Assert.Pass();
    }
}
