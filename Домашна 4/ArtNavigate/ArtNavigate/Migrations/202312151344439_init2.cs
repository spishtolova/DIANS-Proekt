namespace ArtNavigate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ArtGaleries", "NameEnglish", c => c.String());
            AddColumn("dbo.ArtGaleries", "AdressEnglish", c => c.String());
            AddColumn("dbo.ArtGaleries", "CityEnglish", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ArtGaleries", "CityEnglish");
            DropColumn("dbo.ArtGaleries", "AdressEnglish");
            DropColumn("dbo.ArtGaleries", "NameEnglish");
        }
    }
}
