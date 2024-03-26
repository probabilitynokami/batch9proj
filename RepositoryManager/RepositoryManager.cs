using RepositoryManager.Interfaces;
using RepositoryManager.DataClasses;
using RepositoryManager.Exceptions;
using System.ComponentModel.DataAnnotations;
namespace RepositoryManager;

public class RepositoryManager<Tcontent, Ttype> : IRepositoryManager<Tcontent, Ttype>
{
    private readonly IRepository<Tcontent,Ttype> _repository;
    private object _repositoryWriteLock = new();

    private IValidator<RepositoryItem<Tcontent,Ttype>>? _validator = null;

    private bool Validate(RepositoryItem<Tcontent,Ttype> content){
        if(_validator is null)
            return true;
        return _validator.IsValid(content);
    }

    public RepositoryManager(IRepository<Tcontent, Ttype> repository){
        _repository = repository;
    }

    public RepositoryManager(IRepository<Tcontent, Ttype> repository, IValidator<RepositoryItem<Tcontent,Ttype>> validator) : this(repository){
        _validator = validator;
    }


    public void Initialize(){}


    public void Register(string itemName, RepositoryItem<Tcontent, Ttype> item)
    {
        if (_repository.GetEntry(itemName, out _)){
            // throw exception when collision
            // I prefer "exit normal upon failure" style of programming,
            // but since the API's signature uses void,
            // we can't return the fail status.
            throw new InvalidOperationException(itemName + " is already in repository");
        }

        if (!Validate(item)){
            throw new FormatException("item is invalid");
        }

        bool success = false;

        lock(_repositoryWriteLock){
            success = _repository.AddEntry(itemName,item);
        }

        if(!success){
            throw new RepositoryFailWriteException("repository failed to register "+itemName);
        }
    }

    public void Register(string itemName, Tcontent itemContent, Ttype itemType)
    {
        Register(itemName, new RepositoryItem<Tcontent,Ttype>(itemContent,itemType));
    }


    public void Deregister(string itemName)
    {
        if(!_repository.GetEntry(itemName, out _)){
            throw new InvalidOperationException(itemName + " is not in repository");
        }

        bool status = false;
        lock(_repositoryWriteLock){
            status = _repository.RemoveEntry(itemName);
        }

        if(!status){
            throw new RepositoryFailWriteException("repository failed to deregister "+itemName);
        }
    }

    public Ttype? GetType(string itemName)
    {
        if(!_repository.GetType(itemName, out var ret)){
            throw new InvalidOperationException(itemName + " is not in repository");
        }
        return ret;
    }

    public Tcontent? Retrieve(string itemName)
    {
        if(!_repository.GetContent(itemName, out var ret)){
            throw new InvalidOperationException(itemName + " is not in repository");
        }
        return ret;
    }
}

