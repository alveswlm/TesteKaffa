<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CNPJ.aspx.cs" Inherits="KaffaTestApplication.CNPJ" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />

    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.0/css/bootstrap.min.css" integrity="sha384-9aIt2nRpC12Uk9gS9baDl411NQApFmC26EwAOH8WgZl5MYYxFfc+NcPb1dKGj7Sk" crossorigin="anonymous" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="py-5 text-center">
            <h2>Validate CNPJ Mask and Digits</h2>
            <p class="lead">Enter a CNPJ on the field below and click on Validate Mask or Validate Digits</p>
        </div>
        <div class="container-md">
            <div class="row">
                <div class="col-md-3 col-sm-12"></div>
                <div class="col-md-6 col-sm-12">
                    <input type="text" id="txtCNPJ" runat="server" class="form-control" placeholder="Enter a CNPJ" />
                </div>
                <div class="col-md-3 col-sm-12"></div>
            </div>
            <div class="row">
                <div class="col-md-3 col-sm-12"></div>
                <div class="col-md-3 col-sm-12 text-left">
                    <asp:Button ID="btnValidateMask" runat="server" Text="Validate Mask" OnClick="btnValidateMask_Click" CssClass="btn btn-dark" />
                </div>
                <div class="col-md-3 col-sm-12 text-right">
                    <asp:Button ID="btnValidateDigits" runat="server" Text="Validate Digits" OnClick="btnValidateDigits_Click" CssClass="btn btn-light" />
                </div>
                <div class="col-md-3 col-sm-12"></div>
            </div>
            <div class="row">
                <div class="col-md-6 col-sm-12">
                    <div class="alert alert-success" id="divSuccessMessage" role="alert" runat="server" visible="false">
                        <span id="spanSuccessMessage" runat="server"></span>
                    </div>
                    <div class="alert alert-danger" id="divErrorMessage" role="alert" runat="server" visible="false">
                        <span id="spanErrorMessage" runat="server"></span>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
<script src="https://code.jquery.com/jquery-3.5.1.slim.min.js" integrity="sha384-DfXdz2htPH0lsSSs5nCTpuj/zy4C+OGpamoFVy38MVBnE+IbbVYUew+OrCXaRkfj" crossorigin="anonymous"></script>
<script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.0/dist/umd/popper.min.js" integrity="sha384-Q6E9RHvbIyZFJoft+2mJbHaEWldlvI9IOYy5n3zV9zzTtmI3UksdQRVvoxMfooAo" crossorigin="anonymous"></script>
<script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.0/js/bootstrap.min.js" integrity="sha384-OgVRvuATP1z7JjHLkuOU7Xw704+h835Lr+6QL9UvYjZE3Ipu6Tp75j7Bh/kR0JKI" crossorigin="anonymous"></script>
</html>
