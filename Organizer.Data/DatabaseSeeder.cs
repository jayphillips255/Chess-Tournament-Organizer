using Organizer.Data.Models;

namespace Organizer.Data;

public class DatabaseSeeder()
{
    public static void Seed(AppDbContext db)
    {
        if (!db.Tournaments.Any())
        {
            DateTime t1date = new(2024, 12, 5, 14, 0, 0);
            Tournament tournament1 = new() { Name = "Tournament #1", Type = Models.Type.Swiss, DateTime = t1date };
            db.Tournaments.Add(tournament1);
            db.SaveChanges();

            IEnumerable<Player> players = [
                new Player { FirstName = "John", LastName = "Smith", Rating = "1200"},
                new Player { FirstName = "Sarah", LastName = "Johnson", Rating = "1350"},
                new Player { FirstName = "Michael", LastName = "Brown", Rating = "1500"},
                new Player { FirstName = "Emily", LastName = "Davis", Rating = "1650"},
                new Player { FirstName = "David", LastName = "Wilson", Rating = "1800"},
                new Player { FirstName = "Jessica", LastName = "Martinez", Rating = "2000"},
                new Player { FirstName = "James", LastName = "Anderson", Rating = "2200"},
                new Player { FirstName = "Laura", LastName = "Taylor", Rating = "2400"},
            ];

            foreach (var player in players)
            {
                tournament1.Players.Add(player);
            }

            db.SaveChanges();
        }
    }      
}
