using ServiceOrdersApp.Core.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows;
using DAL;

namespace ServiceOrdersApp.ViewModels
{
    public class OrderViewModel : IGeneric
    {
        private Order _original;
        private Order _order;// = new Order();
        private Visibility _isCreate;// = Visibility.Hidden;
        public Order Order
        {
            get => _order;
            set
            {
                _order = value;
            }
        }
        public Visibility IsCreate
        {
            get => _isCreate;
            set
            {
                _isCreate = value;
                RaisePropertyChanged("IsCreate");
            }
        }
        public OrderViewModel() { }
        public OrderViewModel(Order order)
        {
            _original = order;
            Order = new Order()
            {
                id = order.id,
                CustomerName = order.CustomerName,
                Description = order.Description,
                StatusEnum = order.StatusEnum,
                CreatedAt = order.CreatedAt,
                Status = order.Status
            };
            IsCreate = (order.id == 0)? Visibility.Hidden : Visibility.Visible;
        }

        #region SaveOrder
        private ICommand _saveOrderCommand;
        public ICommand SaveOrderCommand
        {
            get
            {
                if (_saveOrderCommand == null)
                    _saveOrderCommand = new ParamCommand(new Action<object>(SaveOrder));
                return _saveOrderCommand;
            }
        }
        private void SaveOrder(object win)
        {
            string message = (Order.id == 0) ? "Order Creada Con Éxito." : "Ordern modificada con Éxito.";
            if (OrderDAO.Save(Order))
                MessageBox.Show(message);
            else
                MessageBox.Show("Ocurrió un error al intentar guardar la orden, Consulte al administrador.");

            CloseWindow((Window)win);
        }
        #endregion

        #region CancelOrder
        private ICommand _cancelOrderCommand;
        public ICommand CancelOrderCommand
        {
            get
            {
                if (_cancelOrderCommand == null)
                    _cancelOrderCommand = new ParamCommand(new Action<object>(CancelOrder), () => CanClose);
                return _cancelOrderCommand;
            }

        }
        private void CancelOrder(object win)
        {
            if (PromptMessage("Desea salir sin guardar los cambios ?", "Confirmación"))
                CloseWindow((Window)win);
        }
        private bool CanClose
        {
            get
            {
                return true;
            }
        }
        #endregion

        private void CloseWindow(Window win)
        {
            win.DialogResult = true;
            win.Close();
        }

        private bool PromptMessage(string message, string title)
        {
            if (MessageBox.Show(message,
                title, MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                return true;
            }
            return false;
        }
    }
}

