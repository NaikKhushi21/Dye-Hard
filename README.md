# Dye Hard

A 2D-platformer survival game featuring a dynamic color-switching mechanic

## Initial Setup

1. Create a empty folder named `DyeHard` in your desired directory
2. In the terminal, navigate to the `DyeHard` folder
3. Run the following command to initialize a new git repository:
```bash
git init
```
4. If the branch is not already set to `main`, run the following command:
```bash
git branch -m master main
```
5. Add the remote repository:
```bash
git remote add origin https://github.com/CSCI-526/pair-prototype-team-dye-hard.git
```
6. Pull the latest changes from the remote repository:
```bash
git pull origin main
```
7. Set the upstream branch to `main`:
```bash
git branch --set-upstream-to origin/main
```
8. Open up Unity Hub, Click on `Add` and select the `DyeHard` folder to add the project
9. Open the project by clicking on the project name in Unity Hub

## Development Workflow

1. Before starting any work, pull the latest changes from the remote repository:
```bash
git pull
```
2. Create a new branch for the feature you are working on:
```bash
git checkout -b feature-name
```
3. Make changes to the project
4. Add the changes to the staging area:
```bash
git add .
```
5. Commit the changes:
```bash
git commit -m "Add your commit message"
```
6. Push the changes to the remote repository:
```bash
git push origin feature-name
```
7. Create a pull request on GitHub and make sure no conflicts exist
8. Merge the pull request once approved

## Resolving Merge Conflicts

1. Pull the latest changes from the remote repository:
```bash
git pull
```
2. Switch to the branch that has the merge conflict:
```bash
git checkout feature-name
```
3. Rebasing the branch with the main branch:
```bash
git rebase main
```
4. Resolve the merge conflicts in the files
5. If needed, continue the rebase by running:
```bash
git rebase --continue
```
6. After resolving the conflicts, push the changes to the remote repository:
```bash
git push origin feature-name
```
7. Create a pull request on GitHub and make sure no conflicts exist
8. Merge the pull request once approved
