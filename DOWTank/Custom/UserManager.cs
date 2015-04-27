using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DOWTank.Core.Service;

namespace DOWTank.Custom
{
    public class UserManager
    {
        private IUtilityService _utilityService;
        public UserManager(IUtilityService utilityService)
        {
            _utilityService = utilityService;
        }
    }
}