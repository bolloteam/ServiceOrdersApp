using ServiceOrdersApp.Core.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows;

namespace ServiceOrdersApp.ViewModels
{
    public class OrderViewModel : IGeneric
    {

        public OrderViewModel()
        {

        }

        #region SaveOrder
        private ICommand _saveOrderCommand;
        public ICommand SaveOrderCommand
        {
            get
            {
                if (_saveOrderCommand == null)
                    _saveOrderCommand = new RelayCommand(new Action(SaveOrder));
                return _saveOrderCommand;
            }
        }
        private void SaveOrder()
        {
            MessageBox.Show("Try Save Data");
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
            ((Window)win).DialogResult = true;
            ((Window)win).Close();
        }
        private bool CanClose
        {
            get
            {
                return true;
            }
        }
        #endregion

    }
}

