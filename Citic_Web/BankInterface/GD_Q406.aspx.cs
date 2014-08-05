using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Xml;

namespace Citic_Web.BankInterface
{
    public partial class GD_Q406 : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDealer();
            }
        }
        #region 绑定经销商
        /// <summary>
        /// 绑定经销商
        /// </summary>
        private void BindDealer()
        {
            try
            {
                DataTable dt = null;
                int RoleId = this.CurrentUser.RoleId;       //获取角色id
                
                switch (RoleId)
                {
                    case 1:         //1为超级管理员
                        dt = DealerBll.GetBankID_DealerID_BankName_List("AND D_L.IsDelete=0 and D_B_L.IsDelete=0 and D_B_L.CollaborateType=1 and  D_B_L.GD_ID<>'-1' and D_B_L.GD_ID<>'' order by D_L.DealerName").Tables[0];
                        break;
                    case 2:         //2为管理员
                        break;
                    case 3:         //3为业务经理
                        dt = DealerBll.GetBankID_DealerID_BankName_List("AND D_L.IsDelete=0 and D_B_L.IsDelete=0 and D_B_L.CollaborateType=1 and  D_B_L.GD_ID<>'-1' and D_B_L.GD_ID<>'' order by D_L.DealerName").Tables[0];
                        break;
                    case 4:         //4为市场经理
                        break;
                    case 5:         //5为市场专员
                        int UserID_5 = this.CurrentUser.UserId;
                        dt = DealerBll.GetBankID_DealerID_BankName_List("and BankID in(select MappingID from tb_UserMapping where RoleID=5 and UserID=" + UserID_5 + ") and  D_B_L.GD_ID<>'-1' and D_B_L.GD_ID<>''").Tables[0];
                        break;
                    case 6:         //6为品牌专员
                        int UserID_6 = this.CurrentUser.UserId;
                        dt = DealerBll.GetBankID_DealerID_BankName_List("and BankID in(select MappingID from tb_UserMapping where RoleID=6 and UserID=" + UserID_6 + ") and  D_B_L.GD_ID<>'-1' and D_B_L.GD_ID<>''").Tables[0];
                        break;
                    case 7:         //7为调配专员
                        break;
                    case 8:         //8为银行
                        break;
                    case 9:         //9为厂家
                        break;
                    case 10:         //10为监管员
                        int SupID = this.CurrentUser.RelationID.Value;
                        dt = DealerBll.GetBankID_DealerID_BankName_List("AND D_L.IsDelete=0 and D_B_L.IsDelete=0 and D_B_L.CollaborateType=1 and SupervisorID='" + SupID + "' and  D_B_L.GD_ID<>'-1' and D_B_L.GD_ID<>'' order by D_L.DealerName").Tables[0];
                        break;
                }
                this.ddl_JXS_ID.DataTextField = "DealerName";
                this.ddl_JXS_ID.DataValueField = "GD_ID";
                ViewState["Dealer"] = dt;
                this.ddl_JXS_ID.DataSource = dt;
                this.ddl_JXS_ID.DataBind();
                ddl_JXS_ID.Items.Insert(0, new FineUI.ListItem("——请选择——", "-1"));
            }
            catch
            {
                FineUI.Alert.ShowInTop("与服务器无法链接,经销商信息", FineUI.MessageBoxIcon.Error);
            }

        }
        #endregion

        protected void Btn_Add_Search_Click(object sender, EventArgs e)
        {
            if (this.ddl_JXS_ID.SelectedValue != "-1")
            {
                if (this.txt_PI_NO.Text.Trim().Length == 0 && this.txt_DJ_NO.Text.Trim().Length == 0)
                {
                    FineUI.Alert.ShowInTop("合格证和车架必须填写一样");
                }
                else
                {
                    //string FTranCode = "Q406";  //交易码 2014年5月21日
                    string TrmSeqNum = DateTime.Now.ToString("yyyyHHddmmssffff");     //流水终端号
                    string xmltxt = "<CHANNEL_CODE>0231J001</CHANNEL_CODE>";    //接入机构号
                    xmltxt += "<JXS_ID>" + this.ddl_JXS_ID.SelectedValue.Trim() + "</JXS_ID>";    //经销商id
                    xmltxt += "<PI_NO>" + this.txt_PI_NO.Text.Trim() + "</PI_NO>";   //合格证编号
                    xmltxt += "<DJ_NO>" + this.txt_DJ_NO.Text.Trim() + "</DJ_NO> ";  //车辆识别代号
                    DataRow[] dr = ((DataTable)ViewState["Dealer"]).Select("GD_ID='" + this.ddl_JXS_ID.SelectedValue.Trim() + "'");
                    string Car_Tb = string.Format("tb_Car_{0}_{1}", dr[0].ItemArray[2].ToString(), dr[0].ItemArray[0].ToString());
                    string sql = string.Format("insert into tb_ToGDMessage (FTranCode,TrmSeqNum,RequestSource,RequestPe_ID,Status,RequestDate,insertValue,PI_ID) values('Q406','{0}','{1}','{2}',0,GETDATE(),'{3}','{4}')", TrmSeqNum, xmltxt, CurrentUser.UserId, Car_Tb, this.ddl_JXS_ID.SelectedText);

                    int Num = new Citic.BLL.Inspection().ExecuteSql(sql);
                    if (Num > 0)
                    {
                        FineUI.Alert.ShowInTop("提交成功，请等1分钟后查询结果");
                    }
                    else
                    {
                        FineUI.Alert.ShowInTop("提交失败", FineUI.MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                FineUI.Alert.ShowInTop("请选择经销商", FineUI.MessageBoxIcon.Error);
            }
        }

        protected void Btn_Search_Click(object sender, EventArgs e)
        {
            int RoleId = this.CurrentUser.RoleId;       //获取角色id
            string sql = string.Empty;
            if (RoleId == 10)
            {
                sql = string.Format("select * from tb_ToGDMessage where FTranCode='Q406' and ([Status]='1' or [Status]='2' or [Status]='3') and CONVERT(varchar(100), RequestDate, 23) =CONVERT(varchar(100),GETDATE(), 23) and RequestPe_ID='{0}' order by ResponseDate desc", CurrentUser.UserId);
            }
            else
            {
                sql = "select * from tb_ToGDMessage where FTranCode='Q406' and ([Status]='1' or [Status]='2' or [Status]='3') and CONVERT(varchar(100), RequestDate, 23) =CONVERT(varchar(100),GETDATE(), 23) order by ResponseDate desc";
            }

            DataSet ds = CarBll.GetList(sql);
            this.G_Correct.DataSource = CorrectTable(ds);
            this.G_Correct.DataBind();
        }
        #region 正确返回
        /// <summary>
        /// 查询结果
        /// </summary>
        /// <param name="ds"></param>
        /// <returns></returns>
        private DataTable CorrectTable(DataSet ds)
        {
            DataTable table = ds.Tables[0];
            DataTable dt = new DataTable();
            dt.Columns.Add("id");
            dt.Columns.Add("JXS_NAME");     //经销商名称
            dt.Columns.Add("PI_NO");            //合格证编号/车架
            dt.Columns.Add("Message");       //返回错误信息
            dt.Columns.Add("RequestDate");      //提交时间
            dt.Columns.Add("ResponseDate");      //返回时间
            XmlDocument xmldoc = new XmlDocument();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                string xml = "<in>" + dr["RequestSource"].ToString() + "</in>";
                xmldoc.LoadXml(xml);
                DataRow dr_dt = dt.NewRow();
                dr_dt["id"] = dr["ID"].ToString();
                dr_dt["JXS_NAME"] = dr["PI_ID"].ToString();
                dr_dt["Message"] = dr["ErrMessage"].ToString();
                dr_dt["RequestDate"] = dr["RequestDate"].ToString();
                dr_dt["ResponseDate"] = dr["ResponseDate"].ToString();
                if (xmldoc["in"]["PI_NO"].InnerText.Trim().Length != 0)
                {
                    dr_dt["PI_NO"] = xmldoc["in"]["PI_NO"].InnerText.Trim();
                }
                else
                {
                    dr_dt["PI_NO"] = xmldoc["in"]["DJ_NO"].InnerText.Trim();
                }
                dt.Rows.Add(dr_dt);
                xmldoc.RemoveAll();     //移除xml所有节点    2014年5月22日
            }
            return dt;
        }
        #endregion

        #region 错误返回
        /// <summary>
        /// 错误返回    张繁 2014年1月21日
        /// </summary>
        /// <param name="ds"></param>
        /// <returns></returns>
        private DataTable ErrorTable(DataSet ds)
        {
            DataRow[] dr = ds.Tables[0].Select("Status=2");
            DataTable dt = new DataTable();
            dt.Columns.Add("JXS_ID");    //经销商id
            dt.Columns.Add("PI_NO");         //合格证编号
            dt.Columns.Add("DJ_NO");        //车辆识别代号
            dt.Columns.Add("ErrMessage");       //返回错误信息
            dt.Columns.Add("RequestDate");      //提交时间
            dt.Columns.Add("ResponseDate");      //返回时间

            XmlDocument xmldoc = new XmlDocument();
            for (int i = 0; i < dr.Length; i++)
            {
                DataRow dr_dt = dt.NewRow();
                string xml = "<in>" + dr[i].ItemArray[3].ToString() + "</in>";
                xmldoc.LoadXml(xml);
                dr_dt["JXS_ID"] = xmldoc["in"]["JXS_ID"].InnerText.ToString();
                dr_dt["PI_NO"] = xmldoc["in"]["PI_NO"].InnerText.ToString();
                //dr_dt["DJ_NO"] = xmldoc["in"]["DJ_NO"].InnerText.ToString();
                dr_dt["ErrMessage"] = dr[i].ItemArray[7].ToString();
                dr_dt["RequestDate"] = dr[i].ItemArray[8].ToString();
                dr_dt["ResponseDate"] = dr[i].ItemArray[9].ToString();
                dt.Rows.Add(dr_dt);
            }
            return dt;
        }
        #endregion

        #region 解析光大状态
        /// <summary>
        /// 解析光大状态 张繁 2014年1月21日 
        /// </summary>
        /// <param name="STATUS">状态代码</param>
        /// <returns></returns>
        private string STATUS(string STATUS)
        {
            string txt = string.Empty;
            switch (STATUS)
            {
                case "400":
                    txt = "在库";
                    break;
                case "450":
                    txt = "出库申请已提交";
                    break;
                case "500":
                    txt = "出库审核流程中";
                    break;
                case "600":
                    txt = "出库审核不通过";
                    break;
                case "700":
                    txt = "出库";
                    break;
                case "760":
                    txt = "出库审核通过";
                    break;
                case "800":
                    txt = "超范围待确认";
                    break;
                case "810":
                    txt = "不监管";
                    break;
                case "750":
                    txt = "在途";
                    break;
                default:
                    txt = "无法解析";
                    break;
            }
            return txt;
        }
        #endregion

        protected void ddl_JXS_ID_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.txt_PI_NO.Text = "";
        }
    }
}