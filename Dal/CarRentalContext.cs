using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Dal.Models;

public partial class CarRentalContext : DbContext
{
    private readonly IConfiguration _configuration;
    //public CarRentalContext(IConfiguration configuration)
    //{
    //    _configuration = configuration;
    //}

    public CarRentalContext(DbContextOptions<CarRentalContext> options, IConfiguration configuration)
        : base(options)
    {
        _configuration = configuration;

    }

    public virtual DbSet<Car> Cars { get; set; }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<Company> Companies { get; set; }

    public virtual DbSet<DriveType> DriveTypes { get; set; }

    public virtual DbSet<Lending> Lendings { get; set; }

    public virtual DbSet<Model> Models { get; set; }

    public virtual DbSet<Restitution> Restitutions { get; set; }

    public virtual DbSet<TypeVehicle> TypeVehicles { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Car>(entity =>
        {
            entity.HasKey(e => e.Code).HasName("PK__cars__357D4CF825B9563A");

            entity.ToTable("cars");

            entity.Property(e => e.Code).HasColumnName("code");
            entity.Property(e => e.Available).HasColumnName("available");
            entity.Property(e => e.BalanceInLiters).HasColumnName("Balance_in_liters");
            entity.Property(e => e.City).HasColumnName("city");
            entity.Property(e => e.CodeModel).HasColumnName("code_model");
            entity.Property(e => e.ConsumptionPerKm).HasColumnName("consumption_per_km");
            entity.Property(e => e.Gear).HasColumnName("gear");
            entity.Property(e => e.Image)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("image");
            entity.Property(e => e.IsDelete).HasColumnName("is_delete");
            entity.Property(e => e.LicensePlate)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("license_plate");
            entity.Property(e => e.NumberOfSeats).HasColumnName("number_of_seats");
            entity.Property(e => e.PricePerHour).HasColumnName("price_per_hour");
            entity.Property(e => e.Year).HasColumnName("year");

            entity.HasOne(d => d.CityNavigation).WithMany(p => p.Cars)
                .HasForeignKey(d => d.City)
                .HasConstraintName("FK__cars__city__48CFD27E");

            entity.HasOne(d => d.CodeModelNavigation).WithMany(p => p.Cars)
                .HasForeignKey(d => d.CodeModel)
                .HasConstraintName("FK__cars__code_model__47DBAE45");
        });

        modelBuilder.Entity<City>(entity =>
        {
            entity.HasKey(e => e.Code).HasName("PK__cities__357D4CF8EA54174C");

            entity.ToTable("cities");

            entity.HasIndex(e => e.Name, "UQ__cities__72E12F1B5F613DBC").IsUnique();

            entity.Property(e => e.Code).HasColumnName("code");
            entity.Property(e => e.IsDelete).HasColumnName("is_delete");
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Company>(entity =>
        {
            entity.HasKey(e => e.Code).HasName("PK__companie__357D4CF8F74A3A71");

            entity.ToTable("companies");

            entity.HasIndex(e => e.Name, "UQ__companie__72E12F1BF1CBF38F").IsUnique();

            entity.Property(e => e.Code).HasColumnName("code");
            entity.Property(e => e.Image)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("image");
            entity.Property(e => e.IsDelete).HasColumnName("is_delete");
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<DriveType>(entity =>
        {
            entity.HasKey(e => e.Code).HasName("PK__drive_ty__357D4CF8BFEFF345");

            entity.ToTable("drive_type");

            entity.HasIndex(e => e.Description, "UQ__drive_ty__489B0D97B128B107").IsUnique();

            entity.Property(e => e.Code).HasColumnName("code");
            entity.Property(e => e.Description)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.IsDelete).HasColumnName("is_delete");
        });

        modelBuilder.Entity<Lending>(entity =>
        {
            entity.HasKey(e => e.Code).HasName("PK__lendings__357D4CF84F2A93EC");

            entity.ToTable("lendings");

            entity.Property(e => e.Code).HasColumnName("code");
            entity.Property(e => e.CodeCar).HasColumnName("code_car");
            entity.Property(e => e.Date)
                .HasColumnType("date")
                .HasColumnName("date");
            entity.Property(e => e.Hour).HasColumnName("hour");
            entity.Property(e => e.IdUser).HasColumnName("id_user");
            entity.Property(e => e.ReturnCar).HasColumnName("return_car");
            entity.Property(e => e.ReturnDate)
                .HasColumnType("date")
                .HasColumnName("return_date");
            entity.Property(e => e.ReturnHour).HasColumnName("return_hour");

            entity.HasOne(d => d.CodeCarNavigation).WithMany(p => p.Lendings)
                .HasForeignKey(d => d.CodeCar)
                .HasConstraintName("FK__lendings__code_c__5165187F");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.Lendings)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__lendings__id_use__4D94879B");
        });

        modelBuilder.Entity<Model>(entity =>
        {
            entity.HasKey(e => e.Code).HasName("PK__models__357D4CF8AEFD1D17");

            entity.ToTable("models");

            entity.Property(e => e.Code).HasColumnName("code");
            entity.Property(e => e.CodeCompany).HasColumnName("code_company");
            entity.Property(e => e.DriveType).HasColumnName("drive_type");
            entity.Property(e => e.IsDelete).HasColumnName("is_delete");
            entity.Property(e => e.Model1)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("model");
            entity.Property(e => e.TypeVehicles).HasColumnName("type_vehicles");

            entity.HasOne(d => d.CodeCompanyNavigation).WithMany(p => p.Models)
                .HasForeignKey(d => d.CodeCompany)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__models__code_com__4316F928");

            entity.HasOne(d => d.DriveTypeNavigation).WithMany(p => p.Models)
                .HasForeignKey(d => d.DriveType)
                .HasConstraintName("FK__models__drive_ty__440B1D61");

            entity.HasOne(d => d.TypeVehiclesNavigation).WithMany(p => p.Models)
                .HasForeignKey(d => d.TypeVehicles)
                .HasConstraintName("FK__models__type_veh__44FF419A");
        });

        modelBuilder.Entity<Restitution>(entity =>
        {
            entity.HasKey(e => e.Code).HasName("PK__restitut__357D4CF802D1B0CC");

            entity.ToTable("restitutions");

            entity.Property(e => e.Code).HasColumnName("code");
            entity.Property(e => e.Balance).HasColumnName("balance");
            entity.Property(e => e.CodeLending).HasColumnName("code_lending");
            entity.Property(e => e.Date)
                .HasColumnType("date")
                .HasColumnName("date");
            entity.Property(e => e.Hour).HasColumnName("hour");
            entity.Property(e => e.Paid).HasColumnName("paid");
            entity.Property(e => e.TotalPayable).HasColumnName("total_payable");

            entity.HasOne(d => d.CodeLendingNavigation).WithMany(p => p.Restitutions)
                .HasForeignKey(d => d.CodeLending)
                .HasConstraintName("FK__restituti__code___5070F446");
        });

        modelBuilder.Entity<TypeVehicle>(entity =>
        {
            entity.HasKey(e => e.Code).HasName("PK__type_veh__357D4CF845930437");

            entity.ToTable("type_vehicles");

            entity.HasIndex(e => e.Description, "UQ__type_veh__489B0D9706306BBA").IsUnique();

            entity.Property(e => e.Code).HasColumnName("code");
            entity.Property(e => e.Description)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.IsDelete).HasColumnName("is_delete");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__users__3213E83F0718FDE4");

            entity.ToTable("users");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Cvv)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("cvv");
            entity.Property(e => e.IsDelete).HasColumnName("is_delete");
            entity.Property(e => e.IsManager).HasColumnName("is_manager");
            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.NumCreditCard)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("num_credit_card");
            entity.Property(e => e.Password)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.Phone)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("phone");
            entity.Property(e => e.Validity)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("validity");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
