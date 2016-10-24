using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MunicipalTrashCollection.Models
{
    public class Day
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? PickUpDateChange { get; set; }
        public DateTime? StartVacation { get; set; }
        public DateTime? EndVacation { get; set; }

        public enum DayList
        {
            Monday = 1,
            Tuesday,
            Wednesday,
            Thursday,
            Friday
        }
        public DayList Days { get; set; }
    }
}