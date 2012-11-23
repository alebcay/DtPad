Imports System.Runtime.InteropServices

<System.ComponentModel.DefaultProperty("ParentRichTextBox")> _
Public Class CustomLineNumbers : Inherits System.Windows.Forms.Control

    Private Class LineNumberItem
        Friend LineNumber As Integer
        Friend Rectangle As Rectangle
        Friend Sub New(ByVal zLineNumber As Integer, ByVal zRectangle As Rectangle)
            Me.LineNumber = zLineNumber
            Me.Rectangle = zRectangle
        End Sub
    End Class

    Public Enum LineNumberDockSide As Byte
        None = 0
        Left = 1
        Right = 2
        Height = 4
    End Enum

    Private WithEvents zParent As RichTextBox = Nothing
    Private WithEvents zTimer As New Windows.Forms.Timer

    Private zMarginLines_SpaceX As Integer = 3

    Private zAutoSizing As Boolean = True
    Private zAutoSizing_Size As New Size(0, 0)
    Private zContentRectangle As Rectangle = Nothing
    Private zDockSide As LineNumberDockSide = LineNumberDockSide.Left
    Private zParentIsScrolling As Boolean = False
    Private zSeeThroughMode As Boolean = False

    Private zGradient_Show As Boolean = True
    Private zGradient_Direction As Drawing2D.LinearGradientMode = Drawing2D.LinearGradientMode.Horizontal
    Private zGradient_StartColor As Color = Color.FromArgb(0, 0, 0, 0)
    Private zGradient_EndColor As Color = Color.LightSteelBlue

    Private zGridLines_Show As Boolean = True
    Private zGridLines_Thickness As Single = 1
    Private zGridLines_Style As Drawing2D.DashStyle = Drawing2D.DashStyle.Dot
    Private zGridLines_Color As Color = Color.SlateGray

    Private zBorderLines_Show As Boolean = True
    Private zBorderLines_Thickness As Single = 1
    Private zBorderLines_Style As Drawing2D.DashStyle = Drawing2D.DashStyle.Dot
    Private zBorderLines_Color As Color = Color.SlateGray

    Private zMarginLines_Show As Boolean = True
    Private zMarginLines_Side As LineNumberDockSide = LineNumberDockSide.Right
    Private zMarginLines_Thickness As Single = 1
    Private zMarginLines_Style As Drawing2D.DashStyle = Drawing2D.DashStyle.Solid
    Private zMarginLines_Color As Color = Color.SlateGray

    Private zLineNumbers_Show As Boolean = True
    Private zLineNumbers_ShowLeadingZeroes As Boolean = True
    Private zLineNumbers_ShowAsHexadecimal As Boolean = False
    Private zLineNumbers_ClipByItemRectangle As Boolean = True
    Private zLineNumbers_Offset As New Size(0, 0)
    Private zLineNumbers_Format As String = "0"
    Private zLineNumbers_Alignment As Drawing.ContentAlignment = ContentAlignment.TopRight
    Private zLineNumbers_AntiAlias As Boolean = True

    Private zLNIs As New List(Of LineNumberItem)

    Private zPointInParent As New Point(0, 0)
    Private zPointInMe As New Point(0, 0)
    Private zParentInMe As Integer = 0

    Public Sub New()
        With Me
            .SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
            .SetStyle(ControlStyles.ResizeRedraw, True)
            .SetStyle(ControlStyles.SupportsTransparentBackColor, True)
            .SetStyle(ControlStyles.UserPaint, True)
            .SetStyle(ControlStyles.AllPaintingInWmPaint, True)
            .Margin = New Padding(0)
            .Padding = New Padding(0, 0, 2, 0)
        End With
        With zTimer
            .Enabled = True
            .Interval = 200
            .Stop()
        End With
        Me.Update_SizeAndPosition()
        Me.Invalidate()
    End Sub

    Protected Overrides Sub OnHandleCreated(ByVal e As System.EventArgs)
        MyBase.OnHandleCreated(e)
        Me.AutoSize = False
    End Sub

    <System.ComponentModel.Browsable(False)> Public Overrides Property AutoSize() As Boolean
        Get
            Return MyBase.AutoSize
        End Get
        Set(ByVal value As Boolean)
            MyBase.AutoSize = value
            Me.Invalidate()
        End Set
    End Property

    <System.ComponentModel.Description("Use this property to automatically resize the control (and reposition it if needed).")> _
    <System.ComponentModel.Category("Additional Behavior")> Public Property AutoSizing() As Boolean
        Get
            Return zAutoSizing
        End Get
        Set(ByVal value As Boolean)
            zAutoSizing = value
            Me.Refresh()
            Me.Invalidate()
        End Set
    End Property

    <System.ComponentModel.Description("Use this property to enable LineNumbers for the chosen RichTextBox.")> _
    <System.ComponentModel.Category("Add LineNumbers to")> Public Property ParentRichTextBox() As RichTextBox
        Get
            Return zParent
        End Get
        Set(ByVal value As RichTextBox)
            zParent = value
            If zParent IsNot Nothing Then
                Me.Parent = zParent.Parent
                zParent.Refresh()
            End If
            Me.Text = String.Empty
            Me.Refresh()
            Me.Invalidate()
        End Set
    End Property

    <System.ComponentModel.Description("Use this property to dock the LineNumbers to a chosen side of the chosen RichTextBox.")> _
    <System.ComponentModel.Category("Additional Behavior")> Public Property DockSide() As LineNumberDockSide
        Get
            Return zDockSide
        End Get
        Set(ByVal value As LineNumberDockSide)
            zDockSide = value
            Me.Refresh()
            Me.Invalidate()
        End Set
    End Property

    <System.ComponentModel.Description("Use this property to enable the control to act as an overlay ontop of the RichTextBox.")> _
    <System.ComponentModel.Category("Additional Behavior")> Public Property _SeeThroughMode_() As Boolean
        Get
            Return zSeeThroughMode
        End Get
        Set(ByVal value As Boolean)
            zSeeThroughMode = value
            Me.Invalidate()
        End Set
    End Property

    <System.ComponentModel.Description("BorderLines are shown on all sides of the LineNumber control.")> _
    <System.ComponentModel.Category("Additional Behavior")> Public Property Show_BorderLines() As Boolean
        Get
            Return zBorderLines_Show
        End Get
        Set(ByVal value As Boolean)
            zBorderLines_Show = value
            Me.Invalidate()
        End Set
    End Property

    <System.ComponentModel.Category("Additional Appearance")> Public Property BorderLines_Color() As Color
        Get
            Return zBorderLines_Color
        End Get
        Set(ByVal value As Color)
            zBorderLines_Color = value
            Me.Invalidate()
        End Set
    End Property

    <System.ComponentModel.Category("Additional Appearance")> Public Property BorderLines_Thickness() As Single
        Get
            Return zBorderLines_Thickness
        End Get
        Set(ByVal value As Single)
            zBorderLines_Thickness = Math.Max(1, Math.Min(255, value))
            Me.Invalidate()
        End Set
    End Property

    <System.ComponentModel.Category("Additional Appearance")> Public Property BorderLines_Style() As Drawing2D.DashStyle
        Get
            Return zBorderLines_Style
        End Get
        Set(ByVal value As Drawing2D.DashStyle)
            If value = Drawing2D.DashStyle.Custom Then value = Drawing2D.DashStyle.Solid
            zBorderLines_Style = value
            Me.Invalidate()
        End Set
    End Property

    <System.ComponentModel.Description("GridLines are the horizontal divider-lines shown above each LineNumber.")> _
    <System.ComponentModel.Category("Additional Behavior")> Public Property Show_GridLines() As Boolean
        Get
            Return zGridLines_Show
        End Get
        Set(ByVal value As Boolean)
            zGridLines_Show = value
            Me.Invalidate()
        End Set
    End Property

    <System.ComponentModel.Category("Additional Appearance")> Public Property GridLines_Color() As Color
        Get
            Return zGridLines_Color
        End Get
        Set(ByVal value As Color)
            zGridLines_Color = value
            Me.Invalidate()
        End Set
    End Property

    <System.ComponentModel.Category("Additional Appearance")> Public Property GridLines_Thickness() As Single
        Get
            Return zGridLines_Thickness
        End Get
        Set(ByVal value As Single)
            zGridLines_Thickness = Math.Max(1, Math.Min(255, value))
            Me.Invalidate()
        End Set
    End Property

    <System.ComponentModel.Category("Additional Appearance")> Public Property GridLines_Style() As Drawing2D.DashStyle
        Get
            Return zGridLines_Style
        End Get
        Set(ByVal value As Drawing2D.DashStyle)
            If value = Drawing2D.DashStyle.Custom Then value = Drawing2D.DashStyle.Solid
            zGridLines_Style = value
            Me.Invalidate()
        End Set
    End Property

    <System.ComponentModel.Description("MarginLines are shown on the Left or Right (or both in Height-mode) of the LineNumber control.")> _
    <System.ComponentModel.Category("Additional Behavior")> Public Property Show_MarginLines() As Boolean
        Get
            Return zMarginLines_Show
        End Get
        Set(ByVal value As Boolean)
            zMarginLines_Show = value
            Me.Invalidate()
        End Set
    End Property

    <System.ComponentModel.Category("Additional Appearance")> Public Property MarginLines_Side() As LineNumberDockSide
        Get
            Return zMarginLines_Side
        End Get
        Set(ByVal value As LineNumberDockSide)
            zMarginLines_Side = value
            Me.Invalidate()
        End Set
    End Property

    <System.ComponentModel.Category("Additional Appearance")> Public Property MarginLines_Color() As Color
        Get
            Return zMarginLines_Color
        End Get
        Set(ByVal value As Color)
            zMarginLines_Color = value
            Me.Invalidate()
        End Set
    End Property

    <System.ComponentModel.Category("Additional Appearance")> Public Property MarginLines_Thickness() As Single
        Get
            Return zMarginLines_Thickness
        End Get
        Set(ByVal value As Single)
            zMarginLines_Thickness = Math.Max(1, Math.Min(255, value))
            Me.Invalidate()
        End Set
    End Property

    <System.ComponentModel.Category("Additional Appearance")> Public Property MarginLines_Style() As Drawing2D.DashStyle
        Get
            Return zMarginLines_Style
        End Get
        Set(ByVal value As Drawing2D.DashStyle)
            If value = Drawing2D.DashStyle.Custom Then value = Drawing2D.DashStyle.Solid
            zMarginLines_Style = value
            Me.Invalidate()
        End Set
    End Property

    <System.ComponentModel.Description("The BackgroundGradient is a gradual blend of two colors, shown in the back of each LineNumber's item-area.")> _
    <System.ComponentModel.Category("Additional Behavior")> Public Property Show_BackgroundGradient() As Boolean
        Get
            Return zGradient_Show
        End Get
        Set(ByVal value As Boolean)
            zGradient_Show = value
            Me.Invalidate()
        End Set
    End Property

    <System.ComponentModel.Category("Additional Appearance")> Public Property BackgroundGradient_AlphaColor() As Color
        Get
            Return zGradient_StartColor
        End Get
        Set(ByVal value As Color)
            zGradient_StartColor = value
            Me.Invalidate()
        End Set
    End Property

    <System.ComponentModel.Category("Additional Appearance")> Public Property BackgroundGradient_BetaColor() As Color
        Get
            Return zGradient_EndColor
        End Get
        Set(ByVal value As Color)
            zGradient_EndColor = value
            Me.Invalidate()
        End Set
    End Property

    <System.ComponentModel.Category("Additional Appearance")> Public Property BackgroundGradient_Direction() As Drawing2D.LinearGradientMode
        Get
            Return zGradient_Direction
        End Get
        Set(ByVal value As Drawing2D.LinearGradientMode)
            zGradient_Direction = value
            Me.Invalidate()
        End Set
    End Property

    <System.ComponentModel.Category("Additional Behavior")> Public Property Show_LineNrs() As Boolean
        Get
            Return zLineNumbers_Show
        End Get
        Set(ByVal value As Boolean)
            zLineNumbers_Show = value
            Me.Invalidate()
        End Set
    End Property

    <System.ComponentModel.Description("Use this to set whether the LineNumbers are allowed to spill out of their item-area, or should be clipped by it.")> _
    <System.ComponentModel.Category("Additional Behavior")> Public Property LineNrs_ClippedByItemRectangle() As Boolean
        Get
            Return zLineNumbers_ClipByItemRectangle
        End Get
        Set(ByVal value As Boolean)
            zLineNumbers_ClipByItemRectangle = value
            Me.Invalidate()
        End Set
    End Property

    <System.ComponentModel.Description("Use this to set whether the LineNumbers should have leading zeroes (based on the total amount of textlines).")> _
    <System.ComponentModel.Category("Additional Behavior")> Public Property LineNrs_LeadingZeroes() As Boolean
        Get
            Return zLineNumbers_ShowLeadingZeroes
        End Get
        Set(ByVal value As Boolean)
            zLineNumbers_ShowLeadingZeroes = value
            Me.Refresh()
            Me.Invalidate()
        End Set
    End Property

    <System.ComponentModel.Description("Use this to set whether the LineNumbers should be shown as hexadecimal values.")> _
    <System.ComponentModel.Category("Additional Behavior")> Public Property LineNrs_AsHexadecimal() As Boolean
        Get
            Return zLineNumbers_ShowAsHexadecimal
        End Get
        Set(ByVal value As Boolean)
            zLineNumbers_ShowAsHexadecimal = value
            Me.Refresh()
            Me.Invalidate()
        End Set
    End Property

    <System.ComponentModel.Description("Use this property to manually reposition the LineNumbers, relative to their current location.")> _
    <System.ComponentModel.Category("Additional Behavior")> Public Property LineNrs_Offset() As Size
        Get
            Return zLineNumbers_Offset
        End Get
        Set(ByVal value As Size)
            zLineNumbers_Offset = value
            Me.Invalidate()
        End Set
    End Property

    <System.ComponentModel.Description("Use this to align the LineNumbers to a chosen corner (or center) within their item-area.")> _
    <System.ComponentModel.Category("Additional Behavior")> Public Property LineNrs_Alignment() As System.Drawing.ContentAlignment
        Get
            Return zLineNumbers_Alignment
        End Get
        Set(ByVal value As System.Drawing.ContentAlignment)
            zLineNumbers_Alignment = value
            Me.Invalidate()
        End Set
    End Property

    <System.ComponentModel.Description("Use this to apply Anti-Aliasing to the LineNumbers (high quality). Some fonts will look better without it, though.")> _
       <System.ComponentModel.Category("Additional Behavior")> Public Property LineNrs_AntiAlias() As Boolean
        Get
            Return zLineNumbers_AntiAlias
        End Get
        Set(ByVal value As Boolean)
            zLineNumbers_AntiAlias = value
            Me.Refresh()
            Me.Invalidate()
        End Set
    End Property

    <System.ComponentModel.Browsable(True)> Public Overrides Property Font() As System.Drawing.Font
        Get
            Return MyBase.Font
        End Get
        Set(ByVal value As System.Drawing.Font)
            MyBase.Font = value
            Me.Refresh()
            Me.Invalidate()
        End Set
    End Property

    <System.ComponentModel.DefaultValue("")> _
    <System.ComponentModel.AmbientValue("")> _
    <System.ComponentModel.Browsable(False)> _
    Public Overrides Property Text() As String
        Get
            Return MyBase.Text
        End Get
        Set(ByVal value As String)
            MyBase.Text = String.Empty
            Me.Invalidate()
        End Set
    End Property

    '//////////////////////////////////////////////////////////////////////////////////////////////////

    Protected Overrides Sub OnSizeChanged(ByVal e As System.EventArgs)
        If Me.DesignMode = True Then Me.Refresh()
        MyBase.OnSizeChanged(e)
        Me.Invalidate()
    End Sub

    Protected Overrides Sub OnLocationChanged(ByVal e As System.EventArgs)
        If Me.DesignMode = True Then Me.Refresh()
        MyBase.OnLocationChanged(e)
        Me.Invalidate()
    End Sub

    Public Overrides Sub Refresh()
        'Note: don't change the order here, first the Mybase.Refresh, then the Update_SizeAndPosition.
        MyBase.Refresh()
        Me.Update_SizeAndPosition()
    End Sub

    ''' <summary>
    ''' This Sub will run whenever Me.Refresh() is called. It applies the AutoSizing and DockSide settings.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub Update_SizeAndPosition()
        If Me.AutoSize = True Then Exit Sub
        If Me.Dock = DockStyle.Bottom Or Me.Dock = DockStyle.Fill Or Me.Dock = DockStyle.Top Then Exit Sub
        Dim zNewLocation As Point = Me.Location, zNewSize As Size = Me.Size

        If zAutoSizing = True Then
            Select Case True
                Case zParent Is Nothing
                    '--- ReminderMessage sizing
                    If zAutoSizing_Size.Width > 0 And zAutoSizing_Size.Width > MinimumSize.Width Then zNewSize.Width = zAutoSizing_Size.Width
                    If zAutoSizing_Size.Height > 0 Then zNewSize.Height = zAutoSizing_Size.Height
                    Me.Size = zNewSize

                    '--- zParent isNot Nothing for the following cases
                Case Me.Dock = DockStyle.Left Or Me.Dock = DockStyle.Right
                    If zAutoSizing_Size.Width > 0 And zAutoSizing_Size.Width > MinimumSize.Width Then zNewSize.Width = zAutoSizing_Size.Width
                    Me.Width = zNewSize.Width

                    '--- DockSide is active L/R/H
                Case zDockSide <> LineNumberDockSide.None
                    If zAutoSizing_Size.Width > 0 And zAutoSizing_Size.Width > MinimumSize.Width Then zNewSize.Width = zAutoSizing_Size.Width
                    zNewSize.Height = zParent.Height
                    If zDockSide = LineNumberDockSide.Left Then zNewLocation.X = zParent.Left - zNewSize.Width - 1
                    If zDockSide = LineNumberDockSide.Right Then zNewLocation.X = zParent.Right + 1
                    zNewLocation.Y = zParent.Top
                    Me.Location = zNewLocation
                    Me.Size = zNewSize

                    '--- DockSide = None, but AutoSizing is still setting the Width
                Case zDockSide = LineNumberDockSide.None
                    If zAutoSizing_Size.Width > 0 And zAutoSizing_Size.Width > MinimumSize.Width Then zNewSize.Width = zAutoSizing_Size.Width
                    Me.Size = zNewSize

            End Select

        Else
            '--- No AutoSizing
            Select Case True
                Case zParent Is Nothing
                    '--- ReminderMessage sizing
                    If zAutoSizing_Size.Width > 0 And zAutoSizing_Size.Width > MinimumSize.Width Then zNewSize.Width = zAutoSizing_Size.Width
                    If zAutoSizing_Size.Height > 0 Then zNewSize.Height = zAutoSizing_Size.Height
                    Me.Size = zNewSize

                    '--- No AutoSizing, but DockSide L/R/H is active so height and position need updates.
                Case zDockSide <> LineNumberDockSide.None
                    zNewSize.Height = zParent.Height
                    If zDockSide = LineNumberDockSide.Left Then zNewLocation.X = zParent.Left - zNewSize.Width - 1
                    If zDockSide = LineNumberDockSide.Right Then zNewLocation.X = zParent.Right + 1
                    zNewLocation.Y = zParent.Top
                    Me.Location = zNewLocation
                    Me.Size = zNewSize

            End Select
        End If

    End Sub

    ''' <summary>
    ''' This Sub determines which textlines are visible in the ParentRichTextBox, and makes LineNumberItems (LineNumber + ItemRectangle)
    ''' for each visible line. They are put into the zLNIs List that will be used by the OnPaint event to draw the LineNumberItems. 
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub Update_VisibleLineNumberItems()
        zLNIs.Clear()
        zAutoSizing_Size = New Size(0, 0)
        zLineNumbers_Format = "0"  'initial setting
        'To measure the LineNumber's width, its Format 0 is replaced by w as that is likely to be one of the widest characters in non-monospace fonts. 
        If zAutoSizing = True Then zAutoSizing_Size = New Size(TextRenderer.MeasureText(zLineNumbers_Format.Replace("0".ToCharArray, "W".ToCharArray), Me.Font).Width, 0)

        If zParent Is Nothing OrElse zParent.Text = String.Empty Then Exit Sub

        '--- Make sure the LineNumbers are aligning to the same height as the zParent textlines by converting to screencoordinates
        'and using that as an offset that gets added to the points for the LineNumberItems
        zPointInParent = zParent.PointToScreen(zParent.ClientRectangle.Location)
        zPointInMe = Me.PointToScreen(New Point(0, 0))
        'zParentInMe is the vertical offset to make the LineNumberItems line up with the textlines in zParent.
        zParentInMe = zPointInParent.Y - zPointInMe.Y + 1
        'The first visible LineNumber may not be the first visible line of text in the RTB if the LineNumbercontrol's .Top is lower on the form than
        'the .Top of the parent RichTextBox. Therefor, zPointInParent will now be used to find zPointInMe's equivalent height in zParent, 
        'which is needed to find the best StartIndex later on.
        zPointInParent = zParent.PointToClient(zPointInMe)

        '--- NOTES: 
        'Additional complication is the fact that when wordwrap is enabled on the RTB, the wordwrapped text spills into the RTB.Lines collection, 
        'so we need to split the text into lines ourselves, and use the Index of each zSplit-line's first character instead of the RTB's.
        Dim zSplit() As String = zParent.Text.Split(vbCrLf.ToCharArray)

        If zSplit.Length < 2 Then
            'Just one line in the text = one linenumber
            'Note: zContentRectangle is built by the zParent.ContentsResized event.
            Dim zPoint As Point = zParent.GetPositionFromCharIndex(0)
            zLNIs.Add(New LineNumberItem(1, New Rectangle(New Point(0, zPoint.Y - 1 + zParentInMe), New Size(Me.Width, zContentRectangle.Height - zPoint.Y))))

            'ElseIf zParentIsScrolling = True Then
            '    zTimer.Start()
            'ElseIf zParentIsScrolling = False Then
        Else

            'Multiple lines, but store only those LineNumberItems for lines that are visible.
            Dim zTimeSpan As New TimeSpan(Now.Ticks)
            Dim zPoint As New Point(0, 0), zStartIndex As Integer = 0
            Dim zSplitStartLine As Integer = 0, zA As Integer = zParent.Text.Length - 1
            Me.FindStartIndex(zStartIndex, zA, zPointInParent.Y)

            'zStartIndex now holds the index of a character in the first visible line from zParent.Text
            'Now it will be pointed at the first character of that line (chr(10) = Linefeed part of the vbCrLf constant)
            zStartIndex = Math.Max(0, Math.Min(zParent.Text.Length - 1, zParent.Text.Substring(0, zStartIndex).LastIndexOf(Chr(10)) + 1))

            'We now need to find out which zSplit-line that character is in, by counting the vbCrlf appearances that come before it.
            zSplitStartLine = Math.Max(0, zParent.Text.Substring(0, zStartIndex).Split(vbCrLf.ToCharArray).Length - 1)

            'zStartIndex starts off pointing at the first character of the first visible line, and will be then be pointed to 
            'the index of the first character on the next line.
            For zA = zSplitStartLine To zSplit.Length - 1
                zPoint = zParent.GetPositionFromCharIndex(zStartIndex)
                zStartIndex += Math.Max(1, zSplit(zA).Length + 1)
                If zPoint.Y + zParentInMe > Me.Height Then Exit For
                'For performance reasons, the list of LineNumberItems (zLNIs) is first built with only the location of its 
                'itemrectangle being used. The height of those rectangles will be computed afterwards by comparing the items' Y coordinates.
                zLNIs.Add(New LineNumberItem(zA + 1, New Rectangle(0, zPoint.Y - 1 + zParentInMe, Me.Width, 1)))
                If zParentIsScrolling = True Then 'AndAlso Now.Ticks > zTimeSpan.Ticks + 500000 Then
                    'The more lines there are in the RTB, the slower the RTB's .GetPositionFromCharIndex() method becomes
                    'To avoid those delays from interfering with the scrollingspeed, this speedbased exit for is applied (0.05 sec)
                    'zLNIs will have at least 1 item, and if that's the only one, then change its location to 0,0 to make it readable
                    If zLNIs.Count = 1 Then zLNIs(0).Rectangle.Y = 0
                    'zParentIsScrolling = False
                    zTimer.Start()
                    Exit For
                End If
            Next

            If zLNIs.Count = 0 Then Exit Sub

            'Add an extra placeholder item to the end, to make the heightcomputation easier
            If zA < zSplit.Length Then
                'getting here means the for/next loop was exited before reaching the last zSplit textline
                'zStartIndex will still be pointing to the startcharacter of the next line, so we can use that:
                zPoint = zParent.GetPositionFromCharIndex(Math.Min(zStartIndex, zParent.Text.Length - 1))
                zLNIs.Add(New LineNumberItem(-1, New Rectangle(0, zPoint.Y - 1 + zParentInMe, 0, 0)))
            Else
                'getting here means the for/next loop ran to the end (zA is now zSplit.Length). 
                zLNIs.Add(New LineNumberItem(-1, New Rectangle(0, zContentRectangle.Bottom, 0, 0)))
            End If

            'And now we can easily compute the height of the LineNumberItems by comparing each item's Y coordinate with that of the next line.
            'There's at least two items in the list, and the last item is a "nextline-placeholder" that will be removed.
            For zA = 0 To zLNIs.Count - 2
                zLNIs(zA).Rectangle.Height = Math.Max(1, zLNIs(zA + 1).Rectangle.Y - zLNIs(zA).Rectangle.Y)
            Next
            'Removing the placeholder item
            zLNIs.RemoveAt(zLNIs.Count - 1)

            'Set the Format to the width of the highest possible number so that LeadingZeroes shows the correct amount of zeroes.
            If zLineNumbers_ShowAsHexadecimal = True Then
                zLineNumbers_Format = "".PadRight(zSplit.Length.ToString("X").Length, "0")
            Else
                zLineNumbers_Format = "".PadRight(zSplit.Length.ToString.Length, "0")
            End If
        End If

        'To measure the LineNumber's width, its Format 0 is replaced by w as that is likely to be one of the widest characters in non-monospace fonts. 
        If zAutoSizing = True Then zAutoSizing_Size = New Size(TextRenderer.MeasureText(zLineNumbers_Format.Replace("0".ToCharArray, "W".ToCharArray), Me.Font).Width, 0)
    End Sub

    ''' <summary>
    ''' FindStartIndex is a recursive Sub (one that calls itself) to compute the first visible line that should have a LineNumber.
    ''' </summary>
    ''' <param name="zMin"> this will hold the eventual BestStartIndex when the Sub has completed its run.</param>
    ''' <param name="zMax"></param>
    ''' <param name="zTarget"></param>
    ''' <remarks></remarks>
    Private Sub FindStartIndex(ByRef zMin As Integer, ByRef zMax As Integer, ByRef zTarget As Integer)
        'Recursive Sub to compute best starting index - only run when zParent is known to exist
        If zMax = zMin + 1 Or zMin = (zMax + zMin) \ 2 Then Exit Sub
        Select Case zParent.GetPositionFromCharIndex((zMax + zMin) \ 2).Y
            Case Is = zTarget
                'BestStartIndex found
                zMin = (zMax + zMin) \ 2
            Case Is > zTarget
                'Look again, in lower half
                zMax = (zMax + zMin) \ 2
                FindStartIndex(zMin, zMax, zTarget)
            Case Is < 0
                'Look again, in top half
                zMin = (zMax + zMin) \ 2
                FindStartIndex(zMin, zMax, zTarget)
        End Select
    End Sub

    ''' <summary>
    ''' OnPaint will go through the enabled elements (vertical ReminderMessage, GridLines, LineNumbers, BorderLines, MarginLines) and will
    ''' draw them if enabled. At the same time, it will build GraphicsPaths for each of those elements (that are enabled), which will be used 
    ''' in SeeThroughMode (if it's active): the figures in the GraphicsPaths will form a customized outline for the control by setting them as the 
    ''' Region of the LineNumber control. Note: the vertical ReminderMessages are only drawn during designtime. 
    ''' </summary>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        'Build the list of visible LineNumberItems (= zLNIs) first. (doesn't take long, so it can stay in OnPaint)
        Me.Update_VisibleLineNumberItems()
        MyBase.OnPaint(e)

        '--- QualitySettings
        If zLineNumbers_AntiAlias = True Then
            e.Graphics.TextRenderingHint = Drawing.Text.TextRenderingHint.AntiAlias
        Else
            e.Graphics.TextRenderingHint = Drawing.Text.TextRenderingHint.SystemDefault
        End If

        '--- Local Declarations
        Dim zTextToShow As String = String.Empty, zReminderToShow As String = String.Empty, zSF As New StringFormat, zTextSize As SizeF
        Dim zPen As New Pen(Me.ForeColor), zBrush As New SolidBrush(Me.ForeColor)
        Dim zPoint As New Point(0, 0), zItemClipRectangle As New Rectangle(0, 0, 0, 0)

        'Note: The GraphicsPaths are only used for SeeThroughMode
        'FillMode.Winding: combined outline ( Alternate: XOR'ed outline )
        Dim zGP_GridLines As New Drawing2D.GraphicsPath(Drawing2D.FillMode.Winding)
        Dim zGP_BorderLines As New Drawing2D.GraphicsPath(Drawing2D.FillMode.Winding)
        Dim zGP_MarginLines As New Drawing2D.GraphicsPath(Drawing2D.FillMode.Winding)
        Dim zGP_LineNumbers As New Drawing2D.GraphicsPath(Drawing2D.FillMode.Winding)
        Dim zRegion As New Region(MyBase.ClientRectangle)

        '----------------------------------------------
        '--- DESIGNTIME / NO VISIBLE ITEMS
        If Me.DesignMode = True Then
            'Show a vertical reminder message
            If zParent Is Nothing Then
                zReminderToShow = "-!- Set ParentRichTextBox -!-"
            Else
                If zLNIs.Count = 0 Then zReminderToShow = "LineNrs (  " & zParent.Name & "  )"
            End If
            If zReminderToShow.Length > 0 Then
                '--- Centering and Rotation for the reminder message
                e.Graphics.TranslateTransform(Me.Width / 2, Me.Height / 2)
                e.Graphics.RotateTransform(-90)
                zSF.Alignment = StringAlignment.Center
                zSF.LineAlignment = StringAlignment.Center
                '--- Show the reminder message (with small shadow)
                zTextSize = e.Graphics.MeasureString(zReminderToShow, Me.Font, zPoint, zSF)
                e.Graphics.DrawString(zReminderToShow, Me.Font, Brushes.WhiteSmoke, 1, 1, zSF)
                e.Graphics.DrawString(zReminderToShow, Me.Font, Brushes.Firebrick, 0, 0, zSF)
                e.Graphics.ResetTransform()

                Dim zReminderRectangle As New Rectangle(Me.Width / 2 - zTextSize.Height / 2, Me.Height / 2 - zTextSize.Width / 2, zTextSize.Height, zTextSize.Width)
                zGP_LineNumbers.AddRectangle(zReminderRectangle)
                zGP_LineNumbers.CloseFigure()

                If zAutoSizing = True Then
                    zReminderRectangle.Inflate(zTextSize.Height * 0.2, zTextSize.Width * 0.1)
                    zAutoSizing_Size = New Size(zReminderRectangle.Width, zReminderRectangle.Height)
                End If
            End If
        End If

        '----------------------------------------------
        '--- DESIGN OR RUNTIME / WITH VISIBLE ITEMS (which means zParent exists)
        If zLNIs.Count > 0 Then
            'The visible LineNumberItems with their BackgroundGradient and GridLines
            'Loop through every visible LineNumberItem
            Dim zLGB As Drawing2D.LinearGradientBrush = Nothing
            zPen = New Pen(zGridLines_Color, zGridLines_Thickness)
            zPen.DashStyle = zGridLines_Style
            zSF.Alignment = StringAlignment.Near
            zSF.LineAlignment = StringAlignment.Near
            zSF.FormatFlags = StringFormatFlags.FitBlackBox + StringFormatFlags.NoClip + StringFormatFlags.NoWrap

            For zA As Integer = 0 To zLNIs.Count - 1

                '--- BackgroundGradient
                If zGradient_Show = True Then
                    zLGB = New Drawing2D.LinearGradientBrush(zLNIs(zA).Rectangle, zGradient_StartColor, zGradient_EndColor, zGradient_Direction)
                    e.Graphics.FillRectangle(zLGB, zLNIs(zA).Rectangle)
                End If

                '--- GridLines
                If zGridLines_Show = True Then
                    e.Graphics.DrawLine(zPen, New Point(0, zLNIs(zA).Rectangle.Y), New Point(Me.Width, zLNIs(zA).Rectangle.Y))

                    'Note: Every item in a GraphicsPath is a closed figure, so instead of adding gridlines as lines, we'll add them
                    'as rectangles that loop out of sight. Their height uses the zContentRectangle which is the maxsize of 
                    'the ParentRichTextBox's contents. 
                    'Note: Slight adjustment needed when the first item has a negative Y coordinate. 
                    'This explains the " - zLNIs(0).Rectangle.Y" (which adds the negative size to the height 
                    'to make sure the rectangle's bottompart stays out of sight) 
                    zGP_GridLines.AddRectangle(New Rectangle(-zGridLines_Thickness, zLNIs(zA).Rectangle.Y, Me.Width + zGridLines_Thickness * 2, Me.Height - zLNIs(0).Rectangle.Y + zGridLines_Thickness))
                    zGP_GridLines.CloseFigure()
                End If

                '--- LineNumbers
                If zLineNumbers_Show = True Then
                    'TextFormatting
                    If zLineNumbers_ShowLeadingZeroes = True Then
                        zTextToShow = IIf(zLineNumbers_ShowAsHexadecimal, zLNIs(zA).LineNumber.ToString("X"), zLNIs(zA).LineNumber.ToString(zLineNumbers_Format))
                    Else
                        zTextToShow = IIf(zLineNumbers_ShowAsHexadecimal, zLNIs(zA).LineNumber.ToString("X"), zLNIs(zA).LineNumber.ToString)
                    End If
                    'TextSizing
                    zTextSize = e.Graphics.MeasureString(zTextToShow, Me.Font, zPoint, zSF)
                    'TextAlignment and positioning   (zPoint = TopLeftCornerPoint of the text)
                    'TextAlignment, padding, manual offset (via LineNrs_Offset) and zTextSize are all included in the calculation of zPoint. 
                    Select Case zLineNumbers_Alignment
                        Case ContentAlignment.TopLeft
                            zPoint = New Point(zLNIs(zA).Rectangle.Left + Me.Padding.Left + zLineNumbers_Offset.Width, zLNIs(zA).Rectangle.Top + Me.Padding.Top + zLineNumbers_Offset.Height)
                        Case ContentAlignment.MiddleLeft
                            zPoint = New Point(zLNIs(zA).Rectangle.Left + Me.Padding.Left + zLineNumbers_Offset.Width, zLNIs(zA).Rectangle.Top + (zLNIs(zA).Rectangle.Height / 2) + zLineNumbers_Offset.Height - zTextSize.Height / 2)
                        Case ContentAlignment.BottomLeft
                            zPoint = New Point(zLNIs(zA).Rectangle.Left + Me.Padding.Left + zLineNumbers_Offset.Width, zLNIs(zA).Rectangle.Bottom - Me.Padding.Bottom + 1 + zLineNumbers_Offset.Height - zTextSize.Height)
                        Case ContentAlignment.TopCenter
                            zPoint = New Point(zLNIs(zA).Rectangle.Width / 2 + zLineNumbers_Offset.Width - zTextSize.Width / 2, zLNIs(zA).Rectangle.Top + Me.Padding.Top + zLineNumbers_Offset.Height)
                        Case ContentAlignment.MiddleCenter
                            zPoint = New Point(zLNIs(zA).Rectangle.Width / 2 + zLineNumbers_Offset.Width - zTextSize.Width / 2, zLNIs(zA).Rectangle.Top + (zLNIs(zA).Rectangle.Height / 2) + zLineNumbers_Offset.Height - zTextSize.Height / 2)
                        Case ContentAlignment.BottomCenter
                            zPoint = New Point(zLNIs(zA).Rectangle.Width / 2 + zLineNumbers_Offset.Width - zTextSize.Width / 2, zLNIs(zA).Rectangle.Bottom - Me.Padding.Bottom + 1 + zLineNumbers_Offset.Height - zTextSize.Height)
                        Case ContentAlignment.TopRight
                            zPoint = New Point(zLNIs(zA).Rectangle.Right - Me.Padding.Right + zLineNumbers_Offset.Width - zTextSize.Width, zLNIs(zA).Rectangle.Top + Me.Padding.Top + zLineNumbers_Offset.Height)
                        Case ContentAlignment.MiddleRight
                            zPoint = New Point(zLNIs(zA).Rectangle.Right - Me.Padding.Right + zLineNumbers_Offset.Width - zTextSize.Width, zLNIs(zA).Rectangle.Top + (zLNIs(zA).Rectangle.Height / 2) + zLineNumbers_Offset.Height - zTextSize.Height / 2)
                        Case ContentAlignment.BottomRight
                            zPoint = New Point(zLNIs(zA).Rectangle.Right - Me.Padding.Right + zLineNumbers_Offset.Width - zTextSize.Width, zLNIs(zA).Rectangle.Bottom - Me.Padding.Bottom + 1 + zLineNumbers_Offset.Height - zTextSize.Height)
                    End Select
                    'TextClipping
                    zItemClipRectangle = New Rectangle(zPoint, zTextSize.ToSize)
                    If zLineNumbers_ClipByItemRectangle = True Then
                        'If selected, the text will be clipped so that it doesn't spill out of its own LineNumberItem-area.
                        'Only the part of the text inside the LineNumberItem.Rectangle should be visible, so intersect with the ItemRectangle
                        'The SetClip method temporary restricts the drawing area of the control for whatever is drawn next.
                        zItemClipRectangle.Intersect(zLNIs(zA).Rectangle)
                        e.Graphics.SetClip(zItemClipRectangle)
                    End If
                    'TextDrawing
                    e.Graphics.DrawString(zTextToShow, Me.Font, zBrush, zPoint, zSF)
                    e.Graphics.ResetClip()
                    'The GraphicsPath for the LineNumber is just a rectangle behind the text, to keep the paintingspeed high and avoid ugly artifacts.
                    zGP_LineNumbers.AddRectangle(zItemClipRectangle)
                    zGP_LineNumbers.CloseFigure()
                End If
            Next

            '--- GridLinesThickness and Linestyle in SeeThroughMode. All GraphicsPath lines are drawn as solid to keep the paintingspeed high.
            If zGridLines_Show = True Then
                zPen.DashStyle = Drawing2D.DashStyle.Solid
                zGP_GridLines.Widen(zPen)
            End If

            '--- Memory CleanUp
            If zLGB IsNot Nothing Then zLGB.Dispose()
        End If

        '----------------------------------------------
        '--- DESIGN OR RUNTIME / ALWAYS
        Dim zP_Left As New Point(Math.Floor(zBorderLines_Thickness / 2), Math.Floor(zBorderLines_Thickness / 2))
        Dim zP_Right As New Point(Me.Width - Math.Ceiling(zBorderLines_Thickness / 2), Me.Height - Math.Ceiling(zBorderLines_Thickness / 2))

        '--- BorderLines 
        Dim zBorderLines_Points() As Point = {New Point(zP_Left.X, zP_Left.Y), New Point(zP_Right.X, zP_Left.Y), New Point(zP_Right.X, zP_Right.Y), New Point(zP_Left.X, zP_Right.Y), New Point(zP_Left.X, zP_Left.Y)}
        If zBorderLines_Show = True Then
            zPen = New Pen(zBorderLines_Color, zBorderLines_Thickness)
            zPen.DashStyle = zBorderLines_Style
            e.Graphics.DrawLines(zPen, zBorderLines_Points)
            zGP_BorderLines.AddLines(zBorderLines_Points)
            zGP_BorderLines.CloseFigure()
            'BorderThickness and Style for SeeThroughMode
            zPen.DashStyle = Drawing2D.DashStyle.Solid
            zGP_BorderLines.Widen(zPen)
        End If

        '--- MarginLines 
        If zMarginLines_Show = True AndAlso zMarginLines_Side > LineNumberDockSide.None Then
            zP_Left = New Point(-zMarginLines_Thickness, -zMarginLines_Thickness)
            zP_Right = New Point(Me.Width + zMarginLines_Thickness, Me.Height + zMarginLines_Thickness)
            zPen = New Pen(zMarginLines_Color, zMarginLines_Thickness)
            zPen.DashStyle = zMarginLines_Style
            If zMarginLines_Side = LineNumberDockSide.Left Or zMarginLines_Side = LineNumberDockSide.Height Then
                e.Graphics.DrawLine(zPen, New Point(Math.Floor(zMarginLines_Thickness / 2) - zMarginLines_SpaceX, 0), New Point(Math.Floor(zMarginLines_Thickness / 2) - zMarginLines_SpaceX, Me.Height - 1))
                zP_Left = New Point(Math.Ceiling(zMarginLines_Thickness / 2), -zMarginLines_Thickness)
            End If
            If zMarginLines_Side = LineNumberDockSide.Right Or zMarginLines_Side = LineNumberDockSide.Height Then
                e.Graphics.DrawLine(zPen, New Point(Me.Width - Math.Ceiling(zMarginLines_Thickness / 2) - zMarginLines_SpaceX, 0), New Point(Me.Width - Math.Ceiling(zMarginLines_Thickness / 2) - zMarginLines_SpaceX, Me.Height - 1))
                zP_Right = New Point(Me.Width - Math.Ceiling(zMarginLines_Thickness / 2), Me.Height + zMarginLines_Thickness)
            End If
            'GraphicsPath for the MarginLines(s):
            'MarginLines(s) are drawn as a rectangle connecting the zP_Left and zP_Right points, which are either inside or 
            'outside of sight, depending on whether the MarginLines at that side is visible. zP_Left: TopLeft and ZP_Right: BottomRight
            zGP_MarginLines.AddRectangle(New Rectangle(zP_Left, New Size(zP_Right.X - zP_Left.X, zP_Right.Y - zP_Left.Y)))
            zPen.DashStyle = Drawing2D.DashStyle.Solid
            zGP_MarginLines.Widen(zPen)
        End If

        '----------------------------------------------
        '--- SeeThroughMode
        'combine all the GraphicsPaths (= zGP_... ) and set them as the region for the control.
        If zSeeThroughMode = True Then
            zRegion.MakeEmpty()
            zRegion.Union(zGP_BorderLines)
            zRegion.Union(zGP_MarginLines)
            zRegion.Union(zGP_GridLines)
            zRegion.Union(zGP_LineNumbers)
        End If

        '--- Region
        If zRegion.GetBounds(e.Graphics).IsEmpty = True Then
            'Note: If the control is in a condition that would show it as empty, then a border-region is still drawn regardless of it's borders on/off state.
            'This is added to make sure that the bounds of the control are never lost (it would remain empty if this was not done).
            zGP_BorderLines.AddLines(zBorderLines_Points)
            zGP_BorderLines.CloseFigure()
            zPen = New Pen(zBorderLines_Color, 1)
            zPen.DashStyle = Drawing2D.DashStyle.Solid
            zGP_BorderLines.Widen(zPen)

            zRegion = New Region(zGP_BorderLines)
        End If
        Me.Region = zRegion

        '----------------------------------------------
        '--- Memory CleanUp
        If zPen IsNot Nothing Then zPen.Dispose()
        If zBrush IsNot Nothing Then zPen.Dispose()
        If zRegion IsNot Nothing Then zRegion.Dispose()
        If zGP_GridLines IsNot Nothing Then zGP_GridLines.Dispose()
        If zGP_BorderLines IsNot Nothing Then zGP_BorderLines.Dispose()
        If zGP_MarginLines IsNot Nothing Then zGP_MarginLines.Dispose()
        If zGP_LineNumbers IsNot Nothing Then zGP_LineNumbers.Dispose()

    End Sub

    '//////////////////////////////////////////////////////////////////////////////////////////////////

    Private Sub zTimer_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles zTimer.Tick
        zParentIsScrolling = False
        zTimer.Stop()
        Me.Invalidate()
    End Sub

    Private Sub zParent_Changed(ByVal sender As Object, ByVal e As System.EventArgs) Handles zParent.Resize, zParent.MultilineChanged ', zParent.DockChanged, zParent.LocationChanged, zParent.Move, zParent.TextChanged
        Me.Refresh()
        Me.Invalidate()
    End Sub

    Private Sub zParent_Scroll(ByVal sender As Object, ByVal e As System.EventArgs) Handles zParent.HScroll, zParent.VScroll
        zParentIsScrolling = True
        Me.Invalidate()
    End Sub

    Private Sub zParent_ContentsResized(ByVal sender As Object, ByVal e As System.Windows.Forms.ContentsResizedEventArgs) Handles zParent.ContentsResized
        zContentRectangle = e.NewRectangle
        Me.Refresh()
        Me.Invalidate()
    End Sub

    Private Sub zParent_Disposed(ByVal sender As Object, ByVal e As EventArgs) Handles zParent.Disposed
        Me.ParentRichTextBox = Nothing
        Me.Refresh()
        Me.Invalidate()
    End Sub

#Region "Suspend-Resume Painting"

    <DllImport("user32.dll")> _
    Private Shared Function SendMessage(ByVal hWnd As IntPtr, ByVal wMsg As Int32, ByVal wParam As Int32, ByRef lParam As Point) As IntPtr
    End Function

    <DllImport("user32.dll")> _
    Private Shared Function SendMessage(ByVal hWnd As IntPtr, ByVal wMsg As Int32, ByVal wParam As Int32, ByVal lParam As IntPtr) As IntPtr
    End Function

    Const WM_USER As Integer = &H400
    Const WM_SETREDRAW As Integer = &HB
    Const EM_GETEVENTMASK As Integer = WM_USER + 59
    Const EM_SETEVENTMASK As Integer = WM_USER + 69
    Const EM_GETSCROLLPOS As Integer = WM_USER + 221
    Const EM_SETSCROLLPOS As Integer = WM_USER + 222

    Private _ScrollPoint As Point
    Private _Painting As Boolean = True
    Private _EventMask As IntPtr
    Private _SuspendIndex As Integer
    Private _SuspendLength As Integer

    Public Sub SuspendPainting()
        If Not _Painting Then
            Return
        End If

        SendMessage(Handle, EM_GETSCROLLPOS, 0, _ScrollPoint)
        SendMessage(Handle, WM_SETREDRAW, 0, IntPtr.Zero)

        _EventMask = SendMessage(Handle, EM_GETEVENTMASK, 0, IntPtr.Zero)
        _Painting = False
    End Sub

    Public Sub ResumePainting()
        If _Painting Then
            Return
        End If

        SendMessage(Handle, EM_SETSCROLLPOS, 0, _ScrollPoint)
        SendMessage(Handle, EM_SETEVENTMASK, 0, _EventMask)
        SendMessage(Handle, WM_SETREDRAW, 1, IntPtr.Zero)

        _Painting = True
        Invalidate()
    End Sub

#End Region

End Class
