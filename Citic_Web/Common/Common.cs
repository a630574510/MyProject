using System;
using System.Collections.Generic;
using System.Web;
using System.Text.RegularExpressions;
using Microsoft.Office.Interop.Word;

namespace Citic_Web.Common
{
    public class Common
    {
        public static bool IsInt(string value)
        {
            return Regex.IsMatch(value, @"^[+-]?\d*$");
        }

        #region 替换Word文档中的内容

        /// <summary>
        /// 替换Word文档中的内容
        /// </summary>
        /// <param name="sourceFilePath">取得Word文件路径</param>
        /// <param name="newFilePath">新Word文件保存路径</param>
        /// <param name="strTemp">替换模板字符串({A};{B})</param>
        /// <param name="tempValue">要替换的值(A;B)</param>
        public static void ReplaceWord(string sourceFilePath, string newFilePath, string strTemp, string tempValue)
        {
            // 在此处放置用户代码以初始化页面 
            object Missing = Type.Missing;
            //取得Word文件路径 
            //string strTemp = @"E:\\work\\Qcy\\ReceiveFiles\\ReadWord_替换Word文档\\确认书.doc";
            //新Word文件保存路径 
            //string newFileName = @"E:\\work\\Qcy\\ReceiveFiles\\ReadWord_替换Word文档\\确认书2.doc";
            //创建一个名为WordApp的组件对象 
            Application WordApp = new ApplicationClass();
            //必须设置为不可见 
            WordApp.Visible = false;

            try
            {
                //创建以strTemp为模板的文档 
                object oTemplate = sourceFilePath;
                Document WordDoc = WordApp.Documents.Add(ref oTemplate, ref Missing, ref Missing, ref Missing);
                WordDoc.Activate();

                //对标签'Title'进行填充 
                object FindText, ReplaceWith, Replace;// 
                //string strold = "{DealerName};{Address};{BankNames};{BrandNames};{Hours};{OperationMode};{CheckDate};{CheckTime}";
                string[] str_old = strTemp.Split(';');
                //string strnew = "中信信通测试经销商;CXL01;LWX1234567;CX2314455;100000;测试标题000";
                string[] str_new = tempValue.Split(';');
                for (int i = 0; i < str_old.Length; i++)
                {
                    WordDoc.Content.Find.Text = str_old[i];// strOldText ;
                    FindText = str_old[i];// strOldText ;//要查找的文本
                    ReplaceWith = str_new[i];// strNewText ;//替换文本
                    Replace = Microsoft.Office.Interop.Word.WdReplace.wdReplaceAll;/**//*wdReplaceAll - 替换找到的所有项。
                                                      * wdReplaceNone - 不替换找到的任何项。
                                                    * wdReplaceOne - 替换找到的第一项。
                                                    * */
                    WordDoc.Content.Find.ClearFormatting();//移除Find的搜索文本和段落格式设置
                    if (WordDoc.Content.Find.Execute(
                        ref FindText, ref Missing,
                        ref Missing, ref Missing,
                        ref Missing, ref Missing,
                        ref Missing, ref Missing, ref Missing,
                        ref ReplaceWith, ref Replace,
                        ref Missing, ref Missing,
                        ref Missing, ref Missing))
                    {

                    }
                }

                //保存为新文件 
                object oNewFileName = newFilePath;
                WordDoc.SaveAs(ref oNewFileName, ref Missing, ref Missing, ref Missing, ref Missing, ref Missing, ref Missing,
                ref Missing, ref Missing, ref Missing, ref Missing, ref Missing, ref Missing, ref Missing, ref Missing, ref Missing);
                WordDoc.Close(ref Missing, ref Missing, ref Missing);

                WordApp.Quit(ref Missing, ref Missing, ref Missing);
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
        }
        #endregion

        #region 移除特殊字符（'）--乔春羽(2014.6.26)
        public static string RemoveSpecialCharacters(string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                if (value.Contains("'"))
                {
                    value = value.Replace("'", string.Empty);
                }
            }
            return value;
        }
        #endregion

        #region 银行的标识--乔春羽(2014.6.26)
        public const string GuangDaString = "1000000000";
        public const string ZhongXinString = "2000000000";
        #endregion
    }
}