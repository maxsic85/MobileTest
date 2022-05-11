using System;

namespace Snake.Tools
{
    public class SubscriptionProperty<T>:IReadOnlySubscriptionProperty<T>
    {
        private T _value;
        private Action<T> OnChangeValue;

        public T Value
        {
            get => _value;
            set 
            {
                _value = value;
                OnChangeValue?.Invoke(_value);
            }
        }

        public void SubscribeOnChange(Action<T> subscritionAction)
        {
            OnChangeValue += subscritionAction;
        }
        public void UnSubscribeOnChange(Action<T> subscritionAction)
        {
            OnChangeValue -= subscritionAction;
        }
    }
}