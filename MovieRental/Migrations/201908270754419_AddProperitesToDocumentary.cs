namespace MovieRental.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProperitesToDocumentary : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Documentaries", "ReleaseDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Documentaries", "DateAdded", c => c.DateTime(nullable: false));
            AddColumn("dbo.Documentaries", "NumberInStock", c => c.Int(nullable: false));
            AddColumn("dbo.Documentaries", "GenreId", c => c.Int(nullable: false));
            CreateIndex("dbo.Documentaries", "GenreId");
            AddForeignKey("dbo.Documentaries", "GenreId", "dbo.Genres", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Documentaries", "GenreId", "dbo.Genres");
            DropIndex("dbo.Documentaries", new[] { "GenreId" });
            DropColumn("dbo.Documentaries", "GenreId");
            DropColumn("dbo.Documentaries", "NumberInStock");
            DropColumn("dbo.Documentaries", "DateAdded");
            DropColumn("dbo.Documentaries", "ReleaseDate");
        }
    }
}
