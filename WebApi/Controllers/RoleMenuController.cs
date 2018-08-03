using API;
using Models;
using Models.ReturnForPhone;
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
    public class RoleMenuController : ApiController
    {
        private RoleMenuAPI api = new RoleMenuAPI();

        /// <summary>
        /// 获取当前用户的菜单信息
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult GetMenuListByUser([FromBody]JObject json)
        {
            GetRoleMenuForPost model = JsonConvert.DeserializeObject<GetRoleMenuForPost>(json.ToString());
            BodyInOut ack = api.GetMenuListByUser(model.user_id, model.role_id);
            return Json<BodyInOut>(ack);
        }
    }
}
