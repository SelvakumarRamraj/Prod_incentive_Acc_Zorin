Imports System.Data
Imports System.Data.SqlClient
Imports CarlosAg.ExcelXmlWriter
Imports System.IO
Public Class FrmpieceRateRep
    Dim msql As String
    Private Sub FrmpieceRateRep_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Height = MDIFORM1.Height
        Me.Width = My.Computer.Screen.Bounds.Width
        Dg.Width = My.Computer.Screen.Bounds.Width - 20

    End Sub
    Private Sub loaddata()
        ' msql = "DECLARE @FromDate DATE='" & Format(CDate(mskdatefr.Text), "yyyy-MM-dd") & "'
        '         DECLARE @ToDate   DATE='" & Format(CDate(Mskdateto.Text), "yyyy-MM-dd") & "'
        '         DECLARE @cols NVARCHAR(MAX)=''
        '         DECLARE @sql  NVARCHAR(MAX)=''
        '     ;WITH M AS
        '     (SELECT DISTINCT  LEFT(DATENAME(MONTH,
        '         CASE WHEN MONTH(cdate)=1 AND DAY(cdate)>=29  THEN DATEFROMPARTS(YEAR(cdate),2,1)
        '   WHEN MONTH(cdate)=2 AND DAY(cdate)<=26 THEN DATEFROMPARTS(YEAR(cdate),2,1)
        'WHEN MONTH(cdate)=2 AND DAY(cdate)>=27 THEN DATEFROMPARTS(YEAR(cdate),3,1)
        'WHEN MONTH(cdate) IN (3,4,5,6,7,8,9,10,11,12) AND DAY(cdate)>=29 THEN DATEADD(MONTH,1,DATEFROMPARTS(YEAR(cdate),MONTH(cdate),1))
        'ELSE DATEFROMPARTS(YEAR(cdate),MONTH(cdate),1) END),3) Mth
        '     FROM prodcost.dbo.dailycontractdata  WHERE cdate BETWEEN @FromDate AND @ToDate
        '     )
        '     SELECT @cols=@cols+'
        '     ISNULL(SUM(CASE WHEN Mth='''+Mth+''' THEN Qty END),0) ['+Mth+' Qty],
        '     ISNULL(AVG(CASE WHEN Mth='''+Mth+''' THEN Rate END),0) ['+Mth+' Rate],
        '     ISNULL(SUM(CASE WHEN Mth='''+Mth+''' THEN Amount END),0) ['+Mth+' Amount],'
        '     FROM M ORDER BY Mth
        '     SET @cols=LEFT(@cols,LEN(@cols)-1)
        '     SET @sql='
        '     WITH D AS
        '         (SELECT nempno,vname, cdepartment, LEFT(DATENAME(MONTH,SalaryMonth),3) Mth, SUM(qty) Qty, AVG(rate) Rate,SUM(amt) Amount FROM  (
        '         SELECT *,CASE WHEN MONTH(cdate)=1 AND DAY(cdate)>=29 THEN DATEFROMPARTS(YEAR(cdate),2,1)
        '   WHEN MONTH(cdate)=2 AND DAY(cdate)<=26 THEN DATEFROMPARTS(YEAR(cdate),2,1)
        '   WHEN MONTH(cdate)=2 AND DAY(cdate)>=27 THEN DATEFROMPARTS(YEAR(cdate),3,1)
        '   WHEN MONTH(cdate) IN (3,4,5,6,7,8,9,10,11,12)   AND DAY(cdate)>=29 THEN DATEADD(MONTH,1,DATEFROMPARTS(YEAR(cdate),MONTH(cdate),1))
        '   ELSE DATEFROMPARTS(YEAR(cdate),MONTH(cdate),1)  END SalaryMonth  FROM prodcost.dbo.dailycontractdata
        '         WHERE cdate BETWEEN '''+CONVERT(VARCHAR,@FromDate,23)+''' AND '''+CONVERT(VARCHAR,@ToDate,23)+''') X
        '         GROUP BY nempno, vname, cdepartment, LEFT(DATENAME(MONTH,SalaryMonth),3))

        '     SELECT  cdepartment, CASE WHEN GROUPING(nempno)=1 THEN ''TOTAL'' ELSE CAST(nempno AS VARCHAR(20)) END nempno,
        '     CASE WHEN GROUPING(vname)=1 THEN '''' ELSE vname END vname,
        '     '+@cols+' FROM D
        '     GROUP BY GROUPING SETS
        '     ((cdepartment,nempno,vname),
        '     (cdepartment)
        '     )
        '     ORDER BY cdepartment, GROUPING(nempno), nempno'
        ' EXEC(@sql)"


        'new
        msql = "DECLARE @FromDate DATE='" & Format(CDate(mskdatefr.Text), "yyyy-MM-dd") & "'
                DECLARE @ToDate   DATE='" & Format(CDate(Mskdateto.Text), "yyyy-MM-dd") & "'
                DECLARE @cols NVARCHAR(MAX)=''
                DECLARE @sql  NVARCHAR(MAX)=''
            ;WITH M AS
                (SELECT DISTINCT LEFT(DATENAME(MONTH,CASE WHEN MONTH(cdate)=1 AND DAY(cdate)>=29 THEN DATEFROMPARTS(YEAR(cdate),2,1)
                WHEN MONTH(cdate)=2 AND DAY(cdate)<=26 THEN DATEFROMPARTS(YEAR(cdate),2,1)
                WHEN MONTH(cdate)=2 AND DAY(cdate)>=27 THEN DATEFROMPARTS(YEAR(cdate),3,1)
                WHEN MONTH(cdate) IN (3,4,5,6,7,8,9,10,11,12) AND DAY(cdate)>=29
                    THEN DATEADD(MONTH,1,DATEFROMPARTS(YEAR(cdate),MONTH(cdate),1))
                ELSE DATEFROMPARTS(YEAR(cdate),MONTH(cdate),1) END),3) AS Mth  FROM prodcost.dbo.dailycontractdata
                WHERE cdate BETWEEN @FromDate AND @ToDate
            )
            SELECT @cols =STUFF((SELECT ',
                ISNULL(SUM(CASE WHEN Mth='''+Mth+''' THEN Qty END),0) ['+Mth+'Qty],
                ISNULL(AVG(CASE WHEN Mth='''+Mth+''' THEN Rate END),0) ['+Mth+'Rate],
                ISNULL(SUM(CASE WHEN Mth='''+Mth+''' THEN Amount END),0) ['+Mth+'Amt]'
                FROM M
                ORDER BY
                    CASE Mth 
                    WHEN 'Mar' THEN 1
                    WHEN 'Apr' THEN 2
                    WHEN 'May' THEN 3
                    WHEN 'Jun' THEN 4
                    WHEN 'Jul' THEN 5
                    WHEN 'Aug' THEN 6
                    WHEN 'Sep' THEN 7
                    WHEN 'Oct' THEN 8
                    WHEN 'Nov' THEN 9
                    WHEN 'Dec' THEN 10
                    WHEN 'Jan' THEN 11
                    WHEN 'Feb' THEN 12
                    END
                FOR XML PATH(''), TYPE ).value('.','nvarchar(max)'),1,1,'')

            SET @sql='
                WITH D AS
                    (SELECT  nempno, vname, cdepartment, LEFT(DATENAME(MONTH,SalaryMonth),3) Mth,  SUM(qty) Qty, AVG(rate) Rate, SUM(amt) Amount FROM
                    ( SELECT *, CASE WHEN MONTH(cdate)=1 AND DAY(cdate)>=29 THEN DATEFROMPARTS(YEAR(cdate),2,1)
                        WHEN MONTH(cdate)=2 AND DAY(cdate)<=26 THEN DATEFROMPARTS(YEAR(cdate),2,1)
                        WHEN MONTH(cdate)=2 AND DAY(cdate)>=27 THEN DATEFROMPARTS(YEAR(cdate),3,1)
                        WHEN MONTH(cdate) IN (3,4,5,6,7,8,9,10,11,12) AND DAY(cdate)>=29
                        THEN DATEADD(MONTH,1,DATEFROMPARTS(YEAR(cdate),MONTH(cdate),1))
                        ELSE DATEFROMPARTS(YEAR(cdate),MONTH(cdate),1) END SalaryMonth
                    FROM prodcost.dbo.dailycontractdata
                    WHERE cdate BETWEEN '''  + CONVERT(VARCHAR,@FromDate,23) +   ''' AND '''   + CONVERT(VARCHAR,@ToDate,23) +  ''' ) X
            GROUP BY  nempno, vname, cdepartment,LEFT(DATENAME(MONTH,SalaryMonth),3))

        SELECT cdepartment, CASE WHEN GROUPING(nempno)=1  THEN ''TOTAL''    ELSE CAST(nempno AS VARCHAR(20))  END nempno,
            CASE WHEN GROUPING(vname)=1   THEN ''''  ELSE vname END vname,
        '+ @cols + ' FROM D
        GROUP BY GROUPING SETS
            (
            (cdepartment,nempno,vname),
            (cdepartment)
           )
        ORDER BY  cdepartment,
         GROUPING(nempno),
        nempno'
EXEC(@sql)"


        Cursor = Cursors.WaitCursor
        Dg.DataSource = Nothing
        Dim dt As DataTable = getDataTable(msql)
        If dt.Rows.Count > 0 Then








            Dim dtNew As DataTable = dt.Copy()

            For i As Integer = dt.Rows.Count - 1 To 0 Step -1
                If dt.Rows(i)("nempno").ToString.Trim.ToUpper = "TOTAL" Then
                    dtNew.Rows.InsertAt(dtNew.NewRow(), i + 1)
                End If
            Next

            Dg.DataSource = dtNew

            For Each col As DataGridViewColumn In Dg.Columns
                If col.Name.ToUpper.Contains("QTY") Then
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    col.DefaultCellStyle.Format = "0"     '1,250
                End If
            Next

            'Rate columns - Decimal
            For Each col As DataGridViewColumn In Dg.Columns
                If col.Name.ToUpper.Contains("RATE") Then
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    col.DefaultCellStyle.Format = "N2"     '12.50
                End If
            Next

            'Amount columns - Decimal
            For Each col As DataGridViewColumn In Dg.Columns
                If col.Name.ToUpper.Contains("AMOUNT") Then
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    col.DefaultCellStyle.Format = "N2"     '1,250.75
                End If
            Next


            'Format TOTAL rows
            For Each dgRow As DataGridViewRow In Dg.Rows

                If dgRow.Cells("nempno").Value IsNot Nothing Then

                    If dgRow.Cells("nempno").Value.ToString.Trim.ToUpper = "TOTAL" Then

                        dgRow.DefaultCellStyle.BackColor = Color.Navy
                        dgRow.DefaultCellStyle.ForeColor = Color.White
                        dgRow.DefaultCellStyle.Font = New Font(Dg.Font, FontStyle.Bold)

                    End If

                End If

            Next



            'Dg.DataSource = dt
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub btnexit_Click(sender As Object, e As EventArgs) Handles btnexit.Click
        Me.Close()
    End Sub

    Private Sub btndisp_Click(sender As Object, e As EventArgs) Handles btndisp.Click
        If Chkday.Checked = True Then
            Call loaddaydata()
        Else
            Call loaddata()
        End If

    End Sub

    Private Sub Dg_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Dg.CellContentClick

    End Sub
    Private Sub loaddaydata()
        Dim sql As String = "declare @d1 as nvarchar(20)
                declare @d2 as nvarchar(20)
                set @d1='" & Format(CDate(mskdatefr.Text), "yyyy-MM-dd") & "'
                set @d2='" & Format(CDate(Mskdateto.Text), "yyyy-MM-dd") & "'
                ;WITH CTE AS
                (
                    SELECT  k.cdate, k.nempno, k.vname, k.cdepartment, k.qty, k.rate, k.Amt, k.WorkingHours, k.totqty,
                    RIGHT('0' + CAST(k.AllocMinutes / 60 AS VARCHAR(2)), 2)
                    + ':' +
                    RIGHT('0' + CAST(k.AllocMinutes % 60 AS VARCHAR(2)), 2) AS ProcessWorkingHours FROM
                ( SELECT b.cdate,b.nempno,b.vname,b.cdepartment,
                    SUM(CAST(b.qty AS DECIMAL(18,2))) AS qty, AVG(CAST(b.rate AS DECIMAL(18,4))) AS rate, SUM(CAST(b.amt AS DECIMAL(18,2))) AS Amt,
                    d.WorkingHours, d.TotalMinutes, SUM(SUM(CAST(b.qty AS DECIMAL(18,2)))) OVER(PARTITION BY b.cdate, b.nempno) AS totqty,
                CAST (ROUND (
                    (  CAST(d.TotalMinutes AS DECIMAL(18,4))
                    * SUM(CAST(b.qty AS DECIMAL(18,2)))
                    )
                    /
                    NULLIF
                    ( SUM(SUM(CAST(b.qty AS DECIMAL(18,2))))
                    OVER(PARTITION BY b.cdate, b.nempno),
                    0
                    ),
                     0
                    )   AS INT
                    ) AS AllocMinutes  FROM prodcost.dbo.dailycontractdata b with (nolock)
            INNER JOIN
                (  SELECT a.AttendanceDate, a.EmpNo,  e.PunchNo,DATEDIFF(MINUTE, a.InTime, a.OutTime) AS TotalMinutes,
			    RIGHT('0' + CAST(DATEDIFF(MINUTE, a.InTime, a.OutTime) / 60 AS VARCHAR(2)), 2)
                + ':' +
                RIGHT('0' + CAST(DATEDIFF(MINUTE, a.InTime, a.OutTime) % 60 AS VARCHAR(2)), 2)  AS WorkingHours
                FROM ehr.dbo.Attendance a with (nolock)
                INNER JOIN ehr.dbo.EmployeeDetails e with (nolock)  ON e.EmpNo = a.EmpNo
                WHERE a.AttendanceDate BETWEEN @d1 AND @d2) d
                ON d.PunchNo = b.nempno AND d.AttendanceDate = b.cdate
                WHERE b.cdate BETWEEN @d1 AND @d2
                GROUP BY b.cdate, b.nempno, b.vname, b.cdepartment, d.WorkingHours, d.TotalMinutes) k
                )
            select k.cdate,k.nempno, k.vname, k.cdepartment Process, convert(int,k.qty) Qty, cast(k.rate as decimal(10,2)) Rate, cast(k.Amt as decimal(15,2)) Amt,k.ProcessWorkingHours Wrkhours from (
            SELECT cdate,nempno, vname, cdepartment, qty, rate,  Amt, WorkingHours, isnull(totqty,0) totqty, ProcessWorkingHours, 1 AS SortOrder FROM CTE
            UNION ALL
            SELECT cdate, 0, 'TOTAL', cdepartment,  SUM(qty),  AVG(rate),  SUM(Amt),  '00:00', 0,  '00:00', 2 FROM CTE GROUP BY cdate,cdepartment
            UNION ALL
            SELECT cdate,  0,  'DATE TOTAL', '', SUM(qty), AVG(rate), SUM(Amt), '00:00',  0,  '00:00',  3 FROM CTE GROUP BY cdate ) k
            ORDER BY k.cdate,k.cdepartment, k.SortOrder, k.nempno;"

        Cursor = Cursors.WaitCursor
        Dg.DataSource = Nothing
        Dim dt As DataTable = getDataTable(sql)
        If dt.Rows.Count > 0 Then

            Dim dtNew As DataTable = dt.Copy()

            For i As Integer = dt.Rows.Count - 1 To 0 Step -1
                If dt.Rows(i)("vname").ToString.Trim.ToUpper = "TOTAL" Then
                    dtNew.Rows.InsertAt(dtNew.NewRow(), i + 1)
                End If
            Next

            Dg.DataSource = dtNew

            For Each col As DataGridViewColumn In Dg.Columns
                If col.Name.ToUpper.Contains("QTY") Then
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    col.DefaultCellStyle.Format = "0"     '1,250
                End If
            Next

            'Rate columns - Decimal
            For Each col As DataGridViewColumn In Dg.Columns
                If col.Name.ToUpper.Contains("RATE") Then
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    col.DefaultCellStyle.Format = "0.00"     '12.50
                End If
            Next

            'Amount columns - Decimal
            For Each col As DataGridViewColumn In Dg.Columns
                If col.Name.ToUpper.Contains("AMT") Then
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    col.DefaultCellStyle.Format = "0.00"     '1,250.75
                End If
            Next


            'Format TOTAL rows
            For Each dgRow As DataGridViewRow In Dg.Rows

                If dgRow.Cells("vname").Value IsNot Nothing Then

                    If dgRow.Cells("vname").Value.ToString.Trim.ToUpper = "TOTAL" Then
                        dgRow.DefaultCellStyle.BackColor = Color.Navy
                        dgRow.DefaultCellStyle.ForeColor = Color.White
                        dgRow.DefaultCellStyle.Font = New Font(Dg.Font, FontStyle.Bold)

                    End If

                    If dgRow.Cells("vname").Value.ToString.Trim.ToUpper = "DATE TOTAL" Then
                        dgRow.DefaultCellStyle.BackColor = Color.DarkOliveGreen
                        dgRow.DefaultCellStyle.ForeColor = Color.White
                        dgRow.DefaultCellStyle.Font = New Font(Dg.Font, FontStyle.Bold)

                    End If


                End If

            Next



            'Dg.DataSource = dt
        End If
        Cursor = Cursors.Default


    End Sub


    Private Sub btnxl_Click(sender As Object, e As EventArgs) Handles btnxl.Click
        'gridexcelexport(Dg, 1)
        'ngridexcelexportngridexcelexport()
        If Chkday.Checked = True Then
            gridexcelexport5(Dg, 1, "PcsrateTalior", "Piece Rate Tailors Processwise Production Report from " & Format(CDate(mskdatefr.Text), "dd-MM-yyyy") & " To " & Format(CDate(Mskdateto.Text), "dd-MM-yyyy"))
        Else
            gridexcelexport4(Dg, 1, "PcsrateTalior", "Piece Rate Tailors Processwise Production Report from " & Format(CDate(mskdatefr.Text), "dd-MM-yyyy") & " To " & Format(CDate(Mskdateto.Text), "dd-MM-yyyy"))
        End If

    End Sub
End Class