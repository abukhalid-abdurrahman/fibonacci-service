using Entity.DTO.FibonacciSubsequence;
using UseCase.Abstraction.FibonacciSubsequence;

namespace UseCase.Abstraction.FibonacciSubsequence;

public sealed class FibonacciSubsequenceGeneratorInteractor : IFibonacciSubsequenceGeneratorUseCase
{
    public async Task<FibonacciSubsequenceResponse> ExecuteAsync(FibonacciSubsequenceRequest request)
    {
        
    }
}