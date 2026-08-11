Option Explicit On

Sub AddBlanks()
    Dim Book As Workbook
    Dim Sheet As Worksheet
    Dim XIndex As Integer
    Dim YIndex As Integer
    Dim NumAdded As Integer

    Set Book = Workbooks("ui-mockup.csv")
    Set Sheet = Book.Worksheets("ui-mockup")
    NumAdded = 0

    For XIndex = 2 To 81
        For YIndex = 2 To 23
            If Sheet.Cells(YIndex, XIndex).Value = "" Then
                Sheet.Cells(YIndex, XIndex).Value = ""
                NumAdded = NumAdded + 1
            End If
        Next YIndex
    Next XIndex

    MsgBox NumAdded & " spaces added."
End Sub