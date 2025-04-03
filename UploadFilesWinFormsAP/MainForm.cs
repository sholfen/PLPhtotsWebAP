using UploadLib.Models;
using UploadLib.Repository;
using UploadLib.Services;

namespace UploadFilesWinFormsAP
{
    public partial class MainForm : Form
    {
        private readonly IPictureAppService _pictureAppService;
        private List<FileInfo> _fileInfos;

        public MainForm()
        {
            _pictureAppService = new PictureAppService(new PictureRepository());

            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnSelectImgs_Click(object sender, EventArgs e)
        {
            var dialogResult = openImgFileDialog.ShowDialog(this);
            Console.WriteLine($"總共有{openImgFileDialog.FileNames.Length}個檔案要上傳");
            if (dialogResult == DialogResult.OK)
            {
                Console.WriteLine("開始上傳檔案...");
                List<FileInfo> fileInfos = new List<FileInfo>();
                txtMessage.Text = string.Empty;
                foreach (var file in openImgFileDialog.FileNames)
                {
                    var fileInfo = new FileInfo(file);
                    fileInfos.Add(fileInfo);
                    txtMessage.Text += $"{fileInfo.Name} \r\n";
                }
                _fileInfos = fileInfos;        
                Console.WriteLine("開始上傳結束...");
            }
        }

        private async void btnUpload_Click(object sender, EventArgs e)
        {
            await _pictureAppService.ResizePic(_fileInfos);
            Console.WriteLine("上傳完成");
        }
    }
}
