using Microsoft.Extensions.DependencyInjection;
using PetShop.Core.Models;
using PetShop.Core.Services;
using PetShop.Domain.Repositories;
using PetShop.Domain.Services;
using PetShop.Infrastructure.Data.InMemory;
using PetShop.Infrastructure.Data.InMemory.Repositories;
using PetShop.UI.ConsoleUI.Application;
using Terminal.Gui;

namespace PetShop.UI.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceCollection serviceCollection = new ServiceCollection();
            serviceCollection.AddSingleton<FakeDB>();
            serviceCollection.AddScoped<IPetRepo, InMemoryPetRepo>();
            serviceCollection.AddScoped<IRepo<PetType>, InMemoryPetTypeRepo>();
            serviceCollection.AddScoped<IPetService<Pet>, GenericService<Pet>>();
            serviceCollection.AddScoped<IPetService<PetType>, GenericService<PetType>>();

            ServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();

            IPetService<Pet> petPetService = serviceProvider.GetRequiredService<IPetService<Pet>>();

            Terminal.Gui.Application.Init();
            Toplevel top = Terminal.Gui.Application.Top;
            
            MainWindow mainWindow = new MainWindow(petPetService);
            top.Add(mainWindow);
            
            mainWindow.InitWindow(Terminal.Gui.Application.Current.Bounds);
            
            Terminal.Gui.Application.Run();
        }
    }
}