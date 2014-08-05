<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ImportDrafts.aspx.cs" Inherits="Citic_Web.FinanceInfo.ImportDrafts" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <x:PageManager ID="PageManager1" runat="server" AutoSizePanelID="pnl_Container" />
        <x:Panel ID="pnl_Container" runat="server" BodyPadding="5px" ShowBorder="true" ShowHeader="true"
            Title="汇票信息" EnableBackgroundColor="true" Layout="VBox" BoxConfigAlign="Stretch">
            <Items>
                <x:SimpleForm ID="SimpleForm1" runat="server" BodyPadding="5px" ShowHeader="false"
                    EnableBackgroundColor="true">
                    <Items>
                        <x:Form ID="Form2" runat="server" BodyPadding="5px" ShowHeader="false" ShowBorder="false" EnableBackgroundColor="true">
                            <Rows>
                                <x:FormRow ID="FormRow1" runat="server">
                                    <Items>
                                        <x:FileUpload ID="file_Upload" runat="server" Label="请选择文件" Width="300px" AutoPostBack="true" OnFileSelected="file_Upload_FileSelected">
                                        </x:FileUpload>
                                    </Items>
                                </x:FormRow>
                            </Rows>
                        </x:Form>
                    </Items>
                </x:SimpleForm>
                <x:Panel ID="Panel1" runat="server" BodyPadding="0px" ShowBorder="true" ShowHeader="false"
                    EnableBackgroundColor="true" Layout="Fit" BoxFlex="1" CssStyle="padding-top:5px">
                    <Toolbars>
                        <x:Toolbar ID="Toolbar1" runat="server">
                            <Items>
                                <x:Button ID="btn_Save" runat="server" Text="保存修改" CssStyle="border:1px solid black" Icon="SystemSave" EnablePostBack="true" OnClick="btn_Save_Click"></x:Button>
                            </Items>
                        </x:Toolbar>
                    </Toolbars>
                    <Items>
                        <x:Grid ID="Grid1" runat="server" EnableCheckBoxSelect="true" EnableRowNumber="true"
                            Title="汇票信息" EnableBackgroundColor="true" BoxFlex="1" EnableMouseOverColor="true"
                            AllowCellEditing="true" ClicksToEdit="2">
                            <Columns>
                                <x:BoundField HeaderText="合作行" DataField="BankName" />
                                <x:BoundField HeaderText="经销商" DataField="DealerName" />
                                <x:RenderField HeaderText="保证金账号" DataField="GuaranteeNo" FieldType="String" Width="150px" ColumnID="GuaranteeNo">
                                    <Editor>
                                        <x:TextBox ID="txt_GuaranteeNo" runat="server" Required="true">
                                        </x:TextBox>
                                    </Editor>
                                </x:RenderField>
                                <x:RenderField HeaderText="承兑汇票协议号/质押号" DataField="PledgeNo" FieldType="String" Width="150px" ColumnID="PledgeNo">
                                    <Editor>
                                        <x:TextBox ID="txtEngineNo" runat="server" Required="true">
                                        </x:TextBox>
                                    </Editor>
                                </x:RenderField>
                                <x:RenderField HeaderText="汇票号" DataField="DraftNo" FieldType="String" Width="200px" ColumnID="DraftNo">
                                    <Editor>
                                        <x:TextBox ID="txt_DraftNo" runat="server" Required="true">
                                        </x:TextBox>
                                    </Editor>
                                </x:RenderField>
                                <x:RenderField HeaderText="开票日" DataField="BeginTime" FieldType="String" Width="110px" ColumnID="BeginTime"
                                    RendererArgument="yyyy-MM-dd">
                                    <Editor>
                                        <x:DatePicker ID="dp_BeginTime" runat="server" DateFormatString="yyyy-MM-dd"></x:DatePicker>
                                    </Editor>
                                </x:RenderField>
                                <x:RenderField HeaderText="到期日" DataField="EndTime" FieldType="String" Width="110px" ColumnID="EndTime"
                                    RendererArgument="yyyy-MM-dd">
                                    <Editor>
                                        <x:DatePicker ID="dp_EndTime" DateFormatString="yyyy-MM-dd" runat="server"></x:DatePicker>
                                    </Editor>
                                </x:RenderField>
                                <x:RenderField HeaderText="票面金额" DataField="DraftMoney" FieldType="Float" Width="100px" ColumnID="DraftMoney">
                                    <Editor>
                                        <x:NumberBox ID="num_DraftMoney" Required="true" DecimalPrecision="2" runat="server"></x:NumberBox>
                                    </Editor>
                                </x:RenderField>
                            </Columns>
                        </x:Grid>
                    </Items>
                </x:Panel>
            </Items>
        </x:Panel>
        <x:Window ID="Window_ShowMessage" runat="server" BodyPadding="5px" Height="350px" IsModal="true" Popup="true"
            Title="" Width="500px" EnableBackgroundColor="true" Hidden="true" Layout="Fit">
            <Items>
                <x:TextArea ID="txt_Message" runat="server" HideScrollbars="true" Readonly="true" Text=""></x:TextArea>
            </Items>
        </x:Window>
    </form>
</body>
</html>
