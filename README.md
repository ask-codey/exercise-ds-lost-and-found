# Exercise: The Lost and Found

Exercise code for the lesson **Exercise: The Lost and Found** in the course *Data Structures and Big-O, Demystified* on [ask-codey.com](https://www.ask-codey.com).

A school's lost-and-found keeps the same eight things three ways: in one jumbled **box**, on **shelves** labeled by kind, and in numbered **cubbies**. You'll write the code that finds things each way, and count how many items each way has to look at. There are three functions to finish:

- `looksInBox` (`LooksInBox` in C#, `looks_in_box` in Python): how many items you look at to find something in the box
- `looksOnShelf` (`LooksOnShelf`, `looks_on_shelf`): how many items you look at when you only search the right shelf
- `itemInCubby` (`ItemInCubby`, `item_in_cubby`): what's in a numbered cubby, in one step

## Pick your language

The same exercise is here in five languages. Work in the folder for the language you set up; you only need one.

| Folder | Your code | The tests |
|---|---|---|
| `csharp/` | `LostAndFound/Finder.cs` | `LostAndFound.Tests/FinderTests.cs` |
| `java/` | `src/main/java/Finder.java` | `src/test/java/FinderTest.java` |
| `python/` | `lost_and_found.py` | `test_lost_and_found.py` |
| `javascript/` | `lost-and-found.js` | `lost-and-found.test.js` |
| `typescript/` | `lost-and-found.ts` | `lost-and-found.test.ts` |

Each function returns `0` or an empty text for now. The comment with it says what it should return, with examples. Replace the `return` line with your own code.

Every folder also has a small demo program that tries your functions on the lost-and-found. You don't need to change the tests or the demo.

## Run it and check your work

Open your language's folder in VS Code (**File > Open Folder**), then open its terminal (**Terminal > New Terminal**) and run these commands there.

**C#**

```bash
dotnet run --project LostAndFound
dotnet test
```

**Java** (the Maven Wrapper downloads Maven the first time, so the first run takes a minute)

```bash
java src/main/java/Demo.java
./mvnw test
```

On Windows in PowerShell, write `.\mvnw test` instead of `./mvnw test`.

**Python** (once: make a virtual environment and install pytest into it)

```bash
python -m venv .venv
```

Then turn it on: `.venv\Scripts\Activate.ps1` in PowerShell on Windows, or `source .venv/bin/activate` on macOS (where the command is `python3`, not `python`). Then:

```bash
pip install -r requirements.txt
python demo.py
python -m pytest
```

**JavaScript**

```bash
node demo.js
npm test
```

**TypeScript** (once: `npm install`, which installs TypeScript)

```bash
node demo.ts
npm test
```

At first every test fails: that is expected. Each function you finish turns its tests green. A failing test's message starts with **Not yet:** and says what it expected.

## Tips

- **Count as you go.** Start a counter at 0, and add one every time you look at an item. Stop as soon as you find the one you want.
- **Look before you reach.** On the shelves, check that the shelf exists before you look on it.
- **Cubbies are numbered from 0,** so eight cubbies are numbered 0 to 7. Your language lets you go straight to one by its number.

## Hand it in

When it works, push your solution to a public repo of your own on GitHub, then paste that repo's address into **Submit your exercise** on the lesson page at [ask-codey.com](https://www.ask-codey.com). That's what completes the lesson. The lesson page shows the Git commands, step by step.
