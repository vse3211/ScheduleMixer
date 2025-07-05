namespace ScheduleMixer.Services.StorageProvider;

public class MauiStoragePathProvider : IStoragePathProvider
{
    public string GetAppDataDirectory()
    {
        return FileSystem.AppDataDirectory;
    }
}