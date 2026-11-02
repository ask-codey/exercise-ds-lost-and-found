# Exercise: The Lost and Found

Exercise code for the lesson **Exercise: The Lost and Found** in the course *Data Structures and Big-O, Demystified* on [ask-codey.com](https://www.ask-codey.com).

## The ticket

> **From:** the front office
>
> By spring the lost-and-found holds about 800 things, and at lunch 30 students line up at the desk. Each one asks for something by its name and its kind ("Blue Water Bottle, it's a bottle"), and the volunteer digs through one big box. Lunch is 30 minutes; the line doesn't make it.
>
> 1. **Every request is answered in 120 looks or fewer,** whether the desk has the item or not, even with 800 items. Every item the desk looks at counts as a look.
> 2. **Every item handed in gets a tag number** in the desk's log: 0 for the first, then 1, 2, 3, in the order they arrive. A student who brings a tag number gets that item in one step, without anyone looking through the others.
> 3. **Nothing goes missing.** Every item handed in can still be found by its name and kind, and by its tag.

The code that's there is the desk as it works today, in a class called `Desk`: everything goes into one list, `box`, and `find` reads the box from the top. Three methods are yours to change:

- `add` (`Add` in C#): an item is handed in, with its kind
- `find` (`Find`): does the desk have this item? Each item it looks at adds 1 to the desk's count of looks
- `itemWithTag` (`ItemWithTag`, `item_with_tag` in Python): the item with this tag number, in one step

Seven tests check it, ending with the lunch line: 800 items handed in, every one of them asked for, and every answer in 120 looks or fewer.

## Pick your language

The same exercise is here in five languages. Work in the folder for the language you set up; you only need one.

| Folder | Your code | The tests |
|---|---|---|
| `csharp/` | `LostAndFound/Desk.cs` | `LostAndFound.Tests/DeskTests.cs` |
| `java/` | `src/main/java/Desk.java` | `src/test/java/DeskTest.java` |
| `python/` | `lost_and_found.py` | `test_lost_and_found.py` |
| `javascript/` | `lost-and-found.js` | `lost-and-found.test.js` |
| `typescript/` | `lost-and-found.ts` | `lost-and-found.test.ts` |

The comment above each method says what it should do, with examples. Change the code, and write each method's growth rate on its **Growth rate:** line.

Every folder also has a small demo program that tries the desk on eight items. You don't need to change the tests or the demo.

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

At first, 4 of the 7 tests fail: that is expected. Today's desk finds things; it's just too slow, and it doesn't know its tags yet. A failing test's message starts with **Not yet:** and says what it expected.

<details>
<summary>Stuck?</summary>

- **Today's `find` never uses the kind** the student asked for. What if the desk kept things the way students ask for them?
- **Where to look:** the lesson *800 Lost Items and a Line at the Desk: What a Data Structure Is* keeps the items on **shelves by kind**, one labeled list for each kind. With 800 items over 8 kinds, a shelf holds about 100, so a search of one shelf stays under 120 looks.
- **Shelves in code:** a labeled list is a `Dictionary<string, List<string>>` in C#, a `Map<String, List<String>>` in Java, a `dict` in Python and a `Map` in JavaScript and TypeScript. In `add`, if there's no shelf for that kind yet, make an empty one first, then put the item on it.
- **Don't throw the box away.** A tag number is a position in the order things arrived, and only the box keeps that order. Keep both: the box for tags, and the shelves for finding.
- **A tag in one step** is the box at that position, as in *Why "Play Track 750,000" Is Instant and "Find Golden Hour" Isn't: Memory as Mailboxes*. Tags start at 0, so a number below 0, or equal to the number of items or more, has no item.

</details>

<details>
<summary>Why Should I Choose This?</summary>

Open this once your tests are green. The lunch line is 800 items and 30 students, every day.

- **One big box, read from the top:** adding is instant, but a request can take 800 looks, and 30 of them is up to 24,000 looks in one lunch.
- **A list kept in A to Z order by name:** finding an exact name is quick, but every item handed in has to be slotted into its place, and students who say "a water bottle" don't know the exact name.
- **Shelves by kind, plus the box:** each request looks at one shelf, about 100 items at most, and a tag is one step into the box. What it costs: each item is filed twice, and adding takes a moment longer, which is fine for a few items a day.
- **What would beat it:** if students always knew the exact name, a structure that goes straight from a name to its item would answer in one look. That's the hash table, in Module 5.

</details>

## Hand it in

When it works, push your solution to a public repo of your own on GitHub, then paste that repo's address into **Submit your exercise** on the lesson page at [ask-codey.com](https://www.ask-codey.com). That's what completes the lesson. The lesson page shows the Git commands, step by step.
