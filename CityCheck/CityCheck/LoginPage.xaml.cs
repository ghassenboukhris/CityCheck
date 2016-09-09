using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace CityCheck
{
    public partial class LoginPage : ContentPage
    {
        private Uri uri;
        private HttpClient client;

        public LoginPage()
        {
            InitializeComponent();
            SizeChanged += OnSizeChanged;

        }
        void OnSizeChanged(object sender, EventArgs e)
        {
            if (Height > Width)
            {
                logoportrait.Source = ImageSource.FromFile("xhdpi/logoxx.png");
                logolandscape.Source = ImageSource.FromFile("");
                cityportrait.Source = ImageSource.FromFile("xhdpi/batiment.png");
                // citylandscape.Source = ImageSource.FromFile("");
                backgroundportrait.Source = ImageSource.FromFile("xhdpi/backgroundx.png");
                // backgroundlandscape.Source = ImageSource.FromFile("");
                facebookportrait.Source = ImageSource.FromFile("xhdpi/fbxh.png");
                facebooklandscape.Source = ImageSource.FromFile("");
                googleportrait.Source = ImageSource.FromFile("xhdpi/googlexh.png");
                googlelandscape.Source = ImageSource.FromFile("");
                loginportrait.Source = ImageSource.FromFile("xhdpi/logxhx.png");
                loginlandscape.Source = ImageSource.FromFile("");
                Orportrait.Text = "OR";
                Orlandscape.Text = "";
            }

            else
            {
                logolandscape.Source = ImageSource.FromFile("xhdpi/logoxx.png");
                logoportrait.Source = ImageSource.FromFile("");
                // citylandscape.Source = ImageSource.FromFile("xhdpi/cityx.png");
                cityportrait.Source = ImageSource.FromFile("");
                //  backgroundlandscape.Source = ImageSource.FromFile("xhdpi/backgroundlandscape.png");
                backgroundportrait.Source = ImageSource.FromFile("");
                facebooklandscape.Source = ImageSource.FromFile("xhdpi/fbxh.png");
                facebookportrait.Source = ImageSource.FromFile("");
                googlelandscape.Source = ImageSource.FromFile("xhdpi/googlexh.png");
                googleportrait.Source = ImageSource.FromFile("");
                loginlandscape.Source = ImageSource.FromFile("xhdpi/logxhx.png");
                loginportrait.Source = ImageSource.FromFile("");
                Orlandscape.Text = "OR";
                Orportrait.Text = "";


            }

        }
        private void Signup(Object sender, EventArgs e)
        {
            App.Current.MainPage = new Signup();

        }


        private async void Login(Object sender, EventArgs e)
        {


            client = new HttpClient();
            uri = new Uri("http://app.swclients.ch/ghassen/apli.php");

            var response = await client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                List<User> users = JsonConvert.DeserializeObject<List<User>>(content);
                foreach (User u in users)

                {

                     if (Username.Text == u.Name1 && Password.Text == u.Name2)
                      {
                         App.Current.MainPage = new CameraPage();
                     }
                      else
                     {

                    }
                }

            }
        }
        private void Loginwithgoogle(Object sender, EventArgs e)
        {
            App.Current.Properties["clientId"] = "514647833664-941m0r5vq4r6fq5skeelgqp3lqeis7cl.apps.googleusercontent.com";

            // Address that we'll go to in the browser so the user can enter thier twitter credentials.
            // App.Current.Properties["authorizeUrl"] = ""https://accounts.google.com/o/oauth2/auth";
            App.Current.Properties["authorizeUrl"] = "https://accounts.google.com/o/oauth2/auth";

            //App.Current.Properties["redirectUrl"] = "http://www.facebook.com";


            App.Current.Properties["clientSecret"] = "Mnx_oeh_WeFYr7Tgq-BRCQDM";
            App.Current.Properties["accessTokenUrl"] = "https://api.google.com/oauth/request_token";
            
        

        }

        private void facebook(Object sender, EventArgs e)
        {

       
        }
        private void google(Object sender, EventArgs e)
        {
           
        }


        private void GetRequestStreamCallback(IAsyncResult asynchronousResult)
        {
            WebRequest request = (WebRequest)asynchronousResult.AsyncState;

            // End the operation
            Stream postStream = request.EndGetRequestStream(asynchronousResult);


              string postData = "var1=" + Username.Text + "&var2=" + Password.Text + "&var3=ess&var4=ahmed";

            //Convert the string into a byte array.
              byte[] byteArray = Encoding.UTF8.GetBytes(postData);

            // Write to the request stream.
               postStream.Write(byteArray, 0, postData.Length);


            // Start the asynchronous operation to get the response
            request.BeginGetResponse(new AsyncCallback(GetResponseCallback), request);
        }


        private static void GetResponseCallback(IAsyncResult asynchronousResult)
        {
            HttpWebRequest request = (HttpWebRequest)asynchronousResult.AsyncState;

            // End the operation
            HttpWebResponse response = (HttpWebResponse)request.EndGetResponse(asynchronousResult);
            Stream streamResponse = response.GetResponseStream();
            StreamReader streamRead = new StreamReader(streamResponse);
            string responseString = streamRead.ReadToEnd();


        }

    }
}
