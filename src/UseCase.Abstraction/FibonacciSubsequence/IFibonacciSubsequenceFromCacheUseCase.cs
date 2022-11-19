using Entity.DTO.FibonacciSubsequence;

namespace UseCase.Abstraction.FibonacciSubsequence;

public interface IFibonacciSubsequenceFromCacheUseCase
{
    public Task<FibonacciSubsequenceResponse> ExecuteAsync(FibonacciSubsequenceRequest request);
}