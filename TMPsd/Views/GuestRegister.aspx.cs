using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TMPsd.Repository;

namespace TMPsd.Views
{
    public partial class GuestRegister : System.Web.UI.Page
    {
        Database1Entities db = new Database1Entities();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void RegAddressCustomValidator_ServerValidate(object sender, ServerValidateEventArgs e)
        {
            if (e.Value.Contains("Street") || (e.Value.Contains("street")))
            {
                e.IsValid = true;
            }
            else
            {
                e.IsValid = false;
            }
        }

        protected void TermCheckCustomValidator_ServerValidate(object sender, ServerValidateEventArgs e)
        {
            e.IsValid = TermCheck.Checked;
        }

        protected void RegisterBtn_Click(object sender, EventArgs e)
        {
            User checkUsername = db.Users.Where(u => u.Username == RegUsername.Text).FirstOrDefault();

            Page.Validate("RegisterValidation");
            if (Page.IsValid)
            {
                if(checkUsername == null)
                {
                    if (!AdminCheck.Checked)
                    {
                        int RoleID = 1;
                        string Username = RegUsername.Text;
                        string Password = RegPassword.Text;
                        string Name = RegName.Text;
                        string Gender = GenderButtonList.Text;
                        string PhoneNumber = RegPhone.Text;
                        string Address = RegAddress.Text;
                        bool Banned = false;

                        UserRepository.insertMember(RoleID, Username, Password, Name, Gender, PhoneNumber, Address, Banned);

                        RegUsername.Text = "";
                        RegPassword.Text = "";
                        RegName.Text = "";
                        RegPhone.Text = "";
                        RegAddress.Text = "";

                        RegisterSuccess.Text = "Register success";
                    }
                    else if (AdminCheck.Checked)
                    {
                        int RoleID = 2;
                        string Username = RegUsername.Text;
                        string Password = RegPassword.Text;
                        string Name = RegName.Text;
                        string Gender = GenderButtonList.Text;
                        string PhoneNumber = RegPhone.Text;
                        string Address = RegAddress.Text;

                        UserRepository.insertAdmin(RoleID, Username, Password, Name, Gender, PhoneNumber, Address);

                        RegUsername.Text = "";
                        RegPassword.Text = "";
                        RegName.Text = "";
                        RegPhone.Text = "";
                        RegAddress.Text = "";

                        RegisterSuccess.Text = "Register success";
                    }
                }
                else if (checkUsername != null)
                {
                    UsernameDuplicate.Text = "*Username has been taken";
                    RegisterFailed.Text = "Failed to register";
                }
            }
            else if (!Page.IsValid)
            {
                RegisterFailed.Text = "Failed to register";
            }
        }
    }
}