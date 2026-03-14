# Snake Game – Unity C# Technical Test

## Overview

This project is a simple **Snake Game** developed using **Unity and C#** as part of a technical assessment for a Junior C# Developer position.

The objective of the game is to control the snake, collect food to increase the score, and avoid collisions with the borders, Poison food and the snake's own body.

The project focuses on clean code structure, grid-based movement logic, and simple gameplay progression.

---

## Gameplay

* The player controls a snake moving on a grid.
* The snake grows longer each time it eats food.
* The game ends when the snake collides with:

  * The border
  * Its own body
  * Purple food(Poison)
* The player's score increases when food is consumed.

To increase gameplay variety, the game introduces **multiple food types** once the player reaches a higher score.

---

## Food System

The game includes a dynamic food spawning system.

* At the start of the game, a **basic food type** will spawn.
* When the **player's score exceeds 1000**, the game will begin to **randomly spawn one of three food types**.
* Different food types are used to add variety and progression to the gameplay.

---

## Controls

Arrow Keys or WASD – Move the snake

---

## How to Run

1. Clone the repository

2. Open the project using **Unity 6000.3.7f1**

3. Open the scene:

Assets/Scenes/Gameplay.unity

4. Press **Play** in the Unity Editor

---

## Project Architecture

The project is organized with a simple and modular structure to separate responsibilities between systems.

**GameManager**

* Manages overall game state
* Handles score tracking
* Controls restart logic

**SnakeHead**

* Controls snake movement
* Handles player input
* Responsible for growing the snake

**SnakeBody**

* Follows the previous segment of the snake

**GridSystem**

* Maintains grid-based positioning
* Ensures all objects align with the grid

**FoodSpawner**

* Spawns food at random grid positions
* Controls food spawning logic
* Enables additional food types when score > 1000

---

## Core Systems

### Grid-based Movement

The snake moves based on a grid system to ensure consistent movement and accurate collision detection.

### Timer-based Movement

Movement is controlled using a fixed time interval rather than frame updates to maintain consistent speed regardless of frame rate.

---

## Features

* Grid-based snake movement
* Snake growth system
* Score tracking
* Random food spawning
* Multiple food types after score threshold
* Border collision detection
* Self collision detection
* Game restart system

---

## Possible Improvements

If more development time were available, the following improvements could be added:

* Object pooling for snake body segments
* UI improvements and animations
* Sound effects
* Difficulty scaling
* Mobile input support
* High score saving system

---

## Author

Developed by
Aitsarapap Sributta

Unity / C# Technical Test Project
