# 🎯 Bulls and Cows - Mastermind Game

<div align="center">

![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)
![.NET Framework](https://img.shields.io/badge/.NET_Framework-512BD4?style=for-the-badge&logo=.net&logoColor=white)
![Windows Forms](https://img.shields.io/badge/Windows_Forms-0078D6?style=for-the-badge&logo=windows&logoColor=white)
![License](https://img.shields.io/badge/License-MIT-green?style=for-the-badge)

**A classic code-breaking game built with C# and Windows Forms**

[Features](#-features) • [Installation](#-installation) • [How to Play](#-how-to-play) • [Architecture](#-architecture)

</div>

---

## 📖 About

Bulls and Cows (also known as **Mastermind**) is a classic code-breaking game where you need to guess a secret color combination. This implementation is built using **C# Windows Forms**, featuring a clean UI, customizable difficulty, and intelligent feedback system.

### 🎮 Game Rules

- The computer generates a secret code of **4 unique colors**
- You have **up to 10 attempts** to guess the code
- After each guess, you receive feedback:
  - **Bulls (V)**: Correct color in the correct position
  - **Cows (X)**: Correct color in the wrong position
- Win by guessing the exact code before running out of attempts!

---

## ✨ Features

### 🎨 Core Gameplay
- **8 vibrant colors** to choose from: Red, Blue, Green, Yellow, Orange, Purple, Light Blue, Pink
- **Intelligent feedback system** with Bulls & Cows indicators
- **Customizable difficulty** - choose 4-10 guessing rounds
- **Real-time validation** - prevent duplicate colors in a single guess

### 💻 Technical Highlights
- **Object-Oriented Design** - clean separation of concerns
- **MVC-inspired architecture** - GameLogic, GameSession, UI components
- **Custom UI components** - reusable GuessLine controls
- **Enum-based color system** - type-safe color handling
- **Event-driven programming** - responsive user interactions

### 🛠️ Engineering Features
- **Modular codebase** - easy to extend and maintain
- **Clean code principles** - readable and well-documented
- **Resource management** - proper disposal of UI resources
- **Error handling** - graceful handling of edge cases

---

## 🚀 Installation

### Prerequisites
- **Windows OS** (7/8/10/11)
- **.NET Framework 4.7.2** or higher
- **Visual Studio 2019+** (for development)

### Quick Start

1. **Clone the repository**
   ```bash
   git clone https://github.com/Dan-Ofri/Bulls-And-Cows-CSharp.git
   cd Bulls-And-Cows-CSharp
   ```

2. **Open in Visual Studio**
   - Double-click the `.sln` file in the project root
   - Or from command line: `start *.sln`

3. **Build and Run**
   - Press `F5` or click **Start**
   - Or build manually: `Build → Build Solution`

### Alternative: Run Pre-built Executable
```bash
cd Ex05\bin\Release
Ex05.exe
```

---

## 🎮 How to Play

### 1️⃣ Start the Game
- Choose number of guessing rounds (4-10)
- Click **Start** to begin

### 2️⃣ Make Your Guess
- Click on a **button** to select a color
- Choose from the **color picker** dialog
- Each row represents one guess
- Colors must be unique within a row

### 3️⃣ Analyze Feedback
- **V (Bulls)**: ✅ Right color, right position
- **X (Cows)**: ⚠️ Right color, wrong position
- Empty: ❌ Color not in the code

### 4️⃣ Win or Lose
- **Win**: Guess all colors correctly (4 Bulls)
- **Lose**: Run out of attempts
- New game starts automatically after each round

---

## 🏗️ Architecture

### Project Structure
```
Ex05/
├── Core Logic
│   ├── GameLogic.cs          # Game rules & feedback calculation
│   ├── GameSession.cs        # Session management
│   ├── Board.cs              # Game state tracking
│   └── Feedback.cs           # Feedback data structure
│
├── UI Components
│   ├── StartForm.cs          # Initial setup screen
│   ├── GameBoardForm.cs      # Main game interface
│   ├── ColorPickerForm.cs    # Color selection dialog
│   └── GuessLine.cs          # Reusable guess row control
│
├── Configuration
│   ├── GameSettings.cs       # Global constants
│   ├── eColor.cs             # Color enumeration
│   └── eGameState.cs         # Game state enumeration
│
└── Entry Point
    └── Program.cs            # Application entry
```

### Key Classes

#### `GameLogic` - Core Algorithm
```csharp
public class GameLogic
{
    // Generates random secret code
    public List<eColor> GenerateSecretCode()
    
    // Calculates Bulls & Cows
    public Feedback CalculateFeedback(List<eColor> secretCode, List<eColor> guess)
    
    // Checks win condition
    public bool IsWinningGuess(Feedback feedback)
}
```

#### `GameSession` - State Management
```csharp
public class GameSession
{
    private List<eColor> m_SecretCode;
    private Board m_Board;
    private GameLogic m_Logic;
    
    public void StartNewGame()
    public Feedback ProcessGuess(List<eColor> guess)
    public bool IsGameOver()
}
```

#### `GuessLine` - Custom UI Control
```csharp
public class GuessLine : UserControl
{
    public List<Button> ColorButtons { get; }
    public List<Label> FeedbackLabels { get; }
    
    public void SetFeedback(Feedback feedback)
    public void Lock() // Disable after submission
}
```

### Design Patterns Used
- **Factory Pattern** - Color generation
- **Observer Pattern** - Event handling
- **Composite Pattern** - UI component hierarchy
- **Strategy Pattern** - Feedback calculation

---

## 🧪 Testing

### Manual Testing Checklist
- ✅ Start game with different round counts (4-10)
- ✅ Select colors for each position
- ✅ Verify duplicate color prevention
- ✅ Check feedback accuracy (Bulls & Cows)
- ✅ Test win condition (4 Bulls)
- ✅ Test lose condition (out of attempts)
- ✅ Verify UI responsiveness
- ✅ Test edge cases (rapid clicking, form closing)

### Test Cases
```
Secret Code: [Red, Blue, Green, Yellow]
Guess: [Red, Green, Blue, Yellow]
Expected Feedback: 2 Bulls, 2 Cows ✅

Secret Code: [Purple, Orange, Pink, LightBlue]
Guess: [Purple, Orange, Pink, LightBlue]
Expected Feedback: 4 Bulls (WIN!) ✅
```

---

## 🛠️ Technologies

| Technology | Version | Purpose |
|-----------|---------|---------|
| **C#** | 8.0+ | Primary language |
| **.NET Framework** | 4.7.2 | Runtime environment |
| **Windows Forms** | - | UI framework |
| **Visual Studio** | 2019+ | IDE |
| **Git** | - | Version control |

---

## 📚 Learning Outcomes

This project demonstrates proficiency in:

### Programming Concepts
- ✅ **Object-Oriented Programming** - Classes, inheritance, encapsulation
- ✅ **Event-Driven Programming** - Event handlers, delegates
- ✅ **Collections** - Lists, LINQ operations
- ✅ **Enumerations** - Type-safe constants

### Software Design
- ✅ **Separation of Concerns** - Logic vs UI
- ✅ **Code Reusability** - Custom controls, utility methods
- ✅ **Maintainability** - Clean code, meaningful names
- ✅ **Scalability** - Easy to add new features

### Windows Forms
- ✅ **Custom Controls** - UserControl inheritance
- ✅ **Layout Management** - Dynamic UI generation
- ✅ **Resource Management** - Proper disposal
- ✅ **Theming** - Color management, visual consistency

---

## 🚀 Future Enhancements

- [ ] **Timer Mode** - Add time pressure for advanced players
- [ ] **Difficulty Levels** - Easy (5 colors), Medium (6), Hard (8)
- [ ] **Statistics Tracking** - Win/loss ratio, average attempts
- [ ] **Sound Effects** - Audio feedback for actions
- [ ] **Themes** - Dark mode, custom color schemes
- [ ] **Multiplayer** - Two-player mode (code setter vs guesser)
- [ ] **Hints System** - Optional hints for struggling players
- [ ] **Leaderboard** - Local high scores

---

## 📄 License

This project is licensed under the **MIT License** - see the [LICENSE](LICENSE) file for details.

```
MIT License - Copyright (c) 2025 Dan Ofri

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files...
```

---

## 👨‍💻 Author

**Dan Ofri**
- GitHub: [@Dan-Ofri](https://github.com/Dan-Ofri)
- Portfolio: [More Projects](https://github.com/Dan-Ofri?tab=repositories)

---

## 🙏 Acknowledgments

- **Course**: Object-Oriented Programming in .NET & C#
- **Academic Project**: Year 2, Semester B (2025)
- **Inspiration**: Classic Mastermind board game by Mordecai Meirowitz

---

## 📞 Contact & Support

Have questions or suggestions? Feel free to:
- 🐛 [Open an issue](https://github.com/Dan-Ofri/Bulls-And-Cows-CSharp/issues)
- 💬 [Start a discussion](https://github.com/Dan-Ofri/Bulls-And-Cows-CSharp/discussions)
- 📧 Email me directly

---

<div align="center">

**⭐ If you found this project helpful, please give it a star!**

Made with ❤️ and C#

</div>
