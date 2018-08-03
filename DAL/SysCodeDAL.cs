using DBUtility;
using Models;
using System.Collections.Generic;
using System.Data;
using Utils;

namespace DAL
{
    public class SysCodeDAL
    {
        public SysCodeDAL() { }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public SysCode DataRowToModel(DataRow row)
        {
            SysCode model = new SysCode();
            if (row != null)
            {
                if (row["CodeValue"] != null)
                {
                    model.CodeValue = row["CodeValue"].ToString();
                }
                if (row["CodeName"] != null)
                {
                    model.CodeName = row["CodeName"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// Code定义
        /// </summary>
        /// <param name="key">关键字</param>
        /// <param name="isDefault">默认选择</param>
        /// <returns></returns>
        public List<SysCode> GetList(string key, bool isDefault)
        {
            string sSql = "SELECT * FROM SysCode WHERE CodeType='" + key + "' ORDER BY SortKey ";
            DataSet ds = DbHelperMySQL.Query(sSql);
            List<SysCode> modelList = new List<SysCode>();

            if (isDefault)
            {
                SysCode model = new SysCode();
                model.CodeName = MemoConst.CODE_NAME;
                model.CodeValue = "";
                modelList.Add(model);
            }

            if (ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                SysCode model = new SysCode();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    model = DataRowToModel(dt.Rows[i]);
                    if (model != null)
                    {
                        modelList.Add(model);
                    }
                }
            }
            return modelList;
        }
    }
}
