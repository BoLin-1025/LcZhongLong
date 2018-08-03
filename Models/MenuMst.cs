using System;

namespace Models
{
    /// <summary>
    /// 菜单表
    /// </summary>
    [Serializable]
    public class MenuMst
    {
        /// <summary>
        /// 菜单ID
        /// </summary>
        public string menu_id { get; set; }
        /// <summary>
        /// 菜单名称
        /// </summary>
        public string menu_name { get; set; }
        /// <summary>
        /// 菜单Icon
        /// </summary>
        public string menu_icon { get; set; }
        /// <summary>
        /// 菜单Url
        /// </summary>
        public string menu_url { get; set; }
        /// <summary>
        /// 是否启用【0:否；1:是】
        /// </summary>
        public int is_enable { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public int sort_key { get; set; }
        /// <summary>
        /// 父级菜单
        /// </summary>
        public string father_menu { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime upd_date_time { get; set; }
    }
}
