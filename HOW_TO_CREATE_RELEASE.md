# 📦 How to Create a GitHub Release

This guide explains how to create a new release for Bulls and Cows on GitHub.

## Prerequisites

- ✅ Project built successfully (`build.bat` completed)
- ✅ `Ex05.exe` exists in `Ex05\bin\Release\`
- ✅ All changes committed to Git
- ✅ Logged into GitHub

---

## Step 1: Prepare the Release Package

### Create Release Directory

```batch
# Create a clean directory for the release
mkdir Release-Package
```

### Copy Required Files

```batch
# Copy the main executable
copy "Ex05\bin\Release\Ex05.exe" "Release-Package\"

# Copy the config file
copy "Ex05\bin\Release\Ex05.exe.config" "Release-Package\"

# Copy any DLL dependencies (if they exist)
copy "Ex05\bin\Release\*.dll" "Release-Package\" 2>nul
```

### Create a User README

Create `Release-Package\README.txt` with these contents:

```text
========================================
Bulls and Cows - Classic Code-Breaking Game
Version 1.0.0
========================================

🎮 HOW TO PLAY
--------------
1. Double-click Ex05.exe to start the game
2. Choose number of guesses (difficulty)
3. Try to guess the secret 4-color code
4. Use the feedback to refine your guesses
5. Win by matching all colors correctly!

📋 GAME RULES
-------------
- 🐂 Bull = Correct color in correct position
- 🐄 Cow = Correct color in wrong position
- 8 colors to choose from
- 4 positions to fill

⚙️ REQUIREMENTS
---------------
- Windows 7 or later
- .NET Framework 4.7.2 (usually pre-installed)

If the game doesn't start, download:
https://dotnet.microsoft.com/download/dotnet-framework/net472

🐛 ISSUES & FEEDBACK
--------------------
Report bugs or suggestions at:
https://github.com/Dan-Ofri/Bulls-And-Cows-CSharp/issues

📄 LICENSE
----------
This software is licensed under the MIT License.
See LICENSE file or visit the GitHub repository.

========================================
Developed by: Dan Ofri & Tair Hadad
GitHub: https://github.com/Dan-Ofri/Bulls-And-Cows-CSharp
========================================
```

### Verify Contents

```batch
# Check what's in the release package
dir Release-Package
```

You should see:
- `Ex05.exe` (the game executable)
- `Ex05.exe.config` (configuration file)
- `README.txt` (user instructions)

---

## Step 2: Create ZIP Archive

### Using PowerShell

```powershell
# Create the ZIP file
Compress-Archive -Path "Release-Package\*" -DestinationPath "BullsAndCows-v1.0-Windows.zip" -Force
```

### Verify ZIP

```powershell
# Check ZIP file size
Get-Item "BullsAndCows-v1.0-Windows.zip" | Select-Object Name, @{Name="Size(KB)";Expression={[math]::Round($_.Length/1KB,2)}}
```

Expected size: ~20-30 KB

---

## Step 3: Create GitHub Release

### Navigate to GitHub

1. Go to: `https://github.com/Dan-Ofri/Bulls-And-Cows-CSharp`
2. Click on **"Releases"** (right sidebar)
3. Click **"Draft a new release"**

### Fill Release Details

**Tag version:** `v1.0.0`
- Click "Choose a tag"
- Type: `v1.0.0`
- Select "Create new tag: v1.0.0 on publish"

**Release title:** `🎮 Bulls and Cows v1.0 - First Release`

**Description:** (Use this template)

```markdown
# 🐂 Bulls and Cows - Classic Mastermind Game

**First stable release of Bulls and Cows!**

## 🎯 What's Included

A fully playable Windows desktop game featuring:
- ✅ Classic Bulls and Cows (Mastermind) gameplay
- ✅ Customizable difficulty (4-10 guesses)
- ✅ 8 color options
- ✅ Smart feedback system (Bulls & Cows)
- ✅ Clean Windows Forms UI
- ✅ Custom color picker

## 📥 Download

Download `BullsAndCows-v1.0-Windows.zip` below and extract it.  
Double-click `Ex05.exe` to play!

### ⚠️ Windows SmartScreen Warning
**You'll see "Windows protected your PC" when running the game.**

This is normal! The app isn't digitally signed (costs $$$).

**To run the game:**
1. Click **"More info"**
2. Click **"Run anyway"**

The app is completely safe - all source code is public on this repository!

## ⚙️ Requirements

- **Windows 7 or later**
- **.NET Framework 4.7.2** (usually pre-installed on Windows 10/11)
- If the game doesn't start, [download .NET Framework 4.7.2](https://dotnet.microsoft.com/download/dotnet-framework/net472)

## 🎮 How to Play

1. Choose your difficulty (number of guesses)
2. Click colors to create your guess
3. Submit your guess
4. Use feedback to refine:
   - 🐂 **Bull** = Right color, right position
   - 🐄 **Cow** = Right color, wrong position
5. Break the code to win!

## 🏗️ Technical Details

- **Language**: C# (.NET Framework 4.7.2)
- **UI**: Windows Forms
- **Architecture**: Observer, Factory, Strategy patterns
- **Build**: Visual Studio 2022
- **File Size**: ~25 KB

## 🤝 For Developers

See the [README](https://github.com/Dan-Ofri/Bulls-And-Cows-CSharp#readme) for:
- Architecture overview
- Design patterns used
- How to build from source
- Contributing guidelines

## 📝 Full Changelog

### Features
- Implemented core Bulls and Cows game logic
- Created custom color picker component
- Added configurable difficulty settings
- Implemented smart feedback system
- Designed clean, intuitive UI

### Technical Improvements
- Applied Factory pattern for object creation
- Used Observer pattern for game state updates
- Implemented Strategy pattern for validation
- Separated concerns (UI, Logic, Data)

---

**Enjoy the game!** 🎮

If you encounter any issues, please [open an issue](https://github.com/Dan-Ofri/Bulls-And-Cows-CSharp/issues).
```

### Upload ZIP File

1. Scroll down to **"Attach binaries"**
2. Drag `BullsAndCows-v1.0-Windows.zip` into the box
3. Wait for upload to complete (you'll see a checkmark)

### Publish

1. **Set as latest release**: ✅ (checked)
2. Click **"Publish release"** (green button)

---

## Step 4: Verify Release

### Check Release Page

```powershell
# Verify release via GitHub API
Invoke-RestMethod -Uri "https://api.github.com/repos/Dan-Ofri/Bulls-And-Cows-CSharp/releases/latest" | Select-Object name, tag_name, published_at, @{Name="Assets";Expression={$_.assets.name}}
```

Expected output:
```
name        : 🎮 Bulls and Cows v1.0 - First Release
tag_name    : v1.0.0
published_at: 2025-11-26T...
Assets      : BullsAndCows-v1.0-Windows.zip
```

### Test Download

1. Go to your release page
2. Click on `BullsAndCows-v1.0-Windows.zip` to download
3. Extract and test `Ex05.exe`
4. Verify the game runs correctly

---

## Step 5: Update README (Optional)

Add a download badge to your `README.md`:

```markdown
## 📥 Download

[![Download Latest Release](https://img.shields.io/github/v/release/Dan-Ofri/Bulls-And-Cows-CSharp?label=Download&style=for-the-badge)](https://github.com/Dan-Ofri/Bulls-And-Cows-CSharp/releases/latest)

**[⬇️ Download BullsAndCows-v1.0-Windows.zip](https://github.com/Dan-Ofri/Bulls-And-Cows-CSharp/releases/latest/download/BullsAndCows-v1.0-Windows.zip)**
```

---

## Future Releases

For version 1.1, 1.2, etc.:

1. Update version numbers everywhere:
   - Tag: `v1.1.0`
   - ZIP name: `BullsAndCows-v1.1-Windows.zip`
   - Release title: `🎮 Bulls and Cows v1.1 - ...`

2. Include a changelog:
   - What's new
   - What's fixed
   - What's changed

3. Consider pre-releases for testing:
   - Tag: `v1.1.0-beta`
   - Check "This is a pre-release"

---

## Troubleshooting

### "Failed to upload asset"
- File might be too large (100 MB limit)
- Check internet connection
- Try uploading again

### "Tag already exists"
- You're trying to reuse a version number
- Either delete the old tag or increment the version

### ZIP file is huge
- Make sure you're only including necessary files
- Don't include `.pdb` files (debug symbols)
- Don't include source code in the ZIP

---

**Congratulations!** 🎉 You've published your first release!

Users can now download and play your game without any development tools.
