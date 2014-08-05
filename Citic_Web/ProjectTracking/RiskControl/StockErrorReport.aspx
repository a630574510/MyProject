<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StockErrorReport.aspx.cs" Inherits="Citic_Web.ProjectTracking.RiskControl.StockErrorReport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script type="text/javascript" src="../../Js/jquery-1.7.1.min.js"></script>
    <link href="../../css/main.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .mygrid-row-summary.x-grid3-row {
            background-color: #efefef !important;
            background-image: none !important;
            border-color: #fff #ededed #ededed !important;
            visibility: hidden;
        }

            .mygrid-row-summary.x-grid3-row .x-grid3-td-numberer, .mygrid-row-summary.x-grid3-row .x-grid3-td-checker {
                background-image: none !important;
            }

                .mygrid-row-summary.x-grid3-row .x-grid3-td-numberer .x-grid3-col-numberer, .mygrid-row-summary.x-grid3-row .x-grid3-td-checker .x-grid3-col-checker {
                    display: none;
                }

            .mygrid-row-summary.x-grid3-row td {
                font-size: 14px;
                line-height: 16px;
                font-weight: bold;
                color: red;
            }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <x:PageManager ID="PageManager1" runat="server" AutoSizePanelID="Panel1" />
        <x:Panel ID="Panel1" runat="server" BodyPadding="0px" ShowBorder="true" ShowHeader="true" Title="日查库异常汇总"
            EnableBackgroundColor="true" Layout="Fit">
            <Toolbars>
                <x:Toolbar ID="Toolbar1" runat="server">
                    <Items>
                        <x:Button ID="btn_Search" runat="server" Text="查询" OnClick="btn_Search_Click"></x:Button>
                    </Items>
                </x:Toolbar>
            </Toolbars>
            <Items>
                <x:Grid ID="grid_List" runat="server" ShowBorder="false" ShowHeader="false" EnableBackgroundColor="true"
                    EnableTextSelection="true" EnableCheckBoxSelect="true" IsDatabasePaging="false" AllowPaging="false"
                    DataKeyNames="ID,BankID,DealerID" OnPageIndexChange="grid_List_PageIndexChange" PageSize="15" EnableRowNumber="true">
                    <Columns>
                        <x:BoundField HeaderText="经销店" DataField="DealerName" Width="300px" />
                        <x:BoundField HeaderText="合作行" DataField="BankName" Width="200px" />
                        <x:BoundField HeaderText="品牌" DataField="BrandName" Width="100px" />
                    </Columns>
                </x:Grid>
            </Items>
        </x:Panel>
        <x:HiddenField ID="hfSelectedIDS" runat="server">
        </x:HiddenField>
        <x:HiddenField ID="hf_GridSummary" runat="server">
        </x:HiddenField>
    </form>
    <script>

        var gridClientID = '<%= grid_List.ClientID %>';
        var gridSummaryID = '<%= hf_GridSummary.ClientID %>';
        var btn = '<%= btn_Search.ClientID %>';

        function calcGridSummary(grid) {
            var donateTotal = 0, store = grid.getStore(), view = grid.getView(), storeCount = store.getCount();

            // 防止重复添加了合计行
            if (Ext.get(view.getRow(storeCount - 1)).hasClass('mygrid-row-summary')) {
                return;
            }

            // 从隐藏字段获取全部数据的汇总
            var summaryJSON = JSON.parse(X(gridSummaryID).getValue());

            store.add(new Ext.data.Record({
                'major': '全部合计：',
                //'donate': summaryJSON['donateTotal'].toFixed(2),
                //'fee': summaryJSON['feeTotal'].toFixed(2)
                'szsmcount': summaryJSON['szsmcount'].toFixed(2),
                'xswhkcount': summaryJSON['xswhkcount'].toFixed(2),
                'szydcount': summaryJSON['szydcount'].toFixed(2),
                'zsclcount': summaryJSON['zsclcount'].toFixed(2),
                'zyczsjccount': summaryJSON['zyczsjccount'].toFixed(2),
                'zyclbcount': summaryJSON['zyclbcount'].toFixed(2)
            }));


            // 为合计行添加自定义样式（隐藏序号列、复选框列，取消 hover 和 selected 效果）
            var summaryNode = Ext.get(view.getRow(storeCount)).addClass('mygrid-row-summary');

            // 找到合计行的外部容器节点
            var viewportNode = summaryNode.parent('.x-grid3-viewport');
            // 删除容器节点下直接子节点为 mygrid-row-summary 的节点
            viewportNode.select('> .mygrid-row-summary').remove();

            // 创建合计行的副本
            var cloneSummaryNode = summaryNode.dom.cloneNode(true);
            // 修改合计行的副本的样式，绝对定位，距离底部0px，显示副本（默认是占位隐藏 visibility: hidden;）
            Ext.get(cloneSummaryNode).setStyle({
                position: 'absolute',
                bottom: 0,
                visibility: 'visible'
            });

            // 向容器节点添加合计行的副本
            viewportNode.appendChild(cloneSummaryNode);

        }

        // 页面第一个加载完毕后执行的函数
        function onReady() {
            $("#" + btn).click(function () {
                var grid = X(gridClientID);
                grid.addListener('viewready', function () {
                    calcGridSummary(grid);
                });
                // 防止选中合计行
                grid.getSelectionModel().addListener('beforerowselect', function (sm, rowIndex, keepExisting, record) {
                    if (Ext.get(grid.getView().getRow(rowIndex)).hasClass('mygrid-row-summary')) {
                        return false;
                    }
                    return true;
                });
            });
        }

        // 页面AJAX回发后执行的函数
        function onAjaxReady() {
            var grid = X(gridClientID);
            calcGridSummary(grid);
        }
    </script>
</body>
</html>
