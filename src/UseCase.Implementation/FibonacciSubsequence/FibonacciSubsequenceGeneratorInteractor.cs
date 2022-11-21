using Entity.Model;
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
            var subsequenceList = new List<BigInteger>();

            var generatorTask = new Task(() => {
                BigInteger fibonacciNumberA = 0;
                BigInteger fibonacciNumberB = 1;
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

            await generatorTask.WaitAsync(TimeSpan.FromSeconds(request.TimeoutInSeconds), cancellationToken);

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

            return Response<FibonacciSubsequenceResponse>.SuccessResponse(ErrorCode.Approved, 
                new FibonacciSubsequenceResponse 
                {
                    Subsequence = subsequenceArray
                });
        }
        catch (System.Exception ex)
        {
            _logger.LogError(ex, "Failed subsequence generation. See exception details for more details.");
            return Response<FibonacciSubsequenceResponse>.FailedResponse(ErrorCode.InternalError);
        }
    }
}