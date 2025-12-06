using OpenCvSharp;
using Tesseract;

namespace OpticalCharacterRecognition
{
    public partial class Form1 : Form
    {
        public string tesseractDataPath = "./tessdata/";
        public string imagePath = string.Empty;
        public string imageLanguage = string.Empty;
        public string tempImagePath = string.Empty;
        public string recognizedText = string.Empty;

        public Image selectedImage;
        public Image processedImage;

        public Form1()
        {
            InitializeComponent();

            cmbLanguage.Items.Add("rus");
            cmbLanguage.Items.Add("eng");
            cmbLanguage.SelectedItem = "rus";

            imageLanguage = "rus";
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = "C:\\";
            openFileDialog1.Filter = "" +
                "JPG files (*.jpg)|*.jpg|" +
                "JPEG files (*.jpeg)|*.jpeg|" +
                "PNG files (*.png)|*.png|" +
                "All files (*.*)|*.*";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                imagePath = openFileDialog1.FileName;
            }

            if (imagePath == string.Empty)
            {
                MessageBox.Show("Файл не указан", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            selectedImage = Image.FromFile(imagePath);
            pictureBox1.Image = selectedImage;

            processedImage = ProcessImage(imagePath);
            pictureBox2.Image = processedImage;
        }

        private Image ProcessImage(string imagePath)
        {
            Mat image = Cv2.ImRead(imagePath, ImreadModes.Color);
            Mat scaledImage = new Mat();
            Mat grayImage = new Mat();
            Mat binaryImage = new Mat();

            tempImagePath = Path.GetTempFileName() + ".png";

            if (image.Empty())
            {
                MessageBox.Show("Не удалось открыть файл по указанному пути", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            Cv2.Resize(image, scaledImage, new OpenCvSharp.Size(), 3, 3, InterpolationFlags.Cubic);
            Cv2.CvtColor(image, grayImage, ColorConversionCodes.BGR2GRAY);
            Cv2.Threshold(grayImage, binaryImage, 0, 255, ThresholdTypes.Otsu);
            Cv2.ImWrite(tempImagePath, binaryImage);

            using MemoryStream memoryStream = new MemoryStream();
            {
                Cv2.ImEncode(".png", binaryImage, out byte[] png);
                memoryStream.Write(png);
                memoryStream.Position = 0;
                return Image.FromStream(memoryStream);
            }
        }

        private void buttonScan_Click(object sender, EventArgs e)
        {
            readTextFromImage();
        }

        private void readTextFromImage()
        {
            using TesseractEngine tesseractEngine = new TesseractEngine(tesseractDataPath, imageLanguage, EngineMode.Default);
            using Pix pix = Pix.LoadFromFile(tempImagePath);
            using Page page = tesseractEngine.Process(pix);
            {
                recognizedText = page.GetText().Trim();
            }

            richTextBox1.Text = recognizedText;

            File.Delete(tempImagePath);
        }

        private void cmbLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbLanguage.SelectedIndex)
            {
                case 0:
                    imageLanguage = "rus";
                    break;
                case 1:
                    imageLanguage = "eng";
                    break;
            }
        }
    }
}
