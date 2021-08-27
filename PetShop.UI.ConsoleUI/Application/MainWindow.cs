using PetShop.Core.Models;
using PetShop.Core.Services;
using Terminal.Gui;

namespace PetShop.UI.ConsoleUI.Application
{
    public class MainWindow : Window
    {
        public MainWindow(IService<Pet> petService) : base("Pet Shop")
        {
            FrameView listFrame = new FrameView(new Rect(0, 0, 20, 28),"Pets");
            FrameView petInfoFrame = new FrameView(new Rect(20, 0, 98, 28), "Pet Info");
            
            ListView petListView = new ListView(new Rect(0, 0, 20, 26), petService.GetAll());
            listFrame.Add(petListView);
            
            Add(listFrame);
            Add(petInfoFrame);
        }
    }
}