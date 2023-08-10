using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CineMate.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Actors",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Country = table.Column<string>(type: "text", nullable: false),
                    CountryCode = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Directors",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Directors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Phone = table.Column<string>(type: "text", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Role = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Rating = table.Column<decimal>(type: "numeric", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    GenreId = table.Column<long>(type: "bigint", nullable: false),
                    DirectorId = table.Column<long>(type: "bigint", nullable: false),
                    AddressId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Movies_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Movies_Directors_DirectorId",
                        column: x => x.DirectorId,
                        principalTable: "Directors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Movies_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovieActor",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MovieId = table.Column<long>(type: "bigint", nullable: false),
                    ActorId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieActor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MovieActor_Actors_ActorId",
                        column: x => x.ActorId,
                        principalTable: "Actors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieActor_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRatings",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Rating = table.Column<int>(type: "integer", nullable: false),
                    Comment = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    MovieId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRatings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRatings_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRatings_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Actors",
                columns: new[] { "Id", "CreatedAt", "FirstName", "IsDeleted", "LastName", "UpdatedAt" },
                values: new object[,]
                {
                    { 1L, new DateTime(2023, 8, 10, 16, 53, 41, 235, DateTimeKind.Utc).AddTicks(5019), "John", false, "Doe", null },
                    { 2L, new DateTime(2023, 8, 10, 16, 53, 41, 235, DateTimeKind.Utc).AddTicks(5020), "Jane", false, "Smith", null },
                    { 3L, new DateTime(2023, 8, 10, 16, 53, 41, 235, DateTimeKind.Utc).AddTicks(5021), "Michael", false, "Johnson", null },
                    { 4L, new DateTime(2023, 8, 10, 16, 53, 41, 235, DateTimeKind.Utc).AddTicks(5022), "Emily", false, "Williams", null },
                    { 5L, new DateTime(2023, 8, 10, 16, 53, 41, 235, DateTimeKind.Utc).AddTicks(5022), "David", false, "Brown", null },
                    { 6L, new DateTime(2023, 8, 10, 16, 53, 41, 235, DateTimeKind.Utc).AddTicks(5023), "Sophia", false, "Jones", null },
                    { 7L, new DateTime(2023, 8, 10, 16, 53, 41, 235, DateTimeKind.Utc).AddTicks(5024), "Robert", false, "Miller", null },
                    { 8L, new DateTime(2023, 8, 10, 16, 53, 41, 235, DateTimeKind.Utc).AddTicks(5025), "Olivia", false, "Davis", null },
                    { 9L, new DateTime(2023, 8, 10, 16, 53, 41, 235, DateTimeKind.Utc).AddTicks(5025), "William", false, "Garcia", null },
                    { 10L, new DateTime(2023, 8, 10, 16, 53, 41, 235, DateTimeKind.Utc).AddTicks(5026), "Ava", false, "Rodriguez", null },
                    { 11L, new DateTime(2023, 8, 10, 16, 53, 41, 235, DateTimeKind.Utc).AddTicks(5027), "Ethan", false, "Martinez", null },
                    { 12L, new DateTime(2023, 8, 10, 16, 53, 41, 235, DateTimeKind.Utc).AddTicks(5028), "Mia", false, "Hernandez", null },
                    { 13L, new DateTime(2023, 8, 10, 16, 53, 41, 235, DateTimeKind.Utc).AddTicks(5028), "Daniel", false, "Lopez", null },
                    { 14L, new DateTime(2023, 8, 10, 16, 53, 41, 235, DateTimeKind.Utc).AddTicks(5029), "Emma", false, "Gonzalez", null },
                    { 15L, new DateTime(2023, 8, 10, 16, 53, 41, 235, DateTimeKind.Utc).AddTicks(5030), "Alexander", false, "Perez", null }
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "Country", "CountryCode", "CreatedAt", "IsDeleted", "UpdatedAt" },
                values: new object[,]
                {
                    { 1L, "Uzbekistan", "UZ", new DateTime(2023, 8, 10, 16, 53, 41, 235, DateTimeKind.Utc).AddTicks(4984), false, null },
                    { 2L, "United States", "US", new DateTime(2023, 8, 10, 16, 53, 41, 235, DateTimeKind.Utc).AddTicks(4987), false, null },
                    { 3L, "Russia", "RU", new DateTime(2023, 8, 10, 16, 53, 41, 235, DateTimeKind.Utc).AddTicks(4988), false, null },
                    { 4L, "United Kingdom", "UK", new DateTime(2023, 8, 10, 16, 53, 41, 235, DateTimeKind.Utc).AddTicks(4989), false, null },
                    { 5L, "Germany", "DE", new DateTime(2023, 8, 10, 16, 53, 41, 235, DateTimeKind.Utc).AddTicks(4990), false, null },
                    { 6L, "France", "FR", new DateTime(2023, 8, 10, 16, 53, 41, 235, DateTimeKind.Utc).AddTicks(4990), false, null },
                    { 7L, "China", "CN", new DateTime(2023, 8, 10, 16, 53, 41, 235, DateTimeKind.Utc).AddTicks(4991), false, null },
                    { 8L, "India", "IN", new DateTime(2023, 8, 10, 16, 53, 41, 235, DateTimeKind.Utc).AddTicks(4992), false, null },
                    { 9L, "Japan", "JP", new DateTime(2023, 8, 10, 16, 53, 41, 235, DateTimeKind.Utc).AddTicks(4993), false, null },
                    { 10L, "South Korea", "KR", new DateTime(2023, 8, 10, 16, 53, 41, 235, DateTimeKind.Utc).AddTicks(4994), false, null }
                });

            migrationBuilder.InsertData(
                table: "Directors",
                columns: new[] { "Id", "CreatedAt", "FirstName", "IsDeleted", "LastName", "UpdatedAt" },
                values: new object[,]
                {
                    { 1L, new DateTime(2023, 8, 10, 16, 53, 41, 235, DateTimeKind.Utc).AddTicks(5055), "Christopher", false, "Nolan", null },
                    { 2L, new DateTime(2023, 8, 10, 16, 53, 41, 235, DateTimeKind.Utc).AddTicks(5057), "Steven", false, "Spielberg", null },
                    { 3L, new DateTime(2023, 8, 10, 16, 53, 41, 235, DateTimeKind.Utc).AddTicks(5058), "Quentin", false, "Tarantino", null },
                    { 4L, new DateTime(2023, 8, 10, 16, 53, 41, 235, DateTimeKind.Utc).AddTicks(5059), "Greta", false, "Gerwig", null },
                    { 5L, new DateTime(2023, 8, 10, 16, 53, 41, 235, DateTimeKind.Utc).AddTicks(5060), "Martin", false, "Scorsese", null },
                    { 6L, new DateTime(2023, 8, 10, 16, 53, 41, 235, DateTimeKind.Utc).AddTicks(5061), "Ava", false, "DuVernay", null },
                    { 7L, new DateTime(2023, 8, 10, 16, 53, 41, 235, DateTimeKind.Utc).AddTicks(5061), "Denis", false, "Villeneuve", null },
                    { 8L, new DateTime(2023, 8, 10, 16, 53, 41, 235, DateTimeKind.Utc).AddTicks(5062), "Kathryn", false, "Bigelow", null },
                    { 9L, new DateTime(2023, 8, 10, 16, 53, 41, 235, DateTimeKind.Utc).AddTicks(5063), "Taika", false, "Waititi", null },
                    { 10L, new DateTime(2023, 8, 10, 16, 53, 41, 235, DateTimeKind.Utc).AddTicks(5064), "Sofia", false, "Coppola", null }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "CreatedAt", "IsDeleted", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1L, new DateTime(2023, 8, 10, 16, 53, 41, 235, DateTimeKind.Utc).AddTicks(5087), false, "Action", null },
                    { 2L, new DateTime(2023, 8, 10, 16, 53, 41, 235, DateTimeKind.Utc).AddTicks(5089), false, "Drama", null },
                    { 3L, new DateTime(2023, 8, 10, 16, 53, 41, 235, DateTimeKind.Utc).AddTicks(5089), false, "Comedy", null },
                    { 4L, new DateTime(2023, 8, 10, 16, 53, 41, 235, DateTimeKind.Utc).AddTicks(5090), false, "Science Fiction", null },
                    { 5L, new DateTime(2023, 8, 10, 16, 53, 41, 235, DateTimeKind.Utc).AddTicks(5091), false, "Adventure", null },
                    { 6L, new DateTime(2023, 8, 10, 16, 53, 41, 235, DateTimeKind.Utc).AddTicks(5092), false, "Horror", null },
                    { 7L, new DateTime(2023, 8, 10, 16, 53, 41, 235, DateTimeKind.Utc).AddTicks(5092), false, "Fantasy", null },
                    { 8L, new DateTime(2023, 8, 10, 16, 53, 41, 235, DateTimeKind.Utc).AddTicks(5093), false, "Romance", null },
                    { 9L, new DateTime(2023, 8, 10, 16, 53, 41, 235, DateTimeKind.Utc).AddTicks(5093), false, "Thriller", null },
                    { 10L, new DateTime(2023, 8, 10, 16, 53, 41, 235, DateTimeKind.Utc).AddTicks(5094), false, "Animation", null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "DateOfBirth", "Email", "FirstName", "IsDeleted", "LastName", "Password", "Phone", "Role", "UpdatedAt" },
                values: new object[,]
                {
                    { 1L, new DateTime(2023, 8, 10, 16, 53, 41, 235, DateTimeKind.Utc).AddTicks(4826), new DateTime(1998, 7, 21, 19, 0, 0, 0, DateTimeKind.Utc), "muqimjon@gmail.com", "Muqimjon", false, "Mamadaliyev", "a", "+998937349808", 3, null },
                    { 2L, new DateTime(2023, 8, 10, 16, 53, 41, 235, DateTimeKind.Utc).AddTicks(4854), new DateTime(2006, 10, 12, 19, 0, 0, 0, DateTimeKind.Utc), "abdurahmon@gmail.com", "Iskandar", false, "Qodirov", "a", "+998972350120", 3, null },
                    { 3L, new DateTime(2023, 8, 10, 16, 53, 41, 235, DateTimeKind.Utc).AddTicks(4856), new DateTime(2005, 11, 3, 19, 0, 0, 0, DateTimeKind.Utc), "madiyor@gmail.com", "Madiyor", false, "Odilov", "a", "+998903638333", 3, null },
                    { 4L, new DateTime(2023, 8, 10, 16, 53, 41, 235, DateTimeKind.Utc).AddTicks(4858), new DateTime(2004, 2, 19, 19, 0, 0, 0, DateTimeKind.Utc), "nodir@gmail.com", "Nodir", false, "Ollonazarov", "a", "+998881813525", 3, null },
                    { 5L, new DateTime(2023, 8, 10, 16, 53, 41, 235, DateTimeKind.Utc).AddTicks(4860), new DateTime(2003, 8, 15, 19, 0, 0, 0, DateTimeKind.Utc), "nurullo@gmail.com", "Nurullo", false, "Nurmatov", "a", "+998330022816", 3, null },
                    { 6L, new DateTime(2023, 8, 10, 16, 53, 41, 235, DateTimeKind.Utc).AddTicks(4862), new DateTime(2002, 8, 17, 19, 0, 0, 0, DateTimeKind.Utc), "ravshanbek@gmail.com", "Ravshanbek", false, "Isroilov", "a", "+998902528196", 3, null },
                    { 7L, new DateTime(2023, 8, 10, 16, 53, 41, 235, DateTimeKind.Utc).AddTicks(4863), new DateTime(1988, 4, 6, 19, 0, 0, 0, DateTimeKind.Utc), "avazbek@gmail.com", "Avazbek", false, "Siddiqov", "a", "+998973340334", 3, null },
                    { 8L, new DateTime(2023, 8, 10, 16, 53, 41, 235, DateTimeKind.Utc).AddTicks(4865), new DateTime(2001, 11, 27, 19, 0, 0, 0, DateTimeKind.Utc), "abdualim@gmail.com", "Abdualim", false, "Normurodov", "a", "+998950642799", 3, null }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "AddressId", "CreatedAt", "DirectorId", "GenreId", "IsDeleted", "Rating", "ReleaseDate", "Title", "UpdatedAt" },
                values: new object[,]
                {
                    { 1L, 1L, new DateTime(2023, 8, 10, 16, 53, 41, 235, DateTimeKind.Utc).AddTicks(5115), 1L, 4L, false, 4.8m, new DateTime(2023, 3, 9, 19, 0, 0, 0, DateTimeKind.Utc), "Inception", null },
                    { 2L, 2L, new DateTime(2023, 8, 10, 16, 53, 41, 235, DateTimeKind.Utc).AddTicks(5127), 2L, 2L, false, 4.5m, new DateTime(2022, 7, 19, 19, 0, 0, 0, DateTimeKind.Utc), "The Shawshank Redemption", null },
                    { 3L, 1L, new DateTime(2023, 8, 10, 16, 53, 41, 235, DateTimeKind.Utc).AddTicks(5129), 1L, 1L, false, 8.5m, new DateTime(2022, 7, 14, 19, 0, 0, 0, DateTimeKind.Utc), "Adventure Awaits", null },
                    { 4L, 3L, new DateTime(2023, 8, 10, 16, 53, 41, 235, DateTimeKind.Utc).AddTicks(5131), 3L, 9L, false, 4.7m, new DateTime(2021, 5, 14, 19, 0, 0, 0, DateTimeKind.Utc), "Pulp Fiction", null },
                    { 5L, 4L, new DateTime(2023, 8, 10, 16, 53, 41, 235, DateTimeKind.Utc).AddTicks(5132), 4L, 8L, false, 4.6m, new DateTime(2020, 9, 7, 19, 0, 0, 0, DateTimeKind.Utc), "The Great Gatsby", null },
                    { 6L, 5L, new DateTime(2023, 8, 10, 16, 53, 41, 235, DateTimeKind.Utc).AddTicks(5134), 5L, 2L, false, 4.3m, new DateTime(2019, 2, 4, 19, 0, 0, 0, DateTimeKind.Utc), "The Irishman", null }
                });

            migrationBuilder.InsertData(
                table: "MovieActor",
                columns: new[] { "Id", "ActorId", "CreatedAt", "IsDeleted", "MovieId", "UpdatedAt" },
                values: new object[,]
                {
                    { 1L, 1L, new DateTime(2023, 8, 10, 16, 53, 41, 236, DateTimeKind.Utc).AddTicks(8211), false, 1L, null },
                    { 2L, 2L, new DateTime(2023, 8, 10, 16, 53, 41, 236, DateTimeKind.Utc).AddTicks(8214), false, 1L, null },
                    { 3L, 3L, new DateTime(2023, 8, 10, 16, 53, 41, 236, DateTimeKind.Utc).AddTicks(8215), false, 1L, null },
                    { 4L, 2L, new DateTime(2023, 8, 10, 16, 53, 41, 236, DateTimeKind.Utc).AddTicks(8216), false, 2L, null },
                    { 5L, 4L, new DateTime(2023, 8, 10, 16, 53, 41, 236, DateTimeKind.Utc).AddTicks(8216), false, 2L, null },
                    { 6L, 6L, new DateTime(2023, 8, 10, 16, 53, 41, 236, DateTimeKind.Utc).AddTicks(8217), false, 2L, null },
                    { 7L, 3L, new DateTime(2023, 8, 10, 16, 53, 41, 236, DateTimeKind.Utc).AddTicks(8218), false, 3L, null },
                    { 8L, 5L, new DateTime(2023, 8, 10, 16, 53, 41, 236, DateTimeKind.Utc).AddTicks(8219), false, 3L, null },
                    { 9L, 7L, new DateTime(2023, 8, 10, 16, 53, 41, 236, DateTimeKind.Utc).AddTicks(8219), false, 3L, null },
                    { 10L, 4L, new DateTime(2023, 8, 10, 16, 53, 41, 236, DateTimeKind.Utc).AddTicks(8220), false, 4L, null },
                    { 11L, 8L, new DateTime(2023, 8, 10, 16, 53, 41, 236, DateTimeKind.Utc).AddTicks(8221), false, 4L, null },
                    { 12L, 10L, new DateTime(2023, 8, 10, 16, 53, 41, 236, DateTimeKind.Utc).AddTicks(8222), false, 4L, null },
                    { 13L, 5L, new DateTime(2023, 8, 10, 16, 53, 41, 236, DateTimeKind.Utc).AddTicks(8222), false, 5L, null },
                    { 14L, 10L, new DateTime(2023, 8, 10, 16, 53, 41, 236, DateTimeKind.Utc).AddTicks(8223), false, 5L, null },
                    { 15L, 12L, new DateTime(2023, 8, 10, 16, 53, 41, 236, DateTimeKind.Utc).AddTicks(8224), false, 5L, null },
                    { 16L, 6L, new DateTime(2023, 8, 10, 16, 53, 41, 236, DateTimeKind.Utc).AddTicks(8224), false, 6L, null },
                    { 17L, 12L, new DateTime(2023, 8, 10, 16, 53, 41, 236, DateTimeKind.Utc).AddTicks(8225), false, 6L, null },
                    { 18L, 14L, new DateTime(2023, 8, 10, 16, 53, 41, 236, DateTimeKind.Utc).AddTicks(8226), false, 6L, null }
                });

            migrationBuilder.InsertData(
                table: "UserRatings",
                columns: new[] { "Id", "Comment", "CreatedAt", "IsDeleted", "MovieId", "Rating", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { 1L, "Amazing movie!", new DateTime(2023, 8, 10, 16, 53, 41, 235, DateTimeKind.Utc).AddTicks(5155), false, 1L, 5, null, 1L },
                    { 2L, "Really enjoyed it.", new DateTime(2023, 8, 10, 16, 53, 41, 235, DateTimeKind.Utc).AddTicks(5159), false, 2L, 4, null, 2L },
                    { 3L, "Good story.", new DateTime(2023, 8, 10, 16, 53, 41, 235, DateTimeKind.Utc).AddTicks(5160), false, 4L, 4, null, 3L },
                    { 4L, "Impressive acting.", new DateTime(2023, 8, 10, 16, 53, 41, 235, DateTimeKind.Utc).AddTicks(5162), false, 1L, 5, null, 4L },
                    { 5L, "Not bad.", new DateTime(2023, 8, 10, 16, 53, 41, 235, DateTimeKind.Utc).AddTicks(5163), false, 5L, 3, null, 5L },
                    { 6L, "Entertaining!", new DateTime(2023, 8, 10, 16, 53, 41, 235, DateTimeKind.Utc).AddTicks(5163), false, 6L, 4, null, 6L },
                    { 7L, "A true masterpiece.", new DateTime(2023, 8, 10, 16, 53, 41, 235, DateTimeKind.Utc).AddTicks(5164), false, 5L, 4, null, 7L },
                    { 8L, "Outstanding.", new DateTime(2023, 8, 10, 16, 53, 41, 235, DateTimeKind.Utc).AddTicks(5165), false, 4L, 5, null, 8L },
                    { 9L, "Enjoyed the movie", new DateTime(2023, 8, 10, 16, 53, 41, 235, DateTimeKind.Utc).AddTicks(5166), false, 3L, 4, null, 1L }
                });

            migrationBuilder.CreateIndex(
                name: "IX_MovieActor_ActorId",
                table: "MovieActor",
                column: "ActorId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieActor_MovieId",
                table: "MovieActor",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_AddressId",
                table: "Movies",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_DirectorId",
                table: "Movies",
                column: "DirectorId");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_GenreId",
                table: "Movies",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRatings_MovieId",
                table: "UserRatings",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRatings_UserId",
                table: "UserRatings",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieActor");

            migrationBuilder.DropTable(
                name: "UserRatings");

            migrationBuilder.DropTable(
                name: "Actors");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Directors");

            migrationBuilder.DropTable(
                name: "Genres");
        }
    }
}
