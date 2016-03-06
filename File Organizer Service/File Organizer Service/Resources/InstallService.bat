@ECHO OFF

REM The following directory is for .NET 2.0
set DOTNETFX=%SystemRoot%\Microsoft.NET\Framework\v4.0.30319
set PATH=%PATH%;%DOTNETFX%

echo # Installing File Organizer Service...
echo ---------------------------------------------------
InstallUtil /i "%~dp0File Organizer Service x64.exe"
echo ---------------------------------------------------
echo # Done!
pause