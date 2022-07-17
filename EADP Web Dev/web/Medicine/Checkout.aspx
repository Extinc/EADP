<%@ Page Title="" Language="C#" MasterPageFile="~/mainMenu.Master"  EnableEventValidation="false" AutoEventWireup="true" CodeBehind="Checkout.aspx.cs" Inherits="EADP_Web_Dev.web.Medicine.Checkout" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 500px;
            height: 400px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <script type="text/javascript">  
        function moveFocus(from, to) {  
            var length = from.value.length;  
            var maxLength = from.getAttribute("maxLength");  
            if (length == maxLength) {  
                document.getElementById(to).focus();  
            }  
        };  
    </script> 
    <head>
<link rel="stylesheet" href="<%= Page.ResolveClientUrl("~/CSS/Pharmacy/responsive.css") %>"/>
<link rel="stylesheet" href="<%= Page.ResolveClientUrl("~/Content/bootstrap.min.css") %>"/>
<link rel="stylesheet" href="<%= Page.ResolveClientUrl("~/CSS/Pharmacy/main.css") %>"/>
<link rel="stylesheet" href="<%= Page.ResolveClientUrl("~/CSS/Pharmacy/price-range.css") %>"/>
<link rel="stylesheet" href="<%= Page.ResolveClientUrl("~/CSS/Pharmacy/prettyPhoto.css") %>"/>
<link rel="stylesheet" href="<%= Page.ResolveClientUrl("~/CSS/Pharmacy/animate.css") %>"/>
</head><!--/head-->

			<div class="shopper-informations">
				<div class="row">
					<div class="col-sm-5 clearfix">
						<div class="bill-to">
							<p>Customer Information</p>
							<div class="form-one">
								<form>
									<input type="text" id="txtName" runat="server" placeholder="Name*"/>
                                    <asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server"
                                    ControlToValidate="txtName" ErrorMessage="Name is a required field." ForeColor="Red">
                                    </asp:RequiredFieldValidator>
									<input type="text" id="txtAddress" runat="server" placeholder="Address*"/>
                                    <asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server"
                                    ControlToValidate="txtAddress" ErrorMessage="Address is a required field." ForeColor="Red">
                                    </asp:RequiredFieldValidator>
                                    <input type="text" id="txtphone" runat="server" maxlength="8" placeholder="Mobile Phone"/>
									<input type="text" id="txtEmail" runat="server" placeholder="Email Address"/>
								</form>

							</div>
							</div>
						</div>
                    <p>
                        &nbsp;</p>
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="medID" DataSourceID="SqlDataSource1" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" Height="500px" Width="700px">
                        <Columns>
                            <asp:BoundField DataField="medID" HeaderText="Medicine ID" ReadOnly="True" SortExpression="medID" />
                            <asp:BoundField DataField="medName" HeaderText="Medicine Name" SortExpression="medName" >
                            <ItemStyle Font-Italic="True" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Amount" HeaderText="Quantity" SortExpression="Amount" />
                            <asp:BoundField DataField="medPrice" HeaderText="Price" SortExpression="medPrice" />
                            <asp:BoundField DataField="total" HeaderText="Total Amount" SortExpression="total" >
                            <ItemStyle Font-Bold="True" Font-Size="Medium" />
                            </asp:BoundField>
                        </Columns>
                        <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                        <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                        <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F7F7F7" />
                        <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                        <SortedDescendingCellStyle BackColor="#E5E5E5" />
                        <SortedDescendingHeaderStyle BackColor="#242121" />
                    </asp:GridView>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Medicine %>" SelectCommand="SELECT * FROM [MedCart]"></asp:SqlDataSource>
&nbsp;
					<br />
					</div>
                </div>
			<div class="payment-options">
                    <asp:Label ID="lblTotal" runat="server" Font-Bold="True" Font-Names="Arial Black" ></asp:Label>
					<br />
					Payment Options<br />

                    <asp:RadioButton ID="btnDelivery" runat="server" Text="Home Delivery"  GroupName="grp1"/>
                    <asp:RadioButton ID="btnPickup" runat="server" Text="Item Pick up" GroupName="grp1"/>
                    <br />
        <div id="creditCardDetailsTextboxes" class="auto-style1">
                    <asp:Label ID="lblMaster" runat="server"></asp:Label>
                    <asp:Label ID="lblVisa" runat="server"></asp:Label>
                    <br />
            Enter Card Number:  
            <asp:TextBox ID="TextBox1" runat="server"  MaxLength="4" Width="50px" onkeyup="moveFocus(this,'TextBox2')"></asp:TextBox>  
            <asp:TextBox ID="TextBox2" runat="server"  MaxLength="4" Width="50px" onkeyup="moveFocus(this,'TextBox3')"></asp:TextBox>  
            <asp:TextBox ID="TextBox3" runat="server"  MaxLength="4" Width="50px" onkeyup="moveFocus(this,'TextBox4')"></asp:TextBox>  
            <asp:TextBox ID="TextBox4" runat="server"  MaxLength="4" Width="50px"></asp:TextBox>
                    <asp:Button ID="btnCheck" runat="server" OnClick="btnCheck_Click" Text="Check" />
                    <br />
                    <asp:Label ID="lblErr1" runat="server" Font-Italic="True" ForeColor="Red"></asp:Label>
            <br />
            Enter Card Name:
            <asp:TextBox ID="TextBox5" runat="server" Width="150px"></asp:TextBox>
                    <br />
                    <br />
                    <asp:Label ID="Label1" runat="server" Text="Expiry date: "></asp:Label>
                    <asp:TextBox ID="txtMM" runat="server" MaxLength="2" placeholder="MM" Width="30px" Height="30px"></asp:TextBox>
                    /<asp:TextBox ID="txtYear" runat="server" MaxLength="4" placeholder="YYYY" Width="50px" Height="30px"></asp:TextBox>
                    <br />
                    <br />
                    <asp:Label ID="Label2" runat="server" Text="CVV: "></asp:Label>
                    <asp:TextBox ID="txtCVV" runat="server" placeholder ="3 Digit CVV" MaxLength="3" Width="100px"></asp:TextBox>
                    
                    <br />
                    <asp:Label ID="lblDelivery" runat="server" Text="" Visible="False" Font-Bold="True" Font-Italic="True" Font-Names="Arial Black"></asp:Label>
                    
                    <br />
                    
            <asp:Button ID="btnTest" runat="server" OnClick="btnTest_Click" Text="Continue" />
                    
        </div> 
  </div>

</asp:Content>
