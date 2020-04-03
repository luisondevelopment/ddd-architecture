using MediatR;

namespace Marketplace.Application
{
    public interface IRequestHandler<TRequest, TResponse>
        : MediatR.IRequestHandler<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
        where TResponse : IResponse
    {
    }
}
