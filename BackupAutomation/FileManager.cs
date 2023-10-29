using Microsoft.VisualBasic;

namespace BackupAutomation;

public static class BackupFileManager
{
    public static List<string> ReadContentsOfBackupFile(string folderPath)
    {
        DirectoryInfo backupDir  = new(folderPath);
        var fileInfo = backupDir.GetFiles();

        return fileInfo.Select(f => f.Name).ToList();
    }
}