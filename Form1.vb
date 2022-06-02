Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnCreateNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCreateNew.Click
        Dim report As New Report
        Dim table As New TableObject
        report.Load("report.frx")
        table = report.FindObject("Table1")
        If table IsNot Nothing Then

            For i As Integer = 0 To 4
                For j As Integer = 0 To 4
                    table(j, i).Text = (5 * i + j + 1).ToString()
                Next j
            Next i
            If report.Prepare() Then
                report.ShowPrepared()
            End If

        Else
            MessageBox.Show("Table1 not found in a report!")
        End If

    End Sub

    Private Sub btnRunExisting_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRunExisting.Click
        Dim report As New Report
        Dim page As New ReportPage
        page.Name = "Page1"
        report.Pages.Add(page)
        Dim DataBand As New DataBand
        DataBand.Name = "DataBand"
        page.Bands.Add(DataBand)
        Dim Table As New TableObject
        Table.Name = "Table1"
        Table.RowCount = 10
        Table.ColumnCount = 10
        For i As Integer = 0 To 9
            For j As Integer = 0 To 9
                Table(j, i).Text = (10 * i + j + 1).ToString()
                Table(j, i).Border.Lines = BorderLines.All
            Next
        Next
        DataBand.Objects.Add(Table)
        If (report.Prepare()) Then
            report.ShowPrepared()
        End If
    End Sub
End Class
