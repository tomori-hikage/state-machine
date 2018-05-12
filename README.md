# state-machine

## Description

state-machineはUniRxをベースにしたステートマシンです

## Install

[release](https://github.com/tomoriaki/state-machine/releases)からstate-machine.unitypackageをダウンロードしてプロジェクトにインポートしてください

## Example

```csharp
using UnityEngine;
using UniRx;
using HC.AI;


[DisallowMultipleComponent]
public class Example : State
{
    #region event

    private void Start()
    {
        BeginStream.Subscribe(_ => Debug.Log("State Begin"));
        UpdateStream.Subscribe(_ => Debug.Log("State Update"));
        FixedUpdateStream.Subscribe(_ => Debug.Log("State FixedUpdate"));
        LateUpdateStream.Subscribe(_ => Debug.Log("State LateUpdate"));
        EndStream.Subscribe(_ => Debug.Log("State End"));
        OnDrawGizmosStream.Subscribe(_ => Debug.Log("State OnDrawGizmos"));
        OnGUIStream.Subscribe(_ => Debug.Log("State OnGUI"));
    }

    #endregion
}
```

## Author

- JINZO  
GitHub: [@JINZO631](https://github.com/JINZO631)  
Twitter: [@jinzo_631](https://twitter.com/jinzo_631)

- 戸森  
Twitter: [@tomoriaki](https://twitter.com/tomoriaki)  
Qiita: [@tomoriaki](https://qiita.com/tomoriaki)

## Distribution License

[MIT](https://github.com/tomoriaki/state-machine/blob/master/LICENSE)

## Use License

state-machineはUniRxをベースに作成しています

[Copyright (c) 2014 Yoshifumi Kawai](https://github.com/neuecc/UniRx/blob/master/LICENSE)

この作品はユニティちゃんライセンス条項の元に提供されています

© Unity Technologies Japan/UCL
