namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeMovieDomain : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Movies", name: "GenreSetId", newName: "GenreId");
            RenameIndex(table: "dbo.Movies", name: "IX_GenreSetId", newName: "IX_GenreId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Movies", name: "IX_GenreId", newName: "IX_GenreSetId");
            RenameColumn(table: "dbo.Movies", name: "GenreId", newName: "GenreSetId");
        }
    }
}
