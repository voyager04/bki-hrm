using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Model;
using DataAccess;

namespace BusinessLogic.Management
{
    public class V_DM_DON_VI_Manager
    {
        #region Singleton
        private static V_DM_DON_VI_Manager _instance;
        private V_DM_DON_VI_Manager() { }
        public static V_DM_DON_VI_Manager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new V_DM_DON_VI_Manager();
                }
                return _instance;
            }
        }
        #endregion

        #region Member
        UnitOfWork _unitOfWork = new UnitOfWork();
        #endregion

        #region Public Interface
        

        #endregion
    }
}
