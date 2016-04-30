using System;
using System.Collections.Generic;
using TEST_Springboard.Controls;

using Xamarin.Forms;

namespace TEST_Springboard
{
	public class SpringboardMain : ContentPage
	{
		public SpringboardMain ()
		{
			// List definition
			List<String> gridTileList = new List<String>();
			gridTileList.Add("First");
			gridTileList.Add("Second");
			gridTileList.Add("Third");

			//Gridview definition
			GridView GrdView=new GridView();
			GrdView.SetBinding(GridView.ItemsSourceProperty, "Test");

			StackLayout layout = new StackLayout {Padding = new Thickness (10, 30, 10, 10)};
			Label topLabel = new Label {Text = "Hello GridView Page", HorizontalOptions=LayoutOptions.Center, TextColor=Color.Blue};

			//layout.Spacing = 10;
			layout.Children.Add(topLabel);
			layout.Children.Add(GrdView);

			Content = layout;

		}
	}
}
