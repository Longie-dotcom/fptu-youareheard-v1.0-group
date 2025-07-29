using Microsoft.Extensions.Configuration;
using System;
using System.ComponentModel;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Windows.Input;
using System.Windows;
using Microsoft.Win32;

namespace YouAreHeard.ViewModels
{
    public class StaffPostViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private string _title;
        private string _detail;
        private string? _imagePath;
        private BitmapImage? _imagePreview;

        private readonly string _serverApi = "https://youareheard.life";
        private readonly string _postControllerApi = "/api/blog";
        private readonly int _staffId;

        public StaffPostViewModel(int staffId)
        {
            _staffId = staffId;
            UploadCommand = new AsyncRelayCommand(UploadPostAsync);
            ChooseImageCommand = new RelayCommand(param => ChooseImage());
        }

        public string Title
        {
            get => _title;
            set { _title = value; OnPropertyChanged(); }
        }

        public string Detail
        {
            get => _detail;
            set { _detail = value; OnPropertyChanged(); }
        }

        public string? ImagePath
        {
            get => _imagePath;
            set
            {
                _imagePath = value;
                OnPropertyChanged();
                if (!string.IsNullOrEmpty(value))
                {
                    ImagePreview = new BitmapImage(new Uri(value));
                }
            }
        }

        public BitmapImage? ImagePreview
        {
            get => _imagePreview;
            private set { _imagePreview = value; OnPropertyChanged(); }
        }

        public ICommand UploadCommand { get; }
        public ICommand ChooseImageCommand { get; }

        private async Task UploadPostAsync()
        {
            if (string.IsNullOrWhiteSpace(Title) ||
                string.IsNullOrWhiteSpace(Detail) ||
                string.IsNullOrWhiteSpace(ImagePath))
            {
                MessageBox.Show("Bài viết phải có đầy đủ tiêu đề, nội dung và ảnh");
                return;
            }

            try
            {
                using var httpClient = new HttpClient();

                // 1. Upload image
                var formData = new MultipartFormDataContent();
                var imageBytes = File.ReadAllBytes(ImagePath);
                var imageContent = new ByteArrayContent(imageBytes);
                imageContent.Headers.ContentType = MediaTypeHeaderValue.Parse("image/jpeg");
                formData.Add(imageContent, "file", Path.GetFileName(ImagePath));

                var uploadResp = await httpClient.PostAsync($"{_serverApi}{_postControllerApi}/upload-image", formData);
                uploadResp.EnsureSuccessStatusCode();

                var uploadJson = await uploadResp.Content.ReadAsStringAsync();
                using var doc = JsonDocument.Parse(uploadJson);
                var imageName = doc.RootElement.GetProperty("fileName").GetString();

                // 2. Send blog metadata
                var blog = new
                {
                    title = Title,
                    details = Detail,
                    image = imageName,
                    userId = _staffId,
                    date = DateTime.UtcNow.ToString("o")
                };

                var json = JsonSerializer.Serialize(blog);
                var stringContent = new StringContent(json, Encoding.UTF8, "application/json");

                var blogResp = await httpClient.PostAsync($"{_serverApi}{_postControllerApi}/postblog", stringContent);
                blogResp.EnsureSuccessStatusCode();

                MessageBox.Show("Tạo bài viết thành công!", "Thành công", MessageBoxButton.OK, MessageBoxImage.Information);
                // Optional: clear form
                Title = "";
                Detail = "";
                ImagePath = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ChooseImage()
        {
            var dialog = new OpenFileDialog
            {
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif"
            };

            if (dialog.ShowDialog() == true)
            {
                ImagePath = dialog.FileName;
            }
        }

        private void OnPropertyChanged([CallerMemberName] string? propName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
