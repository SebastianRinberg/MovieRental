namespace MovieRental.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class PopulateDocumentaryGenre : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO DocumentaryGenres (Name) VALUES ('Health')");
            Sql("INSERT INTO DocumentaryGenres (Name) VALUES ('Nature')");
            Sql("INSERT INTO DocumentaryGenres (Name) VALUES ('Animal')");
            Sql("INSERT INTO DocumentaryGenres (Name) VALUES ('Science')");
            Sql("INSERT INTO DocumentaryGenres (Name) VALUES ('Sport')");
        }

        public override void Down()
        {
        }
    }
}
