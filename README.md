# Tutoring Codes

This repository is a collection of code and materials used during my tutoring lessons, organized by subject tracks.

## Tutoring Subjects

1. `Programming 2 (C++)`
   - C++ exercises and practice solutions (some materials are stored as `.txt` files that contain code snippets).
2. `Programming 3 (C# WinForms + SQLite)`
   - WinForms project examples; database code commonly targets SQLite for local projects.
3. `Software Development 1 (Angular + .NET + MS SQL Server)`
   - Angular frontends paired with .NET backends using MS SQL Server (via EF Core).
4. `Software Development 2 (Flutter + .NET + MS SQL Server)`
   - Flutter/mobile-focused materials paired with a .NET API and MS SQL Server.

## How the repo is organized

- Many folders are named by student and session (dates / semester labels).
- Use search in your editor for keywords like `WinForms`, `@angular`, `SqlServer`, or `Microsoft.Data.Sqlite`.

## 🛠️ Fix for Long File Path Issues on Windows When Cloning This Repository

If you're trying to clone this repository and see an error like:

fatal: unable to checkout working tree
error: unable to create file [...]: Filename too long

This is a common issue on Windows due to the default 260-character path length limit.

---

## ✅ Solution: Enable Long Paths for Git on Windows

### Step 1: Open Command Prompt as Administrator
- Press `Start` and search for **Command Prompt**
- Right-click and choose **Run as administrator**
- Or press `Win + R`, type `cmd`, then press `Ctrl + Shift + Enter`

### Step 2: Run the following command
```bash
git config --system core.longpaths true
```

Now try cloning the repository again:

```bash
git clone https://github.com/vedad-keskin/Tutoring-codes.git
```
