::Abaixo estão todos os comandos para iniciar todas as partes da aplicação

:: Evita que os comandos sejam exibidos no terminal
@echo off

:: Inicializa o Frontend
cd "./Frontend"
start /min cmd /k "npm start"

:: Inicializa o CardCapture (Programa responsável pela captura de imagens)
cd "../CardCapture"
start /min cmd /k "dotnet run"

@REM :: Inicializa o Backend
@REM cd "../Backend"
@REM start /min cmd /k "dotnet run"

@echo Servicos iniciados com sucesso!
pause