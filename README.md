# Archiver for WinRT

Archiver for WinRT is a powerful utility for compressing and decompressing files and folders. Up until now, managing compressed files has been a huge pain in WinRT and Windows 8. Moreover, using the built-in mechanism, you couldn't compress a folder with its subfolders and files.

Archiver makes compressing and decompressing amazingly easy, using just two lines of code:

    Archiver archiver = new Archiver();
    archiver.Compress(source, destination);
        
... where source and destination are the specified files and folders. You can run the included demo and test by yourselves.

## Compressing a single file

    private async void CompressFile()
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
    
## Compressing a folder

    private async void CompressFolder()
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
    
## Decompressing a zip file

    private async void Decompress()
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
    
That's it!

## Credits
* Developed by [Vangos Pterneas](http://pterneas.com) for [LightBuzz](http://lightbuzz.com)
* Folder compression partly based on a [tutorial by Jin Yanyun](http://www.rapidsnail.com/Tutorial/t/2012/116/40/23786/windows-and-development-winrt-to-zip-files-unzip-and-folder-zip-compression.aspx)

## License
You are free to use these libraries in personal and commercial projects by attributing the original creator of Vitruvius. Licensed under [Apache v2 License](https://github.com/LightBuzz/archiver-winrt/blob/master/LICENSE).

## Support Archiver
Do you use Vitruvius in your projects? Do you find it helpful? [Buy us a beer](https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=N5ELYBTYB3AYE)!
