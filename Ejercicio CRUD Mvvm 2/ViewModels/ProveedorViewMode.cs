using Ejercicio_CRUD_Mvvm_2.Models;
using System.Windows.Input;
using Ejercicio_CRUD_Mvvm_2.View;
using System.Data.Entity;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Segment.Model;
using Microsoft.Maui.ApplicationModel.Communication;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Ejercicio_CRUD_Mvvm_2.Base_de_datos;

namespace Ejercicio_CRUD_Mvvm_2.ViewModel
{
	public class ProveedorViewModel : ObservableObject
	{
		private readonly ProveedorDbContext _dbContext;
		private ObservableCollection<Proveedor> _proveedores;

		public ProveedorViewModel(ProveedorDbContext dbContext)
		{
			_dbContext = dbContext;
			_proveedores = new ObservableCollection<Proveedor>(_dbContext.Proveedores.ToList());
		}

		public ObservableCollection<Proveedor> Proveedores
		{
			get { return _proveedores; }
			set { SetProperty(ref _proveedores, value); }
		}

		private string _nombre;
		public string Nombre
		{
			get { return _nombre; }
			set { SetProperty(ref _nombre, value); }
		}

		private string _apellido;
		public string Apellido
		{
			get { return _apellido; }
			set { SetProperty(ref _apellido, value); }
		}

		private string _email;
		public string Email
		{
			get { return _email; }
			set { SetProperty(ref _email, value); }
		}

		private string _telefono;
		public string Telefono
		{
			get { return _telefono; }
			set { SetProperty(ref _telefono, value); }
		}

		public ICommand AgregarCommand => new RelayCommand(AgregarProveedor);
		public ICommand EditarCommand => new RelayCommand<Proveedor>(EditarProveedor);

		private void AgregarProveedor()
		{
			if (string.IsNullOrWhiteSpace(Nombre) || string.IsNullOrWhiteSpace(Apellido) || string.IsNullOrWhiteSpace(Email) || string.IsNullOrWhiteSpace(Telefono))
			{
				// Mostrar mensaje de error
				return;
			}

			var proveedor = new Proveedor { Nombre = Nombre, Apellido = Apellido, Email = Email, Telefono = Telefono };
			_dbContext.Proveedores.Add(proveedor);
			_dbContext.SaveChanges();
			Proveedores.Add(proveedor);
		}

		private void EditarProveedor(Proveedor proveedor)
		{
			if (proveedor == null) return;

			if (string.IsNullOrWhiteSpace(Nombre) || string.IsNullOrWhiteSpace(Apellido) || string.IsNullOrWhiteSpace(Email) || string.IsNullOrWhiteSpace(Telefono))
			{
				// Mostrar mensaje de error
				return;
			}
		}
	}
}
