using Entity.DTO;
using Entity.DTO.FibonacciSubsequence;

namespace UseCase.Abstraction.FibonacciSubsequence;

public interface IFibonacciSubsequenceGeneratorUseCase
{
    /// <summary>
    /// Generates a Fibonacci-Subsequence from a input request, saves it into a cache storage, and returns a result.
    /// </summary>
    public Task<Response<FibonacciSubsequenceResponse>> ExecuteAsync(FibonacciSubsequenceRequest request, CancellationToken cancellationToken = default);
}