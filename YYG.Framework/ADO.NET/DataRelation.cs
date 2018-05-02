using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YYG.Framework.ADO.NET
{
   public class DataRelation
    {
        public void Relation()
        {
            var tb = new DataTable("User");
            tb.Columns.Add(new DataColumn("ID", typeof(int)));
            tb.Columns.Add(new DataColumn("Name", typeof(string)));
            tb.Columns.Add(new DataColumn("RoleID", typeof(int)));
            var pk = new DataColumn[1];
            pk[0]=tb.Columns["ID"];
            tb.PrimaryKey = pk;
            tb.Constraints.Add(new UniqueConstraint("PK_User",pk[0]));

            var tl = new DataTable("Role");
            tl.Columns.Add(new DataColumn("ID", typeof(int)));
            tl.Columns.Add(new DataColumn("Name", typeof(string)));
            var pk2 = new DataColumn[1];
            pk2[0] = tl.Columns["ID"];
            tl.PrimaryKey = pk2;
            tl.Constraints.Add(new UniqueConstraint("PK_Role", pk2[0]));

            DataColumn parent = tl.Columns["ID"];
            DataColumn child = tl.Columns["RoleID"];
            ForeignKeyConstraint fk = new ForeignKeyConstraint("FK_User_RoleID", parent, child);
            fk.DeleteRule = Rule.Cascade;
            fk.UpdateRule = Rule.Cascade;
            tb.Constraints.Add(fk);

            DataSet ds = new DataSet("energy");
            ds.Tables.Add(tb);
            ds.Tables.Add(tl);
        }

        
    }
}
