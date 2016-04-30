using System;
using Xamarin.Forms;
using XLabs.Exceptions;
using XLabs.Forms.Controls;
using TEST_Springboard;

namespace TEST_Springboard
{
public partial class TypeTemplate : Grid
{
	public TypeTemplate()
	{
		InitializeComponent();
	}

	public TypeTemplate(object item)
	{
		InitializeComponent();
		BindingContext = item;
	}

}
}