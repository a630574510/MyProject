using System;
using System.Collections.Generic;
using System.Web;

namespace Citic_Web.Common
{
    #region 联系人枚举类型--乔春羽
    /// <summary>
    /// 联系人类型
    /// </summary>
    public enum LinkType
    {
        /// <summary>
        /// 银行客户经理联系人
        /// </summary>
        DealerBankLinkman = 5,
        /// <summary>
        /// 银行联系人
        /// </summary>
        BankLinkman = 2,
        /// <summary>
        /// 厂商联系人
        /// </summary>
        FactoryLinkman = 3,
        /// <summary>
        /// 仓库（二网）联系人
        /// </summary>
        StorageLinkman = 4,
        /// <summary>
        /// 经销商联系人
        /// </summary>
        DealerLinkman = 1
    }
    #endregion

    #region 质押物状态枚举--乔春羽
    /// <summary>
    /// 质押物状态
    /// </summary>
    public enum CarStatus
    {
        /// <summary>
        /// “出库”状态
        /// </summary>
        OutStorage = 0,
        /// <summary>
        /// “在库”状态
        /// </summary>
        InStorage = 1,
        /// <summary>
        /// “移动”状态
        /// </summary>
        Move = 2,
        /// <summary>
        /// 初始状态，既是“在途”状态
        /// </summary>
        Init = 3,
        /// <summary>
        /// “申请中”状态
        /// </summary>
        Pending = 4,
        /// <summary>
        /// “异常”状态
        /// </summary>
        Error = 5
    }
    #endregion

    #region 映射类型--乔春羽(2014.3.5)
    public enum UserMappingType
    {
        /// <summary>
        /// 银行
        /// </summary>
        Bank, 
        /// <summary>
        /// 品牌
        /// </summary>
        Brand
    }
    #endregion
}