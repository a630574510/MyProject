using System;
using System.Collections.Generic;
using System.Web;

namespace Citic_Web
{
    public enum ActionType
    {
        UserLogin = 1,
        ChangePassword = 10100101,       //Setup/ChangePassword.aspx
        ChangeProfile = 10100301,        //Setup/PersonalProfile.aspx
        CleintList = 15200301,          //Setup/ClientList.aspx   列表  终端客户
        CleintView = 15200302,           //Setup/EditClient.aspx   查看
        CleintEdit = 15200303,           //Setup/EditClient.aspx   编辑
        CleintDelete = 15200304,         //Setup/ClientList.aspx   删除

        VendorList = 15200201,           //Setup/VendorList.aspx   列表 商家
        VendorView = 15200202,           //Setup/EditVendor.aspx   产看
        VendorEdit = 15200203,           //Setup/EditVendor.aspx   修改
        VendorDelete = 15200204,         //Setup/VendorList.aspx  删除

        TargetList = 15200501,            //Setup/TargetList.aspx   列表 监控对象
        TargetView = 15200502,           //Setup/EditTarget.aspx   产看
        TargetEdit = 15200503,           //Setup/EditTarget.aspx   修改
        TargetDelete = 15200504,         //Setup/TargetList.aspx  删除

        UserList = 15100101,            //Setup/UserList.aspx   列表  用户
        UserView = 15100102,           //Setup/EditUser.aspx   产看
        UserEdit = 15100103,           //Setup/EditUser.aspx   修改
        UserDelete = 15100104,         //Setup/UserList.aspx  删除

        RoleList = 15100201,            //Setup/RoleList.aspx   列表 角色
        RoleView = 15100202,           //Setup/EditRole.aspx   产看
        RoleEdit = 15100203,           //Setup/EditRole.aspx   修改
        RoleDelete = 15100204,         //Setup/RoleList.aspx  删除

        UserLoginLog = 15100301,            //Setup/UseLog.aspx   登录历史
        UserActionLog = 15100401,           //Setup/ActionLog.aspx   操作日志
        UserLoginOut = 15100501,            //退出登录

        AccountList = 15200101,            //Setup/AccountList.aspx   列表 子公司
        AccountView = 15200102,           //Setup/EdiAccount.aspx   产看
        AccountEdit = 15200103,           //Setup/EditAccount.aspx   修改
        AccountDelete = 15200104,         //Setup/AccountList.aspx  删除

        DeviceList = 15200401,            //Setup/DeviceList.aspx   列表 设备
        DeviceView = 15200402,           //Setup/EdiDevice.aspx   产看
        DeviceEdit = 15200403,           //Setup/EditDevice.aspx   修改
        DeviceDelete = 15200404,         //Setup/DeviceList.aspx  删除

        DictList = 15500201,            //Setup/DictList.aspx   列表 数据字段
        DictView = 15500202,           //Setup/EdiDict.aspx   产看
        DictEdit = 15500203,           //Setup/EditDict.aspx   修改
        DictDelete = 15500204,         //Setup/DictList.aspx  删除


        DeviceTypeList = 15500301,            //Setup/DeviceTypeList.aspx   列表 设备定义
        DeviceTypeView = 15500302,           //Setup/EdiDeviceType.aspx   产看
        DeviceTypeEdit = 15500303,           //Setup/EditDeviceType.aspx   修改
        DeviceTypeDelete = 15500304,         //Setup/DeviceTypeList.aspx  删除

        ZoneList = 20100101,            //Tools/ZoneList.aspx   列表 电子栅栏
        ZoneView = 20100102,           //Tools/EdiZone.aspx   产看
        ZoneEdit = 20100103,           //Tools/EditZone.aspx   修改
        ZoneDelete = 20100104,         //Tools/ZoneList.aspx  删除

        POIList = 20100201,            //Tools/POIList.aspx   列表 标注
        POIView = 20100202,           //Tools/EdiPOI.aspx   产看
        POIEdit = 20100203,           //Tools/EditPOI.aspx   修改
        POIDelete = 20100204,         //Tools/POIList.aspx  删除

        FeedBackList = 81100201,            //Services/FeedBackList.aspx   列表 客户反馈
        FeedBackView = 81100202,           //Services/EdiFeedBack.aspx   产看
        FeedBackEdit = 81100203,           //Services/EditFeedBack.aspx   修改
        FeedBackDelete = 81100204,         //Services/FeedBackList.aspx  删除

        SpeedReport = 71200101,            //超速报表
        StopReport = 71200102,            //停靠报表
        MileReport = 71200103,            //里程报表
        ExceptionReport = 71200104,        //异常报表


        VehicleNavServices = 81100301,  //导航服务


        HelpInfoList = 15500501,
        HelpInfoEdit = 15500502,
        HelpInfoDelete = 15500503

    }
}