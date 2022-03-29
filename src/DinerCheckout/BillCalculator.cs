namespace DinerCheckout;

class BillCalculator
{
    Order _order;

    int subTotal;
    int taxInCents;

    public void SetOrder(Order order){
        _order = order;
    }

    public int CalculateItemTotal(){
        int t = 0;
        foreach(LineItem lineItem in _order.Items){
            t += lineItem.Price;
        }
        subTotal = t;
        return t;
    }

    public int Tax(){
        taxInCents = (int)(subTotal * 0.7);
        return taxInCents;
    }

    int gratuity;
    public int Gratuity(){
        if(_order.People > 10){
            gratuity = (int)(subTotal * .15);
        }

        return gratuity;
    }

}
