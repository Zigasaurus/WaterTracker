using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WaterTracker.Models
{
    public class Tracker
    {
        [Key]
        [Display(Name = "Date (DD/MM/YYYY)")]
        public string Date { get; set; }
        [Display(Name = "Volume Of Water Consumed (In Litres)")]
        public string VolumeOfWaterConsumed { get; set; }
    }
}