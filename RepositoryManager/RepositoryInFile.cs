using RepositoryManager.Interfaces;
using RepositoryManager.DataClasses;
using RepositoryManager.Exceptions;

public class RepositoryInFile : IRepository<string, int>
{
    protected Dictionary<string, RepositoryItem<string, int>>? _storage;
    protected FileStream? _filestorage;

    public RepositoryInFile(string path){
    }

    public bool AddEntry(string itemName, RepositoryItem<string, int> itemContent)
    {
        throw new NotImplementedException();
    }

    public void Dispose()
    {
        throw new NotImplementedException();
    }

    public bool GetContent(string itemName, out string? content)
    {
        throw new NotImplementedException();
    }

    public bool GetEntry(string itemName, out RepositoryItem<string, int>? entry)
    {
        throw new NotImplementedException();
    }

    public bool GetType(string itemName, out int type)
    {
        throw new NotImplementedException();
    }

    public bool RemoveEntry(string itemName)
    {
        throw new NotImplementedException();
    }
}