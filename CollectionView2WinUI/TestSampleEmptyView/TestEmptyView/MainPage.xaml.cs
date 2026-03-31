using System.Collections.ObjectModel;

namespace TestEmptyView;

public partial class MainPage : ContentPage
{
	public ObservableCollection<string> Items { get; set; } = new();

	public MainPage()
	{
		InitializeComponent();
		BindingContext = this;
		// Uncomment below to add sample items and see the CollectionView populated
		// Items.Add("Item 1");
		// Items.Add("Item 2");
	}
}
