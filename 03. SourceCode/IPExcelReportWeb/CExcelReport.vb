﻿Option Explicit On 
Option Strict On

Imports System.IO
Imports Excel
Imports System.Web.UI.WebControls


Public Class CExcelReport
    Private Const c_ReportTemplatesDir As String = "Reports\Templates\"
    Private Const c_ReportOutputDir As String = "Reports\Output\"

    Protected m_strOutputPath As String = ""
    Protected m_strTemplatesPath As String = ""

    Private m_strTemplateFileNameWithPath As String
    Private m_iSheetStartRow As Integer
    Private m_iSheetStartCol As Integer

    Private m_objExcelApp As Excel.Application
    Private m_objExcelWorksheet As Excel.Worksheet
    Private m_init_successful As Boolean
    Private m_b_haved_show As Boolean
    Private m_b_set_style As Boolean = True

    Public FindAndReplaceCollection As Hashtable

    Public Sub New(ByVal i_strTemplateFileWithoutPath As String _
                            , ByVal i_iSheetStartRow As Integer _
                            , ByVal i_iSheetStartCol As Integer)
        InitPaths()
        m_strTemplateFileNameWithPath = m_strTemplatesPath & i_strTemplateFileWithoutPath
        m_iSheetStartCol = i_iSheetStartCol
        m_iSheetStartRow = i_iSheetStartRow
        m_objExcelApp = New Excel.Application
        FindAndReplaceCollection = New Hashtable
        m_init_successful = False
        m_b_haved_show = False
        init_excel()
    End Sub
    Public Sub New(ByVal i_str_TemplateFilePath As String)
        InitPaths()
        m_strTemplateFileNameWithPath = i_str_TemplateFilePath
        m_init_successful = False
        m_b_haved_show = False
        m_init_successful = True
    End Sub
    Public Sub SetVisibleStyle4Node()
        m_b_set_style = True
    End Sub

    Public Sub SetInvisibleStyle4Node()
        m_b_set_style = False

    End Sub
    Public Function GetOutputFileNameWithPath() As String
        Dim v_strRandomName As String
        Randomize()
        v_strRandomName = m_strOutputPath & "~" & CType(Rnd() * 1000000000000, Int64) & ".xls"
        Return v_strRandomName
    End Function

    '' LinhDH thêm vào để export khi dùng Web
    ''' <summary>
    ''' Dùng để export excel dùng template khi lập trình Web
    ''' </summary>
    ''' <param name="i_fg"></param>
    ''' <param name="i_iFromGridCol"></param>
    ''' <param name="i_iToGridCol"></param>
    ''' <param name="i_b_show"></param>
    ''' <remarks></remarks>
    'Public Sub Export2Excel(ByVal i_fg As GridView _
    '                        , ByVal i_iFromGridCol As Integer _
    '                        , ByVal i_iToGridCol As Integer, Optional ByVal i_b_show As Boolean = True)
    '    Try
    '        If Not m_init_successful Then Exit Sub
    '        Dim v_objFact As New CExportColumnFactory(i_fg, m_objExcelWorksheet)
    '        Dim v_objExpCol As IExportColumn
    '        Dim v_iGridCol As Integer
    '        Dim v_iNumberOfCol As Integer = 0
    '        Dim v_iVisibleColsCount As Integer = 0
    '        Dim v_iCount As Integer = 0
    '        ' Chen 1 so dong trong Excel tuong ung voi so Ban ghi can insert
    '        Dim v_obj_range As Range = m_objExcelWorksheet.Range( _
    '        m_objExcelWorksheet.Cells(m_iSheetStartRow + 2, m_iSheetStartCol) _
    '        , m_objExcelWorksheet.Cells(m_iSheetStartRow + 2, m_iSheetStartCol))
    '        For v_iCount = i_fg.Rows.Fixed To i_fg.Rows.Count - 1
    '            v_obj_range.EntireRow.Insert(Excel.XlDirection.xlUp)
    '        Next
    '        For v_iGridCol = i_iFromGridCol To i_iToGridCol
    '            If i_fg.Cols(v_iGridCol).Visible Then
    '                v_objExpCol = v_objFact.CreateExportColumn(v_iGridCol _
    '                                        , m_iSheetStartCol + v_iNumberOfCol _
    '                                        , m_iSheetStartRow)
    '                v_iNumberOfCol += 1
    '                v_objExpCol.Export()
    '                v_iVisibleColsCount += 1
    '            End If
    '        Next
    '        If (m_b_set_style) Then
    '            setStyle4Node(i_fg, v_iVisibleColsCount)
    '        End If
    '        m_iSheetStartRow = m_iSheetStartRow + i_fg.Rows.Count

    '        If i_b_show Then
    '            m_objExcelApp.Visible = True
    '            Unmount()
    '        End If

    '    Catch v_e As Exception
    '        m_objExcelApp.Workbooks.Close()
    '        m_objExcelApp.Quit()
    '        Unmount()
    '        Throw v_e
    '    End Try
    'End Sub

    Public Sub ChangeSheetExported(ByVal i_sheet_index As Integer)
        m_objExcelApp.Workbooks(1).Worksheets.Select(i_sheet_index)
        m_objExcelWorksheet = CType(m_objExcelApp.Workbooks(1).Worksheets(i_sheet_index), Excel.Worksheet)
    End Sub

    ''' <summary>
    ''' Dùng trong ASP.NET
    ''' </summary>
    ''' <param name="i_fg"></param>
    ''' <param name="i_iFromGridCol"></param>
    ''' <param name="i_iToGridCol"></param>
    ''' <param name="i_b_show"></param>
    ''' <remarks></remarks>
    Public Sub Export2ExcelWithoutFixedRows(ByVal i_fgv As GridView _
                                , ByVal i_iFromGridCol As Integer _
                                , ByVal i_iToGridCol As Integer _
                                , ByVal i_b_show As Boolean)
        Try
            If Not m_init_successful Then Exit Sub
            ''PrepareGrid(i_fgv)
            Dim v_objFact As New CExportColumnFactory(i_fgv, m_objExcelWorksheet)
            Dim v_objExpCol As IExportColumn
            Dim v_iGridCol As Integer
            Dim v_iNumberOfCol As Integer = 0
            Dim v_iVisibleColsCount As Integer = 0
            Dim v_iCount As Integer = 0
            ' Chen 1 so dong trong Excel tuong ung voi so Ban ghi can insert
            Dim v_obj_range As Range = m_objExcelWorksheet.Range( _
            m_objExcelWorksheet.Cells(m_iSheetStartRow + 1, m_iSheetStartCol) _
            , m_objExcelWorksheet.Cells(m_iSheetStartRow + 1, m_iSheetStartCol))
            For v_iCount = 0 To i_fgv.Rows.Count - 1
                v_obj_range.EntireRow.Insert(Excel.XlDirection.xlUp)
            Next
            For v_iGridCol = i_iFromGridCol To i_iToGridCol
                If i_fgv.Columns(v_iGridCol).Visible Then
                    v_objExpCol = v_objFact.CreateExportColumnAsp(v_iGridCol _
                                            , m_iSheetStartCol + v_iNumberOfCol _
                                            , m_iSheetStartRow)
                    v_iNumberOfCol += 1
                    v_objExpCol.ExportWithoutFixedRowsAsp()
                    v_iVisibleColsCount += 1

                End If
            Next
            'If (m_b_set_style) Then
            '    setStyle4Node(i_fg, v_iVisibleColsCount)
            'End If
            m_iSheetStartRow = m_iSheetStartRow + i_fgv.Rows.Count
            If i_b_show Then
                m_objExcelApp.Visible = True
                Unmount()
            End If
        Catch v_e As Exception
            m_objExcelApp.Workbooks.Close()
            m_objExcelApp.Quit()
            Unmount()
            Throw v_e
        End Try

    End Sub

    Public Sub ExportDataSet2ExcelWithoutFixedRows(ByVal i_fgv As GridView _
                                , ByVal i_iFromGridCol As Integer _
                                , ByVal i_iToGridCol As Integer _
                                , ByVal i_b_show As Boolean)
        Try
            If Not m_init_successful Then Exit Sub
            Dim v_objFact As New CExportColumnFactory(i_fgv, m_objExcelWorksheet)
            Dim v_objExpCol As IExportColumn
            Dim v_iGridCol As Integer
            Dim v_iNumberOfCol As Integer = 0
            Dim v_iVisibleColsCount As Integer = 0
            Dim v_iCount As Integer = 0

            ' Chen 1 so dong trong Excel tuong ung voi so Ban ghi can insert
            Dim v_obj_range As Range = m_objExcelWorksheet.Range( _
            m_objExcelWorksheet.Cells(m_iSheetStartRow + 1, m_iSheetStartCol) _
            , m_objExcelWorksheet.Cells(m_iSheetStartRow + 1, m_iSheetStartCol))
            For v_iCount = 0 To i_fgv.Rows.Count - 1
                v_obj_range.EntireRow.Insert(Excel.XlDirection.xlUp)
            Next
            For v_iGridCol = i_iFromGridCol To i_iToGridCol
                If i_fgv.Columns(v_iGridCol).Visible Then
                    v_objExpCol = v_objFact.CreateExportColumnAsp(v_iGridCol _
                                            , m_iSheetStartCol + v_iNumberOfCol _
                                            , m_iSheetStartRow)
                    v_iNumberOfCol += 1
                    v_objExpCol.ExportWithoutFixedRowsAsp()
                    v_iVisibleColsCount += 1

                End If
            Next
            'If (m_b_set_style) Then
            '    setStyle4Node(i_fg, v_iVisibleColsCount)
            'End If
            m_iSheetStartRow = m_iSheetStartRow + i_fgv.Rows.Count
            If i_b_show Then
                m_objExcelApp.Visible = True
                Unmount()
            End If
        Catch v_e As Exception
            m_objExcelApp.Workbooks.Close()
            m_objExcelApp.Quit()
            Unmount()
            Throw v_e
        End Try

    End Sub
    Public Sub GotoExportPosition(ByVal i_iSheetStartRow As Integer _
                            , ByVal i_iSheetCol As Integer)
        m_iSheetStartRow = i_iSheetStartRow
        m_iSheetStartCol = i_iSheetCol
    End Sub
    Public Sub AddFindAndReplaceItem(ByVal i_obj_find As Object _
                                , ByVal i_obj_replace As Object)
        Me.FindAndReplaceCollection.Add(i_obj_find, i_obj_replace)
    End Sub



    Public Sub FindAndReplace(ByVal i_b_show As Boolean)
        Try
            If Not m_init_successful Then Exit Sub
            Dim v_str_replace As String
            For Each v_str_find As String In Me.FindAndReplaceCollection.Keys
                v_str_replace = Me.FindAndReplaceCollection.Item(v_str_find).ToString()
                m_objExcelWorksheet.Cells.Replace(What:=v_str_find, Replacement:=v_str_replace)
                If Not m_b_haved_show Then
                    m_objExcelApp.Visible = True
                    m_b_haved_show = True
                End If
            Next
            If i_b_show Then
                m_objExcelApp.Visible = True
                Unmount()
            End If
        Catch v_e As Exception
            m_objExcelApp.Workbooks.Close()
            m_objExcelApp.Quit()
            Unmount()
            Throw v_e
        End Try
    End Sub

    Private Sub init_excel()
        Dim v_strFileName As String
        v_strFileName = GetOutputFileNameWithPath()
        If Not CopyFileSuccess(v_strFileName) Then Exit Sub
        m_objExcelApp.Workbooks.Open(v_strFileName)
        m_objExcelApp.Workbooks(1).Worksheets.Select(1)
        m_objExcelWorksheet = CType(m_objExcelApp.Workbooks(1).Worksheets(1), Excel.Worksheet)
        m_init_successful = True

    End Sub


    'Tra ve xem co copy thanh cong hay khong
    Private Function CopyFileSuccess(ByVal i_strFileDest As String) As Boolean
        Try
            Dim v_objFileInfo As New FileInfo(m_strTemplateFileNameWithPath)
            Debug.Assert(v_objFileInfo.Exists(), "Khong co file template nay - tuanqt")
            v_objFileInfo.CopyTo(i_strFileDest)
            Return True
        Catch v_e As Exception
            Return False
        End Try
    End Function

    Private Sub InitPaths()
        m_strOutputPath = AppDomain.CurrentDomain.SetupInformation.ApplicationBase & c_ReportOutputDir
        m_strTemplatesPath = AppDomain.CurrentDomain.SetupInformation.ApplicationBase & c_ReportTemplatesDir
    End Sub

    Private Sub Unmount()

        m_objExcelWorksheet = Nothing
        m_objExcelApp = Nothing
        GC.Collect()

    End Sub
End Class
