Imports flash.modVAR
Public Class frmMAIN
    Dim cc As String
    Dim WithEvents wb As WebBrowser

    Dim alertBlocker As String = "window.onerror = function(msg, url, line) { return true; };" & _
            "setOverlayHTMLdung = function emptyMethod() { };" & _
            "setBannerHTML = function() { };" & _
            "removeBannerHTML = function() { };" & _
            "removeOverlayHTML = function() { };" & _
            "removeFooterHTML = function() { };" & _
            "setInterval = function(v1,v2) {return 0; };" & _
            "clearInterval = function(v1) { };" & _
            "setBannerHTML = function(banner_html) { };" & _
            "setOverlayHTMLdung = function() { };" & _
            "setFooterHTML = function() { };" & _
            "countDown = function() { };" & _
            "createElement = function() { };" & _
            "writeln = function() { };" & _
            "setTimeout = function(v1,v2) { };" & _
            "TestPage = function() { };"

    Private Sub OpenChan(chan As String, Optional Name As String = "")
        cc = chan
        Try
            Me.wb.Dispose()
            Me.wb = Nothing
        Catch ex As Exception
            Err.Clear()
        End Try
        wb = New WebBrowser

        With wb
            .Parent = Me
            .Top = 0
            .Left = 0
            .Height = 500
            .Width = 650
            .AllowNavigation = False
            .AllowWebBrowserDrop = False
            .WebBrowserShortcutsEnabled = False
            .ScriptErrorsSuppressed = True
            .ScrollBarsEnabled = False
            .IsWebBrowserContextMenuEnabled = False
        End With


        If chan = "" Then
            MsgBox("Canal Ainda não disponivel")
            Me.Text = "TV Online - miguelferreira.net"
            Exit Sub
        End If

        If Name <> "" Then
            Me.Text = "A Ver " & Name
        Else
            Me.Text = "TV Online - miguelferreira.net DEMO!"
        End If
        wb.Navigate(chan, "_self", Nothing, Headers)
    End Sub


    Private Sub wb_Navigated(sender As Object, e As System.Windows.Forms.WebBrowserNavigatedEventArgs) Handles wb.Navigated
        On Error Resume Next
        Debug.Print("OK: " & e.Url.ToString)
        

        Dim ObjArr(2) As Object
        ObjArr(0) = CObj(New String(alertBlocker))
        ObjArr(1) = CObj(New String("JavaScript"))
        wb.Document.InvokeScript("execScript", ObjArr)
        Call wb_Navigating(sender, Nothing)
    End Sub


    Private Sub wb_Navigating(sender As Object, e As System.Windows.Forms.WebBrowserNavigatingEventArgs) Handles wb.Navigating
        On Error Resume Next

        Dim ObjArr(2) As Object
        ObjArr(0) = CObj(New String(alertBlocker))
        ObjArr(1) = CObj(New String("JavaScript"))
        wb.Document.InvokeScript("execScript", ObjArr)

        Me.wb.Document.GetElementById("video_ads_overdiv").OuterText = ""
        Me.wb.Document.GetElementById("video_ads_overdiv").OuterHtml = ""

        Me.wb.Document.GetElementById("ad_overlay").Style = "visibility:hidden;"
        Me.wb.Document.GetElementById("ad_overlay_countdown").Style = "visibility:hidden;"
        Me.wb.Document.GetElementById("ad_overlay_content").Style = "visibility:hidden;"
        Me.wb.Document.GetElementById("ad_footer").Style = "visibility:hidden;"
        Me.wb.Document.GetElementById("ad_footer_content").Style = "visibility:hidden;"
        Me.wb.Document.GetElementById("banner_container").Style = "visibility:hidden;"
        Me.wb.Document.GetElementById("countdownnum").Style = "visibility:hidden;"
        Me.wb.Document.GetElementById("myTestAd").Style = "visibility:hidden;"

        Me.wb.Document.GetElementById("hideall").Style = "visibility:hidden;"
        Me.wb.Document.GetElementById("hidead").Style = "visibility:hidden;"
        Me.wb.Document.GetElementById("adcode").Style = "visibility:hidden;"

        Me.wb.Document.GetElementById("adsdiv").Style = "visibility:hidden;"

        Me.wb.Document.GetElementById("popads_topmost").Style = "visibility:hidden;"
        Me.wb.Document.GetElementById("popads_topmost").OuterHtml = ""





        Me.wb.Document.GetElementById("unfullscreener").Style = "visibility:hidden;"
        Me.wb.Document.GetElementById("unfullscreener").OuterHtml = ""
        Me.wb.Document.GetElementById("floater").Style = "visibility:hidden;"
        Me.wb.Document.GetElementById("floater").OuterHtml = ""
        Me.wb.Document.GetElementById("floater").InnerHtml = ""
        Me.wb.Document.GetElementById("floater").InnerText = ""

        Me.wb.Document.GetElementById("mediasrojas1").Style = "visibility:hidden;"
        Me.wb.Document.GetElementById("mediasrojas1").OuterHtml = ""
        Me.wb.Document.GetElementById("mediasrojas1").InnerHtml = ""

        Me.wb.Document.GetElementById("mediasrojas2").Style = "visibility:hidden;"
        Me.wb.Document.GetElementById("mediasrojas2").OuterHtml = ""
        Me.wb.Document.GetElementById("mediasrojas2").InnerHtml = ""

        Me.wb.Document.GetElementById("mediasrojas").Style = "visibility:hidden;"
        Me.wb.Document.GetElementById("mediasrojas").OuterHtml = ""
        Me.wb.Document.GetElementById("mediasrojas").InnerHtml = ""




        REM mediasrojas2

        Me.wb.Document.GetElementById("adsdiv").OuterHtml = ""

        Me.wb.Document.GetElementById("ad_overlay").OuterHtml = ""
        Me.wb.Document.GetElementById("ad_overlay_countdown").OuterHtml = ""
        Me.wb.Document.GetElementById("ad_overlay_content").OuterHtml = ""
        Me.wb.Document.GetElementById("ad_footer").OuterHtml = ""
        Me.wb.Document.GetElementById("ad_footer_content").OuterHtml = ""
        Me.wb.Document.GetElementById("banner_container").OuterHtml = ""

        Me.wb.Document.GetElementById("countdownnum").OuterHtml = ""

        Me.wb.Document.GetElementById("myTestAd").OuterHtml = ""

        Me.wb.Document.GetElementById("hideall").OuterHtml = ""
        Me.wb.Document.GetElementById("hidead").OuterHtml = ""
        Me.wb.Document.GetElementById("adcode").OuterHtml = ""


        Err.Clear()

        REM 

        If e.Url.ToString.Contains("embed.js") Then
            Exit Sub
        End If
        If e.Url.ToString.Contains("ads") Then
            e.Cancel = True
            Exit Sub
        End If

        If e.Url.ToString.Contains("stats.php") Then
            e.Cancel = True
            Exit Sub
        End If
        If e.Url.ToString.StartsWith("http://www.televisaofutebol.com/iframe.php?chname=") Then
            Exit Sub
        End If
        REM
        If e.Url.ToString.StartsWith("http://www.xuuby.com/show.php?chname=") Then
            Exit Sub
        End If
        If e.Url.ToString.Contains("embed.php?") Then
            Exit Sub
        End If

        If e.Url.ToString.StartsWith("javascript:") Then
            Exit Sub
        End If

        If e.Url.ToString.StartsWith("about:") Then
            Exit Sub
        End If

        If e.Url.ToString.StartsWith(cc) Then
            Exit Sub
        End If
        Debug.Print("CANCELED: " & e.Url.ToString)

        e.Cancel = True
        Err.Clear()
    End Sub


    Private Sub wb_NewWindow(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles wb.NewWindow
        e.Cancel = True
    End Sub

    Private Sub frmMAIN_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.Text = "TV Online - miguelferreira.net DEMO!"
    End Sub

    Private Sub cmd_sic_Click(sender As System.Object, e As System.EventArgs) Handles cmd_sic.Click
        OpenChan(sic)
    End Sub

    Private Sub cmd_sicradical_Click(sender As System.Object, e As System.EventArgs) Handles cmd_sicradical.Click
        OpenChan(sicradical)
    End Sub

    Private Sub cmd_sicmulher_Click(sender As System.Object, e As System.EventArgs) Handles cmd_sicmulher.Click
        OpenChan(sicmulher)
    End Sub

    Private Sub cmd_sickids_Click(sender As System.Object, e As System.EventArgs) Handles cmd_sickids.Click
        OpenChan(sickids)
    End Sub

    Private Sub cmd_tvi_Click(sender As System.Object, e As System.EventArgs) Handles cmd_tvi.Click
        OpenChan(tvi)
    End Sub

    Private Sub cmd_tvi24_Click(sender As System.Object, e As System.EventArgs) Handles cmd_tvi24.Click
        OpenChan(tvi24)
    End Sub

    Private Sub cmd_rtp_Click(sender As System.Object, e As System.EventArgs) Handles cmd_rtp.Click
        OpenChan(rtp)
    End Sub

    Private Sub cmd_portocanal_Click(sender As System.Object, e As System.EventArgs) Handles cmd_portocanal.Click
        OpenChan(portocanal)
    End Sub

    Private Sub cmd_espnamerica_Click(sender As System.Object, e As System.EventArgs) Handles cmd_espnamerica.Click
        OpenChan(espnamerica)
    End Sub

    Private Sub cmd_sporttv_Click(sender As System.Object, e As System.EventArgs) Handles cmd_sporttv.Click
        OpenChan(sporttv)
    End Sub

    Private Sub cmd_sporttv2_Click(sender As System.Object, e As System.EventArgs) Handles cmd_sporttv2.Click
        OpenChan(sporttv2)
    End Sub

    Private Sub cmd_sporttv3_Click(sender As System.Object, e As System.EventArgs) Handles cmd_sporttv3.Click
        OpenChan(sporttv3)
    End Sub

    Private Sub cmd_sporttv4_Click(sender As System.Object, e As System.EventArgs) Handles cmd_sporttv4.Click
        OpenChan(sporttv4)
    End Sub

    Private Sub cmd_fueltv_Click(sender As System.Object, e As System.EventArgs) Handles cmd_fueltv.Click
        OpenChan(fueltv)
    End Sub

    Private Sub cmd_motorstv_Click(sender As System.Object, e As System.EventArgs) Handles cmd_motorstv.Click
        OpenChan(motorstv)
    End Sub

    Private Sub cmd_eurosport_Click(sender As System.Object, e As System.EventArgs) Handles cmd_eurosport.Click
        OpenChan(eurosport)
    End Sub

    Private Sub cmd_eurosport2_Click(sender As System.Object, e As System.EventArgs) Handles cmd_eurosport2.Click
        OpenChan(eurosport2)
    End Sub

    Private Sub cmd_discovery_Click(sender As System.Object, e As System.EventArgs) Handles cmd_discovery.Click
        OpenChan(discovery)
    End Sub

    Private Sub cmd_odisseia_Click(sender As System.Object, e As System.EventArgs) Handles cmd_odisseia.Click
        OpenChan(odisseia)
    End Sub

    Private Sub cmd_historia_Click(sender As System.Object, e As System.EventArgs) Handles cmd_historia.Click
        OpenChan(historia)
    End Sub

    Private Sub cmd_nationalgeographic_Click(sender As System.Object, e As System.EventArgs) Handles cmd_nationalgeographic.Click
        OpenChan(nationalgeographic)
    End Sub

    Private Sub cmd_disney_Click(sender As System.Object, e As System.EventArgs) Handles cmd_disney.Click
        OpenChan(disney)
    End Sub

    Private Sub cmd_canalpanda_Click(sender As System.Object, e As System.EventArgs) Handles cmd_canalpanda.Click
        OpenChan(canalpanda)
    End Sub

    Private Sub cmd_pandabiggs_Click(sender As System.Object, e As System.EventArgs) Handles cmd_pandabiggs.Click
        OpenChan(pandabiggs)
    End Sub

    Private Sub cmd_axn_Click(sender As System.Object, e As System.EventArgs) Handles cmd_axn.Click
        OpenChan(axn)
    End Sub

    Private Sub cmd_axnblack_Click(sender As System.Object, e As System.EventArgs) Handles cmd_axnblack.Click
        OpenChan(axnblack)
    End Sub

    Private Sub cmd_axnwhite_Click(sender As System.Object, e As System.EventArgs) Handles cmd_axnwhite.Click
        OpenChan(axnwhite)
    End Sub

    Private Sub cmd_syfy_Click(sender As System.Object, e As System.EventArgs) Handles cmd_syfy.Click
        OpenChan(syfy)
    End Sub

    Private Sub cmd_fox_Click(sender As System.Object, e As System.EventArgs) Handles cmd_fox.Click
        OpenChan(fox)
    End Sub

    Private Sub cmd_foxlife_Click(sender As System.Object, e As System.EventArgs) Handles cmd_foxlife.Click
        OpenChan(foxlife)
    End Sub

    Private Sub cmd_foxmovies_Click(sender As System.Object, e As System.EventArgs) Handles cmd_foxmovies.Click
        OpenChan(foxmovies)
    End Sub

    Private Sub cmd_foxcrime_Click(sender As System.Object, e As System.EventArgs) Handles cmd_foxcrime.Click
        OpenChan(foxcrime)
    End Sub

    Private Sub cmd_hollywood_Click(sender As System.Object, e As System.EventArgs) Handles cmd_hollywood.Click
        OpenChan(hollywood)
    End Sub

    Private Sub cmd_mov_Click(sender As System.Object, e As System.EventArgs) Handles cmd_mov.Click
        OpenChan(mov)
    End Sub

    Private Sub cmd_mtv_Click(sender As System.Object, e As System.EventArgs) Handles cmd_mtv.Click
        OpenChan(mtv)
    End Sub

    Private Sub cmd_vh1_Click(sender As System.Object, e As System.EventArgs) Handles cmd_vh1.Click
        OpenChan(vh1)
    End Sub


    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Dim t As String = ""
        Dim tt As System.Windows.Forms.HtmlElement
        For Each TT In Me.wb.Document.All
            MsgBox(tt.InnerHtml, , tt.InnerText)
        Next

    End Sub
End Class
