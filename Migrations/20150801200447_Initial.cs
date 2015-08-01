using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;
using Microsoft.Data.Entity.Migrations.Builders;
using Microsoft.Data.Entity.Migrations.Operations;

namespace rollsMigrations
{
    public partial class Initial : Migration
    {
        public override void Up(MigrationBuilder migration)
        {
            migration.CreateTable(
                name: "Roll",
                columns: table => new
                {
                    Id = table.Column(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", "IdentityColumn"),
                    CreatedAt = table.Column(type: "datetime2", nullable: false),
                    Name = table.Column(type: "nvarchar(max)", nullable: true),
                    Value = table.Column(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roll", x => x.Id);
                });
        }

        public override void Down(MigrationBuilder migration)
        {
            migration.DropTable("Roll");
        }
    }
}
