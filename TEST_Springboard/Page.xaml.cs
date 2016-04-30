<Grid xmlns="http://xamarin.com/schemas/2014/forms"
	xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
	x:Class="Mobile.Controls.GridView">
	</Grid>

public Page()
{
	InitializeComponent();

	// not sure how to define this in XAML
	GrdView.ItemTemplate = typeof(TaskTileTemplate);
}

protected override async void OnAppearing()
{
	base.OnAppearing();
	await GrdView.BuildTiles(taskPageViewModel.Tasks);
}