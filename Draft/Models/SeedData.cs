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
                if (!context.Users.Any())
                {
                    context.Users.AddRange(
                        new User
                        {
                            Email = "admin@gmail.com",
                            Username = "admin",
                            Password = "admin",
                        }
                    );
                    context.SaveChanges();

                }
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
                            FirstName = "Kacper",
                            LastName = "Tobiasz",
                            Nationality = "Poland",
                            Age = 21,
                            Height = 191,
                            ClubName = "Legia Warszawa",
                            PositionId = 1,
                            PhotoPath = "https://img.a.transfermarkt.technology/portrait/big/658111-1677702539.jpg?lm=1"
                        },
                        new Player
                        {
                            FirstName = "Ronald",
                            LastName = "Araujo",
                            Nationality = "Uruguay",
                            Age = 25,
                            Height = 192,
                            ClubName = "Fc Barcelona",
                            PositionId = 2,
                            PhotoPath = "https://img.a.transfermarkt.technology/portrait/big/480267-1701118351.jpg?lm=1"
                        },
                        new Player
                        {
                            FirstName = "Jonathan",
                            LastName = "Clauss",
                            Nationality = "France",
                            Age = 31,
                            Height = 178,
                            ClubName = "Marseille",
                            PositionId = 2,
                            PhotoPath = "https://img.a.transfermarkt.technology/portrait/big/175639-1666815234.jpg?lm=1"
                        },
                        new Player
                        {
                            FirstName = "Artur",
                            LastName = "Jedrzejczyk",
                            Nationality = "Poland",
                            Age = 36,
                            Height = 189,
                            ClubName = "Legia Warszawa",
                            PositionId = 2,
                            PhotoPath = "https://img.a.transfermarkt.technology/portrait/big/42401-1677703217.png?lm=1"
                        },
                        new Player
                        {
                            FirstName = "Fikayo",
                            LastName = "Tomori",
                            Nationality = "England",
                            Age = 26,
                            Height = 185,
                            ClubName = "AC Milan",
                            PositionId = 2,
                            PhotoPath = "https://img.a.transfermarkt.technology/portrait/big/303254-1684856117.jpg?lm=1"
                        },
                        new Player
                        {
                            FirstName = "Kamil",
                            LastName = "Glik",
                            Nationality = "Poland",
                            Age = 36,
                            Height = 190,
                            ClubName = "Cracovia",
                            PositionId = 2,
                            PhotoPath = "https://img.a.transfermarkt.technology/portrait/big/46552-1697367546.png?lm=1"
                        },
                        new Player
                        {
                            FirstName = "Bruno",
                            LastName = "Fernandes",
                            Nationality = "Portugal",
                            Age = 29,
                            Height = 179,
                            ClubName = "Manchester United",
                            PositionId = 3,
                            PhotoPath = "https://img.a.transfermarkt.technology/portrait/big/240306-1683882766.jpg?lm=1"
                        },
                        new Player
                        {
                            FirstName = "Jakub",
                            LastName = "Moder",
                            Nationality = "Poland",
                            Age = 25,
                            Height = 191,
                            ClubName = "Brighton",
                            PositionId = 3,
                            PhotoPath = "https://img.a.transfermarkt.technology/portrait/big/384461-1716985274.jpg?lm=1"
                        },
                        new Player
                        {
                            FirstName = "Claude",
                            LastName = "Goncalves",
                            Nationality = "Portugal",
                            Age = 30,
                            Height = 174,
                            ClubName = "Legia Warszawa",
                            PositionId = 3,
                            PhotoPath = "https://img.a.transfermarkt.technology/portrait/big/280178-1629575705.png?lm=1"
                        },
                        new Player
                        {
                            FirstName = "N'Golo",
                            LastName = "Kante",
                            Nationality = "France",
                            Age = 33,
                            Height = 168,
                            ClubName = "Al-Ittihad",
                            PositionId = 3,
                            PhotoPath = "https://img.a.transfermarkt.technology/portrait/big/225083-1703279938.png?lm=1"
                        },
                        new Player
                        {
                            FirstName = "Bartosz",
                            LastName = "Kapustka",
                            Nationality = "Poland",
                            Age = 27,
                            Height = 179,
                            ClubName = "Legia Warszawa",
                            PositionId = 3,
                            PhotoPath = "https://img.a.transfermarkt.technology/portrait/big/246579-1677703549.png?lm=1"
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
                        },
                        new Player
                        {
                            FirstName = "Kylian",
                            LastName = "Mbappe",
                            Nationality = "France",
                            Age = 25,
                            Height = 178,
                            ClubName = "Real Madrid",
                            PositionId = 4,
                            PhotoPath = "https://img.a.transfermarkt.technology/portrait/big/342229-1682683695.jpg?lm=1"
                        },
                        new Player
                        {
                            FirstName = "Erling",
                            LastName = "Haaland",
                            Nationality = "Norway",
                            Age = 23,
                            Height = 195,
                            ClubName = "Manchester City",
                            PositionId = 4,
                            PhotoPath = "https://img.a.transfermarkt.technology/portrait/big/418560-1709108116.png?lm=1"
                        }
                    );
                    context.SaveChanges();

                }
            }
        }

    }
}
