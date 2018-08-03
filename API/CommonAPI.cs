using Utils;
using DAL;
using Models;
using Models.Common;
using System;
using System.Collections.Generic;

namespace API
{
    public class CommonAPI
    {
        SysCodeDAL sysCode = new SysCodeDAL();
        AreaMstDAL areaDal = new AreaMstDAL();

        /// <summary>
        /// 获取选项值
        /// </summary>
        /// <param name="key">关键字</param>
        /// <param name="isDefault">默认选择</param>
        /// <returns></returns>
        public List<SysCode> GetCodeByKey(string key, bool isDefault)
        {
            return sysCode.GetList(key, isDefault);
        }

        /// <summary>
        /// 获取省市区选项值
        /// </summary>
        /// <param name="parent_id">父级区域ID</param>
        /// <param name="isDefault">默认选择</param>
        /// <returns></returns>
        public BodyInOut GetCodeByArea(string parent_id, bool isDefault)
        {
            BodyInOut ack = new BodyInOut();
            ack.function_id = ApiConst.FUNCTION_API_102;
            try
            {
                ack.data = areaDal.GetCodeByArea(parent_id, isDefault);
                ack.return_flag = ApiConst.RETURN_SUCCESS;
            }
            catch (Exception ex)
            {
                LogManager.ErrorLog(ex.ToString());
                ack.return_flag = ApiConst.RETURN_FAIL;
                ack.return_msg = ErrConst.ErrCode_0004;
            }
            return ack;
        }

        /// <summary>
        /// 根据区ID获取省市区名称
        /// </summary>
        /// <param name="district_id">区ID</param>
        /// <returns></returns>
        public AreaIDList GetAreaIDListByDistrictID(string district_id)
        {
            return areaDal.GetAreaIDListByDistrictID(district_id);
        }

        /// <summary>
        /// 获取省市区选项值
        /// </summary>
        /// <param name="parent_id">父级区域ID</param>
        /// <returns></returns>
        public BodyInOut GetAreaByParentID(string parent_id)
        {
            BodyInOut ack = new BodyInOut();
            try
            {
                ack.data = areaDal.GetAreaByParentID(parent_id);
                ack.return_flag = ApiConst.RETURN_SUCCESS;
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
