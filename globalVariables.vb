Imports System.Security.Cryptography
Imports System.Configuration
Imports System.Text
Imports System.Text.RegularExpressions

Public Class globalVariables
    Public Shared Property Postannounce As String = Nothing
    Public Shared Property cmbx As ComboBox


    ' Machine IPAdress
    Public Shared Property Ipaddress As String
    Public Shared Sub ipadd()

        Try

            'Declare new collection
            Dim IpCollection As New Collection
            'Retrieve IP address entries
            'To get a www address
            Dim i As Integer

            Dim ipE As Net.IPHostEntry = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName())
            Dim IpA() As Net.IPAddress = ipE.AddressList
            For i = 0 To IpA.GetUpperBound(0)
                'Add all to list
                IpCollection.Add(IpA(i).ToString)
            Next
            'Select the right address-
            Dim expr As String = "^\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}$"
            Dim reg As Regex = New Regex(expr)
            For Each item In IpCollection
                If (reg.IsMatch(item)) Then
                    Ipaddress = item.ToString()
                    Exit For
                Else

                End If
            Next
        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try
    End Sub

    Public Shared Function MonthDifference(ByVal first As DateTime, ByVal second As DateTime) As Integer
        Return Math.Abs((first.Month - second.Month) + 12 * (first.Year - second.Year))
    End Function
    Public Shared Function GenerateHash(ByVal SourceText As String) As String
        Dim Ue As New UnicodeEncoding()
        Dim ByteSourceText() As Byte = Ue.GetBytes(SourceText)
        Dim Md5 As New MD5CryptoServiceProvider()
        Dim ByteHash() As Byte = Md5.ComputeHash(ByteSourceText)
        Return Convert.ToBase64String(ByteHash)
    End Function
    'Public Shared Property connectionstring As String = "Data Source=192.168.1.23,1433;AttachDbFilename=C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\dbSIMS_Core.mdf; Database=dbSIMSm;User ID = sa;Password=123;multipleactiveresultsets=True"

    'Public Shared Property connectionstring As String = "Data Source=192.168.1.23,1433; Network Library = DBMSSOCN; Initial Catalog=dbSIMS;User ID = sa;Password=123;multipleactiveresultsets=True"
    'Public Shared Property connection As New SqlConnection(connectionstring)
    Public Shared Property msgResult As Integer
    'Public Shared Property PathName As String = "C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\dbSIMS_Core.mdf"

End Class

