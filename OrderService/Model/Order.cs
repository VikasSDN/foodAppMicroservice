namespace OrderService.Model
{
    public class Order
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int RestaurantId { get; set; }
        public DateTime OrderTime { get; set; }
        public string DeliveryStatus { get; set; }
        public List<OrderItem> OrderItems { get; set; }
    }

    public class OrderItem
    {
        public int Id { get; set; }
        public string ItemName { get; set; }
        public decimal Price { get; set; }
    }

}
