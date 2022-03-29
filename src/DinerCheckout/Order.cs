namespace DinerCheckout;

class Order{
    public List<LineItem> Items {get; set;}
    public int People {get; set;} 
    public string PaymentMethod {get; set;}
    public string CardNumber {get; set;}
}
