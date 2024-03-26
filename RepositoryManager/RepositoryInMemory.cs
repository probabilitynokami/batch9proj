using RepositoryManager.Interfaces;
using RepositoryManager.DataClasses;
using RepositoryManager.Exceptions;
namespace RepositoryManager;

public class RepositoryInMemory<Tcontent, Ttype> : IRepository<Tcontent, Ttype>
{
    protected Dictionary<string, RepositoryItem<Tcontent, Ttype>> _storage;

    public RepositoryInMemory(){
        _storage = [];
    }
    public bool AddEntry(string itemName, RepositoryItem<Tcontent, Ttype> itemContent)
    {
        if(_storage.ContainsKey(itemName))
            return false;

        _storage[itemName] = itemContent;
        return true;
    }

    public void Dispose()
    {
        // no resource to dispose for repository in memory
    }


    public bool GetEntry(string itemName,out RepositoryItem<Tcontent, Ttype> repositoryItem)
    {
        return _storage.TryGetValue(itemName, out repositoryItem!);
    }

    public bool GetType(string itemName, out Ttype? type)
    {
        // use GetEntry because the cost of getting
        // type/content only and getting them at once
        // is virtually the same

        var ret = GetEntry(itemName, out var entry);

        if(ret){
            type = entry.Type;
            return true;
        }

        type = default!; 
        return false;
    }

    public bool GetContent(string itemName, out Tcontent? content)
    {
        var status = GetEntry(itemName, out var entry);

        if (status){
            content = entry.Content;
            return true;
        }

        content = default;
        return false;
    }

    public bool RemoveEntry(string itemName)
    {
        return _storage.Remove(itemName);
    }
}