///////////////////////////////////////////////////////////////////////////
// Description: Data Access class for the table 'NOP_AND_TRA_TIEN_DAT_COC'
// Generated by LLBLGen v1.21.2003.712 Final on: 17/05/2007, 5:07:32 PM
// Because the Base Class already implements IDispose, this class doesn't.
///////////////////////////////////////////////////////////////////////////
using System;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;

namespace AuctionLLBL
{
	/// <summary>
	/// Purpose: Data Access class for the table 'NOP_AND_TRA_TIEN_DAT_COC'.
	/// </summary>
	public class NOP_AND_TRA_TIEN_DAT_COC : DBInteractionBase
	{
		#region Class Member Declarations
			private SqlDateTime		_cREATE_DATE, _nGAY_NOP, _dELETE_DATE, _mODIFY_DATE;
			private SqlDecimal		_iD_DELETE_BY, _iD_MODIFY_BY, _iD_INVENTOR, _iD, _iD_AUCTION, _iD_CREATE_BY, _sO_TIEN_DAT_COC, _tY_LE_PHI, _sO_LUONG_DANG_KY;
			private SqlString		_dA_TRA_YN, _nOI_DUNG;
		#endregion


		/// <summary>
		/// Purpose: Class constructor.
		/// </summary>
		public NOP_AND_TRA_TIEN_DAT_COC()
		{
			// Nothing for now.
		}


		/// <summary>
		/// Purpose: Insert method. This method will insert one new row into the database.
		/// </summary>
		/// <returns>True if succeeded, otherwise an Exception is thrown. </returns>
		/// <remarks>
		/// Properties needed for this method: 
		/// <UL>
		///		 <LI>ID_AUCTION. May be SqlDecimal.Null</LI>
		///		 <LI>ID_INVENTOR. May be SqlDecimal.Null</LI>
		///		 <LI>SO_LUONG_DANG_KY. May be SqlDecimal.Null</LI>
		///		 <LI>TY_LE_PHI. May be SqlDecimal.Null</LI>
		///		 <LI>SO_TIEN_DAT_COC. May be SqlDecimal.Null</LI>
		///		 <LI>DA_TRA_YN. May be SqlString.Null</LI>
		///		 <LI>NOI_DUNG. May be SqlString.Null</LI>
		///		 <LI>NGAY_NOP. May be SqlDateTime.Null</LI>
		///		 <LI>ID_CREATE_BY. May be SqlDecimal.Null</LI>
		///		 <LI>ID_MODIFY_BY. May be SqlDecimal.Null</LI>
		///		 <LI>ID_DELETE_BY. May be SqlDecimal.Null</LI>
		///		 <LI>CREATE_DATE. May be SqlDateTime.Null</LI>
		///		 <LI>MODIFY_DATE. May be SqlDateTime.Null</LI>
		///		 <LI>DELETE_DATE. May be SqlDateTime.Null</LI>
		/// </UL>
		/// Properties set after a succesful call of this method: 
		/// <UL>
		///		 <LI>ID</LI>
		/// </UL>
		/// </remarks>
		public override bool Insert()
		{
			SqlCommand	cmdToExecute = new SqlCommand();
			cmdToExecute.CommandText = "dbo.[pr_NOP_AND_TRA_TIEN_DAT_COC_Insert]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			cmdToExecute.Connection = _mainConnection;

			try
			{
				cmdToExecute.Parameters.Add(new SqlParameter("@ID_AUCTION", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 1, "", DataRowVersion.Proposed, _iD_AUCTION));
				cmdToExecute.Parameters.Add(new SqlParameter("@ID_INVENTOR", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 1, "", DataRowVersion.Proposed, _iD_INVENTOR));
				cmdToExecute.Parameters.Add(new SqlParameter("@SO_LUONG_DANG_KY", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 1, "", DataRowVersion.Proposed, _sO_LUONG_DANG_KY));
				cmdToExecute.Parameters.Add(new SqlParameter("@TY_LE_PHI", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 1, "", DataRowVersion.Proposed, _tY_LE_PHI));
				cmdToExecute.Parameters.Add(new SqlParameter("@SO_TIEN_DAT_COC", SqlDbType.Decimal, 13, ParameterDirection.Input, false, 21, 3, "", DataRowVersion.Proposed, _sO_TIEN_DAT_COC));
				cmdToExecute.Parameters.Add(new SqlParameter("@DA_TRA_YN", SqlDbType.NVarChar, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _dA_TRA_YN));
				cmdToExecute.Parameters.Add(new SqlParameter("@NOI_DUNG", SqlDbType.NVarChar, 250, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _nOI_DUNG));
				cmdToExecute.Parameters.Add(new SqlParameter("@NGAY_NOP", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 23, 3, "", DataRowVersion.Proposed, _nGAY_NOP));
				cmdToExecute.Parameters.Add(new SqlParameter("@ID_CREATE_BY", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 1, "", DataRowVersion.Proposed, _iD_CREATE_BY));
				cmdToExecute.Parameters.Add(new SqlParameter("@ID_MODIFY_BY", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 1, "", DataRowVersion.Proposed, _iD_MODIFY_BY));
				cmdToExecute.Parameters.Add(new SqlParameter("@ID_DELETE_BY", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 1, "", DataRowVersion.Proposed, _iD_DELETE_BY));
				cmdToExecute.Parameters.Add(new SqlParameter("@CREATE_DATE", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 23, 3, "", DataRowVersion.Proposed, _cREATE_DATE));
				cmdToExecute.Parameters.Add(new SqlParameter("@MODIFY_DATE", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 23, 3, "", DataRowVersion.Proposed, _mODIFY_DATE));
				cmdToExecute.Parameters.Add(new SqlParameter("@DELETE_DATE", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 23, 3, "", DataRowVersion.Proposed, _dELETE_DATE));
				cmdToExecute.Parameters.Add(new SqlParameter("@ID", SqlDbType.Decimal, 9, ParameterDirection.Output, false, 18, 1, "", DataRowVersion.Proposed, _iD));

				if(_mainConnectionIsCreatedLocal)
				{
					// Open connection.
					_mainConnection.Open();
				}
				else
				{
					if(_mainConnectionProvider.IsTransactionPending)
					{
						cmdToExecute.Transaction = _mainConnectionProvider.CurrentTransaction;
					}
				}

				// Execute query.
				_rowsAffected = cmdToExecute.ExecuteNonQuery();
				_iD = (Decimal)cmdToExecute.Parameters["@ID"].Value;
				return true;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("NOP_AND_TRA_TIEN_DAT_COC::Insert::Error occured.", ex);
			}
			finally
			{
				if(_mainConnectionIsCreatedLocal)
				{
					// Close connection.
					_mainConnection.Close();
				}
				cmdToExecute.Dispose();
			}
		}


		/// <summary>
		/// Purpose: Update method. This method will Update one existing row in the database.
		/// </summary>
		/// <returns>True if succeeded, otherwise an Exception is thrown. </returns>
		/// <remarks>
		/// Properties needed for this method: 
		/// <UL>
		///		 <LI>ID</LI>
		///		 <LI>ID_AUCTION. May be SqlDecimal.Null</LI>
		///		 <LI>ID_INVENTOR. May be SqlDecimal.Null</LI>
		///		 <LI>SO_LUONG_DANG_KY. May be SqlDecimal.Null</LI>
		///		 <LI>TY_LE_PHI. May be SqlDecimal.Null</LI>
		///		 <LI>SO_TIEN_DAT_COC. May be SqlDecimal.Null</LI>
		///		 <LI>DA_TRA_YN. May be SqlString.Null</LI>
		///		 <LI>NOI_DUNG. May be SqlString.Null</LI>
		///		 <LI>NGAY_NOP. May be SqlDateTime.Null</LI>
		///		 <LI>ID_CREATE_BY. May be SqlDecimal.Null</LI>
		///		 <LI>ID_MODIFY_BY. May be SqlDecimal.Null</LI>
		///		 <LI>ID_DELETE_BY. May be SqlDecimal.Null</LI>
		///		 <LI>CREATE_DATE. May be SqlDateTime.Null</LI>
		///		 <LI>MODIFY_DATE. May be SqlDateTime.Null</LI>
		///		 <LI>DELETE_DATE. May be SqlDateTime.Null</LI>
		/// </UL>
		/// </remarks>
		public override bool Update()
		{
			SqlCommand	cmdToExecute = new SqlCommand();
			cmdToExecute.CommandText = "dbo.[pr_NOP_AND_TRA_TIEN_DAT_COC_Update]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			cmdToExecute.Connection = _mainConnection;

			try
			{
				cmdToExecute.Parameters.Add(new SqlParameter("@ID", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 1, "", DataRowVersion.Proposed, _iD));
				cmdToExecute.Parameters.Add(new SqlParameter("@ID_AUCTION", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 1, "", DataRowVersion.Proposed, _iD_AUCTION));
				cmdToExecute.Parameters.Add(new SqlParameter("@ID_INVENTOR", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 1, "", DataRowVersion.Proposed, _iD_INVENTOR));
				cmdToExecute.Parameters.Add(new SqlParameter("@SO_LUONG_DANG_KY", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 1, "", DataRowVersion.Proposed, _sO_LUONG_DANG_KY));
				cmdToExecute.Parameters.Add(new SqlParameter("@TY_LE_PHI", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 1, "", DataRowVersion.Proposed, _tY_LE_PHI));
				cmdToExecute.Parameters.Add(new SqlParameter("@SO_TIEN_DAT_COC", SqlDbType.Decimal, 13, ParameterDirection.Input, false, 21, 3, "", DataRowVersion.Proposed, _sO_TIEN_DAT_COC));
				cmdToExecute.Parameters.Add(new SqlParameter("@DA_TRA_YN", SqlDbType.NVarChar, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _dA_TRA_YN));
				cmdToExecute.Parameters.Add(new SqlParameter("@NOI_DUNG", SqlDbType.NVarChar, 250, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _nOI_DUNG));
				cmdToExecute.Parameters.Add(new SqlParameter("@NGAY_NOP", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 23, 3, "", DataRowVersion.Proposed, _nGAY_NOP));
				cmdToExecute.Parameters.Add(new SqlParameter("@ID_CREATE_BY", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 1, "", DataRowVersion.Proposed, _iD_CREATE_BY));
				cmdToExecute.Parameters.Add(new SqlParameter("@ID_MODIFY_BY", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 1, "", DataRowVersion.Proposed, _iD_MODIFY_BY));
				cmdToExecute.Parameters.Add(new SqlParameter("@ID_DELETE_BY", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 1, "", DataRowVersion.Proposed, _iD_DELETE_BY));
				cmdToExecute.Parameters.Add(new SqlParameter("@CREATE_DATE", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 23, 3, "", DataRowVersion.Proposed, _cREATE_DATE));
				cmdToExecute.Parameters.Add(new SqlParameter("@MODIFY_DATE", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 23, 3, "", DataRowVersion.Proposed, _mODIFY_DATE));
				cmdToExecute.Parameters.Add(new SqlParameter("@DELETE_DATE", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 23, 3, "", DataRowVersion.Proposed, _dELETE_DATE));

				if(_mainConnectionIsCreatedLocal)
				{
					// Open connection.
					_mainConnection.Open();
				}
				else
				{
					if(_mainConnectionProvider.IsTransactionPending)
					{
						cmdToExecute.Transaction = _mainConnectionProvider.CurrentTransaction;
					}
				}

				// Execute query.
				_rowsAffected = cmdToExecute.ExecuteNonQuery();
				return true;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("NOP_AND_TRA_TIEN_DAT_COC::Update::Error occured.", ex);
			}
			finally
			{
				if(_mainConnectionIsCreatedLocal)
				{
					// Close connection.
					_mainConnection.Close();
				}
				cmdToExecute.Dispose();
			}
		}


		/// <summary>
		/// Purpose: Delete method. This method will Delete one existing row in the database, based on the Primary Key.
		/// </summary>
		/// <returns>True if succeeded, otherwise an Exception is thrown. </returns>
		/// <remarks>
		/// Properties needed for this method: 
		/// <UL>
		///		 <LI>ID</LI>
		/// </UL>
		/// </remarks>
		public override bool Delete()
		{
			SqlCommand	cmdToExecute = new SqlCommand();
			cmdToExecute.CommandText = "dbo.[pr_NOP_AND_TRA_TIEN_DAT_COC_Delete]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			cmdToExecute.Connection = _mainConnection;

			try
			{
				cmdToExecute.Parameters.Add(new SqlParameter("@ID", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 1, "", DataRowVersion.Proposed, _iD));

				if(_mainConnectionIsCreatedLocal)
				{
					// Open connection.
					_mainConnection.Open();
				}
				else
				{
					if(_mainConnectionProvider.IsTransactionPending)
					{
						cmdToExecute.Transaction = _mainConnectionProvider.CurrentTransaction;
					}
				}

				// Execute query.
				_rowsAffected = cmdToExecute.ExecuteNonQuery();
				return true;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("NOP_AND_TRA_TIEN_DAT_COC::Delete::Error occured.", ex);
			}
			finally
			{
				if(_mainConnectionIsCreatedLocal)
				{
					// Close connection.
					_mainConnection.Close();
				}
				cmdToExecute.Dispose();
			}
		}


		#region Class Property Declarations
		public SqlDecimal ID
		{
			get
			{
				return _iD;
			}
			set
			{
				SqlDecimal iDTmp = (SqlDecimal)value;
				if(iDTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("ID", "ID can't be NULL");
				}
				_iD = value;
			}
		}


		public SqlDecimal ID_AUCTION
		{
			get
			{
				return _iD_AUCTION;
			}
			set
			{
				SqlDecimal iD_AUCTIONTmp = (SqlDecimal)value;
				if(iD_AUCTIONTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("ID_AUCTION", "ID_AUCTION can't be NULL");
				}
				_iD_AUCTION = value;
			}
		}


		public SqlDecimal ID_INVENTOR
		{
			get
			{
				return _iD_INVENTOR;
			}
			set
			{
				SqlDecimal iD_INVENTORTmp = (SqlDecimal)value;
				if(iD_INVENTORTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("ID_INVENTOR", "ID_INVENTOR can't be NULL");
				}
				_iD_INVENTOR = value;
			}
		}


		public SqlDecimal SO_LUONG_DANG_KY
		{
			get
			{
				return _sO_LUONG_DANG_KY;
			}
			set
			{
				SqlDecimal sO_LUONG_DANG_KYTmp = (SqlDecimal)value;
				if(sO_LUONG_DANG_KYTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("SO_LUONG_DANG_KY", "SO_LUONG_DANG_KY can't be NULL");
				}
				_sO_LUONG_DANG_KY = value;
			}
		}


		public SqlDecimal TY_LE_PHI
		{
			get
			{
				return _tY_LE_PHI;
			}
			set
			{
				SqlDecimal tY_LE_PHITmp = (SqlDecimal)value;
				if(tY_LE_PHITmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("TY_LE_PHI", "TY_LE_PHI can't be NULL");
				}
				_tY_LE_PHI = value;
			}
		}


		public SqlDecimal SO_TIEN_DAT_COC
		{
			get
			{
				return _sO_TIEN_DAT_COC;
			}
			set
			{
				SqlDecimal sO_TIEN_DAT_COCTmp = (SqlDecimal)value;
				if(sO_TIEN_DAT_COCTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("SO_TIEN_DAT_COC", "SO_TIEN_DAT_COC can't be NULL");
				}
				_sO_TIEN_DAT_COC = value;
			}
		}


		public SqlString DA_TRA_YN
		{
			get
			{
				return _dA_TRA_YN;
			}
			set
			{
				SqlString dA_TRA_YNTmp = (SqlString)value;
				if(dA_TRA_YNTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("DA_TRA_YN", "DA_TRA_YN can't be NULL");
				}
				_dA_TRA_YN = value;
			}
		}


		public SqlString NOI_DUNG
		{
			get
			{
				return _nOI_DUNG;
			}
			set
			{
				SqlString nOI_DUNGTmp = (SqlString)value;
				if(nOI_DUNGTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("NOI_DUNG", "NOI_DUNG can't be NULL");
				}
				_nOI_DUNG = value;
			}
		}


		public SqlDateTime NGAY_NOP
		{
			get
			{
				return _nGAY_NOP;
			}
			set
			{
				SqlDateTime nGAY_NOPTmp = (SqlDateTime)value;
				if(nGAY_NOPTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("NGAY_NOP", "NGAY_NOP can't be NULL");
				}
				_nGAY_NOP = value;
			}
		}


		public SqlDecimal ID_CREATE_BY
		{
			get
			{
				return _iD_CREATE_BY;
			}
			set
			{
				SqlDecimal iD_CREATE_BYTmp = (SqlDecimal)value;
				if(iD_CREATE_BYTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("ID_CREATE_BY", "ID_CREATE_BY can't be NULL");
				}
				_iD_CREATE_BY = value;
			}
		}


		public SqlDecimal ID_MODIFY_BY
		{
			get
			{
				return _iD_MODIFY_BY;
			}
			set
			{
				SqlDecimal iD_MODIFY_BYTmp = (SqlDecimal)value;
				if(iD_MODIFY_BYTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("ID_MODIFY_BY", "ID_MODIFY_BY can't be NULL");
				}
				_iD_MODIFY_BY = value;
			}
		}


		public SqlDecimal ID_DELETE_BY
		{
			get
			{
				return _iD_DELETE_BY;
			}
			set
			{
				SqlDecimal iD_DELETE_BYTmp = (SqlDecimal)value;
				if(iD_DELETE_BYTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("ID_DELETE_BY", "ID_DELETE_BY can't be NULL");
				}
				_iD_DELETE_BY = value;
			}
		}


		public SqlDateTime CREATE_DATE
		{
			get
			{
				return _cREATE_DATE;
			}
			set
			{
				SqlDateTime cREATE_DATETmp = (SqlDateTime)value;
				if(cREATE_DATETmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("CREATE_DATE", "CREATE_DATE can't be NULL");
				}
				_cREATE_DATE = value;
			}
		}


		public SqlDateTime MODIFY_DATE
		{
			get
			{
				return _mODIFY_DATE;
			}
			set
			{
				SqlDateTime mODIFY_DATETmp = (SqlDateTime)value;
				if(mODIFY_DATETmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("MODIFY_DATE", "MODIFY_DATE can't be NULL");
				}
				_mODIFY_DATE = value;
			}
		}


		public SqlDateTime DELETE_DATE
		{
			get
			{
				return _dELETE_DATE;
			}
			set
			{
				SqlDateTime dELETE_DATETmp = (SqlDateTime)value;
				if(dELETE_DATETmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("DELETE_DATE", "DELETE_DATE can't be NULL");
				}
				_dELETE_DATE = value;
			}
		}
		#endregion
	}
}
