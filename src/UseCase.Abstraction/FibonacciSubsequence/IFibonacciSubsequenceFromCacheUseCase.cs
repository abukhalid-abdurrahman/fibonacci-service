using System.Threading.Tasks;

namespace UseCase.Abstraction.FibonacciSubsequence;

public interface IFibonacciSubsequenceFromCacheUseCase
{
    public Task<FibonacciSubsequenceResponse> ExecuteAsync(FibonacciSubsequenceRequest request);
}