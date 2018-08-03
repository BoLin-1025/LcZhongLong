using Utils;
using DAL;
using Models;
using Models.Common;
using Models.ReturnForWeb;
using System;
using System.Collections.Generic;
using System.Data;

namespace API
{
    public class UserAPI
    {
        private readonly UserMstDAL dal = new UserMstDAL();
        private readonly SeqNoDAL seqNoDal = new SeqNoDAL();

        /// <summary>
        /// Web登录
        /// </summary>
        /// <param name="phone">手机号</param>
        /// <param name="pwd">密码</param>
        /// <param name="model"></param>
        /// <returns></returns>
        public BodyInOut WebLogin(string phone, string user_pwd)
        {
            BodyInOut ack = new BodyInOut();
            UserLoginForWeb model = new UserLoginForWeb();
            string sha256_user_pwd = BruceClass.Sha256(user_pwd);
            try
            {
                DataTable dt = dal.GetModel(phone);
                if (dt.Rows.Count > 0)
                {
                    string userPwd = BruceClass.DBNULLStr(dt.Rows[0]["UserPwd"]);
                    if (userPwd.Equals(sha256_user_pwd))
                    {
                        //用户角色
                        model.user_role = BruceClass.DBNULLStr(dt.Rows[0]["UserRole"]);
                        model.user_id = BruceClass.DBNULLStr(dt.Rows[0]["UserID"]);
                        model.nick_name = BruceClass.DBNULLStr(dt.Rows[0]["NickName"]);
                        model.store_id = BruceClass.DBNULLStr(dt.Rows[0]["StoreID"]);
                        model.store_name = BruceClass.DBNULLStr(dt.Rows[0]["StoreName"]);
                        model.store_logo = BruceClass.DBNULLStr(dt.Rows[0]["Logo"]);
                        model.active_flg = BruceClass.DBNULLStr(dt.Rows[0]["ActiveFlg"]);
                        ack.data = model;

                        ack.return_flag = ApiConst.RETURN_SUCCESS;
                        ack.return_msg = "";
                    }
                    else
                    {
                        ack.return_flag = ApiConst.RETURN_FAIL;
                        ack.return_msg = ErrConst.ErrCode_0005;
                    }
                }
                else
                {
                    ack.return_flag = ApiConst.RETURN_FAIL;
                    ack.return_msg = ErrConst.ErrCode_0003;
                }
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
        /// 登录
        /// </summary>
        /// <param name="phone">手机号</param>
        /// <param name="pwd">密码</param>
        /// <param name="model"></param>
        /// <returns></returns>
        public BodyInOut Login(string phone, string user_pwd, string open_id)
        {
            BodyInOut ack = new BodyInOut();
            ack.function_id = ApiConst.FUNCTION_API_1001;
            string sha256_user_pwd = BruceClass.Sha256(user_pwd);
            try
            {
                DataTable dt = dal.GetModel(phone);
                if (dt.Rows.Count > 0)
                {
                    string userPwd = BruceClass.DBNULLStr(dt.Rows[0]["UserPwd"]);
                    if (userPwd.Equals(sha256_user_pwd))
                    {
                        UserLogin model = new UserLogin();
                        model.user_id = BruceClass.DBNULLStr(dt.Rows[0]["UserID"]);
                        model.nick_name = BruceClass.DBNULLStr(dt.Rows[0]["NickName"]);
                        model.phone = BruceClass.DBNULLStr(dt.Rows[0]["Phone"]);
                        model.photo = BruceClass.DBNULLStr(dt.Rows[0]["Photo"]);
                        model.sex = BruceClass.DBNULLStr(dt.Rows[0]["Sex"]);
                        model.mail_addr = BruceClass.DBNULLStr(dt.Rows[0]["MailAddr"]);
                        model.active_flg = BruceClass.DBNULLStr(dt.Rows[0]["ActiveFlg"]);
                        model.total_points = BruceClass.DBNULLDouble(dt.Rows[0]["TotalPoints"]);
                        model.total_consume = BruceClass.DBNULLDouble(dt.Rows[0]["TotalConsume"]);
                        model.total_recharge = BruceClass.DBNULLDouble(dt.Rows[0]["TotalRecharge"]);
                        model.user_role= BruceClass.DBNULLStr(dt.Rows[0]["UserRole"]);
                        model.register_time = BruceClass.DBNULLStr(dt.Rows[0]["RegisterTime"]);

                        if (string.IsNullOrEmpty(open_id))
                        {
                            model.open_id = BruceClass.DBNULLStr(dt.Rows[0]["OpenID"]);
                        }
                        else
                        {
                            model.open_id = open_id;
                        }

                        ack.data = model;

                        ack.return_flag = ApiConst.RETURN_SUCCESS;
                        ack.return_msg = "";
                    }
                    else
                    {
                        ack.return_flag = ApiConst.RETURN_FAIL;
                        ack.return_msg = ErrConst.ErrCode_0005;
                    }
                }
                else
                {
                    ack.return_flag = ApiConst.RETURN_FAIL;
                    ack.return_msg = ErrConst.ErrCode_0003;
                }
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
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string key)
        {
            return dal.Exists(key);
        }

        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public BodyInOut AddModel(UserMst user)
        {
            BodyInOut ack = new BodyInOut();
            UserLogin model = new UserLogin();
            if (Exists(user.phone))
            {
                ack.return_flag = ApiConst.RETURN_FAIL;
                ack.return_msg = ErrConst.ErrCode_0001;
            }
            else
            {
                user.user_id = seqNoDal.GetSeqNo(MemoConst.USER_KEY);     //采番
                if (string.IsNullOrEmpty(user.user_pwd))
                {
                    user.user_pwd = "111111";                               //默认密码为111111
                }
                user.user_pwd = BruceClass.Sha256(user.user_pwd);          //加密
                //user.user_type = MemoConst.USER_TYPE_DEFAULT;             //默认用户类型
                user.active_flg = MemoConst.ACTIVEFLG_1;                  //默认用户是否有效
                user.total_points = MemoConst.POINTS;                           //默认注册积分
                if (dal.Regist(user))
                {
                    model.user_id = user.user_id;
                    model.nick_name = user.nick_name;
                    model.phone = user.phone;
                    model.photo = user.photo;
                    model.sex = user.sex;
                    model.mail_addr = user.mail_addr;
                    model.active_flg = user.active_flg;
                    model.total_points = user.total_points;
                    model.register_time = user.register_time.ToString("yyyy-MM-dd hh:mm:ss");
                    model.open_id = user.open_id;

                    ack.data = model;
                    ack.return_flag = ApiConst.RETURN_SUCCESS;
                    ack.return_msg = "";
                }
                else
                {
                    ack.return_flag = ApiConst.RETURN_FAIL;
                    ack.return_msg = ErrConst.ErrCode_0002;
                }
            }
            return ack;
        }

        /// <summary>
        /// 根据会员ID——查询会员信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public BodyInOut GetModel(string id)
        {
            BodyInOut ack = new BodyInOut();
            try
            {
                var model = GetBaseModel(id);
                if (model!=null)
                {
                    ack.data = model;
                    ack.return_flag = ApiConst.RETURN_SUCCESS;
                    ack.return_msg = "";
                }
                else
                {
                    ack.return_flag = ApiConst.RETURN_FAIL;
                    ack.return_msg = ErrConst.ErrCode_0003;
                }
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
        /// 根据会员ID——查询会员信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public UserMst GetBaseModel(string id)
        {
            UserMst model = new UserMst();
            DataTable dt = dal.GetModel(id);
            if (dt.Rows.Count > 0)
            {
                model.user_id = BruceClass.DBNULLStr(dt.Rows[0]["UserID"]);
                model.phone = BruceClass.DBNULLStr(dt.Rows[0]["Phone"]);
                model.nick_name = BruceClass.DBNULLStr(dt.Rows[0]["NickName"]);
                model.user_role = BruceClass.DBNULLStr(dt.Rows[0]["UserRole"]);
                model.user_pwd = BruceClass.DBNULLStr(dt.Rows[0]["UserPwd"]);
                model.photo = BruceClass.DBNULLStr(dt.Rows[0]["Photo"]);
                model.sex = BruceClass.DBNULLStr(dt.Rows[0]["Sex"]);
                model.mail_addr = BruceClass.DBNULLStr(dt.Rows[0]["MailAddr"]);
                model.active_flg = BruceClass.DBNULLStr(dt.Rows[0]["ActiveFlg"]);
                model.register_time = BruceClass.DBNULLDateTime(dt.Rows[0]["RegisterTime"]);
                model.open_id = BruceClass.DBNULLStr(dt.Rows[0]["OpenID"]);
            }
            return model;
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="user_id">用户ID</param>
        /// <param name="pwd">原密码</param>
        /// <param name="new_pwd">新密码</param>
        /// <returns></returns>
        public BodyInOut UpdatePwd(string user_id,string pwd,string new_pwd)
        {
            BodyInOut ack = new BodyInOut();
            try
            {
                UserMst model = GetBaseModel(user_id);
                if (model.user_pwd.Equals(BruceClass.Sha256(pwd)))
                {
                    if (dal.UpdatePwd(user_id,BruceClass.Sha256(new_pwd)))
                    {
                        ack.return_flag = ApiConst.RETURN_SUCCESS;
                        ack.return_msg = "";
                    }
                    else
                    {
                        ack.return_flag = ApiConst.RETURN_FAIL;
                        ack.return_msg = ErrConst.ErrCode_0007;
                    }
                }
                else
                {
                    ack.return_flag = ApiConst.RETURN_FAIL;
                    ack.return_msg = ErrConst.ErrCode_0017;
                }
            }
            catch (Exception ex)
            {
                LogManager.ErrorLog(ex.ToString());
                ack.return_flag = ApiConst.RETURN_FAIL;
                ack.return_msg = ex.ToString();
            }
            return ack;
        }

        /// <summary>
        /// 修改会员状态
        /// </summary>
        /// <param name="active_flg">是否有效【0、无效，1、有效】</param>
        /// <param name="user_id">会员ID</param>
        /// <returns></returns>
        public bool EditActive(string active_flg, string user_id)
        {
            return dal.EditActive(active_flg, user_id);
        }
    }
}
