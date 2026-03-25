IDistributedApplicationBuilder builder = DistributedApplication.CreateBuilder(args);

var api = builder.AddProject<Projects.Api>("api")
    .WithExternalHttpEndpoints();

if (builder.ExecutionContext.IsRunMode)
{
    builder.AddJavaScriptApp("frontend", "./../Api/Web")
        .WithRunScript("start")
        .WithReference(api)
        .WaitFor(api)
        .WithHttpEndpoint(env: "PORT")
        .WithExternalHttpEndpoints();
}

builder.Build().Run();
