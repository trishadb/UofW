namespace UoW.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCol : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Gadgets", "DateAdded", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Gadgets", "DateAdded");
        }
    }
}
