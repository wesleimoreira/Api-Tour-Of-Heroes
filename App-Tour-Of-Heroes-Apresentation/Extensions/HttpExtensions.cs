using Api_Tour_Of_Heroes_Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace App_Tour_Of_Heroes_Apresentation.Extensions
{
    public static class HttpExtensions
    {
        public static bool IsSuccess(this HttpStatusCode statusCode) => new HttpResponseMessage(statusCode).IsSuccessStatusCode;
    }

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class EstruturaRetorno : ProducesResponseTypeAttribute
    {
        public EstruturaRetorno(int statusCode) : base(typeof(EstruturaResponse), statusCode)
        { }
    }
}
