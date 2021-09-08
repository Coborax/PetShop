using Microsoft.Extensions.DependencyInjection;
using PetShop.Core.Services;
using PetShop.Domain.Repositories;
using PetShop.Domain.Services;
using PetShop.Infrastructure.Data.InMemory;
using PetShop.Infrastructure.Data.InMemory.Repositories;

namespace PetShop.UI.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceCollection serviceCollection = new ServiceCollection();
            serviceCollection.AddSingleton<FakeDB>();
            serviceCollection.AddScoped<IPetRepo, InMemoryPetRepo>();
            serviceCollection.AddScoped<IPetService, PetService>();
            serviceCollection.AddScoped<IPetTypeRepo, InMemoryPetTypeRepo>();
            serviceCollection.AddScoped<IPetTypeService, PetTypeService>();

            ServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();

            Application app = new Application(serviceProvider);
            app.Run();

        }
    }
}