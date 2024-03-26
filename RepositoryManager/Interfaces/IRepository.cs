#nullable enable
using RepositoryManager.DataClasses;
namespace RepositoryManager.Interfaces;

public interface IRepository<Tcontent, Ttype> : IDisposable{
    public bool GetEntry(string itemName, out RepositoryItem<Tcontent, Ttype>? entry);
    public bool GetType(string itemName, out Ttype? type);
    public bool GetContent(string itemName, out Tcontent? content);
    public bool AddEntry(string itemName, RepositoryItem<Tcontent,Ttype> itemContent);
    public bool RemoveEntry(string itemName);
}
