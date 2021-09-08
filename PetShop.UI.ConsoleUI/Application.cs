using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using PetShop.Core.Models;
using PetShop.Core.Services;

namespace PetShop.UI.ConsoleUI
{
    public class Application
    {
        private IPetService _petService;
        private IPetTypeService _petTypeService;

        private Dictionary<string, EventHandler> _menus = new Dictionary<string, EventHandler>();
        private bool _running = false;

        public Application(ServiceProvider provider)
        {
            _petService = provider.GetRequiredService<IPetService>();
            _petTypeService = provider.GetRequiredService<IPetTypeService>();
            
            _menus.Add("Show all pets", ShowPetsAllMenu);
            _menus.Add("Search for pet by type", SearchPetByTypeMenu);
            _menus.Add("Create new pet", CreateNewPetMenu);
            _menus.Add("Delete pet", DeletePetMenu);
            _menus.Add("Update pet", UpdatePetMenu);
            _menus.Add("Sort pets by price", SortPetsByPriceMenu);
            _menus.Add("Get five cheapest pets", GetCheapestMenu);
            _menus.Add("Exit", ExitMenu);
        }

        private void ShowPetsAllMenu(object? sender, EventArgs e)
        {
            List<Pet> pets = _petService.GetAll();
            foreach (Pet pet in pets)
            {
                Console.WriteLine($"({pet.ID}) {pet.Name}");
            }
        }
        
        private void SearchPetByTypeMenu(object? sender, EventArgs e)
        {
            Console.Write("Select pet type: ");
            int selectedType = ListSelect(_petTypeService.GetAll().Select(pt => pt.Name).ToList());
            List<Pet> pets = _petService.Find(_petTypeService.GetAll()[selectedType]);
            foreach (Pet pet in pets)
            {
                Console.WriteLine($"({pet.ID}) {pet.Name}");
            }
        }
        
        private void CreateNewPetMenu(object? sender, EventArgs e)
        {
            string name = GetInput("Name");
            int selectedType = ListSelect(_petTypeService.GetAll().Select(pt => pt.Name).ToList());
            string birthDate = GetInput("Birthdate");
            string soldDate = GetInput("Sold date");
            string color = GetInput("Color");
            string price = GetInput("Price");
            
            Pet newPet = new Pet
            {
                Name = name,
                Type = _petTypeService.GetAll()[selectedType],
                Birthdate = DateTime.Parse(birthDate),
                SoldDate = DateTime.Parse(soldDate),
                Color = color,
                Price = double.Parse(price)
            };

            _petService.Create(newPet);
        }
        
        private void DeletePetMenu(object? sender, EventArgs e)
        {
            int selected = ListSelect(_petService.GetAll().Select(p => p.Name).ToList());
            _petService.Delete(_petService.GetAll()[selected].ID);
        }
        
        private void UpdatePetMenu(object? sender, EventArgs e)
        {
            int selected = ListSelect(_petService.GetAll().Select(p => p.Name).ToList());
            Pet toUpdate = _petService.GetAll()[selected];
            
            string name = GetInput("Name");
            int selectedType = ListSelect(_petTypeService.GetAll().Select(pt => pt.Name).ToList());
            string birthDate = GetInput("Birthdate");
            string soldDate = GetInput("Sold date");
            string color = GetInput("Color");
            string price = GetInput("Price");
            
            Pet pet = new Pet
            {
                ID = toUpdate.ID,
                Name = name,
                Type = _petTypeService.GetAll()[selectedType],
                Birthdate = DateTime.Parse(birthDate),
                SoldDate = DateTime.Parse(soldDate),
                Color = color,
                Price = double.Parse(price)
            };

            _petService.Update(pet);
        }
        
        private void SortPetsByPriceMenu(object? sender, EventArgs e)
        {
            List<Pet> pets = _petService.GetCheapests(_petService.GetAll().Count);
            foreach (Pet pet in pets)
            {
                Console.WriteLine($"({pet.ID}) {pet.Name}");
            }
        }
        
        private void GetCheapestMenu(object? sender, EventArgs e)
        {
            List<Pet> pets = _petService.GetCheapests(5);
            foreach (Pet pet in pets)
            {
                Console.WriteLine($"({pet.ID}) {pet.Name}");
            }
        }
        
        private void ExitMenu(object? sender, EventArgs e)
        {
            _running = false;
        }

        public void Run()
        {
            _running = true;
            while (_running)
            {
                foreach (var x in _menus.Select((entry, index) => new { entry, index }))
                {
                    Console.Write($"({x.index + 1}) {x.entry.Key} ");
                }
                Console.WriteLine();

                Console.Write("> ");
                string input = Console.ReadLine();
                bool parseRes = int.TryParse(input, out var inputNum);
                EventHandler selectedMenuHandler = _menus.ElementAt(inputNum - 1).Value;

                if (!parseRes &&  selectedMenuHandler == null)
                {
                    Console.WriteLine("Please enter a valid menu! (Press enter to continue)");
                    Console.ReadKey();
                }
                
                selectedMenuHandler.Invoke(this, EventArgs.Empty);
                Console.WriteLine();
            }
        }

        private int ListSelect(List<string> options)
        {
            int i = 1;
            foreach (var x in options)
            {
                Console.Write($"({i}) {x} ");
                i++;
            }
            Console.WriteLine();

            Console.Write("> ");
            string input = Console.ReadLine();
            bool parseRes = int.TryParse(input, out var inputNum);

            if (!parseRes)
                return -1;

            return inputNum - 1;
        }

        private string GetInput(string msg)
        {
            Console.Write($"{msg}: ");
            return Console.ReadLine();
        }
    }
}