namespace MovieRental.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNotationToDocumentary : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Documentaries", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Documentaries", "Name", c => c.String());
        }
    }
}
