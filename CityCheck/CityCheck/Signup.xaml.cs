using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace CityCheck
{
    public partial class Signup : ContentPage
    {
        public Signup()
        {
            InitializeComponent();
        }
        private void Signuppp(Object sender, EventArgs e)
        {

            // Create a new HttpWebRequest object.
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://app.swclients.ch/ghassen/test.php");

            request.ContentType = "application/x-www-form-urlencoded";

            // Set the Method property to 'POST' to post data to the URI.
            request.Method = "POST";

            // start the asynchronous operation
            request.BeginGetRequestStream(new AsyncCallback(GetRequestStreamCallback), request);

            // Keep the main thread from continuing while the asynchronous
            // operation completes. A real world application
            // could do something useful such as updating its user interface. 

        }
        private void GetRequestStreamCallback(IAsyncResult asynchronousResult)
        {
            WebRequest request = (WebRequest)asynchronousResult.AsyncState;

            // End the operation
            Stream postStream = request.EndGetRequestStream(asynchronousResult);


            string postData = "var1=" + Username.Text + "&var2=" + Name.Text + "&var3=" + Email.Text + "&var4=" + Password.Text;

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
