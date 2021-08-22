using System;
using System.Collections.Generic;

namespace Command.DesignPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            StockManager sm = new StockManager();
            BuyStock bStock = new BuyStock(sm);
            SellStock sStock = new SellStock(sm);

            StockController controller = new StockController();
            controller.TakeOrder(bStock);
            controller.TakeOrder(sStock);
            controller.TakeOrder(bStock);
            controller.PlaceOrders();


        }
    }
    class StockManager
    {
        private string _name = "Laptop";
        private int _quantity = 50;
        public void Buy()
        {
            Console.WriteLine("Stock:{0},{1} bought", _name, _quantity);
        }
        public void Sell()
        {

        }
    }

    interface IOrder
    {
        void Execute();
    }

    class Order
    {

    }

    class BuyStock : IOrder
    {
        protected StockManager _stockManager;
        public BuyStock(StockManager stockManager)
        {
            _stockManager = stockManager;
        }

        public void Execute()
        {
            _stockManager.Buy();
        }
    }

    class SellStock : IOrder
    {
        protected StockManager _stockManager;
        public SellStock(StockManager stockManager)
        {
            _stockManager = stockManager;
        }
        public void Execute()
        {
            _stockManager.Sell();
        }
    }
    
    class StockController
    {
        List<IOrder> _orders = new List<IOrder>();
        public void TakeOrder(IOrder order)
        {
            _orders.Add(order);
        }
        public void PlaceOrders()
        {
            foreach (var order in _orders)
            {
                order.Execute();
            }
            _orders.Clear();
        }
    }
}
