<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/mainMenu.Master" CodeBehind="~/web/CommunityEvent/CreateCommEvent.aspx.cs" Inherits="EADP_Web_Dev.web.CommunityEvent.CreateCommEvent" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="<%= Page.ResolveClientUrl("~/CSS/Custom/ComEventStyleSheet.css") %>"/>
    <link rel="stylesheet" href="<%= ResolveClientUrl("~/CSS/Custom/articleStyleSheet.css") %>"/>
    <script type="text/javascript" src="<%= ResolveClientUrl("~/Scripts/Custom/CustomJS.js") %>" ></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script type="text/javascript">
        var arrayInvites = [];
        var tbDateCID = '#' + '<%= tbDate.ClientID %>';
        var tbEndDateCID = '#' + '<%= tbEndDate.ClientID %>';
        var btnCreateCID = '#' + '<%= btnCreate.ClientID %>';
        $(function () {
            $(btnCreateCID).click(function() {
               // $.connection.hub.start().done(function () {
                //    notification.server.send("You have been invited!!", "drHo@gmail.com");
               // });
            });
            console.log($.connection.hub);

            $(tbDateCID).pickadate({
                selectMonths: true, // Creates a dropdown to control month
                selectYears: 15, // Creates a dropdown of 15 years to control year,
                today: 'Today',
                clear: 'Clear',
                close: 'Ok',
                closeOnSelect: false, // Close upon selecting a date,
                onClose: function() {
                    if ($(tbDateCID).val() == '') {
                        if (!$(tbDateCID).hasClass("invalid")) {
                            $(tbDateCID).addClass('invalid');
                            Console.log($(tbDateCID).hasClass("invalid"));
                        }
                    } else {
                        $(tbDateCID).removeClass('invalid');
                    }
                }
            });

            $(tbEndDateCID).pickadate({
                selectMonths: true, // Creates a dropdown to control month
                selectYears: 15, // Creates a dropdown of 15 years to control year,
                today: 'Today',
                clear: 'Clear',
                close: 'Ok',
                closeOnSelect: false, // Close upon selecting a date,
                onClose: function () {
                    if ($(tbEndDateCID).val() == '') {
                        if (!$(tbEndDateCID).hasClass("invalid")) {
                            $(tbEndDateCID).addClass('invalid');
                            Console.log($(tbEndDateCID).hasClass("invalid"));
                        }
                    } else {
                        $(tbEndDateCID).removeClass('invalid');
                    }
                }
            });
            $('.timepicker').pickatime({
                default: 'now', // Set default time: 'now', '1:30AM', '16:30'
                fromnow: 0, // set default time to * milliseconds from now (using with default = 'now')
                twelvehour: false, // Use AM/PM or 24-hour format
                donetext: 'OK', // text for done-button
                cleartext: 'Clear', // text for clear-button
                canceltext: 'Cancel', // Text for cancel-button
                autoclose: false, // automatic close timepicker
                ampmclickable: true, // make AM PM clickable
                aftershow: function() {} //Function for after opening timepicker
            });
            $('#inviteChipsCol .chips').material_chip({
                placeholder: 'Enter Email',
                secondaryPlaceholder: '+ User',
                autocompleteOptions: {
                    data: {
                        <%= Otheremail %>
                    },
                    limit: Infinity,
                    minLength: 1
                }
            });

            $('#inviteChipsCol .chips').on('chip.add',
                function(e, chip) {
                    var data = $("#inviteChipsCol .chips").material_chip('data');
                    var i;
                    for (i = 0; i < data.length; i++) {
                        arrayInvites[data.length - 1] = data[i].tag;
                    }
                });
        });

        function CreateEventCC() {
            $('#inviteChipsCol > input').val(arrayInvites);
            refresh();
        }

        function refresh() {
            $('.timepicker').pickatime({
                default: 'now', // Set default time: 'now', '1:30AM', '16:30'
                fromnow: 0, // set default time to * milliseconds from now (using with default = 'now')
                twelvehour: false, // Use AM/PM or 24-hour format
                donetext: 'OK', // text for done-button
                cleartext: 'Clear', // text for clear-button
                canceltext: 'Cancel', // Text for cancel-button
                autoclose: false, // automatic close timepicker
                ampmclickable: true, // make AM PM clickable
                aftershow: function () { } //Function for after opening timepicker
            });
            $(tbDateCID).pickadate({
                selectMonths: true, // Creates a dropdown to control month
                selectYears: 15, // Creates a dropdown of 15 years to control year,
                today: 'Today',
                clear: 'Clear',
                close: 'Ok',
                closeOnSelect: false, // Close upon selecting a date,
                onClose: function () {
                    if ($(tbDateCID).val() == '') {
                        if (!$(tbDateCID).hasClass("invalid")) {
                            $(tbDateCID).addClass('invalid');
                            Console.log($(tbDateCID).hasClass("invalid"));
                        }
                    } else {
                        $(tbDateCID).removeClass('invalid');
                    }
                }
            });

            $(tbEndDateCID).pickadate({
                selectMonths: true, // Creates a dropdown to control month
                selectYears: 15, // Creates a dropdown of 15 years to control year,
                today: 'Today',
                clear: 'Clear',
                close: 'Ok',
                closeOnSelect: false, // Close upon selecting a date,
                onClose: function () {
                    if ($(tbEndDateCID).val() == '') {
                        if (!$(tbEndDateCID).hasClass("invalid")) {
                            $(tbEndDateCID).addClass('invalid');
                            Console.log($(tbEndDateCID).hasClass("invalid"));
                        }
                    } else {
                        $(tbEndDateCID).removeClass('invalid');
                    }
                }
            });
        }
    </script>

    <div class="container col-lg-12">
        <div class="demo-ribbon indigo darken-1" ></div>
        <main class="demo-main">
            <div class="demo-container mdl-grid">
                <%--   <div class="mdl-cell mdl-cell--2-col mdl-cell--hide-tablet mdl-cell--hide-phone"></div>--%>
                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                        <div class="demo-content white z-depth-5 mdl-color-text--grey-800 col-lg-6" style="margin: 0 auto;">
                            <h3>Create Community Event</h3>
                            <div class="row">
                                <div class="col-lg-12">
                                    <div class="input-field">
                                        <asp:TextBox ID="tbEvent" CausesValidation="False" ValidationGroup="CEvent" CssClass="validate" runat="server"/>
                                        <asp:Label ID="lblEventTitle" data-error="wrong" data-success="" AssociatedControlID="tbEvent" runat="server" Text="Event Title"/>
                                        <asp:CustomValidator runat="server" ValidationGroup="CEvent" ID="EventTitleCV" ValidateEmptyText="True" ControlToValidate="tbEvent" OnServerValidate="EventTitleCV_OnServerValidate"></asp:CustomValidator>
                                    </div>
                                </div>

                            </div>
                            <div class="row">
                                <div class="col-lg-6 col-sm-6">
                                    <div class="input-field">
                                        <asp:TextBox ID="tbDate" CausesValidation="True" ValidationGroup="CEvent" CssClass="datepicker" runat="server"/>
                                        <asp:Label ID="lblEventSDate" data-error="wrong" data-success="" AssociatedControlID="tbDate" runat="server" Text="Start Date"/>
                                        <asp:CustomValidator runat="server" ValidationGroup="CEvent" ValidateEmptyText="True" ID="EventDateCV" ControlToValidate="tbDate" OnServerValidate="EventDateCV_OnServerValidate"></asp:CustomValidator>
                                    </div>
                                </div>
                                <div class="col-lg-6 col-sm-6">
                                    <div class="input-field">
                                        <asp:TextBox ID="tbTime" ValidationGroup="CEvent" CssClass="validate timepicker" runat="server"/>
                                        <asp:Label AssociatedControlID="tbTime" runat="server" Text="Start Time"/>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-6 col-sm-6">
                                    <div class="input-field">
                                        <asp:TextBox ID="tbEndDate" CausesValidation="True" ValidationGroup="CEvent" CssClass="datepicker validate" runat="server"/>
                                        <asp:Label ID="lblEventEDate" AssociatedControlID="tbEndDate" runat="server" Text="End Date"/>
                                        <asp:CustomValidator runat="server" ValidateEmptyText="True" ID="CustomValidator1" ValidationGroup="CEvent" ControlToValidate="tbEndDate" OnServerValidate="EventEndDateCV_OnServerValidate"></asp:CustomValidator>
                                    </div>
                                </div>
                                <div class="col-lg-6 col-sm-6">
                                    <div class="input-field">
                                        <asp:TextBox ID="tbEndTime" ValidationGroup="CEvent" CssClass="validate timepicker" runat="server"/>
                                        <asp:Label AssociatedControlID="tbEndTime" runat="server" Text="End Time"/>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-12">
                                    <asp:Label runat="server" Text="Invite :"/>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-12" id="inviteChipsCol">
                                    <div class="chips"></div>
                                    <input type="hidden" id="inputInviteHidden" runat="server"/>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-12 justify-content-center">
                                    <asp:Button ID="btnCreate" OnClick="CreateEvents" ValidationGroup="CEvent" OnClientClick="CreateEventCC()" runat="server" CssClass="btn waves-effect waves-light light-blue darken-4 accent-4" Text="Create"/>
                                </div>
                            </div>
                        </div>

                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </main>
    </div>

</asp:Content>