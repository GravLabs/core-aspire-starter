var builder = DistributedApplication.CreateBuilder(args);

var serverApi = builder.AddProject<Projects.WebApp_Server>("webapp-server")
    .WithExternalHttpEndpoints();

builder.AddNpmApp("webapp-client", "../webapp.client", "dev")
    .WithEndpoint(targetPort: 5173, scheme:"https", env: "PORT")
    .WithReference(serverApi)
    .WithEnvironment("BROWSER", "none") // Disable opening browser on npm start
    //.WithHttpEndpoint(env: "PORT")
    .WithExternalHttpEndpoints()
    .PublishAsDockerFile();

builder.Build().Run();
