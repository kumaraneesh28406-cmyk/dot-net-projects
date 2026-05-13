namespace WebApplication_cnt_sta_cty_Reg_layout_1175.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class popularcntctyreg : DbMigration
    {
        public override void Up()
        {
            //country
            Sql("insert Countries values('India')"); //1
            Sql("insert Countries values('UK')"); //2
            Sql("insert Countries values('US')"); //3
            //state
            Sql("insert States values('Punjab',1)"); //1
            Sql("insert States values('HP',1)"); //2
            Sql("insert States values('UP',1)"); //3
            Sql("insert States values('ABC',2)"); //4
            Sql("insert States values('XYZ',2)"); //5
            Sql("insert States values('ASD',2)"); //6
            // city
            Sql("insert Cities values('Mohali',1)");
            Sql("insert Cities values('LDH',1)");
            Sql("insert Cities values('ASR',1)");
            Sql("insert Cities values('Shimla',2)");
            Sql("insert Cities values('Kangra',2)");
            Sql("insert Cities values('Una',2)");

        }

        public override void Down()
        {
        }
    }
}
