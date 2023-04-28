public record Model;

public class AsyncClass
{
    // ------------------ option 1 ------------------
    public async Task ProcessModel(Model? model)
    {
        if (model is null)
        {
            throw new ArgumentNullException(nameof(model));
        }

        // some processing...
        await Task.Delay(1000);
    }
    // ----------------------------------------------
    
    
    // ------------------ option 2 ------------------
    public Task ProcessModel(Model? model)
    {
        if (model is null)
        {
            throw new ArgumentNullException(nameof(model));
        }

        return ProcessModelInternal(model);
    }

    private async Task ProcessModelInternal(Model model)
    {
        // some processing...
        await Task.Delay(1000);
    }
    // -----------------------------------------------
}