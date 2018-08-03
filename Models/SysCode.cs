using System;

namespace Models
{
    /// <summary>
    /// Code定义表
    /// </summary>
    [Serializable]
    public class SysCode
    {
        /// <summary>
        /// 值
        /// </summary>
        public string CodeValue { get; set; }
        /// <summary>
        /// 显示名称
        /// </summary>
        public string CodeName { get; set; }
    }
}