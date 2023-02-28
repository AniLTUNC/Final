namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_newuserprop : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Country", c => c.String(maxLength: 20));
            AddColumn("dbo.Users", "Gender", c => c.String(maxLength: 10));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "Gender");
            DropColumn("dbo.Users", "Country");
        }
    }
}
