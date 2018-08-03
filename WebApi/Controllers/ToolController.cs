using API;
using Models;
using Models.PostForWeb;
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
    public class ToolController : ApiController
    {
        private CommonAPI api = new CommonAPI();

        /// <summary>
        /// 取得省市区信息
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult GetArea([FromBody]JObject json)
        {
            AreaForWeb model = JsonConvert.DeserializeObject<AreaForWeb>(json.ToString());
            BodyInOut ack = api.GetCodeByArea(model.area_id,true);
            return Json<BodyInOut>(ack);
        }
    }
}
