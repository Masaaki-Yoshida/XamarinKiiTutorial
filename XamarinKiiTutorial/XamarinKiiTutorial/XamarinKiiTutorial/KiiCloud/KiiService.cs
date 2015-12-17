using System;
using System.IO;
using System.Threading.Tasks;
using KiiCorp.Cloud.Storage;

namespace XamarinKiiTutorial
{

    public static class KiiService
    {
        private const string APPID = "****";
        private const string APPKEY = "****";
        private const Kii.Site SITE = Kii.Site.JP;

        public static bool kiiInitialize()
        {
            try
            {
                Kii.Initialize(APPID, APPKEY, SITE);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static Task<KiiUserResponse> KiiUserLoginAsync(string username, string password)
        {
            var tcs = new TaskCompletionSource<KiiUserResponse>();
            KiiUser.LogIn(username, password, (KiiUser user, Exception e) =>{tcs.TrySetResult(new KiiUserResponse(user,e));});
            return tcs.Task;
        }

        public static Task<KiiUserResponse> KiiUserRegisterAsync(string username, string password)
        {
            KiiUser.Builder builder;
            builder = KiiUser.BuilderWithName(username);
            KiiUser user = builder.Build();

            var tcs = new TaskCompletionSource<KiiUserResponse>();
            user.Register(password, (KiiUser registeredUser, Exception e) => { tcs.TrySetResult(new KiiUserResponse(user, e)); });
            return tcs.Task;
        }

        public static Task<KiiObjectResponse> KiiObjectCreateAsync(KiiObject obj)
        {
            var tcs = new TaskCompletionSource<KiiObjectResponse>();
            obj.Save((KiiObject savedObj, Exception e) => { tcs.TrySetResult(new KiiObjectResponse(savedObj, e)); });
            return tcs.Task;
        }

        public static Task<KiiObjectResponse> KiiObjectBodyUploadAsync(KiiObject obj, Stream stream)
        {
            var tcs = new TaskCompletionSource<KiiObjectResponse>();
            obj.UploadBody("image/png",stream, (KiiObject uploadedObj, Exception e2) => {
                tcs.TrySetResult(new KiiObjectResponse(uploadedObj, e2));
            });
            return tcs.Task;
        }
    }
}
