using Entity.DTO.FibonacciSubsequence;

namespace UseCase.Abstraction.FibonacciSubsequence;

public interface IFibonacciSubsequenceGeneratorUseCase
{
    public Task<FibonacciSubsequenceResponse> ExecuteAsync(FibonacciSubsequenceRequest request);
}