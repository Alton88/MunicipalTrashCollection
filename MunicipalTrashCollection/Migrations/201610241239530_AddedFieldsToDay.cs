namespace MunicipalTrashCollection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedFieldsToDay : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Days", "PickUpDateChange", c => c.String());
            AddColumn("dbo.Days", "StartVacation", c => c.String());
            AddColumn("dbo.Days", "EndVacation", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Days", "EndVacation");
            DropColumn("dbo.Days", "StartVacation");
            DropColumn("dbo.Days", "PickUpDateChange");
        }
    }
}
