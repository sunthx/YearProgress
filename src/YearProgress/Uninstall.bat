@echo off

"%~dp0\RegAsm.exe" /nologo /unregister "YearProgress.dll"

taskkill /f /im "explorer.exe"
start explorer.exe

Pause