namespace RepositoryManager.Interfaces;

public interface IRepositoryManager<Tcontent, Ttype>{
    public void Register(string itemName, Tcontent itemContent, Ttype itemType);
    public Tcontent? Retrieve(string itemName);
    public Ttype? GetType(string itemName);
    public void Deregister(string itemName);
    public void Initialize();

    // public void Register(string itemName, RepositoryItem<Tcontent,Ttype> item);
}