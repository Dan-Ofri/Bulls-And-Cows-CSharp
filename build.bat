@echo off
REM Build script for Bulls and Cows game
REM Compiles the project using MSBuild in Release configuration

echo ========================================
echo Building Bulls and Cows - Release Mode
echo ========================================
echo.

REM Set MSBuild path
set MSBUILD="C:\Program Files\Microsoft Visual Studio\2022\Enterprise\MSBuild\Current\Bin\MSBuild.exe"

REM Check if MSBuild exists
if not exist %MSBUILD% (
    echo ERROR: MSBuild not found!
    echo Please install Visual Studio 2022 or adjust the path in this script.
    pause
    exit /b 1
)

REM Build the solution
echo Building solution...
%MSBUILD% "BullsAndCows.sln" /p:Configuration=Release /p:Platform="Any CPU" /v:minimal /nologo

if %ERRORLEVEL% neq 0 (
    echo.
    echo ========================================
    echo BUILD FAILED!
    echo ========================================
    pause
    exit /b 1
)

echo.
echo ========================================
echo BUILD SUCCESS!
echo ========================================
echo.
echo Executable created at: Ex05\bin\Release\Ex05.exe
echo.

pause
