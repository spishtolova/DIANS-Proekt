namespace ArtNavigate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init4 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ArtPieces",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.Int(nullable: false),
                        nameEnglish = c.Int(nullable: false),
                        imageURL = c.Int(nullable: false),
                        artistName = c.Int(nullable: false),
                        artGalery_Id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.ArtGaleries", t => t.artGalery_Id)
                .Index(t => t.artGalery_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ArtPieces", "artGalery_Id", "dbo.ArtGaleries");
            DropIndex("dbo.ArtPieces", new[] { "artGalery_Id" });
            DropTable("dbo.ArtPieces");
        }
    }
}
