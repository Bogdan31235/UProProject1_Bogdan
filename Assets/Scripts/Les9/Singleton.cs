using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    // Флаг для отслеживания завершения работы приложения
    public static bool isApplicationQuitting;
    
    // Приватное статическое поле для хранения единственного экземпляра
    private static T _instance;
    
    // Объект для синхронизации доступа к экземпляру (используется для потокобезопасности)
    private static System.Object _lock = new System.Object();

    // Свойство для получения единственного экземпляра класса
    public static T Instance
    {
        get
        {
            // Если приложение закрывается, возвращаем null
            if (isApplicationQuitting)
                return null;

            // Блок синхронизации для обеспечения потокобезопасного доступа к экземпляру
            lock (_lock)
            {
                // Если экземпляр еще не создан
                if (_instance == null)
                {
                    // Ищем существующий экземпляр объекта в сцене
                    _instance = FindObjectOfType<T>();

                    // Если экземпляр не найден, создаем новый объект
                    if (_instance == null)
                    {
                        // Создаем новый игровой объект с именем [SINGLETON] и типом T
                        var singleton = new GameObject("[SINGLETON] " + typeof(T));
                        
                        // Добавляем компонент типа T к игровому объекту
                        _instance = singleton.AddComponent<T>();
                        
                        // Указываем, что объект не должен уничтожаться при загрузке новой сцены
                        DontDestroyOnLoad(singleton);
                    }
                }

                // Возвращаем единственный экземпляр
                return _instance;
            }
        }
    }

    // Метод, вызываемый при уничтожении объекта
    public virtual void OnDestroy()
    {
        // Устанавливаем флаг, что приложение закрывается
        isApplicationQuitting = true;
    }
}


