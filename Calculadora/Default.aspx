<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Calculadora._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="stylesheet" href="https://cdn.datatables.net/2.1.5/css/dataTables.dataTables.css" />


    <script type="text/javascript">
        $(document).ready(function () {
            var printCounter = 0;

            $('#tabela-historico').DataTable({
                "paging": true,
                "ordering": false,
                "info": false,
                dom: 'Bfrtip',
            });
        });
    </script>

    <style>
        .btn {
            width: 200px;
            color: white;
        }

    </style>

    <main>

        <section class="row" style="text-align: center;">
            <h2 id="aspnetTitle">Bem Vindo!</h2>
        </section>
        <br />
        <br />

        <section class="row" id="container">
            <h3>Digite os Valores</h3>
            <br />
            <div class="col-md-4">
                <br />
                <label>Valor A</label>
                <asp:TextBox ID="txtValorA" runat="server" CssClass="input-group-text"></asp:TextBox>

                <label>Valor B</label>
                <asp:TextBox ID="txtValorB" runat="server" CssClass="input-group-text"></asp:TextBox>
            </div>
            <div class="col-sm-1">
                <asp:LinkButton ID="lnkSomar" OnClick="lnkSomar_Click" runat="server" CssClass="btn mb-2" BackColor="#00a5e3">Adição</asp:LinkButton>
                <asp:LinkButton ID="lnkSubtrair" OnClick="lnkSubtrair_Click" runat="server" CssClass="btn mb-2" BackColor="#00a5e3">Subtração</asp:LinkButton>
                <asp:LinkButton ID="lnkMultiplicar" OnClick="lnkMultiplicar_Click" runat="server" CssClass="btn mb-2" BackColor="#00a5e3">Multiplicação</asp:LinkButton>
                <asp:LinkButton ID="lnkDividir" OnClick="lnkDividir_Click" runat="server" CssClass="btn" BackColor="#00a5e3">Divisão</asp:LinkButton>
            </div>
        </section>
        <br />
        <br />
        <section class="row">
            <div style="height: 400px; overflow: scroll; border: 1px solid #E6E7E8; padding: 15px; width: 100%; text-align: end;">

                <asp:Repeater ID="grd" runat="server">
                    <HeaderTemplate>
                        <table id='tabela-historico' class="table table-striped table-bordered" style="width: 100%; font-size: 12px">
                            <thead>
                                <tr>
                                    <th style="font-size: 10px; letter-spacing: 0.5px; text-align: center;">ID</th>
                                    <th style="font-size: 10px; letter-spacing: 0.5px; text-align: center;">Valor A</th>
                                    <th style="font-size: 10px; letter-spacing: 0.5px; text-align: center;">Valor B</th>
                                    <th style="font-size: 10px; letter-spacing: 0.5px; text-align: center;">Operação</th>
                                    <th style="font-size: 10px; letter-spacing: 0.5px; text-align: center;">Resultado</th>
                                    <th style="font-size: 10px; letter-spacing: 0.5px; text-align: center;">Data e Hora</th>
                                </tr>
                            </thead>
                            <tbody>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td style="text-align:center;"><%# Eval("ID") %></td>
                            <td style="text-align:center;"><%# Eval("valueA") %></td>
                            <td style="text-align:center;"><%# Eval("valueB") %></td>
                            <td style="text-align:center;"><%# Eval("operation") %></td>
                            <td style="text-align:center;"><%# Eval("result") %></td>
                            <td style="text-align:center;"><%# Eval("DtaRegistration") %></td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </tbody>
                        </table>
                    </FooterTemplate>
                </asp:Repeater>

            </div>
        </section>
        <br />
        <br />
    </main>

    <script src="https://cdn.datatables.net/2.1.5/js/dataTables.js"></script>
</asp:Content>
