using System;
using KiiCorp.Cloud.Storage;

namespace XamarinKiiTutorial
{
    public class KiiUserResponse
    {
        public KiiUser user { get; set; }
        public Exception e { get; set; }

        public KiiUserResponse(KiiUser User , Exception e)
        {
            this.user = User;
            this.e= e;
        }
    }
}
