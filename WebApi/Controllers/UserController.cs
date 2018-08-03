using API;
using Models;
using Models.PostForPhone;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi.Controllers
{
    public class UserController : ApiController
    {
        private UserAPI api = new UserAPI();
        
        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult Register([FromBody]JObject json)
        {
            UserMst model = JsonConvert.DeserializeObject<UserMst>(json.ToString());
            BodyInOut ack = api.AddModel(model);
            return Json<BodyInOut>(ack);
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult Login([FromBody]JObject json)
        {
            LoginForPost model = JsonConvert.DeserializeObject<LoginForPost>(json.ToString());
            BodyInOut ack = api.Login(model.phone, model.user_pwd, model.open_id);
            return Json<BodyInOut>(ack);
        }
    }
}
