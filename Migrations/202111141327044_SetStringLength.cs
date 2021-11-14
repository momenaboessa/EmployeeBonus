namespace EmployeeBonus.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SetStringLength : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Departments", "Name", c => c.String(maxLength: 150));
            AlterColumn("dbo.Employees", "Name", c => c.String(maxLength: 150));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employees", "Name", c => c.Int(nullable: false));
            AlterColumn("dbo.Departments", "Name", c => c.String());
        }
    }
}
