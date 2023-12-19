namespace ArtNavigate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init7 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.ArtPieces", "artGaleriyId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ArtPieces", "artGaleriyId", c => c.Int(nullable: false));
        }
    }
}
