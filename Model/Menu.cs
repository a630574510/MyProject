using System;
namespace Citic.Model
{
    /// <summary>
    /// Menu:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Menu
    {
        public Menu()
        { }
        #region Model
        private int _menuid;
        private string _menuname;
        private string _menuurl;
        private int _parentmenu;
        private bool _isnavigation;
        private int? _menuorder;
        /// <summary>
        /// 
        /// </summary>
        public int MenuId
        {
            set { _menuid = value; }
            get { return _menuid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string MenuName
        {
            set { _menuname = value; }
            get { return _menuname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string MenuUrl
        {
            set { _menuurl = value; }
            get { return _menuurl; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int ParentMenu
        {
            set { _parentmenu = value; }
            get { return _parentmenu; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool IsNavigation
        {
            set { _isnavigation = value; }
            get { return _isnavigation; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? MenuOrder
        {
            set { _menuorder = value; }
            get { return _menuorder; }
        }
        #endregion Model

    }
}

