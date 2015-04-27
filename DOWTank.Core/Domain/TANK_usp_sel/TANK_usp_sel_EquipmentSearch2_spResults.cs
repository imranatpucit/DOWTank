using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOWTank.Core.Domain.TANK_usp_sel
{
    public class TANK_usp_sel_EquipmentSearch2_spResults
    {
        public Int32 EquipmentID { get; set; }
        public string EquipmentAn { get; set; }
        public string EquipmentDS { get; set; }
        public string EquipmentTypeDS { get; set; }
        public bool ActiveFL { get; set; }
    }
}
