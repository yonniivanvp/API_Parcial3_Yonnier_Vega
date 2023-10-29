using API_Parcial3.DAL.Entities;
using System.Net;
using System.Numerics;

namespace API_Parcial3.DAL
{
    public class SeederDB
    {
        private readonly DataBaseContext _context;

        public SeederDB(DataBaseContext context)
        {
            _context = context;
        }

        //Prepopulate the different database tables
        public async Task SeederAsync() 
        {
            //Method that creates the DB immediately the API is executed
            await _context.Database.EnsureCreatedAsync();

            //Create methods that serve to repopulate the DB
            await PopulateHotelsAsync();

            await _context.SaveChangesAsync();
        }

        #region Private Methos
        private async Task PopulateHotelsAsync()
        {
            if (!_context.Hotels.Any())
            {
                _context.Hotels.Add(new Hotel
                {
                    CreatedDate = DateTime.Now,
                    Name = "Hotel El Refugio",
                    Address = "Carrera 100 # 123-456",
                    City = "Bogotá",
                    Phone = 31065432,
                    Stars = 4,

                    Rooms = new List<Room>()
                    {
                        new Room
                        {
                            CreatedDate = DateTime.Now,
                            Number = 103,
                            MaxGuests = 5,
                            Availability = true
                        },
                        new Room
                        {
                            CreatedDate = DateTime.Now,
                            Number = 104,
                            MaxGuests = 3,
                            Availability = false
                        },
                        new Room
                        {
                            CreatedDate = DateTime.Now,
                            Number = 105,
                            MaxGuests = 2,
                            Availability = true
                        }
                    }
                });

                _context.Hotels.Add(new Hotel
                {
                    CreatedDate = DateTime.Now,
                    Name = "Hotel Palmira",
                    Address = "Carrera 100 # 123-ew4w",
                    City = "Medellín",
                    Phone = 121323,
                    Stars = 5,

                    Rooms = new List<Room>()
                    {
                        new Room
                        {
                            CreatedDate = DateTime.Now,
                            Number = 103,
                            MaxGuests = 5,
                            Availability = false
                        },
                        new Room
                        {
                            CreatedDate = DateTime.Now,
                            Number = 104,
                            MaxGuests = 3,
                            Availability = true
                        },
                        new Room
                        {
                            CreatedDate = DateTime.Now,
                            Number = 105,
                            MaxGuests = 2,
                            Availability = false
                        }
                    }
                });

                _context.Hotels.Add(new Hotel
                {
                    CreatedDate = DateTime.Now,
                    Name = "Hotel El Rosario",
                    Address = "Carrera 100 # dsew",
                    City = "Cartagena",
                    Phone = 310653433,
                    Stars = 3,

                    Rooms = new List<Room>()
                    {
                        new Room
                        {
                            CreatedDate = DateTime.Now,
                            Number = 103,
                            MaxGuests = 5,
                            Availability = true
                        },
                        new Room
                        {
                            CreatedDate = DateTime.Now,
                            Number = 104,
                            MaxGuests = 3,
                            Availability = false
                        },
                        new Room
                        {
                            CreatedDate = DateTime.Now,
                            Number = 105,
                            MaxGuests = 2,
                            Availability = true
                        }
                    }
                });
            }
        }
        #endregion
    }
}
