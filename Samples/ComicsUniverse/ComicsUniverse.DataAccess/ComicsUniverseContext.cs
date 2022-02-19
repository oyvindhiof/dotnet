using ComicsUniverse.DataAccess.Model;
using ComicsUniverse.ViewModels;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;

namespace ComicsUniverse.DataAccess
{
    public class ComicsUniverseContext : DbContext
    {
        // The constructor is used by the RESTful HTTP service (the api)
        public ComicsUniverseContext(DbContextOptions<ComicsUniverseContext> options) : base(options) { }

        // OnConfiguring is used by the EF tool to generate the database, i.e. when you run the Update-Database command
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            SqlConnectionStringBuilder sqlConnectionStringBuilder = new();
            sqlConnectionStringBuilder.DataSource = @"(localdb)\MSSQLLocalDB";
            sqlConnectionStringBuilder.InitialCatalog = "ComicsUniverse.Database";

            _ = optionsBuilder.UseSqlServer(sqlConnectionStringBuilder.ToString());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new SuperPowerEntityTypeConfiguration().Configure(modelBuilder.Entity<SuperPower>());
            new CharacterEntityTypeConfiguration().Configure(modelBuilder.Entity<Character>());
        }

        public DbSet<Character> Characters { get; set; }
        public DbSet<SuperPower> SuperPowers { get; set; }
    }

    public class SuperPowerEntityTypeConfiguration : IEntityTypeConfiguration<SuperPower>
    {
        public void Configure(EntityTypeBuilder<SuperPower> builder)
        {
            #region Seeding Powers
            builder.HasData(new SuperPower { SuperPowerId = 1, Name = "healing factor" });
            builder.HasData(new SuperPower { SuperPowerId = 2, Name = "super strength" });
            builder.HasData(new SuperPower { SuperPowerId = 3, Name = "flight" });
            builder.HasData(new SuperPower { SuperPowerId = 4, Name = "invulnerability" });
            builder.HasData(new SuperPower { SuperPowerId = 5, Name = "super speed" });
            builder.HasData(new SuperPower { SuperPowerId = 6, Name = "heat vision" });
            builder.HasData(new SuperPower { SuperPowerId = 7, Name = "freeze breath" });
            builder.HasData(new SuperPower { SuperPowerId = 8, Name = "x-ray vision" });
            builder.HasData(new SuperPower { SuperPowerId = 9, Name = "superhuman hearing" });
            builder.HasData(new SuperPower { SuperPowerId = 10, Name = "combat skill" });
            builder.HasData(new SuperPower { SuperPowerId = 11, Name = "combat strategy" });
            builder.HasData(new SuperPower { SuperPowerId = 12, Name = "superhuman agility" });
            builder.HasData(new SuperPower { SuperPowerId = 13, Name = "magic weaponry" });
            builder.HasData(new SuperPower { SuperPowerId = 14, Name = "hard light constructs" });
            builder.HasData(new SuperPower { SuperPowerId = 15, Name = "instant weaponry" });
            builder.HasData(new SuperPower { SuperPowerId = 16, Name = "force fields" });
            builder.HasData(new SuperPower { SuperPowerId = 17, Name = "flight" });
            builder.HasData(new SuperPower { SuperPowerId = 18, Name = "durability" });
            builder.HasData(new SuperPower { SuperPowerId = 19, Name = "alien technology" });
            builder.HasData(new SuperPower { SuperPowerId = 20, Name = "top level marksman" });
            builder.HasData(new SuperPower { SuperPowerId = 21, Name = "weapons expert" });
            #endregion
        }
    }
    public class CharacterEntityTypeConfiguration : IEntityTypeConfiguration<Character>
    {
        public void Configure(EntityTypeBuilder<Character> builder)
        {
            #region Seeding Characters
            var description = "Faster than a speeding bullet, more powerful than a locomotive… The Man of Steel fights a never-ending battle for truth, justice, and the American way. From his blue uniform to his flowing red cape to the 'S' shield on his chest, Superman is one of the most immediately recognizable and beloved DC Super Heroes of all time. The Man of Steel is the ultimate symbol of truth, justice, and hope. He is the world's first Super Hero and a guiding light to all.";
            builder.HasData(new Character { CharacterId = 1, Name = "Superman", ProfileImage = "Superman.jpg", Alias = "Clark Kent, Kal-El", Description = description, Universe = Universes.DC, Occupation = "Reporter" });

            description = "Test pilot Hal Jordan went from being a novelty, the first-ever human Green Lantern, to one of the most legendary Lanterns to ever wield a power ring. Hal Jordan’s life was changed twice by crashing aircraft. The first time was when he witnessed the death of his father, pilot Martin Jordan. The second was when, as an adult and trained pilot himself, he was summoned to the crashed wreckage of a spaceship belonging to an alien named Abin Sur. Abin explained that he was a member of the Green Lantern Corps, an organization of beings from across the cosmos, armed with power rings fueled by the green energy of all willpower in the universe. Upon his death, Abin entrusted his ring and duties as the Green Lantern of Earth’s space sector to Hal Jordan.";
            builder.HasData(new Character { CharacterId = 2, Name = "Green Lantern", ProfileImage = "GreenLantern.jpg", Alias = "Hal Jordan", Description = description, Universe = Universes.DC, Occupation = "Test pilot" });

            description = "Beautiful as Aphrodite, wise as Athena, swifter than Hermes, and stronger than Hercules, Princess Diana of Themyscira fights for peace in Man's World. One of the most beloved and iconic DC Super Heroes of all time, Wonder Woman has stood for nearly eighty years as a symbol of truth, justice and equality to people everywhere. Raised on the hidden island of Themyscira, also known as Paradise Island, Diana is an Amazon, like the figures of Greek legend, and her people's gift to humanity.";
            builder.HasData(new Character { CharacterId = 3, Name = "Wonder Woman", ProfileImage = "WonderWoman.jpg", Alias = "Diana Prince", Description = description, Universe = Universes.DC });

            description = "A huge, hulking specimen with muscles on his muscles, Christopher Smith is a world class marksman - just like his fellow Suicide Squad member, Bloodsport. (But if you ask him, better.) Having adopted the name Peacemaker, Christopher is more than willing to fight, kill and even start a war... all in the name of keeping the peace.";
            builder.HasData(new Character { CharacterId = 4, Name = "Peacemaker", ProfileImage = "Peacemaker.jpg", Alias = "Christopher Smith", Description = description, Universe = Universes.DC });
            #endregion

            #region Character powers
            builder
                .HasMany(c => c.Powers)
                .WithMany(p => p.Characters)
                .UsingEntity<Dictionary<string, object>>(
                    "CharacterSuperPower",
                    r => r.HasOne<SuperPower>().WithMany().HasForeignKey("PowersSuperPowerId"),
                    l => l.HasOne<Character>().WithMany().HasForeignKey("CharactersCharacterId"),
                    je =>
                    {
                        je.HasKey("CharactersCharacterId", "PowersSuperPowerId");
                        je.HasData(
                        #region Superman powers
                            new { CharactersCharacterId = 1, PowersSuperPowerId = 1 },
                            new { CharactersCharacterId = 1, PowersSuperPowerId = 2 },
                            new { CharactersCharacterId = 1, PowersSuperPowerId = 3 },
                            new { CharactersCharacterId = 1, PowersSuperPowerId = 4 },
                            new { CharactersCharacterId = 1, PowersSuperPowerId = 5 },
                            new { CharactersCharacterId = 1, PowersSuperPowerId = 6 },
                            new { CharactersCharacterId = 1, PowersSuperPowerId = 7 },
                            new { CharactersCharacterId = 1, PowersSuperPowerId = 8 },
                            new { CharactersCharacterId = 1, PowersSuperPowerId = 9 },
                        #endregion
                        #region Green Lantern powers
                            new { CharactersCharacterId = 2, PowersSuperPowerId = 14 },
                            new { CharactersCharacterId = 2, PowersSuperPowerId = 15 },
                            new { CharactersCharacterId = 2, PowersSuperPowerId = 16 },
                            new { CharactersCharacterId = 2, PowersSuperPowerId = 17 },
                            new { CharactersCharacterId = 2, PowersSuperPowerId = 18 },
                            new { CharactersCharacterId = 2, PowersSuperPowerId = 19 },
                        #endregion
                        #region Wonder Woman powers
                            new { CharactersCharacterId = 3, PowersSuperPowerId = 1 },
                            new { CharactersCharacterId = 3, PowersSuperPowerId = 2 },
                            new { CharactersCharacterId = 3, PowersSuperPowerId = 3 },
                            new { CharactersCharacterId = 3, PowersSuperPowerId = 4 },
                            new { CharactersCharacterId = 3, PowersSuperPowerId = 10 },
                            new { CharactersCharacterId = 3, PowersSuperPowerId = 11 },
                            new { CharactersCharacterId = 3, PowersSuperPowerId = 12 },
                            new { CharactersCharacterId = 3, PowersSuperPowerId = 13 },
                        #endregion
                        #region Peacemaker powers
                            new { CharactersCharacterId = 4, PowersSuperPowerId = 10 },
                            new { CharactersCharacterId = 4, PowersSuperPowerId = 20 },
                            new { CharactersCharacterId = 4, PowersSuperPowerId = 21 });
                        #endregion
                    });
            #endregion
        }
    }
}
