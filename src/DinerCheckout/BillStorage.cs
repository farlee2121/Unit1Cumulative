namespace DinerCheckout;

class BillStorage{
    private List<Bill> bills = new List<Bill>();
    public void Save(Bill bill){
        bills.Add(bill);
    }
    public Bill GetLastBill(){
        return bills.LastOrDefault();
    }
}
