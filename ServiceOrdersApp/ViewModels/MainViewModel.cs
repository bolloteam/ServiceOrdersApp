using DAL;
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

        #region Variable Declaration
        private OrderCollection _orders = new OrderCollection();
        private Order _currentOrder;

        public OrderCollection Orders
        {
            get => _orders;
            set
            {
                _orders = value;
                if (value != null && value.Count > 0)
                {
                    CurrentOrder = value[0];
                }
                RaisePropertyChanged("Orders");
                RaisePropertyChanged("CanSendOrders");
            }
        }
        public Order CurrentOrder
        {
            get => _currentOrder;
            set
            {
                _currentOrder = value;
                RaisePropertyChanged("CurrentOrder");
            }
        }
        #endregion

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
            Orders = OrderDAO.GetAll();
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
            ShowOrderWindow(new Order() { StatusEnum = StatusEnum.Abierto, CreatedAt = DateTime.Now });
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
                CurrentOrder = (Order)obj;
                ShowOrderWindow(CurrentOrder);//Send Order ID
                //MessageBox.Show("Edit Order #N Form and sending selectedOrder");
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
                if (MessageBox.Show("Desea Eliminar la Orden?", "Advertencia", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    if (OrderDAO.Delete(((Order)obj).id))
                    {
                        MessageBox.Show("Orden Eliminada.");
                        ListOrders();
                    }
                    else
                        MessageBox.Show("Ocurrió un error al intentar guardar la orden, Consulte al administrador.");
                }
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
                return Orders.Count > 0;
            }
        }
        #endregion

        private void ShowOrderWindow(Order order)
        {
            var orderWindow = new OrderWindow(order);
            orderWindow.ShowDialog();
            ListOrders();
        }
    }
}