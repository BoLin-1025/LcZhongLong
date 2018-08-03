using System.Collections.Generic;

namespace Models.ReturnForWeb
{
    public class MenuForWeb
    {
        public List<MenuInfo> menu_list { get; set; }
    }

    public class MenuInfo
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
        /// 子菜单集合
        /// </summary>
        public List<SubMenu> sub_menu { get; set; }
    }

    public class SubMenu
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
    }
}
