using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Xml;
namespace Citic_Web.Car
{
    public partial class GD_QualifiedNo : BasePage
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
                DataSet ds = null;
                //int RoleId = this.CurrentUser.RoleId;       //获取角色id
                int RoleId = 1;
                switch (RoleId)
                {
                    case 1:         //1为超级管理员
                        //ds = DealerBll.GetBankID_DealerID_BankName_List("AND D_L.IsDelete=0 and D_B_L.IsDelete=0 and D_B_L.CollaborateType=1 order by D_L.DealerName");
                        ds = new Citic.BLL.Dealer().GetBankID_DealerID_BankName_List("AND D_L.IsDelete=0 and D_B_L.IsDelete=0 and D_B_L.CollaborateType=1 and D_B_L.GD_ID<>'' order by D_L.DealerName");
                        break;
                    case 2:         //2为管理员
                        break;
                    case 3:         //3为业务经理
                        break;
                    case 4:         //4为市场经理
                        break;
                    case 5:         //5为市场专员
                        break;
                    case 6:         //6为品牌专员
                        break;
                    case 7:         //7为调配专员
                        break;
                    case 8:         //8为银行
                        break;
                    case 9:         //9为厂家
                        break;
                    case 10:         //10为监管员
                        //int SupID = this.CurrentUser.RelationID.Value;
                        //ds = DealerBll.GetBankID_DealerID_BankName_List("AND D_L.IsDelete=0 and D_B_L.IsDelete=0 and D_B_L.CollaborateType=1 and SupervisorID='" + SupID + "' order by D_L.DealerName");
                        break;
                }
                this.ddl_JXS_ID.DataTextField = "DealerName";
                this.ddl_JXS_ID.DataValueField = "GD_ID";
                ViewState["Dealer"] = ds.Tables[0];
                this.ddl_JXS_ID.DataSource = ds;
                this.ddl_JXS_ID.DataBind();
            }
            catch
            {
                FineUI.Alert.ShowInTop("与服务器无法链接,经销商信息", FineUI.MessageBoxIcon.Error);
            }

        }
        #endregion

        protected void Btn_Add_Search_Click(object sender, EventArgs e)
        {
            if (this.txt_PI_NO.Text.Trim().Length == 0 && this.txt_DJ_NO.Text.Trim().Length == 0)
            {
                FineUI.Alert.ShowInTop("合格证和车架必须填写一样");
            }
            else
            {
                string FTranCode = "Q406";  //交易码
                string TrmSeqNum = DateTime.Now.ToString("yyyyHHddmmssffff");     //流水终端号
                string xmltxt = "<CHANNEL_CODE>0231J001</CHANNEL_CODE>";    //接入机构号
                xmltxt += "<JXS_ID>" + this.ddl_JXS_ID.SelectedValue.Trim() + "</JXS_ID>";    //经销商id
                xmltxt += "<PI_NO>" + this.txt_PI_NO.Text.Trim() + "</PI_NO>";   //合格证编号
                xmltxt += "<DJ_NO>" + this.txt_DJ_NO.Text.Trim() + "</DJ_NO> ";  //车辆识别代号
                string[] dr = ((DataTable)ViewState["Dealer"]).Select("GD_ID='" + this.ddl_JXS_ID.SelectedValue.Trim() + "'")[0].ItemArray[0].ToString().Split('_');
                string Car_Tb = "tb_Car_" + dr[0] + "_" + dr[1];
                string sql = "insert into tb_ToGDMessage (FTranCode,TrmSeqNum,RequestSource,RequestPe_ID,Status,RequestDate,insertValue,PI_ID) values('" + FTranCode + "','" + TrmSeqNum + "','" + xmltxt + "','1',0,GETDATE(),'" + Car_Tb + "','1')";

                int Num = new Citic.BLL.Inspection().ExecuteSql(sql);
                if (Num > 0)
                {
                    FineUI.Alert.ShowInTop("提交成功，请等1分钟后查询结果");
                }
                else
                {
                    FineUI.Alert.ShowInTop("提交失败");
                }
            }
        }

        protected void Btn_Search_Click(object sender, EventArgs e)
        {
            if (this.txt_PI_NO.Text.Trim().Length != 0)
            {
                string sql = "select * from tb_ToGDMessage where RequestSource like '%" + this.txt_PI_NO.Text.Trim() + "%' and (FTranCode ='Q402' OR FTranCode ='Q403' OR FTranCode ='Q406' ) and CONVERT(varchar(100), RequestDate, 23) =CONVERT(varchar(100), GETDATE(), 23)";
                DataSet ds = new Citic.BLL.Car().GetList(sql);
                this.G_Correct.DataSource = CorrectTable(ds);
                this.G_Correct.DataBind();

            }
            else
            {
                FineUI.Alert.ShowInTop("请输入合格证编号", FineUI.MessageBoxIcon.Error);
            }

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
            dt.Columns.Add("FTranCode");        //类型
            dt.Columns.Add("JXS_NAME");     //经销商名称
            dt.Columns.Add("PI_NO");            //合格证编号
            dt.Columns.Add("Message");       //返回错误信息
            dt.Columns.Add("RequestDate");      //提交时间
            dt.Columns.Add("ResponseDate");      //返回时间
            dt.Columns.Add("PI_STATUS");            //合格证状态
            dt.Columns.Add("CAR_STATUS");       //车辆状态
            XmlDocument xmldoc = new XmlDocument();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                string xml = "<in>" + table.Rows[i]["RequestSource"].ToString() + "</in>";
                xmldoc.LoadXml(xml);
                DataRow dr_dt = dt.NewRow();
                dr_dt["FTranCode"] = table.Rows[i]["FTranCode"].ToString().Replace("Q402", "合格证入库").Replace("Q403", "合格证修改").Replace("Q406", "合格证查询");      //类型

                dr_dt["PI_NO"] = xmldoc["in"]["PI_NO"].InnerText;        //合格证编号
                dr_dt["RequestDate"] = table.Rows[i]["RequestDate"];      //提交时间
                dr_dt["ResponseDate"] = table.Rows[i]["ResponseDate"];          //返回时间
                if (table.Rows[i]["Status"].ToString() == "1")
                {
                    dr_dt["Message"] = "正常";
                    if (table.Rows[i]["FTranCode"].ToString() == "Q406")
                    {
                        xmldoc.RemoveAll();
                        xmldoc.LoadXml(table.Rows[i]["ResponseSource"].ToString());
                        dr_dt["JXS_NAME"] = xmldoc["Out"]["Body"]["JXS_NAME"].InnerText;        //经销商名称
                        dr_dt["PI_STATUS"] = STATUS(xmldoc["Out"]["Body"]["PI_STATUS"].InnerText);      //合格证状态
                        dr_dt["CAR_STATUS"] = STATUS(xmldoc["Out"]["Body"]["CAR_STATUS"].InnerText);    //车辆状态
                        if (xmldoc["Out"]["Body"]["PI_STATUS"].InnerText.ToString() == "760" && table.Rows[i]["PI_ID"].ToString() == "1")
                        {
                            string FTranCode = "Q408";      //交易码
                            string TrmSeqNum = DateTime.Now.ToString("yyyyHHddmmssffff");     //流水终端号
                            string xmltxt = "<CHANNEL_CODE>0231J001</CHANNEL_CODE><Frame><PI_ID>" + xmldoc["Out"]["Body"]["PI_ID"].InnerText + "</PI_ID><PI_STATUS>1</PI_STATUS><CAR_STATUS>1</CAR_STATUS></Frame>";
                            string Q408_insertValue = "update " + table.Rows[i]["insertValue"].ToString() + " set  Statu=''0'',OutTime=GETDATE() where GD_ID=''" + xmldoc["Out"]["Body"]["PI_ID"].InnerText + "''";
                            string sql = "insert into tb_ToGDMessage (FTranCode,TrmSeqNum,RequestSource,RequestPe_ID,Status,RequestDate,insertValue) values('" + FTranCode + "','" + TrmSeqNum + "','" + xmltxt + "','1',0,GETDATE(),'" + Q408_insertValue + "')";
                            sql += "  update tb_ToGDMessage set PI_ID=null where id=" + table.Rows[i]["ID"].ToString();
                            new Citic.BLL.Inspection().ExecuteSql(sql);
                        }
                    }
                }
                else
                {
                    dr_dt["Message"] = table.Rows[i]["ErrMessage"];
                }





                dt.Rows.Add(dr_dt);
                xmldoc.RemoveAll();     //移除xml所有节点
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