using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOWTank.Core.Domain.TANK_usp_sel
{
    public class TANK_usp_sel_locationTreeALL_spResults
    {
        public int? ParentLocationId { get; set; }
        public int LocationID { get; set; }
        public string LocationDS { get; set; }
        public int Type { get; set; }
    }
}
