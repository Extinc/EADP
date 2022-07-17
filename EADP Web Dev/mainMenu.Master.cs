using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Web;
using System.Web.Compilation;
using System.Web.Script.Services;
using System.Web.Security;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using EADP_Web_Dev.Code;
using EADP_Web_Dev.Code.Consultation;

namespace EADP_Web_Dev
{
    public partial class mainMenu : System.Web.UI.MasterPage
    {
        private AccountDb _accountDb = new AccountDb();
        private NotificationDB _notiDB = new NotificationDB();
        List<Notifications> notiList = new List<Notifications>();
        private ConsultationDAO _cDao = new ConsultationDAO();
        protected void Page_Load(object sender, EventArgs e)
        {
            // Check if user is logged in on page load
            if (Session["userID"] == null &&
                Session["email"] == null &&
                Session["roleID"] == null)
            {
                aLogin.Visible = false;
                bLogin.Visible = true;
                CommunityHyperLinks.Visible = false;
                ClinicHyperLinks.Visible = false;
                financeDD.Visible = false;
            }
            else
            {
                aLogin.Visible = true;
                bLogin.Visible = false;
                CommunityHyperLinks.Visible = true;
                ClinicHyperLinks.Visible = true;
                financeDD.Visible = true;
                if (Convert.ToString(Session["roleID"]) == "2")
                {
                    courseadminli.Visible = true;
                    bookadminli.Visible = true;
                    Approvalli.Visible = true;
                    financeadmminli.Visible = true;
                }
                else
                {
                    courseadminli.Visible = false;
                    bookadminli.Visible = false;
                    Approvalli.Visible = false;
                    financeadmminli.Visible = false;
                }
                NotificationDB notiDb = new NotificationDB();
                if (notiDb.GetNotificationsOfUser(Convert.ToString(Session["userID"])) != null)
                {
                    notiList = notiDb.GetNotificationsOfUser(Convert.ToString(Session["userID"]));
                    nofNotispan.InnerText = notiList.Count.ToString();
                    AppendNotification(notiList);
                }
            }
        }

        // Append Notification to dropdown
        public void AppendNotification(List<Notifications> notiLists)
        {
            foreach (var noti in notiLists)
            {
                HtmlGenericControl liControl = new HtmlGenericControl {TagName = "li"};

                if (noti.Type.Equals("noti"))
                {
                    HtmlGenericControl firstdiv = new HtmlGenericControl {TagName = "div"};

                    HtmlGenericControl seconddiv = new HtmlGenericControl {TagName = "div"};
                    seconddiv.Attributes["class"] = "row";
                    HtmlGenericControl seconddivp = new HtmlGenericControl
                    {
                        TagName = "p",
                        InnerHtml = noti.Message + "by " + noti.ByUser
                    };
                    seconddivp.Attributes["class"] = "text-center";
                    seconddivp.Attributes["style"] = "width:100%;";
                    seconddiv.Controls.Add(seconddivp);

                    HtmlGenericControl thirddiv = new HtmlGenericControl {TagName = "div"};
                    thirddiv.Attributes["class"] = "row";
                    Button btn = new Button
                    {
                        Text = "Accept",
                        ID = "btnAccept" + (notiLists.IndexOf(noti) + 1),
                        CssClass = "btn waves-effect waves-light indigo accent-4",
                        UseSubmitBehavior = false,
                    };
                    Debug.WriteLine("id YO : " + btn.ID);
                    btn.Click += new EventHandler((sender, args) =>
                    {
                        var id = notiLists.IndexOf(noti) + 1;
                        Debug.WriteLine("id : " + id);
                        /*              int startIndex = id.IndexOf("btnAccept");
                                      int endIndex = id.LastIndexOf(id);
                                      int length = endIndex - startIndex + 1;
                                      id = id.Substring(startIndex, length);*/
                        Debug.WriteLine("id 1 : " + noti.Message);
                        int startIndex = "You have been invited to ".Length;
                        int endIndex = noti.Message.LastIndexOf(noti.Message, StringComparison.Ordinal);
                        int length = endIndex - startIndex + 1;
                        Debug.WriteLine("id 2 : " + noti.Message.Substring(startIndex));
                        _notiDB.SetConfirm(id, Convert.ToInt32(Session["userID"]),
                            noti.Message.Substring(startIndex), true);
                    });
                    thirddiv.Controls.Add(btn);

                    firstdiv.Controls.Add(seconddiv);
                    firstdiv.Controls.Add(thirddiv);

                    liControl.Controls.Add(firstdiv);
                }
                else if (noti.Type == "chat")
                {
                    HtmlGenericControl firstdiv = new HtmlGenericControl {TagName = "div"};

                    HtmlGenericControl seconddiv = new HtmlGenericControl {TagName = "div"};
                    seconddiv.Attributes["class"] = "row";
                    HtmlGenericControl seconddivp = new HtmlGenericControl
                    {
                        TagName = "p",
                        InnerHtml = noti.ByUser + " have send you a messages"
                    };
                    seconddivp.Attributes["class"] = "text-center";
                    seconddivp.Attributes["style"] = "width:100%;";
                    seconddiv.Controls.Add(seconddivp);

                    HtmlGenericControl thirddiv = new HtmlGenericControl {TagName = "div"};
                    seconddiv.Attributes["class"] = "row";
                    Button btn = new Button
                    {
                        ID = noti.ByUser + "_" + noti.NotificationId,
                        CssClass = "waves-effect waves-light btn",
                        Text = "Chat",
                        UseSubmitBehavior = false,
                    };
                    btn.Click += new EventHandler((sender, args) =>
                    {
                            Session["chatID"] = _cDao.GetChatId(_cDao.GetTargetId(noti.ByUserEmail), Convert.ToString(Session["email"]));
                            Debug.WriteLine("Noti Chat btn Clicked");
                            Response.Redirect(Page.ResolveClientUrl("~/web/Consultation/Chat.aspx") + "?targetemail=" + noti.ByUserEmail);
                        });
                    thirddiv.Controls.Add(btn);

                    firstdiv.Controls.Add(seconddivp);
                    firstdiv.Controls.Add(thirddiv);
                    liControl.Controls.Add(firstdiv);
                }

                dropdownNoti.Controls.Add(liControl);
            }
        }

        public void GoToChat(object sender, EventArgs e)
        {
            Control ctrl = sender as Control;
            //TODO: Debug writeline to be removed
            Debug.WriteLine(" NOTI EMAIL " + ctrl?.ID);
            //Response.Redirect(Page.ResolveClientUrl("~/web/default.aspx"));
        }

        // Login to account
        protected void Login(object sender, EventArgs e)
        {
            Page.Validate("loginVG");
            if (Page.IsValid)
            {
                AccountEntity acc = _accountDb.GetAccountData(TB_loginEmail.Text);
                Session["userID"] = acc.Userid;
                Session["email"] = acc.Email;
                Session["roleID"] = acc.Roleid;
                FormsAuthentication.SetAuthCookie(acc.Email, true);
                Debug.WriteLine("Context User Name 1 : " + Page.User.Identity.Name.ToString());
                _accountDb.SetUserOnline(acc.Email);
                Response.Redirect(Page.ResolveClientUrl("~/web/default.aspx"));
            }
        }

        // AccountEntity Registration
        protected void SignUp(object sender, EventArgs e)
        {
            var pw = TB_regPW.Text;
            var repeatpass = TB_regRepeatPW.Text;
            AccountEntity acc = new AccountEntity();
            Page.Validate("RegisterGroup");
            if (Page.IsValid)
            {
                if (pw.Equals(repeatpass))
                {
                    acc.Email = TB_regEmail.Text;
                    acc.Dob = DateTime.Parse(TB_regDOBs.Text);
                    acc.Phone = TB_regMobile.Text;
                    acc.FirstName = TB_regFirstName.Text;
                    acc.LastName = TB_regLastName.Text;
                    acc.Password = TB_regPW.Text;
                    // When password is the same
                    _accountDb.Register(acc);
                    TB_regEmail.Text = string.Empty;
                    TB_regDOBs.Text = string.Empty;
                    TB_regFirstName.Text = string.Empty;
                    TB_regLastName.Text = string.Empty;
                    TB_regMobile.Text = string.Empty;
                }
                else
                {
                    // When password is not the same
                    // use validationg isValid equals false 
                }

                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "Materialize.updateTextFields()",
                    true);
            }
        }

        // Check if email exist for register
        protected void emailCV_OnServerValidate(object source, ServerValidateEventArgs args)
        {
            var exist = _accountDb.CheckEmailExist(TB_regEmail.Text);
            if (!string.IsNullOrEmpty(TB_regEmail.Text))
            {
                if (exist)
                {
                    args.IsValid = false;

                    TB_regEmail.CssClass = "validate invalid";
                    lblregEmail.Attributes["data-error"] = "Email already exist";
                    string classname = "active";
                    lblregEmail.CssClass = String.Join(" ", lblregEmail.CssClass
                        .Split(' ')
                        .Except(new string[] {"", classname})
                        .Concat(new string[] {classname})
                        .ToArray()
                    );
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text",
                        "Materialize.updateTextFields()",
                        true);
                }
                else
                {
                    args.IsValid = true;
                }
            }
            else
            {
                args.IsValid = false;
                TB_regEmail.CssClass = "validate invalid";
                lblregEmail.Attributes["data-error"] = "Please enter email";
            }
        }

        // Check if password is correct or if user have enter text
        protected void loginPW_ServerValidation(object source, ServerValidateEventArgs args)
        {
            var correctPw = _accountDb.VerifyPw(TB_loginEmail.Text, TB_loginPw.Text);
            if (string.IsNullOrEmpty(TB_loginPw.Text))
            {
                args.IsValid = false;
                TB_loginPw.CssClass = "validate invalid";
                lblLoginPW.Attributes["data-error"] = "Please enter your password";
            }
            else
            {
                if (correctPw)
                {
                    args.IsValid = true;
                }
                else
                {
                    args.IsValid = false;
                    TB_loginPw.CssClass = "validate invalid";
                    lblLoginPW.Attributes["data-error"] = "Password is incorrect";
                }
            }

            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "Materialize.updateTextFields()",
                true);
        }

        protected void loginemailCV_OnServerValidate(object source, ServerValidateEventArgs args)
        {
            if (string.IsNullOrEmpty(TB_loginEmail.Text))
            {
                args.IsValid = false;
                TB_loginEmail.CssClass = "validate invalid";
                lblLoginEmail.Attributes["data-error"] = "Please enter your email";
            }
            else
            {
                // check if email exist
                args.IsValid = _accountDb.CheckEmailExist(TB_loginEmail.Text);
                if (args.IsValid == false)
                {
                    TB_loginEmail.CssClass = "validate invalid";
                    lblLoginEmail.Attributes["data-error"] = "AccountEntity does not exist";
                }
            }

            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "script", "Materialize.updateTextFields()",
                true);
        }

        protected void logoutBtn_OnClick(object sender, EventArgs e)
        {
            _accountDb.SetUserOffline(Session["email"].ToString());
            Session.Clear();
            FormsAuthentication.SignOut();
            Response.Redirect(Page.ResolveClientUrl("~/web/default.aspx"));
        }

        protected void regDOBCV_OnServerValidate(object source, ServerValidateEventArgs args)
        {
            if (string.IsNullOrEmpty(TB_regDOBs.Text))
            {
                args.IsValid = false;
                TB_regDOBs.CssClass = "datepicker invalid";
                lblregDOB.Attributes["data-error"] = "Please select date of birth";

                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "Refresh()",
                    true);
            }
            else
            {
                TB_regDOBs.CssClass = "datepicker";
                args.IsValid = true;
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "Refresh()",
                    true);
            }
        }

        protected void regPWCV_OnServerValidate(object source, ServerValidateEventArgs args)
        {
            string invalidcn = "invalid";
            if (string.IsNullOrEmpty(TB_regPW.Text))
            {
                args.IsValid = false;

                TB_regPW.CssClass = String.Join(" ", TB_regPW.CssClass
                    .Split(' ')
                    .Except(new[] {"", invalidcn})
                    .Concat(new[] {invalidcn})
                    .ToArray()
                );
                lblregPW.Attributes["data-error"] = "Please enter password";
            }
            else
            {
                if (TB_regPW.Text.Equals(TB_regRepeatPW.Text))
                {
                    args.IsValid = true;
                }
                else
                {
                    args.IsValid = false;
                    lblregPW.Attributes["data-error"] = "password is not the same";
                }
            }
        }

        protected void regRPWCV_OnServerValidate(object source, ServerValidateEventArgs args)
        {
            string invalidcn = "invalid";
            if (string.IsNullOrEmpty(TB_regRepeatPW.Text))
            {
                args.IsValid = false;
                TB_regRepeatPW.CssClass = String.Join(" ", TB_regRepeatPW.CssClass
                    .Split(' ')
                    .Except(new[] {"", invalidcn})
                    .Concat(new[] {invalidcn})
                    .ToArray()
                );
                lblregPWrepeat.Attributes["data-error"] = "Please enter password";
            }
            else
            {
                if (TB_regRepeatPW.Text.Equals(TB_regPW.Text))
                {
                    args.IsValid = true;
                }
                else
                {
                    args.IsValid = false;
                    TB_regRepeatPW.CssClass = String.Join(" ", TB_regRepeatPW.CssClass
                        .Split(' ')
                        .Except(new[] {"", invalidcn})
                        .Concat(new[] {invalidcn})
                        .ToArray()
                    );
                    lblregPWrepeat.Attributes["data-error"] = "password is not the same";
                }
            }
        }

        //Register : First Name Custom Validator Server Validation
        protected void regFNCV_OnServerValidate(object source, ServerValidateEventArgs args)
        {
            string invalidcn = "invalid";
            if (string.IsNullOrEmpty(TB_regFirstName.Text))
            {
                args.IsValid = false;
                TB_regFirstName.CssClass = String.Join(" ", TB_regFirstName.CssClass
                    .Split(' ')
                    .Except(new[] {"", invalidcn})
                    .Concat(new[] {invalidcn})
                    .ToArray()
                );
                lblregFirstName.Attributes["data-error"] = "please enter your first name";
            }
            else
            {
                args.IsValid = true;
            }
        }

        //Register : Last Name Custom Validator Server Validation
        protected void regLNCV_OnServerValidate(object source, ServerValidateEventArgs args)
        {
            string invalidcn = "invalid";
            if (string.IsNullOrEmpty(TB_regLastName.Text))
            {
                args.IsValid = false;
                TB_regLastName.CssClass = String.Join(" ", TB_regLastName.CssClass
                    .Split(' ')
                    .Except(new[] {"", invalidcn})
                    .Concat(new[] {invalidcn})
                    .ToArray()
                );
                lblregLastName.Attributes["data-error"] = "please enter your first name";
            }
            else
            {
                args.IsValid = true;
            }
        }

        protected void btnAgree_OnClick(object sender, EventArgs e)
        {
            Session["AgreeConsult"] = "true";
            Session["PatientEmail"] = pMailHidden.Value;
            pMailHidden.Value = "";
            Response.Redirect(ResolveClientUrl("~/web/Consultation/Chat.aspx"));
        }

        protected void dropdownnoti_OnServerClick(object sender, EventArgs e)
        {
            if (dropdownNoti.Visible == false)
            {
                NotificationDB notiDb = new NotificationDB();
                if (notiDb.GetNotificationsOfUser(Convert.ToString(Session["userID"])) != null)
                {
                    notiList = notiDb.GetNotificationsOfUser(Convert.ToString(Session["userID"]));
                    AppendNotification(notiList);
                }
            }
        }
    }
}