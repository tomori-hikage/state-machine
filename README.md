# state-machine

## Description

state-machineはUniRxをベースにしたステートマシンです

## Install

[releases](https://github.com/tomoriaki/state-machine/releases)からstate-machine.unitypackageをダウンロードしてプロジェクトにインポートしてください

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

- 戸森ひかげ  
GitHub: [tomori-hikage](https://github.com/tomori-hikage)  
Qiita: [@tomori_hikage](https://qiita.com/tomori_hikage)  
Twitter: [@tomori_hikage](https://twitter.com/tomori_hikage)

- takaaptech  
GitHub: [@takaaptech](https://github.com/takaaptech)

## Distribution License

[MIT](https://github.com/tomori-hikage/state-machine/blob/master/LICENSE)

## Use License

state-machineはUniRxをベースに作成しています

[Copyright (c) 2014 Yoshifumi Kawai](https://github.com/neuecc/UniRx/blob/master/LICENSE)


[© Unity Technologies Japan/UCL](http://unity-chan.com/contents/license_jp/)
