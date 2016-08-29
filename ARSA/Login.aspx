<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ARSA.Login" %>

<!DOCTYPE html>

<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
        <title>BIENVENIDO</title>

        <!--STYLESHEETS-->
        <link href="css/style.css" rel="stylesheet" type="text/css" />

        <!--SCRIPTS-->
        <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.2.6/jquery.min.js"></script>
        <!--Slider-in icons-->
        <script type="text/javascript">
            $(document).ready(function () {
                $(".username").focus(function () {
                    $(".user-icon").css("left", "-48px");
                });
                $(".username").blur(function () {
                    $(".user-icon").css("left", "0px");
                });

                $(".password").focus(function () {
                    $(".pass-icon").css("left", "-48px");
                });
                $(".password").blur(function () {
                    $(".pass-icon").css("left", "0px");
                });
            });
        </script>
    </head>
    <body>
        <!--WRAPPER-->
        <div id="wrapper">
	        <!--SLIDE-IN ICONS-->
            <div class="user-icon"></div>
            <div class="pass-icon"></div>
            <!--END SLIDE-IN ICONS-->
            <!--LOGIN FORM-->
            <form name="login-form" class="login-form" action="" id="formulario" runat="server">
	            <!--HEADER-->
                <div class="header">
                <!--TITLE--><h1>APLICACION ARSA</h1><!--END TITLE-->
                <!--DESCRIPTION--><span>por favor logearse para acceder a la aplicacion</span><!--END DESCRIPTION-->
                </div>
                <!--END HEADER-->
	            <!--CONTENT-->
                <div class="content">
	                <!--USERNAME-->
                    <asp:TextBox ID="textUsuario" runat="server" name="username" class="input username" value="Usuario" onfocus="this.value=''"></asp:TextBox>
                    <!--PASSWORD-->
                    <asp:TextBox ID="textPassword" type="password" runat="server" name="password" class="input password" value="12345" onfocus="this.value=''"></asp:TextBox>
                </div>
                <!--END CONTENT-->
    
                <!--FOOTER-->
                <div class="footer">
                    <!--LOGIN BUTTON-->
                        <asp:Button ID="butIngresar" runat="server" Text="Ingresar" name="submit" class="button" onclick="butIngresar_Click" />
                    <!--END LOGIN BUTTON-->
                    <!--REGISTER BUTTON-->
                      
                    <!--END REGISTER BUTTON-->
                </div>
                <!--END FOOTER-->
            </form>
            <!--END LOGIN FORM-->
        </div>
        <!--END WRAPPER-->
        <!--GRADIENT-->
        <div class="gradient">
        </div><!--END GRADIENT-->
    </body>
</html>