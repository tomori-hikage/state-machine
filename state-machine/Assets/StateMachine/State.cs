using System;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using HC.UniRxCustom;


/*
 * このStateクラスを継承して各種ステートを定義する
 * 
 * 
 * 各種処理はBegin,End,Update,LateUpdateのストリームを利用して記述する
 * 
 * ex)
 *      BeginStream.Subscribe(_=>Debug.Log("State begin"));
 *      EndStream.Subscribe(_=>Debug.Log("State end"));
 *      UpdateStream.Subscribe(_=>Debug.Log("State update"));
 *      ...
 *      
 * 他ステートへの遷移はTransition関数を使う
 * ex)
 *      UpdateStream.Where(_=>Input.GetMouseButtonDown(0))
 *                      .Subscribe(_=>Transition(typeof(OtherState)));
 *                      
 * ジェネリック版)
 *      UpdateStream.Where(_=>Input.GetMouseButtonDown(0))
 *                      .Subscribe(_=>Transition<OtherState>());
 */


namespace HC.AI
{
    /// <summary>
    /// ステートクラス
    /// </summary>
    [RequireComponent(typeof(StateMachine))]
    public abstract class State : MonoBehaviour
    {
        #region variable

        /// <summary>
        /// ステートマシン
        /// </summary>
        public StateMachine StateMachine { get; set; }

        /// <summary>
        /// ステート開始ストリーム
        /// </summary>
        private Subject<Unit> _begin = new Subject<Unit>();

        /// <summary>
        /// ステート終了ストリーム
        /// </summary>
        private Subject<Unit> _end = new Subject<Unit>();

        #endregion

        #region event stream

        /// <summary>
        /// ステート開始ストリーム
        /// </summary>
        public IObservable<Unit> BeginStream { get { return _begin.AsObservable(); } }

        /// <summary>
        /// ステート終了ストリーム
        /// </summary>
        public IObservable<Unit> EndStream { get { return _end.AsObservable(); } }

        /// <summary>
        /// Updateストリーム
        /// </summary>
        public IObservable<Unit> UpdateStream
        {
            get { return StateStream(this.UpdateAsObservable()); }
        }

        /// <summary>
        /// FixedUpdateストリーム
        /// </summary>
        public IObservable<Unit> FixedUpdateStream
        {
            get { return StateStream(this.FixedUpdateAsObservable()); }
        }

        /// <summary>
        /// LateUpdateストリーム
        /// </summary>
        public IObservable<Unit> LateUpdateStream
        {
            get { return StateStream(this.LateUpdateAsObservable()); }
        }

        /// <summary>
        /// OnDrawGizmosストリーム
        /// </summary>
        public IObservable<Unit> OnDrawGizmosStream
        {
            get { return StateStream(this.OnDrawGizmosAsObservable()); }
        }

        /// <summary>
        /// OnGUIストリーム
        /// </summary>
        public IObservable<Unit> OnGUIStream
        {
            get { return StateStream(this.OnGUIAsObservable()); }
        }

        /// <summary>
        /// このステートが現在ステートの間だけメッセージが流れるストリーム
        /// </summary>
        protected IObservable<T> StateStream<T>(IObservable<T> source)
        {
            return source
                // BeginStreamがOnNextされてから
                .SkipUntil(BeginStream)
                // EndStreamがOnNextされるまで
                .TakeUntil(EndStream)
                .RepeatUntilDestroy(gameObject)
                .Publish()
                .RefCount();
        }

        #endregion

        #region method

        /// <summary>
        /// ステートの開始通知(StateMachine以外では基本的に呼び出さない)
        /// </summary>
        public void StateBegin()
        {
            _begin.OnNext(default(Unit));
        }

        /// <summary>
        /// ステートの終了通知(StateMachine以外では基本的に呼び出さない)
        /// </summary>
        public void StateEnd()
        {
            _end.OnNext(default(Unit));
        }

        /// <summary>
        /// ステートの遷移予約
        /// </summary>
        protected void Transition<T>() where T : State
        {
            StateMachine.Transition<T>();
        }

        #endregion
    }
}