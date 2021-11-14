namespace EmployeeBonus.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeNullity : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Bonus", "EmployeeName", c => c.String(nullable: false, maxLength: 150));
            AlterColumn("dbo.Departments", "Name", c => c.String(nullable: false, maxLength: 150));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Departments", "Name", c => c.String(maxLength: 150));
            AlterColumn("dbo.Bonus", "EmployeeName", c => c.String(maxLength: 150));
        }
    }
}
