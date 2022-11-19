using Entity.Model;

namespace Test.Entity;

[TestFixture]
public sealed class FibonacciSubsequenceTest
{
    [Test]
    [TestCase(1, 6, "MTo2")]
    [TestCase(0, 3, "MDoz")]
    [TestCase(8, 34, "ODozNA==")]
    public void FibonacciSubsequence_GetKey_ShouldReturnEntityKey_Scenario(int firstIndex, int lastIndex, string key)
    {
        var entity = new FibonacciSubsequence() 
        {
            FirstIndex = firstIndex,
            LastIndex = lastIndex
        };
        var entityKey = entity.GetKey();
        Assert.AreEqual(entityKey, key);
    }
}
