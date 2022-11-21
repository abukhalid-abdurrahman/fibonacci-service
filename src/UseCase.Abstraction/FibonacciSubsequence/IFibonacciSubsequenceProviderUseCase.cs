using Entity.DTO;
using Entity.DTO.FibonacciSubsequence;

namespace UseCase.Abstraction.FibonacciSubsequence;

public interface IFibonacciSubsequenceProviderUseCase
{
    /// <summary>
    /// Provides Fibonacci-Subsequence by RetriveFromCache field from request. If a value true - gets from cache, otherwise generates a subsequence.
    /// </summary>
    public Task<Response<FibonacciSubsequenceResponse>> ExecuteAsync(FibonacciSubsequenceRequest request, CancellationToken cancellationToken = default);
}
