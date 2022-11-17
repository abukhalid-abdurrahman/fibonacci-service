namespace Entity.DTO;

public sealed class Response<T>
{
    public ErrorCode Code { get; set; }
    public string Message { get; set; }
    public T Payload { get; set; }

    public static Response<T> FailedResponse(ErrorCode code) =>
        new Response<T>() 
        {
            Code = code,
            Message = code.GetDescription(),
            Payload = default
        };
    
    public static Response<T> SuccessResponse(ErrorCode code, T payload) =>
        new Response<T>() 
        {
            Code = code,
            Message = code.GetDescription(),
            Payload = payload
        };
}
