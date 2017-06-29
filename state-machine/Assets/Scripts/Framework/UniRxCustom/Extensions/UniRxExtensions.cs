using UniRx;


namespace HC.UniRxCustom
{
    public static class UniRxExtensions
    {
        #region method

        #region DoDebugLog

        /// <summary>
        /// DoオペレータでDebug.Logを呼び出し
        /// </summary>
        public static IObservable<T> DoDebugLog<T>(this IObservable<T> source, object logMessage)
        {
            return source.Do(_ => UnityEngine.Debug.Log(logMessage));
        }

        /// <summary>
        /// DoオペレータでDebug.Log呼び出し
        /// ストリームのメッセージをそのまま流す
        /// </summary>
        public static IObservable<T> DoDebugLog<T>(this IObservable<T> source)
        {
            return source.Do(x => UnityEngine.Debug.Log(x));
        }

        /// <summary>
        /// DoオペレータでDebug.Log呼び出し
        /// source.DoDebugLog(x => "time:" + x);    // Debug.Log("time:"+x);
        /// </summary>
        public static IObservable<T> DoDebugLog<T>(this IObservable<T> source, System.Func<T,object> log)
        {
            return source.Do(x => UnityEngine.Debug.Log(log(x)));
        }

        #endregion

        #region Where

        /// <summary>
        /// メッセージがtrueの場合のみ通過させるフィルタ
        /// </summary>
        public static IObservable<bool> WhereTrue(this IObservable<bool> source)
        {
            return source.Where(b => b);
        }

        /// <summary>
        /// メッセージがfalseの場合のみ通過させるフィルタ
        /// </summary>
        public static IObservable<bool> WhereFalse(this IObservable<bool> source)
        {
            return source.Where(b => !b);
        }

        #endregion

        #region Take

        public static IObservable<T> TakeOne<T>(this IObservable<T> source)
        {
            return source.Take(1);
        }

        #endregion

        #region ZipLR

        /// <summary>
        /// leftのメッセージをそのまま流すZip
        /// </summary>
        public static IObservable<T1> ZipLeft<T1, T2>(this IObservable<T1> left, IObservable<T2> right)
        {
            return left.Zip(right, (l, r) => l);
        }

        /// <summary>
        /// rightのメッセージをそのまま流すZip
        /// </summary>
        public static IObservable<T2> ZipRight<T1, T2>(this IObservable<T1> left, IObservable<T2> right)
        {
            return left.Zip(right, (l, r) => r);
        }

        #endregion

        #region ZipLatestLR

        /// <summary>
        /// leftのメッセージをそのまま流すZipLatest
        /// </summary>
        public static IObservable<T1> ZipLatestLeft<T1, T2>(this IObservable<T1> left, IObservable<T2> right)
        {
            return left.ZipLatest(right, (l, r) => l);
        }

        /// <summary>
        /// rightのメッセージをそのまま流すZipLatest
        /// </summary>
        public static IObservable<T2> ZipLatestRight<T1, T2>(this IObservable<T1> left, IObservable<T2> right)
        {
            return left.ZipLatest(right, (l, r) => r);
        }

        #endregion

        #region CombineLatestLR

        /// <summary>
        /// leftのメッセージをそのまま流すCombineLatest
        /// </summary>
        public static IObservable<T1> CombineLatestLeft<T1, T2>(this IObservable<T1> left, IObservable<T2> right)
        {
            return left.CombineLatest(right, (l, r) => l);
        }

        /// <summary>
        /// rightのメッセージをそのまま流すCombineLatest
        /// </summary>
        public static IObservable<T2> CombineLatestRight<T1, T2>(this IObservable<T1> left, IObservable<T2> right)
        {
            return left.CombineLatest(right, (l, r) => r);
        }

        #endregion

        #endregion
    }
}