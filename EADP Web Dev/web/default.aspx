<%@ Page Title="" Language="C#" MasterPageFile="~/mainMenu.Master" AutoEventWireup="true" CodeBehind="~/web/default.aspx.cs" Inherits="EADP_Web_Dev.web._default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $('.carousel.carousel-slider').carousel({
                fullWidth: true,
                duration: 300,
            });

            $(".goPrev").click(function(e) {
                e.preventDefault();
                e.stopPropagation();
                $('.carousel').carousel('prev');
            });

            $(".goNext").click(function (e) {
                e.preventDefault();
                e.stopPropagation();
                $('.carousel').carousel('next');
            });
        });
    </script>
    <style>
        footer {
            margin-top: 0px !important;
            padding-top: 0px !important;
        }
    </style>
    <div>

        <div class="carousel carousel-slider center" style="height: 82.6vh;" data-indicators="true">
            <div class="carousel-fixed-item center" style="height: 40%;">
                <div class="left">
                    <a href="#" class="goPrev waves-effect waves-light"><i class="material-icons left" style="font-size:4.2rem !important; color:white !important;">chevron_left</i></a>
                </div>
     
                <div class="right">
                    <a href="#" class=" goNext waves-effect waves-light"><i class="material-icons right" style="font-size:4.2rem !important; color:white !important;">chevron_right</i></a>
                </div>
            </div>
            <div class="carousel-item red white-text" href="#one!">
                <h2>First Panel</h2>
                <p class="white-text">This is your first panel</p>
            </div>
            <div class="carousel-item amber white-text" href="#two!">
                <h2>Second Panel</h2>
                <p class="white-text">This is your second panel</p>
            </div>
            <div class="carousel-item green white-text" href="#three!">
                <h2>Third Panel</h2>
                <p class="white-text">This is your third panel</p>
            </div>
            <div class="carousel-item blue white-text" href="#four!">
                <h2>Fourth Panel</h2>
                <p class="white-text">This is your fourth panel</p>
            </div>
        </div>
        

    </div>
</asp:Content>