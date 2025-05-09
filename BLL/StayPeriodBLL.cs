using System;
using System.Collections.Generic;
using DTO;
using DAL;

namespace BLL
{
    public class StayPeriodBLL
    {
        private StayPeriodDAL stayPeriodDAL;

        public StayPeriodBLL()
        {
            stayPeriodDAL = new StayPeriodDAL();
        }

        public List<StayPeriodDTO> GetAllStayPeriods()
        {
            return stayPeriodDAL.GetAllStayPeriods();
        }

        public bool AddStayPeriod(StayPeriodDTO stayPeriod)
        {
            if (stayPeriod != null)
            {
                return stayPeriodDAL.AddStayPeriod(stayPeriod);
            }
            return false;
        }
    }
}
