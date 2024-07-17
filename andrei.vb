Public Class Form1
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        lblDateToday.Text = DateTime.Now.ToString("dddd, MMMM dd, yyyy")
        lblTimeToday.Text = DateTime.Now.ToString("HH:mm:ss tt")
    End Sub

    Private Sub BtnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub btnClearToppings_Click(sender As Object, e As EventArgs) Handles btnClearToppings.Click
        ClearToppings()
    End Sub

    Private Sub ClearToppings()
        For Each xObject As Control In gbExtraToppings.Controls
            If TypeOf xObject Is CheckBox Then
                Dim checkBox As CheckBox = DirectCast(xObject, CheckBox)
                checkBox.Checked = False
            End If
        Next
    End Sub

    Private Sub btnClearAll_Click(sender As Object, e As EventArgs) Handles btnClearAll.Click
        ClearToppings()
        rbSmall.Checked = True
        rbThinkCrust.Checked = True
        rbDineIn.Checked = True
        tbPizza.Text = ""
        tbExtraToppings.Text = ""
        tbDrinks.Text = ""
        tbTotal.Text = "0"

        For Each xObject As Control In gbDrinks.Controls
            If TypeOf xObject Is RadioButton Then
                Dim radioButton As RadioButton = DirectCast(xObject, RadioButton)
                radioButton.Checked = False
            End If
        Next
    End Sub

    Private Sub btnCompute_Click(sender As Object, e As EventArgs) Handles btnCompute.Click
        Dim size, crust, drinks, toppings, total As Single

        If (GetRadioSelectedName(gbSize).Text = "Small") Then
            size = 149
        ElseIf (GetRadioSelectedName(gbSize).Text = "Medium") Then
            size = 179
        Else
            size = 199
        End If

        If (GetRadioSelectedName(gbCrustType).Text = "Thick Crust") Then
            crust = 30
        ElseIf (GetRadioSelectedName(gbCrustType).Text = "Thin Crust") Then
            crust = 20
        Else
            crust = 25
        End If

        If (CheckNullGroupBox(gbDrinks, "RadioButton") = "Cola") Then
            drinks = 25
        ElseIf (CheckNullGroupBox(gbDrinks, "RadioButton") = "Sprite") Then
            drinks = 30
        ElseIf (CheckNullGroupBox(gbDrinks, "RadioButton") = "Root Beer") Then
            drinks = 35
        Else
            drinks = 0
        End If

        toppings = 0
        For Each xObject As CheckBox In gbExtraToppings.Controls.OfType(Of CheckBox)
            If xObject.Checked Then
                toppings += 15
            End If
        Next

        total = size + crust + drinks + toppings
        MsgBox("Total Price: " + total.ToString("C2"), MsgBoxStyle.OkOnly, "Total Price")
    End Sub

    Private Function GetRadioSelectedName(grpb As GroupBox) As RadioButton
        Dim rButton As RadioButton = grpb.Controls.OfType(Of RadioButton).FirstOrDefault(Function(r) r.Checked = True)
        Return rButton
    End Function

    Private Function CheckNullGroupBox(grpb As GroupBox, formType As String) As String

    End Function
    Dim selectedBox As String = ""
    For Each xObject In If(formType = "RadioButton", grpb.Controls.OfType(Of RadioButton), grpb.Controls.OfType(Of CheckBox))
    If xObject.Checked Then
                selectedBox += xObject.Text + If(formType