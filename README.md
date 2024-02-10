# Terminal Trivia Quest

Welcome to **Terminal Trivia Quest**, a console-based multiple-choice quiz game designed to test your knowledge across various categories including Geography, History, Science, and Movies. Dive into a world of questions, sharpen your mind, and challenge the high scores right from your terminal!

## Features

- **Multiple Categories:** Choose from a variety of topics to test your knowledge in areas of interest.
- **Dynamic Question Pool:** Questions are loaded from text files, making it easy to update or add new content.
- **High Score Tracking:** Beat the high scores and make your mark! High scores are saved and displayed for each session.
- **Replayability:** With a simple command, start a new game anytime and keep the trivia challenge going.
- **Randomized Questions:** Each game session presents questions in a random order, ensuring a unique experience every time.

## Getting Started

### Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download) compatible with C# (Version recommended: .NET 5 or higher)

### Installation

1. Clone the repository to your local machine:
   ```bash
   git clone https://github.com/yourusername/TerminalTriviaQuest.git
   ```
2. Navigate to the cloned repository:
   ```bash
   cd TerminalTriviaQuest
   ```
3. Build the project (optional, if you want to compile the source code):
   ```bash
   dotnet build
   ```

### Running the Game

1. Run the game from the terminal:
   ```bash
   dotnet run
   ```
2. Follow the on-screen instructions to start playing!

## How to Play

1. **Enter Your Name:** Start by typing your name when prompted.
2. **Choose a Category:** Select from the list of available categories to tailor your quiz experience.
3. **Answer Questions:** Use the number keys to select your answer for each multiple-choice question.
4. **Complete the Quiz:** Finish all questions in the selected category to see your score and check if you've set a new high score!

## Adding Your Questions

To add your own questions, edit the corresponding `.txt` files in the project directory. Ensure each question follows the format:

```
Question|Choice1|Choice2|Choice3|Choice4|CorrectAnswerIndex
```

For example:
```
What is the capital of France?|London|Berlin|Paris|Rome|3
```

## License

Distributed under the MIT License. See `LICENSE` for more information.

## Contact

Manjunatha S K - skmanjunath16@gmail.com

Enjoy playing **Terminal Trivia Quest**, and may the best trivia enthusiast win!
