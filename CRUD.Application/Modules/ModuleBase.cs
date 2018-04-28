using Nancy;
using Nancy.Responses.Negotiation;
using Newtonsoft.Json;
using System;

namespace CRUD.Application.Modules
{
    public abstract class ModuleBase : NancyModule
    {
        public ModuleBase(string modulePath)
            : base(modulePath)
        {
            RegisterRoutes();
        }

        protected abstract void RegisterRoutes();

        public Negotiator ExceptionResponse(Exception exception)
        {
            return ExceptionResponse(exception, HttpStatusCode.BadRequest);
        }

        public Negotiator ExceptionResponse(Exception exception, HttpStatusCode statusCode)
        {
            string message = statusCode == HttpStatusCode.InternalServerError ? "An error has occurred in our servers" : exception.Message;
            return Negotiate
                .WithModel(message)
                .WithStatusCode(statusCode);
        }

        #region Assistants methods

        protected T DeserializeObject<T>(string jsonString)
        {
            return JsonConvert.DeserializeObject<T>(jsonString);
        }

        public string SerializeObject(object model)
        {
            return JsonConvert.SerializeObject(model,
                            Formatting.None,
                            new JsonSerializerSettings()
                            {
                                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                                DateFormatString = "yyyy-MM-ddTHH:mmZ"
                            });
        }

        public string SerializeObjectWithoutTimeZone(object model)
        {
            return JsonConvert.SerializeObject(model,
                            Formatting.None,
                            new JsonSerializerSettings()
                            {
                                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                                DateFormatString = "yyyy-MM-ddTHH:mm"
                            });
        }

        #endregion
    }
}