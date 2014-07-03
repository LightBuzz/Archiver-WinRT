using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using LightBuzz.Archiver;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace LightBuzz.Archiver.Demo
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void CompressFile_Tapped(object sender, TappedRoutedEventArgs e)
        {
            FileOpenPicker filePickerSource = new FileOpenPicker();
            filePickerSource.FileTypeFilter.Add("*");
            filePickerSource.SuggestedStartLocation = PickerLocationId.ComputerFolder;

            StorageFile source = await filePickerSource.PickSingleFileAsync();

            if (source != null)
            {
                FileSavePicker filePickerDestination = new FileSavePicker();

                filePickerDestination.FileTypeChoices.Add("Zip files (*.zip)", new List<string> { ".zip" });
                filePickerDestination.SuggestedFileName = "Backup";
                filePickerSource.SuggestedStartLocation = PickerLocationId.ComputerFolder;

                StorageFile destination = await filePickerDestination.PickSaveFileAsync();

                if (destination != null)
                {
                    Archiver archiver = new Archiver();
                    archiver.Compress(source, destination);
                }
            }
        }

        private async void CompressFolder_Tapped(object sender, TappedRoutedEventArgs e)
        {
            FolderPicker folderPicker = new FolderPicker();
            folderPicker.FileTypeFilter.Add("*");
            folderPicker.SuggestedStartLocation = PickerLocationId.ComputerFolder;

            StorageFolder source = await folderPicker.PickSingleFolderAsync();

            if (source != null)
            {
                FileSavePicker filePicker = new FileSavePicker();

                filePicker.FileTypeChoices.Add("Zip files (*.zip)", new List<string> { ".zip" });
                filePicker.SuggestedFileName = "Backup";
                filePicker.SuggestedStartLocation = PickerLocationId.ComputerFolder;

                StorageFile destination = await filePicker.PickSaveFileAsync();

                if (destination != null)
                {
                    Archiver archiver = new Archiver();
                    archiver.Compress(source, destination);
                }
            }
        }

        private async void DecompressFile_Tapped(object sender, TappedRoutedEventArgs e)
        {
            FileOpenPicker filePicker = new FileOpenPicker();
            filePicker.FileTypeFilter.Add(".zip");
            filePicker.SuggestedStartLocation = PickerLocationId.ComputerFolder;

            StorageFile source = await filePicker.PickSingleFileAsync();

            if (source != null)
            {
                FolderPicker folderPicker = new FolderPicker();
                folderPicker.FileTypeFilter.Add("*");
                folderPicker.SuggestedStartLocation = PickerLocationId.ComputerFolder;

                StorageFolder destination = await folderPicker.PickSingleFolderAsync();

                if (destination != null)
                {
                    Archiver archiver = new Archiver();
                    archiver.Decompress(source, destination);
                }
            }
        }
    }
}
