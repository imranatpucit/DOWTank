using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DOWTank.Models
{
    public class TankPrepPostModel
    {
        public TankPrepPostModel()
        {
            ActiveFL = true;
        }

        public int TankPrepID { get; set; }
        public int? EquipmentID { get; set; }
        public int? ChassisEquipmentID { get; set; }
        public Int16? LoadStatusTypeCD { get; set; }
        [Required(ErrorMessage = "Product is required")]
        public Int16? ProductID { get; set; }
        public int? FromLocationID { get; set; }
        public int? ToLocationID { get; set; }
        [Required(ErrorMessage = "Charge Code is required")]
        public int? ChargeCodeID { get; set; }
        [Required(ErrorMessage = "Shipment Number is required")]
        [StringLength(12, ErrorMessage = "Shipment Number must not exceed 12 characters")]
        [RegularExpression(@"\d{7}", ErrorMessage = "Shipment Number must be 7 digits")]
        public string ShipmentAN { get; set; }
        [Required(ErrorMessage = "Load Date is required")]
        public DateTime? ScheduledLoadDT { get; set; }
        public DateTime? ScheduledDeliveryDT { get; set; }
        public bool DeliverASAPFL { get; set; }
        public int? FittingCD { get; set; }
        [StringLength(7000, ErrorMessage = "Comments must not exceed 7000 characters")]
        public string CommentsAn { get; set; }
        public string MoveTypeCD { get; set; }
        public int LocationID { get; set; }
        public bool ActiveFL { get; set; }
        public int DispatchedFL { get; set; }
        public bool ReloadFL { get; set; }
        [Required(ErrorMessage = " Block Contact required")]
        public int? ContactID { get; set; }
    }
}