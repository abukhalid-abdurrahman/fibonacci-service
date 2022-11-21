using Entity.DTO;
using Entity.DTO.FibonacciSubsequence;

namespace UseCase.Abstraction.FibonacciSubsequence;

public interface IFibonacciSubsequenceFromCacheUseCase
{
    /// <summary>
    /// Returns Fibonacci-Subsequence from a cache storage.
    /// </summary>
    public Task<Response<FibonacciSubsequenceResponse>> ExecuteAsync(FibonacciSubsequenceRequest request, CancellationToken cancellationToken = default);
}