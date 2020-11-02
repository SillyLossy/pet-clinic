using System;
using System.Collections.Generic;

namespace PetClinic
{
    public static class SeedData
    {
        public static readonly List<Pet> Pets = new List<Pet>
        {
            new Pet
            {
                Name = "Garfield",
                Species = Species.Cat,
                RegistrationDate = new DateTime(2020, 10, 20),
                Owner = new Owner
                {
                    Name = "John Arbuckle",
                    Phone = "+38XXXXXXXXX"
                }
            },
            new Pet
            {
                Name = "Odie",
                Species = Species.Dog,
                RegistrationDate = new DateTime(2020, 10, 21),
                Owner = new Owner
                {
                    Name = "John Arbuckle",
                    Phone = "+38XXXXXXXXX"
                }
            },
            new Pet
            {
                Name = "Fido",
                Species = Species.Dog,
                RegistrationDate = new DateTime(2020, 10, 22),
                Owner = new Owner
                {
                    Name = "Will Smith",
                    Phone = "+38XXXXXXXXX"
                }
            },
            new Pet
            {
                Name = "Spica",
                Species = Species.Bird,
                RegistrationDate = new DateTime(2020, 10, 23),
                Owner = new Owner
                {
                    Name = "Milla Basset",
                    Phone = "+38XXXXXXXXX"
                }
            },
            new Pet
            {
                Name = "Lilac",
                Species = Species.Bird,
                RegistrationDate = new DateTime(2020, 10, 24),
                Owner = new Owner
                {
                    Name = "Carol Tea",
                    Phone = "+38XXXXXXXXX"
                }
            },
            new Pet
            {
                Name = "Neny",
                Species = Species.Cat,
                RegistrationDate = new DateTime(2020, 10, 25),
                Owner = new Owner
                {
                    Name = "Leslie Miller",
                    Phone = "+38XXXXXXXXX"
                }
            },
            new Pet
            {
                Name = "Linn",
                Species = Species.Cat,
                RegistrationDate = new DateTime(2020, 10, 26),
                Owner = new Owner
                {
                    Name = "Leslie Miller",
                    Phone = "+38XXXXXXXXX"
                }
            },
            new Pet
            {
                Name = "Spott",
                Species = Species.Dog,
                RegistrationDate = new DateTime(2020, 10, 27),
                Owner = new Owner
                {
                    Name = "Lewis Spencer",
                    Phone = "+38XXXXXXXXX"
                }
            }
        };
    }
}
