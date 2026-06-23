using SQLite;
using System;
using System.Collections.Generic;

namespace Me.App.Core.DocumentsAgg;

public class Document
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public string Category { get; set; } = string.Empty;

    [Ignore]
    public List<Blob> Blobs { get; set; } = new();

    public bool WithVirtualCard { get; set; }

    // Required for SQLite
    public Document() { }

    public Document(string title, string description, string category)
    {
        Title = title;
        Description = description; 
        Category = category;
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
    }
    public virtual void UpdateDescription(string newDescription)
    {
        Description = newDescription;
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