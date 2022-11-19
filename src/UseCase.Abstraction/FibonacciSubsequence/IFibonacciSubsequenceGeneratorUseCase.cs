using System.Threading.Tasks;

namespace UseCase.Abstraction.FibonacciSubsequence;

public interface IFibonacciSubsequenceGeneratorUseCase
{
    public Task<FibonacciSubsequenceResponse> ExecuteAsync(FibonacciSubsequenceRequest request);
}