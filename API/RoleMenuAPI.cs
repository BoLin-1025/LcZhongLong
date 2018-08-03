using DAL;
using Models;
using System;
using Utils;

namespace API
{
    public class RoleMenuAPI
    {
        private RoleMenuDAL dal = new RoleMenuDAL();

        /// <summary>
        /// 获取当前用户的菜单信息
        /// </summary>
        /// <param name="user_id">用户ID</param>
        /// <param name="role_id">用户角色ID</param>
        /// <returns></returns>
        public BodyInOut GetMenuListByUser(string user_id, string role_id)
        {
            BodyInOut ack = new BodyInOut();
            ack.function_id = ApiConst.FUNCTION_API_1002;

            try
            {
                ack.data = dal.GetMenuListByUser(user_id, role_id);

                ack.return_flag = ApiConst.RETURN_SUCCESS;
                ack.return_msg = "";
            }
            catch (Exception ex)
            {
                LogManager.ErrorLog(ex.ToString());
                ack.return_flag = ApiConst.RETURN_FAIL;
                ack.return_msg = ErrConst.ErrCode_0004;
            }

            return ack;
        }
    }
}
