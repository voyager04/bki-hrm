Option Explicit On 
Option Strict On
Imports IP.Core.IPUserService
Public Class CLoginInformation_302
#Region "Nhiệm vụ của Class"
    '************************************************
    '* Chứa thông tin đăng nhập - dùng cho form login (f102)
    '*
    '************************************************
#End Region

    Public m_us_user As US_HT_NGUOI_SU_DUNG
    ' Public m_us_phap_nhan As US_DM_PHAP_NHAN
    'Public m_strMaPhanHe As String
    Public m_dc_id_Phapnhan As Decimal
    Public Sub New(ByVal i_us_user As US_HT_NGUOI_SU_DUNG, ByVal dc_id_phap_nhan As Decimal)
        MyBase.New()
        m_us_user = i_us_user
        m_dc_id_Phapnhan = dc_id_phap_nhan

        ' m_strMaPhanHe = i_strMaPhanHe
    End Sub

End Class


