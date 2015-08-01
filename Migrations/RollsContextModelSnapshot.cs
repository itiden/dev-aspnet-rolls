using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations.Infrastructure;
using Rolls.Models;

namespace rollsMigrations
{
    [ContextType(typeof(RollsContext))]
    partial class RollsContextModelSnapshot : ModelSnapshot
    {
        public override void BuildModel(ModelBuilder builder)
        {
            builder
                .Annotation("ProductVersion", "7.0.0-beta6-13815")
                .Annotation("SqlServer:ValueGenerationStrategy", "IdentityColumn");

            builder.Entity("Rolls.Models.Roll", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Name");

                    b.Property<int>("Value");

                    b.Key("Id");
                });
        }
    }
}
