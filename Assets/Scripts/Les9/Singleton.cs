using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    // ‘лаг дл¤ отслеживани¤ завершени¤ работы приложени¤
    public static bool isApplicationQuitting;

    // ѕриватное статическое поле дл¤ хранени¤ единственного экземпл¤ра
    private static T _instance;

    // ќбъект дл¤ синхронизации доступа к экземпл¤ру (используетс¤ дл¤ потокобезопасности)
    private static System.Object _lock = new System.Object();

    // —войство дл¤ получени¤ единственного экземпл¤ра класса
    public static T Instance
    {
        get
        {
            // ≈сли приложение закрываетс¤, возвращаем null
            if (isApplicationQuitting)
                return null;

            // Ѕлок синхронизации дл¤ обеспечени¤ потокобезопасного доступа к экземпл¤ру
            lock (_lock)
            {
                // ≈сли экземпл¤р еще не создан
                if (_instance == null)
                {
                    // »щем существующий экземпл¤р объекта в сцене
                    _instance = FindObjectOfType<T>();

                    // ≈сли экземпл¤р не найден, создаем новый объект
                    if (_instance == null)
                    {
                        // —оздаем новый игровой объект с именем [SINGLETON] и типом T
                        var singleton = new GameObject("[SINGLETON] " + typeof(T));

                        // ƒобавл¤ем компонент типа T к игровому объекту
                        _instance = singleton.AddComponent<T>();

                        // ”казываем, что объект не должен уничтожатьс¤ при загрузке новой сцены
                        DontDestroyOnLoad(singleton);
                    }
                }

                // ¬озвращаем единственный экземпл¤р
                return _instance;
            }
        }
    }

    // ћетод, вызываемый при уничтожении объекта
    public virtual void OnDestroy()
    {
        // ”станавливаем флаг, что приложение закрываетс¤
        isApplicationQuitting = true;
    }
}


