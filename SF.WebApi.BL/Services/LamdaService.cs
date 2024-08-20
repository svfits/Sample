using System;
using System.Diagnostics;

namespace SF.WebApi.BL.Services;

public interface ILambdaService
{
    void RunAction();

    void RunFunc();
}

public class LambdaService : ILambdaService
{
    public void RunAction()
    {
        StartAction(a =>
        {
            a.MyProperty = 8;
            a.MyProperty2 = 7;
            a.MyProperty3 = 6;
        });
    }

    /// <summary>
    /// Тут произойдет заполнение объекта myClass
    /// </summary>
    /// <param name="action"></param>
    private static void StartAction(Action<MyClass> action)
    {
        var myClass = new MyClass();
        action(myClass);
    }

    private readonly Func<int, int, bool> finder = delegate (int s, int i) { return s > i; };

    public void RunFunc()
    {
        StartFunc(finder);
    }

    private static (bool result, bool result1) StartFunc(Func<int, int, bool> finder)
    {
        var result = finder(23, 45);
        var result2 = finder(45, 23);
        return (result, result2);
    }
}

public class MyClass
{
    public int MyProperty { get; set; }

    public int MyProperty2 { get; set; }

    public int MyProperty3 { get; set; }

    public static void Method(int v) => Debug.WriteLine(v);
}
