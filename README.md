# state-machine

state-machineはUniRxをベースにしたステートマシンです

## 導入方法

state-machine.unitypackageをプロジェクトにインポートしてください

## 使用方法

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

## 配布ライセンス

MIT / X11ライセンスで公開いたします

## 使用ライセンス

state-machineはUniRxをベースに作成しています

[Copyright (c) 2014 Yoshifumi Kawai](https://github.com/neuecc/UniRx/blob/master/LICENSE)

この作品はユニティちゃんライセンス条項の元に提供されています

© Unity Technologies Japan/UCL
