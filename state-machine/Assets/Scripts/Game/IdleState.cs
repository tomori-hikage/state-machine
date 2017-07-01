using UnityEngine;
using UnityEngine.UI;
using UniRx;
using HC.AI;


namespace HC
{
    [DisallowMultipleComponent]
    public class IdleState : State
    {
        #region variable

        [Header("Parameter")]

        /// <summary>
        /// アピールステートに遷移する時間
        /// </summary>
        public const float TRANSITION_TO_APPEAL_DURATION = 3f;


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
            // 待機アニメーションを再生する
            BeginStream.Subscribe(_ => _animator.Play("Idle"));

            // チュートリアルの文言を変更する
            BeginStream.Subscribe(_ => _tutorialText.text = "左クリックで走行ステートに遷移します");


            float counter = 0f;

            // n秒経過したらアピールステートに遷移する
            UpdateStream.Do(_ => counter += Time.deltaTime)
                .Where(count => counter > TRANSITION_TO_APPEAL_DURATION)
                .Subscribe(_ => Transition<AppealState>());

            // 右クリックされたら走行ステートに遷移する
            UpdateStream.Where(_ => Input.GetMouseButtonDown(0))
                .Subscribe(_ => Transition<RunState>());

            // ステート遷移を行うときカウンタをリセットする
            EndStream.Subscribe(_ => counter = 0f);
        }

        #endregion
    }
}