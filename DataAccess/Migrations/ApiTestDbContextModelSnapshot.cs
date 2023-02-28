﻿// <auto-generated />
using System;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccess.Migrations
{
    [DbContext(typeof(ApiTestDbContext))]
    partial class ApiTestDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Entities.Cliente", b =>
                {
                    b.Property<int>("clienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("clienteId"));

                    b.Property<string>("contrasena")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("direccion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("edad")
                        .HasColumnType("int");

                    b.Property<bool>("estado")
                        .HasColumnType("bit");

                    b.Property<string>("genero")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("personaId")
                        .HasColumnType("int");

                    b.Property<long>("telefono")
                        .HasColumnType("bigint");

                    b.HasKey("clienteId");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("Entities.Cuenta", b =>
                {
                    b.Property<int>("cuentaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("cuentaId"));

                    b.Property<int>("clienteId")
                        .HasColumnType("int");

                    b.Property<bool>("estado")
                        .HasColumnType("bit");

                    b.Property<int>("numeroCuenta")
                        .HasColumnType("int");

                    b.Property<double>("saldoActual")
                        .HasColumnType("float");

                    b.Property<double>("saldoInicial")
                        .HasColumnType("float");

                    b.Property<string>("tipoCuenta")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("cuentaId");

                    b.HasIndex("clienteId");

                    b.ToTable("Cuenta");
                });

            modelBuilder.Entity("Entities.Movimiento", b =>
                {
                    b.Property<int>("movimientoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("movimientoId"));

                    b.Property<int>("cuentaID")
                        .HasColumnType("int");

                    b.Property<DateTime>("fecha")
                        .HasColumnType("datetime2");

                    b.Property<string>("tipoMovimiento")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<double>("valor")
                        .HasColumnType("float");

                    b.HasKey("movimientoId");

                    b.HasIndex("cuentaID");

                    b.ToTable("Movimiento");
                });

            modelBuilder.Entity("Entities.Cuenta", b =>
                {
                    b.HasOne("Entities.Cliente", "cliente")
                        .WithMany("cuentas")
                        .HasForeignKey("clienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("cliente");
                });

            modelBuilder.Entity("Entities.Movimiento", b =>
                {
                    b.HasOne("Entities.Cuenta", "cuenta")
                        .WithMany("movimientos")
                        .HasForeignKey("cuentaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("cuenta");
                });

            modelBuilder.Entity("Entities.Cliente", b =>
                {
                    b.Navigation("cuentas");
                });

            modelBuilder.Entity("Entities.Cuenta", b =>
                {
                    b.Navigation("movimientos");
                });
#pragma warning restore 612, 618
        }
    }
}