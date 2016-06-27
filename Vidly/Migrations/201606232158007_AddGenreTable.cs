namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGenreTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GenreSets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Movies", "GenreSetId", c => c.Byte(nullable: false));
            AddColumn("dbo.Movies", "GenreSet_Id", c => c.Int());
            AlterColumn("dbo.Movies", "Genre", c => c.String(nullable: false));
            AlterColumn("dbo.Movies", "ReleaseDate", c => c.String(nullable: false));
            AlterColumn("dbo.Movies", "DateAdded", c => c.String(nullable: false));
            CreateIndex("dbo.Movies", "GenreSet_Id");
            AddForeignKey("dbo.Movies", "GenreSet_Id", "dbo.GenreSets", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "GenreSet_Id", "dbo.GenreSets");
            DropIndex("dbo.Movies", new[] { "GenreSet_Id" });
            AlterColumn("dbo.Movies", "DateAdded", c => c.String());
            AlterColumn("dbo.Movies", "ReleaseDate", c => c.String());
            AlterColumn("dbo.Movies", "Genre", c => c.String());
            DropColumn("dbo.Movies", "GenreSet_Id");
            DropColumn("dbo.Movies", "GenreSetId");
            DropTable("dbo.GenreSets");
        }
    }
}
