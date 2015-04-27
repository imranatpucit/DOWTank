using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOWTank.Core.Domain.TANK_usp_rpt
{
    public class TANK_usp_rpt_AuditDrivers_spParams
    {
        public int LocationID { get; set; }
        public DateTime StartDT { get; set; }
        public DateTime EndDT { get; set; }
    }
}
