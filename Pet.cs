using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace PetClinic
{
    // AC1: Описать модель данных. Основная сущность – Pet.
    // Она должна состоять из простых полей (кличка, вид животного (кошка/собака/птица), дата регистрации)
    // и вложенного объекта (информация о владельце – имя, телефон).
    public class Pet
    {
        [BsonId]
        [BsonIgnoreIfDefault]
        public ObjectId Id { get; set; }

        public string Name { get; set; }

        public Species Species { get; set; }

        public DateTime RegistrationDate { get; set; }

        public Owner Owner { get; set; }
    }
}
