using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace TEST_Springboard
{
	public class App : Application
	{


		public App ()
		{
			// The root page of your application
			MainPage = new SpringboardMain();
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
			 
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}


	public class person
	{
		public Guid FeatureId { get; set; }
		public bool HasFeature { get; set; }
		public string Name { get; set; }
	}
}

