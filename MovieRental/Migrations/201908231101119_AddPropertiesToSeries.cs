namespace MovieRental.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPropertiesToSeries : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Series", "ReleaseDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Series", "DateAdded", c => c.DateTime(nullable: false));
            AddColumn("dbo.Series", "NumberInStock", c => c.Int(nullable: false));
            AddColumn("dbo.Series", "GenreId", c => c.Int(nullable: false));
            CreateIndex("dbo.Series", "GenreId");
            AddForeignKey("dbo.Series", "GenreId", "dbo.Genres", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Series", "GenreId", "dbo.Genres");
            DropIndex("dbo.Series", new[] { "GenreId" });
            DropColumn("dbo.Series", "GenreId");
            DropColumn("dbo.Series", "NumberInStock");
            DropColumn("dbo.Series", "DateAdded");
            DropColumn("dbo.Series", "ReleaseDate");
        }
    }
}
