using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Classical_Music_Library_Web_App.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Composers",
                columns: table => new
                {
                    ComposerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Era = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nationality = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthYear = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Composers", x => x.ComposerID);
                });

            migrationBuilder.CreateTable(
                name: "EnsembleTypes",
                columns: table => new
                {
                    EnsembleTypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnsembleTypes", x => x.EnsembleTypeID);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    GenreID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GenreName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.GenreID);
                });

            migrationBuilder.CreateTable(
                name: "Compositions",
                columns: table => new
                {
                    CompositionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ComposerID = table.Column<int>(type: "int", nullable: false),
                    EnsembleTypeID = table.Column<int>(type: "int", nullable: true),
                    GenreID = table.Column<int>(type: "int", nullable: true),
                    YearComposed = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compositions", x => x.CompositionID);
                    table.ForeignKey(
                        name: "FK_Compositions_Composers_ComposerID",
                        column: x => x.ComposerID,
                        principalTable: "Composers",
                        principalColumn: "ComposerID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Compositions_EnsembleTypes_EnsembleTypeID",
                        column: x => x.EnsembleTypeID,
                        principalTable: "EnsembleTypes",
                        principalColumn: "EnsembleTypeID",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Compositions_Genres_GenreID",
                        column: x => x.GenreID,
                        principalTable: "Genres",
                        principalColumn: "GenreID",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Recordings",
                columns: table => new
                {
                    RecordingID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompositionID = table.Column<int>(type: "int", nullable: false),
                    EnsembleTypeID = table.Column<int>(type: "int", nullable: true),
                    GenreID = table.Column<int>(type: "int", nullable: true),
                    EnsembleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Soloist = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReleaseYear = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recordings", x => x.RecordingID);
                    table.ForeignKey(
                        name: "FK_Recordings_Compositions_CompositionID",
                        column: x => x.CompositionID,
                        principalTable: "Compositions",
                        principalColumn: "CompositionID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Recordings_EnsembleTypes_EnsembleTypeID",
                        column: x => x.EnsembleTypeID,
                        principalTable: "EnsembleTypes",
                        principalColumn: "EnsembleTypeID",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Recordings_Genres_GenreID",
                        column: x => x.GenreID,
                        principalTable: "Genres",
                        principalColumn: "GenreID",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "LibraryInventory",
                columns: table => new
                {
                    LibraryInventoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecordingID = table.Column<int>(type: "int", nullable: false),
                    Format = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LibraryInventory", x => x.LibraryInventoryID);
                    table.ForeignKey(
                        name: "FK_LibraryInventory_Recordings_RecordingID",
                        column: x => x.RecordingID,
                        principalTable: "Recordings",
                        principalColumn: "RecordingID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Compositions_ComposerID",
                table: "Compositions",
                column: "ComposerID");

            migrationBuilder.CreateIndex(
                name: "IX_Compositions_EnsembleTypeID",
                table: "Compositions",
                column: "EnsembleTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Compositions_GenreID",
                table: "Compositions",
                column: "GenreID");

            migrationBuilder.CreateIndex(
                name: "IX_LibraryInventory_RecordingID",
                table: "LibraryInventory",
                column: "RecordingID");

            migrationBuilder.CreateIndex(
                name: "IX_Recordings_CompositionID",
                table: "Recordings",
                column: "CompositionID");

            migrationBuilder.CreateIndex(
                name: "IX_Recordings_EnsembleTypeID",
                table: "Recordings",
                column: "EnsembleTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Recordings_GenreID",
                table: "Recordings",
                column: "GenreID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LibraryInventory");

            migrationBuilder.DropTable(
                name: "Recordings");

            migrationBuilder.DropTable(
                name: "Compositions");

            migrationBuilder.DropTable(
                name: "Composers");

            migrationBuilder.DropTable(
                name: "EnsembleTypes");

            migrationBuilder.DropTable(
                name: "Genres");
        }
    }
}
