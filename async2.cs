public record Model(int Value);

public interface IRepositiory
{
    IEnumerable<Model> GetModels();
}

public class AsyncClass
{
    private IRepository _repository;
    
    public Task<IEnumerable<Model>> GetFilteredModels()
    {
        // we can't do it, because Predicate is async
        return _repository.GetModels().Where(Predicate);
        
        // option1
        return _repository.GetModels().Where(x => Predicate(x).GetAwaiter().GetResult());
        
        // option2
        return _repository.GetModels().Where(x => Predicate(x).Result);
    }
    
    private async Task<bool> Predicate(Model model)
    {
        // some async filtering...
        return true;
    }
}