using System;
using System.ComponentModel.DataAnnotations;

namespace DOWTank.Models
{
    public class DispatchTankModel
    {
        public Int32? intDispatchId { get; set; }
        [Required(ErrorMessage = "Tank Number is required")]
        public Int32? intEquipmentId { get; set; }
        public Int32? intChassisEquipmentId { get; set; }
        [Required(ErrorMessage = "Tank Status is required")]
        public Int16 sintLoadStatusTypeId { get; set; }
        public Int16? sintProductId { get; set; }
        public Int16? sintDispatchReasonTypeId { get; set; }
        public Int16? sintAdditionalDispatchReasonTypeId { get; set; }
        [Required(ErrorMessage = "Loading Location is required")]
        public Int32 intLocationFrom { get; set; }
        [Required(ErrorMessage = "Delivery Location is required")]
        public Int32 intLocationTo { get; set; }
        [Required(ErrorMessage = "Shipment Number is required")]
        [StringLength(12, ErrorMessage = "Shipment Number must not exceed 12 characters")]
        [RegularExpression(@"\d{7}", ErrorMessage = "Shipment Number must be 7 digits")]
        public String strShipmentAN { get; set; }
        public Int32? intDriverId { get; set; }
        [Required(ErrorMessage = "Dispatch Start DateTime is required")]
        public DateTime dtmDispatchStart { get; set; }
        [Required(ErrorMessage = "Dispatch End DateTime is required")]
        public DateTime dtmDispatchEnd { get; set; }
        public DateTime? dtmScheduledDelivery { get; set; }
        [Required(ErrorMessage = "Block Contact is required")]
        public Int32 intContactId { get; set; }
        [Required(ErrorMessage = "Charge Code is required")]
        public Int32 intChargeCode { get; set; }
        public Int32? intChargeBlockLocationId { get; set; }
        public Int16? sintCraneLiftAmt { get; set; }
        public Int32? intFittingId { get; set; }
        public Boolean bolIsPlannedFL { get; set; }
        [Required(ErrorMessage = "Pro Number is required")]
        public String strProNumberAN { get; set; }
        [StringLength(7000, ErrorMessage = "Comments must not exceed 7000 characters")]
        public String strComments { get; set; }
        public Int32 intLocationId { get; set; }
        public Double? dblCallOutHoursAMT { get; set; }
        public Int32? intWasteClassTypeId { get; set; }
        public Boolean bolIsReloadFL { get; set; }
        public Boolean bolIsCleaningApprovedFL { get; set; }
        public String strWPNAN { get; set; }
    }
}