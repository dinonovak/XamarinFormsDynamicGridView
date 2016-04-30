<Grid xmlns="http://xamarin.com/schemas/2014/forms"
	xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
	x:Class="Mobile.Controls.GridView">
</Grid>

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TEST_Springboard.Extensions;
using Xamarin.Forms;
using XLabs.Exceptions;
using XLabs.Forms.Controls;

namespace TEST_Springboard
{
	public class GridView : Grid
	{
		public static readonly BindableProperty CommandParameterProperty = BindableProperty.Create<GridView, object>(p => p.CommandParameter, null);
		public static readonly BindableProperty CommandProperty = BindableProperty.Create<GridView, ICommand>(p => p.Command, null);
		public static readonly BindableProperty ItemTemplateProperty = BindableProperty.Create<GridView, DataTemplate>(p => p.ItemTemplate, default(DataTemplate));
		public static readonly BindableProperty ItemsSourceProperty = BindableProperty.Create<GridView, IEnumerable>(p => p.ItemsSource, null);

		private int _maxColumns = 2;
		private float _tileHeight = 100;

		public GridView()
		{
			for (var i = 0; i < MaxColumns; i++)
			{
				ColumnDefinitions.Add(new ColumnDefinition());
			}
		}

		public DataTemplate ItemTemplate
		{
			get { return (DataTemplate)GetValue(ItemTemplateProperty); }
			set { SetValue(ItemTemplateProperty, value); }
		}

		public IEnumerable ItemsSource
		{
			get { return (IEnumerable)GetValue(ItemsSourceProperty); }
			set { SetValue(ItemsSourceProperty, value); }
		}

		public int MaxColumns
		{
			get { return _maxColumns; }
			set { _maxColumns = value; }
		}

		public float TileHeight
		{
			get { return _tileHeight; }
			set { _tileHeight = value; }
		}

		public object CommandParameter
		{
			get { return GetValue(CommandParameterProperty); }
			set { SetValue(CommandParameterProperty, value); }
		}

		public ICommand Command
		{
			get { return (ICommand)GetValue(CommandProperty); }
			set { SetValue(CommandProperty, value); }
		}

		public async Task BuildTiles(IEnumerable tiles)
		{
			// Wipe out the previous row definitions if they're there.
			if (RowDefinitions.Any())
			{
				RowDefinitions.Clear();
			}
			var enumerable = tiles as IList ?? tiles.Cast<object>().ToArray(); ;
			var numberOfRows = Math.Ceiling(enumerable.Count / (float)MaxColumns);
			for (var i = 0; i < numberOfRows; i++)
			{
				RowDefinitions.Add(new RowDefinition { Height = TileHeight });
			}

			for (var index = 0; index < enumerable.Count; index++)
			{
				var column = index % MaxColumns;
				var row = (int)Math.Floor(index / (float)MaxColumns);

				var tile = await BuildTile(enumerable[index]);

				Children.Add(tile, column, row);
			}
		}

		public async Task BuildTiles()
		{
			await BuildTiles(ItemsSource);
		}

		private async Task<Xamarin.Forms.View> BuildTile(object item)
		{
			return await Task.Run(() =>
				{
					var content = ItemTemplate?.CreateContent();

					if (!(content is Xamarin.Forms.View) && !(content is ViewCell)) throw new InvalidVisualObjectException(content.GetType());
					var buildTile = (content is Xamarin.Forms.View) ? content as Xamarin.Forms.View : ((ViewCell)content).View;
					buildTile.BindingContext = item;
					var tapGestureRecognizer = new TapGestureRecognizer
					{
						Command = Command,
						CommandParameter = item
					};

					buildTile.GestureRecognizers.Add(tapGestureRecognizer);
					return buildTile;
				});
		}
	}
}