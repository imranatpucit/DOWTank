using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DOWTank.Models
{
    public class TankArrivalUpdatePostModel
    {
        [Required(ErrorMessage = "Tank # is required")]
        public int? EquipmentID { get; set; }
        [StringLength(10)]
        [Required(ErrorMessage = "Tank (EquipmentAN)  is required")]
        public string EquipmentAN { get; set; }
        [StringLength(1)]
        public string CheckDigitAN { get; set; }
        public int? LocationID { get; set; }
        public Int16? LoadStatusTypeCD { get; set; }
        public string UpdateUserAN { get; set; }
    }
}