using Grpc.Core;

namespace GrpcGreeter.Services;

/// <summary>
/// The Greeter Service
/// </summary>
public class GreeterService : Greeter.GreeterBase
{
    private readonly ILogger<GreeterService> _logger;

    /// <summary>
    /// Greeter Service Constructor
    /// </summary>
    /// <param name="logger">An ILogger</param>
    public GreeterService(ILogger<GreeterService> logger) => _logger = logger;

    /// <summary>
    /// Says Hello to the person whose name is provided in the request.
    /// </summary>
    /// <param name="request">A HelloRequest object.</param>
    /// <param name="context">A ServerCallContext object</param>
    /// <returns>An async HelloReply object.</returns>
    public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
    {
        return Task.FromResult(new HelloReply
        {
            Message = "Hello " + request.Name
        });
    }
}
