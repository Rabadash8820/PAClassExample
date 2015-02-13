Imports System
Imports System.Threading
Imports System.Windows.Input

Module Module1

    Public Sub Main()
        Dim key As ConsoleKeyInfo
        Dim shouldKeepGoing As Boolean = True

        Do While shouldKeepGoing

            Console.Clear()
            Console.Write("What would you like to do?" & vbNewLine &
                                vbNewLine &
                                vbTab & "1.  Count down to explosion" & vbNewLine &
                                vbTab & "2.  Calculate the price of a taco" & vbNewLine &
                                vbTab & "3.  Watch the world burn" & vbNewLine &
                                vbTab & "4.  Exit" & vbNewLine &
                                vbNewLine)

            Console.Write("Enter your choice (1-4): ")
            key = Console.ReadKey()

            Select Case key.KeyChar
                Case "1"
                    Call countdown()
                Case "2"
                    Call taco()
                Case "3"
                    Call burnTheWorld()
                Case "4"
                    shouldKeepGoing = False
            End Select

        Loop

    End Sub

    Private Sub countdown()
        Dim start, count As Integer

        Console.Clear()
        Console.WriteLine("Where should the countdown start?")
        Console.Write(">")

        start = getNumber()
        For count = start To 1 Step -1
            Console.WriteLine(count)
        Next

        Console.WriteLine()
        Console.WriteLine("***** BBOOOOMMM!!! *****")
        Console.ReadLine()

    End Sub

    Private Sub taco()
        Console.Clear()

        Console.Write("Enter the cost of taco shells: ")
        Dim shellPrice As Double = getNumber()
        Console.Write(vbNewLine & "Enter the cost of taco meat: ")
        Dim meatPrice As Double = getNumber()
        Console.Write(vbNewLine & "Enter the cost of veggies: ")
        Dim veggiePrice As Double = getNumber()
        Console.Write(vbNewLine & "Enter the cost of sour cream: ")
        Dim creamPrice As Double = getNumber()
        Console.Write(vbNewLine & "Finally, enter how many tacos you are going to make: ")
        Dim numTacos As Integer = Int(getNumber())

        Dim total As Double
        total = numTacos * (shellPrice + meatPrice + veggiePrice + creamPrice)

        Console.WriteLine()
        Console.WriteLine((New String("Item")).PadRight(13) & (New String("Cost")))
        Console.WriteLine("-------------------------")
        Console.WriteLine((New String("Shells")).PadRight(13) & shellPrice.ToString("C"))
        Console.WriteLine((New String("Meat")).PadRight(13) & meatPrice.ToString("C"))
        Console.WriteLine((New String("Veggies")).PadRight(13) & veggiePrice.ToString("C"))
        Console.WriteLine((New String("Sour Cream")).PadRight(13) & creamPrice.ToString("C"))
        Console.WriteLine(vbNewLine & "Total cost to make " & numTacos.ToString() & " tacos is " & total.ToString("C"))
        Console.ReadLine()

    End Sub

    Private Sub burnTheWorld()
        Const DIAMONDS As Short = 2
        Const LENGTH As Short = 3
        Const COOLCHAR As Char = "@"
        Const PAUSE_TIME As Short = 31 'milliseconds
        Const DIAMOND_WIDTH As Short = 15
        Const INCLUDE_VERTICAL As Boolean = True
        Const INCLUDE_HORIZONTAL As Boolean = True

        Dim chars As Char()
        ReDim chars(0 To DIAMOND_WIDTH * DIAMONDS - 1)
        Dim pos As Short = 0

        Console.Clear()

        'Infinite loop
        Do While True

            'Add the cool characters for each diamond
            For i As Short = 0 To DIAMONDS - 1
                If pos = 0 And INCLUDE_HORIZONTAL Then
                    For j As Short = 0 To chars.Length - 1
                        chars(j) = COOLCHAR
                    Next j
                Else
                    chars(pos + DIAMOND_WIDTH * i) = COOLCHAR
                    chars((DIAMOND_WIDTH - 1 - pos) + DIAMOND_WIDTH * i) = COOLCHAR
                    If INCLUDE_VERTICAL Then chars(DIAMOND_WIDTH * i + Int(DIAMOND_WIDTH / 2)) = COOLCHAR
                End If
            Next i

            'Display this section of the diamond (elongated by length)
            For i As Short = 1 To LENGTH
                For Each c As Char In chars
                    Console.Write(c)
                Next
                Console.WriteLine()
                Thread.Sleep(PAUSE_TIME)
            Next i

            'Clear the cool characters for the next iteration
            For i As Short = 0 To chars.Length - 1
                chars(i) = vbNullChar
            Next i

            'Increment the position of the crazy character
            pos = (pos + 1) Mod DIAMOND_WIDTH

        Loop

    End Sub

    Private Function getNumber() As Double
        Dim key As String = Console.ReadLine()
        Do While Not IsNumeric(key)
            Console.Write("Please enter a number: ")
            key = Console.ReadLine()
        Loop

        getNumber = Convert.ToDouble(key)
    End Function

End Module