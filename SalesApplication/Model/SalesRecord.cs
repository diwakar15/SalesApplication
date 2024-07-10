namespace SalesApplication.Model
{
    public class SalesRecord
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public DateTime Date { get; set; }
        public string Region { get; set; }
      
        public decimal TotalSales { get; set; }
        public int TotalQuantity { get; set; }
        public decimal TotalRevenue { get; set; }

    }

}
