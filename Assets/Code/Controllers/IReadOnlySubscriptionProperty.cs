using System;

namespace Snake.Tools
{
    public interface IReadOnlySubscriptionProperty<T>
    {
        T Value { get; }
        void SubscribeOnChange(Action<T> action);
        void UnSubscribeOnChange(Action<T> action);

    }
}