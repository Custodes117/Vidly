namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMembershipType : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE MembershipTypes SET Name = 'Pay as you go' Where Id = 1");
            Sql("UPDATE MembershipTypes SET Name ='Monthly' Where Id = 2");
            Sql("UPDATE MembershipTypes SET Name ='Every third month' Where Id = 3");
            Sql("UPDATE MembershipTypes SET Name ='Every Year' Where Id = 4");
        }
        
        public override void Down()
        {
        }
    }
}
