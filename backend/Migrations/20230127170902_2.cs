using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace clinicalhandoverwebapi.Migrations
{
    /// <inheritdoc />
    public partial class _2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            var sqlFile = Directory.GetCurrentDirectory() + @"/Resources/historyTable.sql"; 
            migrationBuilder.Sql(File.ReadAllText(sqlFile));
            migrationBuilder.Sql("EXEC sp_fill_history");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
