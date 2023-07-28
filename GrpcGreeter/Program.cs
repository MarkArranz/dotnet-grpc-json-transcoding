using GrpcGreeter.Services;

var builder = WebApplication.CreateBuilder(args);

// Register gRPC and JSON Transcoding 
builder.Services.AddGrpc().AddJsonTranscoding();

// Configure Swagger to include gRPC endpoints.
builder.Services.AddGrpcSwagger();

// Autogenerate Swagger documentation
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc(
        "v1",
        new Microsoft.OpenApi.Models.OpenApiInfo { Title = "gRPC transcoding", Version = "v1" }
    );

    var filePath = Path.Combine(System.AppContext.BaseDirectory, "GrpcGreeter.xml");
    // Include comments for .proto messages. 
    c.IncludeXmlComments(filePath);
    // Include comments for .proto services.
    c.IncludeGrpcXmlComments(filePath, includeControllerXmlComments: true);
});

var app = builder.Build();

// Enable Swagger
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API v1");
});

// Configure the HTTP request pipeline.
app.MapGrpcService<GreeterService>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();
