Imports System.Data.SqlClient

Public Class frmlogin

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click, Label3.Click, Label2.Click

    End Sub

    Private Sub btndangnhap_Click(sender As Object, e As EventArgs) Handles btndangnhap.Click
        Dim chuoiketnoi As String = "workstation id=longltps01468.mssql.somee.com;packet size=4096;user id=longltps01468_SQLLogin_1;pwd=6mj5526ts5;data source=longltps01468.mssql.somee.com;persist security info=False;initial catalog=longltps01468"

        Dim KetNoi As SqlConnection = New SqlConnection(chuoiketnoi)
        Dim sqlAdapter As New SqlDataAdapter("select * from NhanVien where MaNV='" & txtdangnhap.Text & "' and Password='" & txtmatkhau.Text & "' ", KetNoi)
        Dim tb As New DataTable

        Try
            KetNoi.Open()
            sqlAdapter.Fill(tb)
            If tb.Rows.Count > 0 Then
                MessageBox.Show("kết nối với nhân viên thành công")
                frmquanly.Show()
                Me.Hide()
            Else
                MessageBox.Show("Bạn đã nhập sai Tài khoản hoặc mật khẩu")
            End If

        Catch ex As Exception
            KetNoi.Close()
        End Try

    End Sub

    Private Sub btnthoat_Click(sender As Object, e As EventArgs) Handles btnthoat.Click
        Me.Close()

    End Sub
End Class
