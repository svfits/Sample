namespace SF.WebApi.BL.Services;

public interface IMainService
{
    List<int> Run();
}

public class MainService : IMainService
{
    public List<int> Run()
    {
        var list = new List<int>() { 10, 15, 20 };
        int i = 10;
        var query = list.Where(x => x >= i);
        i = 15;
        var result = query.ToList();

        return result;
    }
}
