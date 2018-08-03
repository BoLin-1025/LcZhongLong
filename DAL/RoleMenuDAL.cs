using DBUtility;
using Models.ReturnForWeb;
using System;
using System.Collections.Generic;
using System.Data;
using Utils;

namespace DAL
{
    public class RoleMenuDAL
    {
        /// <summary>
        /// 获取当前用户的菜单信息
        /// </summary>
        /// <param name="user_id">用户ID</param>
        /// <param name="role_id">用户角色ID</param>
        /// <returns></returns>
        public MenuForWeb GetMenuListByUser(string user_id, string role_id)
        {
            MenuForWeb ack = new MenuForWeb();
            try
            {
                List<MenuInfo> menu_list = new List<MenuInfo>();

                List<SubMenu> list = new List<SubMenu>();
                list = GetMenuByUser(user_id, role_id);

                foreach (var item in list)
                {
                    MenuInfo model = new MenuInfo();
                    model.menu_id = item.menu_id;
                    model.menu_name = item.menu_name;
                    model.menu_icon = item.menu_icon;

                    List<SubMenu> subList = new List<SubMenu>();
                    subList= GetMenuByUser(user_id, role_id, item.menu_id);

                    model.sub_menu = subList;

                    menu_list.Add(model);
                }

                ack.menu_list = menu_list;
                return ack;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<SubMenu> GetMenuByUser(string user_id, string role_id, string father_id="")
        {
            try
            {
                string sSql = "SELECT B.* FROM RoleMenuTbl A ";
                sSql += "LEFT JOIN MenuMst B ON A.MenuID = B.MenuID ";
                sSql += "WHERE(A.ObjectID = '" + user_id + "' OR A.ObjectID = '" + role_id + "') ";

                if (string.IsNullOrEmpty(father_id))
                {
                    sSql += "AND (B.FatherMenu IS NULL OR B.FatherMenu='') ";
                }
                else
                {
                    sSql += "AND B.FatherMenu = '" + father_id + "' ";
                }
                sSql += "AND B.IsEnable = '1' ";
                sSql += "ORDER BY B.SortKey";

                DataSet ds = DbHelperMySQL.Query(sSql);
                List<SubMenu> menu_list = new List<SubMenu>();

                if (ds.Tables.Count > 0)
                {
                    DataTable dt = ds.Tables[0];
                    SubMenu model = new SubMenu();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        model = DataRowToSubMenu(dt.Rows[i]);
                        if (model != null)
                        {
                            menu_list.Add(model);
                        }
                    }
                }
                return menu_list;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public SubMenu DataRowToSubMenu(DataRow row)
        {
            SubMenu model = new SubMenu();
            if (row != null)
            {
                if (row["MenuID"] != null)
                {
                    model.menu_id = row["MenuID"].ToString();
                }
                if (row["MenuName"] != null)
                {
                    model.menu_name = row["MenuName"].ToString();
                }
                if (row["MenuIcon"] != null)
                {
                    model.menu_icon = row["MenuIcon"].ToString();
                }
                if (row["MenuUrl"] != null)
                {
                    model.menu_url = row["MenuUrl"].ToString();
                }
            }
            return model;
        }
    }
}
