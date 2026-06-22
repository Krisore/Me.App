using System;
using System.Collections.Generic;
using System.Text;

namespace Me.App.Core.DocumentsAgg
{
    public interface IDocumentService
    {
        Task SaveDocumentAsync(Document doc);
        Task<List<Document>> GetAllDocumentsAsync();
    }
}
