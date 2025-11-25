@echo off
REM Run script for Bulls and Cows game
REM Executes the compiled game

echo ========================================
echo Running Bulls and Cows
echo ========================================
echo.

REM Check if Release build exists
if exist "Ex05\bin\Release\Ex05.exe" (
    echo Starting game from Release build...
    echo.
    start "" "Ex05\bin\Release\Ex05.exe"
    exit /b 0
)

REM Check if Debug build exists
if exist "Ex05\bin\Debug\Ex05.exe" (
    echo Starting game from Debug build...
    echo.
    start "" "Ex05\bin\Debug\Ex05.exe"
    exit /b 0
)

REM No build found
echo ERROR: Executable not found!
echo.
echo Please build the project first using:
echo   - build.bat (automated build)
echo   - Or open the solution in Visual Studio and build it
echo.
pause
exit /b 1
