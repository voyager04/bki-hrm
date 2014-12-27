using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BKISystemAdmin.Model;
using Caching;
using Framework.Extensions;
using IP.Core.IPCommon;
using SQLDataAccess;

namespace BKISystemAdmin.Manager
{
    public class CTuDienManager
    {
        #region Singleton
        private static CTuDienManager _instance;
        private CTuDienManager() { }
        public static CTuDienManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new CTuDienManager();
                }
                return _instance;
            }
        }
        #endregion

        #region Members

        private readonly CacheManager _cache = CacheManager.Instance;
        #endregion

        #region Properties
        #endregion

        #region Public Interface
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<CLoaiTDModel> GetAllLoaiTuDien()
        {
            var loai_tu_dien = _cache.Get("loaiTuDien");
            if (loai_tu_dien == null)
            {
                UnitOfWork uow = new UnitOfWork();
                var v_result = uow.Repository<CM_DM_TU_DIEN_WEB>().Query().Get().Select(x => x.CopyAs<CLoaiTDModel>());
                _cache.Add("loaiTuDien", v_result);
                return v_result;
            }
            else
            {
                return (IEnumerable<CLoaiTDModel>)loai_tu_dien;
            }
        }

        /// <summary>
        /// Lấy danh sách từ điển theo mã loại từ điển
        /// </summary>
        /// <param name="ip_str_ma_loai_tu_dien"></param>
        /// <returns></returns>
        public IEnumerable<CM_DM_TU_DIEN_WEB> GetTuDienByLoai(string ip_str_ma_loai_tu_dien)
        {
            UnitOfWork uow = new UnitOfWork();
            var v_lst_tu_dien = uow.Repository<CM_DM_TU_DIEN_WEB>()
                .Query().Include(x => x.CM_DM_LOAI_TD_WEB)
                .Filter(x => x.CM_DM_LOAI_TD_WEB.MA_LOAI == ip_str_ma_loai_tu_dien).Get();
            return v_lst_tu_dien;
        }

        /// <summary>
        /// Lấy danh sách từ điển theo id loại từ điển
        /// </summary>
        /// <param name="ip_str_id_loai_tu_dien"></param>
        /// <returns></returns>
        //public IEnumerable<CTuDienModel> GetTuDienByIdLoaiTuDien(Guid ip_str_id_loai_tu_dien)
        //{
        //    var list_tu_dien = _cache.Get(ip_str_id_loai_tu_dien.ToString());
        //    if (list_tu_dien == null)
        //    {
        //        UnitOfWork uow = new UnitOfWork();
        //        var v_lst_tu_dien = uow.Repository<CM_DM_TU_DIEN>()
        //            .Query().Include(x => x.CM_DM_LOAI_TD)
        //            .Filter(x => x.CM_DM_LOAI_TD.ID == ip_str_id_loai_tu_dien).Get().OrderBy(x => x.UU_TIEN).Select(x => x.CopyAs<CTuDienModel>());
        //        _cache.Add(ip_str_id_loai_tu_dien.ToString(), v_lst_tu_dien);
        //        return v_lst_tu_dien;                
        //    }
        //    else
        //    {
        //        return (IEnumerable<CTuDienModel>)list_tu_dien;
        //    }
        //}


        /// <summary>
        /// Lấy từ điển theo id từ điển
        /// </summary>
        /// <param name="ip_id_tu_dien"></param>
        /// <returns></returns>
        public CTuDienModel getTuDienById(Guid ip_id_tu_dien)
        {
            UnitOfWork uow = new UnitOfWork();
            var v_tu_dien = uow.Repository<CM_DM_TU_DIEN_WEB>().Query()
               .Filter(x => x.ID == ip_id_tu_dien).FirstOrDefault();
            return v_tu_dien.CopyAs<CTuDienModel>();
        }

        /// <summary>
        /// Lấy từ điển theo mã từ điển
        /// </summary>
        /// <param name="ip_ma_tu_dien"></param>
        /// <returns></returns>
        public CM_DM_TU_DIEN_WEB GetTuDienByMa(string ip_ma_tu_dien)
        {
            UnitOfWork uow = new UnitOfWork();
            var v_tu_dien = uow.Repository<CM_DM_TU_DIEN_WEB>().Query()
               .Filter(x => x.MA_TU_DIEN == ip_ma_tu_dien).FirstOrDefault();
            return v_tu_dien;
        }

        /// <summary>
        /// Thực hiện các thao tác thêm, sửa, xóa từ điển dựa vào giá trị của v_e_form_mode
        /// </summary>
        /// <param name="ip_tu_dien"></param>
        /// <param name="v_e_form_mode"></param>
        public void SaveData(CTuDienModel ip_tu_dien, DataEntryFormMode v_e_form_mode)
        {
            CM_DM_TU_DIEN_WEB v_cm_dm_tu_dien = ip_tu_dien.CopyAs<CM_DM_TU_DIEN_WEB>();
            switch (v_e_form_mode)
            {
                case DataEntryFormMode.DeleteDataState:
                    Delete(v_cm_dm_tu_dien.ID);
                    break;
                case DataEntryFormMode.InsertDataState:
                    Insert(v_cm_dm_tu_dien);
                    break;
                case DataEntryFormMode.SelectDataState:
                    break;
                case DataEntryFormMode.UpdateDataState:
                    Update(v_cm_dm_tu_dien);
                    break;
                case DataEntryFormMode.ViewDataState:
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region Private Methods
        private void Insert(CM_DM_TU_DIEN_WEB ip_tu_dien)
        {
            try
            {
                UnitOfWork uow = new UnitOfWork();
                uow.Repository<CM_DM_TU_DIEN_WEB>().Insert(ip_tu_dien);
                uow.Save();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void Update(CM_DM_TU_DIEN_WEB ip_tu_dien)
        {
            try
            {
                UnitOfWork uow = new UnitOfWork();
                var v_tu_dien = uow.Repository<CM_DM_TU_DIEN_WEB>().Query().Filter(x => x.ID == ip_tu_dien.ID).FirstOrDefault();
                v_tu_dien.MA_TU_DIEN = ip_tu_dien.MA_TU_DIEN;
                v_tu_dien.TEN_NGAN = ip_tu_dien.TEN_NGAN;
                v_tu_dien.TEN = ip_tu_dien.TEN;
                v_tu_dien.GHI_CHU = ip_tu_dien.GHI_CHU;
                //v_tu_dien.UU_TIEN = ip_tu_dien.UU_TIEN;
                v_tu_dien.State = EDataState.Modified;
                uow.Repository<CM_DM_TU_DIEN_WEB>().Update(v_tu_dien);
                uow.Save();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void Delete(Guid ip_tu_dien)
        {
            try
            {
                UnitOfWork uow = new UnitOfWork();
                uow.Repository<CM_DM_TU_DIEN>().Delete(ip_tu_dien);
                uow.Save();
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
