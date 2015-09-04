
Imports System
Imports DotRas
Module Module1
    Sub Main()
        If Not My.Application.CommandLineArgs.Count = 3 Then
            ShowUsage()
        Else
            Dim VpnName As String = My.Application.CommandLineArgs(0)
            Dim Destination As String = My.Application.CommandLineArgs(1)
            Dim PresharedKey As String = My.Application.CommandLineArgs(2)

            Try
                Dim PhoneBook As New RasPhoneBook
                PhoneBook.Open()
                Dim VpnEntry As RasEntry = RasEntry.CreateVpnEntry(VpnName, Destination, DotRas.RasVpnStrategy.L2tpOnly, _
                                                                   DotRas.RasDevice.Create(VpnName, DotRas.RasDeviceType.Vpn))
                VpnEntry.Options.UsePreSharedKey = True
                VpnEntry.Options.UseLogOnCredentials = True
                PhoneBook.Entries.Add(VpnEntry)
                VpnEntry.UpdateCredentials(RasPreSharedKey.Client, PresharedKey)
                Console.WriteLine("[+] VPN connection created.")
            Catch ex As Exception
                Console.WriteLine("ERROR: " & ex.Message & vbNewLine)
                Environment.Exit(999)
            End Try
        End If
    End Sub

    Private Sub ShowUsage()
        Console.WriteLine("[-] Invalid Arguments." & vbNewLine & vbNewLine & _
                          "Usage: pskvpn.exe ""VPN_Name"" IP/Host L2TP_PSK" & vbNewLine)
    End Sub

End Module
