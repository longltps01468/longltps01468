Imports System.Data.SqlClient
Imports System.Data.DataTable
Public Class frmthongtintaikhoan
    Dim database As New DataTable
    Dim chuoiketnoi As String = "workstation id=longltps01468.mssql.somee.com;packet size=4096;user id=longltps01468_SQLLogin_1;pwd=6mj5526ts5;data source=longltps01468.mssql.somee.com;persist security info=False;initial catalog=longltps01468"
    Dim connect As SqlConnection = New SqlConnection(chuoiketnoi)
    Private Sub frmthongtintaikhoan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim connect As SqlConnection = New SqlConnection(chuoiketnoi)
        Dim load As SqlDataAdapter = New SqlDataAdapter("select MaNV,Password from NhanVien ", connect)
        connect.Open()
        load.Fill(database)
        DataGridView1.DataSource = database.DefaultView
    End Sub
End Class