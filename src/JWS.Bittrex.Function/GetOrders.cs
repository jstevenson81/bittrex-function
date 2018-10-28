using System;
using System.Threading.Tasks;
using JWS.Bittrex.Api;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;

namespace JWS.Bittrex.Function
{
    public static class GetOrders
    {
        [FunctionName("GetOrders")]
        public static async Task Run([TimerTrigger("*/10 * * * * *")]TimerInfo myTimer, TraceWriter log)
        {
            var key = Environment.GetEnvironmentVariable("Bittrex.ApiKey");
            var secret = Environment.GetEnvironmentVariable("Bittrex.ApiSecret");

            var api = new BittrexClient(key, secret);

            //var orderHistory = await api.GetOrderHistory();
            var balances = await api.GetBalances();

            //foreach (var o in orderHistory.Result)
            //{
            //    log.Info($"{Helper.GetTargetCurrencyFromMarketName(o.Exchange)} {o.Exchange} {o.Price} {o.Commission} {o.Price}.");
            //}

            foreach (var bal in balances.Result)
            {
                log.Info($"{bal.Currency}: {bal.Balance}, reserved: {bal.Balance - bal.Available}");
            }

        }
    }

}
