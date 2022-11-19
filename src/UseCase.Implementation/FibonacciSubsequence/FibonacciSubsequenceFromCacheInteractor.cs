using Entity.DTO;
using Entity.DTO.FibonacciSubsequence;
using UseCase.Abstraction.FibonacciSubsequence;
using Repository.Abstraction.FibonacciSubsequence;
using Microsoft.Extensions.Logging;

namespace UseCase.Implementation.FibonacciSubsequence;

public sealed class FibonacciSubsequenceFromCacheInteractor : IFibonacciSubsequenceFromCacheUseCase
{
    private readonly IFibonacciSubsequenceRepository _repository;
    private readonly ILogger<FibonacciSubsequenceFromCacheInteractor> _logger;

    public FibonacciSubsequenceFromCacheInteractor(
        IFibonacciSubsequenceRepository repository,
        ILogger<FibonacciSubsequenceFromCacheInteractor> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    public async Task<Response<FibonacciSubsequenceResponse>> ExecuteAsync(FibonacciSubsequenceRequest request, CancellationToken cancellationToken = default)
    {
        try
        {
            var fibonacciSubsequence = new Entity.Model.FibonacciSubsequence 
            {
                FirstIndex = request.FirstIndex,
                LastIndex = request.LastIndex
            };
            var fibonacciSubsequenceKey = fibonacciSubsequence.GetKey();
            
            fibonacciSubsequence = await _repository.GetFibonacciSubsequenceByIdAsync(fibonacciSubsequenceKey, cancellationToken);
            if(fibonacciSubsequence == null)
            {
                _logger.LogWarning($"Failed to retrive subsequence with key {fibonacciSubsequenceKey}, not found!");
                return Response<FibonacciSubsequenceResponse>.FailedResponse(ErrorCode.NotFound);
            }

            return Response<FibonacciSubsequenceResponse>.SuccessResponse(ErrorCode.Approved, 
                new FibonacciSubsequenceResponse 
                {
                    Subsequence = fibonacciSubsequence.Subsequence
                });
        }
        catch (System.Exception ex)
        {
            _logger.LogError(ex, "Retriving subsequence from cache failed. See exception details for more details.");
            return Response<FibonacciSubsequenceResponse>.FailedResponse(ErrorCode.InternalError);
        }
    }
}