namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeMovie : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Movies", "GenreSet_Id", "dbo.GenreSets");
            DropIndex("dbo.Movies", new[] { "GenreSet_Id" });
            AlterColumn("dbo.Movies", "ReleaseDate", c => c.String());
            AlterColumn("dbo.Movies", "DateAdded", c => c.String());
            AlterColumn("dbo.Movies", "GenreSet_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Movies", "GenreSet_Id");
            AddForeignKey("dbo.Movies", "GenreSet_Id", "dbo.GenreSets", "Id", cascadeDelete: true);
            DropColumn("dbo.Movies", "Genre");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movies", "Genre", c => c.String(nullable: false));
            DropForeignKey("dbo.Movies", "GenreSet_Id", "dbo.GenreSets");
            DropIndex("dbo.Movies", new[] { "GenreSet_Id" });
            AlterColumn("dbo.Movies", "GenreSet_Id", c => c.Int());
            AlterColumn("dbo.Movies", "DateAdded", c => c.String(nullable: false));
            AlterColumn("dbo.Movies", "ReleaseDate", c => c.String(nullable: false));
            CreateIndex("dbo.Movies", "GenreSet_Id");
            AddForeignKey("dbo.Movies", "GenreSet_Id", "dbo.GenreSets", "Id");
        }
    }
}
