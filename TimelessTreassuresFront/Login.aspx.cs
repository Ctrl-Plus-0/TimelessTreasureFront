using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TimelessTreassuresFront.ServiceReference1;
using HashPass;

namespace TimelessTreassuresFront
{
    public partial class Login : System.Web.UI.Page
    {
        
        //This method wllneed to cheange to accomodate session varaibles but for now
        //This will do
        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            Service1Client Client = new Service1Client();

            string email = txtEmail.Text;
            string password = Secrecy.HashPassword(txtPass.Text);

            string loginstatus = Client.login(email, password);

            if(loginstatus== "Username Or Password is Incorrect")
            {

                Msglabel.Text = "Incorrect Username or Passowrd";
             
            }
            else
            {
                NavBarset(loginstatus);
                Response.Redirect("Landing.aspx");


            }
        }

        private void NavBarset(string Utype)
        {
            Front Masterpage = Master as Front;
            var customerbar = Masterpage.FindControl("CustomerNav") as Control;
            var adminbar = Masterpage.FindControl("AdminNav") as Control;
            var regloginbar = Masterpage.FindControl("RegLoginNav") as Control;
            if (Masterpage != null)
            {
                switch (Utype)
                {
                    case "Customer":

                        customerbar.Visible = true;
                        regloginbar.Visible = false;
                        break;
                    case "Admin":

                        adminbar.Visible = true;
                        regloginbar.Visible = false;
                        break;

                    default:
                        return;
                }
            }
        }
    }
    
}