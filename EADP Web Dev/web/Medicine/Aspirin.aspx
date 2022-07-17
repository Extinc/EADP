<%@ Page Title="" Language="C#" MasterPageFile="~/mainMenu.Master" AutoEventWireup="true" CodeBehind="Aspirin.aspx.cs" Inherits="EADP_Web_Dev.web.Medicine.Aspirin" %>
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
                                    <asp:Label ID="lblName" runat="server" Text="Aspirin Painkiller"></asp:Label>
                                </h2>
								<asp:Label ID="lblID2" runat="server"></asp:Label>
								<asp:Button ID="btnCart" runat="server" OnClick="btnCart_Click" Text="Cart" Style="background-image:url('../../Images/cart.png'); background-repeat:no-repeat" />
								<img src="../../Images/aspirin.jpg" />
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
								<p style="font-size: medium; font-weight: bold"><b>Brand:</b> Aspirin</p>
								<a href=""><img src="images/product-details/share.png" class="share img-responsive"  alt="" /></a>
							</div><!--/product-information-->
						</div>
					</div><!--/product-details-->
					
					
					<div class="recommended_items"><!--recommended_items-->
						<h2 class="title text-center">recommended items</h2>
						
						<div id="recommended-item-carousel" class="carousel slide" data-ride="carousel">
							<div class="carousel-inner">
								<div class="item active">	
									<div class="col-sm-4">
										<div class="product-image-wrapper">
											<div class="single-products">
												<div class="productinfo text-center">
													<img src="images/home/recommend1.jpg" alt="" />
													<h2>$56</h2>
													<p>Easy Polo Black Edition</p>
													<button type="button" class="btn btn-default add-to-cart"><i class="fa fa-shopping-cart"></i>Add to cart</button>
												</div>
											</div>
										</div>
									</div>
									<div class="col-sm-4">
										<div class="product-image-wrapper">
											<div class="single-products">
												<div class="productinfo text-center">
													<img src="images/home/recommend2.jpg" alt="" />
													<h2>$56</h2>
													<p>Easy Polo Black Edition</p>
													<button type="button" class="btn btn-default add-to-cart"><i class="fa fa-shopping-cart"></i>Add to cart</button>
												</div>
											</div>
										</div>
									</div>
									<div class="col-sm-4">
										<div class="product-image-wrapper">
											<div class="single-products">
												<div class="productinfo text-center">
													<img src="images/home/recommend3.jpg" alt="" />
													<h2>$56</h2>
													<p>Easy Polo Black Edition</p>
													<button type="button" class="btn btn-default add-to-cart"><i class="fa fa-shopping-cart"></i>Add to cart</button>
												</div>
											</div>
										</div>
									</div>
								</div>
								<div class="item">	
									<div class="col-sm-4">
										<div class="product-image-wrapper">
											<div class="single-products">
												<div class="productinfo text-center">
													<img src="images/home/recommend1.jpg" alt="" />
													<h2>$56</h2>
													<p>Easy Polo Black Edition</p>
													<button type="button" class="btn btn-default add-to-cart"><i class="fa fa-shopping-cart"></i>Add to cart</button>
												</div>
											</div>
										</div>
									</div>
									<div class="col-sm-4">
										<div class="product-image-wrapper">
											<div class="single-products">
												<div class="productinfo text-center">
													<img src="images/home/recommend2.jpg" alt="" />
													<h2>$56</h2>
													<p>Easy Polo Black Edition</p>
													<button type="button" class="btn btn-default add-to-cart"><i class="fa fa-shopping-cart"></i>Add to cart</button>
												</div>
											</div>
										</div>
									</div>
									<div class="col-sm-4">
										<div class="product-image-wrapper">
											<div class="single-products">
												<div class="productinfo text-center">
													<img src="images/home/recommend3.jpg" alt="" />
													<h2>$56</h2>
													<p>Easy Polo Black Edition</p>
													<button type="button" class="btn btn-default add-to-cart"><i class="fa fa-shopping-cart"></i>Add to cart</button>
												</div>
											</div>
										</div>
									</div>
								</div>
							</div>
							 <a class="left recommended-item-control" href="#recommended-item-carousel" data-slide="prev">
								<i class="fa fa-angle-left"></i>
							  </a>
							  <a class="right recommended-item-control" href="#recommended-item-carousel" data-slide="next">
								<i class="fa fa-angle-right"></i>
							  </a>			
						</div>
					</div><!--/recommended_items-->
					
				</div>
			</div>
		</div>
	</section>
	
  
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
