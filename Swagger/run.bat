@echo OFF

powershell Start-Process -FilePath "start-reverse-proxy.bat"
powershell Start-Process -FilePath "start-sample-webapp-1.bat"
powershell Start-Process -FilePath "start-sample-webapp-2.bat"