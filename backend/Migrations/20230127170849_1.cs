using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace clinicalhandoverwebapi.Migrations
{
    /// <inheritdoc />
    public partial class _1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GetWardPatients",
                columns: table => new
                {
                    PatientKey = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    AdmissionTime = table.Column<DateTime>(type: "datetime2(0)", precision: 0, nullable: true),
                    BedNumber = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    CaseNumber = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: true),
                    Dob = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PatientName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Sex = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    SpecialtyCode = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    WardCode = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GetWardPatients", x => x.PatientKey);
                });

            migrationBuilder.CreateTable(
                name: "HandoverGroups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SpecialtyCode = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HandoverGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Handover",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "HandoverHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart"),
                    patientKey = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "HandoverHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart"),
                    patientName = table.Column<string>(type: "nvarchar(48)", maxLength: 48, nullable: true)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "HandoverHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart"),
                    dob = table.Column<DateTime>(type: "datetime2", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "HandoverHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart"),
                    sex = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "HandoverHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart"),
                    wardCode = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "HandoverHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart"),
                    specialtyCode = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "HandoverHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart"),
                    bedNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "HandoverHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart"),
                    admissionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "HandoverHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart"),
                    caseNumber = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: true)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "HandoverHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart"),
                    freeText = table.Column<string>(type: "nvarchar(max)", nullable: true)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "HandoverHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart"),
                    diagnosis = table.Column<string>(type: "nvarchar(max)", nullable: true)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "HandoverHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart"),
                    background = table.Column<string>(type: "nvarchar(max)", nullable: true)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "HandoverHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart"),
                    progress = table.Column<string>(type: "nvarchar(max)", nullable: true)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "HandoverHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart"),
                    ix = table.Column<string>(type: "nvarchar(max)", nullable: true)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "HandoverHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart"),
                    drugs = table.Column<string>(type: "nvarchar(max)", nullable: true)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "HandoverHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart"),
                    recommendation = table.Column<string>(type: "nvarchar(max)", nullable: true)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "HandoverHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart"),
                    editedBy = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "HandoverHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart"),
                    GroupId = table.Column<int>(type: "int", nullable: true)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "HandoverHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart"),
                    PeriodEnd = table.Column<DateTime>(type: "datetime2", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "HandoverHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart"),
                    PeriodStart = table.Column<DateTime>(type: "datetime2", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "HandoverHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Handover", x => x.id);
                    table.ForeignKey(
                        name: "FK_Handover_HandoverGroups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "HandoverGroups",
                        principalColumn: "Id");
                })
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "HandoverHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart");

            migrationBuilder.CreateTable(
                name: "HandoverLogs",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LogTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LogText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LogBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HandoverId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HandoverLogs", x => x.id);
                    table.ForeignKey(
                        name: "FK_HandoverLogs_Handover_HandoverId",
                        column: x => x.HandoverId,
                        principalTable: "Handover",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "GetWardPatients",
                columns: new[] { "PatientKey", "AdmissionTime", "BedNumber", "CaseNumber", "Dob", "PatientName", "Sex", "SpecialtyCode", "UpdateDate", "WardCode" },
                values: new object[,]
                {
                    { "100", new DateTime(2023, 1, 9, 5, 53, 55, 0, DateTimeKind.Unspecified), "333", "HN100", new DateTime(2022, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Eliza", "M", "ONC", new DateTime(2023, 1, 28, 1, 4, 53, 0, DateTimeKind.Unspecified), "3S" },
                    { "101", new DateTime(2023, 1, 7, 1, 35, 40, 0, DateTimeKind.Unspecified), "350", "HN101", new DateTime(2022, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Laverne", "M", "ONC", new DateTime(2023, 1, 28, 1, 4, 53, 0, DateTimeKind.Unspecified), "3S" },
                    { "102", new DateTime(2022, 12, 2, 4, 54, 15, 0, DateTimeKind.Unspecified), "309", "HN102", new DateTime(2022, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nolan", "M", "ONC", new DateTime(2023, 1, 28, 1, 4, 53, 0, DateTimeKind.Unspecified), "3S" },
                    { "103", new DateTime(2023, 1, 19, 11, 4, 18, 0, DateTimeKind.Unspecified), "308", "HN103", new DateTime(2022, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fanny", "F", "ONC", new DateTime(2023, 1, 28, 1, 4, 53, 0, DateTimeKind.Unspecified), "3S" },
                    { "104", new DateTime(2022, 12, 23, 2, 18, 15, 0, DateTimeKind.Unspecified), "342", "HN104", new DateTime(2022, 7, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gray", "M", "ONC", new DateTime(2023, 1, 28, 1, 4, 53, 0, DateTimeKind.Unspecified), "3S" },
                    { "105", new DateTime(2023, 1, 10, 8, 49, 16, 0, DateTimeKind.Unspecified), "305", "HN105", new DateTime(2022, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mejia", "M", "ONC", new DateTime(2023, 1, 28, 1, 4, 53, 0, DateTimeKind.Unspecified), "3S" },
                    { "106", new DateTime(2022, 12, 9, 6, 49, 36, 0, DateTimeKind.Unspecified), "312", "HN106", new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Shepard", "F", "ONC", new DateTime(2023, 1, 28, 1, 4, 53, 0, DateTimeKind.Unspecified), "3S" },
                    { "107", new DateTime(2022, 12, 2, 11, 31, 21, 0, DateTimeKind.Unspecified), "359", "HN107", new DateTime(2022, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Christa", "F", "ONC", new DateTime(2023, 1, 28, 1, 4, 53, 0, DateTimeKind.Unspecified), "3S" },
                    { "108", new DateTime(2023, 1, 14, 11, 50, 14, 0, DateTimeKind.Unspecified), "344", "HN108", new DateTime(2022, 9, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jeri", "M", "ONC", new DateTime(2023, 1, 28, 1, 4, 53, 0, DateTimeKind.Unspecified), "3S" },
                    { "109", new DateTime(2022, 12, 31, 9, 54, 1, 0, DateTimeKind.Unspecified), "355", "HN109", new DateTime(2023, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Wooten", "M", "ONC", new DateTime(2023, 1, 28, 1, 4, 53, 0, DateTimeKind.Unspecified), "3S" },
                    { "110", new DateTime(2022, 12, 10, 2, 36, 58, 0, DateTimeKind.Unspecified), "346", "HN110", new DateTime(2023, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sheri", "F", "ONC", new DateTime(2023, 1, 28, 1, 4, 53, 0, DateTimeKind.Unspecified), "3S" },
                    { "111", new DateTime(2023, 1, 10, 6, 55, 0, 0, DateTimeKind.Unspecified), "344", "HN111", new DateTime(2022, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rosella", "F", "ONC", new DateTime(2023, 1, 28, 1, 4, 53, 0, DateTimeKind.Unspecified), "3S" },
                    { "112", new DateTime(2022, 12, 6, 1, 57, 45, 0, DateTimeKind.Unspecified), "313", "HN112", new DateTime(2022, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Velez", "M", "ONC", new DateTime(2023, 1, 28, 1, 4, 53, 0, DateTimeKind.Unspecified), "3S" },
                    { "113", new DateTime(2023, 1, 5, 7, 2, 4, 0, DateTimeKind.Unspecified), "315", "HN113", new DateTime(2022, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sheree", "F", "ONC", new DateTime(2023, 1, 28, 1, 4, 53, 0, DateTimeKind.Unspecified), "3S" },
                    { "114", new DateTime(2023, 1, 3, 3, 36, 30, 0, DateTimeKind.Unspecified), "306", "HN114", new DateTime(2022, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Osborn", "M", "ONC", new DateTime(2023, 1, 28, 1, 4, 53, 0, DateTimeKind.Unspecified), "3S" },
                    { "115", new DateTime(2022, 12, 9, 9, 33, 44, 0, DateTimeKind.Unspecified), "319", "HN115", new DateTime(2022, 4, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jeannette", "F", "ONC", new DateTime(2023, 1, 28, 1, 4, 53, 0, DateTimeKind.Unspecified), "3S" },
                    { "116", new DateTime(2022, 12, 11, 4, 10, 21, 0, DateTimeKind.Unspecified), "338", "HN116", new DateTime(2022, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Virgie", "M", "ONC", new DateTime(2023, 1, 28, 1, 4, 53, 0, DateTimeKind.Unspecified), "3S" },
                    { "117", new DateTime(2023, 1, 7, 10, 7, 41, 0, DateTimeKind.Unspecified), "302", "HN117", new DateTime(2022, 3, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Barr", "F", "ONC", new DateTime(2023, 1, 28, 1, 4, 53, 0, DateTimeKind.Unspecified), "3S" },
                    { "118", new DateTime(2022, 12, 1, 8, 36, 5, 0, DateTimeKind.Unspecified), "359", "HN118", new DateTime(2022, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Parsons", "M", "ONC", new DateTime(2023, 1, 28, 1, 4, 53, 0, DateTimeKind.Unspecified), "3S" },
                    { "119", new DateTime(2022, 12, 3, 2, 47, 45, 0, DateTimeKind.Unspecified), "335", "HN119", new DateTime(2022, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Salas", "M", "ONC", new DateTime(2023, 1, 28, 1, 4, 53, 0, DateTimeKind.Unspecified), "3S" },
                    { "120", new DateTime(2022, 12, 6, 8, 59, 47, 0, DateTimeKind.Unspecified), "308", "HN120", new DateTime(2022, 2, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ramsey", "M", "ONC", new DateTime(2023, 1, 28, 1, 4, 53, 0, DateTimeKind.Unspecified), "3S" },
                    { "121", new DateTime(2022, 12, 18, 8, 59, 31, 0, DateTimeKind.Unspecified), "358", "HN121", new DateTime(2022, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bradford", "F", "ONC", new DateTime(2023, 1, 28, 1, 4, 53, 0, DateTimeKind.Unspecified), "3S" },
                    { "122", new DateTime(2022, 12, 14, 3, 32, 57, 0, DateTimeKind.Unspecified), "317", "HN122", new DateTime(2022, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Collins", "F", "ONC", new DateTime(2023, 1, 28, 1, 4, 53, 0, DateTimeKind.Unspecified), "3S" },
                    { "123", new DateTime(2023, 1, 12, 4, 21, 30, 0, DateTimeKind.Unspecified), "345", "HN123", new DateTime(2022, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Melisa", "F", "ONC", new DateTime(2023, 1, 28, 1, 4, 53, 0, DateTimeKind.Unspecified), "3S" },
                    { "124", new DateTime(2022, 12, 27, 10, 54, 25, 0, DateTimeKind.Unspecified), "321", "HN124", new DateTime(2022, 10, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Angelica", "F", "ONC", new DateTime(2023, 1, 28, 1, 4, 53, 0, DateTimeKind.Unspecified), "3S" },
                    { "125", new DateTime(2022, 12, 21, 12, 3, 45, 0, DateTimeKind.Unspecified), "308", "HN125", new DateTime(2022, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Charity", "F", "ONC", new DateTime(2023, 1, 28, 1, 4, 53, 0, DateTimeKind.Unspecified), "3S" },
                    { "126", new DateTime(2023, 1, 4, 3, 7, 13, 0, DateTimeKind.Unspecified), "343", "HN126", new DateTime(2022, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hammond", "F", "ONC", new DateTime(2023, 1, 28, 1, 4, 53, 0, DateTimeKind.Unspecified), "3S" },
                    { "127", new DateTime(2022, 12, 30, 3, 13, 29, 0, DateTimeKind.Unspecified), "323", "HN127", new DateTime(2022, 10, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Battle", "M", "ONC", new DateTime(2023, 1, 28, 1, 4, 53, 0, DateTimeKind.Unspecified), "3S" },
                    { "128", new DateTime(2023, 1, 13, 7, 46, 59, 0, DateTimeKind.Unspecified), "329", "HN128", new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Davis", "F", "ONC", new DateTime(2023, 1, 28, 1, 4, 53, 0, DateTimeKind.Unspecified), "3S" },
                    { "129", new DateTime(2022, 12, 14, 7, 10, 54, 0, DateTimeKind.Unspecified), "330", "HN129", new DateTime(2022, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hays", "M", "ONC", new DateTime(2023, 1, 28, 1, 4, 53, 0, DateTimeKind.Unspecified), "3S" },
                    { "200", new DateTime(2023, 1, 18, 5, 29, 27, 0, DateTimeKind.Unspecified), "545", "HN200", new DateTime(2022, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jamie", "F", "REN", new DateTime(2023, 1, 28, 1, 6, 20, 0, DateTimeKind.Unspecified), "5N" },
                    { "201", new DateTime(2023, 1, 2, 5, 12, 8, 0, DateTimeKind.Unspecified), "528", "HN201", new DateTime(2022, 7, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Grimes", "F", "REN", new DateTime(2023, 1, 28, 1, 6, 20, 0, DateTimeKind.Unspecified), "5N" },
                    { "202", new DateTime(2022, 12, 18, 11, 47, 21, 0, DateTimeKind.Unspecified), "551", "HN202", new DateTime(2022, 9, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Adrienne", "F", "REN", new DateTime(2023, 1, 28, 1, 6, 20, 0, DateTimeKind.Unspecified), "5N" },
                    { "203", new DateTime(2022, 12, 5, 1, 26, 24, 0, DateTimeKind.Unspecified), "549", "HN203", new DateTime(2022, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yvette", "F", "REN", new DateTime(2023, 1, 28, 1, 6, 20, 0, DateTimeKind.Unspecified), "5N" },
                    { "204", new DateTime(2023, 1, 2, 3, 20, 1, 0, DateTimeKind.Unspecified), "531", "HN204", new DateTime(2022, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kane", "M", "REN", new DateTime(2023, 1, 28, 1, 6, 20, 0, DateTimeKind.Unspecified), "5N" },
                    { "205", new DateTime(2022, 12, 11, 3, 50, 55, 0, DateTimeKind.Unspecified), "547", "HN205", new DateTime(2022, 2, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Theresa", "M", "REN", new DateTime(2023, 1, 28, 1, 6, 20, 0, DateTimeKind.Unspecified), "5N" },
                    { "206", new DateTime(2023, 1, 18, 11, 19, 50, 0, DateTimeKind.Unspecified), "545", "HN206", new DateTime(2022, 8, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lauri", "F", "REN", new DateTime(2023, 1, 28, 1, 6, 20, 0, DateTimeKind.Unspecified), "5N" },
                    { "207", new DateTime(2023, 1, 17, 9, 9, 46, 0, DateTimeKind.Unspecified), "542", "HN207", new DateTime(2022, 10, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Roberson", "F", "REN", new DateTime(2023, 1, 28, 1, 6, 20, 0, DateTimeKind.Unspecified), "5N" },
                    { "208", new DateTime(2023, 1, 17, 10, 1, 33, 0, DateTimeKind.Unspecified), "506", "HN208", new DateTime(2022, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Valencia", "F", "REN", new DateTime(2023, 1, 28, 1, 6, 20, 0, DateTimeKind.Unspecified), "5N" },
                    { "209", new DateTime(2022, 12, 4, 10, 30, 10, 0, DateTimeKind.Unspecified), "507", "HN209", new DateTime(2022, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mattie", "F", "REN", new DateTime(2023, 1, 28, 1, 6, 20, 0, DateTimeKind.Unspecified), "5N" },
                    { "210", new DateTime(2022, 12, 12, 1, 43, 4, 0, DateTimeKind.Unspecified), "553", "HN210", new DateTime(2022, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mendoza", "M", "REN", new DateTime(2023, 1, 28, 1, 6, 20, 0, DateTimeKind.Unspecified), "5N" },
                    { "211", new DateTime(2023, 1, 10, 12, 0, 56, 0, DateTimeKind.Unspecified), "518", "HN211", new DateTime(2022, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thornton", "M", "REN", new DateTime(2023, 1, 28, 1, 6, 20, 0, DateTimeKind.Unspecified), "5N" },
                    { "212", new DateTime(2023, 1, 8, 9, 34, 29, 0, DateTimeKind.Unspecified), "512", "HN212", new DateTime(2022, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gonzalez", "M", "REN", new DateTime(2023, 1, 28, 1, 6, 20, 0, DateTimeKind.Unspecified), "5N" },
                    { "213", new DateTime(2022, 12, 12, 4, 6, 13, 0, DateTimeKind.Unspecified), "522", "HN213", new DateTime(2022, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yesenia", "F", "REN", new DateTime(2023, 1, 28, 1, 6, 20, 0, DateTimeKind.Unspecified), "5N" },
                    { "214", new DateTime(2022, 12, 19, 3, 57, 43, 0, DateTimeKind.Unspecified), "521", "HN214", new DateTime(2022, 12, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gamble", "M", "REN", new DateTime(2023, 1, 28, 1, 6, 20, 0, DateTimeKind.Unspecified), "5N" },
                    { "215", new DateTime(2022, 12, 24, 6, 25, 37, 0, DateTimeKind.Unspecified), "530", "HN215", new DateTime(2022, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bette", "M", "REN", new DateTime(2023, 1, 28, 1, 6, 20, 0, DateTimeKind.Unspecified), "5N" },
                    { "216", new DateTime(2022, 12, 28, 7, 10, 32, 0, DateTimeKind.Unspecified), "513", "HN216", new DateTime(2022, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hester", "M", "REN", new DateTime(2023, 1, 28, 1, 6, 20, 0, DateTimeKind.Unspecified), "5N" },
                    { "217", new DateTime(2023, 1, 4, 6, 56, 11, 0, DateTimeKind.Unspecified), "545", "HN217", new DateTime(2022, 11, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Reba", "F", "REN", new DateTime(2023, 1, 28, 1, 6, 20, 0, DateTimeKind.Unspecified), "5N" },
                    { "218", new DateTime(2022, 12, 7, 7, 3, 10, 0, DateTimeKind.Unspecified), "510", "HN218", new DateTime(2022, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Billie", "M", "REN", new DateTime(2023, 1, 28, 1, 6, 20, 0, DateTimeKind.Unspecified), "5N" },
                    { "219", new DateTime(2022, 12, 5, 7, 14, 28, 0, DateTimeKind.Unspecified), "541", "HN219", new DateTime(2022, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ewing", "M", "REN", new DateTime(2023, 1, 28, 1, 6, 20, 0, DateTimeKind.Unspecified), "5N" },
                    { "220", new DateTime(2022, 12, 1, 4, 25, 0, 0, DateTimeKind.Unspecified), "529", "HN220", new DateTime(2022, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nora", "F", "REN", new DateTime(2023, 1, 28, 1, 6, 20, 0, DateTimeKind.Unspecified), "5N" },
                    { "221", new DateTime(2022, 12, 5, 9, 2, 31, 0, DateTimeKind.Unspecified), "538", "HN221", new DateTime(2022, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rocha", "F", "REN", new DateTime(2023, 1, 28, 1, 6, 20, 0, DateTimeKind.Unspecified), "5N" },
                    { "222", new DateTime(2022, 12, 28, 12, 0, 0, 0, DateTimeKind.Unspecified), "508", "HN222", new DateTime(2022, 12, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Meyer", "M", "REN", new DateTime(2023, 1, 28, 1, 6, 20, 0, DateTimeKind.Unspecified), "5N" },
                    { "223", new DateTime(2022, 12, 8, 2, 20, 1, 0, DateTimeKind.Unspecified), "523", "HN223", new DateTime(2022, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Benita", "F", "REN", new DateTime(2023, 1, 28, 1, 6, 20, 0, DateTimeKind.Unspecified), "5N" },
                    { "224", new DateTime(2023, 1, 14, 1, 52, 12, 0, DateTimeKind.Unspecified), "534", "HN224", new DateTime(2022, 12, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Reed", "M", "REN", new DateTime(2023, 1, 28, 1, 6, 20, 0, DateTimeKind.Unspecified), "5N" },
                    { "225", new DateTime(2022, 12, 16, 12, 46, 18, 0, DateTimeKind.Unspecified), "512", "HN225", new DateTime(2022, 6, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jodi", "F", "REN", new DateTime(2023, 1, 28, 1, 6, 20, 0, DateTimeKind.Unspecified), "5N" },
                    { "226", new DateTime(2022, 12, 22, 3, 52, 26, 0, DateTimeKind.Unspecified), "521", "HN226", new DateTime(2022, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Shauna", "F", "REN", new DateTime(2023, 1, 28, 1, 6, 20, 0, DateTimeKind.Unspecified), "5N" },
                    { "227", new DateTime(2022, 12, 21, 5, 37, 33, 0, DateTimeKind.Unspecified), "548", "HN227", new DateTime(2022, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Stevens", "F", "REN", new DateTime(2023, 1, 28, 1, 6, 20, 0, DateTimeKind.Unspecified), "5N" },
                    { "228", new DateTime(2022, 12, 9, 1, 38, 50, 0, DateTimeKind.Unspecified), "559", "HN228", new DateTime(2022, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lilly", "M", "REN", new DateTime(2023, 1, 28, 1, 6, 20, 0, DateTimeKind.Unspecified), "5N" },
                    { "229", new DateTime(2022, 12, 3, 9, 7, 20, 0, DateTimeKind.Unspecified), "532", "HN229", new DateTime(2022, 10, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Shepard", "M", "REN", new DateTime(2023, 1, 28, 1, 6, 20, 0, DateTimeKind.Unspecified), "5N" }
                });

            migrationBuilder.InsertData(
                table: "HandoverGroups",
                columns: new[] { "Id", "GroupName", "SpecialtyCode" },
                values: new object[,]
                {
                    { 1, "Oncology Handover", "ONC" },
                    { 2, "Nephrology Handover", "REN" }
                });

            migrationBuilder.InsertData(
                table: "Handover",
                columns: new[] { "id", "GroupId", "admissionTime", "background", "bedNumber", "caseNumber", "diagnosis", "dob", "drugs", "editedBy", "freeText", "ix", "patientKey", "patientName", "progress", "recommendation", "sex", "specialtyCode", "wardCode" },
                values: new object[,]
                {
                    { new Guid("0015008d-eb4e-4ba0-8b10-3b7499916237"), 1, new DateTime(2022, 12, 9, 6, 49, 36, 0, DateTimeKind.Unspecified), "post RE enucleation, post- #6 CEV\nhx of E Coli UTI in 2/2021\n", "312", "HN106", "unilateral RE group E retinoblastoma\nhistory of septic shock ", new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "IV meropenem ", "Ramos", null, "", "106", "Shepard", "ESBL E Coli septicemia, IV tazocin started on 7/4/2022, -> IV meropenem on 8/4/2022, repeated culture no growth. Stable. No fever after 8/4/2022", "Plan continue meropenem for total 10 days (till 17/4/2022)", "F", "ONC", "3S" },
                    { new Guid("010c958f-d701-4cfa-9013-ae8cc5785c3b"), 1, new DateTime(2023, 1, 4, 3, 7, 13, 0, DateTimeKind.Unspecified), "Stage 4 Neuroblastoma with multiple mets, completed all treatment as per SIOPEN-HR NB on 27/6/2020, prev N-MYC amplified\nCompleted RT ", "343", "HN126", "CNS relapse neuroblastoma\nHaploidentical PBSCT (elder brother) on 2/12/22 (D+27)\nCycle 1 Dinutuximab + IL-2 + GM-CSF 6-11/12/2022", new DateTime(2022, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Micafungin prophylaxis 2x/week\nGanciclovir\nSeptrin\nLactobacillus", "Spence", null, "", "126", "Hammond", "Haploidentical PBSCT (elder brother) 2/12/2022\nCycle 1 Dinutuximab (6-11/12/2022)\nCycle 2 Dinutuximab (6-11/1/2023)\n\nActive problems: \n1. CMV reactivation\n- Memory DLI 21/12, 29/12/2022, Fresh DLI 6x10^6/kg CD3+ given on 5/1/23, memory DLI on 13/1/23\n- On Ganciclovir\n- Latest CMV PCR -ve x 1 on 19/1/2023\n- Plan to valganciclovir if  CMV PCR -ve x 2\n\n2. HHV6 viremia\n- Latest HHV6 PCR -ve x 2\n\n3. Poor oral intake, Hx of mucositis\n- Off TPN on 19/1/2023\n- BW gain fair, appetite improving", "Monitor CMV, HHV6 PCR trend\nHL between IV medication\nMonitor BW daily -> may need to consider resume TPN if poor weight gain", "F", "ONC", "3S" },
                    { new Guid("0d6dc260-73c3-42b9-a06a-7ddb77b63bec"), 2, new DateTime(2022, 12, 12, 1, 43, 4, 0, DateTimeKind.Unspecified), "FN1 nephropathy\nPost DDT 15 weeks", "553", "HN210", "FN1 nephropathy\nPost DDT 22/4/22, poor graft function Cr ~130", new DateTime(2022, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Bertha", null, "", "210", "Mendoza", "impaired graft function\nBKVN\n\nCr improved after IVF, off IVF today ", "will recheck RFT mane ", "M", "REN", "5N" },
                    { new Guid("0db7b786-e1ed-465d-83dd-8f6b4562e19d"), 2, new DateTime(2023, 1, 17, 9, 9, 46, 0, DateTimeKind.Unspecified), "Dysplastic kidney\nPost LDRT \nCMV reactivation ", "542", "HN207", "Dysplastic kidney\nPost LDRT \nCMV reactivation ", new DateTime(2022, 10, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Lou", null, "", "207", "Roberson", "1. CMV reactivation \nOff Valganciclovir Feb 2022\nFound CMV reactivation up to 6 x10^5\nStarted on ganciclovir on 22/4/22, latest CMV PCR 10^2\nDecreasing neutrophil count 20/5 \n\n2. Titration of Tacrolimus dosage\nStart everolimus 29/4\n\n3. E.Coli UTI, blood C/ST no growth \nClinically well\nTo complete 10days antibiotics \n", "Continue Ganciclovir, monitor white cell count \nPlan G-CSF if ANC <1.0 \nMeropenem till 22/5 ", "F", "REN", "5N" },
                    { new Guid("0fddb7fb-69e0-4e38-ab36-69b9e19ff8a8"), 1, new DateTime(2022, 12, 23, 2, 18, 15, 0, DateTimeKind.Unspecified), "diagnosed in 2/2022. left salpinooophrectomy + biopsy at pwh OG. \nextracranial GCT 2018 protocol (JEBX4)", "342", "HN104", "left ovarian yolk sac tumour, stage 2", new DateTime(2022, 7, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Nina", null, "", "104", "Gray", "picc inserted on 25/3", "continue cycle 1 JEB till 27/3\nblood taking on 27/3", "M", "ONC", "3S" },
                    { new Guid("0ff0643f-b034-4cca-bc25-ea29bc49a544"), 1, new DateTime(2022, 12, 27, 10, 54, 25, 0, DateTimeKind.Unspecified), "BCOR sarcoma of left foot with extensive metastasis", "321", "HN124", "BCOR sarcoma of left foot with extensive metastasis\nUnderlying hypothyroidism and adrenal insufficiency", new DateTime(2022, 10, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "IV hydrocortisone\nThyroxine\nSeptrin\nAnd other supportive meds", "Emily", null, "", "124", "Angelica", "Admitted for consolidation #3 IE (80%)\nStarted stress dose steroid for adrenal insufficiency", "Continue chemotherapy over weekends\nMonitor I/O and  urine RBC", "F", "ONC", "3S" },
                    { new Guid("177b70e2-a016-419d-9553-e91069227a51"), 1, new DateTime(2023, 1, 7, 10, 7, 41, 0, DateTimeKind.Unspecified), "Current stage of Tx: dinutixumab, GM-CSF, post tranplant, cycle 5 (last course) on 11/4. Previously admitted for shingles, treated with Acyclovir / Galacyclovir for 10 days. No new lesions\n\n", "302", "HN117", "relapsed stage 4 neuroblastoma", new DateTime(2022, 3, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Frankie", null, "", "117", "Barr", "On Cycle 5 of Dinutuximab, GM-CSF \nOccasional kick of low grade fever but resolved after rechecking\nPlan for septic workup if persistent fever + IV Abx\n", "Home when complete chemo regime\n", "F", "ONC", "3S" },
                    { new Guid("19ab641c-084d-4eb5-8e89-d7d552258587"), 2, new DateTime(2023, 1, 14, 1, 52, 12, 0, DateTimeKind.Unspecified), "Laparoscopic vesicostomy closure and gastrostomy revision on 24/11/2022 (POD8)", "534", "HN224", "CAKUT, CKD", new DateTime(2022, 12, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Emily", null, "", "224", "Reed", "Resumed feeding on POD7, gradually stepping up gastrostomy feeding, well tolerated\nOn partial PN support\n\nCurrent gastrostomy feeding\nDay time: milk 45mL x 3 feeds\nNocturnal: milk drip 30mL/hr x 8 hours", "Gradually step up gastrostomy feeding\nBlood tests on Mon", "M", "REN", "5N" },
                    { new Guid("1ecf7279-c3f0-47af-8bce-6b32da216204"), 2, new DateTime(2022, 12, 16, 12, 46, 18, 0, DateTimeKind.Unspecified), "Ischemic nephropathy \nPost DDT 3 years 6MM + 2 DQ MM\nHistory of BKVN in 2021 \nNow on Pred/CsA/Everolimus", "512", "HN225", "Post DDT 3 years \nBKVN\n", new DateTime(2022, 6, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Ester", null, "", "225", "Jodi", "admission for review & IVIG\n", "home ", "F", "REN", "5N" },
                    { new Guid("268612ba-215d-4316-9daa-518d4b892b09"), 1, new DateTime(2022, 12, 14, 3, 32, 57, 0, DateTimeKind.Unspecified), "Modified radical neck dissection & hickman line insertion 30/5\n- LNs biopsy: only 1 LN +ve out of 86 sampled, focally close margin < 1mm\nSlipped out Hickman, reinserted 6/2022\nSalmonella GE + bacteremia 5/6, completed 2/52 antibiotics \nHx of mucositis since 9/8/2022, poor feeding, off R/T feeding since 31/12/22\nCompleted RT on 19/8/2022\nCycle 12 irinotecan + temozolomiede given on 10/1", "317", "HN122", "Forehead alveolar rhabdomyosarcoma with right cervical LN relapse, first diagnosis in 12/2020", new DateTime(2022, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sirolimus ", "Mcdonald", null, "", "122", "Collins", "1. Cycle 12 IT on 10-14/1/2023, nausea and vomiting on Kytril, emend, dexamethasone \n2. Increased Sirolimus dose from 1mg to 1.5mg once per day since 3/1, latest sirlimus level satisfactory ", "1. Completed 12 cycles of IT on 15/1/2023\n2. MRI neck 20/1/2023 (under GA)  and PET-CT scan QEH in 2/2023", "F", "ONC", "3S" },
                    { new Guid("2f7ecad2-49d0-471a-994b-5d1718e54ba2"), 1, new DateTime(2022, 12, 18, 8, 59, 31, 0, DateTimeKind.Unspecified), "Suprasellar germ cell tumor, hypopituitarism, Hx of carboplatin-induced hyponatremia ", "358", "HN121", "Suprasellar germ cell tumor", new DateTime(2022, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "IV Tazocin", "Krystal", null, "", "121", "Bradford", "Admitted x non-neutropenic fever\nCentral DI on DDAVP. \nPanhypopituitarism on thyroxine, fludrocortisone, NaCl\nStep up to stress dose hydrocortisone due to fever\nFever down after admission, blood culture T/F ", "Continue Tazocin\nPlan off Tazocin and to oral antibiotics if blood culture at 48 hour still T/F", "F", "ONC", "3S" },
                    { new Guid("359ebbdc-19fa-451f-b6ef-a690545d620b"), 2, new DateTime(2022, 12, 22, 3, 52, 26, 0, DateTimeKind.Unspecified), "Post- DDT 11/9/2018\nCKD V left MCDK and right dysplastic kidney with severe right VUR, hydronephrosis and hydroureterurinoma", "521", "HN226", "\"C\" adm for deflux\nRecurrent UTI\nPost- DDT 11/9/2018\nCKD V left MCDK and right dysplastic kidney with severe right VUR, hydronephrosis and hydroureterurinoma", new DateTime(2022, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "IV meropenem ", "Spence", null, "", "226", "Shauna", "Deflux done 21/7, initially empirically covered with Augmentin\nDeveloped fever 22/7, changed Abx to IV Meropenem (previous urine c/st showed ESBL E Coli)\n\nFever improving trend\nCRP 25, urine culture pending \nCr rose up to 166 after admission (baseline around 120)\nGiven IVF, Cr latest improved to 128", "Continue IV Meropenem \nAwait urine culture result ", "F", "REN", "5N" },
                    { new Guid("35ed9db8-e151-4ab0-919d-b5ada2319707"), 2, new DateTime(2022, 12, 3, 9, 7, 20, 0, DateTimeKind.Unspecified), "CAKUT", "532", "HN229", "ESKD on HD", new DateTime(2022, 10, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Underwood", null, "", "229", "Shepard", "", "on home leave for 24hr BP", "M", "REN", "5N" },
                    { new Guid("369beda0-b793-4013-a0a0-dcb0563a95f0"), 1, new DateTime(2022, 12, 14, 7, 10, 54, 0, DateTimeKind.Unspecified), "Spinal undifferentiated round cell sarcoma, completed chemoRT in 2020, found relapse over abdominal wall.", "330", "HN129", "Spinal undifferentiated round cell sarcoma", new DateTime(2022, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Underwood", null, "", "129", "Hays", "Admitted for cryoablation of abdominal wall lesions.\nProcedure done on 26/8. Uneventful", "Home on Sat if wound well and pain under control", "M", "ONC", "3S" },
                    { new Guid("3b402470-0317-43d9-add5-5d04ad869380"), 2, new DateTime(2023, 1, 18, 11, 19, 50, 0, DateTimeKind.Unspecified), "SLE/ TTP / LN\nPoor medication compliance, self stopped all meds since march", "545", "HN206", "SLE/ TTP / LN flare with AKI;\nRecent COVID infection in March\nClinically admitted for cyclophosphamide infusion\n", new DateTime(2022, 8, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Ramos", null, "CXR: showed reduce left pleural effusion\nEcho: reduce pericardial effusion", "206", "Lauri", "Clinically admitted for cyclophosphamide infusion\nClaim good drug compliance the past week (on anti-HT, pred 20mg BD, hydroxychloroquine, MMF)\nNoted weight gain 3kg and significant fluid retention \nAlso rising of Cr up to 80 -> 110\nFor regular lasix for 1 day\nreview tomorrow for CTX", "For regular lasix for 1 day\nreview tomorrow for CTX\n", "F", "REN", "5N" },
                    { new Guid("3d3653bb-9efb-4b95-8358-74cd4be192f9"), 1, new DateTime(2022, 12, 11, 4, 10, 21, 0, DateTimeKind.Unspecified), "Hx of liver, skin, gut GVHD\nHx of disseminated Nocardia infection, on lifelong doxycycline\nHx of pericardial effusion\n\nHx of persistent mixed chimerism, given incremental dose of DLI x2 ( 5/9 & 13/9), latest 100% donor \n\nOn isavuconazole for previous trichosporon chest infection & antifungal prophylaxis and lifelong doxycyline for hx of nocardia \nHx of CMV, EBV, HHV6 viremia, asymptomatic BK viuria.In remission\n", "338", "HN116", "Relapsed/ refractory stage 4 neuroblastoma\nHaploHSCT 10/8/2022, ANC engraftment D+10, latest chimerism  99%\nHypothyroidism ", new DateTime(2022, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Isavuzonazole (for Hx of trichosoporon fungema/ pneumonia)\nDoxycycline (lifelong prophylaxis for hx of nocardia)\nSeptrin prophylaxis \nLevothyroxine\nRuxolitinib", "Forbes", null, "", "116", "Virgie", "1. Paralytic ileus/ SBBO/ poor feeding tolerance \nCompleted empirical SBBO Mx with gentamicin + metronidazole 3-11/1, then rifaximin 11-16/1\nKept NPO on TPN, abdominal pain improving \nFollow through 19/1: no fluoroscopic evidence of high grade obstruction/ delay transit of small bowels \n\nSuggested by GI team: \n- Try small amount of feeding \n- Blood x CBCd/c, LRFT, CaPO4, TG, Mg, H'stix, VBG daily over the weekend and CNY holidays \n- Consider cyclical abx on 30/1/23 (await discussion with micbi) \n\n2. Deranged LFT, likely multifactorial (disease, drug, infection, etc.)\n- Ductal enzyme predominance. For monitoring ?downtrending recently (On Smof/Omegavan)\n- Metabolic workup -ve. Hep serology -ve. Anti-smooth muscle +ve \n- MRCP appt (look for HBP/ PSC pathology) 08/03/23\n- Supportive Tx mainly", "If severe sepsis, start IV Tazocin + Amikacin after sepsis workup + reconsult micbi team (See micbi progress notes in CMS 03/01 and 19/01)\nTry small amount of feeding \nBlood x CBCd/c, LRFT, CaPO4, TG, Mg, H'stix, VBG daily over the weekend and CNY holidays ", "M", "ONC", "3S" },
                    { new Guid("41ba6c7e-437b-412d-a2f3-f6ec1fb14e4f"), 1, new DateTime(2023, 1, 5, 7, 2, 4, 0, DateTimeKind.Unspecified), "refractory Ca ovary, not responsive to chemo\nDNACPR signed", "315", "HN113", "Refractory Ca ovary, DNACPR", new DateTime(2022, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Tammi", null, "", "113", "Sheree", "Admitted for severe abdominal pain, increased vomiting \n? IO, Urgent CT A+P performed, RT inserted, bile stained aspirate yielded\nStarted on IVF, stopped all oral meds\nOn Morphine PCA, Fentanyl patch (plan wean off to IV morphine)\nTo continue pain relief with morphine PCA ", "Optimise pain relief +/- TPN over weekend depending on clinical status \nRT inserted \n", "F", "ONC", "3S" },
                    { new Guid("4a4d817f-8681-4381-ad0d-118ae7a54cd1"), 1, new DateTime(2023, 1, 14, 11, 50, 14, 0, DateTimeKind.Unspecified), "Left submandibular synovial sarcoma with resection done in private. Resection margin not clear. For chemo (PAZNTIS ARST 1321-rigmen A with panzopanib)-ID and RT", "344", "HN108", "Left submandibular synovial sarcoma", new DateTime(2022, 9, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Ora", null, "", "108", "Jeri", "Week 19 ifosfamide + doxorubicin started on 30/6\n", "Continue chemotherapy\nMonitor electrolytes daily (ifosfamide)", "M", "ONC", "3S" },
                    { new Guid("4b06f640-41a9-4237-9677-74435abfcfce"), 2, new DateTime(2022, 12, 5, 1, 26, 24, 0, DateTimeKind.Unspecified), "Cystinosis\nNephropathy\nPost-GJ tube insertion on 17/11/2022", "549", "HN203", "Cystinosis", new DateTime(2022, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Solis", null, "", "203", "Yvette", "parainfluenza URI\ncough/ RN & vomiting\nno SOB\n\nelectrolytes OK", "cut milk to 40ml/hr, supplument with IVF 50ml/hr\nObserve vomiting and fever trend", "F", "REN", "5N" },
                    { new Guid("4c4fb333-d2ab-400a-8086-b48671fd8472"), 2, new DateTime(2022, 12, 5, 9, 2, 31, 0, DateTimeKind.Unspecified), "Adm for ABPM ", "538", "HN221", "Interstitial nephritis \nHashimoto thyroiditis ", new DateTime(2022, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Krystal", null, "", "221", "Rocha", "", "", "F", "REN", "5N" },
                    { new Guid("4d0a6069-8884-4eae-980e-804563fa95d6"), 2, new DateTime(2022, 12, 7, 7, 3, 10, 0, DateTimeKind.Unspecified), "End stage kidney disease\nTRPC-6 GN \nHistory of PRES presented with confusion & GTC on 02/06 requiring Labetalol infusion \nPD cath insertion 16/06/2022", "510", "HN218", "End stage kidney disease\nunderlying ?MPGN \nhistory of PRES presented with confusion & GTC on 02/06\n", new DateTime(2022, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "amlodipine\nramipril ", "Clay", null, "", "218", "Billie", "Neurologically stable on Keppra\nBP control satisfactory on Ramipril and Amlodipine\nno IPD\nPD cath insertion 16/06/2022\nStarted PD POD12 , bridged with HD \nEpigastric pain during last bag dwell \nSymptoms improved after drainage \n\n", "continue PD training", "M", "REN", "5N" },
                    { new Guid("4fe0af36-5e5c-4ab6-b36f-91766ee9a34b"), 1, new DateTime(2022, 12, 10, 2, 36, 58, 0, DateTimeKind.Unspecified), "Bilateral lung wedge resection done on 15/7/2022 for lung metastasis\nprogressive disease with malignant pleural effusion", "346", "HN110", "Left distal femur osteosarcoma, post AKA, lung met\nUnderlying Rothmund Thomson syndrome\nprogressive disease despite IE with TKI, to GEMDOC since 2/9/2022", new DateTime(2023, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Bertha", null, "", "110", "Sheri", "progressive pleural effusion, completed D8 GEMDOC 9/9/2022\n\ndiscussed with IR Dr K Fung, no urgency for pleural catheter insertion, to observe Sx first, slot for pleural catheter insertion reserved on 13/9", "monitor CXR, blood glucose and urine glucose\nplan HL till saturday then till monday to confirm if proceed pleural catheter insertion on 13/9/2022", "F", "ONC", "3S" },
                    { new Guid("512fb66d-b3a3-4fa9-a4af-7a973aaf3b8b"), 2, new DateTime(2023, 1, 8, 9, 34, 29, 0, DateTimeKind.Unspecified), "SRNS", "512", "HN212", "SRNS", new DateTime(2022, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Alfreda", null, "", "212", "Gonzalez", "C admitted for 24 hour ABPM", "HL for 24 hour ABPM, home mane", "M", "REN", "5N" },
                    { new Guid("57990ed5-38d3-4531-a6e2-fe0daf21675c"), 2, new DateTime(2022, 12, 28, 12, 0, 0, 0, DateTimeKind.Unspecified), "fever ? URI", "508", "HN222", "Bartter's syndrome, FSGS\nESRF on HD \n", new DateTime(2022, 12, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "empirical IV Augmentin", "Mcdonald", null, "pending wound swab C/ST", "222", "Meyer", "sepsis workup done\n\nstable clinically\nnot on O2", "IV augmentin ", "M", "REN", "5N" },
                    { new Guid("602b8d2b-5c6e-4875-a93e-ee1e7fe86ea6"), 2, new DateTime(2022, 12, 4, 10, 30, 10, 0, DateTimeKind.Unspecified), "Denys Drash syndrome \nPost DDT\nHx of CMV disease ", "507", "HN209", "Denys Drash syndrome \nCMV reactivation \n", new DateTime(2022, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Latoya", null, "", "209", "Mattie", "Fever since 8/11 with tonsillits noted, fever down ", "on HL ", "F", "REN", "5N" },
                    { new Guid("61061ece-6963-406d-8566-6a5076492b84"), 1, new DateTime(2023, 1, 10, 8, 49, 16, 0, DateTimeKind.Unspecified), "Left distal femur osteosarcoma with lung metastasis, 94.1% chemonecrosis\n\nWeek 26 HDMTX  AP chemo given on 18/10/2022\n\nRecurrent UTI, on nitrofurantoin prophylaxis, stopped due to possible interaction with MTX\n\nOne episode of incontinence after HDMTX infusion on 20/10, no more recurrence so far ", "305", "HN105", "Left distal femur osteosarcoma with lung metastasis\nCOVID infection in mid Sept\nRecurrent UTI + ?Urinary incontinence", new DateTime(2022, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Dena", null, "", "105", "Mejia", "Week 27 HDMTX", "Chemo in progress\nMTX 24/48 level \nNo need MTX 6 hr level as end of treatment ", "M", "ONC", "3S" },
                    { new Guid("61e846ee-3e88-43ab-af52-f0eea5abee0d"), 1, new DateTime(2022, 12, 31, 9, 54, 1, 0, DateTimeKind.Unspecified), "R distal tibia osteosarcoma with lung met\nOT done\nChemo according to HKPHOSG Osteosarcoma protocol", "355", "HN109", "Osteosarcoma", new DateTime(2023, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Latoya", null, "", "109", "Wooten", "completed week 27 MTX", "Monitor MTX level, LFT", "M", "ONC", "3S" },
                    { new Guid("675528cb-a292-44cf-baaa-0e32ac71c3ac"), 2, new DateTime(2022, 12, 12, 4, 6, 13, 0, DateTimeKind.Unspecified), "Dysplastic right kidney on HD\nPortal hypertension\nDepression", "522", "HN213", "Dysplastic right kidney on HD\nPortal hypertension\nDepression", new DateTime(2022, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "IV meropenem, vancomycin", "Tammi", null, "\n", "213", "Yesenia", "ESBL Salmonella GE, now D7 illness\nPrevious suspected HD catheter tunnel site sepsis due to chest wall pain but USG normal", "Continue IV meropenem for ESBL Salmonella GE \nAwait vancomycin level, plan to off vancomycin if blood C/ST no growth on 7/1/23", "F", "REN", "5N" },
                    { new Guid("6945f8eb-eaf5-418e-9bab-126e34eb4110"), 2, new DateTime(2022, 12, 19, 3, 57, 43, 0, DateTimeKind.Unspecified), "Laparoscopic right para-tubal cystectomy + PD catheter removal on 1/12/2022", "521", "HN214", "Congenital nephrotic syndrome, ESKD on HD", new DateTime(2022, 12, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Tyler", null, "", "214", "Gamble", "Epigastric pain and wound pain, on regular IV Paracetamol and IV Nexium\nResumed feeding on POD1, well tolerated", "Next HD on Sat", "M", "REN", "5N" },
                    { new Guid("6b18f490-b125-419c-a4b9-611782d9f48c"), 1, new DateTime(2022, 12, 1, 8, 36, 5, 0, DateTimeKind.Unspecified), "RLL VATS lobectomy on 28/1/2022\nStarted on PAZNTIS ARST 1321 protocol\nWeek 19 liposomal doxorubixin given on 11/7\nPazopanib induced hypothyroidism", "359", "HN118", "right lung relapsed mesenchymal chondrosarcoma", new DateTime(2022, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Levofloxacin\nSeptrin\nThyroxine", "Clay", null, "CT thorax 19/8\n- Status post resection of left chest wall chondrosarcoma and right lower lobe lobectomy. No CT evidence of local tumour recurrence.\n- Interval increase in extent of right pneumothorax without evidence of tension pneumothorax.\n- Previously noted three new lung nodules in left lung are resolved. \n- Other multiple tiny nodules up to 4 mm, some calcified, scattered in both lungs and along pleural surface are similar.\n- Multiple subcentimeter hypodense lesions in the liver and spleen are similar and non-specific. Two new tiny hypoenhancing foci in right and left renal cortex respectively. Underlying hepatosplenic microabscesses with new lesions in kidneys has to be considered in this clinical context.\n- Previously noted mural thickening of the colon and ileum is resolved.\n- Gastric hiatus hernia.", "118", "Parsons", "Incidental finding of right PTX on CT during last admission in late July for neutropenic fever\nNo resp symptoms or chest pain all along\nProgress CT thorax showed interval increase in extent of right PTX \nPazopanib withheld\n\nImage guided pigtail insertion to right chest performed on 23/8\nR chest drain showed swinging but not much bubbling, applied 5cm H2O suction \nPneumothorax resolving but CXR still showed thin rim of R pneumothorax\n\nConsulted CTS\n- Off suction on 26/8 as no more air leak\n- Not for pleurodesis now, if recurrent right PTX, to reconsult for need of pleurodesis\n- Off pigtail on Monday if CXR not increasing in size over weekend\nNo more swinging noted after off suction on 26/8\n\nHepatosplenic microabscess on oral levofloxacin", "CXR on Monday\nOff pigtail on Monday if CXR not increasing in size over weekend", "M", "ONC", "3S" },
                    { new Guid("6fddfbf5-1be4-4f24-8bbf-fa4d2183aa1f"), 2, new DateTime(2022, 12, 24, 6, 25, 37, 0, DateTimeKind.Unspecified), "Alport syndrome \nESKD on PD \n", "530", "HN215", "Alport syndrome on PD \n", new DateTime(2022, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Barbra", null, "", "215", "Bette", "admitted for yearly assessment \nFound fluid overload 4L+ \nNow back to dry weight \nABPM on Friday then plan home on Sat ", "Plan home on Sat", "M", "REN", "5N" },
                    { new Guid("72c23629-ab17-4ef3-8c58-034a6cfe00fa"), 1, new DateTime(2023, 1, 13, 7, 46, 59, 0, DateTimeKind.Unspecified), "Treated according to HKHOSG-PNET-CNS-2000 protocol\nNow on maintenance chemo CCV-V-V, due for cycle 4 on 7/4, withheld due to count not met. \n\n\n", "329", "HN128", "Average risk Cerebellar medulloblastoma, GTR, molecular group 4, MYCN amplification, no drop metastasis\nRight 6th and 7th nerve palsy", new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Wall", null, "VZV IG T/F ", "128", "Davis", "Admitted today for close contact of VZV in 4SD. No fever / rash, well in herself. Plan to proceed with chemo if count enough. ", "Home, count inadequate\nRA 11/4", "F", "ONC", "3S" },
                    { new Guid("74fb46ec-d6ba-4130-9459-88f4e26d7397"), 1, new DateTime(2023, 1, 12, 4, 21, 30, 0, DateTimeKind.Unspecified), "BE group D retinoblastoma with left eye total retinal detachment at 19months of life (1/2014)\nGermline mutation of RB1\nBE enucleation done\n\nCompleted 9 cycles of IV CEV chemotherapy and 3 cycles of IAC with melphalan and topotecan in 2014; \nLE enucleation was performed on 11/6/2014 ;\nReceived 5 additional IAC (completed by Sept 2015) & 6 intravitreal chemotherapy + EBRT in USA Wills eye, eventually NLP, RE enucleation was done in 1/2016; Pathology in USA showed no residual tumour remain in enucleated specimen\nMRI Orbit 1/2022: No local recurrence or intracranial metastasis demonstrated. \n\nNoted mild dull R knee pain from 10/2021 to 1/2022 \nSubsequently confirmed relapse\n\nTreated according to COG ARET0321 protocol (intensive multi-modality therapy for extra-ocular retinoblastoma)\nStem cell harvest for relapse metastatic retinoblastoma on 13/2/2022\nCycle 1 chemo on 15-17/2/22\nCycle 2 chemo on 8/3/2022  , SFI PEG-GCSF 2.5 mg given 11/3/22\nCycle 3 chemo on 31/3/2022 - 7/4/2022, SC GCSF daily 3-6/4\nCycle 4 chemo on 29/4/2022\n\"C\" admitted for 2nd course dinutuximab", "345", "HN123", "Relapsed metastatic retinoblastoma", new DateTime(2022, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Vicki", null, "", "123", "Melisa", "Completed dinutuximab\nR/A on 16/9 due to excessive tiredness and SOB, 1 kick of low grade fever at home. No fever on admission. Vitals stable. Chest exam normal. CXR clear. Blood count stable. GCS full", "Watch out for neurotoxicity of immunotherapy. For CT brain if any change in conscious state.\nSepsis workup + start IV Tazocin if any fever\n\n", "F", "ONC", "3S" },
                    { new Guid("75a130a7-cbce-4a52-a989-00704fcf8f05"), 2, new DateTime(2023, 1, 4, 6, 56, 11, 0, DateTimeKind.Unspecified), "SRNS, frequent relapse\nThis episode post-Biontech 3rd dose ", "545", "HN217", "SRNS, frequent relapse\n", new DateTime(2022, 11, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Frankie", null, "", "217", "Reba", "On Pred, FK, MMF ", "Monitor response to immunosuppressants", "F", "REN", "5N" },
                    { new Guid("7ec92cca-f0f9-441c-a475-256c2ac5c42a"), 1, new DateTime(2022, 12, 9, 9, 33, 44, 0, DateTimeKind.Unspecified), "Stage 4 neuroblastoma\nPBSCT done 25/7/2022\nRT in 10-27/10/2022\nContinued on immunotherapy\n", "319", "HN115", "Stage 4 neuroblastoma \nAutologous HSCT, followed by immunotherapy ", new DateTime(2022, 4, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Meropenem", "Barbra", null, "", "115", "Jeannette", "Admitted for FN ?UTI. MSU: Serratia, Klebsiella\nOn meropenem\nInterim MRI and PET: good tumour response. \nPlan isotretinoin when count recovered. \n", "Plan home if fever down for 1-2 days and good oral intake.\nR/A next Monday for count check and BMA", "F", "ONC", "3S" },
                    { new Guid("83ae23fd-fcf5-4544-827a-35988130126e"), 1, new DateTime(2022, 12, 3, 2, 47, 45, 0, DateTimeKind.Unspecified), "Partial ostectomy of R tibia and fibula with right total knee replacement done on 5/7\n\nBorderline thrombocytopenia\n- parents' platelet normal\n- anti-platelet antibody on 11/3/22:  +ve", "335", "HN119", "Localized right tibial osteosarcoma, no lung metastasis", new DateTime(2022, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Bernard", null, "", "119", "Salas", "Admitted for week 27 HDMTX\nUneventful", "Home if MTX level <0.15", "M", "ONC", "3S" },
                    { new Guid("88306b01-b77c-44d9-bdf8-16ad025fd866"), 2, new DateTime(2022, 12, 28, 7, 10, 32, 0, DateTimeKind.Unspecified), "CAKUT, anterior urethral value postop. bilateral VUR\nESKD on PD ", "513", "HN216", "CAKUT, anterior urethral value postop. bilateral VUR\nESKD on PD \nFever D2", new DateTime(2022, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Forbes", null, "", "216", "Hester", "Fever since 7/9 up to 39 \nNo apparent localising symptoms \nRAT -ve, COVID PCR -ve \nHigh CBC WBC 19 ANC predominant CRP elevated 80\nPDF WBC 9 \nUrine multitix -ve, pending culture\nEmpirically started on IV Augmentin \nFever seems downtrend, remained clinically active \n", "Monitor fever \nRepeat COVID PCR on 10/9, off airborne isolation if -ve \nContinue Augmentin", "M", "REN", "5N" },
                    { new Guid("899e1260-7e95-4129-8def-3e038bd9b41e"), 1, new DateTime(2023, 1, 7, 1, 35, 40, 0, DateTimeKind.Unspecified), "Resection of the bone tumor 3/2022\nLung met resection 17/5/22 \nL interthoracoscapular amputation + neuroplasty on 2/8/2022\n", "350", "HN101", "Left proximal humerus osteosarcoma with lung metastasis & local recurrence", new DateTime(2022, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cabozantnib 40mg 4 days/week (Tue, Thur, Sat, Sun)\nMetoprolol\nAnalgesics (amitriptyline 10mg nocte x 1/52, pregabalin 75mg nocte)", "Roth", null, "", "101", "Laverne", "Admitted for cycle 2 topotecan + cyclophosphamide on 26/12-30/12. Uneventful.\nPain team reviewed: no more phantom limb pain. Plan wean amitriptyline to 10mg nocte x 1/52 then off, then gradually tail down pregabalin by our team", "Home after chemotherapy with GCSF", "M", "ONC", "3S" },
                    { new Guid("8a54131a-2d4b-4176-a982-a1b41665bd6f"), 2, new DateTime(2022, 12, 11, 3, 50, 55, 0, DateTimeKind.Unspecified), "ESKD on PD\nIdiopathic panniculitis, recurrent ", "547", "HN205", "ESKD\nIdiopathic panniculitis, recurrent ", new DateTime(2022, 2, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Dena", null, "", "205", "Theresa", "Epigastric pain\nRaised urea up to 30\n?upper GI bleeding\n", "Home \n", "M", "REN", "5N" },
                    { new Guid("8bd83b26-802e-4d25-a6a7-b101e5dbbc28"), 2, new DateTime(2023, 1, 2, 5, 12, 8, 0, DateTimeKind.Unspecified), "Autosomal recessive nephronophthisis type III\nPost-transplant 9 weeks ", "528", "HN201", "Autosomal recessive nephronophthisis type III\nPost renal transplant DDT ", new DateTime(2022, 7, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Roth", null, "", "201", "Grimes", "Removal of JJ stent PD cathether 21/04/2022\nAdmitted for diarrhoea on 27/5/2022\nStool c/st: salmonella+, on rocephin", "For total 14 days Rocephin", "F", "REN", "5N" },
                    { new Guid("8d17d19b-1742-422f-8668-5751e635f95a"), 1, new DateTime(2022, 12, 6, 1, 57, 45, 0, DateTimeKind.Unspecified), "Stage 4 Rhabdomyosarcoma, origin likely pelvic, with abdominal metastasis. \n", "313", "HN112", "Stage 4 Rhabdomyosarcoma, origin likely pelvic", new DateTime(2022, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Alfreda", null, "", "112", "Velez", "Admitted for week 31 VIE", "Continue chemotherapy over weekend", "M", "ONC", "3S" },
                    { new Guid("987899d6-630d-43e1-b1c9-0f6ad2f7d9b5"), 2, new DateTime(2022, 12, 5, 7, 14, 28, 0, DateTimeKind.Unspecified), "PLCE SRNS, ESKD on HD", "541", "HN219", "PLCE SRNS, ESKD on HD", new DateTime(2022, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Bernard", null, "", "219", "Ewing", "PD catheter insertion on 15/12/2022, POD 1\nClinically stable", "home ", "M", "REN", "5N" },
                    { new Guid("9e04e667-91d4-4535-bbda-9d302ac3d308"), 1, new DateTime(2022, 12, 2, 11, 31, 21, 0, DateTimeKind.Unspecified), "R distal femur osteosarcoma with lung met", "359", "HN107", "Osteosarcoma, with lung met", new DateTime(2022, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Lou", null, "", "107", "Christa", "Bil VATS performed on 25/4/22 for removal of lung metastasis\nL chest drain removed on 28/4/22 and R chest drain removed on 29/4/22\nOn chest physio\nPain well controlled\nStable in RA", "Plan home on 30/4/2022 if CTS fit for discharge", "F", "ONC", "3S" },
                    { new Guid("9f477d03-67a1-4991-bc57-1600e23d5e00"), 2, new DateTime(2022, 12, 21, 5, 37, 33, 0, DateTimeKind.Unspecified), "atypical HUS\nESKD on PD ", "548", "HN227", "GJ tube insertion ", new DateTime(2022, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Jackie", null, "no biochemical features of HUS relapse", "227", "Stevens", "GJ insertion on 10/1/23\nfull feed on 13/1 ", "Plan home on 14/1 ", "F", "REN", "5N" },
                    { new Guid("a3dd2bcd-c4cc-4f8c-bfc3-3fb712367b43"), 1, new DateTime(2022, 12, 21, 12, 3, 45, 0, DateTimeKind.Unspecified), "Started on SIOPEN HR NBL 2014 protocol\nChemo given on 8/2-21/4\nOT done on 27/5/2022\nAutologous HSCT on 20/6/2022 \n", "308", "HN125", "Stage 4 neuroblastoma, MYCN non-amplified", new DateTime(2022, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Ester", null, "", "125", "Charity", "Came back for vomiting + followed by mild headache \nCTB unremarkable\nNo more vomiting on D1 - 2 of admission \nAppetite well maintained", "Father confirmed COVID on 10/12\nHome on sunday / as soon as father evacuated to CIF \nR/A Thurs 15/12 x bloods ", "F", "ONC", "3S" },
                    { new Guid("a474f6cd-9ebc-489d-8c54-f991755a020e"), 1, new DateTime(2022, 12, 2, 4, 54, 15, 0, DateTimeKind.Unspecified), "relapsed neuroblastoma (femur), irinotecan+TMZ x2 cycles, then plan to enter 3f8 trial", "309", "HN102", "relapsed neuroblastoma (femur)", new DateTime(2022, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Lessie", null, "", "102", "Nolan", " course 6 D5 3F8", "Home on 7/10 after 3F8 \nDue for course 7 3F8 on 31/10/2022\nQMH RT for focal RT at right proximal femur  (aim ~week of 21/11/2022 after course 7 3F8 & evaluation)", "M", "ONC", "3S" },
                    { new Guid("a6a4a6c6-5e12-4540-818d-0e50931d3757"), 2, new DateTime(2022, 12, 18, 11, 47, 21, 0, DateTimeKind.Unspecified), "ESKD of unknown aetiology ", "551", "HN202", "ESKD of unknown aetiology ", new DateTime(2022, 9, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Lessie", null, "", "202", "Adrienne", "Admitted due to sudden death of father, now in ward for peritoneal dialysis\nIncreased PD number of cycles for better control of BP and fluid status ", "plan home on Sat. ", "F", "REN", "5N" },
                    { new Guid("ad3e8561-631a-48ae-9552-a1810b604413"), 1, new DateTime(2022, 12, 30, 3, 13, 29, 0, DateTimeKind.Unspecified), "Left proximal tibia resection + prosthesis reconstruction in PWH on 8/2/2022\nHDMTX Wk 26 given 9/6\n\n", "323", "HN127", "L proximal tibia osteosarcoma", new DateTime(2022, 10, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Meropenem", "Jackie", null, "", "127", "Battle", "Adm x neutropenic fever\nSepsis workup no yield so far\nOn empirical meropenem since 14/6, no fever for >48hrs\nPlan 5 days Meropenem then home with Augmentin", "Plan Home on Sunday (5 days Meropenem) then Augmentin\nPlan start Chemo next week (count sufficient)", "M", "ONC", "3S" },
                    { new Guid("b5e57c67-fb9d-4c7e-a92f-a98b760e6795"), 1, new DateTime(2023, 1, 19, 11, 4, 18, 0, DateTimeKind.Unspecified), "Stage 4 relapsed refractory neuroblastoma with bone, BM, CNS involvement\n\nCycle 1 topo/cyclo 12/7/2022\nOff lorlatinib since 8/8 due to persistent low count", "308", "HN103", "Relapse/ refractory stage 4 Neuroblastoma", new DateTime(2022, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "PCA morphine 40mcg/kg/hr, bolus 40mcg/kg/dose\nMidazolam drip at 0.07mg/kg/hr at night, 0.06mg/kg/hr in daytime\nZofran\nBenadryl prn\nMaxolon prn\nTransamin\nNexium", "Solis", null, "", "103", "Fanny", "Progressive disease with increased left maxillary & left jaw mass, partial left nostril airway obstruction & left nasolacrimal duct obstruction, completed palliative RT in QMH on 22-26/8\n\nOn and off haematuria seen in urinary catheter, partially relieved with platelet transfusion\n\nPain control by PCA morphine, now on 40mcg/kg/hr, bolus 40mcg/kg/dose \nMidazolam drip at 0.06mg/kg/hr (daytime) 0.07mg/kg/hr (night time) may titrate up if irritable\n\nNeutropenic fever on 22/9\nEmpirical start on IV Meropenem \nCSU C/ST T/F", "Optimize pain control, can step up PCA morphine & midazolam drip as required\nPlatelet & PC transfusion prn \nNo need regular blood taking", "F", "ONC", "3S" },
                    { new Guid("b7d7e20a-3cdc-451f-b8ec-a6a522adf38a"), 2, new DateTime(2022, 12, 9, 1, 38, 50, 0, DateTimeKind.Unspecified), "SRNS presented in May\nOn Pred/FK \nFK in target range ", "559", "HN228", "SRNS ", new DateTime(2022, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Wall", null, "", "228", "Lilly", "Last Albumin infusion 14/7 \nLatest albumin 18 -> 11 but otherwise no s/s of underfill, no hemoconcentration\nTransient abd pain but otherwise good perfusion, good PU ", "Observe abd pain \nIf really have S/S of underfill, can consider albumin infusion ", "M", "REN", "5N" },
                    { new Guid("bb6ddf9c-5cf3-4d78-97b1-874ffa24c5db"), 1, new DateTime(2023, 1, 3, 3, 36, 30, 0, DateTimeKind.Unspecified), "osteosarcoma as charted above, poor tumor necrosis, lung metastasis. Finished 2 courses of GEMOX\nRight leg wound with debridement performed. Tissue culture and wound swab - no growth.", "306", "HN114", "Relapsed osteosarcoma, first over left humerus, then right proximal tibia. Finished OT and 2 courses of GEMOX. \n", new DateTime(2022, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Tyler", null, "CT thorax 10/6", "114", "Osborn", "continue IV tazocin till 14/5.\nPlan resume next course chemotherapy (gemcitbine-docetaxel course 4) on coming Monday.", "", "M", "ONC", "3S" },
                    { new Guid("bef427ee-f749-4820-9774-a4c242d62661"), 1, new DateTime(2022, 12, 6, 8, 59, 47, 0, DateTimeKind.Unspecified), "Fever, settled\nNo port-a-cath care for sometime because of COVID, then port-a-cath blocked. Pending removal of port on 1/4", "308", "HN120", "relapsed stage 4 neuroblastoma", new DateTime(2022, 2, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Crawford", null, "", "120", "Ramsey", "Continue Abx. port-a-cath removal today not done", "Book EOT on 3/4 for removal of Port-a-cath for 4/4 ", "M", "ONC", "3S" },
                    { new Guid("bf3bbbf9-cfb1-4136-a2e2-b33771ba8e37"), 1, new DateTime(2023, 1, 9, 5, 53, 55, 0, DateTimeKind.Unspecified), "left basal ganglia GCT\nbehavioural problem \nsocial problem, signed off child, SWD as guardian", "333", "HN100", "left basal ganglia GCT", new DateTime(2022, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "vancomycin", "Deirdre", null, "", "100", "Eliza", "Back from RT in PWH\n\nRecent rhinovirus URI\nLine c/st white lumen 11/7: staphy haemolyticus\nOn D4 vancomycin\nRepeated c/st NG so far\nCurrently afebrile, no coryzal symptoms", "To PWH on 18/7 for RT\ncontinue vancomycin, plan for total 7 day if repeated c/st no growth ", "M", "ONC", "3S" },
                    { new Guid("c2230268-5025-4434-9b1d-11dade72d3e7"), 2, new DateTime(2023, 1, 10, 12, 0, 56, 0, DateTimeKind.Unspecified), "ARPKD on HD", "518", "HN211", "ARPKD on HD\nFever of unknown origin", new DateTime(2022, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "April", null, "", "211", "Thornton", "3rd episode of fever of unknown origin with high inflammatory markers\nOn tazocin\nPending PET-CT 4/5/22\n\nClinically well, remained afebrile", "Continue Tazocin over weekend and PH\nPending PET-CT 4/5/22", "M", "REN", "5N" },
                    { new Guid("c2428b29-678e-477b-8047-949445f468e5"), 2, new DateTime(2023, 1, 2, 3, 20, 1, 0, DateTimeKind.Unspecified), "post transplant 8wk", "531", "HN204", "ANCA vasculitis \npost kidney trasnplant ", new DateTime(2022, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Nina", null, "", "204", "Kane", "graft kidney dysfunction", "on IVF + methylpred\n?UTI on IV augmentin\nawait renal biopsy report", "M", "REN", "5N" },
                    { new Guid("c56ae5da-554c-4999-9d68-ff819925e51b"), 2, new DateTime(2022, 12, 1, 4, 25, 0, 0, DateTimeKind.Unspecified), "Newly diagnosed genetically confirmed PH1", "529", "HN220", "Newly diagnosed genetically confirmed PH1", new DateTime(2022, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), ".", "Crawford", null, ".", "220", "Nora", "Started on pyridoxine & K citrate since 21/6/22\nComplained of tiptoeing gait since 22/6 afternoon, also point to left foot for pain on 24/6\nParents discontinued the medications since 23/6 afternoon", "Withhold pyridoxine\nFor blood test and Xray ", "F", "REN", "5N" },
                    { new Guid("d122c045-b445-4bcd-a8b6-8bc6d77d4bb8"), 1, new DateTime(2023, 1, 10, 6, 55, 0, 0, DateTimeKind.Unspecified), "R frontoethmoid Ewing's sarcoma\nCompleted consolidation chemotherapy and RT.\nOral mucositis resolved.", "344", "HN111", "Ewing's sarcoma", new DateTime(2022, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "TPN", "April", null, "Blood culture so far no growth\nOral swab HSV1 +ve\nMSU no growth\n", "111", "Rosella", "complains of loose stool since last night after milk intake. No blood/ mucous in stool. no fever/ vomiting.\nStool culture saved T/F. stool x reducing substances T/F. Stool x CD pcR negative.\nOn TPN now in view of diarrhea after milk intake. Not yet tolerating solid foods.", "", "F", "ONC", "3S" },
                    { new Guid("e41b2b40-bb82-4f94-95fc-e6e6c291b0d3"), 2, new DateTime(2023, 1, 18, 5, 29, 27, 0, DateTimeKind.Unspecified), "Primary disease - ? Nephronophthisis\nPost-renal transplant DDT 6+ months (on 5/2/22)\nImpaired graft function\nBiopsy proven BKV nephropathy\nDSA +ve \nPending biopsy report", "545", "HN200", "Underlying ? Nephronophthisis, Post-renal transplant DDT 6+ months (on 5/2/22)\nBKV nephropathy.\nImpaired graft function\nDSA +Ve \nBiopsy result pending \n", new DateTime(2022, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Deirdre", null, "", "200", "Jamie", "Impaired graft function\nBKVN - Changed immunosuppressant to Cyclosporin/ Leflunomide ; Started Cidofovir infusion\nLatest BK PCR 4 log (decreasing)\nNoted DSA Low MFI level of IgG antibodies against HLA Class I and Class II antigens are detected\nSuspected rejection; biopsy done on 24/8, pending biopsy result \nIS plan - change to Cyclosporin/ Everolimus \ngiven plasma exchang and IVIG", "home today", "F", "REN", "5N" },
                    { new Guid("e7e541a6-dd1f-4bcc-971d-bfe024e68696"), 2, new DateTime(2023, 1, 17, 10, 1, 33, 0, DateTimeKind.Unspecified), "CAKUT, ESKD on HD ", "506", "HN208", "CAKUT, ESKD on HD \nE.Coli UTI ", new DateTime(2022, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Ora", null, "", "208", "Valencia", "breakthrough UTI\non AUgmentin", "HL between HDF", "F", "REN", "5N" },
                    { new Guid("eea0a4cf-2d9f-4448-be24-08de2aa2f1c0"), 2, new DateTime(2022, 12, 8, 2, 20, 1, 0, DateTimeKind.Unspecified), "CAKUT, post-DDT 5 months\nGraft ureteric stricture, post-reimplantation 16/11/2022 (POD16)", "523", "HN223", "CAKUT, post-DDT 5 months", new DateTime(2022, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "IV Vancomycin", "Vicki", null, "", "223", "Benita", "Spigotted PCN on 30/11 (POD14), off foley on 1/12\nRepeated USG urinary system (2/12/2022): slightly prominent central calyces but less prominent than previous scan on 25/11, renal pelvis APPD 0.7cm\nGood urine output, RFT static, Cr 125\n\nEnterococcus faecium UTI, with dysuria\nTreated with IV Vancomycin", "Continue IV Vancomycin\nAllow HL in between antibiotics\nWill recheck RFT mane ", "F", "REN", "5N" }
                });

            migrationBuilder.InsertData(
                table: "HandoverLogs",
                columns: new[] { "id", "HandoverId", "LogBy", "LogText", "LogTime" },
                values: new object[,]
                {
                    { new Guid("00b18eac-782b-4a17-bf87-e3c65197781d"), new Guid("c2428b29-678e-477b-8047-949445f468e5"), "Dillon", "Demo", new DateTime(2023, 1, 3, 1, 51, 56, 0, DateTimeKind.Unspecified) },
                    { new Guid("03e7d837-73fc-4617-8b63-20dc81d88314"), new Guid("6fddfbf5-1be4-4f24-8bbf-fa4d2183aa1f"), "Carissa", "Demo", new DateTime(2023, 1, 4, 10, 34, 15, 0, DateTimeKind.Unspecified) },
                    { new Guid("0ba10f87-a314-4cf8-8251-3b253f9d57d5"), new Guid("bef427ee-f749-4820-9774-a4c242d62661"), "Crawford", "Demo", new DateTime(2023, 1, 6, 2, 12, 14, 0, DateTimeKind.Unspecified) },
                    { new Guid("0c648588-21b7-41e1-8c2b-ac6d29b56690"), new Guid("ad3e8561-631a-48ae-9552-a1810b604413"), "Jackie", "Demo", new DateTime(2023, 1, 8, 6, 52, 26, 0, DateTimeKind.Unspecified) },
                    { new Guid("0d83f35e-9349-4b29-b230-ca5f84f40b47"), new Guid("35ed9db8-e151-4ab0-919d-b5ada2319707"), "Carroll", "Demo", new DateTime(2023, 1, 19, 7, 56, 7, 0, DateTimeKind.Unspecified) },
                    { new Guid("0e11c26a-8507-4cd5-852b-7437a84697e0"), new Guid("8a54131a-2d4b-4176-a982-a1b41665bd6f"), "Leon", "Demo", new DateTime(2023, 1, 16, 12, 12, 21, 0, DateTimeKind.Unspecified) },
                    { new Guid("0e29d838-ca72-414f-b581-b86d5056fce2"), new Guid("512fb66d-b3a3-4fa9-a4af-7a973aaf3b8b"), "Jeanette", "Demo", new DateTime(2023, 1, 13, 10, 59, 7, 0, DateTimeKind.Unspecified) },
                    { new Guid("0e5a2179-ff31-4f61-a802-4eaa912ab0d4"), new Guid("61061ece-6963-406d-8566-6a5076492b84"), "Dena", "Demo", new DateTime(2023, 1, 12, 2, 33, 54, 0, DateTimeKind.Unspecified) },
                    { new Guid("0f19c16b-a5d0-479b-84d3-aee8c3e74e00"), new Guid("9f477d03-67a1-4991-bc57-1600e23d5e00"), "Mckee", "Demo", new DateTime(2023, 1, 1, 3, 32, 1, 0, DateTimeKind.Unspecified) },
                    { new Guid("0f28bec2-4567-4b24-ad15-940adec9e262"), new Guid("88306b01-b77c-44d9-bdf8-16ad025fd866"), "Ana", "Demo", new DateTime(2023, 1, 13, 5, 47, 28, 0, DateTimeKind.Unspecified) },
                    { new Guid("12351e35-7237-4217-9016-e7edd1d9931c"), new Guid("6945f8eb-eaf5-418e-9bab-126e34eb4110"), "White", "Demo", new DateTime(2023, 1, 12, 7, 18, 39, 0, DateTimeKind.Unspecified) },
                    { new Guid("150762a7-13f1-45c7-8c0e-fe3a57b57a46"), new Guid("359ebbdc-19fa-451f-b6ef-a690545d620b"), "Michelle", "Demo", new DateTime(2023, 1, 3, 12, 21, 38, 0, DateTimeKind.Unspecified) },
                    { new Guid("165c0a7e-bbca-4ab4-8221-85fc3dbba6fb"), new Guid("0ff0643f-b034-4cca-bc25-ea29bc49a544"), "Emily", "Demo", new DateTime(2023, 1, 13, 6, 55, 20, 0, DateTimeKind.Unspecified) },
                    { new Guid("1ca4fa18-684f-4717-a588-ba27aec45585"), new Guid("0fddb7fb-69e0-4e38-ab36-69b9e19ff8a8"), "Nina", "Demo", new DateTime(2023, 1, 13, 5, 32, 50, 0, DateTimeKind.Unspecified) },
                    { new Guid("1f3a73a0-3040-4a8d-b8a5-d05e73e1836d"), new Guid("c56ae5da-554c-4999-9d68-ff819925e51b"), "Tia", "Demo", new DateTime(2023, 1, 3, 7, 13, 35, 0, DateTimeKind.Unspecified) },
                    { new Guid("1fe4875a-85ce-4736-a22c-60408ec1fa5b"), new Guid("57990ed5-38d3-4531-a6e2-fe0daf21675c"), "Raymond", "Demo", new DateTime(2023, 1, 11, 2, 21, 30, 0, DateTimeKind.Unspecified) },
                    { new Guid("26610a0d-9d70-47a9-bdf9-2471f78e5c58"), new Guid("2f7ecad2-49d0-471a-994b-5d1718e54ba2"), "Krystal", "Demo", new DateTime(2023, 1, 17, 12, 46, 38, 0, DateTimeKind.Unspecified) },
                    { new Guid("31b1c790-4ef3-407f-b7dd-410ee30c7db0"), new Guid("0db7b786-e1ed-465d-83dd-8f6b4562e19d"), "Pacheco", "Demo", new DateTime(2023, 1, 9, 6, 39, 58, 0, DateTimeKind.Unspecified) },
                    { new Guid("3d3cc16c-3c29-4611-8462-537b9b8e4aa3"), new Guid("4c4fb333-d2ab-400a-8086-b48671fd8472"), "Marissa", "Demo", new DateTime(2023, 1, 12, 11, 3, 15, 0, DateTimeKind.Unspecified) },
                    { new Guid("3eb48cba-e026-4567-9bdb-ef6c8623c206"), new Guid("010c958f-d701-4cfa-9013-ae8cc5785c3b"), "Spence", "Demo", new DateTime(2023, 1, 1, 1, 49, 52, 0, DateTimeKind.Unspecified) },
                    { new Guid("4a409078-2ff4-4435-95a0-cf53d8847e6a"), new Guid("0d6dc260-73c3-42b9-a06a-7ddb77b63bec"), "Luna", "Demo", new DateTime(2023, 1, 8, 4, 31, 32, 0, DateTimeKind.Unspecified) },
                    { new Guid("4f842157-68b2-40b4-a888-09e94af9c83c"), new Guid("987899d6-630d-43e1-b1c9-0f6ad2f7d9b5"), "Cotton", "Demo", new DateTime(2023, 1, 5, 5, 40, 15, 0, DateTimeKind.Unspecified) },
                    { new Guid("5394d183-ca57-4abf-a1e9-4ca235f8fb49"), new Guid("c2230268-5025-4434-9b1d-11dade72d3e7"), "Tanner", "Demo", new DateTime(2023, 1, 9, 10, 52, 45, 0, DateTimeKind.Unspecified) },
                    { new Guid("5654c925-d381-4a23-9d89-3b9da7905f06"), new Guid("4a4d817f-8681-4381-ad0d-118ae7a54cd1"), "Ora", "Demo", new DateTime(2023, 1, 6, 12, 5, 24, 0, DateTimeKind.Unspecified) },
                    { new Guid("5b248ba6-9c86-41cc-9391-0a5fcca7cb01"), new Guid("899e1260-7e95-4129-8def-3e038bd9b41e"), "Roth", "Demo", new DateTime(2023, 1, 7, 10, 32, 52, 0, DateTimeKind.Unspecified) },
                    { new Guid("5dccae90-ad60-4655-bc7e-ac2fcd003baf"), new Guid("61e846ee-3e88-43ab-af52-f0eea5abee0d"), "Latoya", "Demo", new DateTime(2023, 1, 7, 8, 15, 51, 0, DateTimeKind.Unspecified) },
                    { new Guid("672e63a8-a6f7-4a41-ad9d-196fd5887b27"), new Guid("bb6ddf9c-5cf3-4d78-97b1-874ffa24c5db"), "Tyler", "Demo", new DateTime(2023, 1, 3, 9, 28, 10, 0, DateTimeKind.Unspecified) },
                    { new Guid("6ec36a45-3b2a-4db8-bf9b-fb1c1097eaba"), new Guid("83ae23fd-fcf5-4544-827a-35988130126e"), "Bernard", "Demo", new DateTime(2023, 1, 7, 8, 48, 2, 0, DateTimeKind.Unspecified) },
                    { new Guid("6ec93b87-4e71-4358-a847-928b8aa6093d"), new Guid("7ec92cca-f0f9-441c-a475-256c2ac5c42a"), "Barbra", "Demo", new DateTime(2023, 1, 14, 5, 33, 9, 0, DateTimeKind.Unspecified) },
                    { new Guid("70850427-ba75-4ee6-9ed8-6dbe205a286d"), new Guid("a474f6cd-9ebc-489d-8c54-f991755a020e"), "Lessie", "Demo", new DateTime(2023, 1, 11, 11, 21, 51, 0, DateTimeKind.Unspecified) },
                    { new Guid("7714ad74-1848-4744-8e42-39a69939ce38"), new Guid("4b06f640-41a9-4237-9677-74435abfcfce"), "Mckenzie", "Demo", new DateTime(2023, 1, 4, 8, 20, 9, 0, DateTimeKind.Unspecified) },
                    { new Guid("7f21694b-f8b3-4d59-9742-efca718c9b57"), new Guid("3d3653bb-9efb-4b95-8358-74cd4be192f9"), "Forbes", "Demo", new DateTime(2023, 1, 8, 5, 4, 56, 0, DateTimeKind.Unspecified) },
                    { new Guid("7fe3b6ec-bb39-4df8-b72b-802652a6cff1"), new Guid("19ab641c-084d-4eb5-8e89-d7d552258587"), "Copeland", "Demo", new DateTime(2023, 1, 4, 3, 33, 44, 0, DateTimeKind.Unspecified) },
                    { new Guid("85fd51f5-1eb3-46fe-867d-f77df47158e6"), new Guid("675528cb-a292-44cf-baaa-0e32ac71c3ac"), "Colon", "Demo", new DateTime(2023, 1, 19, 3, 12, 15, 0, DateTimeKind.Unspecified) },
                    { new Guid("88a484d5-bc15-4136-b934-56ff7f245a26"), new Guid("0015008d-eb4e-4ba0-8b10-3b7499916237"), "Ramos", "Demo", new DateTime(2023, 1, 19, 7, 37, 22, 0, DateTimeKind.Unspecified) },
                    { new Guid("88f48071-fcf2-45a1-9e4e-b94eec7ceb6f"), new Guid("4fe0af36-5e5c-4ab6-b36f-91766ee9a34b"), "Bertha", "Demo", new DateTime(2023, 1, 1, 10, 58, 12, 0, DateTimeKind.Unspecified) },
                    { new Guid("9645223e-735b-41ab-8342-f104df01d389"), new Guid("8d17d19b-1742-422f-8668-5751e635f95a"), "Alfreda", "Demo", new DateTime(2023, 1, 4, 8, 55, 35, 0, DateTimeKind.Unspecified) },
                    { new Guid("9ab55093-28f1-40a7-a171-fc6fe4ed1e03"), new Guid("9e04e667-91d4-4535-bbda-9d302ac3d308"), "Lou", "Demo", new DateTime(2023, 1, 12, 1, 16, 33, 0, DateTimeKind.Unspecified) },
                    { new Guid("9b5221fe-bf5e-47b0-9fd5-630023afd78e"), new Guid("75a130a7-cbce-4a52-a989-00704fcf8f05"), "Agnes", "Demo", new DateTime(2023, 1, 13, 5, 57, 46, 0, DateTimeKind.Unspecified) },
                    { new Guid("9d5b4dc7-b8a7-4c8a-8a69-c5668ba8ad15"), new Guid("d122c045-b445-4bcd-a8b6-8bc6d77d4bb8"), "April", "Demo", new DateTime(2023, 1, 12, 1, 17, 53, 0, DateTimeKind.Unspecified) },
                    { new Guid("9fcc4fa9-135c-4e1d-9508-7ef64dbfc982"), new Guid("268612ba-215d-4316-9daa-518d4b892b09"), "Mcdonald", "Demo", new DateTime(2023, 1, 13, 3, 9, 25, 0, DateTimeKind.Unspecified) },
                    { new Guid("a4dd9449-bb59-4979-910d-4656fdb7930c"), new Guid("bf3bbbf9-cfb1-4136-a2e2-b33771ba8e37"), "Deirdre", "Demo", new DateTime(2023, 1, 7, 10, 8, 49, 0, DateTimeKind.Unspecified) },
                    { new Guid("a5d1e044-0594-4780-a04e-8b85c5d14639"), new Guid("6b18f490-b125-419c-a4b9-611782d9f48c"), "Clay", "Demo", new DateTime(2023, 1, 8, 7, 9, 15, 0, DateTimeKind.Unspecified) },
                    { new Guid("a9d79cfe-379d-4be3-9fd4-1249910a0237"), new Guid("a3dd2bcd-c4cc-4f8c-bfc3-3fb712367b43"), "Ester", "Demo", new DateTime(2023, 1, 4, 1, 14, 32, 0, DateTimeKind.Unspecified) },
                    { new Guid("aeddb8a8-0d4d-482e-b34b-0a0b382b8065"), new Guid("72c23629-ab17-4ef3-8c58-034a6cfe00fa"), "Wall", "Demo", new DateTime(2023, 1, 10, 3, 4, 5, 0, DateTimeKind.Unspecified) },
                    { new Guid("b66742cd-bf26-4af0-b7b4-05f910218603"), new Guid("602b8d2b-5c6e-4875-a93e-ee1e7fe86ea6"), "Villarreal", "Demo", new DateTime(2023, 1, 11, 12, 42, 23, 0, DateTimeKind.Unspecified) },
                    { new Guid("bbc6e200-df60-4e57-ab49-5aead53f42c2"), new Guid("74fb46ec-d6ba-4130-9459-88f4e26d7397"), "Vicki", "Demo", new DateTime(2023, 1, 5, 9, 41, 13, 0, DateTimeKind.Unspecified) },
                    { new Guid("d36e2a5c-8869-4ccb-be7b-935dfe02577a"), new Guid("4d0a6069-8884-4eae-980e-804563fa95d6"), "Kathrine", "Demo", new DateTime(2023, 1, 3, 6, 22, 31, 0, DateTimeKind.Unspecified) },
                    { new Guid("d5440b58-ff54-44b2-b09d-86f1e961a10e"), new Guid("369beda0-b793-4013-a0a0-dcb0563a95f0"), "Underwood", "Demo", new DateTime(2023, 1, 2, 8, 57, 18, 0, DateTimeKind.Unspecified) },
                    { new Guid("d7b24306-df4a-47ac-9ae4-4dd473c3e78f"), new Guid("1ecf7279-c3f0-47af-8bce-6b32da216204"), "Hurst", "Demo", new DateTime(2023, 1, 10, 8, 44, 24, 0, DateTimeKind.Unspecified) },
                    { new Guid("e0b2a0e6-b2c1-4bbe-a811-4ddfb58f5635"), new Guid("8bd83b26-802e-4d25-a6a7-b101e5dbbc28"), "Melinda", "Demo", new DateTime(2023, 1, 11, 4, 30, 18, 0, DateTimeKind.Unspecified) },
                    { new Guid("e18d5326-301e-4f9e-8c5d-03e3e5e4cf2b"), new Guid("b5e57c67-fb9d-4c7e-a92f-a98b760e6795"), "Solis", "Demo", new DateTime(2023, 1, 18, 5, 17, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e2aa8ba4-2583-4230-8039-0338eec6284c"), new Guid("e7e541a6-dd1f-4bcc-971d-bfe024e68696"), "Bean", "Demo", new DateTime(2023, 1, 10, 11, 9, 35, 0, DateTimeKind.Unspecified) },
                    { new Guid("eab57352-150f-46fe-be54-6a9907b1276f"), new Guid("e41b2b40-bb82-4f94-95fc-e6e6c291b0d3"), "Strong", "Demo", new DateTime(2023, 1, 10, 10, 6, 51, 0, DateTimeKind.Unspecified) },
                    { new Guid("eab6e80a-8784-461b-b81b-05a6e1983ab0"), new Guid("b7d7e20a-3cdc-451f-b8ec-a6a522adf38a"), "Rasmussen", "Demo", new DateTime(2023, 1, 9, 10, 11, 2, 0, DateTimeKind.Unspecified) },
                    { new Guid("eeb3b605-89b2-441c-af2d-cea528669fc5"), new Guid("eea0a4cf-2d9f-4448-be24-08de2aa2f1c0"), "Oconnor", "Demo", new DateTime(2023, 1, 13, 11, 31, 48, 0, DateTimeKind.Unspecified) },
                    { new Guid("f0a76ac5-6aa9-4c3a-ad34-a73c2f554ffb"), new Guid("177b70e2-a016-419d-9553-e91069227a51"), "Frankie", "Demo", new DateTime(2023, 1, 4, 1, 52, 50, 0, DateTimeKind.Unspecified) },
                    { new Guid("f5234e10-3e68-4620-bf96-9fc158600bd8"), new Guid("a6a4a6c6-5e12-4540-818d-0e50931d3757"), "Carolyn", "Demo", new DateTime(2023, 1, 6, 6, 49, 38, 0, DateTimeKind.Unspecified) },
                    { new Guid("f8ed2808-43f6-407a-ae0d-cd48d38a6dac"), new Guid("3b402470-0317-43d9-add5-5d04ad869380"), "Maryann", "Demo", new DateTime(2023, 1, 18, 8, 51, 23, 0, DateTimeKind.Unspecified) },
                    { new Guid("fefa8b3d-05fc-4f0c-91b7-61adde532b44"), new Guid("41ba6c7e-437b-412d-a2f3-f6ec1fb14e4f"), "Tammi", "Demo", new DateTime(2023, 1, 10, 4, 57, 50, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Handover_GroupId",
                table: "Handover",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_HandoverLogs_HandoverId",
                table: "HandoverLogs",
                column: "HandoverId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GetWardPatients");

            migrationBuilder.DropTable(
                name: "HandoverLogs");

            migrationBuilder.DropTable(
                name: "Handover")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "HandoverHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart");

            migrationBuilder.DropTable(
                name: "HandoverGroups");
        }
    }
}
