Imports System.Console
Imports System.IO
Module Module1

    Sub Main()
        Dim jabatan As String
        Dim statusPegawai As String
        Dim gajiGol As Integer
        Dim tunjanganistri As Integer
        Dim tunjangananak As Integer
        Dim gajiBruto As Integer
        Dim koperasi As Integer
        Dim biayaJabatan As Integer
        Dim danaPensiun As Integer
        Dim gajiNetto As Integer
        Dim nama As String
        Dim golongan As Integer
        Dim jk As String
        Dim kawin As String
        Dim jmlAnak As Integer
        Dim gajiPokok As Integer

        WriteLine("----------------------------")
        Write(" SLIP GAJI : ")
        nama = ReadLine()
        WriteLine("----------------------------")
        WriteLine()

        Dim ulang1 As Boolean
        ulang1 = True

        Do While ulang1 = True
            Write("Golongan :  ")
            golongan = ReadLine()

            If golongan > 3 Or golongan < 1 Then
                WriteLine()
                WriteLine("Golongan salah")
            Else
                ulang1 = False
            End If
        Loop

        Dim ulang2 As Boolean
        ulang2 = True

        Do While ulang2 = True
            WriteLine()
            Write("Jabatan : ")
            jabatan = UCase(ReadLine())

            If jabatan <> "KEPALA" And jabatan <> "MANAGER" And jabatan <> "UMUM" Then
                WriteLine()
                WriteLine("Jabatan salah")
            Else
                ulang2 = False
            End If
        Loop

        Dim ulang3 As Boolean
        ulang3 = True

        Do While ulang3 = True
            WriteLine()
            Write("Status Kepegawaian : ")
            statusPegawai = UCase(ReadLine())

            If statusPegawai <> "TETAP" And statusPegawai <> "HONORER" Then
                WriteLine()
                WriteLine("Salah")
            Else
                ulang3 = False
            End If
        Loop

        Dim ulang4 As Boolean
        ulang4 = True

        Do While ulang4 = True
            WriteLine()
            Write("Jenis Kelamin P/L : ")
            jk = UCase(ReadLine())

            If jk <> "P" And jk <> "L" Then
                WriteLine()
                WriteLine(" Salah")
            Else
                ulang4 = False
            End If
        Loop

        Dim ulang5 As Boolean
        ulang5 = True

        Do While ulang5 = True
            WriteLine()
            Write("Status Kawin : ")
            kawin = UCase(ReadLine())

            jmlAnak = 0
            If kawin = "KAWIN" Then
                Write(" jumlah anak : ")
                jmlAnak = jmlAnak + ReadLine()

                WriteLine("Status kawin anda : " & kawin)
                WriteLine("Jumlah anak anda : " & jmlAnak)
                ulang5 = False
            ElseIf kawin = "BELUM" Then
                WriteLine("Status kawin anda : " & kawin)
                ulang5 = False
            Else
                WriteLine()
                WriteLine("Error")
            End If
        Loop


        'Gaji pokok
        If golongan = 1 Then
            gajiGol = 1500000
        ElseIf golongan = 2 Then
            gajiGol = 2500000
        ElseIf golongan = 3 Then
            gajiGol = 3500000
        End If
        gajiPokok = gajiGol

        'Tunjangan istri
        tunjanganistri = 0
        If jk = "L" And kawin = "KAWIN" Then
            If golongan = 1 Then
                tunjanganistri = 0.01 * gajiPokok
            ElseIf golongan = 2 Then
                tunjanganistri = 0.03 * gajiPokok
            ElseIf golongan = 3 Then
                tunjanganistri = 0.05 * gajiPokok
            End If
        End If

        'Tunjangan anak
        If kawin = "KAWIN" And jmlAnak > 0 Then
            tunjangananak = 0.01 * gajiPokok
            If jmlAnak <= 2 Then
                tunjangananak = tunjangananak * jmlAnak
            Else
                tunjangananak = tunjangananak * 2
            End If
        End If

        'Gaji bruto
        gajiBruto = gajiPokok + tunjangananak + tunjanganistri

        'Potongan koperasi
        If statusPegawai = "TETAP" Then
            koperasi = 5000
        Else
            koperasi = 0
        End If

        'Biaya jabatan
        If jabatan = "KEPALA" Then
            biayaJabatan = biayaJabatan + (0.005 * gajiPokok)
        ElseIf jabatan = "MANAGER" Then
            biayaJabatan = biayaJabatan + (0.003 * gajiPokok)
        End If

        'Dana pensiun
        If jabatan = "KEPALA" And statusPegawai = "TETAP" Then
            danaPensiun = danaPensiun + (0.005 * gajiPokok)
        ElseIf jabatan = "MANAGER" And statusPegawai = "TETAP" Then
            danaPensiun = danaPensiun + (0.003 * gajiPokok)
        End If

        'Gaji netto
        gajiNetto = gajiBruto - (koperasi + biayaJabatan + danaPensiun)

        Clear()
        WriteLine()
        WriteLine("----------------------------")
        WriteLine("     SLIP GAJI: " & nama)
        WriteLine("----------------------------")
        WriteLine("1. Golongan          : " & golongan)
        WriteLine("2. Jabatan           : " & jabatan)
        WriteLine("3. Status Pegawai    : " & statusPegawai)
        WriteLine("4. Jenis Kelamin     : " & jk)
        WriteLine("5. Status Kawin      : " & kawin)
        WriteLine("6. Jumlah Anak       : " & jmlAnak)
        WriteLine("7. Gaji Pokok        : Rp  " & FormatNumber(Convert.ToInt32(gajiPokok)), 0, TriState.True, 0)
        WriteLine("8. Tunjangan Istri   : Rp  " & FormatNumber(Convert.ToInt32(tunjanganistri)), 0, TriState.True, 0)
        WriteLine("9. Tunjangan Anak    : Rp  " & FormatNumber(Convert.ToInt32(tunjangananak)), 0, TriState.True, 0)
        WriteLine("        Gaji Bruto   : Rp  " & FormatNumber(Convert.ToInt32(gajiBruto)), 0, TriState.True, 0)
        WriteLine("10. Potongan Koperasi: Rp  " & FormatNumber(Convert.ToInt32(koperasi)), 0, TriState.True, 0)
        WriteLine("11. Biaya Jabatan    : Rp  " & FormatNumber(Convert.ToInt32(biayaJabatan)), 0, TriState.True, 0)
        WriteLine("12. Dana Pensiun     : Rp  " & FormatNumber(Convert.ToInt32(danaPensiun)), 0, TriState.True, 0)
        WriteLine("        Gaji Netto   : Rp  " & FormatNumber(Convert.ToInt32(gajiNetto)), 0, TriState.True, 0)
        WriteLine("----------------------------")
        WriteLine()

        Dim mydate As String = DateTime.Now.ToString("dd'-'MM'-'yyyy-HH-mm-ss")
        Dim filename As String

        filename = "Slip Gaji " & nama & " " & mydate & ".txt"

        Dim myWriter As StreamWriter

        myWriter = My.Computer.FileSystem.OpenTextFileWriter("D:\" & filename, True)

        myWriter.WriteLine("----------------------------")
        myWriter.WriteLine("     SLIP GAJI: " & nama)
        myWriter.WriteLine("----------------------------")
        myWriter.WriteLine("1. Golongan          : " & golongan)
        myWriter.WriteLine("2. Jabatan           : " & jabatan)
        myWriter.WriteLine("3. Status Pegawai    : " & statusPegawai)
        myWriter.WriteLine("4. Jenis Kelamin     : " & jk)
        myWriter.WriteLine("5. Status Kawin      : " & kawin)
        myWriter.WriteLine("6. Jumlah Anak       : " & jmlAnak)
        myWriter.WriteLine("7. Gaji Pokok        : Rp " & FormatNumber(Convert.ToInt32(gajiPokok)), 0, TriState.True, 0)
        myWriter.WriteLine("8. Tunjangan Istri   : Rp  " & FormatNumber(Convert.ToInt32(tunjanganistri)), 0, TriState.True, 0)
        myWriter.WriteLine("9. Tunjangan Anak    : Rp  " & FormatNumber(Convert.ToInt32(tunjangananak)), 0, TriState.True, 0)
        myWriter.WriteLine("        Gaji Bruto   : Rp  " & FormatNumber(Convert.ToInt32(gajiBruto)), 0, TriState.True, 0)
        myWriter.WriteLine("10. Potongan Koperasi: Rp  " & FormatNumber(Convert.ToInt32(koperasi)), 0, TriState.True, 0)
        myWriter.WriteLine("11. Biaya Jabatan    : Rp  " & FormatNumber(Convert.ToInt32(biayaJabatan)), 0, TriState.True, 0)
        myWriter.WriteLine("12. Dana Pensiun     : Rp  " & FormatNumber(Convert.ToInt32(danaPensiun)), 0, TriState.True, 0)
        myWriter.WriteLine("        Gaji Netto   : Rp  " & FormatNumber(Convert.ToInt32(gajiNetto)), 0, TriState.True, 0)
        myWriter.WriteLine("----------------------------")
        myWriter.WriteLine()
        myWriter.Close()
    End Sub

End Module
