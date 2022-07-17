<%@ Page Title="" Language="C#" MasterPageFile="~/mainMenu.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="EADP_Web_Dev.web.Profile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        var arrayInterest = [];
        $(function() {
            $('.nav-link a').click(function() {
                $("#panel12").removeClass("active");
                $("#panel11").addClass("active");
            });
            $('#panel12').click(function() {
                $("#panel11").removeClass("active");
                $("#panel12").addClass("active");
            });
            var contentheight = $('.row > .card').height();
            $('.row ul').height(contentheight);
            $('select').material_select();
            $('.chips').material_chip();
            $('.chips-placeholder').material_chip({
                placeholder: 'Enter a Interest',
                secondaryPlaceholder: '+Tag'
            });
            $('.chips-autocomplete').material_chip({
                autocompleteOptions: {
                    data: {
                        'Chess': null,
                        'Philosophy': null,
                        'Basketball': null,
                        'Taekwondo': null,
                        'Swimming': null,
                        'Tai Chi': null
                    },
                    limit: Infinity,
                    minLength: 0
                }
            });

            $('.chips').on('chip.add',
                function(e, chip) {
                    var data = $(".chips").material_chip('data');
                    var i;
                    for (i = 0; i < data.length; i++) {
                        arrayInterest[data.length - 1] = data[i].tag;
                    }
                });
        });

        function InterestchipRefresh() {
            $(document).ready(function() {
                $('.chips').material_chip();
                $('.chips-placeholder').material_chip({
                    placeholder: 'Enter a Interest',
                    secondaryPlaceholder: '+Tag'
                });
                $('.chips-autocomplete').material_chip({
                    autocompleteOptions: {
                        data: {
                            'Chess': null,
                            'Philosophy': null,
                            'Basketball': null,
                            'Taekwondo': null,
                            'Swimming': null,
                            'Tai Chi': null
                        },
                        limit: Infinity,
                        minLength: 0
                    }
                });
            });
        }

        function UpdateClick() {
            document.getElementById("ContentPlaceHolder1_arrayInterests").value = arrayInterest;
            console.log(document.getElementById("ContentPlaceHolder1_arrayInterests").value);
        }
    </script>
    <div class="container">
        <div class="row justify-content-center" style="margin-top: 10px; margin-bottom: 10px;">
            <ul class="card nav nav-tabs" role="tablist" style="display: inline-block; overflow-x: hidden; margin-right: 0; background-color: rgb(63, 81, 181); padding-right: 0">
                <li class="nav-item">
                    <a class="nav-link waves-light active waves-effect waves-light" data-toggle="tab" href="#panel11" role="tab" style="color: white; width: 100%;">Profile</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link waves-light waves-effect waves-light" data-toggle="tab" href="#panel12" style="color: white; width: 100%;" role="tab">Setting</a>
                </li>
            </ul>
            <div class="card col-sm-7 tab-content" style="display: inline-block; min-height: 100vh">
                <div class="tab-pane fadeIn active show" id="panel11" role="tabpanel">
                    <h3>Test</h3>
                </div>
                <div class="tab-pane fade" id="panel12" role="tabpanel">
                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>
                            <div class="row justify-content-center">
                                <div class="input-field col s6">
                                    <asp:TextBox runat="server" ID="TB_emailChge" CssClass="validate"></asp:TextBox>
                                    <asp:Label runat="server" AssociatedControlID="TB_emailChge" data-error="error" data-success="" Text="Email"></asp:Label>
                                </div>
                            </div>
                            <div class="row">
                                <div id="interestChip" class="interestChip chips chips-placeholder chips-autocomplete"></div>
                                <input type="hidden" id="arrayInterests" runat="server"/>
                            </div>
                            <div class="row" id="interestHolder" runat="server">

                            </div>
                            <div class="row justify-content-center">
                                <asp:Button runat="server" ID="btnUpdate" OnClick="btnUpdate_OnClick" OnClientClick="UpdateClick()" CssClass="waves-effect waves-light btn" Text="Update"/>
                            </div>
                            <div class="divider"></div>
                            <div class="row justify-content-center">
                                <div class="input-field col s6">
                                    <asp:TextBox runat="server" ValidationGroup="chgpwVG" ID="TB_oldpw" CssClass="validate" CausesValidation="false" TextMode="Password"></asp:TextBox>
                                    <asp:Label runat="server" ID="lblUpdteOldPW" AssociatedControlID="TB_oldpw" Text="Enter your old password" data-error="error" data-success=""></asp:Label>
                                    <asp:CustomValidator runat="server" ControlToValidate="TB_oldpw" OnServerValidate="settingOldPW_OnServerValidate"></asp:CustomValidator>
                                </div>
                            </div>

                            <div class="row justify-content-center">
                                <div class="input-field col s6">
                                    <asp:TextBox runat="server" ID="TB_newpw" CssClass="validate" TextMode="Password"></asp:TextBox>
                                    <asp:Label runat="server" CssClass="" ID="lblUpdteNewPw" AssociatedControlID="TB_newpw" Text="Enter your new password" data-error="error" data-success=""></asp:Label>
                                    <%--<asp:CustomValidator runat="server" ControlToValidate="TB_oldpw" OnServerValidate="settingnewPW_OnServerValidate"></asp:CustomValidator>--%>
                                </div>
                            </div>
                            <div class="row justify-content-center">
                                <div class="input-field col s6">
                                    <asp:TextBox runat="server" ID="TB_newpwrepeat" CssClass="validate" TextMode="Password"></asp:TextBox>
                                    <asp:Label runat="server" ID="lblUpdteNewPwRepeat" AssociatedControlID="TB_newpwrepeat" Text="Re-Enter your new password" data-error="error" data-success=""></asp:Label>
                                </div>
                            </div>
                            <div class="row justify-content-center">
                                <asp:Button runat="server" ID="btnChgPW" OnClick="btnChgPW_OnClick" CssClass="waves-effect waves-light btn" Text="Change Password"/>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>

            </div>

        </div>
    </div>
</asp:Content>