namespace MunicipalTrashCollection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedFieldsInDay : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Days", "PickUpDateChange", c => c.DateTime());
            AlterColumn("dbo.Days", "StartVacation", c => c.DateTime());
            AlterColumn("dbo.Days", "EndVacation", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Days", "EndVacation", c => c.String());
            AlterColumn("dbo.Days", "StartVacation", c => c.String());
            AlterColumn("dbo.Days", "PickUpDateChange", c => c.String());
        }
    }
}
