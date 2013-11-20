using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using Cirrious.CrossCore.Core;
using Cirrious.MvvmCross.ViewModels;

namespace FarFetched.Shared.Architecture
{
    public class FarFetchedViewModelBase : MvxViewModel
    {
       
        private Dictionary<string, List<Action>> _actionBindings = new Dictionary<string, List<Action>>();

        public event Action<string, string> RequestShowMessage;

        protected new void RaisePropertyChanged<T>(Expression<Func<T>> changedArgs)
        {
            //do normal UI updates
            base.RaisePropertyChanged(changedArgs);

            //now invoke any action bindings
            string propertyName = this.GetPropertyNameFromExpression(changedArgs);
            if (_actionBindings.ContainsKey(propertyName))
            {
                foreach (Action action in _actionBindings[propertyName])
                {
                    action.Invoke();
                }
            }
        }

        public void ShowMessage(string title, string message)
        {
            if (RequestShowMessage != null)
            {
                RequestShowMessage(title, message);
            }
        }

        public void RunOnUiThread(Action a)
        {
            base.InvokeOnMainThread(a);
        }

        public void SetActionBinding<T>(Expression<Func<T>> propertyExpression, Action action)
        {
            string propertyName = this.GetPropertyNameFromExpression(propertyExpression);

            if (!_actionBindings.ContainsKey(propertyName))
            {
                _actionBindings[propertyName] = new List<Action>();
            }

            _actionBindings[propertyName].Add(action);
        }
    }
}
