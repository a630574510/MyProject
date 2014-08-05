using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Xml;
using System.IO;

using FineUI;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
namespace Citic_Web.DealerManagement.DealerInfo
{
    public partial class AddDealer : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //清空ViewState的值
                ViewState.Clear();
                DataTableInit();
                WUC_Address.Init();
                //加载内存中的数据
                //LoadDataInViewState();
                LoadDataInXMLDocument();
                LoadBankInfo();

            }
        }

        #region 显示被添加了的联系人--乔春羽
        private void LinkmanDataBind()
        {
            if (this.DtLinkman != null)
            {
                DataView dv = new DataView(DtLinkman);

                dv.RowFilter = "dc_Type=" + Convert.ToInt32(Citic_Web.Common.LinkType.DealerLinkman);
                grid_List1.DataSource = dv;
                grid_List1.DataBind();

                dv.RowFilter = "dc_Type=" + Convert.ToInt32(Citic_Web.Common.LinkType.DealerBankLinkman);
                grid_List2.DataSource = dv;
                grid_List2.DataBind();
            }
        }
        #endregion

        #region PrivateFields--乔春羽
        public DataTable DtLinkman
        {
            get { return (DataTable)ViewState[LINKMAN_DT]; }
            set { ViewState[LINKMAN_DT] = value; }
        }
        private const string LINKMAN_DT = "dt_Linkman";

        public string DealerNameInSession
        {
            get { return (string)ViewState["DealerName"]; }
            set { ViewState["DealerName"] = value; }
        }

        private string DealerID
        {
            get
            {
                if (ViewState["DealerID"] == null)
                {
                    ViewState["DealerID"] = string.Empty;
                }
                return (string)ViewState["DealerID"];
            }
            set { ViewState["DealerID"] = value; }
        }

        private string OrganizationCode
        {
            get
            {
                string value = string.Empty;
                if (!string.IsNullOrEmpty(this.txt_OrganizationCode.Text.Trim()))
                {
                    value = this.txt_OrganizationCode.Text.Trim();

                    if (value.Length == 10 && value.IndexOf('-') > 0 && value.IndexOf('-') == 8 && value.LastIndexOf('-') == 8)
                    {
                        value = this.txt_OrganizationCode.Text.Trim();
                    }
                    else if (value.Length == 9 && value.IndexOf('-') <= 0)
                    {
                        value = string.Format("{0}-{1}", value.Substring(0, 8), value.Substring(8, 1));
                    }
                    else { value = string.Empty; }
                }
                return value;
            }
        }

        /// <summary>
        /// 临时数据
        /// 在查询经销商的时候，把查询出来的经销商基本数据存入到这里边
        /// 就一条数据
        /// </summary>
        private DataTable TempDealerInfoDataTable
        {
            get { return (DataTable)ViewState["temp"]; }
            set { ViewState["temp"] = value; }
        }

        /// <summary>
        /// 临时数据的存储文件名
        /// </summary>
        private string TempXMLName
        {
            get { return (string)Session["xmlFileName"]; }
            set { Session["xmlFileName"] = value; }
        }
        #endregion

        #region 初始化成员变量--乔春羽
        /// <summary>
        /// 初始化DataTable表结构
        /// </summary>
        private void DataTableInit()
        {
            DataTable dtLinkman = new DataTable();

            DataColumn dc1 = new DataColumn();
            dc1.DataType = typeof(string);
            dc1.DefaultValue = string.Empty;
            dc1.ColumnName = "dc_Name";
            DataColumn dc2 = new DataColumn();
            dc2.DataType = typeof(string);
            dc2.DefaultValue = string.Empty;
            dc2.ColumnName = "dc_Phone";
            DataColumn dc3 = new DataColumn();
            dc3.DataType = typeof(Int32);
            dc3.DefaultValue = 0;
            dc3.ColumnName = "dc_Type";
            DataColumn dc4 = new DataColumn();
            dc4.DataType = typeof(Int32);
            dc4.DefaultValue = 1;
            dc4.ColumnName = "dc_ID";
            DataColumn dc5 = new DataColumn();
            dc5.DataType = typeof(string);
            dc5.DefaultValue = string.Empty;
            dc5.ColumnName = "dc_Fax";
            DataColumn dc6 = new DataColumn();
            dc6.DataType = typeof(string);
            dc6.DefaultValue = string.Empty;
            dc6.ColumnName = "dc_Email";

            dtLinkman.Columns.Add(dc1);
            dtLinkman.Columns.Add(dc2);
            dtLinkman.Columns.Add(dc3);
            dtLinkman.Columns.Add(dc4);
            dtLinkman.Columns.Add(dc5);
            dtLinkman.Columns.Add(dc6);

            DtLinkman = dtLinkman;
        }
        #endregion

        #region 添加联系人，不存数据库--乔春羽
        /// <summary>
        /// 向DT中添加数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_Add(object sender, EventArgs e)
        {
            FineUI.Button btn = sender as FineUI.Button;
            if (btn != null)
            {
                DataRow dr = DtLinkman.NewRow();
                if (btn.ID == "btn_AddLinkman1")
                {
                    dr["dc_Name"] = txt_LinkmanName1.Text;
                    dr["dc_Phone"] = num_Phone1.Text;
                    dr["dc_Type"] = Convert.ToInt32(Citic_Web.Common.LinkType.DealerLinkman);
                    dr["dc_Fax"] = this.txt_Fax1.Text;
                    dr["dc_Email"] = this.txt_Email1.Text;
                }
                else if (btn.ID == "btn_AddLinkman2")
                {
                    dr["dc_Name"] = txt_LinkmanName2.Text;
                    dr["dc_Phone"] = num_Phone2.Text;
                    dr["dc_Type"] = Convert.ToInt32(Citic_Web.Common.LinkType.DealerBankLinkman);
                    dr["dc_Fax"] = this.txt_Fax2.Text;
                    dr["dc_Email"] = this.txt_Email2.Text;
                }
                dr["dc_ID"] = GetMaxIDForDt();
                DtLinkman.Rows.Add(dr);
                LinkmanDataBind();
            }
        }

        /// <summary>
        /// 获得DtLinkman中最大的ID
        /// </summary>
        /// <returns></returns>
        private int GetMaxIDForDt()
        {
            int id = 0;
            for (int i = 0; i < DtLinkman.Rows.Count; i++)
            {
                int dc_ID = Convert.ToInt32(DtLinkman.Rows[i]["dc_ID"]);
                if (dc_ID > id)
                {
                    id = dc_ID;
                    continue;
                }
            }
            id = id + 1;
            return id;
        }
        #endregion

        #region 行命令事件（联系人）--乔春羽
        protected void grid_List_RowCommand(object sender, FineUI.GridCommandEventArgs e)
        {
            FineUI.Grid grid = sender as FineUI.Grid;
            if (grid != null)
            {
                if (e.CommandName != null && e.CommandName != string.Empty)
                {
                    if (e.CommandName == "delete")
                    {
                        int dc_ID = Convert.ToInt32(grid.DataKeys[e.RowIndex][0]);
                        if (grid.ID == "grid_List1")
                        {
                            RemoveDateForDt(Convert.ToInt32(Citic_Web.Common.LinkType.DealerLinkman), dc_ID);
                        }
                        else if (grid.ID == "grid_List2")
                        {
                            RemoveDateForDt(Convert.ToInt32(Citic_Web.Common.LinkType.DealerBankLinkman), dc_ID);
                        }
                        LinkmanDataBind();
                    }
                }
            }
        }
        #endregion

        #region 行命令事件（合作行）--乔春羽
        protected void grid_BankList_RowCommand(object sender, GridCommandEventArgs e)
        {
            if (e.RowIndex >= 0 && e.CommandName == "del")
            {
                int bankID = Convert.ToInt32(this.grid_BankList.DataKeys[e.RowIndex][0]);
                int brandID = Convert.ToInt32(this.grid_BankList.DataKeys[e.RowIndex][2]);
                for (int i = 0; i < Banks.Count; i++)
                {
                    if (Banks[i].BankID == bankID && Banks[i].BrandID == brandID)
                    {
                        Banks.RemoveAt(i);
                        break;
                    }
                }
                //将Session中的数据，绑定到Grid中显示
                grid_BankList.DataSource = Banks;
                grid_BankList.DataBind();
            }
        }
        #endregion

        #region 保存联系人，入数据库--乔春羽
        /// <summary>
        /// 保存联系人--乔春羽
        /// </summary>
        private int SaveLinkman(int type, int dealerID)
        {
            int num = 0;
            DataView dv = new DataView(DtLinkman);
            dv.RowFilter = "dc_Type=" + type;

            DataTable dt = dv.ToTable();
            List<Citic.Model.Linkman> lists = new List<Citic.Model.Linkman>();
            foreach (DataRow item in dt.Rows)
            {
                Citic.Model.Linkman model = new Citic.Model.Linkman();
                model.ConnectID = string.Empty;
                model.CreateID = this.CurrentUser.UserId;
                model.CreateTime = DateTime.Now;
                model.DeleteID = 0;
                model.UpdateID = 0;
                model.Email = string.Empty;
                model.IsDelete = false;
                model.IsPort = false;
                model.LinkmanName = item["dc_Name"].ToString();
                model.LinkType = type;
                model.Phone = item["dc_Phone"].ToString();
                model.Post = string.Empty;
                model.RelationID = Convert.ToInt32(dealerID);

                lists.Add(model);
            }
            try
            {
                if (lists.Count > 0)
                {
                    num = LinkmanBll.AddRange(lists.ToArray());
                    if (num > 0)
                    {
                        RemoveDateForDt(type);
                        LinkmanDataBind();
                    }
                }
            }
            catch (Exception e)
            {
                Logging.WriteLog(e, HttpContext.Current.Request.Url.AbsolutePath, "SaveLinkman()");
            }
            return num;
        }

        /// <summary>
        /// 删除DataTable中的数据--乔春羽
        /// </summary>
        /// <param name="type"></param>
        private void RemoveDateForDt(int type)
        {
            for (int i = 0; i < DtLinkman.Rows.Count; i++)
            {
                if (Convert.ToInt32(DtLinkman.Rows[i]["dc_Type"]) == type)
                {
                    DtLinkman.Rows.RemoveAt(i);
                    i--;
                    continue;
                }
            }
        }

        /// <summary>
        /// 删除DataTable中的数据--乔春羽
        /// </summary>
        /// <param name="type"></param>
        private void RemoveDateForDt(int type, int id)
        {
            for (int i = 0; i < DtLinkman.Rows.Count; i++)
            {
                if (Convert.ToInt32(DtLinkman.Rows[i]["dc_Type"]) == type)
                {
                    if (Convert.ToInt32(DtLinkman.Rows[i]["dc_ID"]) == id)
                    {
                        DtLinkman.Rows.RemoveAt(i);
                        i--;
                        continue;
                    }
                }
            }
        }

        private bool ValidateDealerID()
        {
            return ViewState["ID"] == null ? true : false;
        }
        #endregion

        #region //保存经销商（首先保存经销商信息；其次保存合作行信息；第三保存联系人信息；第四添加一个二网信息，该二网为新添加经销商的本库）--乔春羽
        protected void btn_SaveDeader_Click(object sender, EventArgs e)
        {
            if (Banks == null || Banks.Count <= 0)
            {
                AlertShowInTop("请选择合作行！");
                return;
            }
            if (string.IsNullOrEmpty(this.txt_DealerName.Text.Trim()))
            {
                AlertShowInTop("请填写经销商的名字!");
                return;
            }
            if (string.IsNullOrEmpty(this.OrganizationCode))
            {
                AlertShowInTop("请填写正确的组织机构代码!");
                return;
            }
            //判断DealerID是否有值
            //DealerID的值，是根据用户所填写的经销商名称与组织机构代码为条件从tb_Dealer_List中查询得出
            //如果该值不存在则表示所输入的经销商是一个新的经销商，则tb_Dealer_List的数据需要添加
            if (string.IsNullOrEmpty(DealerID))
            {
                DealerID = SaveDealer().ToString();
            }
            //否则，不修改该经销商的数据
            else
            {
                //ModifyDealer();
            }
            if (!string.IsNullOrEmpty(DealerID))
            {
                string bankMess = string.Empty;
                string link1Mess = string.Empty;
                string link2Mess = string.Empty;
                int bank = SaveBank(int.Parse(DealerID));
                int link1 = SaveLinkman(Convert.ToInt32(Citic_Web.Common.LinkType.DealerLinkman), int.Parse(DealerID));
                int link2 = SaveLinkman(Convert.ToInt32(Citic_Web.Common.LinkType.DealerBankLinkman), int.Parse(DealerID));

                if (bank >= 0 || link1 > 0 || link2 > 0)
                {
                    AlertShowInTop("添加成功！");

                    File.Delete(string.Format("C://{0}", this.TempXMLName));

                    ClearSession();
                    // 2. 关闭本窗体，然后刷新父窗体
                    PageContext.RegisterStartupScript(ActiveWindow.GetHideRefreshReference());
                }
                else
                {
                    AlertShowInTop(bankMess + "\r\n" + link1Mess + "\r\n" + link2Mess);
                }
            }
            else
            {
                AlertShowInTop("经销商添加失败！");
            }
        }

        private void ClearSession()
        {
            //清空Session中的存值
            Session.Remove("BankIDs");
            Session.Remove("BankNames");
            Session.Remove("bank_jsons");
            Session.Remove("dt_Brand");
            Session.Remove("model");
            Session.Remove("xmlFileName");
            Session.Remove(LINKMAN_DT);
        }

        public int SaveBank(int dealerID)
        {
            int num = 0;
            foreach (Citic.Model.Dealer_Bank model in Banks)
            {
                model.DealerID = dealerID;
                model.DealerName = this.txt_DealerName.Text;
                model.JC = this.txt_JC.Text;
            }
            try
            {
                if (Banks.Count > 0)
                {
                    num = Dealer_BankBll.AddRange(Banks.ToArray());
                    if (num > 0)
                    {
                        grid_BankList.Rows.Clear();
                        grid_BankList.DataSource = null;
                    }
                }
            }
            catch (Exception e)
            {
                num = -11;
                Logging.WriteLog(e, HttpContext.Current.Request.Url.AbsolutePath, "SaveBank()");
            }
            return num;
        }

        #region 保存经销商
        /// <summary>
        /// 保存经销商--乔春羽
        /// </summary>
        private int SaveDealer()
        {
            int dealerID = 0;
            try
            {
                Citic.Model.Dealer model = new Citic.Model.Dealer();
                model.DealerName = this.txt_DealerName.Text;

                model.Address = GetAddress();
                model.CreateID = this.CurrentUser.UserId;
                model.CreateTime = DateTime.Now;
                model.DealerType = string.Join(",", cbl_DealerType.SelectedValueArray);
                model.IsGroup = chk_IsGroup.Checked;
                model.HasOtherIndustries = this.txt_OtherIndustries.Text;
                model.GotoworkTime = ddl_GotoworkTime.SelectedValue;
                model.GoffworkTime = ddl_GoffworkTime.SelectedValue;
                model.IsDelete = false;
                model.IsPort = false;
                model.DealerPayCode = this.OrganizationCode;
                model.Remarks = this.txt_Remark.Text;
                model.ConnectID = string.Empty;
                model.UpdateID = 0;
                model.DeleteID = 0;
                model.SupervisorID = -1;
                model.SupervisorName = string.Empty;
                model.SupervisorDispatchTime = null;
                //经销商业务章
                model.ConnectID = this.txt_YWZ.Text;

                dealerID = DealerBll.CreateDealer(model);
                if (dealerID > 0)
                {
                    ViewState["ID"] = dealerID;
                    AlertShowInTop("添加成功！");
                }
                else
                {
                    AlertShowInTop("添加失败！");
                }
            }
            catch (Exception e)
            {
                AlertShowInTop("服务器正忙，请联系管理员！");
                Logging.WriteLog(e, HttpContext.Current.Request.Url.AbsolutePath, "SaveDealer()");
            }
            return dealerID;
        }
        #endregion

        #region 修改经销商
        private int ModifyDealer()
        {
            int result = 0;
            DataTable dt = this.TempDealerInfoDataTable;
            if (dt != null && dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                Citic.Model.Dealer model = new Citic.Model.Dealer()
                {
                    DealerID = int.Parse(DealerID),
                    DealerName = this.txt_DealerName.Text,
                    SupervisorID = Convert.ToInt32(row["SupervisorID"]),
                    SupervisorName = row["SupervisorName"].ToString(),
                    SupervisorDispatchTime = row.IsNull("SupervisorDispatchTime") ? DateTime.Parse("1900-1-1") : Convert.ToDateTime(row["SupervisorDispatchTime"]),
                    DealerType = string.Join(",", this.cbl_DealerType.SelectedValueArray),
                    IsGroup = this.chk_IsGroup.Checked,
                    HasOtherIndustries = this.txt_OtherIndustries.Text,
                    GotoworkTime = this.ddl_GotoworkTime.SelectedValue,
                    GoffworkTime = this.ddl_GoffworkTime.SelectedValue,
                    Address = GetAddress(),
                    DealerPayCode = this.OrganizationCode,
                    Remarks = this.txt_Remark.Text,
                    CreateID = Convert.ToInt32(row["CreateID"]),
                    CreateTime = row.IsNull("CreateTime") ? DateTime.Parse("1900-1-1") : Convert.ToDateTime(row["CreateTime"]),
                    UpdateID = this.CurrentUser.UserId,
                    UpdateTime = DateTime.Now,
                    IsDelete = false,
                    IsPort = false,
                    ConnectID = this.txt_YWZ.Text
                };

                try
                {
                    result = DealerBll.Update(model) ? 1 : 0;
                }
                catch (Exception)
                {

                }
            }
            return result;
        }
        #endregion

        /// <summary>
        /// 获取地址--乔春羽
        /// </summary>
        /// <returns></returns>
        private string GetAddress()
        {
            return WUC_Address.Value;
        }

        #endregion

        #region 关闭本页面，并刷新父页面--乔春羽
        protected void btn_Close_Click(object sender, EventArgs e)
        {
            //清空Session中的存值 
            ClearSession();
            PageContext.RegisterStartupScript(ActiveWindow.GetHideReference());
        }
        #endregion

        #region //选择银行时，保存页面数据--乔春羽
        protected void btn_ChoiseBank_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txt_DealerName.Text.Trim()))
            {
                AlertShowInTop("请填写经销商的名字!");
                return;
            }
            if (string.IsNullOrEmpty(this.OrganizationCode))
            {
                AlertShowInTop("请填写正确的组织机构代码!");
                return;
            }

            string strWhere = string.Format(" DealerName = '{0}' and DealerPayCode = '{1}' ", this.txt_DealerName.Text.Trim(), this.OrganizationCode);
            DataTable dt = this.DealerBll.GetList(1, strWhere, "DealerID").Tables[0];
            DataRow row = null;
            if (dt != null && dt.Rows.Count > 0)
            {
                row = dt.Rows[0];
                this.DealerID = row["DealerID"].ToString();
            }
            else
            {
                this.DealerID = string.Empty;
            }

            SaveDataInViewState(row);
            SaveDateInXmlDocument();

            WindowShowBank.IFrameUrl = "~/DealerManagement/DealerInfo/ChoiseBank.aspx?DealerID=" + this.DealerID + "&isAdd=1";
            WindowShowBank.Hidden = false;
        }

        #region 将临时数据存到XML文档中
        /// <summary>
        /// 将临时数据存到XML文档中
        /// </summary>
        private void SaveDateInXmlDocument()
        {
            //单独存一个数据
            Session["temp_Dealer"] = this.TempDealerInfoDataTable;

            //创建XML文档对象
            XmlDocument doc = new XmlDocument();
            //根节点
            XmlElement root = doc.CreateElement("Root");
            //添加根节点
            doc.AppendChild(root);

            //创建经销商的元素
            XmlElement ele_Father = null;
            ele_Father = doc.CreateElement("DealerBasic");
            root.AppendChild(ele_Father);

            //下边，添加各个子元素
            XmlElement ele_Temp = null;

            //经销商ID
            ele_Temp = doc.CreateElement("DealerID");
            ele_Temp.InnerText = this.DealerID;
            ele_Father.AppendChild(ele_Temp);

            //经销商名称
            ele_Temp = doc.CreateElement("DealerName");
            ele_Temp.InnerText = this.txt_DealerName.Text;
            ele_Father.AppendChild(ele_Temp);

            //经销商名称简称
            ele_Temp = doc.CreateElement("JC");
            ele_Temp.InnerText = this.txt_JC.Text;
            ele_Father.AppendChild(ele_Temp);

            //经销商属性
            ele_Temp = doc.CreateElement("DealerType");
            ele_Temp.InnerText = string.Join(",", this.cbl_DealerType.SelectedValueArray);
            ele_Father.AppendChild(ele_Temp);

            //是否是集团属性
            ele_Temp = doc.CreateElement("IsGroup");
            ele_Temp.InnerText = this.chk_IsGroup.Checked.ToString();
            ele_Father.AppendChild(ele_Temp);

            //其他产业
            ele_Temp = doc.CreateElement("OtherIndustries");
            ele_Temp.InnerText = this.txt_OtherIndustries.Text;
            ele_Father.AppendChild(ele_Temp);

            //上下班时间
            ele_Temp = doc.CreateElement("GotoworkTime");
            ele_Temp.InnerText = this.ddl_GotoworkTime.SelectedValue;
            ele_Father.AppendChild(ele_Temp);
            ele_Temp = doc.CreateElement("GoffworkTime");
            ele_Temp.InnerText = this.ddl_GoffworkTime.SelectedValue;
            ele_Father.AppendChild(ele_Temp);

            //组织机构代码
            ele_Temp = doc.CreateElement("DealerPayCode");
            ele_Temp.InnerText = this.OrganizationCode;
            ele_Father.AppendChild(ele_Temp);

            //经销商业务章
            ele_Temp = doc.CreateElement("YWZ");
            ele_Temp.InnerText = this.txt_YWZ.Text;
            ele_Father.AppendChild(ele_Temp);

            //地址
            ele_Temp = doc.CreateElement("Address");
            ele_Temp.InnerText = this.GetAddress();
            ele_Father.AppendChild(ele_Temp);

            //备注
            ele_Temp = doc.CreateElement("Remark");
            ele_Temp.InnerText = this.txt_Remark.Text;
            ele_Father.AppendChild(ele_Temp);

            //--------------------------------------------------
            //创建联系人列表元素
            ele_Father = doc.CreateElement("LinkmanList");
            root.AppendChild(ele_Father);

            //创建联系人的各个元素
            foreach (DataRow row in this.DtLinkman.Rows)
            {
                XmlElement linkman = doc.CreateElement("Linkman");
                ele_Father.AppendChild(linkman);
                //姓名
                ele_Temp = doc.CreateElement("dc_Name");
                ele_Temp.InnerText = row["dc_Name"].ToString();
                linkman.AppendChild(ele_Temp);

                //电话
                ele_Temp = doc.CreateElement("dc_Phone");
                ele_Temp.InnerText = row["dc_Phone"].ToString();
                linkman.AppendChild(ele_Temp);

                //传真
                ele_Temp = doc.CreateElement("dc_Fax");
                ele_Temp.InnerText = row["dc_Fax"].ToString();
                linkman.AppendChild(ele_Temp);

                //邮箱
                ele_Temp = doc.CreateElement("dc_Email");
                ele_Temp.InnerText = row["dc_Email"].ToString();
                linkman.AppendChild(ele_Temp);

                //类型
                ele_Temp = doc.CreateElement("dc_Type");
                ele_Temp.InnerText = row["dc_Type"].ToString();
                linkman.AppendChild(ele_Temp);

                //ID
                ele_Temp = doc.CreateElement("dc_ID");
                ele_Temp.InnerText = row["dc_ID"].ToString();
                linkman.AppendChild(ele_Temp);
            }

            //保存文件
            string fileName = string.Format("DealerTemp{0}.xml", ConvertLongDateTimeToUI(DateTime.Now));
            this.TempXMLName = fileName;
            try
            {
                doc.Save("C://" + fileName);
            }
            catch (Exception e)
            {
                AlertShowInTop(e.Message);
                Logging.WriteLog(e, HttpContext.Current.Request.Url.AbsolutePath, "SaveDateInXmlDocument()");
            }
        }
        #endregion

        /// <summary>
        /// 将临时数据存到应用程序内存中
        /// </summary>
        private void SaveDataInViewState(object obj)
        {
            if (obj != null)
            {
                Session["model"] = obj;
            }
            else
            {
                Citic.Model.Dealer model = new Citic.Model.Dealer();
                //经销商名
                model.DealerName = this.txt_DealerName.Text;
                //经销商打款账号
                model.DealerPayCode = this.OrganizationCode;
                //经销商简称
                model.JC = this.txt_JC.Text;
                ////地址
                //model.Address = GetAddress();
                ////备注
                //model.Remarks = this.txt_Remark.Text;
                ////经销商属性
                //model.DealerType = string.Join(",", cbl_DealerType.SelectedValueArray);
                ////是否是集团属性
                //model.IsGroup = this.chk_IsGroup.Checked;
                ////其他产业
                //model.HasOtherIndustries = this.txt_OtherIndustries.Text;
                ////上下班时间
                //model.GotoworkTime = this.ddl_GotoworkTime.Text;
                //model.GoffworkTime = this.ddl_GoffworkTime.Text;
                ////经销商业务章
                //model.ConnectID = this.txt_YWZ.Text;

                Session["model"] = model;
                //保存联系人信息
                //Session[LINKMAN_DT] = DtLinkman;
            }
        }
        #endregion

        #region 加载内存中的数据--乔春羽
        private void LoadDataInViewState()
        {
            if (Session["model"] != null)
            {
                Citic.Model.Dealer model = Session["model"] as Citic.Model.Dealer;
                //经销商名
                this.txt_DealerName.Text = model.DealerName;
                //组织机构代码
                this.txt_OrganizationCode.Text = model.DealerPayCode;
                //地址
                if (model.Address != null && model.Address != string.Empty)
                {
                    string[] adds = model.Address.Split('-');
                    if (adds.Length >= 3)
                    {
                        WUC_Address.Province = adds[0];
                        WUC_Address.City = adds[1];
                        WUC_Address.Address = adds[2];
                    }
                    else
                    {
                        WUC_Address.Address = model.Address;
                    }
                }
                //备注
                this.txt_Remark.Text = model.Remarks;
                //经销商属性
                this.cbl_DealerType.SelectedValueArray = model.DealerType.Split(',');
                //是否是集团性质
                this.chk_IsGroup.Checked = model.IsGroup;
                //其他产业
                this.txt_OtherIndustries.Text = model.HasOtherIndustries;
                //上下班时间
                this.ddl_GotoworkTime.SelectedValue = model.GotoworkTime;
                this.ddl_GoffworkTime.SelectedValue = model.GoffworkTime;
                //经销商业务章
                this.txt_YWZ.Text = model.ConnectID;

                //加载联系人信息
                LinkmanDataBind();
            }
        }
        #endregion

        #region 加载存储在XML中的临时数据--乔春羽(2014.3.20)
        /// <summary>
        /// 加载存储在XML中的临时数据
        /// </summary>
        private void LoadDataInXMLDocument()
        {
            //单独存一个数据
            this.TempDealerInfoDataTable = Session["temp_Dealer"] as DataTable;

            string fileName = this.TempXMLName;
            if (!string.IsNullOrEmpty(fileName))
            {
                XmlDocument doc = new XmlDocument();
                try
                {
                    doc.Load(string.Format("C://{0}", fileName));
                }
                catch
                {
                    return;
                }
                //开始解析存有临时数据的XML文档
                XmlElement root = doc.DocumentElement;
                //获取经销商的信息
                XmlElement ele_Dealer = root["DealerBasic"];
                this.txt_DealerName.Text = ele_Dealer["DealerName"].InnerText;
                this.cbl_DealerType.SelectedValueArray = ele_Dealer["DealerType"].InnerText.Split(',');
                this.chk_IsGroup.Checked = ele_Dealer["IsGroup"].InnerText == string.Empty ? false : Convert.ToBoolean(ele_Dealer["IsGroup"].InnerText);
                this.txt_OtherIndustries.Text = ele_Dealer["OtherIndustries"].InnerText;
                this.ddl_GotoworkTime.SelectedValue = ele_Dealer["GotoworkTime"].InnerText;
                this.ddl_GoffworkTime.SelectedValue = ele_Dealer["GoffworkTime"].InnerText;
                this.txt_YWZ.Text = ele_Dealer["YWZ"].InnerText;
                this.DealerID = ele_Dealer["DealerID"].InnerText;
                this.txt_JC.Text = ele_Dealer["JC"].InnerText;
                //组织机构代码
                string organizationCode = ele_Dealer["DealerPayCode"].InnerText;
                this.txt_OrganizationCode.Text = organizationCode;

                string address = ele_Dealer["Address"].InnerText;
                if (!string.IsNullOrEmpty(address))
                {
                    string[] adds = address.Split('-');
                    if (adds.Length >= 3)
                    {
                        WUC_Address.Province = adds[0];
                        WUC_Address.City = adds[1];
                        WUC_Address.Address = adds[2];
                    }
                    else
                    {
                        WUC_Address.Address = address;
                    }
                }
                this.txt_Remark.Text = ele_Dealer["Remark"].InnerText;

                //获取联系人的信息
                XmlElement ele_Linkman = root["LinkmanList"];
                if (ele_Linkman != null && ele_Linkman.ChildNodes.Count > 0)
                {
                    for (int i = 0; i < ele_Linkman.ChildNodes.Count; i++)
                    {
                        XmlNode node = ele_Linkman.ChildNodes[i];
                        DataRow row = DtLinkman.NewRow();
                        row["dc_Name"] = node["dc_Name"].InnerText;
                        row["dc_Phone"] = node["dc_Phone"].InnerText;
                        row["dc_Fax"] = node["dc_Fax"].InnerText;
                        row["dc_Email"] = node["dc_Email"].InnerText;
                        row["dc_Type"] = node["dc_Type"].InnerText;
                        row["dc_ID"] = node["dc_ID"].InnerText;

                        DtLinkman.Rows.Add(row);
                    }
                    LinkmanDataBind();
                }
            }
        }
        #endregion

        #region 加载已选择的合作行信息--乔春羽
        private void LoadBankInfo()
        {
            //将Session中的数据，绑定到Grid中显示
            grid_BankList.DataSource = Banks;
            grid_BankList.DataBind();
        }
        #endregion

        #region 行数据绑定事件--乔春羽
        protected void grid_BankList_RowDataBound(object sender, GridRowEventArgs e)
        {
            int index = 0;
            if (e.DataItem != null)
            {
                index = 2;
                //业务模式
                int businessMode = Convert.ToInt32(e.Values[index]);
                switch (businessMode)
                {
                    case 1:
                        e.Values[index] = "车证模式";
                        break;
                    case 2:
                        e.Values[index] = "合格证模式";
                        break;
                    case 3:
                        e.Values[index] = "巡库模式";
                        break;
                    default:
                        e.Values[index] = "无效";
                        break;
                }


                //支付周期
                index = 5;
                int paymentCycle = Convert.ToInt32(e.Values[index]);
                switch (paymentCycle)
                {
                    case 1:
                        e.Values[index] = "月";
                        break;
                    case 2:
                        e.Values[index] = "季";
                        break;
                    case 3:
                        e.Values[index] = "半年";
                        break;
                    case 4:
                        e.Values[index] = "年";
                        break;
                    default:
                        e.Values[index] = "无效";
                        break;
                }

            }
        }
        #endregion

    }
}
