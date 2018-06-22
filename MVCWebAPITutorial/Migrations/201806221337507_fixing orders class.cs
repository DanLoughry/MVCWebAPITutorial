namespace MVCWebAPITutorial.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixingordersclass : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "Description", c => c.String());
            DropColumn("dbo.Orders", "Desription");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "Desription", c => c.String());
            DropColumn("dbo.Orders", "Description");
        }
    }
}
