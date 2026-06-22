using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Me.App.Core.DocumentsAgg;

public class Document
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public string Title { get; private set; }
    public string Content { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }
    public string Category { get; private set; } = string.Empty;


    [Ignore]
    public List<Blob> Blobs { get; private set; } = [];
    
    public bool WithVirtualCard { get; private set; }
    public Document()
    {

    }
    public Document( string title, string content)
    {
        Title = title;
        Content = content;
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
    }

    public virtual void UpdateContent(string newContent)
    {
        Content = newContent;
        UpdatedAt = DateTime.UtcNow;
    }


    public virtual void AddBlob(Blob blob)
    {
        Blobs.Add(blob);
    }

    public virtual void RemoveBlob(Blob blob) 
    {
        Blobs.Remove(blob);
    }
}
