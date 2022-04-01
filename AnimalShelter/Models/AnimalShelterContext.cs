using Microsoft.EntityFrameworkCore;
using System;

namespace AnimalShelter.Models
{
  public class AnimalShelterContext : DbContext
  {
    public AnimalShelterContext(DbContextOptions<AnimalShelterContext> options) : base(options)
    {

    }
    protected override async void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<Animal>()
      .HasData(
        new Animal { AnimalId = 1, Type = "Cat", Name = "McCavity", Gender = "Male", Breed = "Ginger Tabby", AdmissionDate = new DateTime(2022, 03, 18)},
        new Animal { AnimalId = 2, Type = "Cat", Name = "Grizabella", Gender = "Female", Breed = "Sokoke", AdmissionDate = new DateTime(2022, 03, 01)},
        new Animal { AnimalId = 3, Type = "Cat", Name = "Mr.Mistopholes", Gender = "Male", Breed = "Tuxedo", AdmissionDate = new DateTime(2022, 03, 06)},
        new Animal { AnimalId = 4, Type = "Dog", Name = "Hubert", Gender = "Male", Breed = "Bloodhound", AdmissionDate = new DateTime(2022, 03, 18)},
        new Animal { AnimalId = 5, Type = "Dog", Name = "Winky", Gender = "Female", Breed = "Terrier",  AdmissionDate = new DateTime(2022, 03, 18)},
        new Animal { AnimalId = 6, Type = "Dog", Name = "Beatrice", Gender = "Female", Breed = "Weimaraner", AdmissionDate = new DateTime(2022, 03, 12)},
        new Animal { AnimalId = 7, Type = "Hamster", Name = "Hamtaro", Gender = "Male", Breed = "Syrian", AdmissionDate = new DateTime(2022, 03, 22)},
        new Animal { AnimalId = 8, Type = "Hamster", Name = "Boss", Gender = "Male", Breed = "Roborovski", AdmissionDate = new DateTime(2022, 03, 22)},
        new Animal { AnimalId = 9, Type = "Hamster", Name = "Howdy", Gender = "Male", Breed = "Syrian",  AdmissionDate = new DateTime(2022, 03, 22)},
        new Animal { AnimalId = 10, Type = "Rabbit", Name = "Roger", Gender = "Male", Breed = "Mini Satin", AdmissionDate = new DateTime(2022, 03, 10)},
        new Animal { AnimalId = 11, Type = "Rabbit", Name = "Thumper", Gender = "Male", Breed = "Netherland Dwarf",  AdmissionDate = new DateTime(2022, 03, 02)},
        new Animal { AnimalId = 12, Type = "Rabbit", Name = "Bunnicula", Gender = "Male", Breed = "Lilac", AdmissionDate = new DateTime(2022, 03, 08) }
      );
    }
    public DbSet<Animal> Animals { get; set; }
  }
}
