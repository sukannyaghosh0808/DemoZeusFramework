#cs ----------------------------------------------------------------------------

 AutoIt Version: 3.3.16.1
 Author:         myName

 Script Function:
	Template AutoIt script.

#ce ----------------------------------------------------------------------------

; Script Start - Add your code below here

WinWaitActive("#32770","file upload",10)
WinFlash("File upload"," ",4,500);
ControlSetText("file upload"," ","Edit1","C:\Users\Sukannya Ghosh\Desktop\patient issue.png")
con("File upload"," ","Button1")