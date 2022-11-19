using System.Threading.Tasks;

namespace Repository.Abstraction.FibonacciSubsequence;

public interface IFibonacciSubsequenceRepository
{
    public Task<FibonacciSubsequence> GetFibonacciSubsequenceByIdAsync(string subsequenceId);
    public Task<bool> InsertFibonacciSubsequenceAsync(string subsequenceId);
}