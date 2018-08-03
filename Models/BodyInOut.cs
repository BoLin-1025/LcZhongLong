namespace Models
{
    public class BodyInOut
    {
        /// <summary>
        /// 返回状态:接口编号
        /// </summary>
        public string function_id { get; set; }

        /// <summary>
        /// 返回状态0：成功、1：失败
        /// </summary>
        public string return_flag { get; set; }

        /// <summary>
        /// 返回失败原因
        /// </summary>
        public string return_msg { get; set; }

        /// <summary>
        /// 返回数据
        /// </summary>
        public object data { get; set; }
    }
}
