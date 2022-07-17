using System;
using EADP_Web_Dev.Code.Finance;

namespace EADP_Web_Dev.web.Finance.ADMIN
{
    public partial class Schemes : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnCreate_Click(object sender, EventArgs e)
        {
           
            string schemeName = schemeNameTextBox.Text.ToString();
            double monthlyHouseLimit = Convert.ToDouble(maxLimitTextbox.Text.ToString());
            string schemeDetails = detailsTextBox.Text.ToString();

            try
            {
                //if user did not select an option
                string schemeType = schemeTypeDropDownList.SelectedItem.ToString();

                //calling the class to insert record into database
                schemeAvailabilityDAO avaiDAO = new schemeAvailabilityDAO();
                int inst = avaiDAO.insertAvailableScheme(schemeName, monthlyHouseLimit, schemeDetails, schemeType);

                //if record is inserted else ...
                if (inst == 1)
                {
                    schemeAvailability avalObj = new schemeAvailability();
                    schemeAvailabilityDAO avalDAO = new schemeAvailabilityDAO();

                    avalObj = avalDAO.getSchemeCreated();
                    Lbl_TypeScheme.Text = avalObj.schemeType;
                    Lbl_SchemeName.Text = avalObj.schemeName;
                    Lbl_MaxLimit.Text = avalObj.monthlyHouseLimit.ToString();
                    Lbl_Details.Text = avalObj.schemeDetails;

                    // clear entry so that new entry can be inputted by the user
                   schemeTypeDropDownList.SelectedIndex = 0;
                   schemeNameTextBox.Text = "";
                   detailsTextBox.Text = "";
                    maxLimitTextbox.Text = "";

                    Response.Write("You have successfully created a record!");

                }
                else
                {
                    Response.Write("Unable to insert expense record !");
                }

            }
            catch (FormatException)
            {
                Response.Write("Please fill in all necessary information!");
            }

        }



    }
}