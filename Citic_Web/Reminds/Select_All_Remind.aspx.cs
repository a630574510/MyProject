using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Citic.BLL;

namespace Citic_Web.Reminds
{
    public partial class Select_All_Remind : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dataTree();
                EnabledTab(true);
            }
        }
        #region 获取银行绑定Tree
        /// <summary>
        /// 获取银行列表
        /// </summary>
        private void dataTree()
        {
            try
            {
                DataSet ds = new DataSet();
                int RoleId = this.CurrentUser.RoleId;       //获取角色id
                switch (RoleId)
                {
                    case 1:         //1为超级管理员
                       ds = new Remind().GetRemindByBankId("select distinct(B_L.BankName),B_L.BankID from  tb_Remind r left join tb_Bank_List B_L on B_L.BankID=r.BankID where 1=1 order by B_L.BankName asc");
                        break;
                    case 2:         //2为管理员
                        break;
                    case 3:         //3为业务经理
                        break;
                    case 4:         //4为市场经理
                        break;
                    case 5:         //5为市场专员
                        int UserID_5 = this.CurrentUser.UserId;
                        ds = new Remind().GetRemindByBankId("select distinct(B_L.BankName),B_L.BankID from  tb_Remind r left join tb_Bank_List B_L on B_L.BankID=r.BankID where 1=1 and B_L.BankID in(select MappingID from tb_UserMapping where UserID=" + UserID_5 + " and RoleID=5)");
                        break;
                    case 6:         //6为品牌专员
                        int UserID_6 = this.CurrentUser.UserId;
                        ds = new Remind().GetRemindByBankId("select distinct(B_L.BankName),B_L.BankID from  tb_Remind r left join tb_Bank_List B_L on B_L.BankID=r.BankID where 1=1 and B_L.BankID in(select MappingID from tb_UserMapping where UserID=" + UserID_6 + " and RoleID=6)");
                        break;
                    case 7:         //7为调配专员
                        break;
                    case 8:         //8为银行
                        break;
                    case 9:         //9为厂家
                        break;
                    case 10:         //10为监管员
                        break;
                }
                
                DataView dv = ds.Tables[0].DefaultView;
                foreach (DataRowView dsTree in dv)
                {
                    FineUI.TreeNode tn = new FineUI.TreeNode();
                    tn.Text = dsTree["BankName"].ToString();
                    tn.NodeID = dsTree["BankID"].ToString();
                    tn.Expanded = false;
                    tn.EnablePostBack = true;
                    tn.Icon = FineUI.Icon.ArrowRight;
                    this.T_Bank.Nodes.Add(tn);

                }
            }
            catch
            {
                FineUI.Alert.ShowInTop("与服务器无法链接,获取银行信息", FineUI.MessageBoxIcon.Error);
            }
        }
        #endregion

        #region 树形菜单事件
        /// <summary>
        /// 树形菜单点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void T_Bank_OnNodeCommand(object sender, FineUI.TreeCommandEventArgs e)
        {
            this.Panel4.Title = "提醒类容—<span style='color:Red'>" + e.Node.Text + "</span>";
            EnabledTab(false);
            DataSet ds = BankIDByRemind(T_Bank.SelectedNode.NodeID);
            Remind1.DataSource = ds.Tables[0].Select("Status=1");
            Remind1.DataBind();
            Remind2.DataSource = ds.Tables[0].Select("Status=2");
            Remind2.DataBind();
            Remind3.DataSource = ds.Tables[0].Select("Status=3");
            Remind3.DataBind();
            Remind4.DataSource = ds.Tables[0].Select("Status=4");
            Remind4.DataBind();
            Remind5.DataSource = ds.Tables[0].Select("Status=5");
            Remind5.DataBind();
            Remind6.DataSource = ds.Tables[0].Select("Status=6");
            Remind6.DataBind();
            Remind7.DataSource = ds.Tables[0].Select("Status=7");
            Remind7.DataBind();
            Remind8.DataSource = ds.Tables[0].Select("Status=8");
            Remind8.DataBind();
            Remind9.DataSource = ds.Tables[0].Select("Status=9");
            Remind9.DataBind();
            Remind10.DataSource = ds.Tables[0].Select("Status=10");
            Remind10.DataBind();
            Remind11.DataSource = ds.Tables[0].Select("Status=11");
            Remind11.DataBind();
            Remind12.DataSource = ds.Tables[0].Select("Status=12");
            Remind12.DataBind();
            Remind13.DataSource = ds.Tables[0].Select("Status=13");
            Remind13.DataBind();
            Remind14.DataSource = ds.Tables[0].Select("Status=14");
            Remind14.DataBind();
            Remind15.DataSource = ds.Tables[0].Select("Status=15");
            Remind15.DataBind();
        }
        #endregion
        int i = 0;
        protected void TS_Remind_OnTabIndexChanged(object sender, EventArgs e)
        {
            if (i == 1)
            {
                string[] str = this.Panel4.Title.Split('—');
                string Leves = T_Bank.SelectedNode.NodeID;
                string Title = str[0] + "—" + str[1];
                if (TS_Remind.ActiveTabIndex == 0)
                {
                    this.Panel4.Title = Title + "—<span style='color:Red'>" + TS_Remind.Tabs[TS_Remind.ActiveTabIndex].Title + "</span>";
                }
                else if (TS_Remind.ActiveTabIndex == 1)
                {
                    this.Panel4.Title = Title + "—<span style='color:Red'>" + TS_Remind.Tabs[TS_Remind.ActiveTabIndex].Title + "</span>";
                }
                else if (TS_Remind.ActiveTabIndex == 2)
                {
                    this.Panel4.Title = Title + "—<span style='color:Red'>" + TS_Remind.Tabs[TS_Remind.ActiveTabIndex].Title + "</span>";
                }
                else if (TS_Remind.ActiveTabIndex == 3)
                {
                    this.Panel4.Title = Title + "—<span style='color:Red'>" + TS_Remind.Tabs[TS_Remind.ActiveTabIndex].Title + "</span>";
                }
                else if (TS_Remind.ActiveTabIndex == 4)
                {
                    this.Panel4.Title = Title + "—<span style='color:Red'>" + TS_Remind.Tabs[TS_Remind.ActiveTabIndex].Title + "</span>";
                }
                else if (TS_Remind.ActiveTabIndex == 5)
                {
                    this.Panel4.Title = Title + "—<span style='color:Red'>" + TS_Remind.Tabs[TS_Remind.ActiveTabIndex].Title + "</span>";
                }
                else if (TS_Remind.ActiveTabIndex == 6)
                {
                    this.Panel4.Title = Title + "—<span style='color:Red'>" + TS_Remind.Tabs[TS_Remind.ActiveTabIndex].Title + "</span>";
                }
                else if (TS_Remind.ActiveTabIndex == 7)
                {
                    this.Panel4.Title = Title + "—<span style='color:Red'>" + TS_Remind.Tabs[TS_Remind.ActiveTabIndex].Title + "</span>";
                }
            }
            i++;
        }
        protected void Btn_Select_Bank_OnClick(object sender, EventArgs e)
        {
            string text = this.T_B_Bank.Text;
            T_Bank.SelectedNodeID = text;
            FineUI.TreeNode tnRet = null;
            foreach (FineUI.TreeNode tn in T_Bank.Nodes)    //T_Bank 为treeview   
            {
                tnRet = FindNode(tn, text.Trim());

                if (tnRet != null)
                {
                    T_Bank.SelectedNodeID = tnRet.NodeID;   //找到就选中

                    break;
                }
            }
        }

        #region 查找Tree节点
        /// <summary>
        /// 模糊查找Tree节点
        /// </summary>
        /// <param name="tnParent"></param>
        /// <param name="strValue">模糊查找的字符</param>
        /// <returns></returns>
        private FineUI.TreeNode FindNode(FineUI.TreeNode tnParent, string strValue)
        {

            if (tnParent == null) return null;

            if (tnParent.Text.IndexOf(strValue) > -1)   //如果不需要模糊，这里改为tnParent.Text==strValue   
            {
                return tnParent;
            }

            FineUI.TreeNode tnRet = null;

            foreach (FineUI.TreeNode tn in tnParent.Nodes)
            {

                tnRet = FindNode(tn, strValue);

                if (tnRet != null) break;

            }
            return tnRet;

        }
        #endregion

        #region 根据银行查提醒信息
        /// <summary>
        /// 查询银行提醒信息
        /// </summary> 
        /// <param name="BankID">银行id</param>
        /// <returns></returns>
        private DataSet BankIDByRemind(string BankID)
        {
            try
            {
                DataSet ds = new Remind().GetList("BankID='" + BankID + "' and Status between 1 and 15");
                return ds;
            }
            catch
            {

            }
            return new DataSet();

        }
        #endregion

        #region 控制选项卡显示
        /// <summary>
        /// 设置选项卡是否隐藏
        /// </summary>
        /// <param name="tab"></param>
        private void EnabledTab(bool tab)
        {
            int Count = TS_Remind.Tabs.Count;
            for (int i = 0; i < Count; i++)
            {
                TS_Remind.Tabs[i].Hidden = tab;
            }
        }
        #endregion

        #region 确定按钮事件
        /// <summary>
        /// 表格确定按钮 张繁 2013年7月12日
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Btn_All(object sender, EventArgs e)
        {
            FineUI.Button btn = (FineUI.Button)sender;      //转换为btn按钮
            List<string> List_Key = new List<string>();
            switch (btn.ID)
            {
                case "btn_Remind1":          //进驻7日未交监管费提醒
                    List_Key = GridKeyList(this.Remind1);
                    break;
                case "btn_Remind2":          //监管费到期7日提醒
                    List_Key = GridKeyList(this.Remind2);
                    break;
                case "btn_Remind3":          //0库存0承兑汇票提醒
                    List_Key = GridKeyList(this.Remind3);
                    break;
                case "btn_Remind4":          //3日质押物未出库提醒
                    List_Key = GridKeyList(this.Remind4);
                    break;
                case "btn_Remind12":     //开票15日未收质押物提醒
                    List_Key = GridKeyList(this.Remind12);
                    break;
                case "btn_Remind13":       //开票30日未押满汇票金额提醒
                    List_Key = GridKeyList(this.Remind13);
                    break;
                case "btn_Remind14":       //汇票到期未押满票面金额提前15日提醒
                    List_Key = GridKeyList(this.Remind14);
                    break;
                case "btn_Remind15":       //汇票到期提前7日提醒
                    List_Key = GridKeyList(this.Remind15);
                    break;
                case "btn_Remind7":       //新进店未进监管员提醒
                    List_Key = GridKeyList(this.Remind7);
                    break;
                case "btn_Remind8":       //停止合作店面提醒
                    List_Key = GridKeyList(this.Remind8);
                    break;
                case "btn_Remind11":       //更换监管员提醒
                    List_Key = GridKeyList(this.Remind11);
                    break;
                case "btn_Remind5":       //质押物在途5天未入库提醒
                    List_Key = GridKeyList(this.Remind5);
                    break;
                case "btn_Remind9":       //经销商剩余一张汇票提醒
                    List_Key = GridKeyList(this.Remind9);
                    break;
                case "btn_Remind6":       //经销商剩余10台车提醒
                    List_Key = GridKeyList(this.Remind6);
                    break;
                case "btn_Remind10":       //经销商剩余10光大总行拟驻点提醒
                    List_Key = GridKeyList(this.Remind10);
                    break;
            }
            if (List_Key.Count == 0)
            {
                FineUI.Alert.ShowInTop("没有选中任何行", FineUI.MessageBoxIcon.Error);
            }
            else
            {
                List<string> List_Sql = new List<string>();
                for (int i = 0; i < List_Key.Count; i++)
                {
                    //此处获取Key值Id，拼接sql
                    //string KeyId = List_Key[i].ToString();

                    List_Sql.Add("update tb_Remind set [Status]='16' where ID='" + List_Key[i].ToString() + "'");

                }
                if (CarBll.SqlTran(List_Sql) > 0)
                {
                    FineUI.Alert.ShowInTop("修改成功！");
                }
                else
                {
                    FineUI.Alert.ShowInTop("修改失败！");
                }
            }
        }
        #endregion

        #region 获取GirdKey值

        /// <summary>
        /// 获取Grid索引绑定Key值 张繁 2013年7月12日
        /// </summary>
        /// <param name="GridId">传入Grid对象</param>
        /// <returns>获取Key添加List集合</returns>
        private List<string> GridKeyList(FineUI.Grid dr)
        {
            try
            {
                List<string> List_Key = new List<string>();
                //获取Grid复选框选中的集合
                int[] CountIndex = dr.SelectedRowIndexArray;
                if (CountIndex.Length > 0)
                {
                    for (int i = 0; i < CountIndex.Length; i++)
                    {
                        //将Key值添加到List集合中
                        List_Key.Add(dr.Rows[CountIndex[i]].DataKeys[0].ToString());
                    }
                }
                return List_Key;
            }
            catch (Exception)
            {

                throw;
            }

        }
        #endregion

    }
}