# dotnet-grpc-json-transcoding

POC to investigate the capabilities of ASP.NET JSON Transcoding.

## How to Run

1. Clone the repo locally.
2. Execute the following commands:
   
    ```bash
    cd GrpcGreeter
    dotnet run .
    ```

    You should see an output similar to:
   
    ```
    info: Microsoft.Hosting.Lifetime[14]
          Now listening on: http://localhost:5000
    info: Microsoft.Hosting.Lifetime[0]
          Application started. Press Ctrl+C to shut down.
    info: Microsoft.Hosting.Lifetime[0]
          Hosting environment: Development
    info: Microsoft.Hosting.Lifetime[0]
    ```

3. Open the HTTP `localhost` address located on the second line of the output in your browser.
4. Append `/swagger` to the path of the localhost address.
   * For example, if I got the output above, I would navigate to: [http://localhost:5000/swagger](http://localhost:5000/swagger)


## Motivation

Suppose your team has already built out a handful of gRPC service endpoints that they now want to expose to a browser application as API endpoints. According to ["The state of gRPC in the broswer"](https://grpc.io/blog/state-of-grpc-web/#the-grpc-web-spec),

> It is currently impossible to implement the HTTP/2 gRPC spec[<sup>1</sup>](https://github.com/grpc/grpc/blob/master/doc/PROTOCOL-WEB.md#protocol-differences-vs-grpc-over-http2) in the browser, as there is simply no browser API with enough fine-grained control over the requests.

## Solutions

### 1. gRPC's Officially Supported Method: gRPC-Web & Envoy

gRPC's officially supported method of integrating web browsers with gRPC services is through the use of the gRPC-Web JavaScript package, an Envoy proxy, & a gRPC backend server. The gRPC-Web package enables automatically creating JavaScript/TypeScript models and service stubs from `.proto` files. The Envoy proxy sits between the browser and the gRPC server. Its job is to translate between the browser's HTTP/1.1 gRPC-Web binary and the gRPC server's HTTP/2 gRPC binary.

### 2. ASP.NET Core's gRPC-Web & gRPC Middleware

gRPC mentions that languages/platforms may implement their own in-process proxies to negate the need for the Envoy proxy, which adds to the list of infrastructure pieces that you would need to manage. ASP.NET Core offers the Grpc.AspNetCore.Web middleware package.

### 3. ASP.NET Core's JSON Transcoding

As an alternative to needing the gRPC-Web package, ASP.NET Core offers the Microsoft.AspNetCore.Grpc.JsonTranscoding NuGet package. This package allows you to automatically generate RESTful JSON APIs (as well as the accompanying OpenAPI/Swagger documentation) for your gRPC services. This allows front-end developers to use the protocols/interfaces they are used to while still keeping the ability to call services using gRPC.

This repo is a POC for the JSON transcoding solution for integrating web browsers with gRPC services written in ASP.NET Core.

## References

1. https://github.com/grpc/grpc/blob/master/doc/PROTOCOL-WEB.md#protocol-differences-vs-grpc-over-http2
