using Me.App.Core.DocumentsAgg;
using System;
using System.Collections.Generic;
using System.Text;

namespace Me.App.Infrastructure.Services
{
    internal sealed class DocumentService(MeDataBase meDataBase) : IDocumentService
    {
        private readonly MeDataBase _meDataBase = meDataBase;

        public async Task SaveDocumentAsync(Document doc)
        {
            var _db = await _meDataBase.GetConnectionAsync();
            if (doc.Id != 0) await _db!.UpdateAsync(doc);
            else await _db!.InsertAsync(doc);
        }
        public async Task<List<Document>> GetAllDocumentsAsync()
        {
            var _db = await _meDataBase.GetConnectionAsync();
            return await _db!.Table<Document>()
                             .OrderByDescending(d => d.UpdatedAt)
                             .ToListAsync();
        }
    }
}
