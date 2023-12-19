namespace ArtNavigate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init5 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ArtPieces", "name", c => c.String());
            AlterColumn("dbo.ArtPieces", "nameEnglish", c => c.String());
            AlterColumn("dbo.ArtPieces", "imageURL", c => c.String());
            AlterColumn("dbo.ArtPieces", "artistName", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ArtPieces", "artistName", c => c.Int(nullable: false));
            AlterColumn("dbo.ArtPieces", "imageURL", c => c.Int(nullable: false));
            AlterColumn("dbo.ArtPieces", "nameEnglish", c => c.Int(nullable: false));
            AlterColumn("dbo.ArtPieces", "name", c => c.Int(nullable: false));
        }
    }
}
