namespace Utils
{
    public class ApiConst
    {
        /*---------API返回成功或失败---------*/
        public const string RETURN_SUCCESS = "0";           //返回成功
        public const string RETURN_FAIL = "1";              //返回失败

        /*---------API基础接口号---------*/
        public static string FUNCTION_API_101 = "101";      //上传图片
        public static string FUNCTION_API_102 = "102";      //取得省市区选项值

        /*---------API后台接口号---------*/
        public static string FUNCTION_API_1001 = "1001";    //登录--后台
        public static string FUNCTION_API_1002 = "1002";    //角色菜单--后台
        public static string FUNCTION_API_1003 = "1003";    //修改应用审核状态--后台
        public static string FUNCTION_API_1004 = "1004";    //获取所有应用信息--后台
        public static string FUNCTION_API_1005 = "1005";    //获取应用信息
        public static string FUNCTION_API_1006 = "1006";    //删除应用--后台
        public static string FUNCTION_API_1007 = "1007";    //添加菜单--后台
        public static string FUNCTION_API_1008 = "1008";    //修改菜单--后台
        public static string FUNCTION_API_1009 = "1009";    //修改菜单是否启用状态--后台
        public static string FUNCTION_API_1010 = "1010";    //获取所有菜单信息--后台
        public static string FUNCTION_API_1011 = "1011";    //获取所有子菜单信息--后台
        public static string FUNCTION_API_1012 = "1012";    //获取当前用户的菜单信息--后台
        public static string FUNCTION_API_1013 = "1013";    //获取菜单信息--后台
        public static string FUNCTION_API_1014 = "1014";    //删除菜单--后台
        public static string FUNCTION_API_1015 = "1015";    //添加角色--后台
        public static string FUNCTION_API_1016 = "1016";    //修改角色--后台
        public static string FUNCTION_API_1017 = "1017";    //获取所有角色信息--后台
        public static string FUNCTION_API_1018 = "1018";    //获取角色信息--后台
        public static string FUNCTION_API_1019 = "1019";    //删除角色--后台

        /*---------API接口号---------*/
        public static string FUNCTION_API_10001 = "10001";  //登录--手机

        /*---------API返回失败信息---------*/
        public static string ErrCode_0001 = "注册失败-手机号重复！";
        public static string ErrCode_0002 = "注册失败！";
        public static string ErrCode_0003 = "用户名不存在！";
        public static string ErrCode_0004 = "系统异常！";
        public static string ErrCode_0005 = "密码不正确！";
        public static string ErrCode_0006 = "注册失败！";
        public static string ErrCode_0007 = "操作失败！";
        public static string ErrCode_0008 = "店铺不存在！";
        public static string ErrCode_0009 = "分类不存在！";
        public static string ErrCode_0010 = "暂无数据！";
        public static string ErrCode_0011 = "数据库插入失败！";
        public static string ErrCode_0012 = "商品库存不足！";
        public static string ErrCode_0013 = "数据库更新失败！";
        public static string ErrCode_0014 = "数据库删除失败！";
        public static string ErrCode_0015 = "物流信息不为空！";
        public static string ErrCode_0016 = "退货原因不为空！";
        public static string ErrCode_0017 = "原密码错误！";
        public static string ErrCode_0018 = "该订单不存在！";
        public static string ErrCode_0019 = "该优惠券已经超过最大领取数量！";
        public static string ErrCode_0020 = "订单金额CHECK失败！";
        public static string ErrCode_0021 = "未查到该OPENID的用户信息！";
    }
}
