using System.Collections.Generic;

namespace Models.ReturnForPhone
{
    public class AreaListForFhone
    {
        /// <summary>
        /// 省、市、区列表
        /// </summary>
        public List<AreaInfo> area_list { get; set; }
    }

    public class AreaInfo
    {
        /// <summary>
        /// 区域名称
        /// </summary>
        public string code_name { get; set; }
        /// <summary>
        /// 区域值
        /// </summary>
        public string code_value { get; set; }
    }
}
