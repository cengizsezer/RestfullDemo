using Google.Protobuf;

public class ResponseService
{
    //public static Response ResponseSender(ResultCodes resultCodes, ByteString responseMessage)
    //{
    //    if (responseMessage == null)
    //    {
    //        responseMessage = ByteString.Empty;
    //    }

    //    ResponseProto.Response.Builder response = ResponseProto.Response.CreateBuilder();
    //    response.SetResultCode(resultCodes);
    //    response.SetData(responseMessage);
    //    response.SetServerTime(DateTimeOffset.UtcNow.ToUnixTimeMilliseconds());

    //    return response.Build();
    //}
}
//namespace RestfullDemo.Response
//{
//    public class ResponseService
//    {
//        public static Response ResponseSender(ResultCodes resultCodes, ByteString responseMessage)
//        {
//            if (responseMessage == null)
//            {
//                responseMessage = ByteString.Empty;
//            }

//            ResponseProto.Response.Builder response = ResponseProto.Response.CreateBuilder();
//            response.SetResultCode(resultCodes);
//            response.SetData(responseMessage);
//            response.SetServerTime(DateTimeOffset.UtcNow.ToUnixTimeMilliseconds());

//            return response.Build();
//        }
//    }
//}
