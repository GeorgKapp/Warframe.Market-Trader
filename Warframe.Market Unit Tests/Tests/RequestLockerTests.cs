using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;
using Warframe.Market_Api.Clients.Implementation;
using static Warframe.Market_Api.Clients.Implementation.RequestLocker;

namespace Warframe.Market_Unit_Tests
{
    [TestClass]
    public class RequestLockerTests
    {
        [TestMethod("Test limiting of requests")]
        [DataRow(TimeUnit.Second, 3, 30)]
        [DataRow(TimeUnit.Minute, 10, 10)]
        public async Task TestRequestLocking(TimeUnit unitOfTime, int requestLimit, int numerOfRequests)
        {
            DateTime startDate = DateTime.Now;
            RequestLocker locker = new RequestLocker(unitOfTime, requestLimit);
            for(int i = 0; i < numerOfRequests; i++)
            {
                await locker.ReleaseAsync();
            }
            DateTime endDate = DateTime.Now;

            var difference = endDate - startDate;
            var allowedTime = numerOfRequests / requestLimit;

            switch(unitOfTime)
            {
                case TimeUnit.Second: Assert.IsTrue(difference.TotalSeconds >= allowedTime); break;
                case TimeUnit.Minute: Assert.IsTrue(difference.TotalMinutes >= allowedTime); break;
                default:
                    throw new NotImplementedException("Test check for this timeunit not implemented yet");
            }
        }
    }
}
