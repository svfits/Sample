namespace SF.WebApi.BL.Services;

public class ReferenceService
{
    public int MyProperty { get; set; }

    public static (string, ReferenceService) Start()
    {
        var mainService = new ReferenceService
        {
            MyProperty = 1234
        };

        string rrrr = "до изменения";

        Changes(mainService, rrrr);

        return (rrrr, mainService);
    }

    private static void Changes(ReferenceService mainService, string rrrr)
    {
        rrrr = "изменится ли?";
        mainService.MyProperty = 99995;
    }
}
