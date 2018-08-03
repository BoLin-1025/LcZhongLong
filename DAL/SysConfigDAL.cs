using DBUtility;
using System.Data;

namespace DAL
{
    public class SysConfigDAL
    {
        public SysConfigDAL() { }

        /// <summary>
        /// 获取配置文件中的值
        /// </summary>
        /// <param name="config_name"></param>
        /// <returns></returns>
        public string GetConfigValue(string config_name)
        {
            string config_value = "";
            string sSql = "SELECT * FROM SysConfig WHERE ConfigName='" + config_name + "'";
            DataSet ds = DbHelperMySQL.Query(sSql);
            if (ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["ConfigValue"] != null)
                    {
                        config_value = dt.Rows[0]["ConfigValue"].ToString();
                    }
                }
            }
            return config_value;
        }
    }
}
