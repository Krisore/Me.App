using SQLite;

namespace Me.App.Core.DocumentsAgg;

public class Blob
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    [Indexed]
    public int DocumentId { get; set; }

    public string FileName { get; private set; } = string.Empty;
    public string FilePath { get; private set; } = string.Empty;
    public string MimeType { get; private set; } = string.Empty; 

    public DateTime UploadedAt { get; set; } = DateTime.UtcNow;

    public Blob() { }

    public Blob(string fileName, string filePath, string mimeType)
    {
        FileName = fileName;
        FilePath = filePath;
        MimeType = mimeType;
    }
}