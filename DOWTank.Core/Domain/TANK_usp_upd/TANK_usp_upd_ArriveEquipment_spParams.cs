using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOWTank.Core.Domain.TANK_usp_upd
{
    public class TANK_usp_upd_ArriveEquipment_spParams
    {
        public int? EquipmentID { get; set; }
        public string EquipmentAN { get; set; }
        public string CheckDigitAN { get; set; }
        public int? LocationID { get; set; }
        public Int16? LoadStatusTypeCD { get; set; }
        public string UpdateUserAN { get; set; }
    }
}
