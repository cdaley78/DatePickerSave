using DatePickerSave.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace DatePickerSave.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            CheckDatePicker();

            return View();
        }

        public IActionResult Other()
        {
            CheckDatePicker();

            return View();
        }

        private void CheckDatePicker()
        {
            if (!TempData.ContainsKey("datepickerval"))
            {
                TempData["datepickerval"] = SetDateToString(DateTime.Now);
            }
            else
            {
                TempData["datepickerval"] = SetDateToString(DateTime.Parse(TempData["datepickerval"].ToString()));
                TempData.Keep("datepickerval");
            }
        }

        private string SetDateToString(DateTime date)
        {
            return date.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
        }

        [HttpPost]
        public JsonResult UpdateDate([FromBody] DateModel model)
        {
            TempData["datepickerval"] = SetDateToString(DateTime.Parse(model.date));
            TempData.Keep("datepickerval");

            return Json(null);
        }
    }

    public class DateModel
    {
        public string date { get; set; }
    }
}
