/**********************************************************************
 * Author: ThongNT
 * DateCreate: 06-25-2014 
 * Description: Quan ly thong tin cau hinh chung cho project  
 * ####################################################################
 * Author:......................
 * DateModify: .................
 * Description: ................
 * 
 *********************************************************************/

using System;
using System.Configuration;

namespace MyConfig
{
    public class DefaultElement : ConfigurationElement
    {
        [ConfigurationProperty("PageSize", DefaultValue = 30)]
        public int PageSize
        {
            get { return (int)this["PageSize"]; }
        }

        [ConfigurationProperty("IsTourDebug", DefaultValue = false)]
        public bool IsTourDebug
        {
            get { return (bool)this["IsTourDebug"]; }
        }

        [ConfigurationProperty("DefaultLanguage", DefaultValue = "vn")]
        public string DefaultLanguage
        {
            get { return (string)this["DefaultLanguage"]; }
        }

        [ConfigurationProperty("DefaultCulture", DefaultValue = "vn-vi")]
        public string DefaultCulture
        {
            get { return (string)this["DefaultCulture"]; }
        }

        /// <summary>
        /// Author: ThongNT
        /// <para>Key dung de ma hoa va giai ma UserId</para>
        /// </summary>
        [ConfigurationProperty("UserEnDecryptKey", DefaultValue = "key@sdh844ach")]
        public string UserEnDecryptKey
        {
            get { return (string)this["UserEnDecryptKey"]; }
        }

        /// <summary>
        /// Author: ThongNT
        /// <para>Type Id cua admin: 55</para>
        /// </summary>
        [ConfigurationProperty("UserAdminTypeId", DefaultValue = 55)]
        public int UserAdminTypeId
        {
            get { return (int)this["UserAdminTypeId"]; }
        }

        /// <summary>
        /// Author: ThongNT
        /// <para>Ten viet ngan domain default: hoiquan52.com</para>
        /// </summary>
        [ConfigurationProperty("ShortHostName", DefaultValue = "localhost:4522")]
        public string ShortHostName
        {
            get { return (string)this["ShortHostName"]; }
        }

        /// <summary>
        /// Author: ThongNT
        /// <para>Ten domain default: http://hoiquan52.com</para>
        /// </summary>
        [ConfigurationProperty("HostName", DefaultValue = "http://hoiquan52.com")]
        public string HostName
        {
            get { return (string)this["HostName"]; }
        }

        /// <summary>
        /// Author: ThongNT
        /// <para>Facebook AppId su cho dang nhap bang facebook</para>
        /// </summary>
        [ConfigurationProperty("FacebookAppId", DefaultValue = "477643052370478")]
        public string FacebookAppId
        {
            get { return (string)this["FacebookAppId"]; }
        }

        /// <summary>
        /// Author: ThongNT
        /// <para>Facebook Secrect key use for login by facebook</para>
        /// </summary>
        [ConfigurationProperty("FacebookSecrectKey", DefaultValue = "b821470207ec00bfb4d316ebfe66eed5")]
        public string FacebookSecrectKey
        {
            get { return (string)this["FacebookSecrectKey"]; }
        }

        /// <summary>
        /// Author: ThongNT
        /// <para>Ten fanpage tren facebook</para>
        /// </summary>
        [ConfigurationProperty("FacebookFanPage", DefaultValue = "danhbaivn")]
        public string FacebookFanPage
        {
            get { return (string)this["FacebookFanPage"]; }
        }

        /// <summary>
        /// Author: ThongNT
        /// <para>Google client id dung de login google</para>
        /// </summary>
        [ConfigurationProperty("GoogleClientId", DefaultValue = "729883332587-5k8pjito5rcc8tp6osrdpq4u3a6car35.apps.googleusercontent.com")]
        public string GoogleClientId
        {
            get { return (string)this["GoogleClientId"]; }
        }

        /// <summary>
        /// Author: ThongNT
        /// <para>Link return sau khi dang nhap thanh cong google</para>
        /// </summary>
        [ConfigurationProperty("GoogleReturnUri", DefaultValue = "http://hoiquan52.com/login/google")]
        public string GoogleReturnUri
        {
            get { return (string)this["GoogleReturnUri"]; }
        }

        /// <summary>
        /// Author: ThongNT
        /// <para>Domain chua hinh cua user</para> 
        /// </summary>
        [ConfigurationProperty("ImageHost", DefaultValue = "http://123.30.128.159:8005/")]
        public string ImageHost
        {
            get { return (string)this["ImageHost"]; }
        }

        /// <summary>
        /// Author: ThongNT
        /// <para>Service upload image</para>
        /// </summary>
        [ConfigurationProperty("ImageServiceUpload", DefaultValue = "http://123.30.128.159:8005/UploadFileService.asmx")]
        public string ImageServiceUpload
        {
            get { return (string)this["ImageServiceUpload"]; }
        }

        /// <summary>
        /// Author: TrungTT
        /// <para>Qui dinh so record tren 1 trang</para>
        /// </summary>
        [ConfigurationProperty("PageSizeFriendPage", DefaultValue = 5)]
        public int PageSizeFriendPage
        {
            get { return (int)this["PageSizeFriendPage"]; }
        }

        /// <summary>
        /// Author: TrungTT
        /// <para>Do dai toi da cua nick de cat</para>
        /// </summary>
        [ConfigurationProperty("MaxLengthNick", DefaultValue = 13)]
        public int MaxLengthNick
        {
            get { return (int)this["MaxLengthNick"]; }
        }

        /// <summary>
        /// Author: TrungTT
        /// <para>Do dai cua ma bao mat tai khoan</para>
        /// </summary>
        [ConfigurationProperty("SecurityLength", DefaultValue = 6)]
        public int SecurityLength
        {
            get { return (int) this["SecurityLength"]; }
        }

        /// <summary>
        /// Author: ThongNT
        /// <para>Live Support Website</para>
        /// </summary>
        [ConfigurationProperty("LiveSupportSite", DefaultValue = "http://livesupport.hoiquan52.com")]
        public string LiveSupportSite
        {
            get { return (string)this["LiveSupportSite"]; }
        }

        /// <summary>
        /// Author: ThongNT
        /// <para>Link cau hoi thuong gap</para>
        /// </summary>
        [ConfigurationProperty("Faq", DefaultValue = "/faq/huong-dan-choi-game")]
        public string Faq
        {
            get { return (string)this["Faq"]; }
        }

        /// <summary>
        /// Author: ThongNT
        /// <para>Link cau hoi thuong gap</para>
        /// </summary>
        [ConfigurationProperty("HotLine", DefaultValue = "0909 889 889")]
        public string HotLine
        {
            get { return (string)this["HotLine"]; }
        }

        [ConfigurationProperty("rootReturnUrl", DefaultValue = "/redirect")]
        public string RootReturnUrl
        {
            get { return (string)this["rootReturnUrl"]; }
        }

        /// <summary>
        /// Author: TrungTT
        /// <para>So sao doi the cao menh gia 10k</para>
        /// </summary>
        [ConfigurationProperty("ChangeStarMenhGia10", DefaultValue = 12500.0)]
        public double ChangeStarMenhGia10
        {
            get { return (double)this["ChangeStarMenhGia10"]; }
        }

        /// <summary>
        /// Author: TrungTT
        /// <para>So sao doi the cao menh gia 20k</para>
        /// </summary>
        [ConfigurationProperty("ChangeStarMenhGia20", DefaultValue = 25000.0)]
        public double ChangeStarMenhGia20
        {
            get { return (double)this["ChangeStarMenhGia20"]; }
        }

        /// <summary>
        /// Author: TrungTT
        /// <para>So sao doi the cao menh gia 50k</para>
        /// </summary>
        [ConfigurationProperty("ChangeStarMenhGia50", DefaultValue = 62500.0)]
        public double ChangeStarMenhGia50
        {
            get { return (double)this["ChangeStarMenhGia50"]; }
        }

        /// <summary>
        /// Author: TrungTT
        /// <para>So sao doi the cao menh gia 100k</para>
        /// </summary>
        [ConfigurationProperty("ChangeStarMenhGia100", DefaultValue = 125000.0)]
        public double ChangeStarMenhGia100
        {
            get { return (double)this["ChangeStarMenhGia100"]; }
        }
        
        /// <summary>
        /// Author: TrungTT
        /// <para>So sao doi the cao menh gia 200k</para>
        /// </summary>
        [ConfigurationProperty("ChangeStarMenhGia200", DefaultValue = 250000.0)]
        public double ChangeStarMenhGia200
        {
            get { return (double)this["ChangeStarMenhGia200"]; }
        }

        /// <summary>
        /// Author: TrungTT
        /// <para>So sao doi the cao menh gia 500k</para>
        /// </summary>
        [ConfigurationProperty("ChangeStarMenhGia500", DefaultValue = 625000.0)]
        public double ChangeStarMenhGia500
        {
            get { return (double)this["ChangeStarMenhGia500"]; }
        }

        /// <summary>
        /// Author: TrungTT
        /// <para>User đang hoạt động trên web hay mobile</para>
        /// </summary>
        [ConfigurationProperty("IsMobile", DefaultValue = false)]
        public bool IsMobile
        {
            get { return (bool)this["IsMobile"]; }
        }

        /// <summary>
        /// Author: TrungTT
        /// <para>
        /// User dang login o dau
        /// 1 : Web
        /// 2 : Mobi
        /// 3 => Facebook
        /// </para>
        /// </summary>
        [ConfigurationProperty("LoginType", DefaultValue = 1)]
        public int LoginType
        {
            get { return (int)this["LoginType"]; }
        }

        /// <summary>
        /// Author: TrungTT
        /// Ti le qui doi Gold
        /// </summary>
        [ConfigurationProperty("ExchangeRate", DefaultValue = 1.00)]
        public double ExchangeRate
        {
            get { return (double)this["ExchangeRate"]; }
        }

        /// <summary>
        /// Author: TrungTT
        /// UserId mac dinh cua admin
        /// </summary>
        [ConfigurationProperty("UserAdmin", DefaultValue = 11334)]
        public int UserAdmin
        {
            get { return (int) this["UserAdmin"]; }
        }

        [ConfigurationProperty("hour_begin", DefaultValue = "15")]
        public int hour_begin
        {
            get { return (int)this["hour_begin"]; }
        }


        [ConfigurationProperty("hour_end", DefaultValue = "21")]
        public int hour_end
        {
            get { return (int)this["hour_end"]; }
        }

      

    }
}
