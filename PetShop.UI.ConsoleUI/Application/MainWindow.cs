using PetShop.Core.Models;
using PetShop.Core.Services;
using Terminal.Gui;

namespace PetShop.UI.ConsoleUI.Application
{
    public class MainWindow : Window
    {
        private readonly IService<Pet> _petService;

        private ListView _petListView;
        private TextField _nameField;
        private TextField _typeLabel;
        private TextField _birthLabel;
        private TextField _soldLabel; 
        private TextField _colorLabel;
        private TextField _priceLabel;

        public MainWindow(IService<Pet> petService) : base("Pet Shop")
        {
            _petService = petService;
        }

        public void InitWindow(Rect terminalRect)
        {
            int windowWidth = terminalRect.Width;
            int windowHeight = terminalRect.Height;
            int padding = 2;
            
            int listFrameWidth = 20;
            
            int fieldOffset = 20;
            int fieldWidth = 20;
            
            // Create application frames
            FrameView listFrame = new FrameView(new Rect(0, 0, listFrameWidth, windowHeight - padding),"Pets");
            FrameView petInfoFrame = new FrameView(new Rect(listFrameWidth, 0, windowWidth - listFrameWidth - padding, windowHeight - padding), "Pet Info");

            // Create pet list view
            _petListView = new ListView(new Rect(0, 0, listFrameWidth, windowHeight - padding * 2), _petService.GetAll());
            _petListView.SelectedItemChanged += PetListViewOnSelectedItemChanged;
            listFrame.Add(_petListView);
            
            // Create Pet edit controls
            Label nameLabel = new Label(0, 0, "Name: ");
            Label typeLabel = new Label(0, 1, "Type: ");
            Label birthLabel = new Label(0, 2, "Birthdate: ");
            Label soldLabel = new Label(0, 3, "Sold Date: ");
            Label colorLabel = new Label(0, 4, "Color: ");
            Label priceLabel = new Label(0, 5, "Price: ");

            _nameField = new TextField(fieldOffset, 0, fieldWidth, "");
            _typeLabel = new TextField(fieldOffset, 1, fieldWidth, "");
            _birthLabel = new TextField(fieldOffset, 2, fieldWidth, "");
            _soldLabel = new TextField(fieldOffset, 3, fieldWidth, "");
            _colorLabel = new TextField(fieldOffset, 4, fieldWidth, "");
            _priceLabel = new TextField(fieldOffset, 5, fieldWidth, "");
            
            petInfoFrame.Add(
                nameLabel,
                typeLabel,
                birthLabel,
                soldLabel,
                colorLabel,
                priceLabel,
                _nameField, 
                _typeLabel, 
                _birthLabel,
                _soldLabel, 
                _colorLabel,
                _priceLabel,
                _nameField);
            
            Add(listFrame);
            Add(petInfoFrame);
        }

        private void PetListViewOnSelectedItemChanged(ListViewItemEventArgs obj)
        {
            _nameField.Text = _petService.GetAll()[_petListView.SelectedItem].Name;
            _typeLabel.Text = _petService.GetAll()[_petListView.SelectedItem].Type.Name;
            _birthLabel.Text = _petService.GetAll()[_petListView.SelectedItem].Birthdate.ToString("dd/MM/yyyy");
            _soldLabel.Text = _petService.GetAll()[_petListView.SelectedItem].SoldDate.ToString("dd/MM/yyyy");
            _colorLabel.Text = _petService.GetAll()[_petListView.SelectedItem].Color;
            _priceLabel.Text = _petService.GetAll()[_petListView.SelectedItem].Price.ToString("dd/MM/yyyy");
            
        }
    }
}