using CrossCuttingConcerns.Util;

namespace Entity.Model;

public class FibonacciSubsequence
{
    public int FirstIndex { get; set; }
    public int LastIndex { get; set; }
    public int[] Subsequence { get; set; }

    private string _key = string.Empty;

    public string GetKey()
    {
        if(!string.IsNullOrEmpty(_key))
            return _key;

        _key = Base64Util.Base64Encode($"{FirstIndex}:{LastIndex}");
        return _key;
    }
}
