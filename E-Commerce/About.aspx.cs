using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace E_Commerce
{
    public partial class About : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //se non ci sono queryParams torna in home (in questo caso prendo solo nome dato che li passo tutti insieme)
            if (Request.QueryString["nome"] == null)
            {
                Response.Redirect("Default.aspx");
            }
            else
            {

                //Al caricamento della pagina prendo i queryParams
                string nome = Request.QueryString["nome"];
                
                decimal prezzo = decimal.Parse(Request.QueryString["prezzo"]);
                int quantita = int.Parse(Request.QueryString["qt"]);
                
               
                string img = Request.QueryString["img"];
                string descrizione = Request.QueryString["desc"];

                //popolo la pagina con i parametri appena presi
                title.InnerText = nome;
                productImg.Src = img;
                productDesc.InnerText = descrizione;
                productPrice.InnerText = prezzo + " €";
                productQt.InnerText = quantita + " Pezzi rimanenti";

            }
        }

        protected void addToCart_Click(object sender, EventArgs e)
        {
            string nome = Request.QueryString["nome"];
            decimal prezzo = decimal.Parse(Request.QueryString["prezzo"]);
            string img = Request.QueryString["img"];

            // se non esiste il cookie cart lo creo
            HttpCookie cartCookie = Request.Cookies["Cart"];
            if (cartCookie == null)
            {
                cartCookie = new HttpCookie("Cart");
            }
            // aggiungo il prodotto al cookie, cart avra una value(nome del prodotto) = altri valori di cui ho bisogno
            string productInfo = $"{prezzo},{img}";
            cartCookie.Values[nome] = productInfo;

            cartCookie.Expires = DateTime.Now.AddDays(10);

            // Aggiungo effettivamente il cookie
            Response.Cookies.Add(cartCookie);
            //confermo all'utente che il cookie e' stato aggiungo
            conferma.Text = "Prodotto aggiunto con successo";
            goToCart.CssClass = "btn btn-success rounded-pill py-2 px-4";


        }

        protected void BackToHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default");
        }

        protected void goToCart_Click(object sender, EventArgs e)
        {
            Response.Redirect("Contact");
        }
    }
}