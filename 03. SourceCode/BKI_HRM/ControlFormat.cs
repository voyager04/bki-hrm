using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using IP.Core.IPCommon;
using IP.Core.IPException;
using IP.Core.IPData;
using IP.Core.IPUserService;
using IP.Core.IPSystemAdmin;
using BKI_HRM.US;

namespace BKI_HRM
{
    public class ControlFormat
    {
        private static void set_control_visible(Control v_c, String str_findControl, bool TU_visible, bool TE_visible, bool TEG_visible)
        {
            int i_id_phap_nhan = (int)CAppContext_201.getCurrentIDPhapnhan();
            if (v_c.Name == str_findControl)
            {
                switch (i_id_phap_nhan)
                {
                    case (int)PHAP_NHAN.TU:
                        v_c.Visible = TU_visible;

                        break;
                    case (int)PHAP_NHAN.TE:
                        v_c.Visible = TE_visible;
                        break;
                    case (int)PHAP_NHAN.TEG:
                        v_c.Visible = TEG_visible;
                        break;

                    default:
                        break;

                }
            }
            else
            {
                foreach (Control subC in v_c.Controls)
                {
                    set_control_visible(subC, str_findControl, TU_visible, TE_visible, TEG_visible);
                }
            }

        }
        public static void setFormat_theo_phap_nhan(Form ip_f)
        {
            int i_id_phap_nhan = (int)CAppContext_201.getCurrentIDPhapnhan();
            switch (ip_f.Name)
            {
                case "f002_main_form":
                    #region "f400_Main"
                    foreach (Control v_c in ip_f.Controls)
                    {
                        // item cua menu strip chua lam duoc
//                         set_control_visible(v_c, "m_menuitem_hopdong", true, true, false);
//                         set_control_visible(v_c, "m_menuitem_bao_cao_hop_dong", true, true, false);
                        set_control_visible(v_c, "panel5", false, false, true);
                        set_control_visible(v_c, "panel4", true, true, false);
                        set_control_visible(v_c, "panel3", true, true, false);

                    }
                    #endregion
                    break;
                case "f201_dm_nhan_su":
                    #region "f201_dm_nhan_su"
                    foreach (Control v_c in ip_f.Controls)
                    {
                        set_control_visible(v_c, "m_cmd_insert", false, false, true);
                        set_control_visible(v_c, "m_cmd_update", false, false, true);
                        set_control_visible(v_c, "m_cmd_delete", false, false, true);
                        set_control_visible(v_c, "m_cmd_chon_phap_nhan", false, false, true);
                        set_control_visible(v_c, "panel5", false, false, false);
                    }
                    #endregion
                    break;
                default:
                    break;
            }



        }
    }
}
