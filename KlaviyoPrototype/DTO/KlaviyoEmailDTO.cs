using System.Collections.Generic;

public class KlaviyoEmailDTO
{
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string AnimatedLogo { get; set; }
    public string OrderNumber { get; set; }
    public string DeliveryAddress { get; set; }
    public string PaymentType { get; set; }
    public string DateOfOrder { get; set; }
    public string DeliveryMethod { get; set; }
    public string Coins { get; set; }
    public List<Item> ItemList { get; set; }
}

public class Item
{
    public string ProductName { get; set; }
    public int Quantity { get; set; }
    public float Price { get; set; }
    public string Currency { get; set; }
}