
namespace Survey.BL.RequestHandler
{
    public interface IHandler<TRequest>
    {
        public Task HandleAsync(TRequest request);
    }
    public interface IHandler<TResponse, TRequest>
    {
        public Task<TResponse> HandleAsync(TRequest request);
    }
}
