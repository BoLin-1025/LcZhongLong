using System;

namespace Models
{
    /// <summary>
    /// 菜单表
    /// </summary>
    [Serializable]
    public class RoleMst
    {
        /// <summary>
        /// 角色ID
        /// </summary>
        public string role_id { get; set; }
        /// <summary>
        /// 角色名称
        /// </summary>
        public string role_name { get; set; }
        /// <summary>
        /// 角色描述
        /// </summary>
        public string memo { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime upd_date_time { get; set; }
    }
}
