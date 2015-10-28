Public Class Form1
    Const intPER_DAY_CHARGE As Integer = 350

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Function CalcStayCharges(intDaysSpent As Integer) As Integer
        Return intDaysSpent * intPER_DAY_CHARGE
    End Function

    Function ValidateInputFields(ByRef intStayLength As Integer,
                                 ByRef decMedication As Decimal,
                                 ByRef decSurgical As Decimal) As Boolean

        If Not (Integer.TryParse(txtStayLength.Text, intStayLength) And intStayLength > 0) Then
            PrintError("Length of Stay")
            Return False
        End If
        If Not (Decimal.TryParse(txtMedication.Text, decMedication) And decMedication > 0) Then
            PrintError("Medication")
            Return False
        End If
        If Not (Decimal.TryParse(txtSurgicalCharges.Text, decSurgical) And decSurgical > 0) Then
            PrintError("Surgical Charges")
            Return False
        End If

        Return True
    End Function

    Private Sub btnCalculate_Click(sender As Object, e As EventArgs) Handles btnCalculate.Click
        Dim intStayLength As Integer, decMedication As Decimal, decSurgical As Decimal

        lblError.Text = String.Empty

        If ValidateInputFields(intStayLength, decMedication, decSurgical) Then
            MessageBox.Show("Stay costs: " & intStayLength.ToString("c"))
            MessageBox.Show("Medication costs: " & decMedication.ToString("c"))
            MessageBox.Show("Surgical costs: " & decSurgical.ToString("c"))
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
End Class
