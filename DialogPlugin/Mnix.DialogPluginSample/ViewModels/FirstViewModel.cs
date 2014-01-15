using Cirrious.MvvmCross.ViewModels;
using Mnix.Plugins.Dialog;

namespace Mnix.DialogPluginSample.ViewModels
{
    public class FirstViewModel 
		: MvxViewModel
    {
        private readonly IMvxDialogTask mDialogTask;

		private string _hello = "Hello MvvmCross";
        public string Hello
		{ 
			get { return _hello; }
			set { _hello = value; RaisePropertyChanged(() => Hello); }
		}

        private Cirrious.MvvmCross.ViewModels.MvxCommand mShowDialogCommand;
        public System.Windows.Input.ICommand ShowDialogCommand
        {
            get { return mShowDialogCommand = mShowDialogCommand ?? new Cirrious.MvvmCross.ViewModels.MvxCommand(DoShowDialog); }
        }

        public FirstViewModel(IMvxDialogTask dialogTask)
        {
            mDialogTask = dialogTask;
        }

        private void DoShowDialog()
        {
            mDialogTask.Show("Titulo", "Mnesaasdas asdasd asd asas", "OKz", "Nope", null, null);
        }
    }
}
