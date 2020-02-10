using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
namespace KlasifikavimasXY
{
    class DatabaseAccessor
    {
        //SqlConnection sqlConn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Tomas\Desktop\mytestdb.sql;Integrated Security=True");
        //public DatabaseAccessor() {; }
        //public DataSet getMokAibe()
        //{
        //    DataSet dataset = new DataSet();
        //    SqlDataAdapter dap = new SqlDataAdapter("select * from object", sqlConn);
        //    dap.Fill(dataset);
        //    return dataset;
        //}
        //public List<ObjectTrainer> getAllItems()
        //{
        //    using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.ConnectionValue("mytestdb")))
        //    {
        //        var output = connection.Query<ObjectTrainer>("select * from object").ToList();
        //        return output;
        //    }
        //}
    }
}
