using Cirrious.CrossCore;
using Cirrious.MvvmCross.ViewModels;
using System;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Mnix.RestSample.ViewModels
{
    public class FirstViewModel 
		: MvxViewModel
    {
        [ServiceStack.ServiceHost.Route("/{username}", Verbs="GET")]
        public class ProfileRequest : ServiceStack.ServiceHost.IReturn<Profile>
        {
            //[DataMember]
            public string username { get; set; }
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
        

        private IMvxCommand mSearchCommand;
        public ICommand SearchCommand
        {
            get
            {
                return mSearchCommand = mSearchCommand ?? new MvxCommand(Query);
            }
        }

        public FirstViewModel(ServiceStack.Service.IServiceClient restClient)
        {
            mServiceClient = restClient;
        }

        private void Query()
        {
            try
            {
                mServiceClient.GetAsync(new ProfileRequest { username = Username },
                    (profile) => Data = profile.ToString(),
                    (profile, exception) => Data = exception.Message);
            }
            catch (Exception exc)
            {
                Data = exc.Message;
            }
        }
        
    }
}
