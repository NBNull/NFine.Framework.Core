﻿using NFine.Application.SystemSecurity;
using NFine.Code;
using NFine.Domain.Entity.SystemSecurity;
using Microsoft.AspNetCore.Mvc;
namespace NFine.Web.Areas.SystemSecurity.Controllers
{
    public class FilterIPController : BaseController
    {
        private FilterIPApp filterIPApp;
        public FilterIPController(FilterIPApp filterIPApp)
        {
            this.filterIPApp = filterIPApp;
        }

        [HttpGet]
        //[HandlerAjaxOnly]
        public ActionResult GetGridJson(string keyword)
        {
            var data = filterIPApp.GetList(keyword);
            return Content(data.ToJson());
        }
        [HttpGet]
        //[HandlerAjaxOnly]
        public ActionResult GetFormJson(string keyValue)
        {
            var data = filterIPApp.GetForm(keyValue);
            return Content(data.ToJson());
        }
        [HttpPost]
        //[HandlerAjaxOnly]
        [ValidateAntiForgeryToken]
        public ActionResult SubmitForm(FilterIPEntity filterIPEntity, string keyValue)
        {
            filterIPApp.SubmitForm(filterIPEntity, keyValue);
            return Success("操作成功。");
        }
        [HttpPost]
        //[HandlerAjaxOnly]
        //[HandlerAuthorize]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteForm(string keyValue)
        {
            filterIPApp.DeleteForm(keyValue);
            return Success("删除成功。");
        }
    }
}
