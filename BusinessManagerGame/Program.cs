using System;
using System.Collections.Generic;
using System.Threading;

namespace BusinessManagerGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите имя владельца: ");
            string ownerName = Console.ReadLine();
            Player player = new Player(ownerName, 10000);

            List<Business> businesses = new List<Business>
            {
                new Business("Заправочная станция", 5000, 10)
            };

            Timer timer = new Timer(_ => GenerateIncome(player, businesses), null, 0, 1000);

            while (true)
            {
                Console.Clear();
                Console.WriteLine($"Владелец - {player.Name} имеет {player.Balance}$\n");

                Console.WriteLine("Ваши бизнесы:");
                for (int i = 0; i < businesses.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {businesses[i]}");
                }

                Console.WriteLine("\nВыберите действие:");
                Console.WriteLine("1. Выбрать бизнес для улучшения");
                Console.WriteLine("2. Купить новый бизнес");
                Console.WriteLine("3. Выйти из игры");

                Console.Write("Введите ваш выбор: ");
                int choice;
                if (!int.TryParse(Console.ReadLine(), out choice)) continue;

                switch (choice)
                {
                    case 1:
                        UpgradeBusiness(player, businesses);
                        break;
                    case 2:
                        BuyNewBusiness(player, businesses);
                        break;
                    case 3:
                        Environment.Exit(0);
                        break;
                }
            }
        }

        static void GenerateIncome(Player player, List<Business> businesses)
        {
            foreach (var business in businesses)
            {
                if (DateTime.Now.Subtract(business.LastIncomeTime).TotalSeconds >= business.IncomeInterval)
                {
                    player.Balance += business.Income;
                    business.LastIncomeTime = DateTime.Now;
                    Console.WriteLine($"\n------------------------");
                    Console.WriteLine($"{business.Name} принес доход: {business.Income}$");
                    Console.WriteLine($"Текущий баланс: {player.Balance}$\n");
                }
            }
        }

        static void UpgradeBusiness(Player player, List<Business> businesses)
        {
            Console.Clear();
            Console.WriteLine("Выберите бизнес для улучшения:");

            for (int i = 0; i < businesses.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {businesses[i]}");
            }

            Console.Write("Введите номер бизнеса или 0 для выхода: ");
            int choice;
            if (!int.TryParse(Console.ReadLine(), out choice) || choice <= 0 || choice > businesses.Count) return;

            Business selectedBusiness = businesses[choice - 1];

            Console.Clear();
            Console.WriteLine($"Выберите улучшение для бизнеса {selectedBusiness.Name}:");
            Console.WriteLine("1. Магазин при заправке | Увеличит доход на 300 | Цена 3000$");
            Console.WriteLine("2. Дополнительная колонка | Увеличит доход на 500 | Цена 5000$");
            Console.WriteLine("3. Назад к выбору бизнеса");

            Console.Write("Введите ваш выбор: ");
            if (!int.TryParse(Console.ReadLine(), out choice)) return;

            switch (choice)
            {
                case 1:
                    if (player.Balance >= 3000)
                    {
                        player.Balance -= 3000;
                        selectedBusiness.Income += 300;
                        Console.WriteLine("Улучшение 'Магазин при заправке' куплено.");
                    }
                    else Console.WriteLine("Недостаточно денег!");

                    break;
                case 2:
                    if (player.Balance >= 5000)
                    {
                        player.Balance -= 5000;
                        selectedBusiness.Income += 500;
                        Console.WriteLine("Улучшение 'Дополнительная колонка' куплено.");
                    }
                    else Console.WriteLine("Недостаточно денег!");

                    break;
            }

            Thread.Sleep(2000);
        }

        static void BuyNewBusiness(Player player, List<Business> businesses)
        {
            Console.Clear();
            Console.WriteLine("Доступные для покупки бизнесы:");
            Console.WriteLine("1. Магазин | Доход: 2000$ | Цена: 7000$");
            Console.WriteLine("2. Кофейня | Доход: 4000$ | Цена: 15000$");
            Console.WriteLine("3. Назад в главное меню");

            Console.Write("Введите ваш выбор: ");
            Console.Write("/n");
            int choice;
            if (!int.TryParse(Console.ReadLine(), out choice)) return;

            switch (choice)
            {
                case 1:
                    if (player.Balance >= 7000)
                    {
                        player.Balance -= 7000;
                        businesses.Add(new Business("Магазин", 2000, 10));
                        Console.WriteLine("Бизнес 'Магазин' куплен!");
                    }
                    else Console.WriteLine("Недостаточно денег!");

                    break;
                case 2:
                    if (player.Balance >= 15000)
                    {
                        player.Balance -= 15000;
                        businesses.Add(new Business("Кофейня", 4000, 10));
                        Console.WriteLine("Бизнес 'Кофейня' куплен!");
                    }
                    else Console.WriteLine("Недостаточно денег!");

                    break;
            }

            Thread.Sleep(2000);
        }
    }

    class Player
    {
        public string Name { get; private set; }
        public double Balance { get; set; }

        public Player(string name, double balance)
        {
            Name = name;
            Balance = balance;
        }
    }

    class Business
    {
        public string Name { get; private set; }
        public double Income { get; set; }
        public int IncomeInterval { get; private set; } // В секундах
        public DateTime LastIncomeTime { get; set; }

        public Business(string name, double income, int incomeInterval)
        {
            Name = name;
            Income = income;
            IncomeInterval = incomeInterval;
            LastIncomeTime = DateTime.Now;
        }

        public override string ToString()
        {
            return $"{Name} | доход {Income}$ | приносит доход каждые {IncomeInterval} сек.";
        }
    }
}