using CrossCuttingConcerns.Extension;

namespace Entity.DTO;

public sealed class Response<T>
{
    public ErrorCode Code { get; set; }
    public string? Message { get; set; }
    public T? Payload { get; set; }

    public static Response<T> FailedResponse(ErrorCode code, string message = null) =>
        new Response<T>() 
        {
            Code = code,
            Message = message ?? code.GetDescription(),
            Payload = default
        };
    
    public static Response<T> SuccessResponse(ErrorCode code, T payload, string message = null) =>
        new Response<T>() 
        {
            Code = code,
            Message = message ?? code.GetDescription(),
            Payload = payload
        };
}
