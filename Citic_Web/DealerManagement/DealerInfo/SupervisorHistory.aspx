<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SupervisorHistory.aspx.cs" Inherits="Citic_Web.DealerManagement.DealerInfo.SupervisorHistory" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <x:PageManager ID="PageManager1" runat="server" AutoSizePanelID="Panel1" />
        <x:Panel ID="Panel1" runat="server" BodyPadding="0px" ShowBorder="true" ShowHeader="true" Title="监管员历史" EnableBackgroundColor="true" Layout="VBox">
            <Items>
                <x:HiddenField ID="hf_DealerID" runat="server"></x:HiddenField>
                <x:Grid ID="grid_List" PageSize="15" ShowBorder="false" ShowHeader="false" AllowPaging="true" BoxFlex="1"
                    runat="server" EnableCheckBoxSelect="True" DataKeyNames="DealerID,DealerName" EnableBackgroundColor="true"
                    IsDatabasePaging="true" OnPageIndexChange="grid_List_PageIndexChange" EnableRowNumber="True"
                    ClearSelectedRowsAfterPaging="false" EnableTextSelection="true">
                    <Columns>
                        <x:BoundField DataField="SupervisorName" HeaderText="监管员姓名" />
                        <x:BoundField DataField="Time_Start" HeaderText="开始时间" />
                        <x:BoundField DataField="Time_End" HeaderText="结束时间" />
                    </Columns>
                    <PageItems>
                        <x:ToolbarSeparator ID="ToolbarSeparator1" runat="server">
                        </x:ToolbarSeparator>
                        <x:ToolbarText ID="TtxtPage" runat="server" Text="每页数：">
                        </x:ToolbarText>
                        <x:DropDownList runat="server" ID="ddlPageSize" Width="40px" AutoPostBack="true"
                            OnSelectedIndexChanged="ddlPageSize_SelectedIndexChanged">
                            <x:ListItem Text="5" Value="5" />
                            <x:ListItem Text="10" Value="10" Selected="true" />
                            <x:ListItem Text="15" Value="15" />
                            <x:ListItem Text="20" Value="20" />
                        </x:DropDownList>
                    </PageItems>
                </x:Grid>
            </Items>
        </x:Panel>
        <x:HiddenField ID="hfSelectedIDS" runat="server">
        </x:HiddenField>
    </form>
</body>
</html>
