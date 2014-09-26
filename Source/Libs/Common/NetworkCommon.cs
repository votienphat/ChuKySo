using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using Common.Model;
using Newtonsoft.Json;

namespace Common
{
    public class NetworkCommon
    {
        /// <summary>
        /// Get local ip, using for winform and webform
        /// </summary>
        /// <returns></returns>
        public static string GetLocalIp()
        {
            string ip = null;

            // Resolves a host name or IP address to an IPHostEntry instance.
            // IPHostEntry - Provides a container class for Internet host address information. 
            System.Net.IPHostEntry ipHostEntry = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName());

            // IPAddress class contains the address of a computer on an IP network. 
            foreach (System.Net.IPAddress ipAddress in ipHostEntry.AddressList)
            {
                // InterNetwork indicates that an IP version 4 address is expected 
                // when a Socket connects to an endpoint
                if (ipAddress.AddressFamily.ToString() == "InterNetwork")
                {
                    ip = ipAddress.ToString();
                }
            }
            return ip;
        }

        /// <summary>
        /// Gửi email
        /// </summary>
        /// <param name="fromEmail">Địa chỉ gửi đi</param>
        /// <param name="fromName">Tên người gửi</param>
        /// <param name="fromPassword">Mật khẩu đăng nhập mail của người gửi</param>
        /// <param name="toEmail">Địa chỉ nhận mail</param>
        /// <param name="toName">Tên người nhận</param>
        /// <param name="title">Tiêu đề</param>
        /// <param name="body">Nội dung</param>
        /// <param name="host">Host của email. Gmail là "smtp.gmail.com"</param>
        /// <param name="port">Cổng. Nếu là Gmail thì là 587</param>
        /// <returns></returns>
        public static bool SentMail(string fromEmail, string fromName, string fromPassword,
                                    string toEmail, string toName, string title, string body,
                                    string host, int port)
        {
            var fromAddress = new MailAddress(fromEmail, fromName);
            var toAddress = new MailAddress(toEmail, toName);

            var smtp = new SmtpClient
                           {
                               Host = host,
                               Port = port,
                               EnableSsl = true,
                               DeliveryMethod = SmtpDeliveryMethod.Network,
                               UseDefaultCredentials = false,
                               Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
                           };

            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = title,
                Body = body
            })
            {
                smtp.Send(message);
            }
            return true;
        }

        /// <summary>
        /// Hàm gửi request dạng Get
        /// </summary>
        /// <param name="requestUrl">Địa chỉ cần gọi</param>
        /// <param name="cookieCon">Cookie</param>
        /// <param name="htmlResult">Kết quả html trả về</param>
        /// <param name="nextLocation">Địa chỉ tiếp theo, nếu có</param>
        /// <param name="allowRedirect">Cho phép tự redirect không</param>
        /// <returns></returns>
        public static bool SendGetRequest(string requestUrl, CookieContainer cookieCon, string referer, out string htmlResult
            , out string nextLocation, bool allowRedirect)
        {
            bool loadSuccess = true;
            nextLocation = string.Empty;
            string resultOutput = string.Empty;
            var webRequest = (HttpWebRequest)WebRequest.Create(requestUrl);

            webRequest.AllowAutoRedirect = false;
            webRequest.AutomaticDecompression = DecompressionMethods.GZip;
            webRequest.CookieContainer = cookieCon;

            webRequest.UserAgent = "Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/37.0.2062.120 Safari/537.36";
            webRequest.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";
            webRequest.Headers[HttpRequestHeader.AcceptLanguage] = "en-US,en;q=0.8,vi;q=0.6";
            webRequest.Headers[HttpRequestHeader.AcceptEncoding] = "gzip,deflate,sdch";
            webRequest.Headers[HttpRequestHeader.AcceptCharset] = "ISO-8859-1,utf-8;q=0.7,*;q=0.7";
            webRequest.KeepAlive = false; //Fix "The server committed a protocol violation. Section=ResponseStatusLine"
            if (!string.IsNullOrEmpty(referer.Trim()))
                webRequest.Referer = referer;
            webRequest.ContentType = "application/x-www-form-urlencoded";

            webRequest.Method = "GET";

            try
            {
                using (var response = (HttpWebResponse)webRequest.GetResponse())
                {
                    cookieCon.Add(webRequest.RequestUri, response.Cookies);
                    nextLocation = response.GetResponseHeader("Location");
                    using (var buffer = new BufferedStream(response.GetResponseStream()))
                    {
                        using (var readStream = new StreamReader(buffer, Encoding.UTF8))
                        {
                            resultOutput = readStream.ReadToEnd();
                        }
                    }
                }
            }
            catch (Exception)
            {
                loadSuccess = false;
            }
            finally
            {
                htmlResult = resultOutput;
            }
            return loadSuccess;
        }

        /// <summary>
        /// Hàm gửi request dạng Post có header
        /// </summary>
        /// <param name="requestUrl">Địa chỉ cần gọi</param>
        /// <param name="cookieCon">Cookie</param>
        /// <param name="postData">Dữ liệu post</param>
        /// <param name="referer">Địa chỉ liên quan được gọi trước đó</param>
        /// <param name="htmlResult">Kết quả html trả về</param>
        /// <param name="nextLocation">Địa chỉ tiếp theo, nếu có</param>
        /// <param name="allowRedirect">Cho phép tự redirect không</param>
        /// <param name="headers">Thông tin Header</param>
        /// <returns></returns>
        public static bool SendPostRequest(string requestUrl, CookieContainer cookieCon, string postData, string referer
            , out string htmlResult, out string nextLocation, bool allowRedirect, IEnumerable<string> headers)
        {
            bool loadSuccess = true;
            nextLocation = string.Empty;
            string resultOutput = string.Empty;
            byte[] dataByte = new ASCIIEncoding().GetBytes(postData);
            var myRequest = (HttpWebRequest)WebRequest.Create(requestUrl);
            myRequest.Method = "POST";
            myRequest.KeepAlive = true;
            myRequest.AllowAutoRedirect = allowRedirect;
            myRequest.Headers.Add("Accept-Charset:ISO-8859-1,utf-8;q=0.7,*;q=0.7");
            myRequest.Headers.Add("Keep-Alive:15");

            if (headers != null)
            {
                foreach (var header in headers)
                {
                    myRequest.Headers.Add(header);
                }
            }

            myRequest.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
            myRequest.ContentType = "application/json";
            if (!string.IsNullOrEmpty(referer.Trim()))
            {
                myRequest.Referer = referer;
            }
            myRequest.UserAgent = "Mozilla/5.0 (Windows NT 6.1; rv:2.0) Gecko/20100101 Firefox/4.0";
            myRequest.ContentLength = postData.Length;
            myRequest.Proxy = null;
            myRequest.CookieContainer = cookieCon;
            try
            {
                Stream postStream = myRequest.GetRequestStream();
                postStream.Write(dataByte, 0, dataByte.Length);
                postStream.Flush();
                postStream.Close();
                using (var response = (HttpWebResponse)myRequest.GetResponse())
                {
                    cookieCon.Add(myRequest.RequestUri, response.Cookies);
                    nextLocation = response.GetResponseHeader("Location");
                    htmlResult = string.Empty;
                    using (var buffer = new BufferedStream(response.GetResponseStream()))
                    {
                        using (var readStream = new StreamReader(buffer, Encoding.UTF8))
                        {
                            resultOutput = readStream.ReadToEnd();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                loadSuccess = false;
                resultOutput = ex.Message;
            }
            finally
            {
                htmlResult = resultOutput;
            }
            return loadSuccess;
        }

        /// <summary>
        /// Hàm gửi request dạng Post
        /// </summary>
        /// <param name="requestUrl">Địa chỉ cần gọi</param>
        /// <param name="cookieCon">Cookie</param>
        /// <param name="postData">Dữ liệu post</param>
        /// <param name="referer">Địa chỉ liên quan được gọi trước đó</param>
        /// <param name="htmlResult">Kết quả html trả về</param>
        /// <param name="nextLocation">Địa chỉ tiếp theo, nếu có</param>
        /// <param name="allowRedirect">Cho phép tự redirect không</param>
        /// <returns></returns>
        public static bool SendPostRequest(string requestUrl, CookieContainer cookieCon, string postData, string referer
            , out string htmlResult, out string nextLocation, bool allowRedirect)
        {
            bool loadSuccess = true;
            nextLocation = string.Empty;
            string resultOutput = string.Empty;
            byte[] dataByte = new ASCIIEncoding().GetBytes(postData);
            var myRequest = (HttpWebRequest)WebRequest.Create(requestUrl);
            myRequest.Method = "POST";
            myRequest.KeepAlive = true;
            myRequest.AllowAutoRedirect = allowRedirect;
            myRequest.Headers.Add("Accept-Charset:ISO-8859-1,utf-8;q=0.7,*;q=0.7");
            myRequest.Headers.Add("Keep-Alive:15");
            myRequest.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
            myRequest.ContentType = "application/x-www-form-urlencoded";
            if (!string.IsNullOrEmpty(referer.Trim()))
            {
                myRequest.Referer = referer;
            }
            myRequest.UserAgent = "Mozilla/5.0 (Windows NT 6.1; rv:2.0) Gecko/20100101 Firefox/4.0";
            myRequest.ContentLength = postData.Length;
            myRequest.Proxy = null;
            myRequest.CookieContainer = cookieCon;
            try
            {
                Stream postStream = myRequest.GetRequestStream();
                postStream.Write(dataByte, 0, dataByte.Length);
                postStream.Flush();
                postStream.Close();
                using (var response = (HttpWebResponse)myRequest.GetResponse())
                {
                    cookieCon.Add(myRequest.RequestUri, response.Cookies);
                    nextLocation = response.GetResponseHeader("Location");
                    htmlResult = string.Empty;
                    using (var buffer = new BufferedStream(response.GetResponseStream()))
                    {
                        using (var readStream = new StreamReader(buffer, Encoding.UTF8))
                        {
                            resultOutput = readStream.ReadToEnd();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                loadSuccess = false;
            }
            finally
            {
                htmlResult = resultOutput;
            }
            return loadSuccess;
        }

        /// <summary>
        /// Gửi message đến Google Cloud Message
        /// </summary>
        /// <param name="regIds">Danh sách Id cần giử</param>
        /// <param name="data">Nội dung cần gửi</param>
        /// <param name="header">Chuỗi Authorize của GCM</param>
        /// <returns></returns>
        public static GCMResponse SendGCM(List<string> regIds, object data, string header)
        {
            string html, next;
            var request = new GCMRequest
            {
                registration_ids = regIds,
                data = data,
                dry_run = false,
                time_to_live = 108, //Nếu delay_while_idle = true (chỉ hơn 200)
                delay_while_idle = false //Nếu offline thì không gửi
            };
            var isSend = SendPostRequest("https://android.googleapis.com/gcm/send", new CookieContainer(),
                                           JsonConvert.SerializeObject(request), string.Empty, out html, out next, false,
                                           new List<string>
                                               {
                                                   "Authorization:key=" + header
                                               });

            var response = !isSend
                               ? new GCMResponse
                                     {
                                         success = 0,
                                         failure = 0,
                                         Message = html
                                     }
                               : JsonConvert.DeserializeObject<GCMResponse>(html);

            return response;
        }
    }
}
