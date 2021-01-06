using System;
using UnityEngine;

namespace Grochoska.ScriptableChannels
{
    public abstract class BaseGameChannel<T> : ScriptableObject
    {
        private Action<T> _action = delegate {  };

        public void Broadcast(T data)
        {
            _action?.Invoke(data);
        }

        public void Subscribe(Action<T> action)
        {
            _action += action;
        }
    
        public void Unsubscribe(Action<T> action)
        {
            _action -= action;
        }
    }
}