﻿Public Class Form1
    Const intPER_DAY_CHARGE As Integer = 350

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Function CalcStayCharges(intDaysSpent As Integer) As Decimal
        Return CDec(intDaysSpent * intPER_DAY_CHARGE)
    End Function

    Function ValidateInputFields(ByRef intStayLength As Integer,
                                 ByRef decMedication As Decimal,
                                 ByRef decSurgical As Decimal,
                                 ByRef decLabFees As Decimal,
                                 ByRef decPhysical As Decimal) As Boolean

        If Not (Integer.TryParse(txtStayLength.Text, intStayLength) And intStayLength > 0) Then
            PrintError("Length of Stay")
            Return False
        End If
        If Not (Decimal.TryParse(txtMedication.Text, decMedication) And decMedication >= 0) Then
            PrintError("Medication")
            Return False
        End If
        If Not (Decimal.TryParse(txtSurgicalCharges.Text, decSurgical) And decSurgical >= 0) Then
            PrintError("Surgical Charges")
            Return False
        End If
        If Not (Decimal.TryParse(txtLabFees.Text, decLabFees) And decLabFees >= 0) Then
            PrintError("Lab Fees")
            Return False
        End If
        If Not (Decimal.TryParse(txtPhysicalCharges.Text, decPhysical) And decPhysical >= 0) Then
            PrintError("Physical")
            Return False
        End If

        Return True
    End Function

    Private Sub btnCalculate_Click(sender As Object, e As EventArgs) Handles btnCalculate.Click
        Dim intStayLength As Integer, decMedication As Decimal, decSurgical As Decimal,
            decLabFees As Decimal, decPhysical As Decimal, decTotal As Decimal, decStayCosts As Decimal,
            decMiscCosts As Decimal

        lblError.Text = String.Empty

        If ValidateInputFields(intStayLength, decMedication, decSurgical, decLabFees, decPhysical) Then
            'After input checks out, get the costs and add them together
            decStayCosts = CalcStayCharges(intStayLength)
            decMiscCosts = CalcMiscCharges(decMedication, decSurgical, decLabFees, decPhysical)
            decTotal = CalcTotalCharges(decStayCosts, decMiscCosts)
            'Display the total
            lblTotal.Text = decTotal.ToString("c")
        End If
    End Sub

    Sub PrintError(ByVal strField As String)
        lblError.Text = "Enter a positive number into " & strField & " field."
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click

        'Clear the textboxes and error label and set focus back onto stay length field
        txtStayLength.Text = String.Empty
        txtMedication.Text = String.Empty
        txtSurgicalCharges.Text = String.Empty
        txtLabFees.Text = String.Empty
        txtPhysicalCharges.Text = String.Empty
        lblError.Text = String.Empty
        txtStayLength.Focus()
    End Sub

    Function CalcMiscCharges(ByVal decMedication As Decimal,
                             ByVal decSurgical As Decimal,
                             ByVal decLabFees As Decimal,
                             ByVal decPhysical As Decimal) As Decimal
        Return decMedication + decSurgical + decLabFees + decPhysical
    End Function

    Function CalcTotalCharges(decStayCosts As Decimal, decMiscCosts As Decimal) As Decimal
        Return decStayCosts + decMiscCosts
    End Function
End Class
