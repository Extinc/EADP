<%@ Page Title="" Language="C#" MasterPageFile="~/mainMenu.Master" AutoEventWireup="true" CodeBehind="~/MedicineShop/Medicine_Shop.aspx.cs" Inherits="EADP_Web_Dev.web.Medicine.Medicine_Shop" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 250px;
            height: 250px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<link rel="stylesheet" href="<%= Page.ResolveClientUrl("~/CSS/Pharmacy/responsive.css") %>"/>
<link rel="stylesheet" href="<%= Page.ResolveClientUrl("~/Content/bootstrap.min.css") %>"/>
<link rel="stylesheet" href="<%= Page.ResolveClientUrl("~/CSS/Pharmacy/main.css") %>"/>
<link rel="stylesheet" href="<%= Page.ResolveClientUrl("~/CSS/Pharmacy/price-range.css") %>"/>
<link rel="stylesheet" href="<%= Page.ResolveClientUrl("~/CSS/Pharmacy/prettyPhoto.css") %>"/>
<link rel="stylesheet" href="<%= Page.ResolveClientUrl("~/CSS/Pharmacy/animate.css") %>"/>
	<section>
		<div class="container">
			<div class="row">
				<div class="col-sm-3">
					<div class="left-sidebar">
						<h2 style="margin-top: 20px;">Category</h2>
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
                    <h2 class="title text-center" style="margin-top: 20px;">Featured Items</h2>
					<div class="featured_items row"><!--featured_items-->
						
						<div class="col-sm-4">
							<div class="product-image-wrapper">
								<div class="single-products">
									<div class="productinfo text-center">
										<img src="../../Images/panadol.png" alt="" class="auto-style1" />
                                        <asp:Label ID="lblID" runat="server" Visible="False"></asp:Label>
                                        &nbsp;<h2>$7</h2>
										<asp:Label ID="med1" runat="server" Font-Bold="True" Font-Italic="True" Font-Size="Medium" Font-Underline="True"></asp:Label>
                                        <br />
                                        <a href="#" class="btn btn-default add-to-cart">View Product</a>
									</div>
									<div class="product-overlay">
										<div class="overlay-content">
                                            <h2>$7</h2>
											<p>Treatment for cough and Headaches</p>
                                            &nbsp;<asp:Button ID="Button2" runat="server" Text="View product" class="btn btn-default add-to-cart" OnClick="btnView_Click"/>
										</div>
									</div>
								</div>
								<div class="choose">
									<ul class="nav nav-pills nav-justified white">
										<li><a href=""  style="padding-right:20px"><i class="fa fa-plus-square"></i>Add to wishlist</a></li>
										<li><a href=""><i class="fa fa-plus-square"></i>Add to compare</a></li>
									</ul>
								</div>
							</div>
						</div>
						<div class="col-sm-4">
							<div class="product-image-wrapper">
								<div class="single-products">
									<div class="productinfo text-center">
										<img src="../../Images/aspirin.jpg" alt="" />
                                        <asp:Label ID="lblID2" runat="server" Visible="False"></asp:Label>
										&nbsp;<h2>$7</h2>
										<asp:Label ID="med2" runat="server" Font-Bold="True" Font-Italic="True" Font-Size="Medium" Font-Underline="True"></asp:Label>
                                        <br />
										<a href="#" class="btn btn-default add-to-cart"><i class="fa fa-shopping-cart"></i>View Product</a>
									</div>
									<div class="product-overlay">
										<div class="overlay-content">
											<h2>$7</h2>
											<p>reduce fever and relieve mild to moderate pain</p>
                                            &nbsp;<asp:Button ID="btnmed2" runat="server" Text="View product" class="btn btn-default add-to-cart" OnClick="btnView_Click2"/>
										</div>
									</div>
								</div>
								<div class="choose">
									<ul class="nav nav-pills nav-justified white">
										<li><a href="" style="padding-right:20px"><i class="fa fa-plus-square "></i>Add to wishlist</a></li>
										<li><a href=""><i class="fa fa-plus-square"></i>Add to compare</a></li>
									</ul>
								</div>
							</div>
						</div>
						<div class="col-sm-4">
							<div class="product-image-wrapper">
								<div class="single-products">
									<div class="productinfo text-center">
										<img src="../../Images/Azithromycin.jpg" alt="" class="auto-style1" />
										<h2>$10</h2>
										<asp:Label ID="Label1" runat="server" Text="Azithromycin" Font-Bold="True" Font-Italic="True" Font-Size="Medium" Font-Underline="True"></asp:Label>
                                        <br />
										<a href="#" class="btn btn-default add-to-cart"><i class="fa fa-shopping-cart"></i>View Product</a>
									</div>
									<div class="product-overlay">
										<div class="overlay-content">
											<h2>$10</h2>
											<p>Azithromycin</p>
											<a href="#" class="btn btn-default add-to-cart"><i class="fa fa-shopping-cart"></i>View Product</a>
										</div>
									</div>
								</div>
								<div class="choose">
									<ul class="nav nav-pills nav-justified white">
										<li><a href="" style="padding-right:20px"><i class="fa fa-plus-square"></i>Add to wishlist</a></li>
										<li><a href=""><i class="fa fa-plus-square"></i>Add to compare</a></li>
									</ul>
								</div>
							</div>
						</div>
						<div class="col-sm-4">
							<div class="product-image-wrapper">
								<div class="single-products">
									<div class="productinfo text-center">
										<img src="../../Images/Antiseptic.jpg" alt="" class="auto-style1"/>
										<h2>$7</h2>
										<asp:Label ID="Label2" runat="server" Text="Antiseptic Cream" Font-Bold="True" Font-Italic="True" Font-Size="Medium" Font-Underline="True"></asp:Label>
                                        <br />
										<a href="#" class="btn btn-default add-to-cart"><i class="fa fa-shopping-cart"></i>View Product</a>
									</div>
									<div class="product-overlay">
										<div class="overlay-content">
											<h2>$7</h2>
											<p>Antiseptic Cream</p>
											<a href="#" class="btn btn-default add-to-cart"><i class="fa fa-shopping-cart"></i>View Product</a>
										</div>
									</div>
								</div>
								<div class="choose">
									<ul class="nav nav-pills nav-justified white">
										<li><a href="" style="padding-right:20px"><i class="fa fa-plus-square"></i>Add to wishlist</a></li>
										<li><a href=""><i class="fa fa-plus-square"></i>Add to compare</a></li>
									</ul>
								</div>
							</div>
						</div>
						<div class="col-sm-4">
							<div class="product-image-wrapper">
								<div class="single-products">
									<div class="productinfo text-center">
										<img src="../../Images/Bonjela.png" alt="" class ="auto-style1"/>
										<h2>$5</h2>
										<asp:Label ID="Label3" runat="server" Text="Bonjela®" Font-Bold="True" Font-Italic="True" Font-Size="Medium" Font-Underline="True"></asp:Label>
                                        <br />
										<a href="#" class="btn btn-default add-to-cart"><i class="fa fa-shopping-cart"></i>View Product</a>
									</div>
									<div class="product-overlay">
										<div class="overlay-content">
											<h2>$5</h2>
											<p>Bonjela®</p>
											<a href="#" class="btn btn-default add-to-cart"><i class="fa fa-shopping-cart"></i>View Product</a>
										</div>
									</div>
								</div>
								<div class="choose">
									<ul class="nav nav-pills nav-justified white">
										<li><a href="" style="padding-right:20px"><i class="fa fa-plus-square"></i>Add to wishlist</a></li>
										<li><a href=""><i class="fa fa-plus-square"></i>Add to compare</a></li>
									</ul>
								</div>
							</div>
						</div>
						<div class="col-sm-4">
							<div class="product-image-wrapper">
								<div class="single-products">
									<div class="productinfo text-center">
										<img src="../../Images/Paracetamol.jpg" alt="" class="auto-style1" />
										<h2>$11</h2>
										<asp:Label ID="Label4" runat="server" Text="Paracetamol" Font-Bold="True" Font-Italic="True" Font-Size="Medium" Font-Underline="True"></asp:Label>
                                        <br />
										<a href="#" class="btn btn-default add-to-cart"><i class="fa fa-shopping-cart"></i>View Product </a>
									</div>
									<div class="product-overlay">
										<div class="overlay-content">
											<h2>$11</h2>
											<p>Paracetamol</p>
											<a href="#" class="btn btn-default add-to-cart"><i class="fa fa-shopping-cart"></i>View Product</a>
										</div>
									</div>
								</div>
								<div class="choose">
									<ul class="nav nav-pills nav-justified white">
										<li><a href="" style="padding-right:20px"><i class="fa fa-plus-square"></i>Add to wishlist</a></li>
										<li><a href=""><i class="fa fa-plus-square"></i>Add to compare</a></li>
									</ul>
								</div>
							</div>
						</div>
						

						
						<ul class="pagination">
							<li class="active"><a href="">1</a></li>
							<li><a href="">2</a></li>
							<li><a href="">3</a></li>
							<li><a href="">&raquo;</a></li>
						</ul>
					</div><!--features_items-->
				</div>
			</div>
		</div>
	</section>
	

  
<%--    <script src="js/jquery.js"></script>--%>
	<script src="~/Scripts/Pharmacy/price-range.js"></script>
    <script src="~/Scripts/Pharmacy/jquery.scrollUp.min.js"></script>
    <script src="~/Scripts/Pharmacy/jquery.prettyPhoto.js"></script>
    <script src="~/Scripts/Pharmacy/main.js"></script>
    <script src="~/Scripts/Pharmacy/bootstrap.min.js"></script>
    <script src="~/Scripts/Pharmacy/contact.js"></script>
    <script src="~/Scripts/Pharmacy/gmaps.js"></script>
    <script src="~/Scripts/Pharmacy/html5shiv.js"></script>
    <script src="~/Scripts/Pharmacy/jquery.js"></script>



</asp:Content>
