Imports MySql.Data.MySqlClient
Public Class KTP

    Sub Combobox()
        Call koneksi()

        Dim str As String
        str = "select no_kk from kk"
        cmd = New MySqlCommand(str, con)
        rd = cmd.ExecuteReader
        If rd.HasRows Then
            Do While rd.Read
                ComboBox4.Items.Add(rd("no_kk"))
            Loop
        Else
        End If
    End Sub

    Sub bersih()
        TextBox1.Text = ""
        TextBox2.Text = ""
        ComboBox1.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        ComboBox2.Text = ""
        ComboBox3.Text = ""
    End Sub
    Sub Tampil_data()
        On Error Resume Next
        koneksi()
        da = New MySqlDataAdapter("SELECT * FROM ktp order by nik", con)
        ds = New DataSet
        ds.Clear()
        da.Fill(ds, "ktp")
        Me.DataGridView1.DataSource = (ds.Tables("ktp"))
    End Sub

    Sub simpan()
        On Error Resume Next
        'validasi simpan
        If TextBox1.Text = "" Or TextBox2.Text = "" Or Format(DateTimePicker1.Value, "yyyy-MM-dd") = "" Or ComboBox1.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Or TextBox5.Text = "" Or ComboBox2.Text = "" Or ComboBox3.Text = "" Then
            MsgBox("isi data dengan lengkap")
        Else
            koneksi()
            Dim simpan As String
            MsgBox("data anda akan disimpan")
            simpan = "INSERT INTO ktp (nik,nama,tgl_lahir,jk,alamat,rt,rw,agama,stat_kawin) VALUES('" & TextBox1.Text & "','" & TextBox2.Text & "', '" & Format(DateTimePicker1.Value, "yyyy-MM-dd") & "','" & ComboBox1.Text & "','" & TextBox3.Text & "','" & TextBox4.Text & "','" & TextBox5.Text & "','" & ComboBox2.Text & "','" & ComboBox3.Text & "')"
            cmd = New MySqlCommand(simpan, con)
            cmd.ExecuteNonQuery()
            bersih()
            Tampil_data()
        End If
    End Sub

    Sub edit()
        koneksi()
        'edit
        On Error Resume Next

        If TextBox1.Text = "" Or TextBox2.Text = "" Or Format(DateTimePicker1.Value, "yyyy-MM-dd") = "" Or TextBox3.Text = "" Or ComboBox1.Text = "" Or TextBox4.Text = "" Or TextBox5.Text = "" Or ComboBox2.Text = "" Or ComboBox3.Text = "" Then
            MsgBox("Data tidak ada yang diupdate")
        Else
            MsgBox(" Data akan diupdate")
            Dim edit As String

            edit = "UPDATE ktp SET nik = '" & TextBox1.Text & "', nama = '" & TextBox2.Text & "', tgl_lahir = '" & Format(DateTimePicker1.Value, "yyyy-MM-dd") & "', Jk = '" & ComboBox1.Text & "' ,alamat = '" & TextBox3.Text & "',rt ='" & TextBox4.Text & "',rw ='" & TextBox5.Text & "',agama ='" & ComboBox2.Text & "',stat_kawin ='" & ComboBox3.Text & "'WHERE nik = '" & TextBox1.Text & "'"
            cmd = New MySqlCommand(edit, con)
            cmd.ExecuteNonQuery()
            bersih()
            Tampil_data()
            Button1.Enabled = True
        End If
    End Sub

    Sub hapus()
        On Error Resume Next

        If TextBox1.Text = "" Or TextBox2.Text = "" Or Format(DateTimePicker1.Value, "yyyy-MM-dd") = "" Or ComboBox1.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Or TextBox5.Text = "" Or ComboBox2.Text = "" Or ComboBox3.Text = "" Then
            MsgBox("data tidak ada yang dihapus")
            bersih()
        Else

            If MessageBox.Show("Apakah anda yakin ingin menghapus data ?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                Dim hapus As String

                hapus = "DELETE  FROM ktp WHERE nik = '" & Me.TextBox1.Text & "'"
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

    Private Sub KTP_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Tampil_data()
        koneksi()
        Combobox()
        TextBox1.Enabled = False
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        On Error Resume Next
        Button1.Enabled = False
        Button2.Enabled = True
        TextBox1.Text = DataGridView1.Rows(e.RowIndex).Cells(0).Value
        TextBox2.Text = DataGridView1.Rows(e.RowIndex).Cells(1).Value
        DateTimePicker1.Value = DataGridView1.Rows(e.RowIndex).Cells(2).Value
        ComboBox1.Text = DataGridView1.Rows(e.RowIndex).Cells(3).Value
        TextBox3.Text = DataGridView1.Rows(e.RowIndex).Cells(4).Value
        TextBox4.Text = DataGridView1.Rows(e.RowIndex).Cells(5).Value
        TextBox5.Text = DataGridView1.Rows(e.RowIndex).Cells(6).Value
        ComboBox2.Text = DataGridView1.Rows(e.RowIndex).Cells(7).Value
        ComboBox3.Text = DataGridView1.Rows(e.RowIndex).Cells(8).Value

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        hapus()
    End Sub

    Private Sub ComboBox4_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox4.SelectedIndexChanged
        koneksi()
        cmd = New MySqlCommand("select * from kk where no_kk ='" & ComboBox4.Text & "'", con)
        rd = cmd.ExecuteReader
        rd.Read()
        If rd.HasRows Then
            TextBox1.Text = rd!no_kk
        End If
    End Sub

    'cetak
    Dim con1 As MySqlConnection
    Dim cmd1 As MySqlCommand
    Dim da1 As MySqlDataAdapter
    Dim ktp1 As New DataTable
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Cursor = Cursors.WaitCursor
        ktp1.Clear()
        Try
            con1 = New MySqlConnection("Server=localhost;user id=root;password=;database= penduduk")
            Dim RPT As New Report1

            cetak()

            RPT.Database.Tables("ktp").SetDataSource(ktp1)
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
        cmd1 = New MySqlCommand("select * from ktp", con1)
        da1 = New MySqlDataAdapter(cmd1)
        da1.Fill(ktp1)

        con1.Close()
        con1.Dispose()
    End Sub
End Class