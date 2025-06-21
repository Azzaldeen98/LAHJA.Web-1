using Castle.DynamicProxy;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Middlewares
{
    public class RequestHandlingInterceptor : IInterceptor
    {
        private readonly ILogger<RequestHandlingInterceptor> _logger;

        public RequestHandlingInterceptor(ILogger<RequestHandlingInterceptor> logger)
        {
            _logger = logger;
        }

        public void Intercept(IInvocation invocation)
        {
            try
            {
                _logger.LogInformation("✅ Start Request: {MethodName}", invocation.Method.Name);
                invocation.Proceed();
                _logger.LogInformation("✅ Executed: {MethodName}", invocation.Method.Name);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "❌ Error in Request {MethodName}", invocation.Method.Name);
      
            }
        }


    }
}