using System;
using UnityEngine;
using UniRx;
using UniRx.Triggers;


namespace HC.UniRxCustom
{
    [DisallowMultipleComponent]
    public class ObservableOnGUITrigger : ObservableTriggerBase
    {
        #region variable

        private Subject<Unit> _onGui;

        #endregion

        #region property

        public IObservable<Unit> OnGUIAsObservable()
        {
            return _onGui ?? (_onGui = new Subject<Unit>());
        }

        #endregion

        #region event

        private void OnGUI()
        {
            if (_onGui != null)
            {
                _onGui.OnNext(default(Unit));
            }
        }

        #endregion



        #region method

        protected override void RaiseOnCompletedOnDestroy()
        {
            if (_onGui != null)
            {
                _onGui.OnCompleted();
            }
        }

        #endregion
    }
}