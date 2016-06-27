namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGenreTable1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Movies", "GenreSet_Id", "dbo.GenreSets");
            DropIndex("dbo.Movies", new[] { "GenreSet_Id" });
            AlterColumn("dbo.Movies", "GenreSet_Id", c => c.Int());
            CreateIndex("dbo.Movies", "GenreSet_Id");
            AddForeignKey("dbo.Movies", "GenreSet_Id", "dbo.GenreSets", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "GenreSet_Id", "dbo.GenreSets");
            DropIndex("dbo.Movies", new[] { "GenreSet_Id" });
            AlterColumn("dbo.Movies", "GenreSet_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Movies", "GenreSet_Id");
            AddForeignKey("dbo.Movies", "GenreSet_Id", "dbo.GenreSets", "Id", cascadeDelete: true);
        }
    }
}
