

using Ejercicio_CRUD_Mvvm_2.Models;
using System.Data.Entity;

namespace Ejercicio_CRUD_Mvvm_2.Base_de_datos
{
	public class ProveedorDbContext : DbContext
	{
		public DbSet<Proveedor> Proveedores { get; set; }

		public void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlite("Data Source=proveedores.db");
		}
	}
}
