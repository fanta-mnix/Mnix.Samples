using Cirrious.CrossCore;
using Cirrious.MvvmCross.ViewModels;
using System;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using System.Windows.Input;
using Mnix.Plugins.Rest;

namespace Mnix.RestSample.ViewModels
{
    public class FirstViewModel 
		: MvxViewModel
    {
        [ServiceStack.ServiceHost.Route("/{Username}", Verbs="GET")]
        public class ProfileRequest : ServiceStack.ServiceHost.IReturn<Profile>
        {
            //[DataMember]
            public string Username { get; set; }
        }

        public class Profile
        {
            public string id { get; set; }
            public string name { get; set; }
            public string first_name { get; set; }
            public string last_name { get; set; }
            public string link { get; set; }
            public string username { get; set; }
            public string gender { get; set; }
            public string locale { get; set; }

            public override string ToString()
            {
                return string.Format("name: {0}, gender: {1}, locale: {2}", name, gender, locale);
            }
        }

        private readonly ServiceStack.Service.IServiceClient mServiceClient;

        private string mUsername;
        public string Username
        {
            get { return mUsername; }
            set { mUsername = value; RaisePropertyChanged(() => Username); }
        }

        private string mData;
        public string Data
        {
            get { return mData; }
            set { mData = value; RaisePropertyChanged(() => Data); }
        }
        

        private MvxAsyncCommand mSearchCommand;
        public ICommand SearchCommand
        {
            get
            {
                return mSearchCommand = mSearchCommand ?? new MvxAsyncCommand(Query);
            }
        }

        public FirstViewModel(ServiceStack.Service.IServiceClient restClient)
        {
            mServiceClient = restClient;
        }

        private async Task Query()
        {
            try
            {
                //mClient.get
                Profile p = await mServiceClient.GetAsync(new ProfileRequest { Username = Username });
                Data = "Hello " + p.name;
            }
            catch (System.Exception exc)
            {
                Data = "Error: " + exc.Message;
            }
        }
        
    }
}
