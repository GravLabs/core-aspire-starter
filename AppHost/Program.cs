var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.WebApp_Server>("webapp-server");

builder.Build().Run();
