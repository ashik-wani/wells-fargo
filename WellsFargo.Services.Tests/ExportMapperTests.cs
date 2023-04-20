using WellsFargo.Services.Export;
using WellsFargo.Services.Types;

namespace WellsFargo.Services.Tests;

public class ExportMapperTests
{

    GenericList[] list = new GenericList[] {
     new GenericList
     {
      CUSIP="test",
       ISIN="ddd",
        Nominal = 22,
         OMS = OMS.AAA,
          PortfolioCode = "eee",
           Ticker = "ddd",
            TransactionType = "ddddd"
     },
      new GenericList
     {
      CUSIP="test",
       ISIN="ddd",
        Nominal = 22,
         OMS = OMS.BBB,
          PortfolioCode = "eee",
           Ticker = "ddd",
            TransactionType = "ddddd"
     }, new GenericList
     {
      CUSIP="test",
       ISIN="ddd",
        Nominal = 22,
         OMS = OMS.CCC,
          PortfolioCode = "eee",
           Ticker = "ddd",
            TransactionType = Constants.TRANSACTION_TYPE_BUY
     }
      , new GenericList
     {
      CUSIP="test",
       ISIN="ddd",
        Nominal = 22,
         OMS = OMS.CCC,
          PortfolioCode = "eee",
           Ticker = "ddd",
            TransactionType = "SELL"
     },
    };

    [Fact]
    public void MapAAATest()
    {
        //arrange
        var service = new ExportMapper();
        var aaa = list.Single(a => a.OMS == OMS.AAA);
        var expected = new AAAList {  ISIN = aaa .ISIN, PortfolioCode = aaa.PortfolioCode, Nominal = aaa.Nominal, TransactionType = aaa.TransactionType };
        //act
        var actual =  service.MapAAA(list);

        //assert
        actual.Count().Should().Be(1);
        actual.First().Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void MapBBBTest()
    {
        //arrange
        var service = new ExportMapper();
        var bbb = list.Single(a => a.OMS == OMS.BBB);
        var expected = new BBBList { CUSIP = bbb.CUSIP, PortfolioCode = bbb.PortfolioCode, Nominal = bbb.Nominal, TransactionType = bbb.TransactionType };
      
        //act
        var actual = service.MapBBB(list);

        //assert
        actual.Count().Should().Be(1);
        actual.First().Should().BeEquivalentTo(expected);
    }


    [Fact]
    public void MapCCCTest()
    {
        //arrange
        var service = new ExportMapper();
        var ccc = list.Single(a => a.OMS == OMS.CCC && a.TransactionType == Constants.TRANSACTION_TYPE_BUY);
        var expected = new CCCList { Ticker = ccc.Ticker, PortfolioCode = ccc.PortfolioCode, Nominal = ccc.Nominal, TransactionType = "B" };

        //act
        var actual = service.MapCCC(list);

        //assert
        actual.Count().Should().Be(1);
        actual.First().Should().BeEquivalentTo(expected);
    }
}