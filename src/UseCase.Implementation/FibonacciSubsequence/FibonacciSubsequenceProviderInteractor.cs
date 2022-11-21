using Entity.DTO;
using Entity.DTO.FibonacciSubsequence;
using UseCase.Abstraction.FibonacciSubsequence;

namespace UseCase.Implementation.FibonacciSubsequence;

public sealed class FibonacciSubsequenceProviderInteractor : IFibonacciSubsequenceProviderUseCase
{
    private readonly IFibonacciSubsequenceGeneratorUseCase _fibonacciSubsequenceGeneratorUseCase;
    private readonly IFibonacciSubsequenceFromCacheUseCase _fibonacciSubsequenceFromCacheUseCase;

    public FibonacciSubsequenceProviderInteractor(
        IFibonacciSubsequenceGeneratorUseCase fibonacciSubsequenceGeneratorUseCase,
        IFibonacciSubsequenceFromCacheUseCase fibonacciSubsequenceFromCacheUseCase)
    {
        _fibonacciSubsequenceGeneratorUseCase = fibonacciSubsequenceGeneratorUseCase;
        _fibonacciSubsequenceFromCacheUseCase = fibonacciSubsequenceFromCacheUseCase;
    }

    public Task<Response<FibonacciSubsequenceResponse>> ExecuteAsync(FibonacciSubsequenceRequest request, CancellationToken cancellationToken = default)
    {
        if(request.RetriveFromCache)
            return _fibonacciSubsequenceFromCacheUseCase.ExecuteAsync(request, cancellationToken);
        else
            return _fibonacciSubsequenceGeneratorUseCase.ExecuteAsync(request, cancellationToken);
    }
}
