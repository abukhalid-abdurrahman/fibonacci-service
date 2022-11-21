namespace Repository.Abstraction.FibonacciSubsequence;

public interface IFibonacciSubsequenceRepository
{
    /// <summary>
    /// Returns a fibonacci subsequence that stores in a storage, by specified key.
    /// </summary>
    public Task<Entity.Model.FibonacciSubsequence?> GetFibonacciSubsequenceByIdAsync(string subsequenceKey, CancellationToken cancellationToken = default);
        
    /// <summary>
    /// Inserts fibonacci subsequence into a storage.
    /// </summary>
    public Task<bool> InsertFibonacciSubsequenceAsync(Entity.Model.FibonacciSubsequence entity, CancellationToken cancellationToken = default);
}