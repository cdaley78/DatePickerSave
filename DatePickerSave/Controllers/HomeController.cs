using DatePickerSave.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Globalization;

namespace DatePickerSave.Controllers
{
    public class HomeController : Controller
    {
        const string _startDateKey = "StartDate";

        public IActionResult Index()
        {
            var vm = new DateModel
            {
                StartDate = SetPeekDate(),
                EndDate = SetDateToString(DateTime.Now)
            };

            return View(vm);
        }

        public IActionResult Other()
        {
            var vm = new DateModel
            {
                StartDate = SetPeekDate(),
                EndDate = SetDateToString(DateTime.Now)
            };

            return View(vm);
        }

        private string SetPeekDate()
        {
            string myDate;

            if (!TempData.ContainsKey(_startDateKey))
            {
                myDate = SetDateToString(DateTime.Now);
            }
            else
            {
                myDate = SetDateToString(DateTime.Parse(TempData.Peek(_startDateKey).ToString()));
            }

            return myDate;
        }

        private string SetDateToString(DateTime date)
        {
            return date.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
        }

        [HttpPost]
        public JsonResult UpdateDate([FromBody] DateModel model)
        {
            TempData[_startDateKey] = model.StartDate;

            return Json(null);
        }
    }
}
