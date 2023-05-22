using System;

Main();

void Main()
{
    Console.WriteLine();
    Console.WriteLine();
    Console.WriteLine();
    Console.WriteLine();
    Console.WriteLine("Welcome to the Enthusiastic Moose Simulator!");
    Console.WriteLine("--------------------------------------------");
    Console.WriteLine();

    // Let the moose speak!
    // MooseSays("H I, I'M  E N T H U S I A S T I C !");
    // MooseSays("I really am enthusiastic");

    // Ask a question
    createAQuestion("Is Canada real?", "Really? It seems very unlikely.", "I  K N E W  I T !!!");
    createAQuestion("Are you enthusiastic?", "Yay!", "You should try it!");
    createAQuestion("Do you love C# yet?", "Good job sucking up to your instructor!", "You will...oh, yes, you will...");
    createAQuestion("Do you want to know a secret?", "ME TOO!!!! I love secrets...tell me one!", "Oh, no...secrets are the best, I love to share them!");

    WhatsNext();

}


static void WhatsNext()
{
    Console.WriteLine();
    Console.WriteLine("What do you want to do next?");
    Console.WriteLine("Type 'RPS' for Rock Paper Scissors");
    Console.WriteLine("or 'MAGIC' to ask the Magic Moose a question");
    Console.WriteLine("or 'QUIT' to end.");
    Console.Write("Your choice: ");
    string userInput = Console.ReadLine(); // Read the user's input

    if (userInput.ToLower() == "rps") // Validate and parse the user's choice
    {
        RockPaperScissors();
    }

    else if(userInput.ToLower() == "magic")
    {
        MagicMoose();
    }

    else if(userInput.ToLower() == "quit")
    {
       return;
    }

    else
    {
        Console.WriteLine();
        Console.WriteLine("Please enter a valid response or 'QUIT' to end."); // Display an error message for an invalid choice
        WhatsNext();
    }

}

void MooseSays(string message)
{
    Console.WriteLine(
        $@"
                                      _.--^^^--,
                                    .'          `\
  .-^^^^^^-.                      .'              |
 /          '.                   /            .-._/
|             `.                |             |
 \              \          .-._ |          _   \
  `^^'-.         \_.-.     \   `          ( \__/
        |             )     '=.       .,   \
       /             (         \     /  \  /
     /`               `\        |   /    `'
     '..-`\        _.-. `\ _.__/   .=.
          |  _    / \  '.-`    `-.'  /
          \_/ |  |   './ _     _  \.'
               '-'    | /       \ |
                      |  .-. .-.  |
                      \ / o| |o \ /
                       |   / \   |    {message}
                      / `^`   `^` \
                     /             \
                    | '._.'         \
                    |  /             |
                     \ |             |
                      ||    _    _   /
                      /|\  (_\  /_) /
                      \ \'._  ` '_.'
                       `^^` `^^^`
    "
    );
}

bool MooseAsks(string question)
{
    Console.Write($"{question} (Y/N): ");
    string answer = Console.ReadLine().ToLower();

    while (answer != "y" && answer != "n")
    {
        Console.Write($"{question} (Y/N): ");
        answer = Console.ReadLine().ToLower();
    }

    if (answer == "y")
    {
        return true;
    }
    else
    {
        return false;
    }
}

void createAQuestion(string question, string trueResponse, string falseResponse)
{
    bool isTrue = MooseAsks(question);
    if (isTrue)
    {
        MooseSays(trueResponse);
    }
    else
    {
        MooseSays(falseResponse);
    }
}


//---------------------------------------------------------------------------------------------------------------
//---------------------------------------------------MAGIC MOOSE-------------------------------------------------
//---------------------------------------------------------------------------------------------------------------


static void MagicMoose()
{

    Console.WriteLine();
    Console.WriteLine("Welcome to the Magic Moose!"); // Display welcome message
    Console.WriteLine("Ask the Magic Moose any question, or hit ENTER to exit."); // Prompt the user

    string question = GetQuestionFromUser(); // Get the first question from the user

    while (!string.IsNullOrWhiteSpace(question)) // Continue the loop until an empty question is entered
    {
        string response = GetRandomResponse(); // Generate a random response
        Console.WriteLine("Magic Moose says: " + response); // Display the response
        Console.WriteLine();

        question = GetQuestionFromUser(); // Get the next question from the user
    }

    Console.WriteLine();
    Console.WriteLine("Goodbye!"); // Display goodbye message
    WhatsNext(); // Back to "What's next?" selection
}

static string GetQuestionFromUser()
{
    Console.Write("Your question: "); // Prompt the user to enter a question
    return Console.ReadLine(); // Read and return the entered question
}

static string GetRandomResponse()
{
    string[] responses =
    {
        "As I see it, yes.",
        "Ask again later.",
        "Better not tell you now.",
        "Cannot predict now.",
        "Concentrate and ask again.",
        "Don’t count on it.",
        "It is certain.",
        "It is decidedly so.",
        "Most likely.",
        "My reply is no.",
        "My sources say no.",
        "Outlook not so good.",
        "Outlook good.",
        "Reply hazy, try again.",
        "Signs point to yes.",
        "Very doubtful.",
        "Without a doubt.",
        "Yes.",
        "Yes – definitely.",
        "You may rely on it."
    };

    Random random = new Random(); // Create a new instance of Random class
    int index = random.Next(responses.Length); // Generate a random index within the range of the responses array
    return responses[index]; // Return the randomly selected response
}


//---------------------------------------------------------------------------------------------------------------
//-----------------------------------------------ROCK PAPER SCISSORS---------------------------------------------
//---------------------------------------------------------------------------------------------------------------


static void RockPaperScissors()
{
    Console.WriteLine();
    Console.WriteLine("Let's play Rock-Paper-Scissors!"); // Display the initial message

    int userScore = 0; // Variable to track the user's score
    int computerScore = 0; // Variable to track the computer's score

    while (userScore < 3 && computerScore < 3) // Loop until either player reaches a score of 3
    {
        Console.WriteLine("Choose: (1) Rock, (2) Paper, or (3) Scissors"); // Prompt the user to make a choice
        Console.Write("Your choice: ");
        string userInput = Console.ReadLine(); // Read the user's input

        if (int.TryParse(userInput, out int userChoice) && userChoice >= 1 && userChoice <= 3) // Validate and parse the user's choice
        {
            int computerChoice = GetRandomChoice(); // Generate a random choice for the computer

            Console.WriteLine($"Computer chooses: {GetChoiceName(computerChoice)}"); // Display the computer's choice
            Console.WriteLine();
            DisplayArt(userChoice, computerChoice); // Display the ASCII art for the user's choice and the computer's choice
            Console.WriteLine();

            int result = GetRoundResult(userChoice, computerChoice); // Determine the result of the round

            if (result == 0) // If it's a tie
            {
                Console.WriteLine("It's a tie!");
            }
            else if (result == 1) // If the user wins
            {
                Console.WriteLine("You win this round!");
                userScore++; // Increment the user's score
            }
            else // If the computer wins
            {
                Console.WriteLine("Computer wins this round!");
                computerScore++; // Increment the computer's score
            }

            Console.WriteLine();
            Console.WriteLine($"Your score: {userScore}"); // Display the current scores
            Console.WriteLine($"Computer score: {computerScore}");
            Console.WriteLine("-------------------------------");
        }

        else if (userInput.ToLower() == "quit")  
        {
            break; //break out of function (return wasn't ending while loop)
            WhatsNext(); // Back to "What's next?" selection
        }



        else
        {
            Console.WriteLine();
            Console.WriteLine("Invalid choice. Please enter a number from 1 to 3 or 'QUIT' to quit"); // Display an error message for an invalid choice
            Console.WriteLine();
        }
    }

    if (userScore > computerScore) // If the user wins the game (changed to compare)
    {
        Console.WriteLine("YOU WIN!");
    }
    else
    {
        Console.WriteLine("YOU LOSE!"); // If the computer wins the game
    }

    Console.WriteLine("Game Over");
    WhatsNext();
}

static int GetRandomChoice()
{
    Random random = new Random(); // Create an instance of the Random class
    return random.Next(1, 4); // Generate a random number between 1 and 3 (inclusive)
}

static string GetChoiceName(int choice)
{
    switch (choice) // Map the choice number to the corresponding choice name
    {
        case 1:
            return "Rock";
        case 2:
            return "Paper";
        case 3:
            return "Scissors";
        default:
            return string.Empty; // Return an empty string for an invalid choice
    }
}

static int GetRoundResult(int userChoice, int computerChoice)
{
    if (userChoice == computerChoice) // If the choices are the same, it's a tie
    {
        return 0; // Return 0 to represent a tie
    }
    else if (
        (userChoice == 1 && computerChoice == 3)
        || // Check the winning conditions for the user
        (userChoice == 2 && computerChoice == 1)
        || (userChoice == 3 && computerChoice == 2)
    )
    {
        return 1; // Return 1 to represent the user's win
    }
    else // If none of the above conditions are met, the computer wins
    {
        return -1; // Return -1 to represent the computer's win
    }
}

static void DisplayArt(int userChoice, int computerChoice)
{
    string userArt = GetArt(userChoice); // Get the ASCII art for the user's choice
    string computerArt = GetArt(computerChoice); // Get the ASCII art for the computer's choice

    Console.WriteLine("Your choice:");
    Console.WriteLine(userArt); // Display the user's ASCII art
    Console.WriteLine();

    Console.WriteLine("Computer choice:");
    Console.WriteLine(computerArt); // Display the computer's ASCII art
    Console.WriteLine();
}

static string GetArt(int choice)
{
    switch (choice) // Get the ASCII art based on the choice number
    {
        case 1: // Rock
            return @"
    _______
---'   ____)
      (_____)
      (_____)
      (____)
---.__(___)
";
        case 2: // Paper
            return @"
     _______
---'    ____)____
           ______)
          _______)
         _______)
---.__________)
";
        case 3: // Scissors
            return @"
    _______
---'   ____)____
          ______)
       __________)
      (____)
---.__(___)
";
        default:
            return string.Empty; // Return an empty string for an invalid choice
    }
}




