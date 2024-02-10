using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Timers;

class MCQGame
{
    private List<(string Question, string[] Choices, int CorrectAnswer)> questions = new List<(string, string[], int)>();
    private int score = 0;
    private string userName;
    private const string HIGH_SCORE_FILE = "high_score.txt";
    private static readonly List<string> Categories = new List<string> { "Geography", "History", "Science", "Movies" };

    public bool LoadQuestions(string filePath)
    {
        if (!File.Exists(filePath))
        {
            Console.WriteLine($"Error: File '{filePath}' not found.");
            return false;
        }

        try
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    var parts = line.Split('|');
                    if (parts.Length == 6)
                    {
                        string question = parts[0];
                        string[] choices = new string[] { parts[1], parts[2], parts[3], parts[4] };
                        int correctAnswer = int.Parse(parts[5]);
                        questions.Add((question, choices, correctAnswer));
                    }
                }
            }
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error reading file: {ex.Message}");
            return false;
        }
    }

    public void Start()
    {
        Console.WriteLine("Welcome to the Quiz Game!");
        Console.Write("Please enter your name: ");
        userName = Console.ReadLine();

        Console.WriteLine("Choose a category:");
        for (int i = 0; i < Categories.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {Categories[i]}");
        }

        int choice;
        while (true)
        {
            if (int.TryParse(Console.ReadLine(), out choice) && choice >= 1 && choice <= Categories.Count)
            {
                break;
            }
            Console.WriteLine("Invalid choice. Please enter a number between 1 and " + Categories.Count + ":");
        }

        string chosenFile = Categories[choice - 1].ToLower() + ".txt";

        if (!LoadQuestions(chosenFile))
        {
            return; // Exit if unable to load questions
        }

        ConductQuiz();

        // Replay option
        Console.WriteLine("Would you like to play again? (Y/N)");
        if (Console.ReadLine().Trim().ToUpper() == "Y")
        {
            Console.Clear();
            Start(); // Restart the game
        }
    }

    private void ConductQuiz()
    {
        Random rnd = new Random();
        questions = questions.OrderBy(q => rnd.Next()).ToList(); // Randomize the order of questions

        for (int qIndex = 0; qIndex < questions.Count; qIndex++)
        {
            var (Question, Choices, CorrectAnswer) = questions[qIndex];

            Console.WriteLine($"Question {qIndex + 1} of {questions.Count}: {Question}");
            for (int i = 0; i < Choices.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {Choices[i]}");
            }

            int userAnswer;
            while (true)
            {
                Console.Write("Enter your answer (option number): ");
                if (int.TryParse(Console.ReadLine(), out userAnswer) && userAnswer >= 1 && userAnswer <= Choices.Length)
                {
                    break;
                }
                Console.WriteLine("Invalid input. Please enter a number between 1 and " + Choices.Length);
            }

            if (userAnswer == CorrectAnswer)
            {
                Console.WriteLine("Correct!");
                score++;
            }
            else
            {
                Console.WriteLine($"Incorrect. The correct answer is: {CorrectAnswer}");
            }

            Console.WriteLine($"Your current score: {score}/{qIndex + 1}");
            Console.WriteLine("-----------------------------------------------------");
        }

        Console.WriteLine($"Quiz completed, {userName}. Your final score: {score}/{questions.Count}");
        CheckAndUpdateHighScore();
    }

    private void CheckAndUpdateHighScore()
    {
        (string Name, int Score) topScore = ReadHighScorefromFile();

        if (score > topScore.Score)
        {
            Console.WriteLine($"Congratulations, {userName}! You've set a new high score of {score}!");
            WriteHighScoreToFile(userName, score);
        }
        else
        {
            Console.WriteLine($"The current high score is {topScore.Score} by {topScore.Name}.");
        }
    }

    private (string Name, int Score) ReadHighScorefromFile()
    {
        if (File.Exists(HIGH_SCORE_FILE))
        {
            var content = File.ReadAllText(HIGH_SCORE_FILE).Split('|');
            if (content.Length == 2)
            {
                return (content[0], int.Parse(content[1]));
            }
        }
        return ("No one", 0);
    }

    private void WriteHighScoreToFile(string name, int score)
    {
        File.WriteAllText(HIGH_SCORE_FILE, $"{name}|{score}");
    }

    static void Main(string[] args)
    {
        MCQGame game = new MCQGame();
        game.Start();
    }
}