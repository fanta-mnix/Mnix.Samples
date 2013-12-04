using Cirrious.MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mnix.RestSample
{
    public class MvxAsyncCommand : MvxCommand
    {
        public MvxAsyncCommand(Func<Task> command) : base(async () => await command()) { }
    }
}
