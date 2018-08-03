using System;

namespace Models
{
    /// <summary>
    /// 角色菜单表
    /// </summary>
    [Serializable]
    public class RoleMenuTbl
    {
        /// <summary>
        /// ID自增
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// 对象ID【角色ID或用户ID】
        /// </summary>
        public string object_id { get; set; }
        /// <summary>
        /// 菜单ID
        /// </summary>
        public string menu_id { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime upd_date_time { get; set; }
    }
}
