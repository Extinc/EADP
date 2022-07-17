using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EADP_Web_Dev.Code;
using EADP_Web_Dev.Code.Community;
using Newtonsoft.Json;

namespace EADP_Web_Dev.web.CommunityEvent
{
    public partial class CreateCommEvent : System.Web.UI.Page
    {
        ComEvent _comEvent = new ComEvent();
        AccountDb _accountDb = new AccountDb();
        protected string Otheremail { get; set; }
        protected Array[] InterestArrays { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            StringBuilder emailBuilder = new StringBuilder();

            if (!(_accountDb.GetAllOtherEmail(Session["email"].ToString())).All(string.IsNullOrWhiteSpace))
            {
                var emails = _accountDb.GetAllOtherEmail(Session["email"].ToString());
                foreach (var email in emails)
                {
                    emailBuilder.Append("'" + email + "':null,");
                    emailBuilder.AppendLine();
                }
                    
                Otheremail = emailBuilder.ToString();
                Debug.WriteLine("No Null !!!");
            }
        }

        protected void CreateEvents(object sender, EventArgs e)
        {
            Page.Validate("CEvent");
            if (Page.IsValid)
            {
                var eventTitle = tbEvent.Text;
                DateTime dateTime = Convert.ToDateTime(tbDate.Text);
                TimeSpan startTime;
                if (string.IsNullOrEmpty(tbTime.Text))
                {
                    startTime = TimeSpan.Parse("00:00");
                }
                else
                {
                    startTime = TimeSpan.Parse(tbTime.Text);
                }

                dateTime = dateTime.Add(startTime);

                TimeSpan endTime;

                if (string.IsNullOrEmpty(tbEndTime.Text))
                {
                    endTime = TimeSpan.Parse("00:00");
                }
                else
                {
                    endTime = TimeSpan.Parse(tbEndTime.Text);
                }


                DateTime enddateTime = Convert.ToDateTime(tbEndDate.Text);
                enddateTime = enddateTime.Add(endTime);
                List<string> inviteList = new List<string>();
                if (!string.IsNullOrEmpty(inputInviteHidden.Value))
                {
                    inviteList = inputInviteHidden.Value.Split(',').ToList();
                }

                DateTime startDT = new DateTime();
                Community community = new Community
                {
                    EventTitle = eventTitle,
                    StartDateTime = dateTime,
                    EndDateTime = enddateTime,
                    EventInvitees = inviteList
                };

                //TODO: Debug writeline to be removed
                Debug.WriteLine(enddateTime.Date.Day + " ,  " + enddateTime.Hour);

                _comEvent.CreateEvent(community, Session["userID"].ToString());
                if (!inviteList.All(string.IsNullOrWhiteSpace))
                { 
                    Session["InviteList"] = inviteList;
                }
                Response.Redirect(Page.ResolveClientUrl("~/web/CommunityEvent/CommunityEvent.aspx"), false);
            }
        }

        public void InterestArrays1(Array[] arrayStrings)
        {
            InterestArrays = arrayStrings;
        }

        protected void EventTitleCV_OnServerValidate(object source, ServerValidateEventArgs args)
        {
            string invalidcn = "invalid";
            if (string.IsNullOrEmpty(tbEvent.Text))
            {
                args.IsValid = false;
                tbEvent.CssClass = String.Join(" ", tbEvent.CssClass
                    .Split(' ')
                    .Except(new[] {"", invalidcn})
                    .Concat(new[] {invalidcn})
                    .ToArray()
                );
                lblEventTitle.Attributes["data-error"] = "Please enter the event title";
            }
            else
            {
/*                tbEvent.CssClass = String.Jo  in(" ", tbEvent.CssClass
                    .Split(' ')
                    .Except(new[] { "", invalidcn })
                    .ToArray()
                );*/

                args.IsValid = true;
            }
        }

        protected void EventDateCV_OnServerValidate(object source, ServerValidateEventArgs args)
        {
            DateTime dt;
            string invalidcn = "invalid";
            if (!DateTime.TryParse(tbDate.Text, out dt) || string.IsNullOrEmpty(tbDate.Text))
            {
                args.IsValid = false;
                tbDate.CssClass = String.Join(" ", tbDate.CssClass
                    .Split(' ')
                    .Except(new[] {"", invalidcn})
                    .Concat(new[] {invalidcn})
                    .ToArray()
                );
                lblEventSDate.Attributes["data-error"] = "Please select event start date";
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "refresh()",
                    true);
                Debug.WriteLine("EventDateCV : " + !DateTime.TryParse(tbDate.Text, out dt));
            }
            else
            {
                var inputs = "#" + tbDate.ClientID;

                tbDate.CssClass = String.Join(" ", tbDate.CssClass
                    .Split(' ')
                    .Except(new[] {"", invalidcn})
                    .ToArray()
                );
                lblEventSDate.CssClass = String.Join(" ", lblEventSDate.CssClass
                    .Split(' ')
                    .Except(new[] {"", invalidcn})
                    .Concat(new[] {"active"})
                    .ToArray()
                );
                args.IsValid = true;
            }
        }

        protected void EventEndDateCV_OnServerValidate(object source, ServerValidateEventArgs args)
        {
            DateTime dt;
            string invalidcn = "invalid";
            if (!DateTime.TryParse(tbEndDate.Text, out dt) || string.IsNullOrEmpty(tbEndDate.Text))
            {
                args.IsValid = false;

                tbEndDate.CssClass = String.Join(" ", tbEndDate.CssClass
                    .Split(' ')
                    .Except(new[] {"", invalidcn})
                    .Concat(new[] {invalidcn})
                    .ToArray()
                );
                lblEventEDate.Attributes["data-error"] = "Please select event end date";
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "refresh()",
                    true);
            }
            else
            {
/*                tbEndDate.CssClass = String.Join(" ", tbEndDate.CssClass
                    .Split(' ')
                    .Except(new[] { "", invalidcn })
                    .ToArray()
                );*/
                lblEventEDate.CssClass = String.Join(" ", lblEventEDate.CssClass
                    .Split(' ')
                    .Except(new[] {"", invalidcn})
                    .Concat(new[] {"active"})
                    .ToArray()
                );
                args.IsValid = true;
            }
        }
    }
}