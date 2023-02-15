Imports MySql.Data.MySqlClient
Public Class KK
    Sub Tampil_data()
        On Error Resume Next
        koneksi()
        da = New MySqlDataAdapter("SELECT * FROM kk order by no_kk", con)
        ds = New DataSet
        ds.Clear()
        da.Fill(ds, "kk")
        Me.DataGridView1.DataSource = (ds.Tables("kk"))
    End Sub


    Sub bersih()
        On Error Resume Next
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        ComboBox1.Text = ""
        TextBox4.Text = ""
        ComboBox2.Text = ""
        ComboBox3.Text = ""
        TextBox5.Text = ""
    End Sub

    'Deklarasi Button Simpan
    Sub simpan()
        On Error Resume Next
        'validasi simpan
        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or ComboBox1.Text = "" Or TextBox4.Text = "" Or Format(Me.DateTimePicker1.Value, "yyyy-MM-dd") = "" Or ComboBox2.Text = "" Or ComboBox3.Text = "" Or TextBox5.Text = "" Then
            MsgBox("isi data dengan lengkap")
        Else
            koneksi()
            Dim simpan As String
            MsgBox("data anda akan disimpan")
            simpan = "INSERT INTO kk (no_kk, nama, nik, jk, tmpt_lhr, tgl_lahir, agama, pendidikan, pekerjaan) VALUES('" & TextBox1.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "','" & ComboBox1.Text & "','" & TextBox4.Text & "','" & Format(Me.DateTimePicker1.Value, "yyyy-MM-dd") & "','" & ComboBox2.Text & "','" & ComboBox3.Text & "','" & TextBox5.Text & "')"
            cmd = New MySqlCommand(simpan, con)
            cmd.ExecuteNonQuery()
            bersih()
            Tampil_data()
        End If
    End Sub

    'Deklarasi Button Edit
    Sub edit()
        koneksi()

        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or ComboBox1.Text = "" Or TextBox4.Text = "" Or Format(Me.DateTimePicker1.Value, "yyyy-MM-dd") = "" Or ComboBox2.Text = "" Or ComboBox3.Text = "" Or TextBox5.Text = "" Then
            MsgBox("data tidak ada yang diupdate")
        Else
            MsgBox(" data akan diupdate")
            Dim edit As String

            edit = "UPDATE kk Set no_kk ='" & TextBox1.Text & "',nama =' " & TextBox2.Text & "' , nik = '" & TextBox3.Text & "', jk ='" & ComboBox1.Text & "' , tmpt_lhr = '" & TextBox4.Text & "',tgl_lahir = '" & Format(DateTimePicker1.Value, "yyyy-MM-dd") & "', agama = '" & ComboBox2.Text & "', pendidikan = '" & ComboBox3.Text & "', pekerjaan = '" & TextBox5.Text & "' WHERE no_kk = '" & TextBox1.Text & "'"
            cmd = New MySqlCommand(edit, con)
            cmd.ExecuteNonQuery()
            bersih()
            Tampil_data()
            Button1.Enabled = True
        End If
    End Sub

    'Deklarasi Button Hapus
    Sub hapus()
        On Error Resume Next
        koneksi()
        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or ComboBox1.Text = "" Or TextBox4.Text = "" Or Format(Me.DateTimePicker1.Value, "yyyy-MM-dd") = "" Or ComboBox2.Text = "" Or ComboBox3.Text = "" Or TextBox5.Text = "" Then
            MsgBox("data tidak ada yang dihapus")
            bersih()
        Else

            If MessageBox.Show("Apakah anda yakin ingin menghapus data ?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                Dim hapus As String

                hapus = "DELETE FROM KK WHERE no_kk = '" & TextBox1.Text & "'"
                cmd = New MySqlCommand(hapus, con)
                cmd.ExecuteNonQuery()
                bersih()
                Tampil_data()
            Else
            End If
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        simpan()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        edit()
    End Sub

    Private Sub KK_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Tampil_data()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        hapus()
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Button1.Enabled = False
        Button2.Enabled = True
        TextBox1.Text = DataGridView1.Rows(e.RowIndex).Cells(0).Value
        TextBox2.Text = DataGridView1.Rows(e.RowIndex).Cells(1).Value
        TextBox3.Text = DataGridView1.Rows(e.RowIndex).Cells(2).Value
        ComboBox1.Text = DataGridView1.Rows(e.RowIndex).Cells(3).Value
        TextBox4.Text = DataGridView1.Rows(e.RowIndex).Cells(4).Value
        DateTimePicker1.Value = DataGridView1.Rows(e.RowIndex).Cells(5).Value
        ComboBox2.Text = DataGridView1.Rows(e.RowIndex).Cells(6).Value
        ComboBox3.Text = DataGridView1.Rows(e.RowIndex).Cells(7).Value
        TextBox5.Text = DataGridView1.Rows(e.RowIndex).Cells(8).Value


    End Sub

    Dim con1 As MySqlConnection
    Dim cmd1 As MySqlCommand
    Dim da1 As MySqlDataAdapter
    Dim kk1 As New DataTable
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Cursor = Cursors.WaitCursor
        kk1.Clear()
        Try
            con1 = New MySqlConnection("Server=localhost;user id=root;password=;database= penduduk")
            Dim RPT As New Report2

            cetak()

            RPT.Database.Tables("kk").SetDataSource(kk1)
            Laporan.CrystalReportViewer1.ReportSource = Nothing
            Laporan.CrystalReportViewer1.ReportSource = RPT
            Laporan.ShowDialog()
            RPT.Clone()
            RPT.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Sub cetak()
        cmd1 = New MySqlCommand("select * from kk", con1)
        da1 = New MySqlDataAdapter(cmd1)
        da1.Fill(kk1)

        con1.Close()
        con1.Dispose()
    End Sub

End Class