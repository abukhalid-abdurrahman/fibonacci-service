using Entity.DTO.FibonacciSubsequence;
using UseCase.Abstraction.FibonacciSubsequence;

namespace UseCase.Implementation.FibonacciSubsequence;

public sealed class FibonacciSubsequenceFromCacheInteractor : IFibonacciSubsequenceFromCacheUseCase
{
    public async Task<FibonacciSubsequenceResponse> ExecuteAsync(FibonacciSubsequenceRequest request)
    {
        
    }
}