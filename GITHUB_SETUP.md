# 🚀 How to Upload to GitHub

Follow these steps to create your own GitHub repository for this project.

## Step 1: Create GitHub Repository

1. Go to [github.com/new](https://github.com/new)
2. Fill in:
   - **Repository name**: `Bulls-And-Cows-CSharp`
   - **Description**: `🎯 Classic code-breaking game built with C# and Windows Forms`
   - **Visibility**: Public (so recruiters can see it!)
   - **Do NOT** initialize with README (we already have one)
3. Click **Create repository**

## Step 2: Update Remote

Since this project is currently linked to Tair's repository, you need to change it to yours:

```powershell
# Remove old remote
git remote remove origin

# Add your new remote (replace YOUR-USERNAME)
git remote add origin https://github.com/Dan-Ofri/Bulls-And-Cows-CSharp.git

# Verify
git remote -v
```

## Step 3: Commit New Files

```powershell
# Add all new documentation files
git add README.md LICENSE CONTRIBUTING.md docs/

# Commit
git commit -m "docs: Add comprehensive documentation and project setup"

# Commit any code changes
git add Ex05/
git commit -m "feat: Complete Bulls and Cows game implementation"
```

## Step 4: Push to GitHub

```powershell
# Push to main branch (or master, depending on your setup)
git push -u origin main

# If it's 'master' branch instead:
# git push -u origin master

# If you get an error about divergent branches:
git push -u origin main --force
```

## Step 5: Verify on GitHub

Go to your repository page and check:
- ✅ README displays nicely
- ✅ License is recognized (should show "MIT" badge)
- ✅ Code is organized in folders
- ✅ All files are present

## Step 6: Add Topics (Optional but Recommended)

On your GitHub repo page:
1. Click **⚙️ Settings** (top right, near "About")
2. Add topics: `csharp`, `windows-forms`, `game`, `bulls-and-cows`, `mastermind`, `dotnet`
3. These help recruiters find your project!

## Step 7: Add Description & Website

In the "About" section (top right):
- **Description**: `🎯 Classic Mastermind game with intelligent feedback system`
- **Website**: Link to your portfolio or LinkedIn
- **Topics**: (already added in Step 6)

## Optional: Add Screenshots

1. Run the game (`Ex05\bin\Release\Ex05.exe`)
2. Take screenshots using **Win + Shift + S**
3. Save them to `docs/screenshots/` with these names:
   - `start-screen.png`
   - `gameplay.png`
   - `win.png`
   - `color-picker.png`
4. Commit and push:
   ```powershell
   git add docs/screenshots/
   git commit -m "docs: Add gameplay screenshots"
   git push
   ```

## Troubleshooting

### "Repository not found"
- Make sure you created the repo on GitHub first
- Check that your username is correct in the URL

### "Permission denied"
- You might need to authenticate with GitHub
- Use **Personal Access Token** instead of password
- Or set up SSH keys

### "Failed to push some refs"
- Your local branch might be behind
- Try: `git pull origin main --rebase` then push again

---

## Quick Commands Summary

```powershell
# 1. Change remote
git remote remove origin
git remote add origin https://github.com/Dan-Ofri/Bulls-And-Cows-CSharp.git

# 2. Commit everything
git add .
git commit -m "docs: Complete project with documentation"

# 3. Push
git push -u origin main --force
```

---

**🎉 Done! Your project is now on GitHub and looks professional!**
