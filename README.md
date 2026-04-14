# CSC360 Final - Mastermind Game

MasterMind is a C# implementation of the classic Mastermind code-breaking game. It is organized as a Visual Studio solution with a main application and a reusable library for the core game logic.

## Solution Structure
- `MasterMind/`  
  Main application project (entry point, user interaction, and game loop).

- `MasterMindLibrary/`  
  Class library containing the core game logic, such as code generation, guess evaluation, and result feedback.

Both projects are configured for `Debug` and `Release` build configurations targeting `Any CPU`.

## Prerequisites

- [Visual Studio 2022](navigational_search:Visual Studio) (or later) with .NET desktop development workload installed.
- .NET SDK compatible with Visual Studio 17.5.2. 

## Getting Started

1. Clone or download this repository.
2. Open `damiasargent_mastermind.sln` in [Visual Studio](navigational_search:Visual Studio).
3. Set the `MasterMind` project as the startup project.
4. Build the solution in either `Debug` or `Release` configuration.
5. Run the project (F5) to start the game.

## Gameplay (Intended)

The main application should:
- Generate a secret code using the logic in `MasterMindLibrary`.
- Prompt the player to make guesses.
- Use the library to evaluate each guess and provide feedback (e.g., correct color and position, correct color, wrong position).
- Track the number of attempts and determine win/lose conditions.

You can extend the library and UI to support different difficulty levels, custom code lengths, or alternative input methods.

## Project Configuration

The solution defines the following configurations:

- `Debug|Any CPU`
- `Release|Any CPU`

Both `MasterMind` and `MasterMindLibrary` are built in each configuration.

## Future Improvements

- Add unit tests for `MasterMindLibrary`.
- Create a richer UI (WPF, WinForms, or web front-end).
