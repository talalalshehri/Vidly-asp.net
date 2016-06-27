namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditMovieModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Movies", "GenreSet_Id", "dbo.GenreSets");
            DropIndex("dbo.Movies", new[] { "GenreSet_Id" });
            AlterColumn("dbo.Movies", "Name", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Movies", "GenreSet_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Movies", "GenreSet_Id");
            AddForeignKey("dbo.Movies", "GenreSet_Id", "dbo.GenreSets", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "GenreSet_Id", "dbo.GenreSets");
            DropIndex("dbo.Movies", new[] { "GenreSet_Id" });
            AlterColumn("dbo.Movies", "GenreSet_Id", c => c.Int());
            AlterColumn("dbo.Movies", "Name", c => c.String());
            CreateIndex("dbo.Movies", "GenreSet_Id");
            AddForeignKey("dbo.Movies", "GenreSet_Id", "dbo.GenreSets", "Id");
        }
    }
}
