using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using EADP_Web_Dev;
using EADP_Web_Dev.Code;
using EADP_Web_Dev.Code.Consultation;

namespace EADP_Web_Dev.web.Consultation
{
    public partial class Consultation : System.Web.UI.Page
    {
        private ConsultationDAO _cDao = new ConsultationDAO();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userID"] == null &&
                Session["email"] == null &&
                Session["roleID"] == null)
            {
            }
            else
            {
                if (_cDao.GetDoctors(Convert.ToInt32(Session["userID"])).Count > 0)
                {
                    int i = 0;
                    List<Consultations> consultation = _cDao.GetDoctors(Convert.ToInt32(Session["userID"]));
                    foreach (var doctor in consultation)
                    {
                        HtmlGenericControl dAvailableCard = new HtmlGenericControl {TagName = "div"};
                        dAvailableCard.Attributes["class"] = "card col-sm-12";

                        #region Card Content

                        HtmlGenericControl dAvailableCardContent = new HtmlGenericControl {TagName = "div"};
                        dAvailableCardContent.Attributes["class"] = "card-content";

                        HtmlGenericControl doctorNamecard = new HtmlGenericControl();
                        doctorNamecard.TagName = "p";
                        doctorNamecard.InnerHtml = "Dr " + doctor.Doctors.FirstName;

                        dAvailableCardContent.Controls.Add(doctorNamecard);

                        #endregion

                        #region Card Action

                        HtmlGenericControl dAvailableCardAction = new HtmlGenericControl {TagName = "div"};
                        dAvailableCardAction.Attributes["class"] = "card-action";
                        dAvailableCardAction.Attributes["runat"] = "server";

                        // Button to have Conversation/Conference with doctors
                        Button btn = new Button
                        {
                            ID = "btnChat" + i,
                            Text = "Chat"
                        };

                        btn.Click += OpenChat;
                        HiddenField hfDocEmail = new HiddenField
                        {
                            ID = "hfDocEmail" + i,
                            Value = doctor.Doctors.Email
                        };


                        dAvailableCardAction.Controls.Add(btn);
                        dAvailableCardAction.Controls.Add(hfDocEmail);

                        #endregion

                        dAvailableCard.Controls.Add(dAvailableCardContent);
                        dAvailableCard.Controls.Add(dAvailableCardAction);
                        divdocAvail.Controls.Add(dAvailableCard);
                        i++;
                       
                        Debug.WriteLine("DOCTORS : " + doctor.Doctors.Email);
                    }
                }
            }
        }

        protected void OpenChat(object sender, EventArgs e)
        {
            var btn = sender as Button;
            HiddenField controls = (HiddenField) btn.Parent.FindControl("hfDocEmail" + btn.ID.Substring(7));
            //TODO: To be removed
            Debug.WriteLine("Siblings : " + controls.Value);
            _cDao.CreateNewChat(Convert.ToInt32(Session["userID"]), controls.Value);
            Session["chatID"] = _cDao.GetChatId(Convert.ToInt32(Session["userID"]), controls.Value);
            Debug.WriteLine("ChatID : " + Session["chatID"]);
            Response.Redirect(Page.ResolveClientUrl("~/web/Consultation/Chat.aspx")+"?docemail="+ controls.Value);
        }
    }
}