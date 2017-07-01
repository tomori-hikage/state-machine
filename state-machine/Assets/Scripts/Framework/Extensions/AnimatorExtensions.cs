using UnityEngine;


namespace HC.Extensions
{
    public static class AnimatorExtensions
    {
        #region method

        /// <summary>
        /// 現在再生しているアニメーションが終了しているか？
        /// </summary>
        /// <param name="self">自身</param>
        /// <returns>アニメーションが終了しているか？</returns>
        public static bool IsCompleted(this Animator self)
        {
            return self.GetCurrentAnimatorStateInfo(0).normalizedTime > 1.0f;
        }

        /// <summary>
        /// 現在再生しているアニメーションが指定ステートかつ終了しているか？
        /// </summary>
        /// <param name="self">自身</param>
        /// <param name="stateHash">指定ステートのハッシュ</param>
        /// <returns></returns>
        public static bool IsCompleted(this Animator self, int stateHash)
        {
            return self.GetCurrentAnimatorStateInfo(0).shortNameHash == stateHash && self.IsCompleted();
        }

        /// <summary>
        /// 現在再生しているアニメーションの指定時間(割合)を過ぎているか？
        /// </summary>
        /// <param name="self">自身</param>
        /// <param name="normalizedTime">指定時間(割合)   0.0f(開始) ～ 1.0f(終了)の値</param>
        /// <returns>アニメーションの指定時間(割合)を過ぎているか？</returns>
        public static bool IsPassed(this Animator self, float normalizedTime)
        {
            return self.GetCurrentAnimatorStateInfo(0).normalizedTime > normalizedTime;
        }

        /// <summary>
        /// アニメーションを最初から再生する
        /// </summary>
        /// <param name="self">自身</param>
        /// <param name="shortNameHash">アニメーションのハッシュ</param>
        public static void PlayBegin(this Animator self, int shortNameHash)
        {
            self.Play(shortNameHash, 0, 0.0f);
        }

        #endregion
    }
}