using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using JsonStorageManager.QueueProcessor;
using JsonStorageManager.BlobManager;

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults()
    .ConfigureServices(s =>
    {
        s.AddMediatR(c => c.RegisterServicesFromAssemblyContaining<Program>());

        s.AddTransient<Validator>();
        s.AddTransient<BlobManager>();
    })
    .Build();

host.Run();
