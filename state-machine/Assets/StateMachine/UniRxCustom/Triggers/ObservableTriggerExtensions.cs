using System;
using UnityEngine;
using UniRx;


namespace HC.UniRxCustom
{
    public static class ObservableTriggerExtensions
    {
        #region method

        #region OnDrawGizmosAsObservable

        public static IObservable<Unit> OnDrawGizmosAsObservable(this Component component)
        {
            if (component == null || component.gameObject == null)
            {
                return Observable.Empty<Unit>();
            }

            return GetOrAddComponent<ObservableOnDrawGizmosTrigger>(component.gameObject).OnDrawGizmosAsObservable();
        }

        #endregion

        #region OnGUIAsObservable

        public static IObservable<Unit> OnGUIAsObservable(this Component component)
        {
            if (component == null || component.gameObject == null)
            {
                return Observable.Empty<Unit>();
            }

            return GetOrAddComponent<ObservableOnGUITrigger>(component.gameObject).OnGUIAsObservable();
        }

        #endregion

        #region GetOrAddComponent

        public static T GetOrAddComponent<T>(GameObject gameObject) where T : Component
        {
            var component = gameObject.GetComponent<T>();

            if (component == null)
            {
                component = gameObject.AddComponent<T>();
            }

            return component;
        }

        #endregion

        #endregion
    }
}