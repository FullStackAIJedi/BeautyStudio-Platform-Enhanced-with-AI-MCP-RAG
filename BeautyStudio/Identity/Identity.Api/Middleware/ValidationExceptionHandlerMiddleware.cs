namespace Identity.Api.Middleware
{
    using System.Net;
    using System.Text.Json;

    using Identity.Application.Common.Exceptions;
    using SharedKernel.Exceptions;

    public class ValidationExceptionHandlerMiddleware
    {
        private readonly RequestDelegate next; 
        public ValidationExceptionHandlerMiddleware(RequestDelegate next) => this.next = next;

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await this.next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var code = HttpStatusCode.InternalServerError;
            var result = string.Empty;

            switch (exception)
            {
                case ModelValidationException modelValidationException:
                    code = HttpStatusCode.BadRequest;
                    result = JsonSerializer.Serialize(new
                    {
                        ValidationDetails = true,
                        modelValidationException.Errors
                    });
                    break;
                case Application.Common.Exceptions.NotFoundException _:
                    code = HttpStatusCode.NotFound;
                    break;
                case BaseDomainException domainException:
                    code = HttpStatusCode.BadRequest;
                    result = JsonSerializer.Serialize(new[] { domainException.Error });
                    break;
            }

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;

            if (string.IsNullOrEmpty(result))
            {
                result = JsonSerializer.Serialize(new[] { exception.Message });
            }

            return context.Response.WriteAsync(result);
        }
    }
}
