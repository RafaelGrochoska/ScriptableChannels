using System;
using UnityEngine;

namespace Grochoska.ScriptableChannels
{
    [CreateAssetMenu(menuName = "Game channel/Void", order = 100)]
    public sealed class VoidChannel : ScriptableObject
    {
        private Action _action = delegate {  };

        public void Broadcast()
        {
            _action?.Invoke();
        }

        public void Subscribe(Action action)
        {
            _action += action;
        }
    
        public void Unsubscribe(Action action)
        {
            _action -= action;
        } 
    }
}