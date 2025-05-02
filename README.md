# Chess Engine

**Harry Bloomfield**

A fully-featured chess application built to provide a portable, accessible chess experience — whether you're playing casually with a friend or training solo against a bot.

---

## Table of Contents

1. [Overview](#overview)  
2. [Features](#features)  
3. [FEN Integration](#fen-integration)  
4. [Game Rules Support](#game-rules-support)  
5. [Planned Features](#optional-enhancements)  
6. [Getting Started](#getting-started)  
7. [License](#license)

---

## Overview

This project is a desktop chess application developed to simulate both traditional over-the-board play and single-player experiences against a basic AI opponent. Designed with portability in mind, it removes the need for a physical board and adds convenience features such as game saving, FEN position loading, and in-game feedback.

---

## Features

### ✅ Core Functionality

- **Two-Player Mode**: Take alternating turns with enforcement of chess rules.
- **Single-Player Mode**: Play against a computer-controlled opponent.
- **Piece Selection**: Click-based interaction to select and move pieces.
- **Move Validation**: Generates and limits movement to legal moves only.
- **Legal Move Highlighting**: Visual cues show all valid destinations for a selected piece.
- **FEN Parsing and Loading**: Supports Forsyth–Edwards Notation for:
  - Loading custom board positions.
  - Resuming games.
  - Exploring custom or historical positions.
- **Check & Checkmate Detection**: Prevents illegal king movements and identifies game-ending states.
- **Pawn Promotion**: Automatically prompts for a promotion when a pawn reaches the last rank.
- **Win & Draw Conditions**:
  - Displays outcome (Win, Draw, or Stalemate).
  - Recognizes 50-move rule, threefold repetition, insufficient material.
  - Players can agree to a draw or resign.
- **Time Control**: Optional timers for each player, automatically switching on move completion.

---

## FEN Integration

This project makes extensive use of FEN strings to manage game state. A FEN string such as:

```
rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1
```

...encodes:
- **Piece positions**
- **Whose turn it is**
- **Castling availability**
- **En passant targets**
- **Halfmove clock** (for 50-move rule)
- **Fullmove number**

FEN input/output allows users to:
- Start from any arbitrary position
- Save their current game state
- Replay historical games
- Test specific tactical or endgame scenarios

---

## Game Rules Support

This engine adheres closely to official FIDE rules, including:
- No moving into or through check
- Valid castling and en passant handling
- Draw by:
  - Stalemate
  - Insufficient material
  - Repetition
  - 50-move rule

Example Draw FEN (Stalemate):
```
8/8/8/8/8/1k6/2P5/K7 w - - 28 66
```

Example Draw FEN (Insufficient Material):
```
8/8/8/8/2k5/8/8/4K3 w - - 31 42
```

---

## Planned Features

The following features are planned to be immplemented:

- 🎨 **Themes**: Change the board and piece visuals.
- 🎼 **Sound Effects**: Add move and capture sounds for feedback.
- 📥 **FEN Import Dialog**: User-friendly method to input a FEN string directly.
- 🔁 **Move History**: Browse or undo previous moves. 
- 🧠 **Adjustable Bot Difficulty**: Learn and improve at any skill level.

---

## Getting Started

### Requirements
- [.NET 6+](https://dotnet.microsoft.com/)  
- Avalonia UI (if using the GUI version)  
- C# 10+

### Running the App

```bash
git clone https://github.com/hrBloomfield/Chess-CourseWork
cd Chess-CourseWork/UI
dotnet run
```

---

## License

This project is released under the MIT License. See `LICENSE` for more information.
