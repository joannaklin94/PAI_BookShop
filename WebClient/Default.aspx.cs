using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Net.Http;


namespace WebClient
{
    public partial class Default : System.Web.UI.Page
    {

        string address = "http://localhost:61792/TutorialService.svc/Tutorial";


        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button_GetAllProducts_Click(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient();
            //HttpResponseMessage wcfResponse = client.GetAsync("http://localhost:61792/TutorialService.svc/Tutorial").Result;
            HttpResponseMessage wcfResponse = client.GetAsync(address).Result;
            HttpContent stream = wcfResponse.Content;
            var data = stream.ReadAsStringAsync();
            Label1.Text = data.Result;

            
            //HttpClient client = new HttpClient();
            //Label1.Text = "";
            //List<Product> products = null;
            //HttpResponseMessage getResponse = client.GetAsync(address).Result;
            //var task = getResponse.Content.ReadAsAsync<List<Product>>().ContinueWith((t) =>
            //{
            //    products = t.Result;
            //});
            //task.Wait();

            //foreach (Product product in products)
            //{
            //    Label1.Text += "Product ID: " + product.Id + " "
            //        + product.Name + " Price: " + product.Price + "<br/>";
            //}


        }

        protected void Button_GetProductbyId_Click(object sender, EventArgs e)
        {

            string user = ((TextBox)FindControl("TextBox1")).Text;
            int pID = Int32.Parse(user);

            HttpClient client = new HttpClient();
            HttpResponseMessage getResponseWithId = client.GetAsync(new Uri(address + "/" + pID.ToString())).Result;
            HttpContent stream = getResponseWithId.Content;
            var data = stream.ReadAsStringAsync();
            if (data.Equals(null))
            {
                Label2.Text = "no product";

            }

            Label2.Text = data.Result;
            
        }

        protected void Button_DeleteProduct_Click(object sender, EventArgs e)
        {
            //int pDelID = Int32.Parse(txtDeleteProductID.Text);
            HttpClient client = new HttpClient();
            //string str = String.Concat("http://localhost:61792/TutorialService.svc/Tutorial/", pDelID);  
            //HttpResponseMessage wcfResponse = client.GetAsync(str).Result;

        }

        protected void Button_CreateProduct_Click(object sender, EventArgs e)
        {
            //int pDelID = Int32.Parse(txtDeleteProductID.Text);
            HttpClient client = new HttpClient();
            //string str = String.Concat("http://localhost:61792/TutorialService.svc/Tutorial/", pDelID);
            //HttpResponseMessage wcfResponse = client.GetAsync(str).Result;

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //int pDelID = Int32.Parse(txtDeleteProductID.Text);
            HttpClient client = new HttpClient();

            HttpResponseMessage wcfResponse = client.GetAsync("http://localhost:61792/TutorialService.svc/Post").Result;
            HttpContent stream = wcfResponse.Content;
            var data = stream.ReadAsStringAsync();
            Label6.Text = data.Result;

        }





    }
}