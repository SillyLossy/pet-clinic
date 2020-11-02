using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace PetClinic
{
    // AC2: Создать репозиторий для работы с коллекцией. Все операции с базой данных должны вызываться через методы репозитория.
    public class PetRepository
    {
        private readonly IMongoCollection<Pet> collection;

        public PetRepository(IMongoDatabase database)
        {
            collection = database.GetCollection<Pet>(nameof(Pet));

            // AC6: Назначить коллекции индексы в соответствии с выполняемыми операциями поиска и сортировки.
            // Индексы должны создаваться автоматически.
            collection.Indexes.CreateMany(new[]
            {
                new CreateIndexModel<Pet>($"{{ {nameof(Pet.RegistrationDate)}: -1 }}"),
                new CreateIndexModel<Pet>($"{{ {nameof(Pet.Species)}: 1 }}")
            });
        }

        public void BulkInsert(IEnumerable<Pet> pets)
        {
            collection.InsertMany(pets);
        }

        public long GetCount()
        {
            return collection.EstimatedDocumentCount();
        }

        // AC4: Через функцию Find реализовать постраничный просмотр записей в коллекции,
        // например по 3 записи на странице. Сортировка – по убыванию даты регистрации.
        public List<Pet> Search(int pageNumber, int pageSize)
        {
            return collection.Find(Builders<Pet>.Filter.Empty)
                             .Sort(Builders<Pet>.Sort.Descending(p => p.RegistrationDate))
                             .Skip(pageSize * pageNumber)
                             .Limit(pageSize)
                             .ToList();
        }

        // AC5: С помощью агрегации данных в коллекции реализовать генерацию отчета –
        // вывести сколько животных определённого вида зарегистрировано в базе.
        // Здесь нужно использовать стадию агрегации Group и функцию Count.
        public List<PetReport> GetReport()
        {
            return collection.Aggregate(new AggregateOptions { AllowDiskUse = true })
                             .Group(p => p.Species, g => new PetReport { Species = g.Key, Count = g.Count() })
                             .ToList();
        }
    }
}
