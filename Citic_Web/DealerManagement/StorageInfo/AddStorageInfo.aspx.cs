using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;

using FineUI;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
namespace Citic_Web.DealerManagement.StorageInfo
{
    public partial class AddStorageInfo : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewState.Clear();
                //显示企业信息
                GridBind();
                WUC_Address.Init();
                //类型，如果该值不为空，则表示此次请求为“修改”操作。
                //如果为空，则表示此次请求为“添加”操作。
                string type = Request.QueryString["type"];
                if (!string.IsNullOrEmpty(type))
                {
                    int storageID = int.Parse(Request.QueryString[STORAGEID]);
                    if (storageID != 0)
                    {
                        ViewState[STORAGEID] = storageID;
                        //加载二网信息
                        LoadStorageInfo(storageID);
                    }
                }
            }
        }
        #region PrivateField--乔春羽(2013.11.29)
        private const string DEALERID = "DealerID";
        private const string _ID = "ID";
        private const string MODEL = "MODEL";
        /// <summary>
        /// 经过URL传过来的StorageID
        /// </summary>
        private const string STORAGEID = "s_i_d";
        #endregion

        #region 加载二网信息，“修改”操作下调用的函数--乔春羽(2013.11.29)
        private void LoadStorageInfo(int storageID)
        {
            Citic.Model.Storage model = StorageBll.GetStorageWithLinkman(storageID);
            ViewState[MODEL] = model == null ? null : model;

            //加载二网信息
            ViewState[DEALERID] = model.DealerID;
            this.lbl_DealerName.Text = model.DealerName;

            this.txt_StorageName.Text = model.StorageName;
            this.cbl_StorageProp.SelectedValueArray = model.StorageProp.Split(',');


            //显示地址信息
            if (model.Address != null && model.Address != string.Empty)
            {
                string[] adds = model.Address.Split('-');
                if (adds.Length > 1)
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

            this.num_Distence.Text = model.Distence.Value.ToString();
            this.txt_LinkmanName.Text = model.LinkManName;
            this.num_Phone.Text = model.LinkPhone;
        }
        #endregion

        #region 加载企业关联的本库二网信息--乔春羽
        /// <summary>
        /// 加载本地银行--乔春羽
        /// </summary>
        private void LocalStorageDataBind()
        {
            DataTable dt = StorageBll.GetList(string.Format("DealerID={0} and IsLocalStorage=1 and IsDelete=0", ViewState["DealerID"].ToString())).Tables[0];
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                }
                else
                {
                    AlertShowInTop("没有本地仓库！");
                }
            }
        }
        #endregion

        #region 绑定数据--乔春羽
        /// <summary>
        /// 绑定数据
        /// </summary>
        private void GridBind()
        {
            //where条件
            string where = ConditionInit();

            //设置表格的总数据量
            this.grid_List.RecordCount = GetCountBySearch(where);

            if (this.grid_List.PageCount < this.grid_List.PageIndex)
            {
                this.grid_List.PageIndex = 1;
            }

            int pageIndex = grid_List.PageIndex;
            int pageSize = grid_List.PageSize;
            int rowbegin = pageIndex * pageSize + 1;
            int rowend = (pageIndex + 1) * pageSize;
            DataTable dt = DealerBll.GetListByPage(where, "CreateTime DESC", rowbegin, rowend).Tables[0];

            grid_List.DataSource = dt;
            grid_List.DataBind();
        }


        /// <summary>
        /// 获得查询后结果的总数据数量
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        private int GetCountBySearch(string where)
        {
            return DealerBll.GetRecordCount(where);
        }

        #region 得到查询条件--乔春羽
        /// <summary>
        /// 得到查询条件
        /// </summary>
        private string ConditionInit()
        {
            string DealerName = this.ttb_DealerName.Text;
            StringBuilder where = new StringBuilder("IsDelete=0");
            if (DealerName != null && DealerName != string.Empty)
            {
                where.AppendFormat(" and DealerName like '%{0}%'", DealerName);
            }

            return where.ToString();
        }
        #endregion

        #endregion

        #region 查询操作--乔春羽
        protected void TwinTriggerBox1_Trigger1Click(object sender, EventArgs e)
        {
            // 执行清空动作
            ttb_DealerName.Text = string.Empty;
            ttb_DealerName.ShowTrigger1 = false;
        }
        protected void TwinTriggerBox1_Trigger2Click(object sender, EventArgs e)
        {
            GridBind();
        }
        #endregion

        #region 每页显示数量改变事件--乔春羽
        /// <summary>
        /// 每页显示数量改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            grid_List.PageSize = int.Parse(ddlPageSize.SelectedValue);
            GridBind();
        }
        #endregion

        #region 翻页事件--乔春羽
        /// <summary>
        /// 翻页事件--乔春羽
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grid_List_PageIndexChange(object sender, FineUI.GridPageEventArgs e)
        {
            SyncSelectedRowIndexArrayToHiddenField(grid_List, hfSelectedIDS);
            grid_List.PageIndex = e.NewPageIndex;

            GridBind();

            UpdateSelectedRowIndexArray(grid_List, hfSelectedIDS);
        }
        #endregion

        #region 行绑定事件--乔春羽
        /// <summary>
        /// 行绑定事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grid_List_RowDataBound(object sender, FineUI.GridRowEventArgs e)
        {
            if (e.DataItem != null)
            {
                int index = 1;
                //企业属性
                string dealerType = Convert.ToString(e.Values[index]);
                if (dealerType.Contains("1"))
                {
                    dealerType = dealerType.Replace("1", "民营");
                }
                if (dealerType.Contains("2"))
                {
                    dealerType = dealerType.Replace("2", "国营");
                }
                if (dealerType.Contains("3"))
                {
                    dealerType = dealerType.Replace("3", "集团");
                }
                if (dealerType.Contains("4"))
                {
                    dealerType = dealerType.Replace("4", "单店");
                }
                e.Values[index] = dealerType;
                //是否是集团性质
                index = 2;
                bool isGroup = Convert.ToBoolean(e.Values[index]);
                e.Values[index] = isGroup ? "是" : "否";
                index = 3;
                string hasOtherIndustries = Convert.ToString(e.Values[index]);
                e.Values[index] = string.IsNullOrEmpty(hasOtherIndustries) ? "无" : hasOtherIndustries;
            }
        }
        #endregion

        #region 行选择事件--乔春羽

        protected void grid_List_RowSelect(object sender, GridRowSelectEventArgs e)
        {
            //表示已选择行
            if (e.RowIndex > -1)
            {
                //将经销商ID存起来
                ViewState.Add(DEALERID, this.grid_List.DataKeys[e.RowIndex][0]);
                //将经销商名显示出来
                this.lbl_DealerName.Text = this.grid_List.DataKeys[e.RowIndex][1].ToString();
                //查找出该经销商下唯一的本库
                if (ViewState[DEALERID] != null)
                {
                    LocalStorageDataBind();
                }
            }
        }
        #endregion

        #region 保存仓库信息--乔春羽
        protected void btn_SaveAndClose_Click(object sender, EventArgs e)
        {
            Save();
            PageContext.RegisterStartupScript(ActiveWindow.GetHideRefreshReference());
        }

        /// <summary>
        /// 保存二网信息--乔春羽
        /// </summary>
        private void Save()
        {
            //“添加”操作
            if (ViewState[DEALERID] == null)
            {
                Citic.Model.Storage model = new Citic.Model.Storage();
                model.StorageName = this.txt_StorageName.Text;
                model.Address = GetAddress();
                model.CreateID = this.CurrentUser.UserId;
                model.CreateTime = DateTime.Now;
                model.DealerID = Convert.ToInt32(ViewState[DEALERID]);
                model.DealerName = lbl_DealerName.Text;
                model.IsDelete = false;
                model.IsLocalStorage = false;
                model.IsPort = false;
                model.Distence = Decimal.Parse(num_Distence.Text);
                model.StorageProp = string.Join(",", cbl_StorageProp.SelectedValueArray);
                model.LinkManName = this.txt_LinkmanName.Text;
                model.LinkPhone = this.num_Phone.Text;
                model.LinkType = Convert.ToInt32(Citic_Web.Common.LinkType.StorageLinkman);

                try
                {
                    int num = StorageBll.CreateStorage(model);
                    if (num > 0)
                    {
                        AlertShowInTop("添加成功！");
                    }
                    else
                    {
                        AlertShowInTop("添加失败！");
                    }
                }
                catch (Exception e)
                {
                    Logging.WriteLog(e, HttpContext.Current.Request.Url.AbsolutePath, "Save()");
                }
            }
            else    //“修改”操作 
            {
                Citic.Model.Storage model = ViewState[MODEL] as Citic.Model.Storage;
                if (model != null)
                {
                    model.StorageName = this.txt_StorageName.Text;
                    model.Address = GetAddress();
                    model.UpdateID = this.CurrentUser.UserId;
                    model.DealerID = Convert.ToInt32(ViewState[DEALERID]);
                    model.DealerName = lbl_DealerName.Text;
                    model.IsDelete = false;
                    model.IsLocalStorage = false;
                    model.IsPort = false;
                    model.Distence = Decimal.Parse(num_Distence.Text);
                    model.StorageProp = string.Join(",", cbl_StorageProp.SelectedValueArray);
                    model.LinkManName = this.txt_LinkmanName.Text;
                    model.LinkPhone = this.num_Phone.Text;
                    try
                    {
                        int num = StorageBll.ModifyStorage(model);
                        if (num > 0)
                        {
                            AlertShowInTop("修改成功！");
                        }
                        else
                        {
                            AlertShowInTop("修改失败！");
                        }
                    }
                    catch (Exception e)
                    {
                        Logging.WriteLog(e, HttpContext.Current.Request.Url.AbsolutePath, "Save()");
                    }
                }
                else { AlertShowInTop("内存数据有异常！"); }
            }
        }

        /// <summary>
        /// 经销商只能有一个本库，其余的都叫二网
        /// </summary>
        /// <returns></returns>
        private bool ValidateLocalStorage()
        {
            bool flag = false;
            List<Citic.Model.Storage> lists = new List<Citic.Model.Storage>();
            lists = StorageBll.GetModelList(string.Format("DealerID={0} and IsDelete=0", ViewState["DealerID"].ToString()));
            if (lists != null && lists.Count > 1)
            {
                flag = true;
            }
            return flag;
        }

        #region 获取地址--乔春羽
        /// <summary>
        /// 获取地址
        /// </summary>
        /// <returns></returns>
        private string GetAddress()
        {
            return WUC_Address.Value;
        }
        #endregion
        #endregion

    }
}