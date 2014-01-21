using Android.Content;
using Cirrious.CrossCore.Platform;
using Cirrious.CrossCore.Plugins;
using Cirrious.MvvmCross.Droid.Platform;
using Cirrious.MvvmCross.ViewModels;
using Mnix.Samples.SoapPlugin.Droid.Svc;

namespace Mnix.Samples.SoapPlugin.Droid
{
    public class Setup : MvxAndroidSetup
    {
        public Setup(Context applicationContext) : base(applicationContext)
        {
        }

        protected override IMvxApplication CreateApp()
        {
            return new App();
        }

        protected override IMvxPluginConfiguration GetPluginConfiguration(System.Type plugin)
        {
            if (plugin == typeof(Mnix.Plugins.Soap.PluginLoader))
            {
                return new Mnix.Plugins.Soap.Droid.SoapClientConfiguration(new Service());
            }
            return base.GetPluginConfiguration(plugin);
        }
		
        protected override IMvxTrace CreateDebugTrace()
        {
            return new DebugTrace();
        }
    }
}