using System.Collections.ObjectModel;
using BallChamps.Model;

namespace BallChamps.View;

public partial class ProductsPage : ContentPage
{
	public ProductsPage()
	{
		InitializeComponent();

		ObservableCollection<Product> products = new ObservableCollection<Product>
		{
			new Product("Sport T-Shirt 1", "productimg1.png")
		};

	}
}