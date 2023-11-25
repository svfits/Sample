using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SF.WebApi.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF.WebApi.BL.Tests;

[TestClass()]
public class MapBLTests
{
    [TestMethod()]
    public void MapBLTest()
    {
        var cfg = new MapperConfiguration(expression => expression.AddProfile<MapBL>());
        cfg.AssertConfigurationIsValid();
    }
}