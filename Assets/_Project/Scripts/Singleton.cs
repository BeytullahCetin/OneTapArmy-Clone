using UnityEngine;

namespace Utility
{
    public abstract class StaticInstance<T> : MonoBehaviour where T : MonoBehaviour
    {
        public static T instance { get; private set; }

        protected virtual void Awake()
        {
            instance = this as T;
        }
    }

    public abstract class Singleton<T> : StaticInstance<T> where T : MonoBehaviour
    {
        protected override void Awake()
        {
            if (instance != null)
                Destroy(gameObject);
            else
                base.Awake();
        }
    }

    public abstract class PersistentSingleton<T> : Singleton<T> where T : MonoBehaviour
    {
        protected override void Awake()
        {
            base.Awake();
            DontDestroyOnLoad(gameObject);
        }
    }
}
