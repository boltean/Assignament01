namespace ZenithWebSite.Migrations.Zenith
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InnitialCreate5 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Activities", "ActivityDescription", c => c.String(nullable: false, maxLength: 250));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Activities", "ActivityDescription", c => c.String(maxLength: 250));
        }
    }
}
