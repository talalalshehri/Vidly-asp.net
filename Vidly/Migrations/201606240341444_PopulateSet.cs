namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateSet : DbMigration
    {
        public override void Up()
        {
            Sql("SET IDENTITY_INSERT GenreSets ON");
            Sql("INSERT INTO GenreSets (Id, Name) VALUES (1, 'Action')");
            Sql("INSERT INTO GenreSets (Id, Name) VALUES (2, 'Thriller')");
            Sql("INSERT INTO GenreSets (Id, Name) VALUES (3, 'Family')");
            Sql("INSERT INTO GenreSets (Id, Name) VALUES (4, 'Romance')");
            Sql("INSERT INTO GenreSets (Id, Name) VALUES (5, 'Comedy')");
        }
        
        public override void Down()
        {
        }
    }
}
