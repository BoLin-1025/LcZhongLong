using System;

namespace Models
{
    /// <summary>
    /// 系统采番表
    /// </summary>
    [Serializable]
    public class SeqNo
    {
        /// <summary>
        /// 流水号业务类型KEY值
        /// </summary>
        public string SeqKey { get; set; }
        /// <summary>
        /// 清零规则
        /// </summary>
        public string ZeroType { get; set; }
        /// <summary>
        /// 清零规则
        /// </summary>
        public int DateType { get; set; }
        /// <summary>
        /// 当前最大值
        /// </summary>
        public int NowNumber { get; set; }
        /// <summary>
        /// 每次递增seed
        /// </summary>
        public int IncreNumber { get; set; }
        /// <summary>
        /// 最大值
        /// </summary>
        public int MaxNumber { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime UpDateTime { get; set; }
        /// <summary>
        /// 前缀
        /// </summary>
        public string PreFix { get; set; }
        /// <summary>
        /// 说明
        /// </summary>
        public string Memo { get; set; }
    }
}
