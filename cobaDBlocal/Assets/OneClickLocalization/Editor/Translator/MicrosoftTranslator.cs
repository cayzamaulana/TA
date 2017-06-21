using UnityEngine;
using System;
using System.Net;
using System.IO;
using System.Text;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using OneClickLocalization.Editor.Utils;

namespace OneClickLocalization.Editor.Translator
{
    public class MicrosoftTranslator
    {

        private AdmAuthentication auth;
        private string clientId;
        private string clientSecret;

        public MicrosoftTranslator(string clientId = null, string clientSecret = null)
        {
            this.clientId = clientId;
            this.clientSecret = clientSecret;
        }

        /// <summary>
        /// Translate textToTranslate using Microsoft Translator
        /// Max number of characters : 10 000.
        /// </summary>
        /// <param name="textToTranslate"></param>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public string Translate(string textToTranslate, SystemLanguage from, SystemLanguage to)
        {
            // Verify authentication
            try
            {
                if(auth == null)
                {
                    try
                    {
                        auth = new AdmAuthentication(clientId, clientSecret);
                    }
                    catch(Exception e)
                    {
                        Debug.LogError("Translate Error during authentication : " + e.Message);
                        return null;
                    }
                }

                AdmAccessToken token = auth.GetAccessToken();

                string fromCode = LanguageUtils.GetCodeFromLanguage(from);
                string toCode = LanguageUtils.GetCodeFromLanguage(to);

                string uri = "http://api.microsofttranslator.com/v2/Http.svc/Translate?text=" + WWW.EscapeURL(textToTranslate) + "&from=" + fromCode + "&to=" + toCode;
                string authToken = "Bearer" + " " + token.access_token;

                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(uri);
                httpWebRequest.Headers.Add("Authorization", authToken);

                WebResponse response = null;
                response = httpWebRequest.GetResponse();
                using (Stream stream = response.GetResponseStream())
                {
                    System.Runtime.Serialization.DataContractSerializer dcs = new System.Runtime.Serialization.DataContractSerializer(Type.GetType("System.String"));
                    string translation = (string)dcs.ReadObject(stream);

                    return translation;
                }

            }
            catch (Exception ex)
            {
                Debug.LogError("Error during translation : " + ex.Message);
            }

            return null;
        }

        public void SetCredentials(string clientId, string clientSecret)
        {
            if(this.clientId != clientId || this.clientSecret != clientSecret)
            {
                this.clientId = clientId;
                this.clientSecret = clientSecret;

                if(auth != null)
                {
                    auth.updateCredentials(clientId, clientSecret);
                }
            }
        }


        // Private classes

        [Serializable]
        public class AdmAccessToken
        {
            public string access_token;
            public string token_type;
            public string expires_in;
            public string scope;
        }

        public class AdmAuthentication
        {
            public static readonly string DatamarketAccessUri = "https://datamarket.accesscontrol.windows.net/v2/OAuth2-13";
            public string clientId;
            public string clientSecret;
            private string request;

            private AdmAccessToken token;
            private DateTime tokenCreationDate;

            //Access token expires every 10 minutes. Renew it every 9 minutes only.
            private const int RefreshTokenDuration = 9;
            public AdmAuthentication(string clientId, string clientSecret)
            {
                updateCredentials(clientId, clientSecret);
                this.token = HttpPost(DatamarketAccessUri, this.request);
            }

            public void updateCredentials(string clientId, string clientSecret)
            {
                this.clientId = clientId;
                this.clientSecret = clientSecret;

                //If clientid or client secret has special characters, encode before sending request
                request = string.Format("grant_type=client_credentials&client_id={0}&client_secret={1}&scope=http://api.microsofttranslator.com", WWW.EscapeURL(this.clientId), WWW.EscapeURL(this.clientSecret));

                // invalidate current token
                this.token = null;

            }

            public AdmAccessToken GetAccessToken()
            {
                // Token has an expire time of 10 min, renew if created for more than 9 minutes
                if (this.token == null || (DateTime.Now.Subtract(tokenCreationDate) > new TimeSpan(0, 9, 0)))
                {
                    AdmAccessToken newAccessToken = HttpPost(DatamarketAccessUri, this.request);
                    this.token = newAccessToken;
                }
                return this.token;
            }
            
            private void RenewAccessToken()
            {
                AdmAccessToken newAccessToken = HttpPost(DatamarketAccessUri, this.request);
                //swap the new token with old one
                //Note: the swap is thread unsafe
                this.token = newAccessToken;
                tokenCreationDate = DateTime.Now;
                //Debug.Log(string.Format("Renewed token for user: {0} is: {1}", this.clientId, this.token.access_token));
            }

            private AdmAccessToken HttpPost(string DatamarketAccessUri, string requestDetails)
            {
                ServicePointManager.ServerCertificateValidationCallback = MyRemoteCertificateValidationCallback;
                //Prepare OAuth request 
                WebRequest webRequest = WebRequest.Create(DatamarketAccessUri);
                webRequest.ContentType = "application/x-www-form-urlencoded";
                webRequest.Method = "POST";
                byte[] bytes = Encoding.ASCII.GetBytes(requestDetails);
                webRequest.ContentLength = bytes.Length;
                using (Stream outputStream = webRequest.GetRequestStream())
                {
                    outputStream.Write(bytes, 0, bytes.Length);
                }
                AdmAccessToken createdToken = null;
                using (WebResponse webResponse = webRequest.GetResponse())
                {
                    using (var reader = new StreamReader(webResponse.GetResponseStream()))
                    {
                        string result = reader.ReadToEnd();
                        createdToken = JsonUtility.FromJson<AdmAccessToken>(result);
                    }
                }
                return createdToken;
            }

            /// <summary>
            /// Workaround method for security error
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="certificate"></param>
            /// <param name="chain"></param>
            /// <param name="sslPolicyErrors"></param>
            /// <returns></returns>
            public bool MyRemoteCertificateValidationCallback(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
            {
                bool isOk = true;
                // If there are errors in the certificate chain, look at each error to determine the cause.
                if (sslPolicyErrors != SslPolicyErrors.None)
                {
                    for (int i = 0; i < chain.ChainStatus.Length; i++)
                    {
                        if (chain.ChainStatus[i].Status != X509ChainStatusFlags.RevocationStatusUnknown)
                        {
                            chain.ChainPolicy.RevocationFlag = X509RevocationFlag.EntireChain;
                            chain.ChainPolicy.RevocationMode = X509RevocationMode.Online;
                            chain.ChainPolicy.UrlRetrievalTimeout = new TimeSpan(0, 1, 0);
                            chain.ChainPolicy.VerificationFlags = X509VerificationFlags.AllFlags;
                            bool chainIsValid = chain.Build((X509Certificate2)certificate);
                            if (!chainIsValid)
                            {
                                isOk = false;
                            }
                        }
                    }
                }
                return isOk;
            }
        }
    }

}
