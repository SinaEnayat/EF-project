﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Task3.DataModel;

#nullable disable

namespace Final3.Migrations
{
    [DbContext(typeof(MyContext))]
    [Migration("20230826072513_Changing_BorrowerHistory")]
    partial class Changing_BorrowerHistory
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Task3.DataModel.Authors", b =>
                {
                    b.Property<int>("AuthorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AuthorId"));

                    b.Property<string>("AuthorName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AuthorId");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("Task3.DataModel.Books", b =>
                {
                    b.Property<int>("BookId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BookId"));

                    b.Property<int>("AuthorsAuthorId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PublisherId")
                        .HasColumnType("int");

                    b.Property<string>("genre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BookId");

                    b.HasIndex("AuthorsAuthorId");

                    b.HasIndex("PublisherId");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("Task3.DataModel.BorrowHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<int>("BorrowerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsReturn")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("BorrowerId");

                    b.ToTable("BorrowHistory");
                });

            modelBuilder.Entity("Task3.DataModel.Borrower", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("BorrowerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Borrower");
                });

            modelBuilder.Entity("Task3.DataModel.Publisher", b =>
                {
                    b.Property<int>("PublisherId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PublisherId"));

                    b.Property<string>("PublisherName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PublisherId");

                    b.ToTable("Publishers");
                });

            modelBuilder.Entity("Task3.DataModel.Books", b =>
                {
                    b.HasOne("Task3.DataModel.Authors", "Authors")
                        .WithMany("Books")
                        .HasForeignKey("AuthorsAuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Task3.DataModel.Publisher", "Publisher")
                        .WithMany("Books")
                        .HasForeignKey("PublisherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Authors");

                    b.Navigation("Publisher");
                });

            modelBuilder.Entity("Task3.DataModel.BorrowHistory", b =>
                {
                    b.HasOne("Task3.DataModel.Books", "Book")
                        .WithMany()
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Task3.DataModel.Borrower", "Borrower")
                        .WithMany()
                        .HasForeignKey("BorrowerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("Borrower");
                });

            modelBuilder.Entity("Task3.DataModel.Authors", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("Task3.DataModel.Publisher", b =>
                {
                    b.Navigation("Books");
                });
#pragma warning restore 612, 618
        }
    }
}