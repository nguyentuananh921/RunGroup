using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RunGroupWebAppMVC.Data.Enums;
using RunGroupWebAppMVC.Models;
namespace RunGroupWebAppMVC.Data.Seed
{
    public class SeedData
    {        
        private readonly ApplicationDbContext _context;
        public SeedData(ApplicationDbContext context)
        {
            _context = context;            
        }        
        public void SeedInitialData()
        {
            SeedAddresses();
            SeedClub();
            SeedRace();
        }
        public void SeedAddresses()
        {
            if (!_context.Addresses.Any())
            {
                _context.Addresses.AddRange(new List<Address>()
                {
                    new Address()
                    {
                        //Id=1,
                        Street = "123 Main St",
                        City = "Charlotte",
                        State = "NC"
                    },
                    new Address()
                    {
                        //Id = 2,
                        Street = "123 Main St",
                        City = "Michigan",
                        State = "NC"
                    }

                });
                _context.SaveChanges();
            }
        }
        public void SeedClub()
        {
            if (!_context.Clubs.Any())
            {
                _context.Clubs.AddRange(new List<Club>()
                    {
                        new Club()
                        {
                            Title = "Running Club 1",
                            Image = "https://www.eatthis.com/wp-content/uploads/sites/4/2020/05/running.jpg?quality=82&strip=1&resize=640%2C360",
                            Description = "This is the description of the first cinema",
                            ClubCategory = ClubCategory.City,
                            AddressId=1,                            
                         },
                        new Club()
                        {
                            Title = "Running Club 2",
                            Image = "https://www.eatthis.com/wp-content/uploads/sites/4/2020/05/running.jpg?quality=82&strip=1&resize=640%2C360",
                            Description = "This is the description of the first cinema",
                            ClubCategory = ClubCategory.Endurance,
                            AddressId = 2                            
                        },
                        new Club()
                        {
                            Title = "Running Club 3",
                            Image = "https://www.eatthis.com/wp-content/uploads/sites/4/2020/05/running.jpg?quality=82&strip=1&resize=640%2C360",
                            Description = "This is the description of the first club",
                            ClubCategory = ClubCategory.Trail,
                            AddressId=1                            
                        },
                        new Club()
                        {
                            Title = "Running Club 3",
                            Image = "https://www.eatthis.com/wp-content/uploads/sites/4/2020/05/running.jpg?quality=82&strip=1&resize=640%2C360",
                            Description = "This is the description of the first club",
                            ClubCategory = ClubCategory.City,
                            AddressId=2
                        }
                    });
                _context.SaveChanges();
            }
        }
        public void SeedRace()
        {
            if (!_context.Races.Any())
            {
                _context.Races.AddRange(new List<Race>()
                    {
                        new Race()
                        {
                            Title = "Running Race 1",
                            Image = "https://www.eatthis.com/wp-content/uploads/sites/4/2020/05/running.jpg?quality=82&strip=1&resize=640%2C360",
                            Description = "This is the description of the first race",
                            RaceCategory = RaceCategory.Marathon,
                            AddressId=1
                        },
                        new Race()
                        {
                            Title = "Running Race 2",
                            Image = "https://www.eatthis.com/wp-content/uploads/sites/4/2020/05/running.jpg?quality=82&strip=1&resize=640%2C360",
                            Description = "This is the description of the first race",
                            RaceCategory = RaceCategory.Ultra,
                            AddressId = 2
                        }
                    });
                _context.SaveChanges();
            }
        }       

    }
}

