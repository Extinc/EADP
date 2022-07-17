using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.WebSockets;
using EADP_Web_Dev.Code.Consultation;

namespace EADP_Web_Dev.web.Consultation
{
    public partial class Chat : System.Web.UI.Page
    {
        string docemail;
        static ConsultationDAO _consultationDao = new ConsultationDAO();
        static HtmlGenericControl msgul = new HtmlGenericControl {TagName = "ul", ID = "messageUL"};
        
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["userID"] == null &&
                Session["email"] == null &&
                Session["roleID"] == null)
            {
                Response.Redirect(ResolveClientUrl("~/web/error.aspx"));
            }
            else
            {
                msgul.Attributes["class"] = "collection";
                chatPanel.Controls.Add(msgul);
                docemail = Convert.ToString(Request.QueryString["docemail"]);
                string targetemail = Convert.ToString(Request.QueryString["targetemail"]);
                if (!string.IsNullOrEmpty(docemail))
                {

                    StringBuilder sb = new StringBuilder();
                    string useremail = Convert.ToString(Session["email"]);
                    HtmlGenericControl userCl = new HtmlGenericControl
                    {
                        TagName = "li",
                        ID = "userId"
                    };
                    userCl.Attributes["class"] = "collection-item";
                    userCl.InnerHtml = useremail;
                    HtmlGenericControl doctorCl = new HtmlGenericControl
                    {
                        TagName = "li",
                        ID = "doctorId"
                    };
                    doctorCl.Attributes["class"] = "collection-item";
      
                    doctorCl.InnerHtml = docemail;
                    userUL.Controls.Add(userCl);
                    userUL.Controls.Add(doctorCl);
                    AppendLi(_consultationDao.GetChatMessage(Convert.ToInt32(Session["chatID"])), docemail);
                }

                if (!string.IsNullOrEmpty(targetemail))
                {
                    StringBuilder sb = new StringBuilder();
                    HtmlGenericControl userCl = new HtmlGenericControl
                    {
                        TagName = "li",
                        ID = "userId"
                    };
                    userCl.Attributes["class"] = "collection-item";
                    userCl.InnerHtml = targetemail;
                    HtmlGenericControl doctorCl = new HtmlGenericControl
                    {
                        TagName = "li",
                        ID = "doctorId"
                    };
                    doctorCl.Attributes["class"] = "collection-item";

                    doctorCl.InnerHtml = Session["email"] as string;
                    userUL.Controls.Add(userCl);
                    userUL.Controls.Add(doctorCl);
                    AppendLi(_consultationDao.GetChatMessage(Convert.ToInt32(Session["chatID"])), Convert.ToString(Session["email"]));
                }
            }
        }

        [WebMethod]
        public static void AppendLi(List<Consultations> consultsList, string dEmail)
        {
            Debug.WriteLine("AppendLI YEAH 123");

            List<Consultations> consult = consultsList;
            var dmail = "";
            dmail = Convert.ToString(HttpContext.Current.Request.QueryString["docemail"]);
            Debug.WriteLine(dmail);
            string targetemail = Convert.ToString(HttpContext.Current.Request.QueryString["targetemail"]);
            if (!string.IsNullOrEmpty(dmail))
            {
                if (consult.Count > 0)
                {
                    foreach (var c in consult)
                    {
                        HtmlGenericControl liCollect = new HtmlGenericControl { TagName = "li" };
                        liCollect.Attributes["class"] = "collection-item";

                        HtmlGenericControl row1 = new HtmlGenericControl { TagName = "div" };

                        HtmlGenericControl row2 = new HtmlGenericControl { TagName = "div" };
                        row2.Attributes["class"] = "row";
                        HtmlGenericControl colfRow2DT = new HtmlGenericControl { TagName = "div" };
                        HtmlGenericControl colfRow2Name = new HtmlGenericControl { TagName = "div" };

                        HtmlGenericControl row1p = new HtmlGenericControl { TagName = "p" };
                        row1p.InnerText = c.Message;

                        HtmlGenericControl row2p = new HtmlGenericControl { TagName = "p" };
                        HtmlGenericControl row2p1 = new HtmlGenericControl { TagName = "p" };

                        row2p.Attributes["style"] = "width:100%;";

                        DateTime dt = c.Timestamp;
                        row2p.InnerText = dt.ToShortDateString() + " " + dt.ToShortTimeString();

                        if (c.UserId == Convert.ToInt32(HttpContext.Current.Session["userID"]))
                        {
                            row1p.Attributes["class"] = "row text-right";
                            colfRow2DT.Attributes["class"] = "col-sm-6 text-left";
                            row2p.Attributes["class"] = "text-left";
                            colfRow2Name.Attributes["class"] = "col-sm-6 text-right";
                            row2p1.Attributes["class"] = "text-right";
                            row2p.InnerText = c.Timestamp.ToShortDateString() + " " + c.Timestamp.ToShortTimeString();
                            row2p1.InnerText = HttpContext.Current.Session["email"] as string;

                        }
                        else
                        {
                            row1p.Attributes["class"] = "text-left";
                            colfRow2DT.Attributes["class"] = "col-sm-6 text-left";
                            row2p.Attributes["class"] = "text-left";
                            colfRow2Name.Attributes["class"] = "col-sm-6 text-right";
                            row2p1.Attributes["class"] = "text-right";
                            row2p.InnerText = dEmail;
                            Debug.WriteLine(dEmail);
                            row2p1.InnerText = c.Timestamp.ToShortDateString() + " " + c.Timestamp.ToShortTimeString();
                        }

                        row2p.Attributes["style"] = "color:#999";
                        row2p1.Attributes["style"] = "color:#999";
                        liCollect.Controls.Add(row1);
                        liCollect.Controls.Add(row2);
                        row1.Controls.Add(row1p);
                        row2.Controls.Add(colfRow2DT);
                        row2.Controls.Add(colfRow2Name);
                        colfRow2DT.Controls.Add(row2p);
                        colfRow2Name.Controls.Add(row2p1);
                        Page page = HttpContext.Current.CurrentHandler as Page;
                        /*                        Panel chatPane = (Panel)page.FindControl("chatPanel");
                                                HtmlGenericControl htmlGeneric = (HtmlGenericControl) chatPane.Controls[0].FindControl("messageUL");*/
                        msgul.Controls.Add(liCollect);
                    }
                }
            }

            if (!string.IsNullOrEmpty(targetemail))
            {
                if (consult.Count > 0)
                {
                    foreach (var c in consult)
                    {
                        HtmlGenericControl liCollect = new HtmlGenericControl { TagName = "li" };
                        liCollect.Attributes["class"] = "collection-item";

                        HtmlGenericControl row1 = new HtmlGenericControl { TagName = "div" };

                        HtmlGenericControl row2 = new HtmlGenericControl { TagName = "div" };
                        row2.Attributes["class"] = "row";
                        HtmlGenericControl colfRow2DT = new HtmlGenericControl { TagName = "div" };
                        HtmlGenericControl colfRow2Name = new HtmlGenericControl { TagName = "div" };

                        HtmlGenericControl row1p = new HtmlGenericControl { TagName = "p" };
                        row1p.InnerText = c.Message;

                        HtmlGenericControl row2p = new HtmlGenericControl { TagName = "p" };
                        HtmlGenericControl row2p1 = new HtmlGenericControl { TagName = "p" };

                        row2p.Attributes["style"] = "width:100%;";

                        DateTime dt = c.Timestamp;
                        row2p.InnerText = dt.ToShortDateString() + " " + dt.ToShortTimeString();

                        if (c.UserId == Convert.ToInt32(HttpContext.Current.Session["userID"]))
                        {
                            row1p.Attributes["class"] = "row text-right";
                            colfRow2DT.Attributes["class"] = "col-sm-6 text-left";
                            row2p.Attributes["class"] = "text-left";
                            colfRow2Name.Attributes["class"] = "col-sm-6 text-right";
                            row2p1.Attributes["class"] = "text-right";
                            row2p.InnerText = c.Timestamp.ToShortDateString() + " " + c.Timestamp.ToShortTimeString();
                            row2p1.InnerText = HttpContext.Current.Session["email"] as string;

                        }
                        else
                        {
                            row1p.Attributes["class"] = "text-left";
                            colfRow2DT.Attributes["class"] = "col-sm-6 text-left";
                            row2p.Attributes["class"] = "text-left";
                            colfRow2Name.Attributes["class"] = "col-sm-6 text-right";
                            row2p1.Attributes["class"] = "text-right";
                            row2p.InnerText = targetemail;
                            row2p1.InnerText = c.Timestamp.ToShortDateString() + " " + c.Timestamp.ToShortTimeString();
                        }

                        row2p.Attributes["style"] = "color:#999";
                        row2p1.Attributes["style"] = "color:#999";
                        liCollect.Controls.Add(row1);
                        liCollect.Controls.Add(row2);
                        row1.Controls.Add(row1p);
                        row2.Controls.Add(colfRow2DT);
                        row2.Controls.Add(colfRow2Name);
                        colfRow2DT.Controls.Add(row2p);
                        colfRow2Name.Controls.Add(row2p1);
                        Page page = HttpContext.Current.CurrentHandler as Page;
                        /*                        Panel chatPane = (Panel)page.FindControl("chatPanel");
                                                HtmlGenericControl htmlGeneric = (HtmlGenericControl)chatPane.Controls[0].FindControl("messageUL");*/
                        msgul.Controls.Add(liCollect);
                    }
                }
            }

        }

        [WebMethod]
        public static void MethodAppendLi()
        {
            Debug.WriteLine("MethodAppendLI YEAH");
            var dmail = "";
            dmail = Convert.ToString(HttpContext.Current.Request.QueryString["docemail"]);
            string targetemail = Convert.ToString(HttpContext.Current.Request.QueryString["targetemail"]);
            if (!string.IsNullOrEmpty(dmail))
            {
                AppendLi(_consultationDao.GetChatMessage(Convert.ToInt32(HttpContext.Current.Session["chatID"])), dmail);
            }

            if (!string.IsNullOrEmpty(targetemail))
            {
                AppendLi(_consultationDao.GetChatMessage(Convert.ToInt32(HttpContext.Current.Session["chatID"])), Convert.ToString(HttpContext.Current.Session["email"]));
            }

        }


        public string GetDocEmail()
        {
            string demail = "";
            docemail = Convert.ToString(Request.QueryString["docemail"]);
            if (!string.IsNullOrEmpty(docemail))
            {
                demail = docemail;
            }
            return demail;
        }

        protected void btnSend_OnClick(object sender, EventArgs e)
        {
            int noticount = 0;

            
            if (Request.QueryString["docemail"] != null)
            {
                docemail = Convert.ToString(Request.QueryString["docemail"]);
            }
            else
            {
                docemail = Convert.ToString(Request.QueryString["targetemail"]);
            }

            _consultationDao.InsertMessage(tb_Message.Text, Convert.ToInt32(Session["userID"]), Convert.ToInt32(Session["chatID"]));
            _consultationDao.InsertChatNotification(tb_Message.Text, Convert.ToInt32(Session["userID"]), docemail);
            AppendLi(_consultationDao.GetChatMessage(Convert.ToInt32(Session["chatID"])), docemail);

            StringBuilder sb = new StringBuilder();
            sb.Append("$(function(){");
            sb.AppendLine("var chatInvite = $.connection.chatHub;");
            sb.AppendLine("var noti = $.connection.notificationHub;");
            sb.AppendLine("$.connection.hub.start().done(function() {");
            sb.AppendLine("console.log('connect');");
            sb.AppendLine(
                $"chatInvite.server.sendPrivate(\"{tb_Message.Text}\", \"{docemail}\")");
            sb.AppendLine(
                $"noti.server.send(\"{tb_Message.Text}\", \"{Convert.ToInt32(Session["userID"])}\", \"chat\", \"{_consultationDao.GetChatMessage(Convert.ToInt32(Session["chatID"])).Count}\")");
            sb.AppendLine("console.log(\"" + docemail + "\");");
            sb.AppendLine("});");
            sb.AppendLine("});");
            ScriptManager.RegisterStartupScript(Page, GetType(), "text", sb.ToString(),
                true);
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            MethodAppendLi();
            chatUpdatePanel.Update();
        }
    }
}