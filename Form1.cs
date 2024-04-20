using System;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using Compunet.YoloV8;
using Compunet.YoloV8.Plotting;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace WinFormsApp1
{
    public partial class YoloV8Gpu : Form
    {
        private string selectedImagePath;
        private string currentDirectory;
        private YoloV8Predictor predictor;
        Stopwatch stopwatch1;
        Stopwatch stopwatch2;
        Stopwatch stopwatch3;
        TimeSpan elapsedTime1;
        TimeSpan elapsedTime2;
        String selectedFolderPath;


        public YoloV8Gpu()
        {
            InitializeComponent();
            currentDirectory = "C:\\Users\\vuvie\\OneDrive\\Desktop\\WinFormsApp1";
        }
        private void btnloadModel(object sender, EventArgs e)
        {
            stopwatch2 = new Stopwatch();
            stopwatch2.Start();
            string modelPath = "./model/best.onnx";
            predictor = YoloV8Predictor.Create(modelPath);
            stopwatch2.Stop();
            elapsedTime2 = stopwatch2.Elapsed;
            timeprocess.Text = "Thời gian load model: " + elapsedTime2.TotalMilliseconds + " milliseconds";
        }


        private async void btnRunYolo_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedImagePath))
            {
                MessageBox.Show("Vui lòng chọn một hình ảnh trước khi chạy YOLO.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (predictor == null)
            {
                MessageBox.Show("Vui lòng tải model trước khi chạy YOLO.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //var modelPath = Path.Combine(currentDirectory, "model", "best.onnx");

            stopwatch1 = new Stopwatch();
            stopwatch1.Start();
            var image = SixLabors.ImageSharp.Image.Load<Rgba32>(selectedImagePath);
            var result = await predictor.SegmentAsync(selectedImagePath);
            stopwatch1.Stop();
            var ploted = await result.PlotImageAsync(image);
            elapsedTime1 = stopwatch1.Elapsed;

            if (result.Boxes.Count() > 0)
            {
                timeprocess.Text = "Thời gian xử lý ảnh: "+ elapsedTime1.TotalMilliseconds + " milliseconds\n" 
                + "Thời gian load model: " + elapsedTime2.TotalMilliseconds + " milliseconds"
                + "\n score (0): " + result.Boxes.ElementAt(0).Confidence.ToString()
                + "\n Name (0): " + result.Boxes.ElementAt(0).Class.Name.ToString()
                + "\n Full (0): " + result.Boxes.ElementAt(0).Bounds.ToString()
                + "\n info points (0): " + result.Boxes.ElementAtOrDefault(0).Mask.Height.ToString()
                ;
            }
            using (var memoryStream = new MemoryStream())
            {
                ploted.SaveAsPng(memoryStream);
                memoryStream.Seek(0, SeekOrigin.Begin);
                pictureBoxResult.Image = System.Drawing.Image.FromStream(memoryStream);
            }
            pictureBoxResult.SizeMode = PictureBoxSizeMode.Zoom;
            // Tạo thư mục để lưu ảnh đã xử lý nếu nó chưa tồn tại
            var processedImagesDirectory = Path.Combine(currentDirectory, "processed_images");
            Directory.CreateDirectory(processedImagesDirectory);
            // Tạo tên file mới với phần phân biệt
            var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(selectedImagePath);
            var fileExtension = Path.GetExtension(selectedImagePath);
            var outputFileName = $"{fileNameWithoutExtension}_processed{fileExtension}";
            // Lưu ảnh đã xử lý vào thư mục mới với tên file mới
            var outputImagePath = Path.Combine(processedImagesDirectory, outputFileName);
            ploted.Save(outputImagePath);
            Console.WriteLine(result);
        }
        private void btnBrowseImage_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.bmp;*.jpg;*.jpeg;*.png)|*.BMP;*.JPG;*.JPEG;*.PNG";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                selectedImagePath = openFileDialog.FileName;

                //Hiển thị ảnh
                pictureBoxInput.Image = System.Drawing.Image.FromFile(selectedImagePath);
                pictureBoxInput.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }

        private void btnBrowseFolder_Click(object sender, EventArgs e)
        {
            var folderBrowserDialog = new FolderBrowserDialog();

            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                // Lưu đường dẫn thư mục được chọn
                selectedFolderPath = folderBrowserDialog.SelectedPath;
            
            }
        }

        private async void btnProcessImages_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedFolderPath))
            {
                MessageBox.Show("Vui lòng chọn một thư mục chứa các tệp ảnh trước khi xử lý.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (predictor == null)
            {
                MessageBox.Show("Vui lòng tải model trước khi chạy YOLO.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Lấy danh sách các tệp ảnh trong thư mục được chọn
            string[] imageFiles = Directory.GetFiles(selectedFolderPath, "*.bmp", SearchOption.AllDirectories)
                                            .Union(Directory.GetFiles(selectedFolderPath, "*.jpg", SearchOption.AllDirectories))
                                            .Union(Directory.GetFiles(selectedFolderPath, "*.jpeg", SearchOption.AllDirectories))
                                            .Union(Directory.GetFiles(selectedFolderPath, "*.png", SearchOption.AllDirectories))
                                            .ToArray();

            // Khởi tạo biến tổng thời gian
            TimeSpan totalElapsedTime = TimeSpan.Zero;
            stopwatch3 = new Stopwatch();
            stopwatch3.Start();
            int processedImageCount = 0;

            // Xử lý từng tệp ảnh
            foreach (var imagePath in imageFiles)
            {
                // Xử lý ảnh
                
                var image = SixLabors.ImageSharp.Image.Load<Rgba32>(imagePath);
                var result = await predictor.SegmentAsync(imagePath);
                //var ploted = await result.PlotImageAsync(image);
                // Dừng đồng hồ đếm thời gian và tính tổng thời gian
                processedImageCount++;

            }
            stopwatch3.Stop();
            totalElapsedTime += stopwatch3.Elapsed;

            // Hiển thị tổng thời gian xử lý
            var resultMessage = $"Tổng thời gian xử lý tất cả {processedImageCount} ảnh: {totalElapsedTime.TotalMilliseconds} milliseconds";
            MessageBox.Show(resultMessage, "Kết quả", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }



    }
}


