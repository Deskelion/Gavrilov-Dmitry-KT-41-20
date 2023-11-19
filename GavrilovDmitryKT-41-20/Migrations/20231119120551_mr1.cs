using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace GavrilovDmitryKT_41_20.Migrations
{
    /// <inheritdoc />
    public partial class mr1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    subject_id = table.Column<int>(type: "integer", nullable: false, comment: "Идентификатор дисциплины")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    subject_title = table.Column<string>(type: "varchar", maxLength: 100, nullable: false, comment: "Название дисциплины"),
                    subject_type = table.Column<string>(type: "varchar", maxLength: 100, nullable: false, comment: "Тип дисциплины"),
                    subject_totaltime = table.Column<int>(type: "int4", nullable: false, comment: "Суммарное время дисциплины")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_(TableName)_Id", x => x.subject_id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Subjects");
        }
    }
}
