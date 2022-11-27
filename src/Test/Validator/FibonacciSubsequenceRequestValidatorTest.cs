using Entity.DTO.FibonacciSubsequence;
using Entity.Validation;
using FluentValidation.TestHelper;

namespace Test.Validator;

[TestFixture]
public sealed class FibonacciSubsequenceRequestValidatorTest
{
    FibonacciSubsequenceRequestValidator _validator;

    [SetUp]
    public void Setup()
    {
        _validator = new FibonacciSubsequenceRequestValidator();
    }

    [Test]
    [TestCase(1, 100, false, 10)]
    [TestCase(0, 21, true, 1)]
    public void FibonacciSubsequenceRequestValidator_TestValidate_ShouldValidateParamaters_Scenario
        (int firstIndex, int lastIndex, bool retriveFromCache, int timeout)
    {
        var requestModel = new FibonacciSubsequenceRequest
        {
            FirstIndex = firstIndex,
            LastIndex = lastIndex,
            RetriveFromCache = retriveFromCache,
            TimeoutInMilliseconds = timeout
        };

        var result = _validator.TestValidate(requestModel);
        result.ShouldNotHaveAnyValidationErrors();
    }

    [Test]
    [TestCase(1000, 21, false, 0)]
    [TestCase(21, 21, true, 1)]
    public void FibonacciSubsequenceRequestValidator_TestValidate_ShouldFailValidation_Scenario
        (int firstIndex, int lastIndex, bool retriveFromCache, int timeout)
    {
        var requestModel = new FibonacciSubsequenceRequest
        {
            FirstIndex = firstIndex,
            LastIndex = lastIndex,
            RetriveFromCache = retriveFromCache,
            TimeoutInMilliseconds = timeout
        };

        var result = _validator.TestValidate(requestModel);
        result.ShouldHaveAnyValidationError();
    }
}
