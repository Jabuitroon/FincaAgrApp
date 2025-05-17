<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Presentation.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Login</title>
    <link href="src/css/bootstrap.min.css" rel="stylesheet" />
    <link href="src/css/bootstrap.min.css" rel="stylesheet" />
    <link href="src/css/style.css" rel="stylesheet" />
</head>
<body>
        <div>
            <h1>Pagina de Incio Finca Agricola</h1>
        </div>
     <div class="container">
    <div class="row justify-content-center">
        <div class="col-md-6 col-lg-4">
            <div class="card shadow-sm border mt-5">
                <div class="card-body text-center">
                    <!-- Avatar Icon -->
                    <div class="mx-auto mb-3" style="width: 100px; height: 100px; background-color: #5d6d8c; border-radius: 50%; display: flex; justify-content: center; align-items: center;">
                        <i class="bi bi-person-fill text-white" style="font-size: 50px;"></i>
                    </div>
                    
                    <h4 class="mb-4">Admin Login</h4>
                    
                    <form method="post" runat="server">
                        <div asp-validation-summary="ModelOnly" class="text-danger"></div>
                        
                        <div class="form-group text-start mb-3">
                            <label class="form-label">Member ID</label>
                            <asp:TextBox class="form-control" id="TBUserName" runat="server" placeholder="User Name"></asp:TextBox>
                            <span asp-validation-for="Input.MemberId" class="text-danger"></span>
                        </div>
                        
                        <div class="form-group text-start mb-4">
                            <label class="form-label">Password</label>
                            <asp:TextBox class="form-control" id="TBUserPassword" runat="server" type="password" placeholder="Password"></asp:TextBox>                         
                            <span asp-validation-for="Input.Password" class="text-danger"></span>
                        </div>
                        
                        <div class="d-grid gap-2">
                            <asp:Button runat="server" type="submit" class="btn btn-success" onclick="SubmitLogin" Text="Login"/>
                        </div>
                    </form>
                </div>
            </div>
        </div>
    </div>
</div>
</body>
</html>
