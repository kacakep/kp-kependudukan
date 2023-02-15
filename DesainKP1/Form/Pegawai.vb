Imports MySql.Data.MySqlClient
Public Class Pegawai
    Sub Tampil_data()
        koneksi()
        da = New MySqlDataAdapter("SELECT * FROM user order by username", con)
        ds = New DataSet
        ds.Clear()
        da.Fill(ds, "user")
        Me.DataGridView1.DataSource = (ds.Tables("user"))
    End Sub

    Sub Bersih()
        TextBox1.Text = ""
        TextBox2.Text = ""
        ComboBox1.Text = ""
        Tampil_data()
    End Sub

    Sub Combobox()
        Call koneksi()
        Dim str As String
        str = "select jabatan from user"
        cmd = New MySqlCommand(str, con)
        rd = cmd.ExecuteReader
        If rd.HasRows Then
            Do While rd.Read
                ComboBox1.Items.Add(rd("jabatan"))
            Loop
        Else
        End If
        Bersih()
    End Sub

    'input data ke database
    Sub simpan()
        koneksi()

        If TextBox1.Text = "" Or TextBox2.Text = "" Or ComboBox1.Text = "" Then
            MsgBox("isi data dengan lengkap")
        Else
            Dim simpan As String
            MsgBox("data anda akan disimpan")
            simpan = "INSERT INTO user (username,password,jabatan) VALUES('" & TextBox1.Text & "','" & TextBox2.Text & "','" & ComboBox1.Text & "')"
            cmd = New MySqlCommand(simpan, con)
            cmd.ExecuteNonQuery()
            Bersih()
        End If
        Bersih()
    End Sub

    Sub edit()
        koneksi()

        If TextBox1.Text = "" Or TextBox2.Text = "" Or ComboBox1.Text = "" Then
        Else
            MsgBox(" data akan diupdate")
            Dim edit As String

            edit = "UPDATE user Set username='" & TextBox1.Text & "',password ='" & TextBox2.Text & "',jabatan ='" & ComboBox1.Text & "' WHERE username = '" & TextBox1.Text & "'"
            cmd = New MySqlCommand(edit, con)
            cmd.ExecuteNonQuery()
            Bersih()
            Tampil_data()
            Button1.Enabled = True
        End If
    End Sub

    Sub hapus()

        If TextBox1.Text = "" Or TextBox2.Text = "" Or ComboBox1.Text = "" Then
            MsgBox("data tidak ada yang dihapus")
            Bersih()
        Else

            If MessageBox.Show("Apakah anda yakin ingin menghapus data ?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                Dim hapus As String

                hapus = "DELETE  FROM user WHERE username = '" & Me.TextBox1.Text & "'"
                cmd = New MySqlCommand(hapus, con)
                cmd.ExecuteNonQuery()
                Bersih()
                Tampil_data()
            Else
            End If
        End If
    End Sub

    Private Sub Pegawai_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Combobox()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        simpan()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        edit()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        hapus()
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Button1.Enabled = False
        Button2.Enabled = True
        TextBox1.Text = DataGridView1.Rows(e.RowIndex).Cells(0).Value
        TextBox2.Text = DataGridView1.Rows(e.RowIndex).Cells(1).Value
        ComboBox1.Text = DataGridView1.Rows(e.RowIndex).Cells(2).Value

    End Sub
End Class