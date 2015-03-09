using System;
using System.Data.SqlClient;
using IP.Core.IPCommon;
using IP.Core.IPUserService;
using System.Windows.Forms ;
using System.Data;

using BKI_HRM.DS;
using BKI_HRM.US;


namespace BKI_HRM
{
	/// <summary>
	/// Summary description for CDataBaseProccessing.
	/// </summary>
	public class CDataBaseProccessing {
//		private static bool DatabaseIsExists(string i_str_DBName){
//			string v_str_currentDB = IP.Core.IPBusinessService.CProvider.getDBname();
//			try {
//				IP.Core.IPBusinessService.CProvider.changeDataBase("master");
//				DataTable v_dt = new DataSet();
//				SqlDataAdapter v_sqladapter = new SqlDataAdapter();
//				v_sqladapter.SelectCommand = "select * from sysdatabases where name = '" + i_str_DBName + "'"; 
//				SqlConnection v_connection = IP.Core.IPBusinessService.CProvider.getConnection();
//				SqlCommand v_sqlcommand = new SqlCommand();
//				v_sqlcommand.CommandText =	v_str_CommandText ;
//				v_sqlcommand.CommandType =	 System.Data.CommandType.Text;
//				v_sqlcommand.Connection  = v_connection;
//				v_sqlcommand.Parameters.Add("@name","");
//				v_sqlcommand.Parameters.Add("@a","eFinance2006");
//				v_sqlcommand.Connection.Open();
//				int v_int_result = v_sqlcommand.ExecuteNonQuery();
//				MessageBox.Show(v_sqlcommand.Parameters["@name"].Value.ToString());
//				v_sqlcommand.Connection.Close();
//				IP.Core.IPBusinessService.CProvider.changeDataBase(v_str_currentDB);
//				if (v_int_result > 0) {
//					return true;
//				}
//				else {
//					return false;
//				}
//			} 
//			catch (Exception v_e) {
//				IP.Core.IPBusinessService.CProvider.changeDataBase(v_str_currentDB);
//				throw v_e;
//			}
//		}
//
		public static void CreateDataBase(string i_str_old_db_name, string i_str_new_db_name){
			string v_str_db_current_name;
			v_str_db_current_name = IP.Core.IPBusinessService.CProvider.getDBname();
			try{				
				//string v_str_path = System.Windows.Forms.Application.StartupPath + "\\..\\Database\\";				
				string v_str_path = "c:\\";
				string v_str_convert_file_name_path = v_str_path + v_str_db_current_name + System.DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss");
				// Delete file tạm
				System.IO.FileInfo v_file_info = new System.IO.FileInfo(v_str_convert_file_name_path);
				v_file_info.Delete();
				// Copy Data base
				IP.Core.IPBusinessService.CProvider.changeDataBase("master");
				SqlCommand v_obj_cmd = new SqlCommand();
				v_obj_cmd.CommandType = System.Data.CommandType.Text;
				v_obj_cmd.CommandText = "USE master "					
					+ " BACKUP DATABASE " + i_str_old_db_name + " TO DISK = '" +  v_str_convert_file_name_path + "' " 
					+ " RESTORE FILELISTONLY FROM DISK = '" + v_str_convert_file_name_path + "' "
					+ " RESTORE DATABASE " + i_str_new_db_name + " FROM DISK = '" + v_str_convert_file_name_path + "' "	
			
					+" WITH MOVE 'EFINANCE' TO '" + v_str_path + i_str_new_db_name + ".mdf', "
					+" MOVE 'EFINANCE_log' TO '" + v_str_path + i_str_new_db_name + ".ldf' "  ;
				
				v_obj_cmd.Connection = IP.Core.IPBusinessService.CProvider.getConnection();											
				v_obj_cmd.Connection.Open();
				v_obj_cmd.ExecuteNonQuery();
				v_obj_cmd.Connection.Close();
				IP.Core.IPBusinessService.CProvider.changeDataBase(v_str_db_current_name);
			}
			catch (Exception v_e){
				IP.Core.IPBusinessService.CProvider.changeDataBase(v_str_db_current_name);
				throw v_e;
			}
		}
		
		
		public static void BackupDataBase(){
			try	{
				string v_str_db_current_name = IP.Core.IPBusinessService.CProvider.getDBname();
				SaveFileDialog v_save_file = new SaveFileDialog();
                v_save_file.InitialDirectory = @"\\10.0.0.1\Images";
                v_save_file.RestoreDirectory = true;
				//v_save_file.Filter = "";
				if(v_save_file.ShowDialog()==DialogResult.OK){					
					string v_str_output = v_save_file.FileName ;
					string v_str_db_backup = v_str_db_current_name + System.DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss");				
					SqlCommand v_obj_cmd = new SqlCommand();
					v_obj_cmd.CommandType = System.Data.CommandType.Text;
					v_obj_cmd.CommandText = "USE master ";
					v_obj_cmd.CommandText += "EXEC sp_addumpdevice 'disk' " + "," + "'" + v_str_db_backup +"' " ;
					v_obj_cmd.CommandText += "," + "'" + v_str_output + "' ";
					v_obj_cmd.CommandText += "BACKUP DATABASE " + v_str_db_current_name + " TO " + v_str_db_backup ;						
					v_obj_cmd.Connection = IP.Core.IPBusinessService.CProvider.getConnection();				
					v_obj_cmd.Connection.Open();
					v_obj_cmd.ExecuteNonQuery();
					v_obj_cmd.Connection.Close();
					BaseMessages.MsgBox_Infor("Backup Database thành công!");
				}
			}
			catch (Exception v_e)
			{				
				throw v_e;
			}
		}
		public static void RestoreDataBase(){
			string v_str_db_current_name = IP.Core.IPBusinessService.CProvider.getDBname();
			SqlCommand v_obj_cmd = new SqlCommand();
			try	{				
				OpenFileDialog v_open_file = new OpenFileDialog();	
				v_open_file.Filter = "All file (*.*)|*.*";		
				if(v_open_file.ShowDialog()==DialogResult.OK){					
					string v_str_input = v_open_file.FileName ;			
					IP.Core.IPBusinessService.CProvider.changeDataBase("master");					
					v_obj_cmd.CommandType = System.Data.CommandType.Text;
//					v_obj_cmd.CommandText = "USE master ";
//					v_obj_cmd.CommandText  +=  " RESTORE FILELISTONLY  FROM DISK = " + "'" + v_str_input + "'  ";	
//					v_obj_cmd.CommandText += " RESTORE DATABASE  " +  v_str_db_current_name ;
//					v_obj_cmd.CommandText += "  FROM DISK = " + "'" + v_str_input + "' ";					
					v_obj_cmd.CommandText ="use master ";
					v_obj_cmd.CommandText +="   alter database " + v_str_db_current_name +" set single_user with rollback immediate ";
					v_obj_cmd.CommandText +="  restore database " + v_str_db_current_name ;
					v_obj_cmd.CommandText +="  from disk= '" +v_str_input+"' ";
					v_obj_cmd.CommandText +="  alter database "+v_str_db_current_name+" set multi_user";

					v_obj_cmd.Connection = IP.Core.IPBusinessService.CProvider.getConnection();				
					v_obj_cmd.Connection.Open();
					v_obj_cmd.ExecuteNonQuery();
					v_obj_cmd.Connection.Close();
					BaseMessages.MsgBox_Infor("Restore Database thành công!");
					IP.Core.IPBusinessService.CProvider.changeDataBase(v_str_db_current_name);
				}
			}
			catch (Exception v_e) {		
					v_obj_cmd.Connection.Close();	
				IP.Core.IPBusinessService.CProvider.changeDataBase(v_str_db_current_name);					
				throw v_e;
			}
		}
		
		/*public static void import_result_auction(decimal i_dc_id_auction) {
			string v_str_name_database_fill ="",v_str_name_database_default="";
			v_str_name_database_fill =
				System.Configuration.ConfigurationSettings.AppSettings["FILL_DATABASE"];
			v_str_name_database_default =
				System.Configuration.ConfigurationSettings.AppSettings["INITIAL_DATABASE"];
			DS_BID_CARD v_ds_bid_card = new DS_BID_CARD();
			US_BID_CARD v_us_bid_card = new US_BID_CARD();
			DS_REJECT v_ds_reject = new DS_REJECT();
			US_REJECT v_us_reject = new US_REJECT();
			DS_RESULTSHOW v_ds_result_show = new DS_RESULTSHOW();
			US_RESULTSHOW v_us_result_show = new US_RESULTSHOW();
			DS_REGISTER v_ds_register = new DS_REGISTER();
			US_REGISTER v_us_register = new US_REGISTER();
			US_Object v_us_object = new US_Object();
			try {
				//Hỏi xem có muốn chèn dữ liệu kết quả không ?
				if (BaseMessages.askUser_DataCouldBeDeleted(9) !=
					BaseMessages.IsDataCouldBeDeleted.CouldBeDeleted)  return;
				//Nếu có thì làm như sau :
				//1.Chuyển đổi và chắc chắn thao thác với CSDL mặc	định .
			
				IP.Core.IPBusinessService.CProvider.changeDataBase(v_str_name_database_default);
				
				
				//2.Xoá dữ liệu trong CSDL mặc định trước khi chèn	dữ liêu từ CSDL import kết quả vào .
				
				v_us_bid_card.delete_data_before_import_result(i_dc_id_auction);
				//3.Chuyển đổi sang CSDL import kết quả và lấy thông tin cần thiết.
			
				IP.Core.IPBusinessService.CProvider.changeDataBase(v_str_name_database_fill);
				v_us_bid_card.FillDataset(v_ds_bid_card 
					, "WHERE ID_REGISTER in (select ID from REGISTER WHERE ID_AUCTION="+ i_dc_id_auction + ")");
				v_us_reject.FillDataset(v_ds_reject
					,"WHERE ID_REGISTER in (select ID from REGISTER WHERE ID_AUCTION="+ i_dc_id_auction + ")");
				v_us_result_show.FillDataset(v_ds_result_show ,"WHERE ID_AUCTION =" + i_dc_id_auction);
				v_us_register.FillDataset(v_ds_register,"where ID not in " 
					+" (select ID_REGISTER from bid_card) and ID_AUCTION = " 
					+ i_dc_id_auction );
				
				//4.Trở về CSDL mặc định sau đó import dữ liệu vào:			
				IP.Core.IPBusinessService.CProvider.changeDataBase(v_str_name_database_default);
				//4.0 Open 01 transaction import data
				v_us_object.BeginTransaction();
				v_us_bid_card.UseTransOfUSObject(v_us_object);
				v_us_register.UseTransOfUSObject(v_us_object);
				v_us_reject.UseTransOfUSObject(v_us_object);
				v_us_result_show.UseTransOfUSObject(v_us_object);
				//4.1 Insert vào bảng BID_CARD
				foreach (DataRow v_dr in v_ds_bid_card.BID_CARD.Rows){
					v_us_bid_card.DataRow2Me(v_dr);
					v_us_bid_card.Insert();
				}
				//4.2 Insert vào bảng REJECT
				foreach ( DataRow v_dr in v_ds_reject.REJECT.Rows){
					v_us_reject.DataRow2Me(v_dr);
					v_us_reject.Insert();
				}
				//4.3 Insert vào bảng RESULTSHOW
				foreach ( DataRow v_dr in v_ds_result_show.RESULTSHOW.Rows){
					v_us_result_show.DataRow2Me(v_dr);
					v_us_result_show.Insert();
				}
				//4.4 Update vào bảng RESULTSHOW - VALID_YN = "N";
				foreach ( DataRow v_dr in v_ds_register.REGISTER.Rows){
					v_us_register.DataRow2Me(v_dr);
					v_us_register.strVALID_YN = "N";
					v_us_register.Update();
				}
				v_us_object.CommitTransaction();
				BaseMessages.MsgBox_Infor("Đã cập nhật thành công dữ liệu !");
			}
			catch(Exception v_e) {			
				IP.Core.IPBusinessService.CProvider.changeDataBase(v_str_name_database_default);
				v_us_object.Rollback();
				throw v_e;
			}
		}*/

	}
}