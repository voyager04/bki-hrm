using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Model;
using DataAccess;
using Framework.Extensions;

namespace BusinessLogic.Management
{
    public class CoCauTopicaManager
    {
        #region Singleton
        private static CoCauTopicaManager _instance;
        private CoCauTopicaManager() { }
        public static CoCauTopicaManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new CoCauTopicaManager();
                }
                return _instance;
            }
        }
        #endregion

        #region Public Interface
        public List<CoCauTopicaModel> GetAllDonVi()
        {
            return new UnitOfWork().Repository<V_DM_DON_VI>()
                .Query()
                .Get()
                .Select(m => m.CopyAs<CoCauTopicaModel>()).ToList();
        } 
        #endregion
    }
}
