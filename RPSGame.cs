namespace RPS {
    class Game {
        private static bool isPlaying = true;
        private static int score = 0;

        private Game() {}

        ~Game() {}

        enum Objects {
            rock = 0,
            paper = 1,
            scissors = 2
        }

        static void Main(string[] args) {
            System.Random rnd = new System.Random();
            Game game = new Game();
            System.Console.WriteLine("Welcome To Rock, Paper, Scissors!");
            
            while(isPlaying == true) {
                System.Console.WriteLine("Computer pick rock, paper or scissors.");
                int computer = rnd.Next(0, 2);

                System.Console.WriteLine("Player please pick rock, paper, or scissors.");
                string user = System.Console.ReadLine().ToLower();
                
                while((user != "rock") && (user != "scissors") && (user != "paper")) {
                    System.Console.WriteLine("Player please pick rock, paper, or scissors.");
                    user = System.Console.ReadLine().ToLower();
                }

                Objects userNum = game.StrToInt(ref user);
                game.FindWinner(ref computer, ref userNum);
            }

            System.Console.WriteLine("Thank you for playing!");            
        }

        /*
         * Converts the user string into a int
         * 
         * @param user is rock, paper or scissors
         * @return the Objects value
         */
        private Objects StrToInt(ref string user) {
            if(user == "rock") {
                return Objects.rock;
            } else if(user == "paper") {
                return Objects.paper;
            }
            return Objects.scissors;
        }

        /*
        * Determines if the computer or the useris the winner
        * 
        * @param computer is rock, paper or scissors
        * @param user is rock, paper or scissors
        */
        private void FindWinner(ref int computer, ref Objects user) {
            if(computer == 0) {
                switch(user) {
                    case Objects.rock:
                        System.Console.WriteLine("Tie");
                        break;
                    case Objects.paper:
                        System.Console.WriteLine("Lose");
                        score -= 1;
                        break;
                    case Objects.scissors:
                        System.Console.WriteLine("Win");
                        score += 1;
                        break;
                }
            } else if(computer == 1) {
                switch(user) {
                    case Objects.rock:
                        System.Console.WriteLine("Win");
                        score += 1;
                        break;
                    case Objects.paper:
                        System.Console.WriteLine("Tie");
                        break;
                    case Objects.scissors:
                        System.Console.WriteLine("Lose");
                        score -= 1;
                        break;
                }
            } else {
                switch(user) {
                    case Objects.rock:
                        System.Console.WriteLine("Lose");
                        score -= 1;
                        break;
                    case Objects.paper:
                        System.Console.WriteLine("Win");
                        score += 1;
                        break;
                    case Objects.scissors:
                        System.Console.WriteLine("Tie");
                        break;
                }
            }

            System.Console.WriteLine("Your score is " + score);
            System.Console.Write("Play again? Y/N: ");
            string play = System.Console.ReadLine().ToLower();

            while((play != "y") && (play != "n")) {
                System.Console.Write("Play again? Y/N: ");
                play = System.Console.ReadLine().ToLower();
            }

            if(play == "n") {
                isPlaying = false;
            }
        }
    }
}
