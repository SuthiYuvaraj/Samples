using System.Collections.ObjectModel;

namespace TestSample;

public partial class MainPage : ContentPage
{
	int count = 0;

	public ObservableCollection<string> Items { get; set; } = new ObservableCollection<string>
	{
		"Item 1",
		"Item 2",
		"Item 3",
		"Item 4",
		"Item 5"
	};

	public MainPage()
	{
		InitializeComponent();
		BindingContext = this;
	}


	private void OnToggleSelectionModeClicked(object? sender, EventArgs e)
	{
		if (MyCollectionView.SelectionMode == SelectionMode.Single)
		{
			MyCollectionView.SelectionMode = SelectionMode.Multiple;
			ToggleSelectionModeBtn.Text = "Switch to Single Selection";
		}
		else
		{
			MyCollectionView.SelectionMode = SelectionMode.Single;
			ToggleSelectionModeBtn.Text = "Switch to Multiple Selection";
		}
	}
}
