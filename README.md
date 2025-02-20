# Dye Hard

A 2D-platformer survival game featuring a dynamic color-switching mechanic.

## Gameplay Link 
https://dw1209.github.io/DyeHard/

## Logline

In this 2D Shooting-Survivor, the player survives by smashing through obstacles and matching colors with precision. Player must switch colors to earn ammo, hit different colors consecutively and break blended obstacles in order to score and survive.


## Prototype description

Dye Hard is a 2D Shooting-Survival game featuring a dynamic color-switching mechanic. As the player, the goal is to smash through obstacles while precisely matching their colors. Players have to switch the color of the ball to correspond with the obstacles that appear on screen. As the game progresses, blended colors(combinations of the original three colors) will start to appear so that players have to mix the colors based on their knowledge of colors.


## Controls description

Switch Player Color with Number keys 1(Red), 2(Yellow) and 3(Blue)
Aim Ball with Mouse Position
Shoot Ball with Left Mouse click


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

1. Before starting any work, switch back to "main" branch, pull the latest changes from the remote repository:
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
6. Checkout back to "main" branch and pull the latest changes from the remote repository:
```bash
git checkout main
git pull
```
7. Merge the feature branch with the main branch:
```bash
git merge feature-name
```
8. Push the changes to the remote repository:
```bash
git push
```

## Resolving Merge Conflicts locally

If you see a merge conflict while merging the feature branch with the main branch, use any text editor to resolve the conflicts. After resolving the conflicts, add the changes to the staging area and commit the changes. Then push the changes to the remote repository.

## Names of Team Members

Ying Tu

Daniel Wang

Khushi Naik
