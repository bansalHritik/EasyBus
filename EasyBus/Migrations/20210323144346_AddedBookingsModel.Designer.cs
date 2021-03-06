// <auto-generated />
using System;
using EasyBus.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EasyBus.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20210323144346_AddedBookingsModel")]
    partial class AddedBookingsModel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EasyBus.EntityDataModels.Models.Bus", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<short>("Capacity")
                        .HasColumnType("smallint");

                    b.Property<string>("Description")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Operator")
                        .HasColumnType("nvarchar(max)");

                    b.Property<short>("SeatsBooked")
                        .HasColumnType("smallint");

                    b.Property<string>("VehicleNumber")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Buses");
                });

            modelBuilder.Entity("EasyBus.Models.Booking", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("ArrivalStopId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("DateAndTime")
                        .HasColumnType("datetime2");

                    b.Property<long?>("DepartureStopId")
                        .HasColumnType("bigint");

                    b.Property<long>("Fare")
                        .HasColumnType("bigint");

                    b.Property<int>("NumberOfSeats")
                        .HasColumnType("int");

                    b.Property<string>("User")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ArrivalStopId");

                    b.HasIndex("DepartureStopId");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("EasyBus.Models.BusStop", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("ArrivalTime")
                        .HasColumnType("datetime2");

                    b.Property<long?>("BusId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("DepartureTime")
                        .HasColumnType("datetime2");

                    b.Property<long?>("StopId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("BusId");

                    b.HasIndex("StopId");

                    b.ToTable("BusStops");
                });

            modelBuilder.Entity("EasyBus.Models.Stop", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Stops");
                });

            modelBuilder.Entity("EasyBus.Models.Booking", b =>
                {
                    b.HasOne("EasyBus.Models.Stop", "ArrivalStop")
                        .WithMany()
                        .HasForeignKey("ArrivalStopId");

                    b.HasOne("EasyBus.Models.Stop", "DepartureStop")
                        .WithMany()
                        .HasForeignKey("DepartureStopId");

                    b.Navigation("ArrivalStop");

                    b.Navigation("DepartureStop");
                });

            modelBuilder.Entity("EasyBus.Models.BusStop", b =>
                {
                    b.HasOne("EasyBus.EntityDataModels.Models.Bus", "Bus")
                        .WithMany()
                        .HasForeignKey("BusId");

                    b.HasOne("EasyBus.Models.Stop", "Stop")
                        .WithMany()
                        .HasForeignKey("StopId");

                    b.Navigation("Bus");

                    b.Navigation("Stop");
                });
#pragma warning restore 612, 618
        }
    }
}
