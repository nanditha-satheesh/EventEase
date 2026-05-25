# GitHub Upload Instructions for EventEase

This guide will help you push your EventEase project to GitHub.

## Prerequisites

- Git installed on your computer ([Download Git](https://git-scm.com/downloads))
- A GitHub account ([Sign up at GitHub](https://github.com/signup))
- Command line or terminal access

## Step-by-Step Instructions

### 1. Create a New Repository on GitHub

1. Go to [GitHub](https://github.com) and log in to your account
2. Click the **"+"** icon in the top right corner of the page
3. Select **"New repository"** from the dropdown menu
4. Fill in the repository details:
   - **Repository name**: `EventEase`
   - **Description**: `Modern Event Management System built with ASP.NET Core Blazor and .NET 8`
   - **Visibility**: Choose **Public** (recommended for assignments) or **Private**
   - **DO NOT** check "Initialize this repository with a README" (we already have one)
5. Click **"Create repository"**
6. Copy the repository URL (it will look like `https://github.com/YOUR-USERNAME/EventEase.git`)

### 2. Initialize Git in Your Project

Open your terminal or command prompt and navigate to your EventEase project folder:

```bash
# Navigate to your project directory
cd path/to/EventEase

# Example on Windows:
# cd C:\Users\YourName\source\repos\EventEase

# Example on Mac/Linux:
# cd ~/Projects/EventEase
```

### 3. Initialize Git Repository

```bash
# Initialize a new Git repository
git init
```

You should see: `Initialized empty Git repository in...`

### 4. Configure Git (First Time Only)

If this is your first time using Git, configure your name and email:

```bash
# Set your name
git config --global user.name "Your Name"

# Set your email (use the email associated with your GitHub account)
git config --global user.email "your.email@example.com"
```

### 5. Add Files to Git

```bash
# Add all files to the staging area
git add .

# Check what files are staged (optional)
git status
```

You should see all your project files listed in green.

### 6. Create Your First Commit

```bash
# Commit your changes with a descriptive message
git commit -m "Initial commit: Complete EventEase Event Management System"
```

### 7. Rename Branch to Main (if necessary)

GitHub's default branch is now called `main`. Ensure your branch is named correctly:

```bash
# Rename your branch to main
git branch -M main
```

### 8. Link Your Local Repository to GitHub

Replace `YOUR-USERNAME` with your actual GitHub username:

```bash
# Add the remote origin (replace with your actual repository URL)
git remote add origin https://github.com/YOUR-USERNAME/EventEase.git

# Verify the remote was added correctly
git remote -v
```

You should see:
```
origin  https://github.com/YOUR-USERNAME/EventEase.git (fetch)
origin  https://github.com/YOUR-USERNAME/EventEase.git (push)
```

### 9. Push to GitHub

```bash
# Push your code to GitHub
git push -u origin main
```

You may be prompted to enter your GitHub credentials:
- **Username**: Your GitHub username
- **Password**: Use a Personal Access Token (not your GitHub password)

#### Creating a Personal Access Token (if needed):

1. Go to GitHub Settings → Developer settings → Personal access tokens → Tokens (classic)
2. Click "Generate new token (classic)"
3. Give it a name (e.g., "EventEase Project")
4. Select scopes: check **repo** (full control of private repositories)
5. Click "Generate token"
6. **IMPORTANT**: Copy the token immediately (you won't be able to see it again)
7. Use this token as your password when pushing to GitHub

### 10. Verify Your Upload

1. Go to your GitHub repository in your web browser
2. You should see all your files uploaded
3. The README.md will be displayed on the repository homepage

## Making Future Updates

After making changes to your project, follow these steps to update GitHub:

```bash
# 1. Check what files have changed
git status

# 2. Add the changed files
git add .

# 3. Commit your changes with a descriptive message
git commit -m "Update: Description of what you changed"

# 4. Push to GitHub
git push
```

## Common Git Commands

| Command | Description |
|---------|-------------|
| `git status` | Check the status of your files |
| `git add .` | Add all changed files to staging |
| `git add filename.txt` | Add a specific file to staging |
| `git commit -m "message"` | Commit staged changes with a message |
| `git push` | Push commits to GitHub |
| `git pull` | Pull latest changes from GitHub |
| `git log` | View commit history |
| `git branch` | List all branches |
| `git clone <url>` | Clone a repository from GitHub |

## Troubleshooting

### Issue: "fatal: remote origin already exists"

**Solution:**
```bash
# Remove the existing remote
git remote remove origin

# Add it again with the correct URL
git remote add origin https://github.com/YOUR-USERNAME/EventEase.git
```

### Issue: Authentication Failed

**Solution:** Use a Personal Access Token instead of your password (see step 9 above)

### Issue: "Updates were rejected because the remote contains work that you do not have locally"

**Solution:**
```bash
# Pull the remote changes first
git pull origin main --allow-unrelated-histories

# Then push your changes
git push origin main
```

### Issue: Files Too Large

**Solution:** GitHub has a file size limit. If you have large files:
```bash
# Check which files are large
git ls-files | xargs ls -lh | sort -k5 -hr | head -20

# Consider adding large files to .gitignore
echo "large-file.zip" >> .gitignore
```

## Best Practices

✅ **DO:**
- Write clear, descriptive commit messages
- Commit frequently with small, logical changes
- Keep your .gitignore file updated
- Pull before pushing if working with others
- Review your changes before committing

❌ **DON'T:**
- Commit sensitive information (passwords, API keys)
- Commit generated files (bin/, obj/ folders)
- Use vague commit messages like "update" or "fix"
- Force push unless absolutely necessary

## Git Workflow Example

Here's a typical workflow for making changes:

```bash
# 1. Start working on a feature
git status

# 2. Make your code changes in your editor
# ... edit files ...

# 3. Check what changed
git status
git diff

# 4. Add your changes
git add .

# 5. Commit with a descriptive message
git commit -m "Add: Event filtering functionality with category dropdown"

# 6. Push to GitHub
git push

# 7. Repeat for next feature!
```

## Deleting Files from Git

If you accidentally committed a file you don't want:

```bash
# Remove file from Git but keep it locally
git rm --cached filename.txt

# Remove file from Git and delete it locally
git rm filename.txt

# Commit the removal
git commit -m "Remove unnecessary file"

# Push the change
git push
```

## Additional Resources

- [Git Documentation](https://git-scm.com/doc)
- [GitHub Guides](https://guides.github.com/)
- [Git Cheat Sheet](https://education.github.com/git-cheat-sheet-education.pdf)
- [GitHub Desktop](https://desktop.github.com/) - GUI alternative to command line

## Support

If you encounter issues:
1. Check the [GitHub Help](https://help.github.com/)
2. Search for your error message on [Stack Overflow](https://stackoverflow.com/)
3. Ask in the course discussion forum

---
