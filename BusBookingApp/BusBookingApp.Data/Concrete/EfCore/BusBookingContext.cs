using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusBookingApp.Entity;
using Microsoft.EntityFrameworkCore;

namespace BusBookingApp.Data.Concrete.EfCore
{
    public class BusBookingContext : DbContext
    {
        public BusBookingContext(DbContextOptions options):base(options)
        {
            
        }
        public DbSet<TravelDetail> TravelDetails { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Bus> Buses { get; set; }
        public DbSet<CompanyIntroduction> CompanyIntroductions { get; set; }
        public DbSet<Support> Supports { get; set; }
        public DbSet<Contact> Contacts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Bus>()
                .HasData(
                    new Bus() {BusId=1, BusSeatCapacity = 36},
                    new Bus() {BusId=2, BusSeatCapacity = 48}
                );

            modelBuilder
                .Entity<City>()
                .HasData(
                    new City() {CityId=1, CityName = "İstanbul"},

                    new City() {CityId=2, CityName = "Bursa"},
                    new City() {CityId=3, CityName = "Balıkesir"},
                    new City() {CityId=4, CityName = "Manisa"},
                    new City() {CityId=5, CityName = "İzmir"},

                    new City() {CityId=6, CityName = "Bolu"},
                    new City() {CityId=7, CityName = "Samsun"},
                    new City() {CityId=8, CityName = "Ordu"},
                    new City() {CityId=9, CityName = "Rize"},

                    new City() {CityId=10, CityName = "Eskişehir"},
                    new City() {CityId=11, CityName = "Afyon"},
                    new City() {CityId=12, CityName = "Isparta"},
                    new City() {CityId=13, CityName = "Antalya"}
                );

            modelBuilder
                .Entity<Customer>()
                .HasData(
                    new Customer() { CustomerId = 1, CustomerName = "Ahmet", CustomerSurname = "Yılmaz", PhoneNumber = "5547455843", Email = "deneme@gmail.com" },
                    new Customer() { CustomerId = 2, CustomerName = "Mert", CustomerSurname = "Yılan", PhoneNumber = "5547455843", Email = "deneme2@gmail.com" },
                    new Customer() { CustomerId = 3, CustomerName = "Hakkı", CustomerSurname = "Metin", PhoneNumber = "5547455843", Email = "deneme3@gmail.com" },
                    new Customer() { CustomerId = 4, CustomerName = "Mustafa", CustomerSurname = "Yıldırım", PhoneNumber = "5547455843", Email = "deneme4@gmail.com" },
                    new Customer() { CustomerId = 5, CustomerName = "Caner", CustomerSurname = "Şimşek", PhoneNumber = "5547455843", Email = "deneme5@gmail.com" },
                    new Customer() { CustomerId = 6, CustomerName = "Berk", CustomerSurname = "Ok", PhoneNumber = "5547455843", Email = "deneme6@gmail.com" },
                    new Customer() { CustomerId = 7, CustomerName = "Semih", CustomerSurname = "Yay", PhoneNumber = "5547455843", Email = "deneme7@gmail.com" }
                );

            modelBuilder
                .Entity<Ticket>()
                .HasData(
                     new Ticket() {TicketId=1, CustomerId=1, SeatNumber=15, TravelDetailId=1},
                     new Ticket() {TicketId=2, CustomerId=2, SeatNumber=11, TravelDetailId=1},
                     new Ticket() {TicketId=3, CustomerId=3, SeatNumber=13, TravelDetailId=1},

                     new Ticket() {TicketId=4, CustomerId=3, SeatNumber=13, TravelDetailId=2},
                     new Ticket() {TicketId=5, CustomerId=4, SeatNumber=14, TravelDetailId=2},
                     new Ticket() {TicketId=6, CustomerId=5, SeatNumber=15, TravelDetailId=2},

                     new Ticket() {TicketId=7, CustomerId=4, SeatNumber =1, TravelDetailId=3},
                     new Ticket() {TicketId=8, CustomerId=5, SeatNumber =2, TravelDetailId=3},
                     new Ticket() {TicketId=9, CustomerId=6, SeatNumber =3, TravelDetailId=3},
                     new Ticket() {TicketId=10,CustomerId=7, SeatNumber =4, TravelDetailId=3},

                     new Ticket() {TicketId=11,CustomerId=4, SeatNumber =20,TravelDetailId=4},
                     new Ticket() {TicketId=12,CustomerId=5, SeatNumber =11,TravelDetailId=4},
                     new Ticket() {TicketId=13,CustomerId=6, SeatNumber =5, TravelDetailId=4},
                     new Ticket() {TicketId=14,CustomerId=5, SeatNumber =9, TravelDetailId=4}
                );

            modelBuilder
                .Entity<TravelDetail>()
                .HasData(
                    new TravelDetail() {TravelDetailId=1, Date= "1.12.2022", Time="19:00", DepartureCityId = 1, ArrivalCityId = 2, Price =600,  PeronNumber=15, BusId=1},
                    new TravelDetail() {TravelDetailId=2, Date= "1.12.2022", Time="20:00", DepartureCityId = 1, ArrivalCityId = 2, Price =600,  PeronNumber=15, BusId=2},
                    new TravelDetail() {TravelDetailId=3, Date= "1.12.2022", Time="21:00", DepartureCityId = 1, ArrivalCityId = 2, Price =600,  PeronNumber=15, BusId=1},
                                                                    
                    new TravelDetail() {TravelDetailId=4, Date= "2.12.2022", Time="19:00", DepartureCityId = 2, ArrivalCityId = 3, Price =500,  PeronNumber=15, BusId=1},
                    new TravelDetail() {TravelDetailId=5, Date= "2.12.2022", Time="20:00", DepartureCityId = 2, ArrivalCityId = 3, Price =500,  PeronNumber=15, BusId=2},
                    new TravelDetail() {TravelDetailId=6, Date= "2.12.2022", Time="21:00", DepartureCityId = 2, ArrivalCityId = 3, Price =500,  PeronNumber=15, BusId=2},
                                                                    
                    new TravelDetail() {TravelDetailId=7, Date= "3.12.2022", Time="10:00", DepartureCityId = 3, ArrivalCityId = 5, Price =400,  PeronNumber=15, BusId=2},
                    new TravelDetail() {TravelDetailId=8, Date= "3.12.2022", Time="11:00", DepartureCityId = 3, ArrivalCityId = 5, Price =400,  PeronNumber=15, BusId=2}
                );

            modelBuilder
                .Entity<CompanyIntroduction>()
                .HasData(
                    new CompanyIntroduction() { CompanyIntroductionId = 1, CompanyDescriptionTitle = "Misyon ve Vizyon", CompanyDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Scelerisque in dictum non consectetur a erat nam at lectus. Eget aliquet nibh praesent tristique magna. Lectus nulla at volutpat diam ut venenatis tellus in metus. Felis eget nunc lobortis mattis aliquam faucibus purus in. Mattis aliquam faucibus purus in. Vulputate ut pharetra sit amet aliquam id diam. Quam elementum pulvinar etiam non quam lacus suspendisse faucibus. Ut sem viverra aliquet eget. Pellentesque habitant morbi tristique senectus et netus. Commodo elit at imperdiet dui. Dignissim enim sit amet venenatis urna cursus eget nunc scelerisque. Lectus mauris ultrices eros in cursus turpis. Proin sed libero enim sed faucibus turpis in eu mi. Ullamcorper dignissim cras tincidunt lobortis feugiat vivamus. Et tortor consequat id porta nibh venenatis cras sed. Amet purus gravida quis blandit turpis cursus." }
                );

            modelBuilder
                .Entity<Contact>()
                .HasData(
                    new Contact() { ContactId = 1, BranchName = "İstanbul", BranchPhone = "01111111111", BranchAddress = "euismod nisi porta lorem mollis aliquam ut" },
                    new Contact() { ContactId = 2, BranchName = "Ankara", BranchPhone = "01111111111", BranchAddress = "euismod nisi porta lorem mollis aliquam ut" },
                    new Contact() { ContactId = 3, BranchName = "Bursa", BranchPhone = "01111111111", BranchAddress = "euismod nisi porta lorem mollis aliquam ut" },
                    new Contact() { ContactId = 4, BranchName = "İzmir", BranchPhone = "01111111111", BranchAddress = "euismod nisi porta lorem mollis aliquam ut" }
                );

            modelBuilder
                .Entity<Support>()
                .HasData(
                    new Support() { SupportId = 1, FirstName = "Metin", LastName = "Tekin", Email = "metintekin@gmail.com", PhoneNumber = "00111225444", Topic = "Şikayet", Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Bibendum ut tristique et egestas quis ipsum suspendisse. Fames ac turpis egestas integer eget aliquet." },
                    new Support() { SupportId = 2, FirstName = "Metin", LastName = "Tekin", Email = "metintekin@gmail.com", PhoneNumber = "00111225444", Topic = "Şikayet", Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Bibendum ut tristique et egestas quis ipsum suspendisse. Fames ac turpis egestas integer eget aliquet." },
                    new Support() { SupportId = 3, FirstName = "Metin", LastName = "Tekin", Email = "metintekin@gmail.com", PhoneNumber = "00111225444", Topic = "Şikayet", Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Bibendum ut tristique et egestas quis ipsum suspendisse. Fames ac turpis egestas integer eget aliquet." },
                    new Support() { SupportId = 4, FirstName = "Metin", LastName = "Tekin", Email = "metintekin@gmail.com", PhoneNumber = "00111225444", Topic = "Şikayet", Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Bibendum ut tristique et egestas quis ipsum suspendisse. Fames ac turpis egestas integer eget aliquet." }
                );

        }
    }
}