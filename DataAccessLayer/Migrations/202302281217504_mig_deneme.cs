namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_deneme : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        FlagImage = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Users", "Country_Id", c => c.Int());
            CreateIndex("dbo.Users", "Country_Id");
            AddForeignKey("dbo.Users", "Country_Id", "dbo.Countries", "Id");
            DropColumn("dbo.Users", "Country");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Country", c => c.String(maxLength: 20));
            DropForeignKey("dbo.Users", "Country_Id", "dbo.Countries");
            DropIndex("dbo.Users", new[] { "Country_Id" });
            DropColumn("dbo.Users", "Country_Id");
            DropTable("dbo.Countries");
        }
    }
}
