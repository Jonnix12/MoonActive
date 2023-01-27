using UnityEngine;

namespace MoonActive.Singleton
{
    public abstract class MonoSingleton<T> : MonoBehaviour where T : class
    {
        private static T _instance;
        public static T Instance => _instance;

        public virtual void Awake()
        {
            if (isActiveAndEnabled)
            {
                if (Instance == null)
                    _instance = this as T;
                else if (Instance != this as T)
                    Destroy(this);
            }
        }
    }
}