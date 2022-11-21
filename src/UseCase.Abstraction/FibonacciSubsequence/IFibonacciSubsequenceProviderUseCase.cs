using Entity.DTO;
using Entity.DTO.FibonacciSubsequence;

namespace UseCase.Abstraction.FibonacciSubsequence;

public interface IFibonacciSubsequenceProviderUseCase
{
    public Task<Response<FibonacciSubsequenceResponse>> ExecuteAsync(FibonacciSubsequenceRequest request, CancellationToken cancellationToken = default);
}
