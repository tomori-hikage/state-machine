using UnityEngine;
using UnityEngine.UI;
using UniRx;
using HC.AI;
using HC.Extensions;


[DisallowMultipleComponent]
public class AppealState : State
{
    #region variable

    [Header("Cache")]

    [SerializeField]
    private Animator _animator = null;

    [SerializeField]
    private Text _tutorialText = null;

    #endregion

    #region event

    private void Reset()
    {
        _animator = transform.GetComponent<Animator>();
    }

    private void Start()
    {
        // アピールアニメーションを再生する
        BeginStream.Subscribe(_ => _animator.Play("Appeal"));

        // チュートリアルの文言を変更する
        BeginStream.Subscribe(_ => _tutorialText.text =
            (int)IdleState.TRANSITION_TO_APPEAL_DURATION + "秒経過したのでアピールステートに遷移しました");

        // アピールアニメーションの再生が完了したら待機ステートに遷移する
        UpdateStream.Where(_ => _animator.IsCompleted(Animator.StringToHash("Appeal")))
            .Subscribe(_ => Transition<IdleState>());

        // 右クリックされたら走行ステートに遷移する
        UpdateStream.Where(_ => Input.GetMouseButtonDown(0))
            .Subscribe(_ => Transition<RunState>());
    }

    #endregion
}