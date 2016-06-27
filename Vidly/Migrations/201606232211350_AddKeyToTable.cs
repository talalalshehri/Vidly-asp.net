namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddKeyToTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Movies", "GenreSet_Id", "dbo.GenreSets");
            DropIndex("dbo.Movies", new[] { "GenreSet_Id" });
            DropColumn("dbo.Movies", "GenreSetId");
            RenameColumn(table: "dbo.Movies", name: "GenreSet_Id", newName: "GenreSetId");
            DropPrimaryKey("dbo.GenreSets");
            AlterColumn("dbo.Movies", "GenreSetId", c => c.Byte(nullable: false));
            AlterColumn("dbo.GenreSets", "Id", c => c.Byte(nullable: false));
            AddPrimaryKey("dbo.GenreSets", "Id");
            CreateIndex("dbo.Movies", "GenreSetId");
            AddForeignKey("dbo.Movies", "GenreSetId", "dbo.GenreSets", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "GenreSetId", "dbo.GenreSets");
            DropIndex("dbo.Movies", new[] { "GenreSetId" });
            DropPrimaryKey("dbo.GenreSets");
            AlterColumn("dbo.GenreSets", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Movies", "GenreSetId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.GenreSets", "Id");
            RenameColumn(table: "dbo.Movies", name: "GenreSetId", newName: "GenreSet_Id");
            AddColumn("dbo.Movies", "GenreSetId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Movies", "GenreSet_Id");
            AddForeignKey("dbo.Movies", "GenreSet_Id", "dbo.GenreSets", "Id", cascadeDelete: true);
        }
    }
}
