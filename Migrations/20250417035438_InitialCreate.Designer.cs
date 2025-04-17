﻿// <auto-generated />
using Classical_Music_Library_Web_App.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Classical_Music_Library_Web_App.Migrations
{
    [DbContext(typeof(MusicDbContext))]
    [Migration("20250417035438_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Classical_Music_Library_Web_App.Models.Composer", b =>
                {
                    b.Property<int>("ComposerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ComposerID"));

                    b.Property<int?>("BirthYear")
                        .HasColumnType("int");

                    b.Property<string>("Era")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nationality")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ComposerID");

                    b.ToTable("Composers");
                });

            modelBuilder.Entity("Classical_Music_Library_Web_App.Models.Composition", b =>
                {
                    b.Property<int>("CompositionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CompositionID"));

                    b.Property<int>("ComposerID")
                        .HasColumnType("int");

                    b.Property<int?>("EnsembleTypeID")
                        .HasColumnType("int");

                    b.Property<int?>("GenreID")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("YearComposed")
                        .HasColumnType("int");

                    b.HasKey("CompositionID");

                    b.HasIndex("ComposerID");

                    b.HasIndex("EnsembleTypeID");

                    b.HasIndex("GenreID");

                    b.ToTable("Compositions");
                });

            modelBuilder.Entity("Classical_Music_Library_Web_App.Models.EnsembleType", b =>
                {
                    b.Property<int>("EnsembleTypeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EnsembleTypeID"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TypeName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EnsembleTypeID");

                    b.ToTable("EnsembleTypes");
                });

            modelBuilder.Entity("Classical_Music_Library_Web_App.Models.Genre", b =>
                {
                    b.Property<int>("GenreID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GenreID"));

                    b.Property<string>("GenreName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GenreID");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("Classical_Music_Library_Web_App.Models.LibraryInventory", b =>
                {
                    b.Property<int>("LibraryInventoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LibraryInventoryID"));

                    b.Property<string>("Format")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RecordingID")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LibraryInventoryID");

                    b.HasIndex("RecordingID");

                    b.ToTable("LibraryInventory");
                });

            modelBuilder.Entity("Classical_Music_Library_Web_App.Models.Recording", b =>
                {
                    b.Property<int>("RecordingID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RecordingID"));

                    b.Property<int>("CompositionID")
                        .HasColumnType("int");

                    b.Property<string>("EnsembleName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("EnsembleTypeID")
                        .HasColumnType("int");

                    b.Property<int?>("GenreID")
                        .HasColumnType("int");

                    b.Property<int>("ReleaseYear")
                        .HasColumnType("int");

                    b.Property<string>("Soloist")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RecordingID");

                    b.HasIndex("CompositionID");

                    b.HasIndex("EnsembleTypeID");

                    b.HasIndex("GenreID");

                    b.ToTable("Recordings");
                });

            modelBuilder.Entity("Classical_Music_Library_Web_App.Models.Composition", b =>
                {
                    b.HasOne("Classical_Music_Library_Web_App.Models.Composer", "Composer")
                        .WithMany("Compositions")
                        .HasForeignKey("ComposerID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Classical_Music_Library_Web_App.Models.EnsembleType", "EnsembleType")
                        .WithMany("Compositions")
                        .HasForeignKey("EnsembleTypeID")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("Classical_Music_Library_Web_App.Models.Genre", "Genre")
                        .WithMany("Compositions")
                        .HasForeignKey("GenreID")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Composer");

                    b.Navigation("EnsembleType");

                    b.Navigation("Genre");
                });

            modelBuilder.Entity("Classical_Music_Library_Web_App.Models.LibraryInventory", b =>
                {
                    b.HasOne("Classical_Music_Library_Web_App.Models.Recording", "Recording")
                        .WithMany("LibraryInventories")
                        .HasForeignKey("RecordingID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Recording");
                });

            modelBuilder.Entity("Classical_Music_Library_Web_App.Models.Recording", b =>
                {
                    b.HasOne("Classical_Music_Library_Web_App.Models.Composition", "Composition")
                        .WithMany("Recordings")
                        .HasForeignKey("CompositionID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Classical_Music_Library_Web_App.Models.EnsembleType", "EnsembleType")
                        .WithMany("Recordings")
                        .HasForeignKey("EnsembleTypeID")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("Classical_Music_Library_Web_App.Models.Genre", "Genre")
                        .WithMany("Recordings")
                        .HasForeignKey("GenreID")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Composition");

                    b.Navigation("EnsembleType");

                    b.Navigation("Genre");
                });

            modelBuilder.Entity("Classical_Music_Library_Web_App.Models.Composer", b =>
                {
                    b.Navigation("Compositions");
                });

            modelBuilder.Entity("Classical_Music_Library_Web_App.Models.Composition", b =>
                {
                    b.Navigation("Recordings");
                });

            modelBuilder.Entity("Classical_Music_Library_Web_App.Models.EnsembleType", b =>
                {
                    b.Navigation("Compositions");

                    b.Navigation("Recordings");
                });

            modelBuilder.Entity("Classical_Music_Library_Web_App.Models.Genre", b =>
                {
                    b.Navigation("Compositions");

                    b.Navigation("Recordings");
                });

            modelBuilder.Entity("Classical_Music_Library_Web_App.Models.Recording", b =>
                {
                    b.Navigation("LibraryInventories");
                });
#pragma warning restore 612, 618
        }
    }
}
