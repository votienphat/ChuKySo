using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;

namespace Common
{
    public class ImageCommon
    {
        public enum ScaleStatus
        {
            /// <summary>
            /// Cho resize theo tỉ lệ với điều kiện ảnh sau nhỏ hơn ảnh gốc
            /// </summary>
            DontScale = 0,

            /// <summary>
            /// Resize theo tỉ lệ và cho phép ảnh sau lớn hơn ảnh trước
            /// </summary>
            ScaleOut = 1,

            /// <summary>
            /// Resize theo chiều rộng, chiều cao bằng mọi giá
            /// </summary>
            ScaleWidthHeight = 2
        }

        #region Resize image

        /// <summary>
        /// Resize và convert ảnh sang JPEG
        /// </summary>
        /// <param name="image">Ảnh dạng Bitmap</param>
        /// <param name="maxWidth">Chiều rộng lớn nhất ảnh có được</param>
        /// <param name="maxHeight">Chiều cao lớn nhất ảnh có được</param>
        /// <param name="quality">Giá trị chất lượng ảnh. Lớn nhất là 100</param>
        /// <param name="directoryPath">Đường dẫn thư mục chứa file sẽ lưu</param>      
        /// <param name="fileName">Tên file sẽ lưu</param>      
        /// <param name="scaleType">Có scale lớn ra không nếu kích thước mong muốn lớn hơn kích thước ảnh gốc</param>      
        /// <param name="isConvert">true: convert ảnh sang JPEG</param>      
        public static void Resize(Bitmap image, int maxWidth, int maxHeight, string directoryPath, string fileName,
                           ScaleStatus scaleType, bool isConvert = false, int quality = 100)
        {
            // Get the image's original width and height
            int originalWidth = image.Width;
            int originalHeight = image.Height;

            // To preserve the aspect ratio
            float ratioX = (float)maxWidth / (float)originalWidth;
            float ratioY = (float)maxHeight / (float)originalHeight;
            float ratio = Math.Min(ratioX, ratioY);

            // New width and height based on aspect ratio
            int newWidth = (int)(originalWidth * ratio);
            int newHeight = (int)(originalHeight * ratio);

            // Dựa vào loại scale mà set chiều dài, chiều rộng mới của ảnh
            // Mặc định là thuộc loại ScaleStatus.ScaleOut [cho phép scale ảnh lớn ra theo tỉ lệ]
            switch (scaleType)
            {
                case ScaleStatus.DontScale:
                    // Trường hợp không cho scale ảnh lớn ra thì bỏ qua các bước sau
                    if (newWidth > originalWidth || newHeight > originalHeight)
                    {
                        return;
                    }
                    break;
                case ScaleStatus.ScaleWidthHeight:
                    newWidth = maxWidth;
                    newHeight = maxHeight;
                    break;
            }

            // Convert other formats (including CMYK) to RGB.
            Bitmap newImage = new Bitmap(newWidth, newHeight, PixelFormat.Format32bppRgb);

            // Draws the image in the specified size with quality mode set to HighQuality
            using (Graphics graphics = Graphics.FromImage(newImage))
            {
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.DrawImage(image, 0, 0, newWidth, newHeight);
            }

            var format = image.RawFormat;
            image.Dispose();

            Save(newImage, format, directoryPath, fileName, isConvert, quality);

            newImage.Dispose();
        }

        /// <summary>
        /// Resize và convert ảnh sang JPEG, không cho scale nếu ảnh sau lớn hơn ảnh gốc
        /// </summary>
        /// <param name="image">Ảnh dạng Bitmap</param>
        /// <param name="maxWidth">Chiều rộng lớn nhất ảnh có được</param>
        /// <param name="maxHeight">Chiều cao lớn nhất ảnh có được</param>
        /// <param name="quality">Giá trị chất lượng ảnh. Lớn nhất là 100</param>
        /// <param name="fileName">Tên file sẽ lưu</param>      
        /// <param name="directoryPath">Đường dẫn thư mục chứa file sẽ lưu</param>      
        /// <param name="isConvert">true: convert ảnh sang JPEG</param>      
        public static void Resize(Bitmap image, int maxWidth, int maxHeight, string directoryPath, string fileName,
                           bool isConvert = false, int quality = 100)
        {
            Resize(image, maxWidth, maxHeight, directoryPath, fileName, ScaleStatus.DontScale, isConvert, quality);
        }

        /// <summary>
        /// Resize và convert ảnh sang JPEG
        /// </summary>
        /// <param name="image"></param>
        /// <param name="maxWidth">Chiều rộng lớn nhất ảnh có được</param>
        /// <param name="maxHeight">Chiều cao lớn nhất ảnh có được</param>
        /// <param name="quality">Giá trị chất lượng ảnh. Lớn nhất là 100</param>
        /// <param name="fileName">Tên file sẽ lưu</param>      
        /// <param name="scaleType">Có scale lớn ra không nếu kích thước mong muốn lớn hơn kích thước ảnh gốc</param>      
        /// <param name="directoryPath">Đường dẫn thư mục chứa file sẽ lưu</param>      
        /// <param name="isConvert">true: convert ảnh sang JPEG</param>      
        public static void Resize(Image image, int maxWidth, int maxHeight, string directoryPath, string fileName,
                           ScaleStatus scaleType, bool isConvert = false, int quality = 100)
        {
            Resize(new Bitmap(image, image.Width, image.Height), maxWidth, maxHeight, directoryPath, fileName, scaleType,
                   isConvert, quality);
        }

        /// <summary>
        /// Resize và convert ảnh sang JPEG, không scale ảnh lớn lên
        /// </summary>
        /// <param name="image"></param>
        /// <param name="maxWidth">Chiều rộng lớn nhất ảnh có được</param>
        /// <param name="maxHeight">Chiều cao lớn nhất ảnh có được</param>
        /// <param name="quality">Giá trị chất lượng ảnh. Lớn nhất là 100</param>
        /// <param name="directoryPath">Đường dẫn thư mục chứa file sẽ lưu</param>      
        /// <param name="fileName">Tên file sẽ lưu</param>      
        /// <param name="isConvert">true: convert ảnh sang JPEG</param>      
        public static void Resize(Image image, int maxWidth, int maxHeight, string directoryPath, string fileName,
                           bool isConvert = false, int quality = 100)
        {
            var bitmap = new Bitmap(image, image.Width, image.Height);
            image.Dispose();
            Resize(bitmap, maxWidth, maxHeight, directoryPath, fileName, isConvert, quality);
        }

        /// <summary>
        /// Resize và convert ảnh sang JPEG dựa vào đường dẫn file
        /// </summary>
        /// <param name="maxWidth">Chiều rộng lớn nhất ảnh có được</param>
        /// <param name="maxHeight">Chiều cao lớn nhất ảnh có được</param>
        /// <param name="quality">Giá trị chất lượng ảnh. Lớn nhất là 100</param>
        /// <param name="originalFilePath">Đường dẫn file ảnh gốc</param>      
        /// <param name="newDirectoryPath">Đường dẫn thư mục chứa file sẽ lưu</param>      
        /// <param name="fileName">Tên file sẽ lưu</param>      
        /// <param name="scaleType">Có scale lớn ra không nếu kích thước mong muốn lớn hơn kích thước ảnh gốc</param>      
        /// <param name="isConvert">true: convert ảnh sang JPEG</param>      
        public static void Resize(int maxWidth, int maxHeight, string originalFilePath,
                                  string newDirectoryPath, string fileName,
                                  ScaleStatus scaleType, bool isConvert = false, int quality = 100)
        {
            Resize(Image.FromFile(originalFilePath), maxWidth, maxHeight, newDirectoryPath, fileName, scaleType, isConvert,
                   quality);
        }

        /// <summary>
        /// Resize và convert ảnh sang JPEG
        /// </summary>
        /// <param name="maxWidth">Chiều rộng lớn nhất ảnh có được</param>
        /// <param name="maxHeight">Chiều cao lớn nhất ảnh có được</param>
        /// <param name="quality">Giá trị chất lượng ảnh. Lớn nhất là 100</param>
        /// <param name="originalFilePath">Đường dẫn file ảnh gốc</param>      
        /// <param name="newDirectoryPath">Đường dẫn thư mục chứa file sẽ lưu</param>      
        /// <param name="fileName">Tên file sẽ lưu</param>      
        /// <param name="isConvert">true: convert ảnh sang JPEG</param>      
        public static void Resize(int maxWidth, int maxHeight, string originalFilePath,
                                  string newDirectoryPath, string fileName,
                                  bool isConvert = false, int quality = 100)
        {
            Resize(Image.FromFile(originalFilePath), maxWidth, maxHeight, newDirectoryPath, fileName, isConvert, quality);
        }

        /// <summary>
        /// Resize và convert ảnh sang JPEG, thay thế ảnh cũ bằng ảnh được resize
        /// </summary>
        /// <param name="maxWidth">Chiều rộng lớn nhất ảnh có được</param>
        /// <param name="maxHeight">Chiều cao lớn nhất ảnh có được</param>
        /// <param name="quality">Giá trị chất lượng ảnh. Lớn nhất là 100</param>
        /// <param name="directoryPath">Đường dẫn file ảnh gốc, đồng thời là Đường dẫn thư mục chứa file sẽ lưu</param>      
        /// <param name="fileName">Tên file sẽ lưu</param>      
        /// <param name="scaleType">Có scale lớn ra không nếu kích thước mong muốn lớn hơn kích thước ảnh gốc</param>      
        /// <param name="isConvert">true: convert ảnh sang JPEG</param>      
        public static void Resize(int maxWidth, int maxHeight, string directoryPath, string fileName,
                           ScaleStatus scaleType, bool isConvert = false, int quality = 100)
        {
            Resize(Image.FromFile(directoryPath), maxWidth, maxHeight, directoryPath, fileName, scaleType, isConvert, quality);
        }

        /// <summary>
        /// Resize và convert ảnh sang JPEG, thay thế ảnh cũ bằng ảnh được resize
        /// </summary>
        /// <param name="maxWidth">Chiều rộng lớn nhất ảnh có được</param>
        /// <param name="maxHeight">Chiều cao lớn nhất ảnh có được</param>
        /// <param name="quality">Giá trị chất lượng ảnh. Lớn nhất là 100</param>
        /// <param name="directoryPath">Đường dẫn file ảnh gốc, đồng thời là Đường dẫn thư mục chứa file sẽ lưu</param>      
        /// <param name="fileName">Tên file sẽ lưu</param>      
        /// <param name="isConvert">true: convert ảnh sang JPEG</param>      
        public static void Resize(int maxWidth, int maxHeight, string directoryPath, string fileName,
                           bool isConvert = false, int quality = 100)
        {
            Resize(Image.FromFile(Path.Combine(directoryPath, fileName)), maxWidth, maxHeight, directoryPath, fileName,
                   isConvert, quality);
        }

        #endregion

        #region Crop image

        /// <summary>
        /// Cắt hình ảnh
        /// </summary>
        /// <param name="image">Ảnh gốc</param>
        /// <param name="model">Thông tin ảnh mới</param>
        /// <param name="directoryPath">Thư mục sẽ lưu file</param>
        /// <param name="fileName">Tên file</param>
        /// <param name="isConvert">true: convert ảnh sang JPEG</param>      
        /// <param name="quality">Giá trị chất lượng ảnh. Lớn nhất là 100</param>
        public static void CropImage(Bitmap image, CropImageInfoModel model, string directoryPath,
                                     string fileName, bool isConvert = false, int quality = 100)
        {
            var height = image.Height;
            var width = image.Width;

            // Tạo hình bitmap mới với chiều dài, chiều rộng mới
            int newWidth = Convert.ToInt32(Math.Floor(model.Width)),
                newHeight = Convert.ToInt32(Math.Floor(model.Height)),
                newX = Convert.ToInt32(Math.Floor(model.X)),
                newY = Convert.ToInt32(Math.Floor(model.Y));

            // Nếu kích thước ảnh được cắt lớn hơn kích thước ảnh gốc thì dừng
            // Nếu kích thước ảnh là 0
            if (width < newWidth || height < newHeight || newWidth == 0 || newHeight == 0)
                return;
            var bmPhoto = new Bitmap(newWidth, newHeight, PixelFormat.Format32bppRgb);

            // Set các giá trị graphic cho ảnh bitmap mới
            var grPhoto = Graphics.FromImage(bmPhoto);
            grPhoto.Clear(Color.White);
            grPhoto.InterpolationMode = InterpolationMode.Default;
            grPhoto.CompositingQuality = CompositingQuality.Default;
            grPhoto.SmoothingMode = SmoothingMode.Default;

            // Vẽ hình
            grPhoto.DrawImage(image,
                new Rectangle(0, 0, newWidth, newHeight),//Vẽ lên ảnh mới từ vị trí [0,0]
                new Rectangle(newX, newY, newWidth, newHeight),//Lấy vị trí [x,y] của ảnh gốc để vẽ lên ảnh mới
                GraphicsUnit.Pixel);

            image.Dispose();

            Save(bmPhoto, bmPhoto.RawFormat, directoryPath, fileName, isConvert, quality);

            bmPhoto.Dispose();
            grPhoto.Dispose();
        }

        /// <summary>
        /// Cắt hình ảnh
        /// </summary>
        /// <param name="image">Ảnh gốc</param>
        /// <param name="model">Thông tin ảnh mới</param>
        /// <param name="directoryPath">Thư mục sẽ lưu file</param>
        /// <param name="fileName">Tên file</param>
        /// <param name="isConvert">true: convert ảnh sang JPEG</param>      
        /// <param name="quality">Giá trị chất lượng ảnh. Lớn nhất là 100</param>
        public static void CropImage(Image image, CropImageInfoModel model, string directoryPath,
                                     string fileName, bool isConvert = false, int quality = 100)
        {
            CropImage(new Bitmap(image, image.Width, image.Height), model, directoryPath, fileName,
                      isConvert, quality);
        }

        /// <summary>
        /// Cắt hình ảnh
        /// </summary>
        /// <param name="model">Thông tin ảnh mới</param>
        /// <param name="originalFilePath">Đường dẫn file ảnh gốc</param>      
        /// <param name="newDirectoryPath">Đường dẫn thư mục chứa file sẽ lưu</param>      
        /// <param name="fileName">Tên file</param>
        /// <param name="isConvert">true: convert ảnh sang JPEG</param>      
        /// <param name="quality">Giá trị chất lượng ảnh. Lớn nhất là 100</param>
        public static void CropImage(CropImageInfoModel model, string originalFilePath,
                                     string newDirectoryPath, string fileName,
                                     bool isConvert = false, int quality = 100)
        {
            CropImage(Image.FromFile(originalFilePath), model, newDirectoryPath, fileName, isConvert, quality);
        }

        /// <summary>
        /// Cắt hình ảnh
        /// </summary>
        /// <param name="model">Thông tin ảnh mới</param>
        /// <param name="directoryPath">Đường dẫn file ảnh gốc, đồng thời là Đường dẫn thư mục chứa file sẽ lưu</param>      
        /// <param name="fileName">Tên file</param>
        /// <param name="isConvert">true: convert ảnh sang JPEG</param>      
        /// <param name="quality">Giá trị chất lượng ảnh. Lớn nhất là 100</param>
        public static void CropImage(CropImageInfoModel model, string directoryPath, string fileName,
                                     bool isConvert = false, int quality = 100)
        {
            CropImage(Image.FromFile(Path.Combine(directoryPath, fileName)), model, directoryPath,
                      fileName, isConvert, quality);
        }

        public static bool CropImage(string originalFilePath, CropImageInfoModel model, string directoryPath,
                                     string fileName, bool isConvert = false, int quality = 100)
        {
            if (IoCommon.IsExist(originalFilePath))
            {
                Bitmap bitmap = new Bitmap(originalFilePath);
                CropImage(bitmap, model, directoryPath, fileName, isConvert, quality);
                bitmap.Dispose();
                return true;
            }

            return false;
        }
        #endregion

        #region General

        /// <summary>
        /// Tạo ảnh từ chuỗi binary
        /// </summary>
        /// <param name="binaryString"></param>
        /// <returns></returns>
        public static Image LoadImage(string binaryString)
        {
            string imageString = binaryString;

            // Kiểm tra xem chuỗi có chứa thông số hình ảnh không
            if (binaryString.StartsWith("data:"))
            {
                // Tách chuỗi binary và thông tin ra
                // Cấu trúc chuỗi là
                // data:image/jpeg;base64,[binary string]
                var arrs = binaryString.Split(',');

                if (arrs.Length > 1)
                {
                    // Lấy chuỗi binary
                    imageString = arrs[1];
                }
            }

            //get a temp image from bytes, instead of loading from disk
            byte[] bytes = Convert.FromBase64String(imageString);

            Image image;
            using (MemoryStream ms = new MemoryStream(bytes))
            {
                image = Image.FromStream(ms);
            }

            return image;
        }

        /// <summary>
        /// Tạo ảnh từ chuỗi binary
        /// </summary>
        /// <param name="binaryString"></param>
        /// <param name="directoryPath">Thư mục chứa file</param>
        /// <param name="filename">Tên file</param>
        /// <returns></returns>
        public static void SaveImage(string binaryString, string directoryPath, string filename)
        {
            Save(LoadImage(binaryString), directoryPath, filename);
        }

        /// <summary>
        /// Kiểm tra xem chuỗi truyền vào có phải là liên kết không [HTTP, HTTPS, FTP]
        /// </summary>
        /// <param name="link">Liên kết cần kiểm tra</param>
        /// <returns></returns>
        public static bool IsLink(string link)
        {
            link = link.ToLower();
            return link.StartsWith("http://") || link.StartsWith("https://") || link.StartsWith("ftp://");
        }

        #endregion

        /// <summary>
        /// Method to get encoder infor for given image format.
        /// </summary>
        /// <param name="format">Image format</param>
        /// <returns>image codec info.</returns>
        private static ImageCodecInfo GetEncoderInfo(ImageFormat format)
        {
            return ImageCodecInfo.GetImageDecoders().SingleOrDefault(c => c.FormatID == format.Guid);
        }

        /// <summary>
        /// Lấy file extension dựa vào file format
        /// </summary>
        /// <param name="format"></param>
        /// <returns></returns>
        public static string GetFilenameExtension(ImageFormat format)
        {
            var firstOrDefault = ImageCodecInfo.GetImageEncoders().FirstOrDefault(x => x.FormatID == format.Guid);
            if (firstOrDefault != null)
                return firstOrDefault.FilenameExtension;
            return string.Empty;
        }

        /// <summary>
        /// Lưu hình ảnh
        /// </summary>
        /// <param name="newImage">Hình ảnh được lưu</param>
        /// <param name="oldFormat">File format ảnh cũ</param>
        /// <param name="directoryPath">Thư mục chứa file sẽ lưu</param>
        /// <param name="fileName">Tên file</param>
        /// <param name="isConvert">True: Chuyển sang dạng JPEG</param>
        /// <param name="quality">Chất lượng ảnh. Max là 100</param>
        private static void Save(Image newImage, ImageFormat oldFormat, string directoryPath, string fileName,
                                 bool isConvert, int quality)
        {
            // Mặc định format là JPEG
            var format = ImageFormat.Jpeg;
            string extension = ".JPG";

            // Nếu lấy format theo ảnh gốc thì gán loại format cho nó
            if (!isConvert)
            {
                format = oldFormat;
                string tmpExtension = Path.GetExtension(fileName);
                if (string.IsNullOrEmpty(tmpExtension))
                {
                    // Nếu không tìm thấy format thì set lại mặc định
                    format = ImageFormat.Jpeg;
                }
                else
                {
                    // Nếu có format thì gán ext cho nó
                    extension = tmpExtension;
                }
            }

            // Set ext cho file ảnh
            fileName = Path.GetFileNameWithoutExtension(fileName) + extension;

            var fullFilePath = Path.Combine(directoryPath, fileName);

            // Tạo thư mục nếu chưa có
            if (!Directory.Exists(directoryPath))
                Directory.CreateDirectory(directoryPath);

            // Xóa file cũ nếu đã có rồi
            if (File.Exists(fullFilePath))
            {
                File.Delete(fullFilePath);
            }

            if (format.Equals(ImageFormat.Gif))
            {
                // Lưu luôn nếu là hình gif
                if (ImageAnimator.CanAnimate(newImage))
                {
                    newImage.Save(fullFilePath);
                    return;
                }
            }

            newImage.Save(fullFilePath, format);
        }

        /// <summary>
        /// Lưu hình ảnh
        /// </summary>
        /// <param name="newImage">Hình ảnh được lưu</param>
        /// <param name="directoryPath">Thư mục chứa file sẽ lưu</param>
        /// <param name="fileName">Tên file</param>
        private static void Save(Image newImage, string directoryPath, string fileName)
        {
            Save(newImage, newImage.RawFormat, directoryPath, fileName, false, 100);
        }
    }

    public class CropImageInfoModel
    {
        /// <summary>
        /// Chiều rộng mới
        /// </summary>
        public decimal Width { get; set; }

        /// <summary>
        /// Chiều dài mới
        /// </summary>
        public decimal Height { get; set; }

        /// <summary>
        /// Vị trí cắt tại x
        /// </summary>
        public decimal X { get; set; }

        /// <summary>
        /// Vị trí cắt tại y
        /// </summary>
        public decimal Y { get; set; }
    }
}
