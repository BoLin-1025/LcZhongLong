namespace Utils
{
    public class MemoConst
    {
        /*---------常量---------*/
        public const int PAGE_SIZE = 10;                        //每页记录数
        public const int POINTS = 0;                            //默认注册积分
        public const string ACTIVEFLG_1 = "1";                  //默认用户是否有效
        public const string USER_TYPE = "USER_TYPE";            //用户类型
        public const string ORDER_STATUS = "ORDER_STATUS";      //订单状态
        public const string RETURN_STATUS = "RETURN_STATUS";    //退货订单状态
        public const string ORDER_TYPE = "ORDER_TYPE";          //订单类型
        public const string USER_TYPE_DEFAULT = "3";            //默认用户类型为会员

        public const string CODE_NAME = "--请选择--";            //默认“--请选择--”
        public const string CODE_CATE_NAME = "-无（一级分类）-";   //默认分类“-无（一级分类）-”

        public const string ORDER_STATUS_00 = "00";             //未支付
        public const string ORDER_STATUS_01 = "01";             //已支付
        public const string ORDER_STATUS_02 = "02";             //已发货
        public const string ORDER_STATUS_03 = "03";             //订单取消
        public const string ORDER_STATUS_04 = "04";             //订单完成

        public const string USER_TYPE_1 = "1";            //管理员
        public const string USER_TYPE_2 = "2";            //经销商
        public const string USER_TYPE_3 = "3";            //会员


        /*------------------采番常量-----------------------*/
        public const string ROLEID_KEY = "ROLEID_KEY";                //角色ID
        public const string MENUID_KEY = "MENUID_KEY";                //菜单ID 

        public const string SUPPLIER_KEY = "SUPPLIER_KEY";            //供应商ID 
        public const string ORDERINFO_KEY = "ORDERINFO_KEY";          //订单明细ID
        public const string ORDER_KEY = "ORDER_KEY";                  //订单ID
        public const string USER_KEY = "USER_KEY";                    //会员ID
        public const string COMPANY_KEY = "COMPANY_KEY";              //经销商ID
        public const string RETURN_ORDER_KEY = "RETURN_ORDER_KEY";    //退货编号采番


        /*------------------Config常量-----------------------*/
        public const string WXAPPID_KEY = "WXAPPID_KEY";                    //绑定支付的APPID
        public const string MCHID_KEY = "MCHID_KEY";                        //商户号
        public const string APIKEY_KEY = "APIKEY_KEY";                      //商户支付密钥
        public const string APPSECRET_KEY = "APPSECRET_KEY";                //公众帐号secert
        public const string SSLCERT_PASSWORD_KEY = "SSLCERT_PASSWORD_KEY";  //证书密码
        public const string NOTIFY_URL_KEY = "NOTIFY_URL_KEY";              //支付结果通知回调url
        public const string WX_IP_KEY = "WX_IP_KEY";                        //商户系统后台机器IP


        /*------------------模版消息常量-----------------------*/
        public const string H5_URL = "http://www.langcheinfo.com/h5/";
        public const string NODE_API_URL = "http://www.langcheinfo.com/h5/api";

        /// <summary>
        /// 3个keyword【1、预约类型，2、预约时间，3、预约地点】
        /// </summary>
        public const string TEMPLATE_FAIL_ID = "5p6uluQvhcou43GY-wMAPN3XCtk_smgxeBDKF84hu-A";
        /// <summary>
        /// 3个keyword【1、客户姓名，2、预约项目，3、预约时间】
        /// </summary>
        public const string TEMPLATE_REMIND_ID = "9Cv-J_6UM5PmojfXLQUJpWLwdqLx3tCDF0Vb-NPSvgI";
        /// <summary>
        /// 5个keyword【1、预约经销商，2、预约车型，3、预约时间，4、车辆信息，5、保养套餐】
        /// </summary>
        public const string TEMPLATE_ACCEPTANCE_ID = "Up2zC5guYgaFrHELKWYruRjyEPedKdhtVr7applt_oo";
        /// <summary>
        /// 5个keyword【1、会员姓名，2、预约门店，3、门店地址，4、预约时间，5、预约服务】
        /// </summary>
        public const string TEMPLATE_SUCCESS_ID = "f9wb8WT4pVk7YEAlpG2ZNFPNf1ou_o-IZ5qAzesui_U";
        /// <summary>
        /// 5个keyword【1、预约门店，2、预约时间，3、接待者，4、联系电话，5、地址】
        /// </summary>
        public const string TEMPLATE_CAR_SUCCESS_ID = "yPUAPObzU-L0MDukG1_l_xrxzVaT8n20VhIqo-dezLc";
    }
}
