<%@ Page Title="" Language="C#" MasterPageFile="~/mainMenu.Master" AutoEventWireup="true" CodeBehind="incomeStatistics.aspx.cs" Inherits="EADP_Web_Dev.web.Finance.incomeStatistics" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 314px;
        }
        .auto-style2 {
            height: 22px;
            width: 314px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="http://code.jquery.com/jquery-1.8.2.js"></script>  
    <script src="http://www.google.com/jsapi" type="text/javascript"></script>
         <script type="text/javascript">           
        google.load('visualization', '1', { packages: ['corechart'] });  
    </script> 

      <script type="text/javascript">
          $(function () {
              $.ajax({
                  type: 'POST',
                  dataType: 'json',
                  contentType: 'application/json',
                  url: 'incomeStatistics.aspx/GetChartData',
                  data: '{}',
                  success:
                  function (response) {
                      drawchart(response.d);
                  },

                  error: function () {
                      alert("Error loading data!");
                  }
              });
          })

          function drawchart(dataValues) {
              var data = new google.visualization.DataTable();
              data.addColumn('string', 'Column Name');
              data.addColumn('number', 'Column Value');
              for (var i = 0; i < dataValues.length; i++) {
                  data.addRow([dataValues[i].incomeType, dataValues[i].totalIncomeAmt]);
              }
              new google.visualization.PieChart(document.getElementById('myChartDiv')).
                  draw(data, { title: "Income Details" });
          }
    </script> 
    <h2 style="text-align:center;font-family:'Lucida Handwriting'">&nbsp;Income Statistics.</h2>
    
      
    <div style ="margin:auto;">
        <table style="width: 100%;">
            <tr>
                <td style="width:60%;">
                     <div id="myChartDiv" style="height: 500px;">  
        </div>
                   
                </td>
                <td style="width:40%;">
                    <table style="width: 100%;;">
                        <tr>
                            <td class="auto-style1">&nbsp;</td>
                            <td style="width: 238px">&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style1">&nbsp;</td>
                            <td style="width: 238px">&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style1">&nbsp;</td>
                            <td style="width: 238px">&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style1">
                                <asp:Label ID="Label1" runat="server" Text="Total Number of Income:"  Font-Bold="False" Font-Size="Medium"></asp:Label>
                            </td>
                            <td style="width: 238px">
                                <asp:Label ID="LblNumber" runat="server" Font-Bold="true" Font-Size="Medium"></asp:Label>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style2">
                                &nbsp;</td>
                            <td style="width: 238px; height: 22px">
                                &nbsp;</td>
                            <td style="height: 22px"></td>
                        </tr>
                        <tr>
                            <td class="auto-style1">
                                <asp:Label ID="Label2" runat="server" Text="Total Income  Earned: "  Font-Bold="False" Font-Size="Medium"></asp:Label>
                            </td>
                            <td style="width: 238px">
                                <asp:Label ID="LblTotalIncome" runat="server" Font-Bold="true" Font-Size="Medium"></asp:Label>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style1">&nbsp;</td>
                            <td style="width: 238px">&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style1">
                                &nbsp;</td>
                            <td style="width: 238px">
                                &nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style1">&nbsp;</td>
                            <td style="width: 238px">
                                <asp:Button ID="expenseStatBtn" runat="server" CssClass="btn btn-info" OnClick="expenseStatBtn_Click" Text="View Expense" />
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                    </table>

                </td>
               
            </tr>
            <tr>
                <td style="width:60%;">
                     &nbsp;</td>
                <td style="width:40%;">
                    &nbsp;</td>
               
            </tr>
        </table>
                  
        </div>
    
  
</asp:Content>

