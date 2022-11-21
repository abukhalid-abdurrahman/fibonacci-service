using System.Numerics;
using Entity.DTO;
using Entity.DTO.FibonacciSubsequence;
using Microsoft.Extensions.Logging;
using Repository.Abstraction.FibonacciSubsequence;

namespace UseCase.Abstraction.FibonacciSubsequence;

public sealed class FibonacciSubsequenceGeneratorInteractor : IFibonacciSubsequenceGeneratorUseCase
{
    private readonly IFibonacciSubsequenceRepository _fibonacciSubsequenceRepository;
    private readonly ILogger<FibonacciSubsequenceGeneratorInteractor> _logger;

    public FibonacciSubsequenceGeneratorInteractor(
        IFibonacciSubsequenceRepository fibonacciSubsequenceRepository,
        ILogger<FibonacciSubsequenceGeneratorInteractor> logger)
    {
        _fibonacciSubsequenceRepository = fibonacciSubsequenceRepository;
        _logger = logger;
    }

    public async Task<Response<FibonacciSubsequenceResponse>> ExecuteAsync(FibonacciSubsequenceRequest request, CancellationToken cancellationToken = default)
    {
        try
        {
            var responseMessage = string.Empty;
            var subsequenceList = new List<BigInteger>();

            var generatorTask = new Task(() => {
                BigInteger fibonacciNumberA = 0;
                BigInteger fibonacciNumberB = 1;
        
                subsequenceList.Add(fibonacciNumberA);
                subsequenceList.Add(fibonacciNumberB);

                for(int i = 2; i < request.LastIndex + 1; i++)
                {
                    var fibonacciNumber = fibonacciNumberA + fibonacciNumberB;

                    if(i >= request.FirstIndex && i <= request.LastIndex)
                        subsequenceList.Add(fibonacciNumber);

                    fibonacciNumberA = fibonacciNumberB;
                    fibonacciNumberB = fibonacciNumber;
                }
            }, cancellationToken);
            generatorTask.Start();

            _logger.LogInformation($"Async task for generation fibonacci-subsequence from {request.FirstIndex} to {request.LastIndex} started.");

            var isGenerationCompleted = generatorTask.Wait(TimeSpan.FromMilliseconds(request.TimeoutInMilliseconds), cancellationToken);
            if(!isGenerationCompleted) 
                responseMessage = "Generation cancelled, because spicified timeout.";
            
            var subsequenceArray = subsequenceList
                .Select(bi => bi.ToString())
                .ToArray();

            var fibonacciSubsequenceEntity = new Entity.Model.FibonacciSubsequence() 
            {
                FirstIndex = request.FirstIndex,
                LastIndex = request.LastIndex,
                Subsequence = subsequenceArray
            };

            var insertionResult = await _fibonacciSubsequenceRepository.InsertFibonacciSubsequenceAsync(fibonacciSubsequenceEntity);
            if(!insertionResult)
                return Response<FibonacciSubsequenceResponse>.FailedResponse(ErrorCode.InternalError, "Subsequence insertion failed.");

            _logger.LogInformation($"Generation of fibonacci-subsequence from {request.FirstIndex} to {request.LastIndex} finished, inserted into storage, and ready to response.");

            return Response<FibonacciSubsequenceResponse>.SuccessResponse(ErrorCode.Approved, 
                new FibonacciSubsequenceResponse 
                {
                    Subsequence = subsequenceArray
                }, responseMessage);
        }
        catch (System.Exception ex)
        {
            _logger.LogError(ex, "Failed subsequence generation. See exception details for more details.");
            return Response<FibonacciSubsequenceResponse>.FailedResponse(ErrorCode.InternalError);
        }
    }
}