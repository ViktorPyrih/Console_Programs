using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Lab_OOP_wpf.ua.cdu.edu.vu.view_model.helper
{
    public abstract class ViewHelper<T>
    {

        private static readonly string QUESTION = "Would you like to save changes?";

        protected ViewHelper() 
        {
        }

        public abstract bool ValidateRecord();

        protected abstract bool IsRecordEmpty();

        public abstract T ConvertRecord();

        public abstract void CLear();

        public bool OnClose(Action<T> beforeCloseAction, string caption) 
        {
            if (!IsRecordEmpty())
            {
                MessageBoxResult result = MessageBox.Show(QUESTION, caption, MessageBoxButton.YesNoCancel);
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        if (!ValidateRecord()) 
                        {
                            return true;
                        }
                        beforeCloseAction.Invoke(ConvertRecord());
                        break;
                    case MessageBoxResult.No:
                        break;
                    default:
                        return true;
                }
            }

            return false;
        }
    }
}
