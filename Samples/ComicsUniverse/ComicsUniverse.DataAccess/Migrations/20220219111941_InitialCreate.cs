using Microsoft.EntityFrameworkCore.Migrations;

namespace ComicsUniverse.DataAccess.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Characters",
                columns: table => new
                {
                    CharacterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Alias = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Occupation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Universe = table.Column<int>(type: "int", nullable: false),
                    ProfileImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.CharacterId);
                });

            migrationBuilder.CreateTable(
                name: "SuperPowers",
                columns: table => new
                {
                    SuperPowerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SuperPowers", x => x.SuperPowerId);
                });

            migrationBuilder.CreateTable(
                name: "CharacterSuperPower",
                columns: table => new
                {
                    CharactersCharacterId = table.Column<int>(type: "int", nullable: false),
                    PowersSuperPowerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterSuperPower", x => new { x.CharactersCharacterId, x.PowersSuperPowerId });
                    table.ForeignKey(
                        name: "FK_CharacterSuperPower_Characters_CharactersCharacterId",
                        column: x => x.CharactersCharacterId,
                        principalTable: "Characters",
                        principalColumn: "CharacterId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharacterSuperPower_SuperPowers_PowersSuperPowerId",
                        column: x => x.PowersSuperPowerId,
                        principalTable: "SuperPowers",
                        principalColumn: "SuperPowerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Characters",
                columns: new[] { "CharacterId", "Alias", "Description", "Name", "Occupation", "ProfileImage", "Universe" },
                values: new object[,]
                {
                    { 1, "Clark Kent, Kal-El", "Faster than a speeding bullet, more powerful than a locomotive… The Man of Steel fights a never-ending battle for truth, justice, and the American way. From his blue uniform to his flowing red cape to the 'S' shield on his chest, Superman is one of the most immediately recognizable and beloved DC Super Heroes of all time. The Man of Steel is the ultimate symbol of truth, justice, and hope. He is the world's first Super Hero and a guiding light to all.", "Superman", "Reporter", "Superman.jpg", 1 },
                    { 2, "Hal Jordan", "Test pilot Hal Jordan went from being a novelty, the first-ever human Green Lantern, to one of the most legendary Lanterns to ever wield a power ring. Hal Jordan’s life was changed twice by crashing aircraft. The first time was when he witnessed the death of his father, pilot Martin Jordan. The second was when, as an adult and trained pilot himself, he was summoned to the crashed wreckage of a spaceship belonging to an alien named Abin Sur. Abin explained that he was a member of the Green Lantern Corps, an organization of beings from across the cosmos, armed with power rings fueled by the green energy of all willpower in the universe. Upon his death, Abin entrusted his ring and duties as the Green Lantern of Earth’s space sector to Hal Jordan.", "Green Lantern", "Test pilot", "GreenLantern.jpg", 1 },
                    { 3, "Diana Prince", "Beautiful as Aphrodite, wise as Athena, swifter than Hermes, and stronger than Hercules, Princess Diana of Themyscira fights for peace in Man's World. One of the most beloved and iconic DC Super Heroes of all time, Wonder Woman has stood for nearly eighty years as a symbol of truth, justice and equality to people everywhere. Raised on the hidden island of Themyscira, also known as Paradise Island, Diana is an Amazon, like the figures of Greek legend, and her people's gift to humanity.", "Wonder Woman", null, "WonderWoman.jpg", 1 },
                    { 4, "Christopher Smith", "A huge, hulking specimen with muscles on his muscles, Christopher Smith is a world class marksman - just like his fellow Suicide Squad member, Bloodsport. (But if you ask him, better.) Having adopted the name Peacemaker, Christopher is more than willing to fight, kill and even start a war... all in the name of keeping the peace.", "Peacemaker", null, "Peacemaker.jpg", 1 }
                });

            migrationBuilder.InsertData(
                table: "SuperPowers",
                columns: new[] { "SuperPowerId", "Name" },
                values: new object[,]
                {
                    { 19, "alien technology" },
                    { 18, "durability" },
                    { 17, "flight" },
                    { 16, "force fields" },
                    { 15, "instant weaponry" },
                    { 14, "hard light constructs" },
                    { 13, "magic weaponry" },
                    { 12, "superhuman agility" },
                    { 11, "combat strategy" },
                    { 9, "superhuman hearing" },
                    { 20, "top level marksman" },
                    { 8, "x-ray vision" },
                    { 7, "freeze breath" },
                    { 6, "heat vision" },
                    { 5, "super speed" },
                    { 4, "invulnerability" },
                    { 3, "flight" },
                    { 2, "super strength" },
                    { 1, "healing factor" },
                    { 10, "combat skill" },
                    { 21, "weapons expert" }
                });

            migrationBuilder.InsertData(
                table: "CharacterSuperPower",
                columns: new[] { "CharactersCharacterId", "PowersSuperPowerId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 19 },
                    { 2, 18 },
                    { 2, 17 },
                    { 2, 16 },
                    { 2, 15 },
                    { 2, 14 },
                    { 3, 13 },
                    { 3, 12 },
                    { 3, 11 },
                    { 4, 10 },
                    { 3, 10 },
                    { 1, 9 },
                    { 1, 8 },
                    { 1, 7 },
                    { 1, 6 },
                    { 1, 5 },
                    { 3, 4 },
                    { 1, 4 },
                    { 3, 3 },
                    { 1, 3 },
                    { 3, 2 },
                    { 1, 2 },
                    { 3, 1 },
                    { 4, 20 },
                    { 4, 21 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CharacterSuperPower_PowersSuperPowerId",
                table: "CharacterSuperPower",
                column: "PowersSuperPowerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CharacterSuperPower");

            migrationBuilder.DropTable(
                name: "Characters");

            migrationBuilder.DropTable(
                name: "SuperPowers");
        }
    }
}
