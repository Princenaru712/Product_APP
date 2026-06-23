var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.API_>("api");

builder.Build().Run();
