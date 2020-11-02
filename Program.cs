using MongoDB.Driver;
using System;

namespace PetClinic
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("homework");
            var repository = new PetRepository(database);

            var count = repository.GetCount();

            // AC3: При первом запуске приложение должно вставлять данные в коллекцию, если она пуста.
            if (count == 0)
            {
                repository.BulkInsert(SeedData.Pets);
            }

            bool inLoop = true;
            while (inLoop)
            {
                Console.WriteLine();
                Console.WriteLine("1. Посмотреть записи");
                Console.WriteLine("2. Сгенерировать отчет");
                Console.WriteLine("3. Выйти");
                Console.Write("> ");

                var key = Console.ReadKey();
                Console.WriteLine();
                Console.WriteLine();

                switch (key.Key)
                {
                    case ConsoleKey.D1:
                        ViewRecords(repository);
                        break;
                    case ConsoleKey.D2:
                        BuildReport(repository);
                        break;
                    case ConsoleKey.D3:
                        inLoop = false;
                        break;
                }
            }
        }

        private static void ViewRecords(PetRepository repository)
        {
            const int pageSize = 3;
            int lastPageSize, currentPage = 0;

            do
            {
                Console.WriteLine($">> СТРАНИЦА {currentPage + 1} <<");
                var result = repository.Search(currentPage, pageSize);

                foreach (var pet in result)
                {
                    Console.WriteLine($"Питомец: кличка = {pet.Name}, вид = {pet.Species}, зарегистрирован = {pet.RegistrationDate}");
                    Console.WriteLine($"Хозяин: имя = {pet.Owner.Name}, телефон = {pet.Owner.Phone}");
                    Console.WriteLine();
                }

                currentPage++;
                lastPageSize = result.Count;
                Console.WriteLine();
            }
            while (lastPageSize == pageSize);
        }

        private static void BuildReport(PetRepository repository)
        {
            var report = repository.GetReport();

            Console.WriteLine("Отчет:");
            foreach (var entry in report)
            {
                Console.WriteLine($"{entry.Species} - {entry.Count} записей");
            }
        }
    }
}
