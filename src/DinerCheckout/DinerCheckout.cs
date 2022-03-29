namespace DinerCheckout;

class DinerCheckout
{
    BillStorage billStore = new BillStorage();

    VisaService visaService = new VisaService();
    private ReceiptMachine receiptMachine;

    public void Checkout(Order order){
        CalculateBill(order);
        Pay(order);
    }

    public void CalculateBill(Order order){
        Line("Thanks for Dining at FoodPlace");
        Bill b = new Bill();
        var calc = new BillCalculator();
        calc.SetOrder(order);
        Line(" ");
        Line("Items");
        foreach(LineItem item in order.Items){
            Line($"{item.Name} x{item.Num} \t {item.Price}");
        }
        int total = calc.CalculateItemTotal();
        int tax = calc.Tax();
        int gratuity = calc.Gratuity();
        Line($"Sub-total: {(double)total/100}");
        Line($"Tax: {(double)tax/100}");
        if(gratuity != 0){
            Line($"Gratuity (party of 10+): {(double)gratuity/100}");
        }
        b.Total = total;
        b.Tax = tax;
        b.Gratuity = gratuity;
        BillFinalTotal(b);
        Line($"Total: {(double)b.TaxTotal/100}");
        billStore.Save(b);
    }

    private void BillFinalTotal(Bill bill){
        bill.TaxTotal = bill.Total + bill.Tax + bill.Gratuity;
    }

    public void Pay(Order order){
        Bill bill = billStore.GetLastBill();
        if(order.PaymentMethod == "card"){
            visaService.Process(order.CardNumber, bill.TaxTotal);
        }
        else if(order.PaymentMethod == "cash"){
            return;
        }
    }


    private void Line(string line){
        receiptMachine.Print(line);
    }
}
