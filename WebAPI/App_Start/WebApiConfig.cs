﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;

namespace WebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API 配置和服务

            // Web API 路由
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                "DefaultApi",
                "api/{controller}/{action}/{id}",
                new { id = RouteParameter.Optional }
            );
            config.Routes.MapHttpRoute(
                "DefaultApi2",
                "api2/{controller}/{action}/{id}",
                new { id = RouteParameter.Optional }
            );

            //GlobalConfiguration.Configuration.Formatters.XmlFormatter.SupportedMediaTypes.Clear();
            ////默认返回 json  
            //GlobalConfiguration.Configuration.Formatters.JsonFormatter.MediaTypeMappings.Add(
            //    new QueryStringMapping("datatype", "json", "application/json"));
            ////返回格式选择 datatype 可以替换为任何参数   
            //GlobalConfiguration.Configuration.Formatters.XmlFormatter.MediaTypeMappings.Add(
            //    new QueryStringMapping("datatype", "xml", "application/xml"));
        }
    }
}
