using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace Citic_Web.Common
{
    public class OperateConfigFile
    {
        /// <summary>
        /// 清空
        /// </summary>
        public static void Clear()
        {
            //获取应用于所有用户的Configuration
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings.Clear();
            config.Save();
        }

        /// <summary>
        /// 根据Key取Value
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string getValue(string key)
        {
            //Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            Configuration config = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~");
            if (config.AppSettings.Settings[key] != null)
            {
                return config.AppSettings.Settings[key].Value.ToString();
            }
            else
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// 创建&更新
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public static void updateValue(string key, string value)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            //不存在，就创建
            if (config.AppSettings.Settings[key] == null)
            {
                config.AppSettings.Settings.Add(key, value);
            }
            else    //存在就更新
            {
                config.AppSettings.Settings[key].Value = value;
            }
            config.Save();
        }
    }
}
