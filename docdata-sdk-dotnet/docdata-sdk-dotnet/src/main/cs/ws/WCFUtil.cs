using System;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Security;
using System.ServiceModel.Security.Tokens;

namespace docdata_sdk_dotnet
{
    /// <summary>
    /// WCFUtil.
    /// 
    /// Utility class used by the WCF clients.
    /// </summary>
    public class WCFUtil
    {

        /// <summary>
        /// Certificate validation callback to accepts any SSL certificate.
        /// </summary>
        public static bool AnyCertificateValidationCallback(Object sender,
            X509Certificate certificate,
            X509Chain chain,
            SslPolicyErrors sslPolicyErrors)
        {
            Console.WriteLine("Certificate Validation Callback");
            return true;
        }

        /// <summary>
        /// BasicHttpBinding with SSL Transport Security. Provides NO message integrity.
        /// </summary>
        /// <returns></returns>
        public static BasicHttpBinding BasicHttpOverSSLBinding()
        {
            BasicHttpBinding binding = new BasicHttpBinding(BasicHttpSecurityMode.Transport);
            BasicHttpSecurity security = binding.Security;

            BasicHttpMessageSecurity messageSecurity = security.Message;
            messageSecurity.ClientCredentialType = BasicHttpMessageCredentialType.UserName;
            messageSecurity.AlgorithmSuite = SecurityAlgorithmSuite.Default;

            HttpTransportSecurity transportSecurity = security.Transport;
            transportSecurity.ClientCredentialType = HttpClientCredentialType.None;
            transportSecurity.ProxyCredentialType = HttpProxyCredentialType.None;
            transportSecurity.Realm = "";
            return binding;
        }
    }
}
