using CrossCuttingConcerns.Util;

namespace Test;

[TestFixture]
public sealed class Base64UtilTest
{
    [Test]
    [TestCase("Computer", "Q29tcHV0ZXI=")]
    [TestCase("Encoding", "RW5jb2Rpbmc=")]
    [TestCase("Fibonacci", "Rmlib25hY2Np")]
    [TestCase("Subsequence", "U3Vic2VxdWVuY2U=")]
    public void Base64Util_Base64Encode_ShouldEncodeStringToBase64_Scenario(string plain, string base64)
    {
        var encoded = Base64Util.Base64Encode(plain);
        Assert.AreEqual(encoded, base64);
    }

    [Test]
    [TestCase("Computer", "Q29tcHV0ZXI=")]
    [TestCase("Encoding", "RW5jb2Rpbmc=")]
    [TestCase("Fibonacci", "Rmlib25hY2Np")]
    [TestCase("Subsequence", "U3Vic2VxdWVuY2U=")]
    public void Base64Util_Base64Decode_ShouldDecodeFromBase64_Scenario(string plain, string base64)
    {
        var decoded = Base64Util.Base64Decode(base64);
        Assert.AreEqual(decoded, plain);
    }

    [Test]
    [TestCase("Computer")]
    [TestCase("Encoding")]
    [TestCase("Fibonacci")]
    [TestCase("Subsequence")]
    public void Base64Util_Base64Decode_ShouldEncodeAndDecodeFromBase64_Scenario(string plain)
    {
        var encoded = Base64Util.Base64Encode(plain);
        var decoded = Base64Util.Base64Decode(encoded);
        Assert.AreEqual(decoded, plain);
    }
}