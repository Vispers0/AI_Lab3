/*
 *    Экспертные системы и ИИ
 *    Лабораторная работа #3
 *    Распознавание текста с помощью Tesseract и OpenCV
 *    Выполнил: ст. гр. ИВТ-223 Степанов Александр
 */

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

            // Инициализация комбобокса, который отвечает за язык изображения
            cmbLanguage.Items.Add("rus");
            cmbLanguage.Items.Add("eng");
            cmbLanguage.SelectedItem = "rus";

            // Установка языка изображения по умолчанию
            imageLanguage = "rus";
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            // Настройка диалогового окна для открытия файла
            openFileDialog1.InitialDirectory = "C:\\";
            openFileDialog1.Filter = "" +
                "JPG files (*.jpg)|*.jpg|" +
                "JPEG files (*.jpeg)|*.jpeg|" +
                "PNG files (*.png)|*.png|" +
                "All files (*.*)|*.*";

            // Открытие диалогового окна и запись пути до изображения
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                imagePath = openFileDialog1.FileName;
            }

            if (imagePath == string.Empty)
            {
                MessageBox.Show("Файл не указан", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Вывод выбранного изображения в левом Picture Box
            selectedImage = Image.FromFile(imagePath);
            pictureBox1.Image = selectedImage;

            // Подготовка изображения к передаче в Tesseract и вывод обработанного изображения в правый PictureBox
            processedImage = ProcessImage(imagePath);
            pictureBox2.Image = processedImage;
        }

        // Обработка изображения
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

            // Масштабирование изображения, смена цветовой схемы на оттенки серого и бинаризация изображения методом Оцу
            Cv2.Resize(image, scaledImage, new OpenCvSharp.Size(), 3, 3, InterpolationFlags.Cubic);
            Cv2.CvtColor(image, grayImage, ColorConversionCodes.BGR2GRAY);
            Cv2.Threshold(grayImage, binaryImage, 0, 255, ThresholdTypes.Otsu);

            // Запись изображения во временный файл, чтобы избежать его блокировки при удалении
            Cv2.ImWrite(tempImagePath, binaryImage);

            //Получение обработанного изображения с помощью MemoryStream и его возвращение
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

        // Распознавание текста
        private void readTextFromImage()
        {
            /*
             * Инициализация движка Tesseract с помощью указания пути до языковых данных (*.traineddata), языка изображения и режима работы
             * Ранее сохранённое обработанное изображение загружается в объект класса Pix - внутренний формат файла Tesseract
             * Результат распознавания загружается в объект класса Page, а из него распознанный текст записывается в строку recognizedText
             * Использую using, чтобы гарантированно освободить все используемые ресурсы при завершении работы для корректной работы последующих распознаваний
             */
            using TesseractEngine tesseractEngine = new TesseractEngine(tesseractDataPath, imageLanguage, EngineMode.Default);
            using Pix pix = Pix.LoadFromFile(tempImagePath);
            using Page page = tesseractEngine.Process(pix);
            {
                recognizedText = page.GetText().Trim();
            }

            // Вывод в нижний RichTextBox распознанного текста
            richTextBox1.Text = recognizedText;

            // Удаление временного файла, т.е. обработанного изображения
            File.Delete(tempImagePath);
        }

        // Смена языка изображения
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
