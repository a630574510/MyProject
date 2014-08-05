using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Citic.DAL
{
    /// <summary>
    /// 数据访问类:RiskQuestion
    /// </summary>
    public partial class RiskQuestion
    {
        public RiskQuestion()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_RiskQuestion");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Citic.Model.RiskQuestion model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_RiskQuestion(");
            strSql.Append("No,CC_Date,CC_AP,CC_Unit,CC_P,CC_Post,CC_PPhone,CC_Content,SQ_ShopID,SQ_Shop,SQ_BrandID,SQ_Brand,SQ_Name,SQ_Phone,SQ_FBP,SQ_FBPP,SQ_Content,S_P,S_Phone,S_Result,GD,WTCLBF,FXWTBMQZ,QCJRZXYJ,QCJRZXQZ,GLZXYJ,GLZXQZ,CreateID,CreateTime)");
            strSql.Append(" values (");
            strSql.Append("@No,@CC_Date,@CC_AP,@CC_Unit,@CC_P,@CC_Post,@CC_PPhone,@CC_Content,@SQ_ShopID,@SQ_Shop,@SQ_BrandID,@SQ_Brand,@SQ_Name,@SQ_Phone,@SQ_FBP,@SQ_FBPP,@SQ_Content,@S_P,@S_Phone,@S_Result,@GD,@WTCLBF,@FXWTBMQZ,@QCJRZXYJ,@QCJRZXQZ,@GLZXYJ,@GLZXQZ,@CreateID,@CreateTime)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@No", SqlDbType.NVarChar,20),
					new SqlParameter("@CC_Date", SqlDbType.DateTime),
					new SqlParameter("@CC_AP", SqlDbType.NVarChar,50),
					new SqlParameter("@CC_Unit", SqlDbType.NVarChar,50),
					new SqlParameter("@CC_P", SqlDbType.NVarChar,50),
					new SqlParameter("@CC_Post", SqlDbType.NVarChar,50),
					new SqlParameter("@CC_PPhone", SqlDbType.NVarChar,11),
					new SqlParameter("@CC_Content", SqlDbType.NVarChar,300),
					new SqlParameter("@SQ_ShopID", SqlDbType.Int,4),
					new SqlParameter("@SQ_Shop", SqlDbType.NVarChar,100),
					new SqlParameter("@SQ_BrandID", SqlDbType.Int,4),
					new SqlParameter("@SQ_Brand", SqlDbType.NVarChar,50),
					new SqlParameter("@SQ_Name", SqlDbType.NVarChar,50),
					new SqlParameter("@SQ_Phone", SqlDbType.NVarChar,11),
					new SqlParameter("@SQ_FBP", SqlDbType.NVarChar,50),
					new SqlParameter("@SQ_FBPP", SqlDbType.NVarChar,11),
					new SqlParameter("@SQ_Content", SqlDbType.NVarChar,300),
					new SqlParameter("@S_P", SqlDbType.NVarChar,50),
					new SqlParameter("@S_Phone", SqlDbType.NVarChar,11),
					new SqlParameter("@S_Result", SqlDbType.NVarChar,300),
					new SqlParameter("@GD", SqlDbType.NVarChar,50),
					new SqlParameter("@WTCLBF", SqlDbType.NVarChar,300),
					new SqlParameter("@FXWTBMQZ", SqlDbType.NVarChar,50),
					new SqlParameter("@QCJRZXYJ", SqlDbType.NVarChar,300),
					new SqlParameter("@QCJRZXQZ", SqlDbType.NVarChar,50),
					new SqlParameter("@GLZXYJ", SqlDbType.NVarChar,300),
					new SqlParameter("@GLZXQZ", SqlDbType.NVarChar,50),
					new SqlParameter("@CreateID", SqlDbType.Int,4),
					new SqlParameter("@CreateTime", SqlDbType.DateTime)};
            parameters[0].Value = model.No;
            parameters[1].Value = model.CC_Date;
            parameters[2].Value = model.CC_AP;
            parameters[3].Value = model.CC_Unit;
            parameters[4].Value = model.CC_P;
            parameters[5].Value = model.CC_Post;
            parameters[6].Value = model.CC_PPhone;
            parameters[7].Value = model.CC_Content;
            parameters[8].Value = model.SQ_ShopID;
            parameters[9].Value = model.SQ_Shop;
            parameters[10].Value = model.SQ_BrandID;
            parameters[11].Value = model.SQ_Brand;
            parameters[12].Value = model.SQ_Name;
            parameters[13].Value = model.SQ_Phone;
            parameters[14].Value = model.SQ_FBP;
            parameters[15].Value = model.SQ_FBPP;
            parameters[16].Value = model.SQ_Content;
            parameters[17].Value = model.S_P;
            parameters[18].Value = model.S_Phone;
            parameters[19].Value = model.S_Result;
            parameters[20].Value = model.GD;
            parameters[21].Value = model.WTCLBF;
            parameters[22].Value = model.FXWTBMQZ;
            parameters[23].Value = model.QCJRZXYJ;
            parameters[24].Value = model.QCJRZXQZ;
            parameters[25].Value = model.GLZXYJ;
            parameters[26].Value = model.GLZXQZ;
            parameters[27].Value = model.CreateID;
            parameters[28].Value = model.CreateTime;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Citic.Model.RiskQuestion model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_RiskQuestion set ");
            strSql.Append("CC_Date=@CC_Date,");
            strSql.Append("CC_AP=@CC_AP,");
            strSql.Append("CC_Unit=@CC_Unit,");
            strSql.Append("CC_P=@CC_P,");
            strSql.Append("CC_Post=@CC_Post,");
            strSql.Append("CC_PPhone=@CC_PPhone,");
            strSql.Append("CC_Content=@CC_Content,");
            strSql.Append("SQ_ShopID=@SQ_ShopID,");
            strSql.Append("SQ_Shop=@SQ_Shop,");
            strSql.Append("SQ_BrandID=@SQ_BrandID,");
            strSql.Append("SQ_Brand=@SQ_Brand,");
            strSql.Append("SQ_Name=@SQ_Name,");
            strSql.Append("SQ_Phone=@SQ_Phone,");
            strSql.Append("SQ_FBP=@SQ_FBP,");
            strSql.Append("SQ_FBPP=@SQ_FBPP,");
            strSql.Append("SQ_Content=@SQ_Content,");
            strSql.Append("S_P=@S_P,");
            strSql.Append("S_Phone=@S_Phone,");
            strSql.Append("S_Result=@S_Result,");
            strSql.Append("GD=@GD,");
            strSql.Append("WTCLBF=@WTCLBF,");
            strSql.Append("FXWTBMQZ=@FXWTBMQZ,");
            strSql.Append("QCJRZXYJ=@QCJRZXYJ,");
            strSql.Append("QCJRZXQZ=@QCJRZXQZ,");
            strSql.Append("GLZXYJ=@GLZXYJ,");
            strSql.Append("GLZXQZ=@GLZXQZ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@CC_Date", SqlDbType.DateTime),
					new SqlParameter("@CC_AP", SqlDbType.NVarChar,50),
					new SqlParameter("@CC_Unit", SqlDbType.NVarChar,50),
					new SqlParameter("@CC_P", SqlDbType.NVarChar,50),
					new SqlParameter("@CC_Post", SqlDbType.NVarChar,50),
					new SqlParameter("@CC_PPhone", SqlDbType.NVarChar,11),
					new SqlParameter("@CC_Content", SqlDbType.NVarChar,300),
					new SqlParameter("@SQ_ShopID", SqlDbType.Int,4),
					new SqlParameter("@SQ_Shop", SqlDbType.NVarChar,100),
					new SqlParameter("@SQ_BrandID", SqlDbType.Int,4),
					new SqlParameter("@SQ_Brand", SqlDbType.NVarChar,50),
					new SqlParameter("@SQ_Name", SqlDbType.NVarChar,50),
					new SqlParameter("@SQ_Phone", SqlDbType.NVarChar,11),
					new SqlParameter("@SQ_FBP", SqlDbType.NVarChar,50),
					new SqlParameter("@SQ_FBPP", SqlDbType.NVarChar,11),
					new SqlParameter("@SQ_Content", SqlDbType.NVarChar,300),
					new SqlParameter("@S_P", SqlDbType.NVarChar,50),
					new SqlParameter("@S_Phone", SqlDbType.NVarChar,11),
					new SqlParameter("@S_Result", SqlDbType.NVarChar,300),
					new SqlParameter("@GD", SqlDbType.NVarChar,50),
					new SqlParameter("@WTCLBF", SqlDbType.NVarChar,300),
					new SqlParameter("@FXWTBMQZ", SqlDbType.NVarChar,50),
					new SqlParameter("@QCJRZXYJ", SqlDbType.NVarChar,300),
					new SqlParameter("@QCJRZXQZ", SqlDbType.NVarChar,50),
					new SqlParameter("@GLZXYJ", SqlDbType.NVarChar,300),
					new SqlParameter("@GLZXQZ", SqlDbType.NVarChar,50),
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = model.CC_Date;
            parameters[1].Value = model.CC_AP;
            parameters[2].Value = model.CC_Unit;
            parameters[3].Value = model.CC_P;
            parameters[4].Value = model.CC_Post;
            parameters[5].Value = model.CC_PPhone;
            parameters[6].Value = model.CC_Content;
            parameters[7].Value = model.SQ_ShopID;
            parameters[8].Value = model.SQ_Shop;
            parameters[9].Value = model.SQ_BrandID;
            parameters[10].Value = model.SQ_Brand;
            parameters[11].Value = model.SQ_Name;
            parameters[12].Value = model.SQ_Phone;
            parameters[13].Value = model.SQ_FBP;
            parameters[14].Value = model.SQ_FBPP;
            parameters[15].Value = model.SQ_Content;
            parameters[16].Value = model.S_P;
            parameters[17].Value = model.S_Phone;
            parameters[18].Value = model.S_Result;
            parameters[19].Value = model.GD;
            parameters[20].Value = model.WTCLBF;
            parameters[21].Value = model.FXWTBMQZ;
            parameters[22].Value = model.QCJRZXYJ;
            parameters[23].Value = model.QCJRZXQZ;
            parameters[24].Value = model.GLZXYJ;
            parameters[25].Value = model.GLZXQZ;
            parameters[26].Value = model.ID;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_RiskQuestion ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_RiskQuestion ");
            strSql.Append(" where ID in (" + IDlist + ")  ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Citic.Model.RiskQuestion GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,No,CC_Date,CC_AP,CC_Unit,CC_P,CC_Post,CC_PPhone,CC_Content,SQ_ShopID,SQ_Shop,SQ_BrandID,SQ_Brand,SQ_Name,SQ_Phone,SQ_FBP,SQ_FBPP,SQ_Content,S_P,S_Phone,S_Result,GD,WTCLBF,FXWTBMQZ,QCJRZXYJ,QCJRZXQZ,GLZXYJ,GLZXQZ,CreateID,CreateTime from tb_RiskQuestion ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

            Citic.Model.RiskQuestion model = new Citic.Model.RiskQuestion();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Citic.Model.RiskQuestion DataRowToModel(DataRow row)
        {
            Citic.Model.RiskQuestion model = new Citic.Model.RiskQuestion();
            if (row != null)
            {
                if (row["ID"] != null && row["ID"].ToString() != "")
                {
                    model.ID = int.Parse(row["ID"].ToString());
                }
                if (row["No"] != null)
                {
                    model.No = row["No"].ToString();
                }
                if (row["CC_Date"] != null && row["CC_Date"].ToString() != "")
                {
                    model.CC_Date = DateTime.Parse(row["CC_Date"].ToString());
                }
                if (row["CC_AP"] != null)
                {
                    model.CC_AP = row["CC_AP"].ToString();
                }
                if (row["CC_Unit"] != null)
                {
                    model.CC_Unit = row["CC_Unit"].ToString();
                }
                if (row["CC_P"] != null)
                {
                    model.CC_P = row["CC_P"].ToString();
                }
                if (row["CC_Post"] != null)
                {
                    model.CC_Post = row["CC_Post"].ToString();
                }
                if (row["CC_PPhone"] != null)
                {
                    model.CC_PPhone = row["CC_PPhone"].ToString();
                }
                if (row["CC_Content"] != null)
                {
                    model.CC_Content = row["CC_Content"].ToString();
                }
                if (row["SQ_ShopID"] != null && row["SQ_ShopID"].ToString() != "")
                {
                    model.SQ_ShopID = int.Parse(row["SQ_ShopID"].ToString());
                }
                if (row["SQ_Shop"] != null)
                {
                    model.SQ_Shop = row["SQ_Shop"].ToString();
                }
                if (row["SQ_BrandID"] != null && row["SQ_BrandID"].ToString() != "")
                {
                    model.SQ_BrandID = int.Parse(row["SQ_BrandID"].ToString());
                }
                if (row["SQ_Brand"] != null)
                {
                    model.SQ_Brand = row["SQ_Brand"].ToString();
                }
                if (row["SQ_Name"] != null)
                {
                    model.SQ_Name = row["SQ_Name"].ToString();
                }
                if (row["SQ_Phone"] != null)
                {
                    model.SQ_Phone = row["SQ_Phone"].ToString();
                }
                if (row["SQ_FBP"] != null)
                {
                    model.SQ_FBP = row["SQ_FBP"].ToString();
                }
                if (row["SQ_FBPP"] != null)
                {
                    model.SQ_FBPP = row["SQ_FBPP"].ToString();
                }
                if (row["SQ_Content"] != null)
                {
                    model.SQ_Content = row["SQ_Content"].ToString();
                }
                if (row["S_P"] != null)
                {
                    model.S_P = row["S_P"].ToString();
                }
                if (row["S_Phone"] != null)
                {
                    model.S_Phone = row["S_Phone"].ToString();
                }
                if (row["S_Result"] != null)
                {
                    model.S_Result = row["S_Result"].ToString();
                }
                if (row["GD"] != null)
                {
                    model.GD = row["GD"].ToString();
                }
                if (row["WTCLBF"] != null)
                {
                    model.WTCLBF = row["WTCLBF"].ToString();
                }
                if (row["FXWTBMQZ"] != null)
                {
                    model.FXWTBMQZ = row["FXWTBMQZ"].ToString();
                }
                if (row["QCJRZXYJ"] != null)
                {
                    model.QCJRZXYJ = row["QCJRZXYJ"].ToString();
                }
                if (row["QCJRZXQZ"] != null)
                {
                    model.QCJRZXQZ = row["QCJRZXQZ"].ToString();
                }
                if (row["GLZXYJ"] != null)
                {
                    model.GLZXYJ = row["GLZXYJ"].ToString();
                }
                if (row["GLZXQZ"] != null)
                {
                    model.GLZXQZ = row["GLZXQZ"].ToString();
                }
                if (row["CreateID"] != null && row["CreateID"].ToString() != "")
                {
                    model.CreateID = int.Parse(row["CreateID"].ToString());
                }
                if (row["CreateTime"] != null && row["CreateTime"].ToString() != "")
                {
                    model.CreateTime = DateTime.Parse(row["CreateTime"].ToString());
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,No,CC_Date,CC_AP,CC_Unit,CC_P,CC_Post,CC_PPhone,CC_Content,SQ_ShopID,SQ_Shop,SQ_BrandID,SQ_Brand,SQ_Name,SQ_Phone,SQ_FBP,SQ_FBPP,SQ_Content,S_P,S_Phone,S_Result,GD,WTCLBF,FXWTBMQZ,QCJRZXYJ,QCJRZXQZ,GLZXYJ,GLZXQZ,CreateID,CreateTime ");
            strSql.Append(" FROM tb_RiskQuestion ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" ID,No,CC_Date,CC_AP,CC_Unit,CC_P,CC_Post,CC_PPhone,CC_Content,SQ_ShopID,SQ_Shop,SQ_BrandID,SQ_Brand,SQ_Name,SQ_Phone,SQ_FBP,SQ_FBPP,SQ_Content,S_P,S_Phone,S_Result,GD,WTCLBF,FXWTBMQZ,QCJRZXYJ,QCJRZXQZ,GLZXYJ,GLZXQZ,CreateID,CreateTime ");
            strSql.Append(" FROM tb_RiskQuestion ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM tb_RiskQuestion ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.ID desc");
            }
            strSql.Append(")AS Row, T.*  from tb_RiskQuestion T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }

        #endregion  BasicMethod
        #region  ExtensionMethod

        #region 批量添加--乔春羽(2013.12.9)
        public int AddRange(params Citic.Model.RiskQuestion[] models)
        {
            int num = 0;
            System.Collections.Generic.List<CommandInfo> cInfos = new System.Collections.Generic.List<CommandInfo>();
            string sql = string.Format(@"INSERT INTO [tb_RiskQuestion]([No],[Status],[CC_Date],[CC_AP],[CC_Unit],[CC_P]
           ,[CC_Post],[CC_PPhone],[CC_Content],[SQ_ShopID],[SQ_Shop],[SQ_BrandID],[SQ_Brand],[SQ_Name],[SQ_Phone],[SQ_FBP]
           ,[SQ_FBPP],[SQ_Content],[S_P],[S_Phone],[S_Result],[GD],[WTCLBF],[FXWTBMQZ],[QCJRZXYJ],[QCJRZXQZ],[GLZXYJ]
           ,[GLZXQZ],[CreateID],[CreateTime]) VALUES (@No,0,@CC_Date,@CC_AP,@CC_Unit,@CC_P,@CC_Post,@CC_PPhone,@CC_Content,@SQ_ShopID
           ,@SQ_Shop,@SQ_BrandID,@SQ_Brand,@SQ_Name,@SQ_Phone,@SQ_FBP,@SQ_FBPP,@SQ_Content,@S_P,'',@S_Result,@GD,'','','','','','',@CreateID,@CreateTime)");
            if (models != null && models.Length > 0)
            {
                foreach (Citic.Model.RiskQuestion model in models)
                {
                    CommandInfo cInfo = new CommandInfo()
                    {
                        CommandText = sql,
                        Parameters = new SqlParameter[]
                        {
                            new SqlParameter("@No",DateTime.Now.ToString("yyyyMMddHHmmss")),
                            new SqlParameter("@CC_Date",model.CC_Date),
                            new SqlParameter("@CC_AP",model.CC_AP),
                            new SqlParameter("@CC_Unit",model.CC_Unit),
                            new SqlParameter("@CC_P",model.CC_P),
                            new SqlParameter("@CC_Post",model.CC_Post),
                            new SqlParameter("@CC_PPhone",model.CC_PPhone),
                            new SqlParameter("@CC_Content",model.CC_Content),
                            new SqlParameter("@SQ_ShopID",model.SQ_ShopID),
                            new SqlParameter("@SQ_Shop",model.SQ_Shop),
                            new SqlParameter("@SQ_BrandID",model.SQ_BrandID),
                            new SqlParameter("@SQ_Brand",model.SQ_Brand),
                            new SqlParameter("@SQ_Name",model.SQ_Name),
                            new SqlParameter("@SQ_Phone",model.SQ_Phone),
                            new SqlParameter("@SQ_FBP",model.SQ_FBP),
                            new SqlParameter("@SQ_FBPP",model.SQ_FBPP),
                            new SqlParameter("@SQ_Content",model.SQ_Content),
                            new SqlParameter("@S_P",model.S_P),
                            new SqlParameter("@S_Result",model.S_Result),
                            new SqlParameter("@GD",model.GD),
                            new SqlParameter("@CreateID",model.CreateID),
                            new SqlParameter("@CreateTime",model.CreateTime),
                        }
                    };
                    cInfos.Add(cInfo);
                }
                try
                {
                    num = DbHelperSQL.ExecuteSqlTran(cInfos);
                    num = 1;
                }
                catch (SqlException se)
                {
                    num = 0;
                    throw se;
                }
            }
            return num;
        }
        #endregion

        #region 批量更新--乔春羽(2013.12.9)
        public int UpdateRange(params Citic.Model.RiskQuestion[] models)
        {
            int num = 0;
            if (models != null && models.Length > 0)
            {
                string sql = "UPDATE tb_RiskQuestion SET WTCLBF=@WTCLBF,FXWTBMQZ=@FXWTBMQZ,QCJRZXYJ=@QCJRZXYJ,QCJRZXQZ=@QCJRZXQZ,GLZXYJ=@GLZXYJ,GLZXQZ=@GLZXQZ,Status=1 WHERE ID=@ID";
                System.Collections.Generic.List<CommandInfo> cInfos = new System.Collections.Generic.List<CommandInfo>();
                foreach (Citic.Model.RiskQuestion model in models)
                {
                    cInfos.Add(new CommandInfo()
                    {
                        CommandText = sql,
                        Parameters = new SqlParameter[]
                        {
                            new SqlParameter("@WTCLBF",model.WTCLBF),
                            new SqlParameter("@FXWTBMQZ",model.FXWTBMQZ),
                            new SqlParameter("@QCJRZXYJ",model.QCJRZXYJ),
                            new SqlParameter("@QCJRZXQZ",model.QCJRZXQZ),
                            new SqlParameter("@GLZXYJ",model.GLZXYJ),
                            new SqlParameter("@GLZXQZ",model.GLZXQZ),
                            new SqlParameter("@ID",model.ID)
                        }
                    });
                }
                try
                {
                    DbHelperSQL.ExecuteSqlTran(cInfos);
                    num = 1;
                }
                catch (SqlException se)
                {
                    num = 0;
                    throw se;
                }
            }
            return num;
        }
        #endregion

        #region 分页获得数据列表--乔春羽(2013.8.6)
        /// <summary>
        /// 分页获得数据列表
        /// </summary>
        /// <param name="strWhere">Where条件</param>
        /// <param name="orderby">排序条件</param>
        /// <param name="startIndex">开始下表</param>
        /// <param name="endIndex">结束下表</param>
        /// <param name="cols">要查询的列</param>
        /// <returns></returns>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex, params string[] cols)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.ID desc");
            }
            strSql.Append(")AS Row, ");
            for (int i = 0; i < cols.Length; i++)
            {
                if (i == cols.Length - 1)
                {
                    strSql.Append(" T." + cols[i]);
                }
                else
                {
                    strSql.Append(" T." + cols[i] + ",");
                }
            }
            strSql.Append(" from tb_RiskQuestion T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }
        #endregion
        #endregion  ExtensionMethod
    }
}

