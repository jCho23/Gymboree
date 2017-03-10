using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;
using System.Threading;

namespace Gymboree
{
	[TestFixture(Platform.Android)]
	[TestFixture(Platform.iOS)]
	public class Tests
	{
		IApp app;
		Platform platform;

		public Tests(Platform platform)
		{
			this.platform = platform;
		}

		[SetUp]
		public void BeforeEachTest()
		{
			app = AppInitializer.StartApp(platform);
			app.Screenshot("App Launched");
		}



		[Test]
		public void FirstTest()
		{
			Thread.Sleep(8000);
			app.WaitForElement(x => x.Css("#search"), timeout: TimeSpan.FromSeconds(80));
			app.Tap(x => x.Css("#search"));
			Thread.Sleep(8000);
			app.Screenshot("Tapped on Search Text Field");

			Thread.Sleep(8000);
			app.EnterText("Microsoft");
			Thread.Sleep(8000);
			app.Screenshot("Typed in my Search, 'Microsoft'");

			app.DismissKeyboard();
			app.Screenshot("Dismissed Keyboard");

			Thread.Sleep(8000);
			app.Tap(x => x.Css(".icon-search"));
			Thread.Sleep(8000);
			app.Screenshot("Tapped on Seach Button");

			Thread.Sleep(8000);
			app.Tap(x => x.Css("#search"));
			Thread.Sleep(8000);
			app.Screenshot("Tapped on Search Text Field");

			Thread.Sleep(8000);
			app.EnterText("pants");
			Thread.Sleep(8000);
			app.Screenshot("Typed in my Search, 'pants'");

			Thread.Sleep(8000);
			app.Tap(x => x.Css(".icon-search"));
			Thread.Sleep(8000);
			app.Screenshot("Tapped on Seach Button");

			Thread.Sleep(8000);
			app.ScrollDown();
			app.Screenshot("Scrolling down for more information");

			Thread.Sleep(8000);
			app.Tap(x => x.Css(".sli_grid_image"));
			Thread.Sleep(8000);
			app.Screenshot("Tapped on my pant selection");

			Thread.Sleep(4000);
			app.Tap(x => x.Css(".icon-shop"));
			Thread.Sleep(8000);
			app.Screenshot("Tapped on Hamburger Menu Button");

			Thread.Sleep(8000);
			app.Tap(x => x.Css("#gbl-kid-girl"));
			Thread.Sleep(8000);
			app.Screenshot("Tapped on the catagory, 'Girl");

			Thread.Sleep(8000);
			app.ScrollDown();
			Thread.Sleep(8000);
			app.Screenshot("Scrolling down for more information");

		}




	}
}
