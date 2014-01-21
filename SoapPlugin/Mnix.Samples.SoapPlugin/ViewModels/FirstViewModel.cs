using System.Threading.Tasks;
using Cirrious.MvvmCross.ViewModels;
using Mnix.Plugins.Soap;

namespace Mnix.Samples.SoapPlugin.ViewModels
{
    public class FirstViewModel 
		: MvxViewModel
    {
        private readonly ISoapClient mClient;

		private string _hello = "Hello MvvmCross";
        public string Hello
		{ 
			get { return _hello; }
			set { _hello = value; RaisePropertyChanged(() => Hello); }
		}

        private Cirrious.MvvmCross.ViewModels.MvxCommand mInvokeCommand;
        public System.Windows.Input.ICommand InvokeCommand
        {
            get { return mInvokeCommand = mInvokeCommand ?? new MvxAsyncCommand(DoInvoke); }
        }

        public FirstViewModel(ISoapClient client)
        {
            mClient = client;
        }

        private async Task DoInvoke()
        {
            string greeting = await mClient.HelloWorldAsync("Rafael");
            Hello = greeting;
        }
    }
}
