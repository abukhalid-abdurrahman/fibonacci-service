namespace Entity.DTO.FibonacciSubsequence;

public sealed class FibonacciSubsequenceRequest
{
    public int FirstIndex { get; set; }
    public int LastIndex { get; set; }
    public int TimeoutInSeconds { get; set; }
    public bool RetriveFromCache { get; set; }
}