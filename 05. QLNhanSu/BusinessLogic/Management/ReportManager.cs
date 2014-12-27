using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLDataAccess;

namespace BusinessLogic.Management
{
    public class ReportManager
    {
        #region Constructor
        public static ReportManager _instance;
        private ReportManager() { }
        public static ReportManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ReportManager();
                }
                return _instance;
            }
        }
        #endregion

        #region Member
        UnitOfWork _uow = new UnitOfWork();
        #endregion

        #region Public Method

        #endregion

        #region Private Method

        #endregion
    }
}
