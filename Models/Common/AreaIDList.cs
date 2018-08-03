namespace Models.Common
{
    /// <summary>
    /// 获取省市区的ID和名字
    /// </summary>
    public class AreaIDList
    {
        /// <summary>
        /// 省ID
        /// </summary>
        public string province_id { get; set; }
        /// <summary>
        /// 省名称
        /// </summary>
        public string province_name { get; set; }
        /// <summary>
        /// 市ID
        /// </summary>
        public string city_id { get; set; }
        /// <summary>
        /// 市名称
        /// </summary>
        public string city_name { get; set; }
        /// <summary>
        /// 区ID
        /// </summary>
        public string district_id { get; set; }
        /// <summary>
        /// 区名称
        /// </summary>
        public string district_name { get; set; }
    }
}
