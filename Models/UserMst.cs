using System;

namespace Models
{
    /// <summary>
    /// 会员表
    /// </summary>
    [Serializable]
    public class UserMst
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
        /// 密码
        /// </summary>
        public string user_pwd { get; set; }
        /// <summary>
        /// 性别【0:保密；1:男；2:女】
        /// </summary>
        public string sex { get; set; }
        /// <summary>
        /// 头像
        /// </summary>
        public string photo { get; set; }
        /// <summary>
        /// 邮箱
        /// </summary>
        public string mail_addr { get; set; }
        /// <summary>
        /// 用户角色
        /// </summary>
        public string user_role { get; set; }
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
        /// 省ID
        /// </summary>
        public string province { get; set; }
        /// <summary>
        /// 市ID
        /// </summary>
        public string city { get; set; }
        /// <summary>
        /// 区ID
        /// </summary>
        public string district { get; set; }
        /// <summary>
        /// 详细地址
        /// </summary>
        public string address { get; set; }
        /// <summary>
        /// 微信OpenID
        /// </summary>
        public string open_id { get; set; }
        /// <summary>
        /// 所属经销商ID
        /// </summary>
        public string company_id { get; set; }
        /// <summary>
        /// 注册时间
        /// </summary>
        public DateTime register_time { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime upd_date_time { get; set; }
    }
}
