using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    // ���� ��� ������������ ���������� ������ ����������
    public static bool isApplicationQuitting;
    
    // ��������� ����������� ���� ��� �������� ������������� ����������
    private static T _instance;
    
    // ������ ��� ������������� ������� � ���������� (������������ ��� ������������������)
    private static System.Object _lock = new System.Object();

    // �������� ��� ��������� ������������� ���������� ������
    public static T Instance
    {
        get
        {
            // ���� ���������� �����������, ���������� null
            if (isApplicationQuitting)
                return null;

            // ���� ������������� ��� ����������� ����������������� ������� � ����������
            lock (_lock)
            {
                // ���� ��������� ��� �� ������
                if (_instance == null)
                {
                    // ���� ������������ ��������� ������� � �����
                    _instance = FindObjectOfType<T>();

                    // ���� ��������� �� ������, ������� ����� ������
                    if (_instance == null)
                    {
                        // ������� ����� ������� ������ � ������ [SINGLETON] � ����� T
                        var singleton = new GameObject("[SINGLETON] " + typeof(T));
                        
                        // ��������� ��������� ���� T � �������� �������
                        _instance = singleton.AddComponent<T>();
                        
                        // ���������, ��� ������ �� ������ ������������ ��� �������� ����� �����
                        DontDestroyOnLoad(singleton);
                    }
                }

                // ���������� ������������ ���������
                return _instance;
            }
        }
    }

    // �����, ���������� ��� ����������� �������
    public virtual void OnDestroy()
    {
        // ������������� ����, ��� ���������� �����������
        isApplicationQuitting = true;
    }
}


