using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using EADP_Web_Dev.Code.Community;

namespace EADP_Web_Dev.web.CommunityEvent
{
    public partial class CommunityEvent : System.Web.UI.Page
    {
        ComEvent _comEvent = new ComEvent();

        protected void Page_Load(object sender, EventArgs e)
        {
            // Check if user is logged in on page load
            if (Session["userID"] == null &&
                Session["email"] == null &&
                Session["roleID"] == null)
            {
                Response.Redirect(Page.ResolveClientUrl("~/web/error.aspx"));
            }
            else
            {
                if (Session["inviteList"] != null || string.IsNullOrEmpty(Session["inviteList"] as string))
                {
                    List<string> inviteList = (List<string>) Session["inviteList"];
                    if (inviteList != null)
                        foreach (var invitees in inviteList)
                        {
                            StringBuilder sb = new StringBuilder();
                            sb.Append("$(function(){");
                            sb.AppendLine("var notification = $.connection.notificationHub; ");
                            sb.AppendLine(" $.connection.hub.start().done(function() { ");
                            sb.AppendLine("notification.server.send(\"You have been invited\",\"" + invitees + "\", \"noti\", \"0\");");
                            sb.AppendLine("});");
                            sb.AppendLine("});");
                            ScriptManager.RegisterStartupScript(Page, GetType(), "text", sb.ToString(),
                                true);
                        }
                }

                if (_comEvent.GetUserCreatedEvent(Session["userID"]?.ToString()).Count > 0)
                {
                    List<Community> comList = _comEvent.GetUserCreatedEvent(Session["userID"]?.ToString());
                    foreach (var community in comList)
                    {

                        HtmlGenericControl tooltipCard = new HtmlGenericControl{TagName = "a"};
                        tooltipCard.Attributes["class"] = "btn tooltipped";
                        tooltipCard.Attributes["data-position"] = "right";
                        tooltipCard.Attributes["data-delay"] = "right";


                        #region Card

                        HtmlGenericControl eventCard = new HtmlGenericControl {TagName = "div"};
                        eventCard.Attributes["class"] = "card col-sm-3";
                        eventCard.Attributes["style"] = "margin-left:15px;";
                        #endregion

                        #region Card Panel

                        HtmlGenericControl cardPanel = new HtmlGenericControl
                        {
                            TagName = "div",
                        };
                        cardPanel.Attributes["class"] =
                            "card-panel activator teal waves-effect waves-block waves-light tooltipped";
     /*                   cardPanel.Attributes["class"] = "btn ";*/
                        cardPanel.Attributes["data-position"] = "right";
                        cardPanel.Attributes["data-delay"] = "50";
                        cardPanel.Attributes["data-tooltip"] = "click for more information";
                        
                        Label lblCpTitle = new Label
                        {
                            CssClass = "white-text",
                            Text = community.EventTitle
                        };
                        cardPanel.Controls.Add(lblCpTitle);

                        #endregion

                        #region Card Content

                        HtmlGenericControl cardContent = new HtmlGenericControl {TagName = "div"};
                        cardContent.Attributes["class"] = "card-content";

                        Label lblStartDate = new Label
                        {
                            Text = community.StartDateTime.Date.ToString("d"),
                            CssClass = "card-title activator grey-text text-darken-4"
                        };
                        Label lblevtCreator = new Label
                        {
                            /*   Text = community.Members,*/
                            CssClass = "card-title activator grey-text text-darken-4"
                        };
                        cardContent.Controls.Add(lblStartDate);
                        cardContent.Controls.Add(lblevtCreator);

                        #endregion

                        #region Card Reveal

                        HtmlGenericControl cardReveal = new HtmlGenericControl {TagName = "div"};
                        cardReveal.Attributes["class"] = "card-reveal";

                        HtmlGenericControl closeicon = new HtmlGenericControl {TagName = "i"};
                        closeicon.Attributes["class"] = "material-icons right";
                        closeicon.InnerHtml = "close";

                        Label lbltitleReveal = new Label
                        {
                            CssClass = "card-title grey-text text-darken-4",
                            Text = community.EventTitle + " <i class=\"material-icons right\">more_vert</i>"
                        };

                        Label lblcontentReveal = new Label();
/*                        if (!community.Members.All(string.IsNullOrEmpty))
                        {
                            lblcontentReveal.Text = "Members : " + string.Join(",", community.Members);
                        }
                        else
                        {
                            lblcontentReveal.Text = "Members : Not Members";
                        }*/

                        cardReveal.Controls.Add(lbltitleReveal);
                        cardReveal.Controls.Add(lblcontentReveal);

                        #endregion

                        //TODO: Remove Debug.Writeline
                        Debug.WriteLine("Community : " + community.EventTitle);

                        eventCard.Controls.Add(cardPanel);
                        eventCard.Controls.Add(cardContent);
                        eventCard.Controls.Add(cardReveal);
                        CEHolder.Controls.Add(eventCard);
                    }
                }
            }
        }
    }
}