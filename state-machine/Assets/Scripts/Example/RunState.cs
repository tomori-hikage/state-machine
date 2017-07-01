using UnityEngine;
using UnityEngine.UI;
using UniRx;
using AI;


[DisallowMultipleComponent]
public class RunState : State
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
        // 走行アニメーションを再生する
        BeginStream.Subscribe(_ => _animator.Play("Run"));

        // チュートリアルの文言を変更する
        BeginStream.Subscribe(_ => _tutorialText.text = "左クリックで待機ステートに遷移します");

        // 右クリックされたら待機ステートに遷移する
        UpdateStream.Where(_ => Input.GetMouseButtonDown(0))
            .Subscribe(_ => Transition<IdleState>());
    }

    #endregion
}