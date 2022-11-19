namespace Entity.Model;

public class FibonacciSubsequence
{
    public FibonacciSubsequence(int firstIndex, int lastIndex, int[] subsequence)
    {
        Subsequence = subsequence;
        Id = Base64Util.Base64Encode($"{firstIndex}:{lastIndex}");
    }
    
    public string Id { get; private set; }
    public int[] Subsequence { get; set; }
}
