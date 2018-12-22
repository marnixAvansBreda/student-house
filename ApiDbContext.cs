using System;
using Microsoft.EntityFrameworkCore;
using StudentHouse.Models;

namespace StudentHouse
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MealEntity>()
                .HasOne(m => m.Chef)
                .WithMany(c => c.MealsAsChef)
                .HasForeignKey(m => m.ChefId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<MealGuestEntity>()
                .HasKey(mg => new { mg.MealId, mg.GuestId });

            modelBuilder.Entity<MealGuestEntity>()
                .HasOne(mg => mg.Meal)
                .WithMany(m => m.Guests)
                .HasForeignKey(mg => mg.MealId);

            modelBuilder.Entity<MealGuestEntity>()
                .HasOne(mg => mg.Guest)
                .WithMany(g => g.MealsAsGuest)
                .HasForeignKey(mg => mg.GuestId);

            var abbey = new StudentEntity { Id = Guid.Parse("6f1e369b-29ce-4d43-b027-3756f03899a1"), CreatedAt = DateTime.Now, Name = "Abbey", EMail = "Abbey@gmail.com", PhoneNumber = "0612345678" };
            var ahmad = new StudentEntity { Id = Guid.Parse("9902719d-959c-4f28-b3f9-c5c8217df377"), CreatedAt = DateTime.Now, Name = "Ahmad", EMail = "Ahmad@gmail.com", PhoneNumber = "0634986134" };
            var dolly = new StudentEntity { Id = Guid.Parse("8f6dcad1-c920-411c-9d00-c6b3a841cd88"), CreatedAt = DateTime.Now, Name = "Dolly", EMail = "Dolly@gmail.com", PhoneNumber = "0613354975" };
            var twila = new StudentEntity { Id = Guid.Parse("635158c3-e28e-46fd-808e-c18b1722392c"), CreatedAt = DateTime.Now, Name = "Twila", EMail = "Twila@gmail.com", PhoneNumber = "0632164994" };

            var macaroni = new MealEntity { Id = Guid.Parse("e59e07df-cf1c-412c-b7b3-e216ecf1facf"), Name = "Macaroni", Description = "Delicious pasta from Italy!", Price = 3, MaxAmountOfGuests = 5, DateTime = new DateTime(2018, 11, 17), ChefId = abbey.Id };
            var schnitzel = new MealEntity { Id = Guid.Parse("b6296516-9b2a-4f17-bc15-5e70d397051a"), Name = "Schnitzel", Description = "Classic schnitzel from Germany", Price = 4.5, MaxAmountOfGuests = 5, DateTime = new DateTime(2018, 11, 18), ChefId = dolly.Id };
            var sushi = new MealEntity { Id = Guid.Parse("58067c81-ac5e-40b5-afbf-f73bc2d333e5"), Name = "Sushi", Description = "A Japanese dish with raw fish", Price = 5, MaxAmountOfGuests = 3, DateTime = new DateTime(2018, 11, 19), ChefId = dolly.Id };

            modelBuilder.Entity<StudentEntity>().HasData(abbey, dolly, twila, ahmad);
            modelBuilder.Entity<MealEntity>().HasData(macaroni, schnitzel, sushi);
            modelBuilder.Entity<MealGuestEntity>().HasData(
                new MealGuestEntity { MealId = macaroni.Id, GuestId = dolly.Id },
                new MealGuestEntity { MealId = macaroni.Id, GuestId = twila.Id },
                new MealGuestEntity { MealId = schnitzel.Id, GuestId = ahmad.Id },
                new MealGuestEntity { MealId = schnitzel.Id, GuestId = twila.Id },
                new MealGuestEntity { MealId = sushi.Id, GuestId = ahmad.Id },
                new MealGuestEntity { MealId = sushi.Id, GuestId = abbey.Id },
                new MealGuestEntity { MealId = sushi.Id, GuestId = twila.Id }
            );
        }

        public DbSet<StudentEntity> Students { get; set; }

        public DbSet<MealEntity> Meals { get; set; }
    }
}
