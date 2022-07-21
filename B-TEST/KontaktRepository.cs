using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace B_TEST
{
    internal class KontaktRepository
    {
        public IList<Kontakt> GetAll()
                {
            using (SqlConnection conn = new SqlConnection("Data Source=localhost;Database=B-DEV;Trusted_Connection=True;Encrypt=False;TrustServerCertificate=False;"))

            { 
                conn.Open();
                return
                conn.Query<Kontakt>("select * from dbo.Kontakty").ToList();
                 
            }
        }


        public void Insert(Kontakt b)
        {
            using (SqlConnection conn = new SqlConnection("Data Source=localhost;Database=B-DEV;Trusted_Connection=True;Encrypt=False;TrustServerCertificate=False;"))
            using (SqlCommand cmd = new SqlCommand("INSERT INTO [dbo].[Kontakty] ([Meno]  ,[Priezvisko])  VALUES  (@Meno , @Priezvisko)", conn)) 
            {
                
                conn.Open();

                SqlParameter param1 = new SqlParameter("@Meno", b.Meno);
                SqlParameter param2 = new SqlParameter("@Priezvisko", b.Priezvisko);
                
                cmd.Parameters.Add(param1);
                cmd.Parameters.Add(param2);
                cmd.ExecuteNonQuery();
                
            }
        }

    }
}
