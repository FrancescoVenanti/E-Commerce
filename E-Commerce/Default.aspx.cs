using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static E_Commerce._Default;

namespace E_Commerce
{
    

    public partial class _Default : Page
    {
        public static class Prodotto
        {
            public static List<ProdottoItem> Prodotti { get; } = new List<ProdottoItem>();

            static Prodotto()
            {
                // Initialize your products here
                Prodotti.Add(new ProdottoItem("Smartphone", "Un telefono intelligente con molte funzioni", 599.99m, 100, "content/img/smartphone.jpg"));
                Prodotti.Add(new ProdottoItem("Laptop", "Un computer portatile potente e leggero", 999.99m, 50, "content/img/laptop.jpg"));
                Prodotti.Add(new ProdottoItem("Smartwatch", "Un orologio intelligente con monitoraggio fitness", 299.99m, 80, "content/img/smartwatch.jpg"));
                //Prodotti.Add(new ProdottoItem("Tablet", "Un tablet versatile per il lavoro e l'intrattenimento", 299.99m, 80, "content/img/tablet.jpeg"));
                Prodotti.Add(new ProdottoItem("TV", "Una TV 4K con immagini nitide e vivide", 899.99m, 30, "content/img/tv.jpg"));
                Prodotti.Add(new ProdottoItem("Speaker", "Un altoparlante Bluetooth per un suono di alta qualità", 79.99m, 150, "content/img/speaker.jpg"));
                Prodotti.Add(new ProdottoItem("Mouse", "Un mouse ergonomico per una maggiore comodità", 29.99m, 200, "content/img/mouse.jpg"));
                Prodotti.Add(new ProdottoItem("Tastiera", "Una tastiera senza fili con layout completo", 49.99m, 100, "content/img/keyboard.jpg"));
                Prodotti.Add(new ProdottoItem("Headphones", "Cuffie wireless con cancellazione attiva del rumore", 149.99m, 80, "content/img/headphones.jpg"));
                Prodotti.Add(new ProdottoItem("Fotocamera", "Una fotocamera digitale con molte funzioni avanzate", 699.99m, 40, "content/img/camera.jpg"));
                // Add more products as needed
            }

            // Nested class representing a product
            public class ProdottoItem
            {
                public string Nome { get; }
                public string Descrizione { get; }
                public decimal Prezzo { get; }
                public int QuantitàDisponibile { get; }
                public string ImgProdotto { get; }

                public ProdottoItem(string nome, string descrizione, decimal prezzo, int quantitàDisponibile, string imgProdotto)
                {
                    Nome = nome;
                    Descrizione = descrizione;
                    Prezzo = prezzo;
                    QuantitàDisponibile = quantitàDisponibile;
                    ImgProdotto = imgProdotto;
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            foreach (var prodotto in Prodotto.Prodotti)
            {

                container.InnerHtml += $@"
                <div class='col-12 col-md-4 col-lg-3'>
                    <div class='card pt-3 h-100'>
                        <img src='{prodotto.ImgProdotto}' class='card-img-top' alt='{prodotto.Nome}'>
                        <div class='card-body d-flex flex-column justify-content-end'>
                            <h5 class='card-title'>{prodotto.Nome}</h5>
                            <p class='card-text'>{prodotto.Prezzo} €</p>
                            <a href='About.aspx?nome={prodotto.Nome}&img={prodotto.ImgProdotto}&desc={prodotto.Descrizione}&qt={prodotto.QuantitàDisponibile}&prezzo={prodotto.Prezzo}' class='btn btn-primary'>Dettagli</a>
                        </div>
                    </div>
                </div>";

                     
            }
        }
    }
}