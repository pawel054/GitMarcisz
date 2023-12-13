using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GitMarcisz
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ManageProduct : ContentPage
    {
        private Produkt wybranyProdukt;
        private ObservableCollection<Produkt> produkty = new ObservableCollection<Produkt>();
        public ManageProduct(ObservableCollection<Produkt> produkty)
        {
            InitializeComponent();
            this.produkty = produkty;
        }

        public ManageProduct(Produkt wybranyProdukt)
        {
            InitializeComponent();
            this.wybranyProdukt = wybranyProdukt;
            labelTytul.Text = "Edytuj produkt";
            entryNazwa.Text = wybranyProdukt.Nazwa;
            entryCena.Text = wybranyProdukt.Cena.ToString();
            entryIlosc.Text = wybranyProdukt.Ilosc.ToString();
            btnDodaj.IsVisible = false;
            btnEdytuj.IsVisible = true;
        }

        private void BtnDodajClicked(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(entryNazwa.Text) && !string.IsNullOrEmpty(entryCena.Text) && !string.IsNullOrEmpty(entryIlosc.Text))
            {
                if(int.TryParse(entryIlosc.Text, out int _) && double.TryParse(entryCena.Text, out double _))
                {
                    var produkt = new Produkt(entryNazwa.Text, double.Parse(entryCena.Text), int.Parse(entryIlosc.Text));
                    produkty.Add(produkt);
                    Navigation.PopAsync();
                }
                else
                {
                    DisplayAlert("Niepoprawne dane", "Pola cena i ilość muszą być liczbami", "OK");
                }
            }
            else
            {
                DisplayAlert("Niepoprawne dane", "Pola nie mogą byc puste", "OK");
            }
        }

        private void BtnEdytujClicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(entryNazwa.Text) && !string.IsNullOrEmpty(entryCena.Text) && !string.IsNullOrEmpty(entryIlosc.Text))
            {
                if (int.TryParse(entryIlosc.Text, out int _) && double.TryParse(entryCena.Text, out double _))
                {
                    wybranyProdukt.Nazwa = entryNazwa.Text;
                    wybranyProdukt.Cena = double.Parse(entryCena.Text);
                    wybranyProdukt.Ilosc = double.Parse(entryIlosc.Text);
                    Navigation.PopAsync();
                }
                else
                {
                    DisplayAlert("Niepoprawne dane", "Pola cena i ilość muszą być liczbami", "OK");
                }
            }
            else
            {
                DisplayAlert("Niepoprawne dane", "Pola nie mogą byc puste", "OK");
            }
        }
    }
}