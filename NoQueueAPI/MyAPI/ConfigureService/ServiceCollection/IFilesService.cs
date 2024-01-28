namespace MyAPI.ConfigureService.ServiceCollection
{
    public interface IFilesService
    {
        public Task<string?> GetFilePath(string? localFile,string? path);
        public Task<string?> GenerateQRForTables(string frontUrl, int branchId, int tableId);
    }
}
