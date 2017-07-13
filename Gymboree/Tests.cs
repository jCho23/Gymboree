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
        public void Repl()
        {
            app.Repl();
        }

		[Test]
		public void FirstTest()
		{
            //The following command will reveal the URL for this app
            //app.Query(x => x.WebView().Invoke("getUrl"))

			app.WaitForElement(x => x.Css("#search"), timeout: TimeSpan.FromSeconds(80));
			app.Tap(x => x.Css("#search"));
			app.Screenshot("Tapped on Search Text Field");

			app.EnterText("Microsoft");
			app.Screenshot("Typed in my Search, 'Microsoft'");

			app.DismissKeyboard();
			app.Screenshot("Dismissed Keyboard");

			app.Tap(x => x.Css(".icon-search"));
			app.Screenshot("Tapped on Seach Button");

			app.Tap(x => x.Css("#search"));
			app.Screenshot("Tapped on Search Text Field");

			app.EnterText("pants");
			app.Screenshot("Typed in my Search, 'pants'");

			app.Tap(x => x.Css(".icon-search"));
			app.Screenshot("Tapped on Seach Button");

			app.ScrollDown();
			app.Screenshot("Scrolling down for more information");

			app.Tap(x => x.Css(".sli_grid_image"));
			app.Screenshot("Tapped on my pant selection");

			app.Tap(x => x.Css(".icon-shop"));
			app.Screenshot("Tapped on Hamburger Menu Button");

			app.Tap(x => x.Css("#gbl-kid-girl"));
			app.Screenshot("Tapped on the catagory, 'Girl");
		}
	}
}
