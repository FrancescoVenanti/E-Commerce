using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace E_Commerce
{
    public partial class Contact : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            container.InnerHtml = "";
            //prendo il cookie cart
            HttpCookie cartCookie = Request.Cookies["Cart"];
            decimal totale = 0;
            //ciclo i prodotti in cookie cart
            if (Request.Cookies["cart"] != null)
            {
                foreach (string product in cartCookie.Values.AllKeys)
                {
                    //faccio lo split sulla virgola per ogni songolo prodotto cosi da avere i valori
                    string[] productInfo = cartCookie.Values[product].Split(',');
                    string name = product;
                    string price = productInfo[0] + "," + productInfo[1];
                    string img = productInfo[2];
                    totale += decimal.Parse(price);

                    container.InnerHtml += $"<div class='d-flex align-items-center border my-2 px-2 py-3 rounded'>" +
                                      $"<img height='50px' src='{img}' class='me-4'/>" +
                                      $"<p class='mb-0 me-2 fw-bold'>{name}</p>" +
                                      $"<p class='mb-0'>{price:C}</p>" +
                                      //$"<button ID='btnDelete_{name}' runat='server' CommandName='Delete' CommandArgument='{name}' CssClass='btn btn-danger ms-auto' OnCommand='DeleteItem_Command'>Cancella <button />" +
                                      $"</div>";
                }
            }
            else
            {
                container.InnerHtml = "<p class='display-6'>Il tuo carrello e' vuoto</p>";
            }
            totCart.InnerText = "totale carrello: " + totale.ToString() + " €";
        }

        //prova funzione per eliminare il singolo oggetto nel carrello, che pero non riesco a far funzionare correttamente
        protected void DeleteItem_Command(object sender, CommandEventArgs e)
        {
            string productName = e.CommandArgument.ToString();

            // Retrieve the cart cookie
            HttpCookie cartCookie = Request.Cookies["Cart"];

            // Remove the product from the cart cookie
            if (cartCookie != null && cartCookie.Values[productName] != null)
            {
                cartCookie.Values.Remove(productName);

                // Update the expiration date of the cart cookie
                cartCookie.Expires = DateTime.Now.AddDays(10);

                // Add the updated cart cookie to the response
                Response.Cookies.Add(cartCookie);

                // Redirect back to the cart page to reflect the changes
                Response.Redirect(Request.RawUrl);
            }
        }

        //funzione che elimina il cookie del carrello
        protected void DeleteCart_Click(object sender, EventArgs e)
        {
            if (Request.Cookies["Cart"] != null)
            {
                HttpCookie cartCookie = new HttpCookie("Cart");

                //imposto la scadenza al passato cosi da eliminare il cookie
                cartCookie.Expires = DateTime.Now.AddDays(-1); 
                Response.Cookies.Add(cartCookie);

                //ricarica pagina
                Response.Redirect(Request.RawUrl);
            }
        }
    }
}