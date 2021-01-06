# Scriptable Channels
Extensible scriptable object event system in Unity

## Installation

Add the folowing line to your `manifest.json` 

```json
"com.grochoska.scriptablechannels": "https://github.com/RafaelGrochoska/ScriptableChannels.git#1.0.0",
```

## How to use:
Create a reference to any of the channel types provided or create your custom channel type.

### In the listener class:

```csharp

using UnityEngine;
using Grochoska.ScriptableChannels;

public class MyClass : MonoBehaviour
{
    public IntChannel onIntReceived;

    private void Awake()
    {
        onIntReceived.Subscribe(HandleIntReceived);
    }
    
    private void OnDestroy()
    {
        onIntReceived.Unsubscribe(HandleIntReceived);
    }

    private void HandleIntReceived(int data)
    {
        // Do something
    }
}

```

### In the broadcaster class:

```csharp

using UnityEngine;
using Random = UnityEngine.Random;
using Grochoska.ScriptableChannels;

public class MyBroadcasterClass : MonoBehaviour
{
    public IntChannel onIntReceived;

    private void Awake()
    {
        onIntReceived.Broadcast(Random.Range(-1, 1));
    }
}

```

## Custom channel types:
To create a custom channel, just inherit from `BaseGameChannel<>`:

```csharp

using UnityEngine;
using Grochoska.ScriptableChannels;

[CreateAssetMenu(menuName = "Game channel/MyCustomData")]
public sealed class MyCustomDataChannel : BaseGameChannel<MyCustomData>
{
    
}

```
