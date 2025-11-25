# 🚀 Quick Start Guide - Bulls and Cows

**Get started playing in 2 minutes!**

## For Players (Non-Developers)

### Windows Users - Simple Method

1. **Download the Game**
   - Go to [Releases](https://github.com/Dan-Ofri/Bulls-And-Cows-CSharp/releases)
   - Download `BullsAndCows-v1.0-Windows.zip`
   - Extract the ZIP file to any folder

2. **Run the Game**
   - Double-click `Ex05.exe`
   - **That's it!** The game should start immediately

3. **If Windows SmartScreen appears:**
   - Click "More info" → "Run anyway"
   - (This happens because the app isn't digitally signed)

### Requirements
- **Windows 7 or later**
- **.NET Framework 4.7.2** (usually pre-installed on Windows 10/11)
- If the game doesn't start, download [.NET Framework 4.7.2](https://dotnet.microsoft.com/download/dotnet-framework/net472)

---

## For Developers

### Prerequisites
- **Visual Studio 2022** (Community/Professional/Enterprise)
- **.NET Framework 4.7.2 SDK**
- **Windows 7 or later**

### Method 1: Automated Build (Fastest! ⚡)

```batch
# Clone the repository
git clone https://github.com/Dan-Ofri/Bulls-And-Cows-CSharp.git
cd Bulls-And-Cows-CSharp

# Build the project
build.bat

# Run the game
run.bat
```

**That's it!** The `build.bat` script handles everything automatically.

### Method 2: Visual Studio

1. **Open the Solution**
   ```batch
   # Double-click this file:
   Ex05 Dan 322527227 Tair 212096234.sln
   ```

2. **Build and Run**
   - Press `F5` (Debug) or `Ctrl+F5` (Release)
   - Or: Right-click solution → Build Solution

### Method 3: Manual Build

```batch
# Navigate to project directory
cd path\to\Bulls-And-Cows-CSharp

# Build using MSBuild
"C:\Program Files\Microsoft Visual Studio\2022\Enterprise\MSBuild\Current\Bin\MSBuild.exe" ^
  "Ex05 Dan 322527227 Tair 212096234.sln" ^
  /p:Configuration=Release /p:Platform="Any CPU"

# Run the executable
.\Ex05\bin\Release\Ex05.exe
```

---

## How to Play

### Game Rules
Bulls and Cows is a classic code-breaking game (like Mastermind):

1. **Objective**: Guess the secret 4-color code
2. **Available Colors**: 8 colors to choose from
3. **Feedback After Each Guess**:
   - 🐂 **Bulls**: Correct color in correct position
   - 🐄 **Cows**: Correct color in wrong position

### Controls
- **Left Mouse Click**: Select colors for your guess
- **Right Mouse Click**: Submit your guess
- **Number of Guesses**: Choose difficulty (4-10 attempts)

### Winning
- Match all 4 colors in the correct positions!
- Try to win in the fewest guesses possible

---

## Troubleshooting

### "The application was unable to start correctly"
**Solution**: Install [.NET Framework 4.7.2](https://dotnet.microsoft.com/download/dotnet-framework/net472)

### "Windows protected your PC"
**Solution**: Click "More info" → "Run anyway"  
(The app is safe - it's just not digitally signed)

### Build Errors
**Solution**: 
1. Make sure Visual Studio 2022 is installed
2. Verify .NET Framework 4.7.2 SDK is installed
3. Run `build.bat` as Administrator

### Game Doesn't Start
**Solution**:
1. Check if `Ex05.exe` exists in `Ex05\bin\Release\`
2. If not, run `build.bat` first
3. Make sure you have .NET Framework 4.7.2 installed

---

## What's Next?

- 📖 Read the full [README.md](README.md) for architecture details
- 🤝 Want to contribute? See [CONTRIBUTING.md](CONTRIBUTING.md)
- 🐛 Found a bug? [Open an issue](https://github.com/Dan-Ofri/Bulls-And-Cows-CSharp/issues)
- ⭐ Like the game? Give us a star on GitHub!

---

## Project Structure

```
Bulls-And-Cows-CSharp/
├── Ex05/                      # Main source code
│   ├── *.cs                   # C# source files
│   ├── *.Designer.cs          # Windows Forms designers
│   ├── *.resx                 # Resource files
│   └── bin/Release/Ex05.exe   # Compiled game
├── build.bat                  # Automated build script
├── run.bat                    # Run the game
├── README.md                  # Full documentation
└── QUICK_START.md            # This file
```

---

**Enjoy the game! 🎮**
