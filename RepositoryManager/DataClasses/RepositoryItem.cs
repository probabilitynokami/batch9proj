namespace RepositoryManager.DataClasses;

public class RepositoryItem<Tcontent, Ttype> {
    public RepositoryItem(Tcontent content, Ttype type){
        Content = content;
        Type = type;
    }
    public Tcontent Content{get;set;}
    public Ttype Type{get;set;}
}


