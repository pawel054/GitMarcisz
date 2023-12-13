using System;
using System.Collections.Generic;
using System.Text;

namespace GitMarcisz
{
    public class Produkt
    {
        public string Nazwa {  get; set; }
        public decimal Cena {  get; set; }
        public int Ilosc {  get; set; }

        public Produkt(string nazwa,decimal cena,int ilosc) {
            Nazwa = nazwa;
            Cena = cena;
            Ilosc = ilosc;
        }
        public Produkt() { }
    }
}
