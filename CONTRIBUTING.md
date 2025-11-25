# Contributing to Bulls and Cows

Thank you for your interest in contributing to this project! 🎉

## How to Contribute

### 🐛 Reporting Bugs

If you find a bug, please open an issue with:
- Clear description of the problem
- Steps to reproduce
- Expected vs actual behavior
- Screenshots (if applicable)
- Your environment (Windows version, .NET version)

### 💡 Suggesting Features

Feature requests are welcome! Please include:
- Clear use case
- Expected behavior
- Mockups or examples (if applicable)

### 🔧 Pull Requests

1. **Fork the repository**
2. **Create a feature branch**
   ```bash
   git checkout -b feature/amazing-feature
   ```
3. **Make your changes**
   - Follow existing code style
   - Add comments for complex logic
   - Test thoroughly
4. **Commit your changes**
   ```bash
   git commit -m "Add: amazing feature description"
   ```
5. **Push to your fork**
   ```bash
   git push origin feature/amazing-feature
   ```
6. **Open a Pull Request**

## Code Style Guidelines

### C# Conventions
- **Naming**: PascalCase for public members, camelCase for private
- **Indentation**: 4 spaces (no tabs)
- **Braces**: Always use braces, even for single-line blocks
- **Comments**: Use XML documentation for public APIs

### Example
```csharp
/// <summary>
/// Calculates feedback for a given guess
/// </summary>
/// <param name="secretCode">The secret code to compare against</param>
/// <param name="guess">The player's guess</param>
/// <returns>Feedback object with Bulls and Cows</returns>
public Feedback CalculateFeedback(List<eColor> secretCode, List<eColor> guess)
{
    // Implementation
}
```

## Project Structure

```
Ex05/
├── Core Logic      # Business logic (no UI dependencies)
├── UI Components   # Windows Forms classes
├── Configuration   # Constants and enums
└── Entry Point     # Program.cs
```

## Testing

- Manual testing is currently used
- Test all user interactions
- Verify edge cases (rapid clicks, invalid inputs)
- Check win/lose conditions

## Building

```bash
# Debug build
msbuild Ex05.sln /p:Configuration=Debug

# Release build
msbuild Ex05.sln /p:Configuration=Release
```

## Questions?

Feel free to open an issue or contact the maintainer directly.

---

**Thank you for contributing!** 🙏
