# 🎯 Bulls and Cows - Mastermind Game

![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)
![.NET Framework](https://img.shields.io/badge/.NET_Framework-512BD4?style=for-the-badge&logo=.net&logoColor=white)
![Windows Forms](https://img.shields.io/badge/Windows_Forms-0078D6?style=for-the-badge&logo=windows&logoColor=white)
![License](https://img.shields.io/badge/License-MIT-green?style=for-the-badge)

**Classic code-breaking game built with C# Windows Forms**

[![Download](https://img.shields.io/github/v/release/Dan-Ofri/Bulls-And-Cows-CSharp?label=Download&style=for-the-badge&color=success)](https://github.com/Dan-Ofri/Bulls-And-Cows-CSharp/releases/latest)

📖 **Quick Guide:** See [QUICK_START.md](QUICK_START.md)

---

## 📖 About

Bulls and Cows (Mastermind) is a code-breaking game where you guess a secret color combination. Built with **C# Windows Forms**, featuring clean UI, customizable difficulty, and intelligent feedback.

### 🎮 Game Rules
- Computer generates **4 unique colors**
- **Up to 10 attempts** to guess
- Feedback after each guess:
  - **Bulls (V)**: Correct color, correct position
  - **Cows (X)**: Correct color, wrong position
- Win by guessing the code!

---

## ✨ Features

**Gameplay:**
- 8 vibrant colors: Red, Blue, Green, Yellow, Orange, Purple, Light Blue, Pink
- Intelligent Bulls & Cows feedback
- Customizable difficulty (4-10 rounds)
- Real-time duplicate prevention

**Technical:**
- Object-Oriented Design with MVC architecture
- Custom UI components (GuessLine controls)
- Enum-based type-safe color system
- Event-driven responsive UI
- Clean code with proper resource management

---

## 🚀 Quick Start

### Option 1: Download & Play
1. Get [latest release](https://github.com/Dan-Ofri/Bulls-And-Cows-CSharp/releases/latest)
2. Extract ZIP
3. Run `Ex05.exe`

**Windows SmartScreen?** Click "More info" → "Run anyway" (app not digitally signed)

**Requirements:** Windows 7+, .NET Framework 4.7.2

### Option 2: Build from Source

**Prerequisites:** Visual Studio 2019+, .NET Framework 4.7.2

**Using Scripts:**
```batch
git clone https://github.com/Dan-Ofri/Bulls-And-Cows-CSharp.git
cd Bulls-And-Cows-CSharp
build.bat  # Builds the project
run.bat    # Runs the game
```

**Using Visual Studio:**
- Open `.sln` file
- Press `F5` to build and run

---

## 🎮 How to Play

### Setup
1. Launch game
2. Choose number of rounds (4-10)
3. Click "Start Game"

### Gameplay
1. **Select colors** - Click on buttons to choose 4 unique colors
2. **Make guess** - Click arrow to submit
3. **Review feedback**:
   - **V** (Bulls) = Correct color + position
   - **X** (Cows) = Correct color, wrong position
4. **Adjust strategy** - Use feedback to narrow down options
5. **Win** - Match all 4 colors in correct positions!

---

## 🏗️ Architecture

### Project Structure
```
Ex05/
├── UI Components
│   ├── FormBullsAndCows.cs    # Main game window
│   ├── FormSettings.cs        # Difficulty settings
│   ├── GuessLine.cs           # Reusable guess row
│   ├── ColorButton.cs         # Custom color button
│   └── ColorPicker.cs         # Color selection panel
│
├── Game Logic
│   ├── GameLogic.cs           # Core game rules
│   ├── GameSession.cs         # Game state management
│   ├── eColor.cs              # Color enumeration
│   └── ColorUtils.cs          # Helper functions
│
└── Resources
    └── Images/                # UI assets
```

### Class Responsibilities

**GameLogic** - Core game engine
- Generate secret code
- Validate guesses
- Calculate Bulls & Cows

**GameSession** - State management
- Track current round
- Store guess history
- Handle win/loss conditions

**GuessLine** - UI component
- Display color selections
- Show feedback indicators
- Handle user interactions

### Design Patterns

**MVC Architecture:**
```csharp
// Model
public class GameLogic {
    public void CheckGuess(eColor[] guess, out int bulls, out int cows) { }
}

// View
public class GuessLine : UserControl {
    public void DisplayFeedback(int bulls, int cows) { }
}

// Controller
public class FormBullsAndCows : Form {
    private void onGuessSubmitted() {
        m_GameLogic.CheckGuess(currentGuess, out bulls, out cows);
        m_GuessLine.DisplayFeedback(bulls, cows);
    }
}
```

---

## 🛠️ Technologies

- **C# 7.3** - Core language
- **.NET Framework 4.7.2** - Runtime platform
- **Windows Forms** - UI framework
- **Visual Studio 2019+** - IDE

---

## 📚 Learning Outcomes

**OOP Mastery:**
- Custom control development
- Event-driven programming
- Resource management and disposal

**Software Design:**
- MVC architecture pattern
- Separation of concerns
- Reusable components

**Windows Forms:**
- Dynamic UI generation
- User control composition
- Form lifecycle management

---

## 📄 License

MIT License - see [LICENSE](LICENSE) for details.

---

## 👨‍💻 Authors

**Dan Ofri**  
**Tair Mazrahi**

- GitHub: [@Dan-Ofri](https://github.com/Dan-Ofri)
- Email: ofridan@gmail.com

---

## 🙏 Acknowledgments

- **Course:** Object-Oriented Programming in C# and .NET
- **Academic Project:** Year 2, Semester B (2024/2025)
- **Original Game:** Bulls and Cows / Mastermind

---

<div align="center">

**⭐ If you enjoyed this project, please give it a star!**

Made with ❤️ and C#

</div>
