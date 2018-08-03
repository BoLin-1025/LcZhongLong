using Utils;
using DBUtility;
using Models;
using Models.Common;
using Models.ReturnForPhone;
using System.Collections.Generic;
using System.Data;

namespace DAL
{
    public class AreaMstDAL
    {
        public AreaMstDAL() { }

        /// <summary>
        /// 区域Code
        /// </summary>
        /// <returns></returns>
        public List<SysCode> GetCodeByArea(string parent_id, bool isDefault)
        {
            string sSql = "SELECT AreaID,AreaName FROM AreaMst WHERE ";
            if (string.IsNullOrEmpty(parent_id))
            {
                sSql += "ParentID='0' ";
            }
            else
            {
                sSql += "ParentID='" + parent_id + "' ";
            }
            sSql += "ORDER BY SortKey ";
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

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public SysCode DataRowToModel(DataRow row)
        {
            SysCode model = new SysCode();
            if (row != null)
            {
                if (row["AreaID"] != null)
                {
                    model.CodeValue = row["AreaID"].ToString();
                }
                if (row["AreaName"] != null)
                {
                    model.CodeName = row["AreaName"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 根据区ID获取省市区名称
        /// </summary>
        /// <param name="district_id">区ID</param>
        /// <returns></returns>
        public AreaIDList GetAreaIDListByDistrictID(string district_id)
        {
            string sSql = "SELECT a.AreaID As PID,a.AreaName As PName,b.AreaID As CID,b.AreaName As CName,c.AreaID As AID,c.AreaName As AName FROM areamst c ";
            sSql += " LEFT JOIN areamst b ON b.AreaID=c.ParentID ";
            sSql += " LEFT JOIN areamst a ON a.AreaID=b.ParentID ";
            sSql += " WHERE c.AreaID='" + district_id + "' ";
            DataSet ds = DbHelperMySQL.Query(sSql);
            AreaIDList model = new AreaIDList();
            if (ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                if (dt.Rows[0] != null)
                {
                    if (dt.Rows[0]["PID"] != null)
                    {
                        model.province_id = dt.Rows[0]["PID"].ToString();
                    }
                    if (dt.Rows[0]["PName"] != null)
                    {
                        model.province_name = dt.Rows[0]["PName"].ToString();
                    }
                    if (dt.Rows[0]["CID"] != null)
                    {
                        model.city_id = dt.Rows[0]["CID"].ToString();
                    }
                    if (dt.Rows[0]["CName"] != null)
                    {
                        model.city_name = dt.Rows[0]["CName"].ToString();
                    }
                    if (dt.Rows[0]["AID"] != null)
                    {
                        model.district_id = dt.Rows[0]["AID"].ToString();
                    }
                    if (dt.Rows[0]["AName"] != null)
                    {
                        model.district_name = dt.Rows[0]["AName"].ToString();
                    }
                }
            }
            return model;
        }

        /// <summary>
        /// 区域Code
        /// </summary>
        /// <returns></returns>
        public List<AreaInfo> GetAreaByParentID(string parent_id)
        {
            string sSql = "SELECT AreaID,AreaName FROM AreaMst WHERE ParentID='" + parent_id + "' ORDER BY SortKey ";
            DataSet ds = DbHelperMySQL.Query(sSql);
            List<AreaInfo> modelList = new List<AreaInfo>();

            if (ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                AreaInfo model = new AreaInfo();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    model = DataRowToAreaInfo(dt.Rows[i]);
                    if (model != null)
                    {
                        modelList.Add(model);
                    }
                }
            }
            return modelList;
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public AreaInfo DataRowToAreaInfo(DataRow row)
        {
            AreaInfo model = new AreaInfo();
            if (row != null)
            {
                if (row["AreaID"] != null)
                {
                    model.code_value = row["AreaID"].ToString();
                }
                if (row["AreaName"] != null)
                {
                    model.code_name = row["AreaName"].ToString();
                }
            }
            return model;
        }
    }
}
