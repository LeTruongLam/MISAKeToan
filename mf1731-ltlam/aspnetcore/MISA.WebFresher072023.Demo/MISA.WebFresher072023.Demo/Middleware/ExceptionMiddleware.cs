using MISA.WebFresher072023.Demo.Domain;
using System;

namespace MISA.WebFresher072023.Demo
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        public ExceptionMiddleware(RequestDelegate next) { 
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }
        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            Console.WriteLine(exception);
            context.Response.ContentType = "application/json";
            if(exception is NotFoundException 
                notFoundException)
            {
                context.Response.StatusCode = StatusCodes.Status404NotFound;
                await context.Response.WriteAsync(
                    text: new BaseException()
                    {
                        ErrorCode = notFoundException.ErrorCode,
                        UserMessage = "Không tìm thấy tài nguyên",
                        DevMessage = exception.Message,
                        TraceId = context.TraceIdentifier,
                        MoreInfo = exception.HelpLink
                    }.ToString() ?? ""
                    );
            }
            else if (exception is ConflictException conflictException) {
                context.Response.StatusCode = StatusCodes.Status409Conflict;
                await context.Response.WriteAsync(
                    text: new BaseException()
                    {
                        ErrorCode = conflictException.ErrorCode,
                        UserMessage = "Tài nguyên bị trùng",
                        DevMessage = exception.Message,
                        TraceId = context.TraceIdentifier,
                        MoreInfo = exception.HelpLink
                    }.ToString() ?? ""
                    );


            }
            else
            {
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                await context.Response.WriteAsync(
                    text: new BaseException()
                    {
                        ErrorCode = context.Response.StatusCode,
                        UserMessage = "Lỗi hệ thống",
#if DEBUG
                        DevMessage = exception.Message,
#else
                        DevMessage=""
#endif
                        TraceId = context.TraceIdentifier,
                        MoreInfo = exception.HelpLink
                    }.ToString() ?? ""
                    );
            }
        }
    }
}
