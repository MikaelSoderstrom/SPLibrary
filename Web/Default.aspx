<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Web._Default" Trace="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>Sites</h1>
        <asp:TextBox runat="server" Text="http://moss" ID="tbWebs" Width="600px" />
        <asp:Button runat="server" ID="btnGetWebs" Text="Get sites" 
            onclick="btnGetWebs_Click" />
        <br />
        <asp:GridView runat="server" ID="gvWebs" CellPadding="4" ForeColor="#333333" 
            GridLines="None" >
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <EditRowStyle BackColor="#999999" />
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        </asp:GridView>
        <h2>Lists</h2>
        <asp:GridView runat="server" ID="gvFiles" CellPadding="4" ForeColor="#333333" 
            GridLines="None" >
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <EditRowStyle BackColor="#999999" />
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        </asp:GridView>
    </div>
    <div>
        <h2>List</h2>
        <asp:TextBox runat="server" ID="tbList" Width="600px" />
        <asp:Button runat="server" ID="btnGetList" Text="Get list" 
            onclick="btnGetList_Click" style="height: 26px" />
        <br />
        <asp:GridView runat="server" ID="gvList" CellPadding="4" ForeColor="#333333" 
            GridLines="None" >
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <EditRowStyle BackColor="#999999" />
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        </asp:GridView>
        <h3>List items</h3>
        <asp:GridView runat="server" ID="gvListItems" CellPadding="4" ForeColor="#333333" 
            GridLines="None" AutoGenerateColumns="False" 
            onrowdatabound="gvListItems_RowDataBound" >
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <EditRowStyle BackColor="#999999" />
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="Id" />
                <asp:BoundField DataField="Name" HeaderText="Name" />
                <asp:BoundField DataField="Url" HeaderText="Url" />
                <asp:BoundField DataField="CreatedBy" HeaderText="CreatedBy" />
                <asp:BoundField DataField="Created" HeaderText="Created" />
                <asp:BoundField DataField="ModifiedBy" HeaderText="ModifiedBy" />
                <asp:BoundField DataField="Modified" HeaderText="Modified" />
                <asp:BoundField DataField="ItemType" HeaderText="ItemType" />
                <asp:TemplateField HeaderText="Metadata">
                    <ItemTemplate>
                        <asp:GridView runat="server" ID="gvListItemsMetaData" CellPadding="4" ForeColor="#333333" 
                            GridLines="None" >
                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <EditRowStyle BackColor="#999999" />
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        </asp:GridView>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
    </form>
</body>
</html>
