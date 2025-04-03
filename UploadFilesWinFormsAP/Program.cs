using System.Configuration;
using UploadLib.Models;
using UploadLib.Repository;

namespace UploadFilesWinFormsAP
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //load config file
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            string containerName = config.AppSettings.Settings["AzureBlobContainerName"].Value;
            PictureRepository.ContainerName = containerName;
            PictureRepository.BlobConnectionString = config.AppSettings.Settings["AzureBlobContainer"].Value;
            PictureRepository.TableConnectionString = config.AppSettings.Settings["AzureTable"].Value;
            PictureRepository.CDNDomain = config.AppSettings.Settings["PicDomain"].Value;
            AlbumRepository.TableConnectionString = config.AppSettings.Settings["AzureTable"].Value;


            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm());
        }
    }
}