using Draft.Data;
using Microsoft.EntityFrameworkCore;

namespace Draft.Models
{
    public class SeedData
    {

        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new DraftContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<DraftContext>>()))
            {
                
                if (!context.Positions.Any())
                {              
                    context.Positions.AddRange(
                        new Position
                        {
                            Name = "Goalkeeper",
                        },
                        new Position
                        {
                            Name = "Deffender ",
                        },
                        new Position
                        {
                            Name = "Midfielder",
                        },
                        new Position
                        {
                            Name = "Forward ",
                        }
                    );
                    context.SaveChanges();

                }

                if (!context.Players.Any())
                {
                
                    context.Players.AddRange(
                        new Player
                        {
                            FirstName = "Wojciech",
                            LastName = "Szczesny",
                            Nationality = "Poland",
                            Age = 34,
                            Height = 196,
                            ClubName = "Juventus",
                            PositionId = 1,
                            PhotoPath = "https://img.a.transfermarkt.technology/portrait/header/44058-1595847517.jpg?lm=1"
                        },
                        new Player
                        {
                            FirstName = "Robert",
                            LastName = "Lewandowski",
                            Nationality = "Poland",
                            Age = 35,
                            Height = 185,
                            ClubName = "Barcelona",
                            PositionId = 4,
                            PhotoPath = "https://img.a.transfermarkt.technology/portrait/header/38253-1701118759.jpg?lm=1"
                        }                 
                    );
                    context.SaveChanges();

                }
            }
        }

    }
}
