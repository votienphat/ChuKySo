using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Common
{
    public static class StringCommon
    {
        #region Extension

        /// <summary>
        /// Returns the last few characters of the string with a length
        /// specified by the given parameter. If the string's length is less than the 
        /// given length the complete string is returned. If length is zero or 
        /// less an empty string is returned
        /// </summary>
        /// <param name="text"> </param>
        /// <param name="length">Number of characters to return</param>
        /// <returns></returns>
        public static string Right(this string text, int length)
        {
            string strResult = text;
            length = Math.Max(length, 0);

            if (text.Length > length)
            {
                strResult = text.Substring(text.Length - length, length);
            }
            return strResult;
        }

        /// <summary>
        /// Returns the first few characters of the string with a length
        /// specified by the given parameter. If the string's length is less than the 
        /// given length the complete string is returned. If length is zero or 
        /// less an empty string is returned
        /// </summary>
        /// <param name="text"> </param>
        /// <param name="length">Number of characters to return</param>
        /// <returns></returns>
        public static string Left(this string text, int length)
        {
            string strResult = text;
            length = Math.Max(length, 0);

            if (text.Length > length)
            {
                strResult = text.Substring(0, length);
            }
            return strResult;
        }

        /// <summary>
        /// Nếu chuỗi bị null thì trả về empty
        /// </summary>
        /// <param name="text"> </param>
        /// <returns></returns>
        public static string Empty(this string text)
        {
            return string.IsNullOrEmpty(text) ? string.Empty : text;
        }

        #endregion

        #region Phone

        /// <summary>
        /// Convert phone number to phone number with region code. 
        /// Ex: 0909123456 => 84909123456
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        public static string SetPhoneRegionCode(string phone)
        {
            if (!string.IsNullOrEmpty(phone) && phone.StartsWith("0") && phone.Length < 15)
            {
                return "84" + phone.Substring(1);
            }
            return phone;
        }

        /// <summary>
        /// Convert phone numberwith region code to general phone number. 
        /// Ex: 84909123456 => 0909123456
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        public static string RemovePhoneRegionCode(string phone)
        {
            if (!string.IsNullOrEmpty(phone) && phone.StartsWith("84") && phone.Length < 15)
            {
                return "0" + phone.Substring(2);
            }
            return phone;
        }

        /// <summary>
        /// Get Telco name based on phone number
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        public static string GetTelcoName(string phone)
        {
            string telco = string.Empty;

            if (!string.IsNullOrEmpty(phone))
            {
                // Remove region code if any
                phone = RemovePhoneRegionCode(phone);

                string check = phone.Substring(0, phone[1].Equals('9') ? 3 : 4);

                switch (check)
                {
                    case "095":
                        telco = "SFONE";
                        break;
                    //------------------------------------------------------
                    case "092":
                    case "0188":
                    case "0186":
                        telco = "VNMOBI";
                        break;
                    //------------------------------------------------------
                    case "0199":
                        telco = "BEELINE";
                        break;
                    //------------------------------------------------------
                    case "090":
                    case "093":
                    case "0120":
                    case "0121":
                    case "0122":
                    case "0124":
                    case "0126":
                    case "0128":
                        telco = "VMS";
                        break;
                    //------------------------------------------------------
                    case "096": // evn cu
                    case "097":
                    case "098":
                    case "0162":
                    case "0163":
                    case "0164":
                    case "0165":
                    case "0166":
                    case "0167":
                    case "0168":
                    case "0169":
                        telco = "VIETTEL";
                        break;
                    //------------------------------------------------------
                    case "091":
                    case "094":
                    case "0123":
                    case "0125":
                    case "0127":
                    case "0129":
                        telco = "VNP";
                        break;
                }
            }

            return telco;
        }

        /// <summary>
        /// Dựa vào đầu số lấy ra số tiền của SMS
        /// </summary>
        /// <param name="service"></param>
        /// <returns></returns>
        public static int GetPriceFromService(string service)
        {
            int price = 0;

            if (service.Length > 2)
            {
                switch (service[1])
                {
                    case '0':
                        price = 500;
                        break;
                    case '1':
                        price = 1000;
                        break;
                    case '2':
                        price = 2000;
                        break;
                    case '3':
                        price = 3000;
                        break;
                    case '4':
                        price = 4000;
                        break;
                    case '5':
                        price = 5000;
                        break;
                    case '6':
                        price = 10000;
                        break;
                    case '7':
                        price = 15000;
                        break;
                }
            }

            return price;
        }

        #endregion

        /// <summary>
        /// Bỏ dấu
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string ConvertToUnsign(string s)
        {
            var regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
            string temp = s.Normalize(NormalizationForm.FormD);
            return regex.Replace(temp, String.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D').ToLower().Trim();
        }

        /// <summary>
        /// Mã hóa chuỗi từ Unicode thành ASCII
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string EncodeNonAsciiCharacters(string value)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in value)
            {
                if (c > 127)
                {
                    // This character is too big for ASCII
                    string encodedValue = "\\u" + ((int)c).ToString("x4");
                    sb.Append(encodedValue);
                }
                else
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }

        /// <summary>
        /// Giải mã từ ASCII thành Unicode
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string DecodeNonAsciiCharacters(string value)
        {
            return Regex.Replace(
                value,
                @"\\u(?<Value>[a-zA-Z0-9]{4})",
                m =>
                {
                    return ((char)int.Parse(m.Groups["Value"].Value, NumberStyles.HexNumber)).ToString();
                });
        }

        /// <summary>
        /// Cắt 1 đoạn ký tự để làm intro
        /// </summary>
        /// <param name="s"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string SplitIntro(string s, int length=20)
        {
            var regex = new Regex(@"<[^>]*>");
            s = regex.Replace(s, String.Empty);
            return s.Length < length ? s : s.Left(20) + "...";
        }

    }
}
