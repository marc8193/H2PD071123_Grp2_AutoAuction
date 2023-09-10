namespace AutoAuctionProjekt
{
    public interface ISeller
    {
        public string UserName { get; set; }
        decimal Balance { get; set; }
        uint Zipcode { get; set; }

        string ReceiveBidNodification(string message);
    }
}
