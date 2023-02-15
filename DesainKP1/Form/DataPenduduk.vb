Imports MySql.Data.MySqlClient
Public Class DataPenduduk
    Sub Combobox()
        Call koneksi()
        Dim str As String
        str = "select nik from ktp"
        cmd = New MySqlCommand(str, con)
        rd = cmd.ExecuteReader
        If rd.HasRows Then
            Do While rd.Read
                ComboBox4.Items.Add(rd("nik"))
            Loop
        Else
        End If
        Bersih()
    End Sub

    Sub Comboboxnew()
        Call koneksi()
        Dim str As String
        str = "select no_kk from kk"
        cmd = New MySqlCommand(str, con)
        rd = cmd.ExecuteReader
        If rd.HasRows Then
            Do While rd.Read
                ComboBox5.Items.Add(rd("no_kk"))
            Loop
        Else
        End If
        Bersih()
    End Sub

    Sub Comboboxnew1()
        Call koneksi()
        Dim str As String
        str = "select username from user"
        cmd = New MySqlCommand(str, con)
        rd = cmd.ExecuteReader
        If rd.HasRows Then
            Do While rd.Read
                ComboBox6.Items.Add(rd("username"))
            Loop
        Else
        End If
        Bersih()
    End Sub

    Sub Tampil_data()
        koneksi()
        da = New MySqlDataAdapter("SELECT * FROM data_penduduk order by no_kk", con)
        ds = New DataSet
        ds.Clear()
        da.Fill(ds, "data_penduduk")
        Me.DataGridView1.DataSource = (ds.Tables("data_penduduk"))
    End Sub
    Sub Bersih()
        TextBox1.Text = ""
        ComboBox4.Text = ""
        TextBox3.Text = ""
        ComboBox5.Text = ""
        ComboBox1.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        TextBox7.Text = ""
        TextBox8.Text = ""
        ComboBox2.Text = ""
        ComboBox3.Text = ""
        ComboBox6.Text = ""
        Tampil_data()
    End Sub


    'Sub untuk menyimpan
    Sub simpan()
        koneksi()
        If TextBox1.Text = "" Or ComboBox4.Text = "" Or TextBox3.Text = "" Or ComboBox5.Text = "" Or ComboBox1.Text = "" Or Format(DateTimePicker1.Value, "yyyy-MM-dd") = "" Or TextBox5.Text = "" Or TextBox6.Text = "" Or TextBox7.Text = "" Or TextBox8.Text = "" Or ComboBox2.Text = "" Or ComboBox3.Text = "" Or ComboBox6.Text = "" Then
            MsgBox("isi data dengan lengkap")
        Else
            Dim simpan As String
            MsgBox("data anda akan disimpan")
            simpan = "INSERT INTO data_penduduk (id_dpi,nik,nama,no_kk,jk,tgl_lahir,pekerjaan,alamat,rt,rw,agama,pendidikan,username) VALUES('" & TextBox1.Text & "','" & ComboBox4.Text & "','" & TextBox3.Text & "','" & ComboBox5.Text & "','" & ComboBox1.Text & "','" & Format(DateTimePicker1.Value, "yyyy-MM-dd") & "','" & TextBox5.Text & "','" & TextBox6.Text & "','" & TextBox7.Text & "','" & TextBox8.Text & "','" & ComboBox2.Text & "','" & ComboBox3.Text & "','" & ComboBox6.Text & "')"
            cmd = New MySqlCommand(simpan, con)
            cmd.ExecuteNonQuery()
            Bersih()
        End If
        Bersih()
    End Sub

    'Deklarasi Button Edit
    Sub edit()
        koneksi()

        If TextBox1.Text = "" Or ComboBox4.Text = "" Or TextBox3.Text = "" Or ComboBox5.Text = "" Or ComboBox1.Text = "" Or Format(DateTimePicker1.Value, "yyyy-MM-dd") = "" Or TextBox5.Text = "" Or TextBox6.Text = "" Or TextBox7.Text = "" Or TextBox8.Text = "" Or ComboBox2.Text = "" Or ComboBox3.Text = "" Or ComboBox6.Text = "" Then
            MsgBox("data tidak ada yang diupdate")
        Else
            MsgBox(" data akan diupdate")
            Dim edit As String

            edit = "UPDATE data_penduduk Set id_dpi ='" & TextBox1.Text & "',nik ='" & ComboBox4.Text & "',nama ='" & TextBox3.Text & "',no_kk ='" & ComboBox5.Text & "',jk ='" & ComboBox1.Text & "',tgl_lahir ='" & Format(DateTimePicker1.Value, "yyyy-MM-dd") & "',pekerjaan ='" & TextBox5.Text & "',alamat ='" & TextBox6.Text & "',rt ='" & TextBox7.Text & "',rw ='" & TextBox8.Text & "',agama ='" & ComboBox2.Text & "',pendidikan ='" & ComboBox3.Text & "',username ='" & ComboBox6.Text & "'WHERE id_dpi = '" & TextBox1.Text & "'"
            cmd = New MySqlCommand(edit, con)
            cmd.ExecuteNonQuery()
            Bersih()
            Tampil_data()
            Button1.Enabled = True
            Button1.Enabled = True
            TextBox3.Enabled = True
            TextBox6.Enabled = True
            TextBox7.Enabled = True
            TextBox8.Enabled = True
            ComboBox1.Enabled = True
            DateTimePicker1.Enabled = True
            TextBox5.Enabled = True
            ComboBox2.Enabled = True
            ComboBox3.Enabled = True
        End If
    End Sub

    Sub hapus()
        On Error Resume Next

        If TextBox1.Text = "" Or ComboBox4.Text = "" Or TextBox3.Text = "" Or ComboBox5.Text = "" Or ComboBox1.Text = "" Or Format(DateTimePicker1.Value, "yyyy-MM-dd") = "" Or TextBox5.Text = "" Or TextBox6.Text = "" Or TextBox7.Text = "" Or TextBox8.Text = "" Or ComboBox2.Text = "" Or ComboBox3.Text = "" Or ComboBox6.Text = "" Then
            MsgBox("data tidak ada yang dihapus")
            Bersih()
        Else

            If MessageBox.Show("Apakah anda yakin ingin menghapus data ?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                Dim hapus As String

                hapus = "DELETE  FROM data_penduduk WHERE id_dpi = '" & Me.TextBox1.Text & "'"
                cmd = New MySqlCommand(hapus, con)
                cmd.ExecuteNonQuery()
                Bersih()
                Tampil_data()
            Else
            End If
        End If
    End Sub

    Private Sub DataPenduduk_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call koneksi()
        Call Combobox()
        Call Comboboxnew()
        Call Comboboxnew1()
        Call Tampil_data()

        TextBox3.Enabled = False
        TextBox6.Enabled = False
        TextBox7.Enabled = False
        TextBox8.Enabled = False
        ComboBox1.Enabled = False
        DateTimePicker1.Enabled = False
        TextBox5.Enabled = False
        ComboBox2.Enabled = False
        ComboBox3.Enabled = False

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        simpan()
    End Sub

    Private Sub ComboBox4_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox4.SelectedIndexChanged
        koneksi()
        cmd = New MySqlCommand("select * from ktp where nik ='" & ComboBox4.Text & "'", con)
        rd = cmd.ExecuteReader
        rd.Read()
        If rd.HasRows Then
            TextBox3.Text = rd!nama
            TextBox6.Text = rd!alamat
            TextBox7.Text = rd!rt
            TextBox8.Text = rd!rw
        End If
        'TextBox3.Enabled = False
        'TextBox6.Enabled = False
        'TextBox7.Enabled = False
        'TextBox8.Enabled = False
        con.Close()
    End Sub

    Private Sub ComboBox5_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox5.SelectedIndexChanged
        koneksi()
        cmd = New MySqlCommand("select * from kk where no_kk ='" & ComboBox5.Text & "'", con)
        rd = cmd.ExecuteReader
        rd.Read()
        If rd.HasRows Then
            ComboBox1.Text = rd!jk
            DateTimePicker1.Value = rd!tgl_lahir
            TextBox5.Text = rd!pekerjaan
            ComboBox2.Text = rd!agama
            ComboBox3.Text = rd!pendidikan
        End If
        'ComboBox1.Enabled = False
        'DateTimePicker1.Enabled = False
        'TextBox5.Enabled = False
        'ComboBox2.Enabled = False
        'ComboBox3.Enabled = False
        con.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        edit()
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        On Error Resume Next
        Button1.Enabled = False
        Button2.Enabled = True
        TextBox1.Text = DataGridView1.Rows(e.RowIndex).Cells(0).Value
        ComboBox4.Text = DataGridView1.Rows(e.RowIndex).Cells(1).Value
        TextBox3.Text = DataGridView1.Rows(e.RowIndex).Cells(2).Value
        ComboBox5.Text = DataGridView1.Rows(e.RowIndex).Cells(3).Value
        ComboBox1.Text = DataGridView1.Rows(e.RowIndex).Cells(4).Value
        DateTimePicker1.Value = DataGridView1.Rows(e.RowIndex).Cells(5).Value
        TextBox5.Text = DataGridView1.Rows(e.RowIndex).Cells(6).Value
        TextBox6.Text = DataGridView1.Rows(e.RowIndex).Cells(7).Value
        TextBox7.Text = DataGridView1.Rows(e.RowIndex).Cells(8).Value
        TextBox8.Text = DataGridView1.Rows(e.RowIndex).Cells(9).Value
        ComboBox2.Text = DataGridView1.Rows(e.RowIndex).Cells(10).Value
        ComboBox3.Text = DataGridView1.Rows(e.RowIndex).Cells(11).Value
        ComboBox6.Text = DataGridView1.Rows(e.RowIndex).Cells(12).Value
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        hapus()
    End Sub

    Dim con1 As MySqlConnection
    Dim cmd1 As MySqlCommand
    Dim da1 As MySqlDataAdapter
    Dim dp1 As New DataTable

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Cursor = Cursors.WaitCursor
        dp1.Clear()
        Try
            con1 = New MySqlConnection("Server=localhost;user id=root;password=;database= penduduk")
            Dim RPT As New Report3

            cetak()

            RPT.Database.Tables("data_penduduk").SetDataSource(dp1)
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
        cmd1 = New MySqlCommand("select * from data_penduduk", con1)
        da1 = New MySqlDataAdapter(cmd1)
        da1.Fill(dp1)

        con1.Close()
        con1.Dispose()
    End Sub

End Class