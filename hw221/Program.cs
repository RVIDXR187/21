using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CardGame21
{
    public struct Card
    {
        public string Suit { get; set; }
        public string Rank { get; set; }
        public int Points { get; set; }

        public Card(string suit, string rank, int points)
        {
            Suit = suit;
            Rank = rank;
            Points = points;
        }

        public override string ToString()
        {
            return $"{Rank} {Suit}";
        }
    }

    public class Deck
    {
        private List<Card> cards = new List<Card>();
        private static string[] suits = { "Черви", "Бубни", "Трефи", "Піки" };
        private static string[] ranks = { "6", "7", "8", "9", "10", "Валет", "Дама", "Король", "Туз" };
        private static Dictionary<string, int> points = new Dictionary<string, int>
        {
            { "6", 6 },
            { "7", 7 },
            { "8", 8 },
            { "9", 9 },
            { "10", 10 },
            { "Валет", 2 },
            { "Дама", 3 },
            { "Король", 4 },
            { "Туз", 11 }
        };

        public Deck()
        {
            GenerateDeck();
        }

        private void GenerateDeck()
        {
            cards.Clear();
            foreach (var suit in suits)
            {
                foreach (var rank in ranks)
                {
                    cards.Add(new Card(suit, rank, points[rank]));
                }
            }
        }

        public void Shuffle()
        {
            Random random = new Random();
            cards = cards.OrderBy(c => random.Next()).ToList();
        }

        public Card DrawCard()
        {
            if (cards.Count == 0)
                throw new InvalidOperationException("Колода порожня");

            Card card = cards[0];
            cards.RemoveAt(0);
            return card;
        }

        public void PrintDeck()
        {
            foreach (var card in cards)
            {
                Console.WriteLine(card);
            }
        }
    }

    public class Player
    {
        public string Name { get; }
        private List<Card> hand = new List<Card>();
        public int TotalPoints => hand.Sum(c => c.Points);

        public Player(string name)
        {
            Name = name;
        }

        public void TakeCard(Card card)
        {
            hand.Add(card);
        }

        public void ShowHand()
        {
            Console.WriteLine($"Карти гравця {Name}:");
            foreach (var card in hand)
            {
                Console.WriteLine(card);
            }
            Console.WriteLine($"Загальна кількість очок: {TotalPoints}\n");
        }

        public bool HasTwoAces()
        {
            return hand.Count(c => c.Rank == "Туз") == 2;
        }

        public void ResetHand()
        {
            hand.Clear();
        }
    }

    public class Game
    {
        private Deck deck;
        private Player player;
        private Player computer;
        private bool playerTurn;
        private int playerWins = 0;
        private int computerWins = 0;

        public Game(string playerName)
        {
            deck = new Deck();
            player = new Player(playerName);
            computer = new Player("Комп'ютер");
        }

        public void StartGame()
        {
            Console.WriteLine("Хто має отримати перші карти? (гравець/комп'ютер): ");
            string firstTurn = Console.ReadLine()?.ToLower();
            playerTurn = firstTurn == "гравець";
            PlayRound();
        }

        private void PlayRound()
        {
            deck.Shuffle();
            player.ResetHand();
            computer.ResetHand();

            player.TakeCard(deck.DrawCard());
            player.TakeCard(deck.DrawCard());
            computer.TakeCard(deck.DrawCard());
            computer.TakeCard(deck.DrawCard());

            while (true)
            {
                if (CheckWinConditions()) return;

                if (playerTurn)
                {
                    PlayerTurn();
                }
                else
                {
                    ComputerTurn();
                }

                playerTurn = !playerTurn;
            }
        }

        private void PlayerTurn()
        {
            player.ShowHand();
            if (CheckWinConditions()) return;

            Console.WriteLine("Хочете ще одну карту? (y/n): ");
            string response = Console.ReadLine()?.ToLower();

            if (response == "y")
            {
                player.TakeCard(deck.DrawCard());
                if (CheckWinConditions()) return;
            }
        }

        private void ComputerTurn()
        {
            computer.ShowHand();
            if (CheckWinConditions()) return;

            if (computer.TotalPoints < 17)
            {
                Console.WriteLine("Комп'ютер бере карту.");
                computer.TakeCard(deck.DrawCard());
                if (CheckWinConditions()) return;
            }
            else
            {
                Console.WriteLine("Комп'ютер зупиняється.");
                DetermineWinner();
            }
        }

        private bool CheckWinConditions()
        {
            if (player.HasTwoAces())
            {
                Console.WriteLine($"{player.Name} переміг з двома тузами!");
                playerWins++;
                return true;
            }

            if (computer.HasTwoAces())
            {
                Console.WriteLine($"Комп'ютер переміг з двома тузами!");
                computerWins++;
                return true;
            }

            if (player.TotalPoints == 21)
            {
                Console.WriteLine($"{player.Name} переміг з 21 очком!");
                playerWins++;
                return true;
            }

            if (computer.TotalPoints == 21)
            {
                Console.WriteLine("Комп'ютер переміг з 21 очком!");
                computerWins++;
                return true;
            }

            if (player.TotalPoints > 21)
            {
                Console.WriteLine($"{player.Name} програв. Перебір (більше 21 очка).");
                computerWins++;
                return true;
            }

            if (computer.TotalPoints > 21)
            {
                Console.WriteLine("Комп'ютер програв. Перебір (більше 21 очка).");
                playerWins++;
                return true;
            }

            return false;
        }

        private void DetermineWinner()
        {
            if (player.TotalPoints > 21)
            {
                Console.WriteLine($"{player.Name} програв. Перебір (більше 21 очка).");
                computerWins++;
            }
            else if (computer.TotalPoints > 21)
            {
                Console.WriteLine("Комп'ютер програв. Перебір (більше 21 очка).");
                playerWins++;
            }
            else if (player.TotalPoints > computer.TotalPoints)
            {
                Console.WriteLine($"{player.Name} переміг з {player.TotalPoints} очками проти {computer.TotalPoints} у комп'ютера!");
                playerWins++;
            }
            else if (computer.TotalPoints > player.TotalPoints)
            {
                Console.WriteLine($"Комп'ютер переміг з {computer.TotalPoints} очками проти {player.TotalPoints} у гравця!");
                computerWins++;
            }
            else
            {
                Console.WriteLine("Нічия! У вас обох однакова кількість очок.");
            }
        }

        public void ShowStatistics()
        {
            Console.WriteLine($"Перемоги гравця: {playerWins}");
            Console.WriteLine($"Перемоги комп'ютера: {computerWins}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

            Console.OutputEncoding = UTF8Encoding.UTF8;

            Console.WriteLine("Ласкаво просимо до гри «21»!");
            Console.Write("Введіть своє ім'я: ");
            string playerName = Console.ReadLine();

            Game game = new Game(playerName);

            while (true)
            {
                game.StartGame();
                Console.WriteLine("Бажаєте грати ще раз? (y/n): ");
                string playAgain = Console.ReadLine()?.ToLower();

                if (playAgain != "y")
                {
                    game.ShowStatistics();
                    break;
                }
            }
        }
    }
}