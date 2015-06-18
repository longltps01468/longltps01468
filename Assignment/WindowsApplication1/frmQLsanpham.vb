Imports System.Data.SqlClient
Imports System.Data.DataTable
Public Class frmQLsanpham
    Dim database As New DataTable
    Dim chuoiketnoi As String = "workstation id=longltps01468.mssql.somee.com;packet size=4096;user id=longltps01468_SQLLogin_1;pwd=6mj5526ts5;data source=longltps01468.mssql.somee.com;persist security info=False;initial catalog=longltps01468"
    Dim connect As SqlConnection = New SqlConnection(chuoiketnoi)
    Private Sub frmQLsanpham_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim connect As SqlConnection = New SqlConnection(chuoiketnoi)
        Dim load As SqlDataAdapter = New SqlDataAdapter("select * from SanPham", connect)
        connect.Open()
        load.Fill(database)
        DataGridView1.DataSource = database.DefaultView
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Dim index As Integer = DataGridView1.CurrentCell.RowIndex
        txtmasp.Text = DataGridView1.Item(0, index).Value
        txttensp.Text = DataGridView1.Item(1, index).Value
        txtngaysx.Text = DataGridView1.Item(2, index).Value
        txtdongia.Text = DataGridView1.Item(3, index).Value
    End Sub

    Private Sub btnthem_Click(sender As Object, e As EventArgs) Handles btnthem.Click
        Dim connect As SqlConnection = New SqlConnection(chuoiketnoi)
        connect.Open()
        Dim them As String = "insert into SanPham values (@MaSP,@TenSP,@NgaySX,@Dongia)"
        Dim Executethem As New SqlCommand(them, connect)
        Try
            Executethem.Parameters.AddWithValue("@MaSP", txtmasp.Text)
            Executethem.Parameters.AddWithValue("@TenSP", txttensp.Text)
            Executethem.Parameters.AddWithValue("@NgaySX", txtngaysx.Text)
            Executethem.Parameters.AddWithValue("@Dongia", txtdongia.Text)
            Executethem.ExecuteNonQuery()
            connect.Close()

            MessageBox.Show("Thêm sản phẩm thành công")
        Catch ex As Exception
            MessageBox.Show("Thêm thất bại")
        End Try
        Dim again As SqlDataAdapter = New SqlDataAdapter("select * from SanPham", connect)
        database.Clear()

        again.Fill(database)
        DataGridView1.DataSource = database.DefaultView
    End Sub

    Private Sub btnsua_Click(sender As Object, e As EventArgs) Handles btnsua.Click
        Dim connect As SqlConnection = New SqlConnection(chuoiketnoi)
        connect.Open()
        Dim sua As String = "update SanPham set TenSP = @TenSP, NgaySX = @NgaySX, Dongia = @Dongia where MaSP=@MaSP"
        Dim Executesua As New SqlCommand(sua, connect)
        Try
            Executesua.Parameters.AddWithValue("@MaSP", txtmasp.Text)
            Executesua.Parameters.AddWithValue("@TenSP", txttensp.Text)
            Executesua.Parameters.AddWithValue("@NgaySX", txtngaysx.Text)
            Executesua.Parameters.AddWithValue("@Dongia", txtdongia.Text)
            Executesua.ExecuteNonQuery()
            connect.Close()

            MessageBox.Show("sửa thành công")

        Catch ex As Exception
            MessageBox.Show("sửa không thành công")

        End Try

        'database.Clear()
        'DataGridView1.DataSource = database
        'DataGridView1.DataSource = Nothing
        'LoadData()
        ' load lại dư liệu vô dataGridview
        Dim again As SqlDataAdapter = New SqlDataAdapter("select * from SanPham", connect)
        database.Clear()
        again.Fill(database)
        DataGridView1.DataSource = database.DefaultView


    End Sub

    Private Sub btnxoa_Click(sender As Object, e As EventArgs) Handles btnxoa.Click
        Dim connect As SqlConnection = New SqlConnection(chuoiketnoi)
        connect.Open()
        Dim xoa As String = "delete from SanPham where MaSP = @MaSP"
        Dim Executexoa As New SqlCommand(xoa, connect)
        Try
            Executexoa.Parameters.AddWithValue("@MaSP", txtmasp.Text)
            Executexoa.ExecuteNonQuery()
            connect.Close()

            MessageBox.Show("Xóa thành công")
        Catch ex As Exception
            MessageBox.Show("Xóa không thành công")
        End Try
        ' load lại dư liệu vô dataGridview
        Dim again As SqlDataAdapter = New SqlDataAdapter("select * from SanPham", connect)
        database.Clear()
        again.Fill(database)
        DataGridView1.DataSource = database.DefaultView
    End Sub

    Private Sub btnsearch_Click(sender As Object, e As EventArgs) Handles btnsearch.Click

    End Sub

    Private Sub btnclear_Click(sender As Object, e As EventArgs) Handles btnclear.Click
        txtdongia.Clear()
        txtmasp.Clear()
        txtngaysx.Clear()
        txttensp.Clear()
    End Sub

    Private Sub btnthoat_Click(sender As Object, e As EventArgs) Handles btnthoat.Click
        frmquanly.Show()
        Me.Hide()
    End Sub
End Class