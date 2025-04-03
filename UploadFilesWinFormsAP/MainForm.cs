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
            Console.WriteLine($"�`�@��{openImgFileDialog.FileNames.Length}���ɮ׭n�W��");
            if (dialogResult == DialogResult.OK)
            {
                Console.WriteLine("�}�l�W���ɮ�...");
                List<FileInfo> fileInfos = new List<FileInfo>();
                txtMessage.Text = string.Empty;
                foreach (var file in openImgFileDialog.FileNames)
                {
                    var fileInfo = new FileInfo(file);
                    fileInfos.Add(fileInfo);
                    txtMessage.Text += $"{fileInfo.Name} \r\n";
                }
                _fileInfos = fileInfos;        
                Console.WriteLine("�}�l�W�ǵ���...");
            }
        }

        private async void btnUpload_Click(object sender, EventArgs e)
        {
            await _pictureAppService.ResizePic(_fileInfos);
            Console.WriteLine("�W�ǧ���");
        }
    }
}
