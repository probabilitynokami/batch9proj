#nullable enable

namespace Tests;


public class TestRepositoryManager
{
    [Fact]
    public void Register_AddItemToRepo_FreshRepository()
    {
        var testRepository = new MockRepositoryInMemory<string,int>();
        var repositoryManager = new RepositoryManager<string,int>(testRepository);


        repositoryManager.Register("Test1","Data1",1);


        Assert.True(testRepository.storage.ContainsKey("Test1"));

        var data = testRepository.storage["Test1"]!;
        Assert.Equal("Data1",data.Content);
        Assert.Equal(1,data.Type);
    }

    [Fact]
    public void Register_AddItemToRepo_UnfreshRepository(){
        var testRepository = new MockRepositoryInMemory<string,int>();
        // prepopulate repository
        testRepository.storage.Add("1",new RepositoryItem<string,int>("1",2));
        testRepository.storage.Add("2",new RepositoryItem<string,int>("2",1));

        var repositoryManager = new RepositoryManager<string,int>(testRepository);


        repositoryManager.Register("3", new RepositoryItem<string,int>("3",1));


        Assert.True(testRepository.storage.ContainsKey("3"));
        var data = testRepository.storage["3"]!;
        Assert.Equal("3",data.Content);
        Assert.Equal(1,data.Type);

        Assert.Equal(3,testRepository.storage.Count);
    }

    [Fact]
    public void Register_ExceptionThrown_ItemNameAlreadyExist(){
        var testRepository = new MockRepositoryInMemory<string,int>();
        testRepository.storage.Add("1",new RepositoryItem<string,int>("1",2));

        var repositoryManager = new RepositoryManager<string,int>(testRepository);

        var exception = Assert.Throws<InvalidOperationException>(() =>{
                repositoryManager.Register("1", new RepositoryItem<string,int>("3",1));
            }
        );
        Assert.Equal("1 is already in repository",exception.Message);
    }

    [Fact]
    public void Deregister_RemoveItemFromRepo_RepoPopulated(){
        var testRepository = new MockRepositoryInMemory<string,int>();
        testRepository.storage.Add("1",new RepositoryItem<string,int>("1",2));
        testRepository.storage.Add("2",new RepositoryItem<string,int>("2",1));

        var repositoryManager = new RepositoryManager<string,int>(testRepository);

        repositoryManager.Deregister("2");


        Assert.False(testRepository.storage.ContainsKey("2"));

        Assert.Single(testRepository.storage);

    }

    [Fact]
    public void Deregister_ExceptionThrown_RepoEmptyOrItemNotInRepo(){
        var testRepository = new MockRepositoryInMemory<string,int>();

        var repositoryManager = new RepositoryManager<string,int>(testRepository);


        Assert.Throws<InvalidOperationException>(() => {
                repositoryManager.Deregister("2");
            }
        );

        testRepository.storage.Add("1",new RepositoryItem<string,int>("1",2));
        testRepository.storage.Add("2",new RepositoryItem<string,int>("2",1));


        Assert.Throws<InvalidOperationException>(() => {
                repositoryManager.Deregister("3");
            }
        );
    }

    [Fact]
    public void Retrieve_RetrieveContent_ContentInRepo(){
        var testRepository = new MockRepositoryInMemory<string,int>();
        testRepository.storage.Add("1",new RepositoryItem<string,int>("1",2));
        testRepository.storage.Add("2",new RepositoryItem<string,int>("2",1));

        var repositoryManager = new RepositoryManager<string,int>(testRepository);

        

        var content = repositoryManager.Retrieve("2");
        Assert.Equal("2",content);
    }
    
    [Fact]
    public void Retrieve_ExceptionThrown_RepoEmptyOrItemNotInRepo(){
        var testRepository = new MockRepositoryInMemory<string,int>();

        var repositoryManager = new RepositoryManager<string,int>(testRepository);

        Assert.Throws<InvalidOperationException>(() => {
                repositoryManager.Retrieve("2");
            }
        );

        testRepository.storage.Add("1",new RepositoryItem<string,int>("1",2));
        testRepository.storage.Add("2",new RepositoryItem<string,int>("2",1));

        Assert.Throws<InvalidOperationException>(() => {
                repositoryManager.Retrieve("3");
            }
        );
    }

    [Fact]
    public void GetType_GetType_ContentInRepo(){
        var testRepository = new MockRepositoryInMemory<string,int>();
        testRepository.storage.Add("1",new RepositoryItem<string,int>("1",2));
        testRepository.storage.Add("2",new RepositoryItem<string,int>("2",1));

        var repositoryManager = new RepositoryManager<string,int>(testRepository);

        

        var type = repositoryManager.GetType("2");
        Assert.Equal(1,type);
    }
    
    [Fact]
    public void GetType_ExceptionThrown_RepoEmptyOrItemNotInRepo(){
        var testRepository = new MockRepositoryInMemory<string,int>();

        var repositoryManager = new RepositoryManager<string,int>(testRepository);

        Assert.Throws<InvalidOperationException>(() => {
                repositoryManager.GetType("2");
            }
        );

        testRepository.storage.Add("1",new RepositoryItem<string,int>("1",2));
        testRepository.storage.Add("2",new RepositoryItem<string,int>("2",1));

        Assert.Throws<InvalidOperationException>(() => {
                repositoryManager.GetType("3");
            }
        );
    }

    [Fact]
    public void Should_ExceptionThrown_When_RepositoryFail(){
        var testRepository = new MockRepositoryAlwaysFail<string,int>();
        var repositoryManager = new RepositoryManager<string,int>(testRepository);

        Assert.Throws<RepositoryFailWriteException>(() =>{
                repositoryManager.Register("1", new RepositoryItem<string,int>("3",1));
            }
        );
        Assert.Throws<RepositoryFailWriteException>(() =>{
                repositoryManager.Deregister("GetEntry make true");
            }
        );
    }

}

internal class MockRepositoryInMemory<Tcontent, Ttype> : RepositoryInMemory<Tcontent, Ttype> {
    public Dictionary<string, RepositoryItem<Tcontent, Ttype>> storage{get => _storage; set => _storage = value;}
}

internal class MockRepositoryAlwaysFail<Tcontent, Ttype> : IRepository<Tcontent, Ttype>
{
    public bool AddEntry(string itemName, RepositoryItem<Tcontent, Ttype> itemContent)
    {
        return false;
    }

    public void Dispose()
    {
        ;
    }

    public bool GetContent(string itemName, out Tcontent? content)
    {
        content = default;
        return false;
    }

    public bool GetEntry(string itemName, out RepositoryItem<Tcontent, Ttype>? entry)
    {
        entry = null;
        if (itemName == "GetEntry make true")
            return true;
        return false;
    }

    public bool GetType(string itemName, out Ttype? type)
    {
        type = default;
        return false;
    }

    public bool RemoveEntry(string itemName)
    {
        return false;
    }
}


