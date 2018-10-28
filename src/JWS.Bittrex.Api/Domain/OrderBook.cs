using System.Collections.Generic;

namespace JWS.Bittrex.Api.Domain
{
    public class OrderBook
    {
        public string MarketName { get; set; }
        public IEnumerable<OrderBookEntry> Buy { get; set; }
        public IEnumerable<OrderBookEntry> Sell { get; set; }
    }
}
