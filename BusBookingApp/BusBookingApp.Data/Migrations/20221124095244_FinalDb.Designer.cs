﻿// <auto-generated />
using BusBookingApp.Data.Concrete.EfCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BusBookingApp.Data.Migrations
{
    [DbContext(typeof(BusBookingContext))]
    [Migration("20221124095244_FinalDb")]
    partial class FinalDb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.11");

            modelBuilder.Entity("BusBookingApp.Entity.Bus", b =>
                {
                    b.Property<int>("BusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("BusSeatCapacity")
                        .HasColumnType("INTEGER");

                    b.HasKey("BusId");

                    b.ToTable("Buses");

                    b.HasData(
                        new
                        {
                            BusId = 1,
                            BusSeatCapacity = 36
                        },
                        new
                        {
                            BusId = 2,
                            BusSeatCapacity = 48
                        });
                });

            modelBuilder.Entity("BusBookingApp.Entity.City", b =>
                {
                    b.Property<int>("CityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CityName")
                        .HasColumnType("TEXT");

                    b.HasKey("CityId");

                    b.ToTable("Cities");

                    b.HasData(
                        new
                        {
                            CityId = 1,
                            CityName = "İstanbul"
                        },
                        new
                        {
                            CityId = 2,
                            CityName = "Bursa"
                        },
                        new
                        {
                            CityId = 3,
                            CityName = "Balıkesir"
                        },
                        new
                        {
                            CityId = 4,
                            CityName = "Manisa"
                        },
                        new
                        {
                            CityId = 5,
                            CityName = "İzmir"
                        },
                        new
                        {
                            CityId = 6,
                            CityName = "Bolu"
                        },
                        new
                        {
                            CityId = 7,
                            CityName = "Samsun"
                        },
                        new
                        {
                            CityId = 8,
                            CityName = "Ordu"
                        },
                        new
                        {
                            CityId = 9,
                            CityName = "Rize"
                        },
                        new
                        {
                            CityId = 10,
                            CityName = "Eskişehir"
                        },
                        new
                        {
                            CityId = 11,
                            CityName = "Afyon"
                        },
                        new
                        {
                            CityId = 12,
                            CityName = "Isparta"
                        },
                        new
                        {
                            CityId = 13,
                            CityName = "Antalya"
                        });
                });

            modelBuilder.Entity("BusBookingApp.Entity.CompanyIntroduction", b =>
                {
                    b.Property<int>("CompanyIntroductionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CompanyDescription")
                        .HasColumnType("TEXT");

                    b.Property<string>("CompanyDescriptionTitle")
                        .HasColumnType("TEXT");

                    b.HasKey("CompanyIntroductionId");

                    b.ToTable("CompanyIntroductions");

                    b.HasData(
                        new
                        {
                            CompanyIntroductionId = 1,
                            CompanyDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Scelerisque in dictum non consectetur a erat nam at lectus. Eget aliquet nibh praesent tristique magna. Lectus nulla at volutpat diam ut venenatis tellus in metus. Felis eget nunc lobortis mattis aliquam faucibus purus in. Mattis aliquam faucibus purus in. Vulputate ut pharetra sit amet aliquam id diam. Quam elementum pulvinar etiam non quam lacus suspendisse faucibus. Ut sem viverra aliquet eget. Pellentesque habitant morbi tristique senectus et netus. Commodo elit at imperdiet dui. Dignissim enim sit amet venenatis urna cursus eget nunc scelerisque. Lectus mauris ultrices eros in cursus turpis. Proin sed libero enim sed faucibus turpis in eu mi. Ullamcorper dignissim cras tincidunt lobortis feugiat vivamus. Et tortor consequat id porta nibh venenatis cras sed. Amet purus gravida quis blandit turpis cursus.",
                            CompanyDescriptionTitle = "Misyon ve Vizyon"
                        });
                });

            modelBuilder.Entity("BusBookingApp.Entity.Contact", b =>
                {
                    b.Property<int>("ContactId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("BranchAddress")
                        .HasColumnType("TEXT");

                    b.Property<string>("BranchName")
                        .HasColumnType("TEXT");

                    b.Property<string>("BranchPhone")
                        .HasColumnType("TEXT");

                    b.HasKey("ContactId");

                    b.ToTable("Contacts");

                    b.HasData(
                        new
                        {
                            ContactId = 1,
                            BranchAddress = "euismod nisi porta lorem mollis aliquam ut",
                            BranchName = "İstanbul",
                            BranchPhone = "01111111111"
                        },
                        new
                        {
                            ContactId = 2,
                            BranchAddress = "euismod nisi porta lorem mollis aliquam ut",
                            BranchName = "Ankara",
                            BranchPhone = "01111111111"
                        },
                        new
                        {
                            ContactId = 3,
                            BranchAddress = "euismod nisi porta lorem mollis aliquam ut",
                            BranchName = "Bursa",
                            BranchPhone = "01111111111"
                        },
                        new
                        {
                            ContactId = 4,
                            BranchAddress = "euismod nisi porta lorem mollis aliquam ut",
                            BranchName = "İzmir",
                            BranchPhone = "01111111111"
                        });
                });

            modelBuilder.Entity("BusBookingApp.Entity.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CustomerName")
                        .HasColumnType("TEXT");

                    b.Property<string>("CustomerSurname")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.HasKey("CustomerId");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            CustomerId = 1,
                            CustomerName = "Ahmet",
                            CustomerSurname = "Yılmaz",
                            Email = "deneme@gmail.com",
                            PhoneNumber = "5547455843"
                        },
                        new
                        {
                            CustomerId = 2,
                            CustomerName = "Mert",
                            CustomerSurname = "Yılan",
                            Email = "deneme2@gmail.com",
                            PhoneNumber = "5547455843"
                        },
                        new
                        {
                            CustomerId = 3,
                            CustomerName = "Hakkı",
                            CustomerSurname = "Metin",
                            Email = "deneme3@gmail.com",
                            PhoneNumber = "5547455843"
                        },
                        new
                        {
                            CustomerId = 4,
                            CustomerName = "Mustafa",
                            CustomerSurname = "Yıldırım",
                            Email = "deneme4@gmail.com",
                            PhoneNumber = "5547455843"
                        },
                        new
                        {
                            CustomerId = 5,
                            CustomerName = "Caner",
                            CustomerSurname = "Şimşek",
                            Email = "deneme5@gmail.com",
                            PhoneNumber = "5547455843"
                        },
                        new
                        {
                            CustomerId = 6,
                            CustomerName = "Berk",
                            CustomerSurname = "Ok",
                            Email = "deneme6@gmail.com",
                            PhoneNumber = "5547455843"
                        },
                        new
                        {
                            CustomerId = 7,
                            CustomerName = "Semih",
                            CustomerSurname = "Yay",
                            Email = "deneme7@gmail.com",
                            PhoneNumber = "5547455843"
                        });
                });

            modelBuilder.Entity("BusBookingApp.Entity.Support", b =>
                {
                    b.Property<int>("SupportId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<string>("Text")
                        .HasColumnType("TEXT");

                    b.Property<string>("Topic")
                        .HasColumnType("TEXT");

                    b.HasKey("SupportId");

                    b.ToTable("Supports");

                    b.HasData(
                        new
                        {
                            SupportId = 1,
                            Email = "metintekin@gmail.com",
                            FirstName = "Metin",
                            LastName = "Tekin",
                            PhoneNumber = "00111225444",
                            Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Bibendum ut tristique et egestas quis ipsum suspendisse. Fames ac turpis egestas integer eget aliquet.",
                            Topic = "Şikayet"
                        },
                        new
                        {
                            SupportId = 2,
                            Email = "metintekin@gmail.com",
                            FirstName = "Metin",
                            LastName = "Tekin",
                            PhoneNumber = "00111225444",
                            Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Bibendum ut tristique et egestas quis ipsum suspendisse. Fames ac turpis egestas integer eget aliquet.",
                            Topic = "Şikayet"
                        },
                        new
                        {
                            SupportId = 3,
                            Email = "metintekin@gmail.com",
                            FirstName = "Metin",
                            LastName = "Tekin",
                            PhoneNumber = "00111225444",
                            Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Bibendum ut tristique et egestas quis ipsum suspendisse. Fames ac turpis egestas integer eget aliquet.",
                            Topic = "Şikayet"
                        },
                        new
                        {
                            SupportId = 4,
                            Email = "metintekin@gmail.com",
                            FirstName = "Metin",
                            LastName = "Tekin",
                            PhoneNumber = "00111225444",
                            Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Bibendum ut tristique et egestas quis ipsum suspendisse. Fames ac turpis egestas integer eget aliquet.",
                            Topic = "Şikayet"
                        });
                });

            modelBuilder.Entity("BusBookingApp.Entity.Ticket", b =>
                {
                    b.Property<int>("TicketId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CustomerId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SeatNumber")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TravelDetailId")
                        .HasColumnType("INTEGER");

                    b.HasKey("TicketId");

                    b.HasIndex("CustomerId")
                        .IsUnique();

                    b.HasIndex("TravelDetailId");

                    b.ToTable("Tickets");

                    b.HasData(
                        new
                        {
                            TicketId = 1,
                            CustomerId = 1,
                            SeatNumber = 15,
                            TravelDetailId = 1
                        },
                        new
                        {
                            TicketId = 2,
                            CustomerId = 2,
                            SeatNumber = 11,
                            TravelDetailId = 1
                        },
                        new
                        {
                            TicketId = 3,
                            CustomerId = 3,
                            SeatNumber = 13,
                            TravelDetailId = 1
                        },
                        new
                        {
                            TicketId = 4,
                            CustomerId = 3,
                            SeatNumber = 13,
                            TravelDetailId = 2
                        },
                        new
                        {
                            TicketId = 5,
                            CustomerId = 4,
                            SeatNumber = 14,
                            TravelDetailId = 2
                        },
                        new
                        {
                            TicketId = 6,
                            CustomerId = 5,
                            SeatNumber = 15,
                            TravelDetailId = 2
                        },
                        new
                        {
                            TicketId = 7,
                            CustomerId = 4,
                            SeatNumber = 1,
                            TravelDetailId = 3
                        },
                        new
                        {
                            TicketId = 8,
                            CustomerId = 5,
                            SeatNumber = 2,
                            TravelDetailId = 3
                        },
                        new
                        {
                            TicketId = 9,
                            CustomerId = 6,
                            SeatNumber = 3,
                            TravelDetailId = 3
                        },
                        new
                        {
                            TicketId = 10,
                            CustomerId = 7,
                            SeatNumber = 4,
                            TravelDetailId = 3
                        },
                        new
                        {
                            TicketId = 11,
                            CustomerId = 4,
                            SeatNumber = 20,
                            TravelDetailId = 4
                        },
                        new
                        {
                            TicketId = 12,
                            CustomerId = 5,
                            SeatNumber = 11,
                            TravelDetailId = 4
                        },
                        new
                        {
                            TicketId = 13,
                            CustomerId = 6,
                            SeatNumber = 5,
                            TravelDetailId = 4
                        },
                        new
                        {
                            TicketId = 14,
                            CustomerId = 5,
                            SeatNumber = 9,
                            TravelDetailId = 4
                        });
                });

            modelBuilder.Entity("BusBookingApp.Entity.TravelDetail", b =>
                {
                    b.Property<int>("TravelDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ArrivalCityId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("BusId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Date")
                        .HasColumnType("TEXT");

                    b.Property<int>("DepartureCityId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PeronNumber")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Price")
                        .HasColumnType("REAL");

                    b.Property<string>("Time")
                        .HasColumnType("TEXT");

                    b.HasKey("TravelDetailId");

                    b.HasIndex("ArrivalCityId");

                    b.HasIndex("BusId");

                    b.HasIndex("DepartureCityId");

                    b.ToTable("TravelDetails");

                    b.HasData(
                        new
                        {
                            TravelDetailId = 1,
                            ArrivalCityId = 2,
                            BusId = 1,
                            Date = "1.12.2022",
                            DepartureCityId = 1,
                            PeronNumber = 15,
                            Price = 600.0,
                            Time = "19:00"
                        },
                        new
                        {
                            TravelDetailId = 2,
                            ArrivalCityId = 2,
                            BusId = 2,
                            Date = "1.12.2022",
                            DepartureCityId = 1,
                            PeronNumber = 15,
                            Price = 600.0,
                            Time = "20:00"
                        },
                        new
                        {
                            TravelDetailId = 3,
                            ArrivalCityId = 2,
                            BusId = 1,
                            Date = "1.12.2022",
                            DepartureCityId = 1,
                            PeronNumber = 15,
                            Price = 600.0,
                            Time = "21:00"
                        },
                        new
                        {
                            TravelDetailId = 4,
                            ArrivalCityId = 3,
                            BusId = 1,
                            Date = "2.12.2022",
                            DepartureCityId = 2,
                            PeronNumber = 15,
                            Price = 500.0,
                            Time = "19:00"
                        },
                        new
                        {
                            TravelDetailId = 5,
                            ArrivalCityId = 3,
                            BusId = 2,
                            Date = "2.12.2022",
                            DepartureCityId = 2,
                            PeronNumber = 15,
                            Price = 500.0,
                            Time = "20:00"
                        },
                        new
                        {
                            TravelDetailId = 6,
                            ArrivalCityId = 3,
                            BusId = 2,
                            Date = "2.12.2022",
                            DepartureCityId = 2,
                            PeronNumber = 15,
                            Price = 500.0,
                            Time = "21:00"
                        },
                        new
                        {
                            TravelDetailId = 7,
                            ArrivalCityId = 5,
                            BusId = 2,
                            Date = "3.12.2022",
                            DepartureCityId = 3,
                            PeronNumber = 15,
                            Price = 400.0,
                            Time = "10:00"
                        },
                        new
                        {
                            TravelDetailId = 8,
                            ArrivalCityId = 5,
                            BusId = 2,
                            Date = "3.12.2022",
                            DepartureCityId = 3,
                            PeronNumber = 15,
                            Price = 400.0,
                            Time = "11:00"
                        });
                });

            modelBuilder.Entity("BusBookingApp.Entity.Ticket", b =>
                {
                    b.HasOne("BusBookingApp.Entity.Customer", "Customer")
                        .WithOne("Ticket")
                        .HasForeignKey("BusBookingApp.Entity.Ticket", "CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BusBookingApp.Entity.TravelDetail", "TravelDetail")
                        .WithMany("Tickets")
                        .HasForeignKey("TravelDetailId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("TravelDetail");
                });

            modelBuilder.Entity("BusBookingApp.Entity.TravelDetail", b =>
                {
                    b.HasOne("BusBookingApp.Entity.City", "ArrivalCity")
                        .WithMany()
                        .HasForeignKey("ArrivalCityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BusBookingApp.Entity.Bus", "Bus")
                        .WithMany("Travels")
                        .HasForeignKey("BusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BusBookingApp.Entity.City", "DepartureCity")
                        .WithMany()
                        .HasForeignKey("DepartureCityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ArrivalCity");

                    b.Navigation("Bus");

                    b.Navigation("DepartureCity");
                });

            modelBuilder.Entity("BusBookingApp.Entity.Bus", b =>
                {
                    b.Navigation("Travels");
                });

            modelBuilder.Entity("BusBookingApp.Entity.Customer", b =>
                {
                    b.Navigation("Ticket");
                });

            modelBuilder.Entity("BusBookingApp.Entity.TravelDetail", b =>
                {
                    b.Navigation("Tickets");
                });
#pragma warning restore 612, 618
        }
    }
}
