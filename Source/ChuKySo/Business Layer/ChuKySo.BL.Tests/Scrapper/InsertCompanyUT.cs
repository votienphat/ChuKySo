using ChuKySo.BL.Business;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChuKySo.BL.Tests.Scrapper
{
    [TestClass]
    public class InsertCompanyUT
    {
        [TestMethod]
        public void InsertCompany()
        {

            #region Data

            string html = @"<!DOCTYPE html PUBLIC ""-//W3C//DTD XHTML 1.0 Transitional//EN"" ""http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd"">"
                          + @"<html xmlns=""http://www.w3.org/1999/xhtml"">"
                          + @"<head>"
                          +
                          @"<meta name=""google-site-verification"" content=""UzGRrNAvD6orfEYI4DNBLMRNGQGJ7T6FRzaY6_t95ns"" />"
                          + @"<meta name=""alexaVerifyID"" content=""umX0f8gJKNJWXh99WpEc73eLYv4"" />"
                          + @"<meta http-equiv=""Content-Type"" content=""text/html; charset=utf-8"" />"
                          + @"<meta name=""robots"" content=""INDEX,FOLLOW"" />"
                          + @"<meta name=""GOOGLEBOT"" content=""index,follow"" />"
                          +
                          @"<meta id=""ctl00_description"" name=""description"" content=""Báo Tiền Phong điện tử, Tien Phong Online, tin tức cập nhật liên tục trong ngày"" />"
                          +
                          @"<meta id=""ctl00_keywords"" name=""keywords"" content=""Tin mới, tin moi, tin tức, tin tuc, Việt Nam, Tiền Phong, Tien Phong, Tiền Phong Online, Tien Phong online, báo Tiền Phong, bao Tien Phong, Thời sự, Thoi su, Tin nóng, Tin nong,  Pháp luật, Phap luat, vụ án, vu an, điều tra, dieu tra, Thể thao, The thao, Bóng đá, Bong da, Văn hóa, Van hoa, Quốc tế, Quoc te, Thế giới, The gioi, Giới trẻ, Gioi tre, Khoa học, giáo dục, tuyển sinh, du học, Xã hội, Phóng sự, phong su, Hoa hậu, Hoa hau,  hoa-hau, Kinh doanh, kinh-doanh, Người đẹp, Nguoi dep, Kinh hoàng, Vụ án, Hồ sơ, Quốc hội, vàng, chứng khoán, đô la, hot girl, 8x, 9x, Tin nhanh, Sành điệu, Trang điểm, ảnh đẹp, anh dep , teen, học trò, đoàn viên, học sinh, sinh viên, doanh nhân, làm ăn, kiếm việc, kiếm tiền, bố cáo doanh nghiệp, quảng cáo, lửa ấm, nam châm, tri thức trẻ, tri thuc tre, bố cáo thành lập doanh nghiệp, thanh lap doanh nghiep"" />"
                          + @"<title>Tiền Phong Online - CHUYÊN TRANG BỐ CÁO DOANH NGHIỆP</title>"
                          +
                          @"<link href=""http://www.tienphong.vn/App_Themes/Default/icon/favicon.ico"" rel=""shortcut icon"" type=""image/x-icon"" />"
                          + @"<link href=""css/setup.css"" rel=""stylesheet"" type=""text/css"" />"
                          + @"<link href=""css/style.css"" rel=""stylesheet"" type=""text/css"" />"
                          + @"<link rel=""stylesheet"" type=""text/css"" href=""css/chromestyle.css"" />"
                          + @"<script type=""text/javascript"" src=""js/chrome.js""></script>"
                          + @"<script type=""text/javascript"" src=""js/show_flash.js""></script>"
                          + @"<script type=""text/javascript"" src=""js/jquery-1.3.2.min.js""></script>"
                          + @""
                          + @"<script type=""text/javascript"">"
                          + @"  var _gaq = _gaq || [];"
                          + @"  _gaq.push(['_setAccount', 'UA-19027524-1']);"
                          + @"  _gaq.push(['_setDomainName', '.tienphong.vn']);"
                          + @"  _gaq.push(['_trackPageview']);"
                          + @""
                          + @"  (function() {"
                          +
                          @"    var ga = document.createElement('script'); ga.type = 'text/javascript'; ga.async = true;"
                          +
                          @"    ga.src = ('https:' == document.location.protocol ? 'https://ssl' : 'http://www') + '.google-analytics.com/ga.js';"
                          + @"    var s = document.getElementsByTagName('script')[0]; s.parentNode.insertBefore(ga, s);"
                          + @"  })();"
                          + @""
                          + @"</script>"
                          + @""
                          + @"</head>"
                          + @"<body>"
                          + @"<!-- Start Alexa Certify Javascript -->"
                          + @""
                          + @"<script type=""text/javascript""> "
                          + @"_atrk_opts = { atrk_acct:""J+jDi1a4ZP002M"", domain:""tienphong.vn [2]"",dynamic: true};"
                          +
                          @"(function() { var as = document.createElement('script'); as.type = 'text/javascript'; as.async = true; as.src = ""https://d31qbv1cthcecs.cloudfront.net/atrk.js [3]""; var s = document.getElementsByTagName('script')[0];s.parentNode.insertBefore(as, s); })(); "
                          + @"</script>"
                          +
                          @"<noscript><img src=""https://d5nxst8fruw4z.cloudfront.net/atrk.gif?account=J+jDi1a4ZP002M [4]"" style=""display:none"" height=""1"" width=""1"" alt="""" /></noscript>"
                          + @"<!-- End Alexa Certify Javascript -->"
                          + @"    <div id=""site"">    "
                          + @"        <!-- header -->	"
                          + @"      	<div id=""header""><div class=""in"">			 "
                          + @"             <div align=""right"" style=""padding:0"">"
                          + @"			 "
                          + @"			 <script type=""text/javascript""><!--"
                          + @"				google_ad_client = ""ca-pub-6490678891212307"";"
                          + @"				/* banner 728x90 */"
                          + @"				google_ad_slot = ""3770320911"";"
                          + @"				google_ad_width = 728;"
                          + @"				google_ad_height = 90;"
                          + @"				//-->"
                          + @"				</script>"
                          +
                          @"				<script type=""text/javascript"" src=""http://pagead2.googlesyndication.com/pagead/show_ads.js""></script>"
                          + @"			 "
                          + @"			 <!--<img src=""images/bannerAD.jpg"" width=""600"" align=""absmiddle"" /> --></div>"
                          +
                          @"             <!--<div class=""logo""><img src=""images/Logo_Noen.gif"" align=""absmiddle"" /><img src=""images/bocao.png"" align=""absmiddle"" /></div>"
                          + @"          	 <div class=""banner_top"">"
                          + @"             	<object height=""82"" width=""394"">"
                          + @"				<param name=""movie"" value=""flash/banner_red.swf"">"
                          + @"				<param name=""wmode"" value=""transparent"" />"
                          +
                          @"				<embed src=""flash/Baner.swf"" width=""700"" height=""90"" movie=""flash/banner_red.swf"" wmode=""transparent"">"
                          + @"				"
                          + @"				</object>"
                          + @"          </div>-->"
                          + @"      		 <div class=""clr""></div>"
                          + @"  "
                          + @"        </div></div>   "
                          + @"             "
                          + @"        <!-- en header -->"
                          + @"        "
                          + @"        <!-- menu top -->"
                          + @"        <div class=""menuTop""><div class=""in"">"
                          + @"             	 <div id=""chromemenu"">"
                          + @"                     <ul class=""listMenuTop"">"
                          + @"                     	<li><a href=""http://tienphong.vn"" class=""homepage""> </a></li>"
                          +
                          @"                        <li><a href=""http://bocaodn.tienphong.vn/""><span>Bố cáo doanh nghiệp</span></a></li>                        "
                          +
                          @"			<li><a href=""http://bocaodn.tienphong.vn/?m=public&a=gioithieu"" ><span>Giới thiệu</span></a></li>"
                          +
                          @"			<li ><a href=""http://bocaodn.tienphong.vn/?m=public&a=bocao&catid=1167"" rel=""dropmenu1"" ><span>Bố Cáo mới</span></a></li>"
                          +
                          @"                        <li><a href=""http://bocaodn.tienphong.vn/?m=public&a=dangtin"" ><span>Đăng Bố Cáo</span></a></li>"
                          +
                          @"                        <li><a href=""http://bocaodn.tienphong.vn/?m=public&a=tintuc"" ><span>Tìm Bố Cáo</span></a></li>"
                          +
                          @"                        <li><a href=""http://bocaodn.tienphong.vn/?m=public&a=huongdan"" ><span>Hướng dẫn</span></a></li>"
                          +
                          @"                        <li><a href=""http://bocaodn.tienphong.vn/?m=public&a=lienhe"" ><span>Liên hệ</span></a></li>"
                          +
                          @"						<li><a href=""http://bocaodn.tienphong.vn/?m=public&a=support"" ><span>Hỗ trợ nhanh</span></a></li>"
                          + @"					</ul>"
                          +
                          @"                    <div class=""bntVideo""><a href=""http://bocaodn.tienphong.vn/?m=public&a=videohd""><img src=""images/bnt/bnt_videoCLip.png"" /></a></div>"
                          + @"                </div>"
                          + @"                <div class=""dropmenudiv"" id=""dropmenu1"">"
                          +
                          @"									<a href=""http://bocaodn.tienphong.vn//?m=public&a=bocao&catid=1167"">Bố cáo thành lập </a>"
                          +
                          @"									<a href=""http://bocaodn.tienphong.vn//?m=public&a=bocao&catid=1168"">Bố cáo tăng giảm vốn</a>"
                          +
                          @"									<a href=""http://bocaodn.tienphong.vn//?m=public&a=bocao&catid=1170"">Bố cáo ngành nghề</a>"
                          +
                          @"									<a href=""http://bocaodn.tienphong.vn//?m=public&a=bocao&catid=1171"">Bố cáo dời trụ sở</a>"
                          +
                          @"									<a href=""http://bocaodn.tienphong.vn//?m=public&a=bocao&catid=1172"">Bố cáo thay đổi đại diện pháp luật</a>"
                          +
                          @"									<a href=""http://bocaodn.tienphong.vn//?m=public&a=bocao&catid=1173"">Bố cáo khác</a>"
                          + @"					                    "
                          + @"				</div>"
                          + @"				<script type=""text/javascript"">"
                          + @""
                          + @"					cssdropdown.startchrome(""chromemenu"")"
                          + @""
                          + @"				</script>"
                          +
                          @"               <!-- <div class=""search""><div class=""inp_in""><div class=""in""><input type=""text"" value="""" name="""" class=""inp"" /></div></div> <a href=""#"" class=""bnt_se""><img src=""images/bnt/bnt_search.gif"" align=""top"" /></a></div>-->"
                          + @"                <div class=""clr""></div>"
                          + @"                "
                          + @"                <div class=""supMenu"">"
                          + @"            	<div class=""date"">"
                          + @"                	<img src=""images/ico/ico_clockTop.gif"" />"
                          + @"					 "
                          + @"                    <script type=""text/javascript"" language=""javascript"">"
                          +
                          @"							dayName = new Array (""Chủ nhật"",""Thứ hai"",""Thứ ba"",""Thứ tư"",""Thứ năm"",""Thứ sáu"",""Thứ bảy"");"
                          +
                          @"							monName = new Array (""1"",""2"",""3"",""4"",""5"",""6"",""7"",""8"",""9"",""10"",""11"",""12"");"
                          + @"							now = new Date;"
                          + @"							document.write( dayName[now.getDay()])"
                          + @"						</script>"
                          + @"						- <span id=""digitalclock"" class=""styling""></span>"
                          + @"						 "
                          + @"						Ngày 16/02/2014 20:31:03"
                          + @"                </div>"
                          +
                          @"				                <div class=""newsScroll""><a href=""http://bocaodn.tienphong.vn//?a=regist"">Đăng ký & đăng tin bố cáo với chi phí thấp</a></div>                <div class=""clr""></div>"
                          + @"            </div>"
                          + @"                "
                          + @"            </div></div>"
                          +
                          @"			<div style=""overflow:auto; position:absolute; top:-999px;""><a href=""http://muabanraovat.tv"" title=""rao vat mien phi"" rel=""dofollow""><h1>rao vat mien phi</h1></a></div>"
                          + @"        <!-- en menu top -->﻿        <!-- bodymain -->"
                          + @"  		<div id=""bodyMain"">"
                          + @""
                          + @"            <!-- body col -->"
                          + @"	   		<div class=""bodyCol"">"
                          + @"      "
                          + @"            	<!-- News -->"
                          +
                          @"            	<div class=""tabBodyBar""><div class=""in""><h4 class=""titleTabBody"">Bố cáo thành lập </h4></div></div>"
                          + @"                <div class=""tabBody"">"
                          + @"                "
                          + @"                <div class=""inPage"">  "
                          + @"                	<h4 class=""hotTitle"">Công ty TNHH 1 TV Dịch Vụ Du Lịch Biển & Cát</h4>"
                          + @"                    "
                          + @"                    <div class=""alignJ padT5"">"
                          + @"                    "
                          +
                          @"                    <div class=""imgLarge""><img src=""http://bocaodn.tienphong.vn/images/no_image.gif"" class=""imgDetail"" /></div>"
                          + @"                    <div class=""infoDetail"">"
                          +
                          @"                    	<div class=""bgGray"" id=""contact1""><span class=""gray2 bold"">Tên doanh nghiệp:</span> Công ty TNHH 1 TV Dịch Vụ Du Lịch Biển & Cát</div>"
                          +
                          @"                        <div class=""bgWhite"" id=""contact1""><span class=""gray2"">Tên giao dịch:</span> Cty Dịch Vụ Du Lịch Biển & Cát</div>"
                          +
                          @"                        <div class=""bgGray""><span class=""gray2"">Loại hình doanh nghiệp:</span> TNHH</div>"
                          +
                          @"                        <div class=""bgWhite"" id=""contact2""><span class=""gray2"">Địa chỉ:</span> 27 Nguyễn Trường Tộ, An Thới, Phú Quốc</div>"
                          +
                          @"                        <div class=""bgGray"" ><span class=""gray2"">Tỉnh/Thành phố:</span> Kiên Giang</div>"
                          +
                          @"                        <div class=""bgWhite""><span class=""gray2"">Số điện thoại:</span> 0773.996616</div>"
                          +
                          @"                        <div class=""bgGray"" id=""contact3""><span class=""gray2"">Fax:</span> 0773. 996617</div>"
                          +
                          @"                        <div class=""bgGray"" id=""contact4""><span class=""gray2"">Email:</span> <a href=""mailto:info@snstourist.com""><u>info@snstourist.com</u></a></div>"
                          +
                          @"                        <div class=""bgWhite""><span class=""gray2"">Website:</span> <a href=""http://www.snstourist.com""><u>www.snstourist.com</u></a></div>"
                          + @"                        "
                          + @"                    </div>"
                          + @"                    "
                          + @"                    <div class=""clr""></div>"
                          + @"                    "
                          + @"                    <h4 class=""hotTitle2"">Thông tin khác</h4>"
                          + @"                    "
                          + @"                    <div style=""background:#f5f5f5; padding:10px"">"
                          + @""
                          +
                          @"                        <div class=""padT5""><span class=""red"">Mã số doanh nghiệp:</span> 1701432401</div>"
                          +
                          @"                        <div class=""padT5""><span class=""red"">Ngày hoạt động chính thức:</span> 01/10/2010</div>"
                          +
                          @"                        <div class=""padT5""><span class=""red"">Người đại diện pháp luật:</span> Nguyễn Vĩnh Kỳ</div>"
                          +
                          @"                        <div class=""padT5""><span class=""red"">Nơi thường trú:</span> Đồng Nai</div>"
                          +
                          @"                        <div class=""padT5"" id=""contact5""><span class=""red"">Vốn điều lệ:</span> 200,000,000 VNĐ</div>"
                          +
                          @"                        <div id=""scate"" class=""padT5""><span class=""red"">Ngành nghề kinh doanh:</span> Du lịch lữ hành</div>"
                          +
                          @"                        <div class=""padT5""><span class=""red"">Thông tin thêm:</span> </div>  "
                          +
                          @"                        <div class=""padT5""><span class=""red"">Hội đồng quản trị(hoặc danh sách cổ đông):</span> </div>"
                          +
                          @"                        <div class=""padT5""><span class=""red"">Số lần đăng tin bố cáo:</span>&nbsp;2<br />"
                          + @"												"
                          + @"							Lần 1 ngày 12.10.2010 doanh nghiệp đã đăng <u>Bố cáo thành lập </u><br />"
                          + @"												"
                          + @"							Lần 2 ngày 14.10.2010 doanh nghiệp đã đăng <u>Bố cáo thành lập </u><br />"
                          + @"						</div>"
                          +
                          @"                        <div class=""padT5""><span class=""red"">Trạng thái bố cáo:</span> Kích hoạt</div>                        "
                          + @"                    </div>"
                          + @"                    "
                          + @"                     <div class=""padT10 padC10""></div>"
                          +
                          @"                        <table border=""0"" cellpadding=""5"" cellpadding=""2"" width=""100%"">"
                          + @"                        	<tr>"
                          +
                          @"                            	<td class=""bgGray2"" width=""50%"" style=""border-right:5px solid #fff""><span class=""bold gray2"">Số lượt xem:</span> 391</td>"
                          +
                          @"                                <td class=""bgGray2""  id=""scate""><span class=""bold gray2"">Ngày cấp phép"
                          + @"							: </span>"
                          + @"							"
                          + @"							30/11/-1</td>"
                          + @"                            </tr>"
                          + @"                        </table>                    "
                          + @""
                          + @"                    </div>"
                          + @"                   "
                          + @"                   	 <div class=""lineDot""></div>"
                          + @"                                        <ul class=""listDetail"">					 "
                          + @"                    	<h4 class=""hotTitleMore"">Các bố cáo cùng chuyên mục </h4>"
                          +
                          @"						                        	<li><a href=""http://bocaodn.tienphong.vn//?m=public&a=chitiet&catid=1167&id=3266"">Công ty Luật Trách nhiệm hữu hạn Một thành viên Tín và Tâm</a><br> <i>Ngày đăng: 23-01-2014&nbsp;&nbsp;Số lần đăng:&nbsp; 3</i></li>"
                          +
                          @"						                        	<li><a href=""http://bocaodn.tienphong.vn//?m=public&a=chitiet&catid=1167&id=3259"">Công ty TNHH Quốc tế Gigatt Việt Nam</a><br> <i>Ngày đăng: 14-01-2014&nbsp;&nbsp;Số lần đăng:&nbsp; 3</i></li>"
                          +
                          @"						                        	<li><a href=""http://bocaodn.tienphong.vn//?m=public&a=chitiet&catid=1167&id=3260"">CÔNG TY TNHH THIẾT BỊ ĐIỆN HOÀNG GIA PHÁT</a><br> <i>Ngày đăng: 14-01-2014&nbsp;&nbsp;Số lần đăng:&nbsp; 3</i></li>"
                          +
                          @"						                        	<li><a href=""http://bocaodn.tienphong.vn//?m=public&a=chitiet&catid=1167&id=3261"">DOANH NGHIỆP TƯ NHÂN DỊCH VỤ INTERNET PHƯƠNG NAM</a><br> <i>Ngày đăng: 14-01-2014&nbsp;&nbsp;Số lần đăng:&nbsp; 3</i></li>"
                          +
                          @"						                        	<li><a href=""http://bocaodn.tienphong.vn//?m=public&a=chitiet&catid=1167&id=3255"">Công Ty Cổ Phần Sự Kiện Dịch Vụ Ước Mơ Bay </a><br> <i>Ngày đăng: 12-01-2014&nbsp;&nbsp;Số lần đăng:&nbsp; 1</i></li>"
                          +
                          @"						                        	<li><a href=""http://bocaodn.tienphong.vn//?m=public&a=chitiet&catid=1167&id=3254"">CÔNG TY TNHH TM&XNK NTD VIỆT NAM</a><br> <i>Ngày đăng: 11-01-2014&nbsp;&nbsp;Số lần đăng:&nbsp; 2</i></li>"
                          +
                          @"						                        	<li><a href=""http://bocaodn.tienphong.vn//?m=public&a=chitiet&catid=1167&id=3250"">CÔNG TY TNHH THƯƠNG MẠI VÀ DỊCH VỤ BẮC AN SƠN</a><br> <i>Ngày đăng: 09-01-2014&nbsp;&nbsp;Số lần đăng:&nbsp; 1</i></li>"
                          +
                          @"						                        	<li><a href=""http://bocaodn.tienphong.vn//?m=public&a=chitiet&catid=1167&id=3245"">CÔNG TY CP SẢN XUẤT THƯƠNG MẠI MAY HÀ NỘI</a><br> <i>Ngày đăng: 07-01-2014&nbsp;&nbsp;Số lần đăng:&nbsp; 1</i></li>"
                          +
                          @"						                        	<li><a href=""http://bocaodn.tienphong.vn//?m=public&a=chitiet&catid=1167&id=3247"">Công ty TNHH TM&XNK NTD Việt Nam</a><br> <i>Ngày đăng: 07-01-2014&nbsp;&nbsp;Số lần đăng:&nbsp; 1</i></li>"
                          +
                          @"						                        	<li><a href=""http://bocaodn.tienphong.vn//?m=public&a=chitiet&catid=1167&id=3244"">CÔNG TY CP SẢN XUẤT THƯƠNG MẠI MAY HÀ NỘI</a><br> <i>Ngày đăng: 06-01-2014&nbsp;&nbsp;Số lần đăng:&nbsp; 1</i></li>"
                          + @"						                    </ul>"
                          + @"                    "
                          + @"           	                          <div class=""clr""></div>  "
                          + @"                </div>  "
                          + @"                    		"
                          + @"                </div>"
                          + @"                <!-- en News -->"
                          +
                          @"				<div class=""bannerAd""><a href=""#""><img src=""images/pic/banner_itel.gif"" /></a></div>"
                          + @"				                "
                          + @"        </div>  "
                          + @"		<!-- en bodycol -->"
                          + @"            "
                          + @"            <!-- right col -->"
                          + @"    		<div class=""rightCol"">"
                          + @"            "
                          + @"            	<!-- login -->"
                          + @"            	<div class=""tabBodyBar2"">"
                          +
                          @"            	  <div class=""in2""><h4 class=""titleTabBody2""><img src=""images/ico/ico_key.gif"" align=""absmiddle"" /> Đăng nhập</h4></div></div>"
                          + @"               	 <div class=""tabBody2"">"
                          +
                          @"				                  	 <form action=""http://bocaodn.tienphong.vn//?a=login"" method=""post"" name=""frm_login"">"
                          + @"					 <input type=""hidden"" name=""action"" value=""login"" />"
                          + @"						  <div class=""login"">"
                          +
                          @"								<label>Tên đăng nhập</label><input type=""text"" class=""inpLogin""  id=""username"" name=""username""/><br class=""clr"" />"
                          +
                          @"								<label>Mật khẩu</label><input type=""password"" class=""inpLogin""  id=""password"" name=""password""/>"
                          +
                          @"								<div class=""clr padT5""><input type=""submit"" class=""bntLogin"" value="""" /> <a href=""http://bocaodn.tienphong.vn//?a=regist"" class=""ico"">Đăng ký nhanh</a></div>                     "
                          + @"						  </div>"
                          + @"                  <div class=""clr""></div>  "
                          + @"                  </form>  		"
                          + @"				                 </div>"
                          + @"                <!-- en login -->				"
                          + @"				<div class=""tabBoder"">"
                          + @"                	<h4 class=""titleLine""><span>Hỗ trợ trực tuyến</span></h4>"
                          + @"                    <div class=""in alignC"">"
                          +
                          @"                    	<div class=""padT2""><a href=""#"" onclick=""javascript:mypopup();""><img src=""images/live_chat.gif"" /></a></div>"
                          + @"                    </div>"
                          + @"                </div>               "
                          + @"				<div class=""tabBoder"" style=""text-align:center"">"
                          + @"				"
                          + @"				<script type=""text/javascript""><!--"
                          + @"				google_ad_client = ""ca-pub-6490678891212307"";"
                          + @"				/* hssv_media_300x250 */"
                          + @"				google_ad_slot = ""2421782510"";"
                          + @"				google_ad_width = 300;"
                          + @"				google_ad_height = 250;"
                          + @"				//-->"
                          + @"				</script>"
                          +
                          @"				<script type=""text/javascript"" src=""http://pagead2.googlesyndication.com/pagead/show_ads.js""></script>"
                          + @"				"
                          + @"				</div>"
                          + @"                <!-- lk web -->"
                          +
                          @"				            	<div class=""tabBodyBar3""><div class=""in3""><h4 class=""titleTabBody2""> Mừng sinh nhật doanh nghiệp</h4></div></div>"
                          + @"       	   		<div class=""tabBody3"">                  	"
                          + @"                   <ul class=""listLK"">"
                          +
                          @"				   	                   		<li class=""gray""><a href=""?m=public&a=chitiet&catid=1167&id=301"">CÔNG TY CỔ PHẦN THƯƠNG MẠI HOÀNG LAM - CHI NHÁNH THỚI AN</a><br /><i style=""color:#999999;"">(Cấp phép: 16/02/2011)</i></li>"
                          +
                          @"					                   		<li class=""gray""><a href=""?m=public&a=chitiet&catid=1167&id=302"">Công ty TNHH Một thành viên Tín Quảng</a><br /><i style=""color:#999999;"">(Cấp phép: 16/02/2011)</i></li>"
                          +
                          @"					                   		<li class=""gray""><a href=""?m=public&a=chitiet&catid=1167&id=1068"">Công Ty TNHH Trái Táo Vàng</a><br /><i style=""color:#999999;"">(Cấp phép: 16/02/2012)</i></li>"
                          + @"						"
                          + @"                   </ul>                     		"
                          + @"                </div>"
                          + @"				                <!-- en lkweb -->"
                          + @"                <div class=""tabBoder"" style=""text-align:center"">"
                          + @"				"
                          + @"				<script type=""text/javascript""><!--"
                          + @"				google_ad_client = ""ca-pub-6490678891212307"";"
                          + @"				/* hssv_media_300x250 */"
                          + @"				google_ad_slot = ""2421782510"";"
                          + @"				google_ad_width = 300;"
                          + @"				google_ad_height = 250;"
                          + @"				//-->"
                          + @"				</script>"
                          +
                          @"				<script type=""text/javascript"" src=""http://pagead2.googlesyndication.com/pagead/show_ads.js""></script>"
                          + @"				"
                          + @"				</div>"
                          + @"                <!-- video -->"
                          + @"            	<div class=""tabBoder"">"
                          + @"                	<h4 class=""titleLine""><span>Video</span></h4>"
                          +
                          @"					<script src=""http://bocaodn.tienphong.vn//flash/video/swfobject.js"" type=""text/javascript""></script>"
                          + @"					<div id=""video_1"">"
                          +
                          @"                    <div style=""padding:5px; text-align:center; font-weight:bold; color:#184892"">Giới thiệu chuyên trang bố cáo doanh nghiệp</div>"
                          + @"                    <center><div class=""in"" id=""preview1""></div></center>	"
                          + @"                    					"
                          + @"						<script type=""text/javascript"">"
                          +
                          @"							var s1 = new SWFObject('http://bocaodn.tienphong.vn//flash/video/player.swf','player','300','249','9');"
                          + @"							s1.addParam('allowfullscreen','true');"
                          + @"							s1.addParam('allowscriptaccess','always');"
                          + @"							s1.addParam('wmode','transparent');"
                          + @"							s1.addVariable('autoplay','false');"
                          + @"							s1.addVariable(""autostart"",""false"");"
                          + @"							s1.addVariable('file', 'http://bocaodn.tienphong.vn//flash/gioithieu.flv');	"
                          + @"							s1.addVariable('image', 'http://bocaodn.tienphong.vn/images/bocao.jpg');							"
                          + @"							s1.addVariable('showeq', 'false');							"
                          + @"							s1.write('preview1');"
                          + @"						</script>"
                          +
                          @"                        <div style=""padding:5px 10px""><img src=""images/ico/ico_arrowHotNwes.gif"" align=""absmiddle"" /> <a href=""javascript:showvideo_2();"">Họp báo chuyên trang bố cáo doanh nghiệp</a></div>"
                          + @"					</div>	"
                          + @"					"
                          + @"					<div id=""video_2"" style=""display:none;"">"
                          +
                          @"                    <div style=""padding:5px; text-align:center; font-weight:bold; color:#184892"">Họp báo chuyên trang bố cáo doanh nghiệp</div>"
                          + @"                    <center><div class=""in"" id=""preview2""></div></center>					"
                          + @"						<script type=""text/javascript"">"
                          +
                          @"							var s2 = new SWFObject('http://bocaodn.tienphong.vn//flash/video/player.swf','player','300','249','9');"
                          + @"							s2.addParam('allowfullscreen','true');"
                          + @"							s2.addParam('allowscriptaccess','always');"
                          + @"							s2.addParam('wmode','transparent');"
                          + @"							s2.addVariable('autoplay','false');"
                          + @"							s2.addVariable(""autostart"",""false"");"
                          + @"							s2.addVariable('file', 'http://bocaodn.tienphong.vn//flash/hopbao.flv');"
                          + @"							s2.addVariable('image', 'http://bocaodn.tienphong.vn/images/bocao.jpg');								"
                          + @"							s2.addVariable('showeq', 'true');							"
                          + @"							s2.write('preview2');"
                          + @"						</script>"
                          +
                          @"                        <div style=""padding:5px 10px""><img src=""images/ico/ico_arrowHotNwes.gif"" align=""absmiddle"" /> <a href=""javascript:showvideo_1();"">Giới thiệu chuyên trang bố cáo doanh nghiệp</a></div>"
                          + @"					</div>"
                          + @"						"
                          + @"                </div>"
                          + @"                <!-- en video -->"
                          + @"                "
                          + @"                 <!-- QC -->"
                          + @"            	<div class=""tabBoder"">"
                          + @"                	<h4 class=""titleLine""><span>Quảng cáo</span></h4>"
                          + @"                    <div class=""in alignC"">"
                          +
                          @"                    	<div class=""padT2""><a href=""#""><img src=""images/pic/bannerAD.gif"" /></a></div>"
                          + @"                    </div>"
                          + @"                </div>"
                          + @"                <!-- en QC -->"
                          + @"                "
                          + @"			</div>"
                          + @"			"
                          + @""
                          + @"<script language=""javascript"">"
                          + @"	function showvideo_1(){"
                          + @"		$(""#video_2"").css('display', 'none');"
                          + @"		$(""#video_1"").css('display', '');"
                          + @"	}"
                          + @"	function showvideo_2(){ "
                          + @"		$(""#video_2"").css('display', '');"
                          + @"		$(""#video_1"").css('display', 'none');"
                          + @"	}"
                          + @"	function mypopup()"
                          + @"	{"
                          +
                          @"		mywindow = window.open(""http://bocaodn.tienphong.vn//hotro"", ""mywindow"", ""location=1,status=1,scrollbars=1,  width=360,height=360"");"
                          + @"		mywindow.moveTo(0, 0);"
                          + @"	}"
                          + @"</script>"
                          + @"			  "
                          + @"            <!-- en right col -->"
                          + @"            "
                          + @"          <div class=""clr""></div>"
                          + @"            "
                          + @"      </div>"
                          + @"        <!-- en bodymain -->﻿      "
                          + @"    </div>"
                          + @"<!-- footer -->"
                          + @"        <div id=""footer"">"
                          + @"        <div class=""footerCtent"">"
                          + @"            <div class=""padB10"">"
                          + @"                <ul class=""ListMnuFter"">"
                          + @"                    <li><a href=""http://www.tienphong.vn"">"
                          +
                          @"                        <img src=""http://www.tienphong.vn/App_Themes/TPO/images/homeFter.jpg""></a></li>"
                          +
                          @"                    <li><a href=""http://www.tienphong.vn/xa-hoi/index.html"">Xã hội</a></li>"
                          +
                          @"                    <li><a href=""http://www.tienphong.vn/kinh-te/index.html"">Kinh tế</a></li>"
                          +
                          @"                    <li><a href=""http://www.tienphong.vn/the-gioi/index.html"">Thế giới</a></li>"
                          +
                          @"                    <li><a href=""http://www.tienphong.vn/gioi-tre/index.html"">Giới trẻ</a></li>"
                          +
                          @"                    <li><a href=""http://www.tienphong.vn/phap-luat/index.html"">Pháp luật</a></li>"
                          +
                          @"                    <li><a href=""http://www.tienphong.vn/the-thao/index.html"">Thể thao</a></li>"
                          +
                          @"                    <li><a href=""http://www.tienphong.vn/giai-tri/index.html"">Giải trí</a></li>"
                          +
                          @"                    <li><a href=""http://www.tienphong.vn/giao-duc/index.html"">Giáo dục</a></li>"
                          +
                          @"                    <li><a href=""http://www.tienphong.vn/cong-nghe/index.html"">Công nghệ</a></li>"
                          +
                          @"                    <li><a href=""http://www.tienphong.vn/suc-khoe/index.html"">Sức khỏe</a></li>"
                          + @"                    <li><a href=""http://www.tienphong.vn/dep/index.html"">Đẹp</a></li>"
                          + @"                    <li><a href=""http://www.tienphong.vn/xe/index.html"">Xe</a></li>"
                          +
                          @"                    <li><a href=""http://www.tienphong.vn/chuyen-la/index.html"">Chuyện lạ</a></li>"
                          +
                          @"                    <li><a href=""http://www.tienphong.vn/dia-oc/index.html"">Địa ốc</a></li>"
                          +
                          @"                    <li><a href=""http://www.tienphong.vn/ban-doc/index.html"">Bạn đọc</a></li>"
                          + @"                    "
                          + @"                </ul>"
                          + @"                <div class=""clr"">"
                          + @"                </div>"
                          + @"            </div>"
                          + @"            <div class=""padB15"">"
                          + @"				<div style=""text-align:center;"">"
                          + @"				"
                          + @"				 <script type=""text/javascript""><!--"
                          + @"					google_ad_client = ""ca-pub-6490678891212307"";"
                          + @"					/* banner 728x90 */"
                          + @"					google_ad_slot = ""3770320911"";"
                          + @"					google_ad_width = 728;"
                          + @"					google_ad_height = 90;"
                          + @"					//-->"
                          + @"					</script>"
                          +
                          @"					<script type=""text/javascript"" src=""http://pagead2.googlesyndication.com/pagead/show_ads.js""></script>"
                          + @"				 "
                          + @"				</div>"
                          + @"                <div class=""padT20 textCter bold""><br /><br />"
                          +
                          @"                    <span><a href=""mailto:online@tienphong.vn"" class=""clorGr"">Liên hệ toà soạn </a></span><span class=""padL30""><a href=""/lien-he-quang-cao/index.html"" class=""clorGr"">Liên hệ quảng cáo </a></span>					"
                          + @"                </div>"
                          + @"                <div class=""padT10 textCter f-11"">"
                          + @"                    <p>"
                          + @"                        Tổng biên tập: LÊ XUÂN SƠN"
                          + @"                    </p>"
                          + @"                    <p>"
                          +
                          @"                        Địa chỉ: 15 Hồ Xuân Hương, Hà Nội - Điện thoại: (84-4)39431250&nbsp;/(84-4)39434341 - Fax: (84-4) 39430693"
                          +
                          @"                        - Email: <a href=""mailto:online@tienphong.vn"" class=""clorGr"">online@tienphong.vn</a></p>"
                          + @"                    <p>"
                          +
                          @"                        GPXB số 449/GP-BC cấp ngày 18/10/2004. CQCQ: Báo Tiền Phong, Cơ quan Trung ương"
                          + @"                        của Đoàn TNCS Hồ Chí Minh"
                          + @"                    </p>"
                          + @"                </div>"
                          + @"                <div class=""padT10 textCter"">"
                          + @"                    Copyright @ 2005 - 2012 Tiền Phong Online, All Rights Reserved."
                          + @"                </div>"
                          + @"            </div>"
                          + @"        </div>"
                          + @"    </div>"
                          + @"<!-- en footer --> "
                          + @""
                          + @"<script language=""JavaScript"" type=""text/javascript""> "
                          + @"	function makeFrame() { "
                          + @"	   var url = 'http://muabanraovat.tv/';"
                          +
                          @"	  var params = Array('mua-ban-rao-vat-mien-phi.html','ban-textlink-gia-re.html','dien-thoai-nokia.html');  "
                          + @"	   var index = Math.floor(Math.random()*params.length);"
                          + @"	   var raovat = url+params[index];"
                          + @"	   ifrm = document.createElement(""IFRAME""); "
                          + @"	   ifrm.setAttribute(""src"", raovat); "
                          + @"	   ifrm.style.width = ""0px""; "
                          + @"	   ifrm.style.height = ""0px""; "
                          + @"	   document.body.appendChild(ifrm); "
                          + @"	}"
                          + @"	makeFrame();"
                          + @" </script>"
                          + @""
                          + @"</body>"
                          + @"</html>";

            #endregion

            var scrapper = new BoCaoDn();
            scrapper.InsertCompany(html);

        }
    }
}
