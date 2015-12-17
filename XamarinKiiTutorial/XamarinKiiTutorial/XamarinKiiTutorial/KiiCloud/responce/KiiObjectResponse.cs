using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KiiCorp.Cloud.Storage;

namespace XamarinKiiTutorial
{
    public class KiiObjectResponse
    {
        public KiiObject obj { get; set; }
        public Exception e { get; set; }

        public KiiObjectResponse(KiiObject obj, Exception e)
        {
            this.obj = obj;
            this.e = e;
        }
    }

}
