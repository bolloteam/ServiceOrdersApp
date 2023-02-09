using ServiceOrdersApp.Core.Commands;
using ServiceOrdersApp.Views;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ServiceOrdersApp.ViewModels
{
    public class MainViewModel : IGeneric
    {

        public MainViewModel()
        {

        }

        #region OrderList
        private ICommand _orderListCommand;
        public ICommand OrderListCommand
        {
            get
            {
                if (_orderListCommand == null)
                {
                    _orderListCommand = new RelayCommand(new Action(ListOrders));
                }
                return _orderListCommand;
            }
        }

        private void ListOrders()
        {
            
        }
        #endregion

        #region CreateOrder
        private ICommand _createOrder;
        public ICommand CreateOrderCommand
        {
            get
            {
                if (_createOrder == null)
                    _createOrder = new RelayCommand(new Action(CreateOrder));
                return _createOrder;
            }
        }
        private void CreateOrder()
        {
            ShowOrderWindow();
        }
        #endregion

        #region UpdateOrder
        private ICommand _updateOrder;
        public ICommand UpdateOrderCommand
        {
            get
            {
                if (_updateOrder == null)
                    _updateOrder = new ParamCommand(new Action<object>(UpdateOrder));
                return _updateOrder;
            }
        }
        private void UpdateOrder(object obj)
        {

            if (obj != null)
            {
                ShowOrderWindow();//Send Order ID
                MessageBox.Show("Edit Order #N Form and sending selectedOrder");
            }

        }

        #endregion

        #region DeleteOrder
        private ICommand _deleteOrder;
        public ICommand DeleteOrderCommand
        {
            get
            {
                if (_deleteOrder == null)
                    _deleteOrder = new ParamCommand(new Action<object>(DeleteOrder));
                return _deleteOrder;
            }
        }
        private void DeleteOrder(object obj)
        {
            if (obj != null)
            {
            }

        }

        #endregion

        #region SendOrders
        private ICommand _sendOrders;
        public ICommand SendOrdersCommand
        {
            get
            {
                if (_sendOrders == null)
                    _sendOrders = new RelayCommand(new Action(SendOrders), () => CanSendOrders);
                return _sendOrders;
            }
        }
        private void SendOrders()
        {
            MessageBox.Show("Send Selected Order");
        }
        private bool CanSendOrders
        {
            get
            {
                return true;
            }
        }
        #endregion

        private void ShowOrderWindow()
        {
            var orderWindow = new OrderWindow();
            orderWindow.ShowDialog();
        }
    }
}