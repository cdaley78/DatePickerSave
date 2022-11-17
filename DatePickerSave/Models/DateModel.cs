using Microsoft.AspNetCore.Mvc;

namespace DatePickerSave.Models
{
    public class DateModel
    {
        [TempData]
        public string StartDate { get; set; }

        public string EndDate { get; set; }
    }
}
