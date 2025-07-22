# 🐲 Monster Manager Console App (C#)

A simple console-based monster management system built in C# for learning purposes.

## 📌 Features

- Add monsters with dynamic stats based on level
- Store monsters by name using a dictionary (`Dictionary<string, List<Monster>>`)
- Remove monsters by name or specific index
- Show all monsters or view a specific group
- Merge two monsters of the same name and level into a stronger version

## 💡 How Merging Works

- Only monsters of the **same type and level** can be merged
- Two monsters combine into one with:
  - `Level = Level + 1`
  - `HP = Level * 10`
  - `ATK = Level + 5`

## 🛠 Technologies

- C# (.NET 6 or newer recommended)
- Console-based interface (no UI)

## 📂 Project Structure

- `Program.cs` – Contains the main logic and menu system
- `Monster` class – Defines monster properties and formatting

## ⚠️ Disclaimer

> This project was created purely for **educational and self-learning purposes**.  
> It is unpolished, not optimized, and lacks advanced error handling or scalability features.  
> That said, it’s a solid demonstration of:
> - Object-oriented programming
> - Dictionary and list manipulation
> - Console app interaction

Feel free to explore, break it, or expand it as you learn.

## 🧠 Author

Made by a self-taught dev working through C# projects to level up 👾
