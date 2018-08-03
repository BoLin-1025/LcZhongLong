using System;

namespace Models.PostForPhone
{
    /// <summary>
    /// 登录提交信息类
    /// </summary>
    [Serializable]
    public class LoginForPost
    {
        /// <summary>
        /// 手机号
        /// </summary>
        public string phone { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string user_pwd { get; set; }
        /// <summary>
        /// 微信OpenID
        /// </summary>
        public string open_id { get; set; }
        /// <summary>
        /// 绑定平台 公众号：WX、小程序：APP
        /// </summary>
        public string app_name { get; set; }
    }
}