using Microsoft.EntityFrameworkCore;
using GS_EAP.Models.Usuarios;
using System.Collections.Generic;
using GS_EAP.Models.Veiculos;
using GS_EAP.Models.Parceiros;
using Microsoft.Extensions.Hosting;
using System.Runtime.Intrinsics.X86;
using Microsoft.AspNetCore.Hosting.Server;
using MySql.Data.MySqlClient;

namespace GS_EAP.Data
{
    public class Context : DbContext
    {
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Veiculos> Veiculos { get; set; }
        public DbSet<Parceiros> Parceiros { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseMySQL("Server=mysqlfiap.mysql.database.azure.com;User Id=mysqlfiap;Password=fiap@2022;Database=mysqlfiap");
            optionsBuilder.UseMySQL("Server=127.0.0.1;Port=3306;User Id=root;Password=fiap@2022;Database=fiap;Port=3306");
            //optionsBuilder.UseOracle("User Id=RM88439;Password=100101;Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=tcp)(HOST=oracle.fiap.com.br)(PORT=1521))(CONNECT_DATA=(SID=orcl)))");
            //optionsBuilder.UseMySQL("Server = mysqlfiap.mysql.database.azure.com; UserID = mysqlfiap; Password = fiap@2022; Database = mysqlfiap; SslCa = BaltimoreCyberTrustRoot.crt.pem");


        }
    }
}
