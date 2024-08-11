using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF.WebApi.BL.Services;

public interface ILambdaService
{
    void RunAction();
}

public class LambdaService : ILambdaService
{
    public void RunAction()
    {
        Start(a =>
        {
            a.MyProperty = 8;
            a.MyProperty2 = 7;
            a.MyProperty3 = 6;
            a.Method(234);
        });
    }

    /// <summary>
    /// Тут произойдет заполнение объекта myClass
    /// </summary>
    /// <param name="action"></param>
    private static void Start(Action<MyClass> action)
    {
        var myClass = new MyClass();
        action(myClass);
    }
}

public class MyClass
{
    public int MyProperty { get; set; }

    public int MyProperty2 { get; set; }

    public int MyProperty3 { get; set; }

    public void Method(int v)
    {
        Debug.WriteLine(v);
    }
}
