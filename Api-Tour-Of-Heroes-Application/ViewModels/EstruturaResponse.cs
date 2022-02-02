using System.Net;

namespace Api_Tour_Of_Heroes_Application.ViewModels
{
    public class EstruturaResponse
    {
        public HttpStatusCode StatusCode { get; private set; }
        public bool Success { get; private set; }
        public object? Data { get; private set; }
        public IEnumerable<string>? Erros { get; private set; }
              
        public EstruturaResponse(HttpStatusCode statusCode, bool success)
        {
            StatusCode = statusCode;
            Success = success;
        }

        public EstruturaResponse(HttpStatusCode statusCode, bool success, object data) : this(statusCode, success)
        {
            Data = data;
        }

        public EstruturaResponse(HttpStatusCode statusCode, bool success, IEnumerable<string> erros) : this(statusCode, success)
        {
            Erros = erros;
        }

        public EstruturaResponse(HttpStatusCode statusCode, bool success, object data, IEnumerable<string> erros) : this(statusCode, success, data)
        {
            Erros = erros;
        }
    }
}
