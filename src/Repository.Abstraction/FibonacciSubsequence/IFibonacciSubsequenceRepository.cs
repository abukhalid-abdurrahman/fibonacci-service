namespace Repository.Abstraction.FibonacciSubsequence;

public interface IFibonacciSubsequenceRepository
{
    public Task<Entity.Model.FibonacciSubsequence?> GetFibonacciSubsequenceByIdAsync(string subsequenceKey, CancellationToken cancellationToken = default);
    public Task<bool> InsertFibonacciSubsequenceAsync(Entity.Model.FibonacciSubsequence entity, CancellationToken cancellationToken = default);
}