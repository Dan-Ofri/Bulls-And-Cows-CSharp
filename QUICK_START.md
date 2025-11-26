# 🚀 Quick Start - Bulls and Cows

**Get playing in 2 minutes!**

---

## 🎮 For Players

### Windows - Simple Method

**1. Download:**
- Go to [Releases](https://github.com/Dan-Ofri/Bulls-And-Cows-CSharp/releases/latest)
- Download `BullsAndCows-v1.0-Windows.zip`
- Extract ZIP

**2. Run:**
- Double-click `Ex05.exe`

**3. Windows SmartScreen appears?**
- Click **"More info"**
- Click **"Run anyway"**
- This is normal - app isn't digitally signed (safe to run!)

**Requirements:**
- Windows 7+
- .NET Framework 4.7.2 (pre-installed on Win10/11)
- [Download .NET 4.7.2](https://dotnet.microsoft.com/download/dotnet-framework/net472) if needed

---

## 💻 For Developers

### Prerequisites
- Visual Studio 2019+
- .NET Framework 4.7.2 SDK
- Windows 7+

### Method 1: Automated Build ⚡

```batch
# Clone
git clone https://github.com/Dan-Ofri/Bulls-And-Cows-CSharp.git
cd Bulls-And-Cows-CSharp

# Build & Run
build.bat
run.bat
```

### Method 2: Visual Studio

```batch
# Open solution
BullsAndCows.sln

# Press F5 to build and run
```

---

## 🎮 How to Play

**Setup:**
1. Choose rounds (4-10)
2. Click "Start Game"

**Gameplay:**
1. Select 4 unique colors
2. Click arrow to guess
3. Read feedback:
   - **V** = Bull (correct color + position)
   - **X** = Cow (correct color, wrong position)
4. Adjust and repeat
5. Win by matching all colors!

**Strategy Tips:**
- Start with diverse colors
- Use feedback to eliminate options
- Track patterns in Bulls/Cows
- Plan systematic guesses

---

## 🎨 Game Elements

**Available Colors:**
- 🔴 Red
- 🔵 Blue
- 🟢 Green
- 🟡 Yellow
- 🟠 Orange
- 🟣 Purple
- 🔷 Light Blue
- 🌸 Pink

**Feedback:**
- **V** (Bull) = ✅ Right color, right spot
- **X** (Cow) = ⚠️ Right color, wrong spot
- **Blank** = ❌ Color not in code

---

## 📁 Project Structure

```
Ex05/
├── FormBullsAndCows.cs    # Main game
├── FormSettings.cs        # Difficulty select
├── GuessLine.cs           # Guess row UI
├── GameLogic.cs           # Game engine
└── GameSession.cs         # State manager
```

---

## 🔧 Build Options

**Release Build:**
```batch
MSBuild "BullsAndCows.sln" /p:Configuration=Release
```

**Debug Build:**
```batch
MSBuild "BullsAndCows.sln" /p:Configuration=Debug
```

**Clean Build:**
```batch
MSBuild "BullsAndCows.sln" /t:Clean,Build
```

---

## 🐛 Troubleshooting

**Game doesn't start:**
- Install [.NET Framework 4.7.2](https://dotnet.microsoft.com/download/dotnet-framework/net472)
- Check Windows version (7 or later required)

**SmartScreen blocks:**
- Click "More info" → "Run anyway"
- Or right-click `Ex05.exe` → Properties → Unblock

**Build errors:**
- Verify Visual Studio has .NET Desktop Development workload
- Check .NET Framework 4.7.2 SDK is installed

---

## 📚 Full Documentation

- 📖 [README.md](README.md) - Complete documentation
- 🎯 [HOW_TO_CREATE_RELEASE.md](HOW_TO_CREATE_RELEASE.md) - Release guide

---

## 👨‍💻 Authors

**Dan Ofri** & **Tair Mazrahi**  
Email: ofridan@gmail.com  
GitHub: [@Dan-Ofri](https://github.com/Dan-Ofri)

---

**Enjoy the game! 🎉**
