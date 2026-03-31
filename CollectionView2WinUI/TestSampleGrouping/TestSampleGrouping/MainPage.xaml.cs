using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TestSampleGrouping;

public class Item
{
	public string? Name { get; set; }
	public string? Group { get; set; }
}

public class GroupedItemsModel : ObservableCollection<Item>
{
	public string Key { get; set; }
	public GroupedItemsModel(string key, IEnumerable<Item> items) : base(items)
	{
		Key = key;
	}
}

public partial class MainPage : ContentPage, INotifyPropertyChanged
{
	int count = 0;


	private ObservableCollection<GroupedItemsModel> _groupedItems = new();
	public ObservableCollection<GroupedItemsModel> GroupedItems
	{
		get => _groupedItems;
		set { _groupedItems = value; OnPropertyChanged(); }
	}

	public MainPage()
	{
		InitializeComponent();
		BindingContext = this;
		LoadGroupedData();
	}

	private void LoadGroupedData()
	{
		var items = new List<Item>
		{
			new Item { Name = "Apple", Group = "Fruits" },
			new Item { Name = "Banana", Group = "Fruits" },
			new Item { Name = "Carrot", Group = "Vegetables" },
			new Item { Name = "Broccoli", Group = "Vegetables" },
			new Item { Name = "Chicken", Group = "Meat" },
			new Item { Name = "Beef", Group = "Meat" }
		};

		var grouped = items
			.GroupBy(i => i.Group)
			.Select(g => new GroupedItemsModel(g.Key!, g));

		GroupedItems = new ObservableCollection<GroupedItemsModel>(grouped);
	}

	public new event PropertyChangedEventHandler? PropertyChanged;
	protected override void OnPropertyChanged([CallerMemberName] string? name = null)
	{
		base.OnPropertyChanged(name);
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
	}
}
