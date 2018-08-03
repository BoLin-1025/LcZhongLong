using System;

namespace Models.Common
{
    /// <summary>
    /// 登录返回信息类
    /// </summary>
    [Serializable]
    public class UserLogin
    {
        /// <summary>
        /// 会员号
        /// </summary>
        public string user_id { get; set; }
        /// <summary>
        /// 昵称
        /// </summary>
        public string nick_name { get; set; }
        /// <summary>
        /// 手机号
        /// </summary>
        public string phone { get; set; }
        /// <summary>
        /// 头像
        /// </summary>
        public string photo { get; set; }
        /// <summary>
        /// 性别【0:保密；1:男；2:女】
        /// </summary>
        public string sex { get; set; }
        /// <summary>
        /// 邮箱
        /// </summary>
        public string mail_addr { get; set; }
        /// <summary>
        /// 是否有效【0、无效，1、有效】
        /// </summary>
        public string active_flg { get; set; }
        /// <summary>
        /// 累计积分
        /// </summary>
        public double total_points { get; set; }
        /// <summary>
        /// 累计消费
        /// </summary>
        public double total_consume { get; set; }
        /// <summary>
        /// 累计充值
        /// </summary>
        public double total_recharge { get; set; }
        /// <summary>
        /// 注册时间
        /// </summary>
        public string register_time { get; set; }
        /// <summary>
        /// 微信OpenID
        /// </summary>
        public string open_id { get; set; }
        /// <summary>
        /// 用户角色
        /// </summary>
        public string user_role { get; set; }
    }

    public class UserLoginForWeb
    {
        /// <summary>
        /// 会员号
        /// </summary>
        public string user_id { get; set; }
        /// <summary>
        /// 昵称
        /// </summary>
        public string nick_name { get; set; }
        /// <summary>
        /// 是否有效【0、无效，1、有效】
        /// </summary>
        public string active_flg { get; set; }
        /// <summary>
        /// 用户角色
        /// </summary>
        public string user_role { get; set; }
        /// <summary>
        /// 店铺ID
        /// </summary>
        public string store_id { get; set; }
        /// <summary>
        /// 店铺名称
        /// </summary>
        public string store_name { get; set; }
        /// <summary>
        /// 店铺Logo
        /// </summary>
        public string store_logo { get; set; }
    }
}