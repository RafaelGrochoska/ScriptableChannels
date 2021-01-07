using UnityEngine;
using UnityEngine.Events;

namespace Grochoska.ScriptableChannels
{
    internal class VoidBroadcastListener : MonoBehaviour
    {
        [SerializeField] private VoidChannel _channel;
        [SerializeField] private UnityEvent _event;

        private void Awake()
        {
            if (_channel == null)
            {
                Debug.LogError($"You must attach a channel into {gameObject.name} GameObject.");
                return;
            }
        
            _channel.Subscribe(OnBroadcastReceived);
        }

        private void OnDestroy()
        {
            _channel.Unsubscribe(OnBroadcastReceived);
        }

        private void OnBroadcastReceived()
        {
            _event?.Invoke();
        }
    }
}