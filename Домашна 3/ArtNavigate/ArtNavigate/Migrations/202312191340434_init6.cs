namespace ArtNavigate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init6 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ArtPieces", "artGaleriyId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ArtPieces", "artGaleriyId");
        }
    }
}
