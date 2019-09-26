namespace MovieRental.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChanceGenrePropInDocumentaryModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Documentaries", "GenreId", "dbo.Genres");
            DropIndex("dbo.Documentaries", new[] { "GenreId" });
            AddColumn("dbo.Documentaries", "DocumentaryGenreId", c => c.Int(nullable: false));
            CreateIndex("dbo.Documentaries", "DocumentaryGenreId");
            AddForeignKey("dbo.Documentaries", "DocumentaryGenreId", "dbo.DocumentaryGenres", "Id", cascadeDelete: true);
            DropColumn("dbo.Documentaries", "GenreId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Documentaries", "GenreId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Documentaries", "DocumentaryGenreId", "dbo.DocumentaryGenres");
            DropIndex("dbo.Documentaries", new[] { "DocumentaryGenreId" });
            DropColumn("dbo.Documentaries", "DocumentaryGenreId");
            CreateIndex("dbo.Documentaries", "GenreId");
            AddForeignKey("dbo.Documentaries", "GenreId", "dbo.Genres", "Id", cascadeDelete: true);
        }
    }
}
