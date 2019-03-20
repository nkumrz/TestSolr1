<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />

    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <link href="css/style.css" rel="stylesheet" />
    <title>Search Homes</title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager runat="server"></asp:ScriptManager>
        <asp:UpdatePanel runat="server" ID="updatepanel">
            <ContentTemplate>
                <div class="container ">
                    <div class="row">
                        <div class="col-md-12">
                            <div class="wrapper-outer text-center">
                                <div class="form-group">
                                    <asp:TextBox runat="server" ID="txtQuery" CssClass="form-control mb-2"></asp:TextBox>
                                    <asp:Button runat="server" ID="btnSearch" OnClick="btnSearch_Click" Text="Search Home Models" CssClass="btn btn-dark" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <div class="text-center ">
                            <asp:Label CssClass="text-center alert-danger" runat="server" ID="ltrmsg" Visible="false" Text="No Data Found"></asp:Label>
                        </div>
                            </div>
                        <asp:Repeater runat="server" ID="RepSearchedResult" ItemType="Home">
                            <ItemTemplate>
                                <div class="col-md-4">
                                    <div class="card text-left">
                                        <div class="card-body">
                                            <h5 class="card-title"><%# Item.Name +"-"+ Item.ID %></h5>
                                            <p>
                                                <%# (Convert.ToDecimal(Item.Size)).ToString("0,00") +" Sq. Ft. | " %>
                                                <%# Item.Bed %>
                                                <img class="icn-bed" src="images/icn_bed.svg" alt="Bed" title="Bed" />
                                                |
                                                <%# Item.Bath %>
                                                <img class="icn-bed" src="images/icn_bath.svg" alt="Bath" title="Bath" />

                                            </p>
                                            <p>
                                                <%# Item.Price.ToString("c") + " | "+ Item.Possession +" | "+ Item.Address %>
                                            </p>
                                            <p class="card-text"><%# "This beautiful home is developed by ABC builder in "+ Item.Community + " community of "+ Item.City +". This "+ Item.Style + " home comes with " + Item.Bed +" bedrooms with "+ Item.Bath +" bathrooms and floorplan size is "+ (Convert.ToDecimal(Item.Size)).ToString("0,00") +" Sq. Ft. "%></p>

                                        </div>
                                    </div>

                                </div>
                            </ItemTemplate>
                        </asp:Repeater>

                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>

    </form>
</body>
</html>
