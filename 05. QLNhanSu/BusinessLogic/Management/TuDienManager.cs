using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessLogic.Model;
using Caching;
using Framework.Extensions;
using SQLDataAccess;
using log4net;

namespace BusinessLogic.Management
{
    public class TuDienManager
    {
        #region Singleton
        private static TuDienManager _instance;
        private TuDienManager() { }
        public static TuDienManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new TuDienManager();
                }
                return _instance;
            }
        }
        #endregion

        #region Members
        private readonly ILog _logger = LogManager.GetLogger(typeof(TuDienManager));
        #endregion

        #region Properties
        #endregion

        #region Public Interface
        public List<TuDienModel> GetTuDienByLoai(string ip_str_ma_loai_tu_dien)
        {
            var v_str_cache_key = BuildCacheKey(ip_str_ma_loai_tu_dien);
            var value = CacheManager.Instance.Get(v_str_cache_key) as List<TuDienModel>;
            if (value == null)
            {
                UnitOfWork uow = new UnitOfWork();
                var v_lst_tu_dien = uow.Repository<CM_DM_TU_DIEN_WEB>()
                    .Query().Include(x => x.CM_DM_LOAI_TD_WEB)
                    .Filter(x => x.CM_DM_LOAI_TD_WEB.MA_LOAI == ip_str_ma_loai_tu_dien).Get();
                value = v_lst_tu_dien.Select(x => x.CopyAs<TuDienModel>()).ToList();
                CacheManager.Instance.Add(v_str_cache_key, value, TimeSpan.FromMinutes(60));
            }

            return value;
        }

        public TuDienModel GetTuDienByLoaiVaMa(string ip_str_ma_loai_tu_dien, string ip_str_ma_tu_dien)
        {
            var v_lst_tu_dien = GetTuDienByLoai(ip_str_ma_loai_tu_dien);
            if (v_lst_tu_dien == null)
                _logger.Error(string.Format("Không load được từ điển với mã loại: {0}", ip_str_ma_loai_tu_dien));

            return v_lst_tu_dien.FirstOrDefault(x =>
                x.MA_TU_DIEN.Equals(ip_str_ma_tu_dien, StringComparison.InvariantCultureIgnoreCase));
        }

        public IEnumerable<CM_DM_TU_DIEN_WEB> GetAllDataInTuDien()
        {
            UnitOfWork uow = new UnitOfWork();
            var v_lst = uow.Repository<CM_DM_TU_DIEN_WEB>().Query().Get();
            return v_lst.Select(x => x.CopyAs<CM_DM_TU_DIEN_WEB>());
        }
        public void updateMaBN(TuDienModel td_model)
        {
            UnitOfWork uow = new UnitOfWork();
            td_model.State = EDataState.Modified;
            var v_td = td_model.CopyAs<CM_DM_TU_DIEN_WEB>();
            uow.Repository<CM_DM_TU_DIEN_WEB>().Update(v_td);
            uow.Save();
        }
        //public TuDienModel GetTuDienByMaLoai(string ip_str_ma_loai) {
        //    UnitOfWork uow = new UnitOfWork();
        //    var v_tudien = uow.Repository<CM_DM_TU_DIEN>().Query()
        //            .Filter(x => x.MA_TU_DIEN == ip_str_ma_loai)
        //            .OrderBy(x => x.OrderByDescending(y => y.TEN)).FirstOrDefault();
        //    return v_tudien.CopyAs<TuDienModel>();
        //} 
        public TuDienModel getTuDienById(Guid ip_id_tu_dien)
        {
            UnitOfWork uow = new UnitOfWork();
            var v_tu_dien = uow.Repository<CM_DM_TU_DIEN_WEB>().Query()
               .Filter(x => x.ID == ip_id_tu_dien).FirstOrDefault();
            return v_tu_dien.CopyAs<TuDienModel>();
        }

        #endregion

        #region Private Methods

        private string BuildCacheKey(string ip_loai_td)
        {
            return string.Format("Tudien_{0}", ip_loai_td);
        }

        #endregion
    }
}
