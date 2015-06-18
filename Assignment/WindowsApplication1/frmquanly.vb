Public Class frmquanly

    Private Sub ThoátToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ThoátToolStripMenuItem.Click
        frmlogin.Show()
        Me.Close()
    End Sub

    Private Sub SảnPhẩmToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SảnPhẩmToolStripMenuItem.Click
        frmQLsanpham.Show()
    End Sub

    Private Sub TàiKhoảnToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TàiKhoảnToolStripMenuItem.Click
        frmQLnhanvien.Show()
    End Sub

    Private Sub frmquanly_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub KháchHàngToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles KháchHàngToolStripMenuItem.Click
        frmQLkhachhang.Show()
    End Sub

    Private Sub LoạiSảnPhẩmToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LoạiSảnPhẩmToolStripMenuItem.Click

    End Sub

    Private Sub ThôngTinSảnPhẩmToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ThôngTinSảnPhẩmToolStripMenuItem.Click
        frmthongtin.Show()

    End Sub

    Private Sub NhânToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NhânToolStripMenuItem.Click
        frmthongtintaikhoan.Show()
    End Sub
End Class