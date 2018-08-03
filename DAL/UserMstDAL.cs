using DBUtility;
using Models;
using System;
using System.Data;

namespace DAL
{
    public class UserMstDAL
    {
        public UserMstDAL() { }

        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool Regist(UserMst model)
        {
            string sSql = "INSERT INTO UserMst ";
            sSql += "(UserID, NickName, Phone, UserPwd, Sex, Photo, MailAddr, UserRole, ActiveFlg, TotalPoints, TotalConsume, TotalRecharge, Province, City, District, Address, OpenID, CompanyID, RegisterTime, UpdDateTime) ";
            sSql += "VALUES(";
            sSql += "'" + model.user_id + "',";
            sSql += "'" + model.nick_name + "',";
            sSql += "'" + model.phone + "',";
            sSql += "'" + model.user_pwd + "',";
            sSql += "'" + model.sex + "',";
            sSql += "'" + model.photo + "',";
            sSql += "'" + model.mail_addr + "',";
            sSql += "'" + model.user_role + "',";
            sSql += "'" + model.active_flg + "',";
            sSql += model.total_points + ",";
            sSql += model.total_consume + ",";
            sSql += model.total_recharge + ",";
            sSql += "'" + model.province + "',";
            sSql += "'" + model.city + "',";
            sSql += "'" + model.district + "',";
            sSql += "'" + model.address + "',";
            sSql += "'" + model.open_id + "',";
            sSql += "'" + model.company_id + "',";
            sSql += "'" + DateTime.Now.ToString() + "',";
            sSql += "'" + DateTime.Now.ToString() + "'";
            sSql += ")";
            int rowCount = DbHelperMySQL.ExecuteSql(sSql);
            if (rowCount > 0)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="user_id"></param>
        /// <param name="company_id"></param>
        /// <returns></returns>
        public bool InsertUnionInfo(string user_id, string company_id)
        {
            string sSql = "INSERT INTO UserCompUnionTbl ";
            sSql += "(UserID, CompanyID, RoleType, RegisterTime, UpdDateTime) ";
            sSql += "VALUES(";
            sSql += "'" + user_id + "',";
            sSql += "'" + company_id + "',";
            sSql += "'',";
            sSql += "'" + DateTime.Now.ToString() + "',";
            sSql += "'" + DateTime.Now.ToString() + "'";
            sSql += ")";
            int rowCount = DbHelperMySQL.ExecuteSql(sSql);
            if (rowCount > 0)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="new_pwd">新密码</param>
        /// <returns></returns>
        public bool UpdatePwd(string user_id, string new_pwd)
        {
            string sSql = "UPDATE UserMst SET ";
            sSql += "UserPwd='" + new_pwd + "',";
            sSql += "UpdDateTime='" + DateTime.Now.ToString() + "'";

            sSql += " WHERE UserID='" + user_id + "'";
            int rowCount = DbHelperMySQL.ExecuteSql(sSql);
            if (rowCount > 0)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 更新OpenID
        /// </summary>
        /// <param name="open_id">OpenID</param>
        /// <returns></returns>
        public bool UpdateOpenID(string user_id, string open_id)
        {
            string sSql = "UPDATE UserMst SET ";
            sSql += "OpenID='" + open_id + "',";
            sSql += "UpdDateTime='" + DateTime.Now.ToString() + "'";

            sSql += " WHERE UserID='" + user_id + "'";
            int rowCount = DbHelperMySQL.ExecuteSql(sSql);
            if (rowCount > 0)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 修改会员状态
        /// </summary>
        /// <param name="active_flg">是否有效【0、无效，1、有效】</param>
        /// <param name="user_id">会员ID</param>
        /// <returns></returns>
        public bool EditActive(string active_flg, string user_id)
        {
            string sSql = "UPDATE UserMst SET ";
            sSql += "ActiveFlg='" + active_flg + "'";

            sSql += " WHERE UserID='" + user_id + "'";
            int rowCount = DbHelperMySQL.ExecuteSql(sSql);
            if (rowCount > 0)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 根据手机号或UserID——查询会员信息
        /// </summary>
        /// <param name="key">手机号或UserID</param>
        /// <param name="app_name">登录区分</param>
        /// <returns></returns>
        public DataTable GetModel(string key)
        {
            string sSql = "SELECT * FROM UserMst ";
            sSql += " WHERE UserID='" + key + "' OR Phone='" + key + "'";

            DataSet ds = DbHelperMySQL.Query(sSql);
            return ds.Tables[0];
        }

        /// <summary>
        /// 查询会员列表信息
        /// </summary>
        /// <param name="key">账号、手机号、昵称</param>
        /// <param name="user_role">用户角色</param>
        /// <param name="pageSize">每页显示记录数</param>
        /// <param name="pageNow">当前页</param>
        /// <returns></returns>
        public DataTable GetList(string key, string user_role, int pageSize, int pageNow = 1)
        {
            string sSql = "SELECT A.UserID,A.NickName,A.Phone,A.Sex,A.MailAddr,A.UserRole,B.RoleName,A.RegisterTime FROM UserMst A ";
            sSql += " LEFT JOIN RoleMst B ON b.RoleID=A.UserRole ";
            sSql += " WHERE 1=1 ";
            if (!string.IsNullOrEmpty(key))
            {
                sSql += " AND (A.UserID LIKE '%" + key + "%' OR A.Phone LIKE '%" + key + "%' OR A.NickName LIKE '%" + key + "%') ";
            }
            if (!string.IsNullOrEmpty(user_role))
            {
                sSql += " AND A.UserRole='" + user_role + "' ";
            }
            int number = (pageNow - 1) * pageSize;
            sSql += " ORDER BY A.UserID LIMIT " + number + "," + pageSize;

            DataSet ds = DbHelperMySQL.Query(sSql);
            return ds.Tables[0];
        }

        /// <summary>
        /// 查询会员列表总数
        /// </summary>
        /// <param name="key">账号、手机号、昵称</param>
        /// <param name="user_role">用户类型</param>
        /// <returns></returns>
        public int GetListCount(string key, string user_role)
        {
            string sSql = "SELECT Count(*) FROM UserMst A ";
            sSql += " LEFT JOIN RoleMst B ON B.RoleID=A.UserRole ";
            sSql += " WHERE 1=1 ";
            if (!string.IsNullOrEmpty(key))
            {
                sSql += " AND (A.UserID LIKE '%" + key + "%' OR A.Phone LIKE '%" + key + "%' OR A.NickName LIKE '%" + key + "%') ";
            }
            if (!string.IsNullOrEmpty(user_role))
            {
                sSql += " AND A.UserRole='" + user_role + "' ";
            }
            object obj = DbHelperMySQL.GetSingle(sSql);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string key)
        {
            string sSql = "SELECT COUNT(1) from UserMst WHERE Phone = '" + key + "' OR UserID='" + key + "'";
            return DbHelperMySQL.Exists(sSql);
        }
    }
}
