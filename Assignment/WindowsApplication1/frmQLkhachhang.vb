Imports System.Data.SqlClient
Imports System.Data.DataTable
Public Class frmQLkhachhang
    Dim database As New DataTable
    Dim chuoiketnoi As String = "workstation id=longltps01468.mssql.somee.com;packet size=4096;user id=longltps01468_SQLLogin_1;pwd=6mj5526ts5;data source=longltps01468.mssql.somee.com;persist security info=False;initial catalog=longltps01468"
    Dim connect As SqlConnection = New SqlConnection(chuoiketnoi)
    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub frmQLkhachhang_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim connect As SqlConnection = New SqlConnection(chuoiketnoi)
        Dim load As SqlDataAdapter = New SqlDataAdapter("select * from KhachHang", connect)
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
        txtsdt.Text = DataGridView1.Item(4, index).Value
    End Sub

    Private Sub btnthem_Click(sender As Object, e As EventArgs) Handles btnthem.Click
        Dim connect As SqlConnection = New SqlConnection(chuoiketnoi)
        connect.Open()

        'Dim them As String = "insert into Khachhang values ('" & txtmasp.Text & "','" & txttensp.Text & "','" & txtngaysx.Text & "','" & txtdongia.Text & "','" & txtsdt.Text & "')"
        Dim them As String = "insert into Khachhang values (@MaKH,@TenKH,@Mail,@Diachi,@sdt)"
        Dim Executethem As New SqlCommand(them, connect)
        Try
            Executethem.Parameters.AddWithValue("@MaKH", txtmasp.Text)
            Executethem.Parameters.AddWithValue("@TenKH", txttensp.Text)
            Executethem.Parameters.AddWithValue("@Mail", txtngaysx.Text)
            Executethem.Parameters.AddWithValue("@Diachi", txtdongia.Text)
            Executethem.Parameters.AddWithValue("@sdt", txtsdt.Text)
            Executethem.ExecuteNonQuery()
            connect.Close()

            MessageBox.Show("Thêm thành công dữ liệu")
        Catch ex As Exception
            MessageBox.Show("Thêm Thất bại!")
        End Try
        Dim again As SqlDataAdapter = New SqlDataAdapter("select * from Khachhang", connect)
        database.Clear()

        again.Fill(database)
        DataGridView1.DataSource = database.DefaultView
    End Sub

    Private Sub btnsua_Click(sender As Object, e As EventArgs) Handles btnsua.Click
        Dim connect As SqlConnection = New SqlConnection(chuoiketnoi)
        connect.Open()
        Dim sua As String = "update Khachhang set TenKH = @TenKH, Mail = @Mail, Diachi = @Diachi, SDT = @sdt where MaHK=@MaKH"
        Dim Executesua As New SqlCommand(sua, connect)
        Try
            Executesua.Parameters.AddWithValue("@MaKH", txtmasp.Text)
            Executesua.Parameters.AddWithValue("@TenKH", txttensp.Text)
            Executesua.Parameters.AddWithValue("@Mail", txtngaysx.Text)
            Executesua.Parameters.AddWithValue("@Diachi", txtdongia.Text)
            Executesua.Parameters.AddWithValue("@sdt", txtsdt.Text)
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
        Dim again As SqlDataAdapter = New SqlDataAdapter("select * from Khachhang", connect)
        database.Clear()
        again.Fill(database)
        DataGridView1.DataSource = database.DefaultView
    End Sub

    Private Sub btnxoa_Click(sender As Object, e As EventArgs) Handles btnxoa.Click
        Dim connect As SqlConnection = New SqlConnection(chuoiketnoi)
        connect.Open()
        Dim xoa As String = "delete from Khachhang where MaHK = @MaKH"
        Dim Executexoa As New SqlCommand(xoa, connect)
        Try
            Executexoa.Parameters.AddWithValue("@MaKH", txtmasp.Text)
            Executexoa.ExecuteNonQuery()
            connect.Close()

            MessageBox.Show("Xóa Thành Công")
        Catch ex As Exception
            MessageBox.Show("Xóa không thành công")
        End Try
        ' load lại dư liệu vô dataGridview
        Dim again As SqlDataAdapter = New SqlDataAdapter("select * from Khachhang", connect)
        database.Clear()
        again.Fill(database)
        DataGridView1.DataSource = database.DefaultView
    End Sub

    Private Sub btnclear_Click(sender As Object, e As EventArgs) Handles btnclear.Click
        txtdongia.Clear()
        txtmasp.Clear()
        txtngaysx.Clear()
        txttensp.Clear()
        txtsdt.Clear()

    End Sub

    Private Sub btnthoat_Click(sender As Object, e As EventArgs) Handles btnthoat.Click
        frmquanly.Show()
        Me.Hide()

    End Sub
End Class