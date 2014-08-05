/*******************************************************************************************
*	Copyright:	ThinkRaceTECH
*	Create Date:	2007-11-27 by Allen
*	Update Date:
*	Description:	Read configuration file
*******************************************************************************************/
using System;
using System.Data;
using System.Collections;
using System.IO;
using System.Configuration;
using System.Xml.Serialization;
using System.Xml;
using System.Web;
using System.Web.Caching;

namespace Citic_Web
{
    /// <summary>
    /// Summary description for ConfigNode.
    /// </summary>
    public class ConfigSetting
    {
        #region  -- Constructorss --
        public ConfigSetting()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion

        #region  -- Public Propertis --
        public static HttpContext Context
        {
            get
            {
                HttpContext c = HttpContext.Current;
                if (c == null)
                    throw (new Exception("HttpContext not found!"));
                try
                {
                    return c;
                }
                catch (Exception x)
                {
                    throw (new Exception(x.Message));
                }
            }
        }

        public string SettingConfigLocation
        {
            get
            {
                return this.GetParentLocation() + "/web.config";
            }
        }

        public string ParentLocation
        {
            get
            {
                return GetParentLocation();
            }
        }

        #endregion

        #region  -- Private User Methods --

        private string GetParentLocation()
        {
            /*
            string Location = "";
            Location = Context.Server.MapPath(Context.Request.ApplicationPath);
            if (Location.EndsWith("/"))
                Location = Location.Substring(0, Location.Length - 1);
            return Location;
            */

            return RootPath();
        }

        private XmlDocument GetWebConfigXML()
        {
            XmlDocument xmlDoc = new XmlDocument();
            Cache cache = GetCache();
            object o = null;
            if (cache != null)
                o = cache["Settings"];
            //object o = ConfigSetting.Context.Cache["Settings"];
            if (o == null)
            {
                System.IO.FileInfo file = new FileInfo(this.SettingConfigLocation);
                if (!file.Exists)
                {
                    throw new System.IO.FileNotFoundException("setting file can not be found!");
                }
                else
                {
                    System.IO.TextReader tr = new StreamReader(this.SettingConfigLocation, System.Text.Encoding.Default);
                    using (tr)
                    {
                        xmlDoc.Load(tr);
                        tr.Close();
                    }
                    //Context.Cache.Insert("Settings", xmlDoc, new System.Web.Caching.CacheDependency(this.SettingConfigLocation));
                    if (cache != null)
                        cache.Insert("Settings", xmlDoc, new System.Web.Caching.CacheDependency(this.SettingConfigLocation));
                }
            }
            else
            {
                xmlDoc = (XmlDocument)cache["Settings"];
            }
            return xmlDoc;
        }

        #endregion

        #region  -- Public Methods --

        public string GetConnectionString()
        {
            string rb = "";
            XmlDocument xmlDoc = GetWebConfigXML();

            foreach (System.Xml.XmlNode n in xmlDoc["configuration"]["nhibernate"])
            {
                if (n.Name == "add" && n.Attributes["key"].Value == "hibernate.connection.connection_string")
                {
                    rb = n.Attributes["value"].Value;
                }
            }
            return rb;
        }

        public string GetErrorLogPath()
        {
            string rb = "";
            XmlDocument xmlDoc = GetWebConfigXML();

            foreach (System.Xml.XmlNode n in xmlDoc["configuration"]["appSettings"])
            {
                if (n.Name == "add" && n.Attributes["key"].Value == "ErrorLogPath")
                {
                    rb = n.Attributes["value"].Value;
                }
            }
            return this.GetParentLocation() + "\\" + rb + "\\";
        }

        public void EditXMLSection(string sectionname, string sectionvalue)
        {
            System.Xml.XmlDocument xdoc = new System.Xml.XmlDocument();

            xdoc.Load(this.SettingConfigLocation);
            foreach (System.Xml.XmlNode node in xdoc["configuration"])
            {
                if (node.Name == sectionname)
                {
                    node.InnerText = sectionvalue;
                }
            }
            xdoc.Save(this.SettingConfigLocation);
        }

        public void EditResources(string XmlPath, string ResourceName, string ResourceValue)
        {
            System.Xml.XmlDocument xdoc = new System.Xml.XmlDocument();

            xdoc.Load(XmlPath);
            foreach (System.Xml.XmlNode node in xdoc["root"])
            {
                if (node.NodeType != XmlNodeType.Comment)
                {
                    if (node.Attributes["name"].Value == ResourceName)
                    {
                        node.InnerText = ResourceValue;
                    }
                }
            }
            xdoc.Save(XmlPath);
        }

        #endregion

        #region Path Method
        public static string RootPath() {
            return RootPath("/");
        }

        public static string RootPath(string filePath)
        {
            string rootPath = AppDomain.CurrentDomain.BaseDirectory;
            string separator = Path.DirectorySeparatorChar.ToString();
            rootPath = rootPath.Replace("/", separator);
            if (filePath != null)
            {
                filePath = filePath.Replace("/", separator);
                if (((filePath.Length > 0) && filePath.StartsWith(separator)) && rootPath.EndsWith(separator))
                {
                    rootPath = rootPath + filePath.Substring(1);
                }
                else
                {
                    rootPath = rootPath + filePath;
                }
            }
            return rootPath;
        }

        public string PhysicalPath(string path)
        {
            return (RootPath().TrimEnd(new char[] { Path.DirectorySeparatorChar }) 
             + Path.DirectorySeparatorChar.ToString() + path.TrimStart(new char[] { Path.DirectorySeparatorChar }));
        }

        public string MapPath(string path)
        {
            HttpContext context = HttpContext.Current;
            if (context != null)
            {
                return context.Server.MapPath(path);
            }
            return PhysicalPath(path.Replace("/", Path.DirectorySeparatorChar.ToString()).Replace("~", ""));
        }

        private static Cache GetCache()
        {
            Cache cache = null;
            try
            {
                if (HttpContext.Current != null)
                    cache = HttpContext.Current.Cache;
                else
                    cache = HttpRuntime.Cache;
            }
            catch (Exception ex)
            {
                Logging.WriteLog(ex);
                return null;
            }
            return cache;
        }
        #endregion
    }
}