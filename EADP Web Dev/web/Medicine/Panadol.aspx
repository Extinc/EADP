<%@ Page Title="" Language="C#" MasterPageFile="~/mainMenu.Master" AutoEventWireup="true" CodeBehind="Panadol.aspx.cs" Inherits="EADP_Web_Dev.web.Medicine.Product_Details" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <head>
<link rel="stylesheet" href="<%= Page.ResolveClientUrl("~/CSS/Pharmacy/responsive.css") %>"/>
<link rel="stylesheet" href="<%= Page.ResolveClientUrl("~/Content/bootstrap.min.css") %>"/>
<link rel="stylesheet" href="<%= Page.ResolveClientUrl("~/CSS/Pharmacy/main.css") %>"/>
<link rel="stylesheet" href="<%= Page.ResolveClientUrl("~/CSS/Pharmacy/price-range.css") %>"/>
<link rel="stylesheet" href="<%= Page.ResolveClientUrl("~/CSS/Pharmacy/prettyPhoto.css") %>"/>
<link rel="stylesheet" href="<%= Page.ResolveClientUrl("~/CSS/Pharmacy/animate.css") %>"/>
</head><!--/head-->

<body>
	
<section>
		<div class="container">
			<div class="row">
				<div class="col-sm-3">
					<div class="left-sidebar">
						<h2 style="margin-top:20px;">Category</h2>
						<div class="panel-group category-products" id="accordian"><!--category-productsr-->

							
							<div class="panel panel-default">
								<div class="panel-heading">
									<h4 class="panel-title"><a href="#">Medicine</a></h4>
								</div>
							</div>
							<div class="panel panel-default">
								<div class="panel-heading">
									<h4 class="panel-title"><a href="#">Health Supplements</a></h4>
								</div>
							</div>
							<div class="panel panel-default">
								<div class="panel-heading">
									<h4 class="panel-title"><a href="#">Nutritional</a></h4>
								</div>
							</div>
							<div class="panel panel-default">
								<div class="panel-heading">
									<h4 class="panel-title"><a href="#">Home Care</a></h4>
								</div>
							</div>
							<div class="panel panel-default">
								<div class="panel-heading">
									<h4 class="panel-title"><a href="#">Personal Care</a></h4>
								</div>
							</div>
						</div><!--/category-productsr-->
					
						<div class="brands_products"><!--brands_products-->
							<h2>Brands</h2>
							<div class="brands-name">
								<ul class="nav nav-pills nav-stacked white" >
									<li><a href=""> <span class="pull-right">(12)</span>paracetamol</a></li>
									<li><a href=""> <span class="pull-right">(8)</span>Aspirin</a></li>
									<li><a href=""> <span class="pull-right">(11)</span>Acetaminophen</a></li>
									<li><a href=""> <span class="pull-right">(5)</span>Certainty(adult diaper)</a></li>
									<li><a href=""> <span class="pull-right">(5)</span>Aleve</a></li>
								</ul>
							</div>
						</div><!--/brands_products-->
						
					</div>
				</div>
				
				<div class="col-sm-9 padding-right">
					<div class="product-details"><!--product-details-->
						<div class="col-sm-7">
							<div class="product-information"><!--/product-information-->
                                <h2>
                                    <asp:Label ID="lblName" runat="server" Text="Panadol Cold Relief"></asp:Label>
                                </h2>
								<asp:Label ID="lblID" runat="server"></asp:Label>
								<br />
								<asp:Button ID="btnCart" runat="server" OnClick="btnCart_Click" Text="Cart" class="btnCart"/>
								<br />
								<img src="../../Images/panadol.png" />
                                <br />
                                
                                <span>
                                    <asp:Label ID="Label1" runat="server" Text="Price: $" style=" margin-right: 0px; font-size: medium; font-weight: bold; font-style: oblique;" ForeColor="#666666"></asp:Label>
                                    <Label ID="lblprice" runat="server" Text="" style=" padding-right:450px; font-size: medium; font-weight: bold; font-style: oblique;">
                                <br />
                                </Label>
                                    <Label ID="lblquantity" runat="server" Text="" style="padding-right:450px; font-size: medium; font-weight: bold; font-style: oblique;"></Label>
								    <asp:Button ID="btnAddToCart" runat="server" Text="Add to Cart" class="btn btn-default add-to-cart" Height="50px" OnClick="btnAddToCart_Click" Width="250px"/>
                                <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
                                <asp:Label ID="lblErr" runat="server"></asp:Label>
                                </span>
								<p>
                                    <b>Availability:<asp:Label ID="lblstock" runat="server" Text="" style="font-size: medium; font-weight: bold; font-style: oblique;"></asp:Label>
                                    </b>
								<p style="font-size: medium; font-weight: bold"><b>Brand:</b> Panadol</p>
							</div><!--/product-information-->
						</div>
					</div><!--/product-details-->
	
  
	<script src="~/Scripts/Pharmacy/price-range.js"></script>
    <script src="~/Scripts/Pharmacy/jquery.scrollUp.min.js"></script>
    <script src="~/Scripts/Pharmacy/jquery.prettyPhoto.js"></script>
    <script src="~/Scripts/Pharmacy/main.js"></script>
    <script src="~/Scripts/Pharmacy/bootstrap.min.js"></script>
    <script src="~/Scripts/Pharmacy/contact.js"></script>
    <script src="~/Scripts/Pharmacy/gmaps.js"></script>
    <script src="~/Scripts/Pharmacy/html5shiv.js"></script>
    <script src="~/Scripts/Pharmacy/jquery.js"></script>

</body>
    </span>
</asp:Content>
