using DAL;

namespace API
{
    public static class SysConfigAPI
    {
        private static SysConfigDAL dal = new SysConfigDAL();

        /// <summary>
        /// 获取配置文件中的值
        /// </summary>
        /// <param name="config_name"></param>
        /// <returns></returns>
        public static string GetConfigValue(string config_name)
        {
            return dal.GetConfigValue(config_name);
        }
    }
}
