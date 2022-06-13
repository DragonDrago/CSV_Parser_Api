namespace CSV_Parser_Api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedDatabase : DbMigration
    {
        public override void Up()
        {
           Sql("INSERT INTO Employees(PayrollNumber, Forenames, Surname, DateOfBirth, Telephone, Mobile, Address, Address2, Postcode, EmailHome, StartDate) VALUES('COOP08', 'John', 'William', '10/01/1955', '12345678', '987654231', '12 Foreman road', 'London', 'GU12 6JW', 'nomadic20@hotmail.co.uk', '10/04/2013')");
           Sql("INSERT INTO Employees(PayrollNumber, Forenames, Surname, DateOfBirth, Telephone, Mobile, Address, Address2, Postcode, EmailHome, StartDate) VALUES('JACK13', 'Jerry', 'Jackson', '10/5/1974', '2050508', '6987457', '115 Spinney Road', 'Luton', 'LU33DF', 'gerry.jackson@bt.com', '10/04/2013')"); 

        }

        public override void Down()
        {
        }
    }
}
