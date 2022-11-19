using Microsoft.Extensions.Logging;
using Entity.Configs;
using Repository.Abstraction.FibonacciSubsequence;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace Repository.Implementation.FibonacciSubsequence;

public sealed class FibonacciSubsequenceRepository : IFibonacciSubsequenceRepository
{
    private readonly IDistributedCache _distributedCache;
    private readonly ILogger<FibonacciSubsequenceRepository> _logger;
    private readonly DistributedCacheOption _distributedCacheOption;

    public FibonacciSubsequenceRepository(
        IDistributedCache distributedCache,
        ILogger<FibonacciSubsequenceRepository> logger,
        DistributedCacheOption distributedCacheOption)
    {
        _distributedCache = distributedCache;
        _logger = logger;
        _distributedCacheOption = distributedCacheOption;
    }

    public async Task<Entity.Model.FibonacciSubsequence?> GetFibonacciSubsequenceByIdAsync(string subsequenceKey, CancellationToken cancellationToken = default)
    {
        try
        {
            var entityBytes = await _distributedCache.GetAsync(subsequenceKey, cancellationToken);
            if(entityBytes?.Length == 0)
            {
                _logger.LogWarning($"Record with key {subsequenceKey} returns empty bytes array.");
                return null;
            }

            var entityContent = System.Text.Encoding.UTF8.GetString(entityBytes);
            var entity = JsonConvert
                .DeserializeObject<Entity.Model.FibonacciSubsequence?>(entityContent);

            return entity;
        }
        catch (System.Exception ex)
        {
            _logger.LogError(ex, $"Getting record with id {subsequenceKey}, failed. See exception details for more detail.");   
            return null;
        }
    }

    public async Task<bool> InsertFibonacciSubsequenceAsync(Entity.Model.FibonacciSubsequence entity, CancellationToken cancellationToken = default)
    {
        try 
        {
            var recordKey = entity.GetKey();
            var recordValueContent = JsonConvert.SerializeObject(entity);
            var recordValueBytes = System.Text.Encoding.UTF8.GetBytes(recordValueContent);

            await _distributedCache.SetAsync(recordKey, recordValueBytes, new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(_distributedCacheOption.RecordExpirationInSeconds)
            }, cancellationToken);

            _logger.LogInformation($"Setting/inserting record with key {recordKey}, first and last indicies {entity.FirstIndex}:{entity.LastIndex} into distributed cache completed.");

            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to set/insert record into distributed cache. See exception message to get more detail.");
            return false;
        }
    }
}
