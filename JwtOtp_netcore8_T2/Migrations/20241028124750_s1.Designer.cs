﻿// <auto-generated />
using JwtOtp_netcore8_T2.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace JwtOtp_netcore8_T2.Migrations
{
    [DbContext(typeof(JwtOtpContext))]
    [Migration("20241028124750_s1")]
    partial class s1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("JwtOtp_netcore8_T2.Models.JwtToken", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("platform")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("JwtToken");
                });

            modelBuilder.Entity("JwtOtp_netcore8_T2.Models.Users", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("IP")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("JwtToken_ID")
                        .HasColumnType("int");

                    b.Property<int>("OtpCode")
                        .HasColumnType("int");

                    b.Property<string>("PhoneNumb")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("JwtToken_ID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("JwtOtp_netcore8_T2.Models.Users", b =>
                {
                    b.HasOne("JwtOtp_netcore8_T2.Models.JwtToken", "JwtToken")
                        .WithMany()
                        .HasForeignKey("JwtToken_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("JwtToken");
                });
#pragma warning restore 612, 618
        }
    }
}