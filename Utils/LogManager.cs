namespace Utils
{
    public class LogManager
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static void WriteLog(string info)
        {
            if (log.IsInfoEnabled)
            {
                log.Info(info);
            }
        }

        /// <summary>
        /// 错误记录
        /// </summary>
        /// <param name="info">附加信息</param>
        /// <param name="ex">错误</param>
        public static void ErrorLog(string errorMsg)
        {
            log.Error(errorMsg);
        }
    }
}