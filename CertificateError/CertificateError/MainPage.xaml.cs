using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace CertificateError
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            GetCertificateTest();

            //GetCertificateTest2();
        }

        private void GetCertificateTest()
        {
            Task.Run(async () =>
            {
                try
                {
                    var file2 = await FileSystem.OpenAppPackageFileAsync("certificado.p12");

                    using (StreamReader sr = new StreamReader(file2))
                    {
                        var bytes = sr.CurrentEncoding.GetBytes(sr.ReadToEnd());
                        var x509 = new X509Certificate2(bytes);
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
            });
        }

        private void GetCertificateTest2()
        {
            Task.Run(async () =>
            {
                try
                {
                    var file2 = await FileSystem.OpenAppPackageFileAsync("certificado.p12");

                    using (StreamReader sr = new StreamReader(file2, Encoding.ASCII, true))
                    {
                        byte[] raw = Encoding.ASCII.GetBytes(sr.ReadToEnd());
                        var x509 = new X509Certificate2(raw, string.Empty, X509KeyStorageFlags.DefaultKeySet);
                    }
                }
                catch (Exception e)
                {

                    throw e;
                }
            });
        }
    }
}
