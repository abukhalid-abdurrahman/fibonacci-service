using Entity.DTO;
using Entity.DTO.FibonacciSubsequence;
using UseCase.Abstraction.FibonacciSubsequence;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FibonacciController : ControllerBase
{
    private readonly IFibonacciSubsequenceProviderUseCase _fibonacciSubsequenceProviderUseCase;

    public FibonacciController(
        IFibonacciSubsequenceProviderUseCase fibonacciSubsequenceProviderUseCase)
    {
        _fibonacciSubsequenceProviderUseCase = fibonacciSubsequenceProviderUseCase;
    }

    [HttpGet("Subsequence")]
    public async Task<Response<FibonacciSubsequenceResponse>> GetFibonacciSubsequenceAsync(
        [FromQuery] FibonacciSubsequenceRequest request, CancellationToken cancellationToken)
    {
        return await _fibonacciSubsequenceProviderUseCase.ExecuteAsync(request, cancellationToken);
    }
}
