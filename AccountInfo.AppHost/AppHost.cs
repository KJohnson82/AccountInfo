var builder = DistributedApplication.CreateBuilder(args);

var postgres = builder.AddPostgres("accountinfo-postgres")
    .WithPgAdmin();

var appInfoDb = postgres.AddDatabase("appinfodb");

var accountinfoapiservice = builder.AddProject<Projects.AccountInfo_ApiService>("accountinfoapiservice")
    .WaitFor(appInfoDb)
    .WithReference(appInfoDb)
    .WithHttpHealthCheck("/health");

builder.AddProject<Projects.AccountInfo_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithHttpHealthCheck("/health")
    .WaitFor(accountinfoapiservice)
    .WithReference(accountinfoapiservice)
    .WithReference(appInfoDb);
    

builder.AddDockerComposeEnvironment("env");

builder.Build().Run();
