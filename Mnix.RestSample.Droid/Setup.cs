using Android.Content;
using Cirrious.CrossCore.Platform;
using Cirrious.CrossCore.Plugins;
using Cirrious.MvvmCross.Droid.Platform;
using Cirrious.MvvmCross.ViewModels;
using System.Threading.Tasks;

namespace Mnix.RestSample.Droid
{
    public class Setup : MvxAndroidSetup
    {
        private const string FACEBOOK_URI = "http://graph.facebook.com";

        public Setup(Context applicationContext) : base(applicationContext)
        {
        }

        protected override IMvxPluginConfiguration GetPluginConfiguration(System.Type plugin)
        {
            if (plugin == typeof(Plugins.Rest.RestPluginLoader))
            {
                return new Plugins.Rest.ServiceClientConfiguration() { BaseUri = FACEBOOK_URI };
            }
            return base.GetPluginConfiguration(plugin);
        }

        protected override IMvxApplication CreateApp()
        {
            return new App();
        }
		
        protected override IMvxTrace CreateDebugTrace()
        {
            return new DebugTrace();
        }
    }
}