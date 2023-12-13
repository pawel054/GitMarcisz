using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GitMarcisz
{
    public partial class MainPage : ContentPage
    {
        private Produkt wybranyProdukt;
        public ObservableCollection<Produkt> produkty = new ObservableCollection<Produkt>();
        protected override void OnAppearing()
        {
            base.OnAppearing();
            AktualizujListe();
        }
        public void AktualizujListe()
        {
            lista.ItemsSource = null;
            lista.ItemsSource = produkty;
        }
        public MainPage()
        {
            InitializeComponent();
            OnAppearing();
        }

        public void Dodaj_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ManageProduct(produkty));
        }
        public void Edytuj_Clicked(object sender,EventArgs e)
        {
            wybranyProdukt = (Produkt)lista.SelectedItem;
            Navigation.PushAsync(new ManageProduct(wybranyProdukt));
        }
        public void Usun_Clicked(object sender,EventArgs e)
        {
            wybranyProdukt = (Produkt)lista.SelectedItem;
            produkty.Remove(wybranyProdukt);
            AktualizujListe();
        }
    }
}
