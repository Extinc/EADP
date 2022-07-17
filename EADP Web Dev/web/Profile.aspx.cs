using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using EADP_Web_Dev.Code;

namespace EADP_Web_Dev.web
{
    public partial class Profile : System.Web.UI.Page
    {
        private AccountDb _accountdb = new AccountDb();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userID"] == null &&
                Session["email"] == null &&
                Session["roleID"] == null)
            {
                Response.Redirect(Page.ResolveClientUrl("~/web/error.aspx"));
            }
            else
            {
                TB_emailChge.Text = Session["email"]?.ToString();
                AccountEntity acc = new AccountEntity();
                acc.Userid = Convert.ToInt32(Session["userID"].ToString());
                List<string> intList = _accountdb.GetUserInterest(acc);
                if ((intList != null))
                {
                    foreach (var interest in intList)
                    {
                        string interestChips = "<i class=\"close material-icons\">close</i>";
                        HtmlGenericControl chipDiv = new HtmlGenericControl();
                        chipDiv.TagName = "div";
                        chipDiv.Attributes["class"] = "chip";
                        Debug.WriteLine("INTERRESST : " + interest);
                        chipDiv.InnerHtml = interest + interestChips;
                        interestHolder.Controls.Add(chipDiv);
                        Debug.WriteLine("CHIP : " + interestHolder.Controls);
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "chipRefresh()", true);
                    }
                }
            }
        }

        protected void btnUpdate_OnClick(object sender, EventArgs e)
        {
            AccountEntity acc = new AccountEntity();
            acc.Userid = Convert.ToInt32(Session["userID"].ToString());
            string stringArray = arrayInterests.Value;
            stringArray = stringArray.Replace(",", " ");
            string[] array = stringArray.Split(' ');
            List<string> interestList = new List<string>();
            /*            string[] array = ;*/
            for (int i = 0; i < array.Length; i++)
            {
                interestList.Add(array[i]);
                Debug.Write("arr[i]=" + array[i]);
            }

            List<string> intList = _accountdb.GetUserInterest(acc);
            if ((intList != null))
            {
                foreach (var interest in intList)
                {
                    if (interestList.Contains(interest))
                    {
                        interestList.Remove(interest);
                    }
                }
            }

            foreach (var VARIABLE in interestList)
            {
                Debug.WriteLine("NEW : " + VARIABLE);
            }

            acc.Interest = interestList;
            Debug.Write("EXIST : " + _accountdb.CheckUserInterestExist(acc));

            _accountdb.UpdateInterest(acc);

            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "chipRefresh()",
                true);
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text",
                "Materialize.updateTextFields()",
                true);
        }

        protected void btnChgPW_OnClick(object sender, EventArgs e)
        {
            Page.Validate("chgpwVG");
            if (Page.IsValid)
            {
                if (TB_newpw.Text.Equals(TB_newpwrepeat.Text))
                {
                    AccountEntity acc = new AccountEntity();
                    acc.Email = Session["email"].ToString();
                    acc.Password = TB_newpw.Text;
                    _accountdb.UpdatePassword(acc);
                }
                else
                {
                    TB_newpw.CssClass = "validate invalid";
                    TB_newpwrepeat.CssClass = "validate invalid";
                    lblUpdteNewPw.Attributes["data-error"] = "New password is not the same";
                    lblUpdteNewPwRepeat.Attributes["data-error"] = "New password is not the same";
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text",
                        "Materialize.updateTextFields()",
                        true);
                }
            }

            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "Materialize.updateTextFields()",
                true);
        }

        protected void settingOldPW_OnServerValidate(object source, ServerValidateEventArgs args)
        {
            var email = Session["email"].ToString();
            var correctpw = _accountdb.VerifyPw(email, TB_oldpw.Text);

            if (correctpw)
            {
                args.IsValid = true;
            }
            else
            {
                args.IsValid = false;
                TB_oldpw.CssClass = "validate invalid";
                lblUpdteOldPW.Attributes["data-error"] = "Password is incorrect";
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "Materialize.updateTextFields()",
                    true);
            }
        }
    }
}