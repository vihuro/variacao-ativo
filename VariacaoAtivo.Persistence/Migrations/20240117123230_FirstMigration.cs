using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace VariacaoAtivo.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tab_chart",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Currency = table.Column<string>(type: "text", nullable: false),
                    Symbol = table.Column<string>(type: "text", nullable: false),
                    ExachangeName = table.Column<string>(type: "text", nullable: false),
                    ExchangeTimeZone = table.Column<string>(type: "text", nullable: false),
                    RegularMarketPrice = table.Column<double>(type: "double precision", nullable: false),
                    ChartPreviousClose = table.Column<double>(type: "double precision", nullable: false),
                    PreviousClose = table.Column<double>(type: "double precision", nullable: false),
                    QuoteClose = table.Column<List<double>>(type: "double precision[]", nullable: false),
                    QuoteHigh = table.Column<List<double>>(type: "double precision[]", nullable: false),
                    QuoteLow = table.Column<List<double>>(type: "double precision[]", nullable: false),
                    QuoteOpen = table.Column<List<double>>(type: "double precision[]", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tab_chart", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tab_chart");
        }
    }
}
