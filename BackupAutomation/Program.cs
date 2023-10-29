using BackupAutomation;


string path = "/home/diogoaraldo/Notes/Backups";

List<string> files = BackupFileManager.ReadContentsOfBackupFile(path);

MenuHandler.DisplayOptions(files, path);
