using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotWaiterSmall : RobotWaiter
{
    [SerializeField]
    private GameObject water;

    public override void Bring()
    {
        StartCoroutine(Choose());
    }

    public void Bring(int index)
    {
        if (index == 0)
        {
            Debug.Log("Я принёс вам воду!");
            Instantiate(water, transform.position + new Vector3(0, 1f, -1f),
                Quaternion.identity);
        }

        if (index == 1)
        {
            Debug.Log("Я принёс вам кофе!");
            Instantiate(_coffe, transform.position + new Vector3(0, 1f, -1f),
                Quaternion.identity);
        }
    }

    public override void Use()
    {
        Debug.Log("Хотите, чтобы я принёс вам воду или кофе? Нажмите 5 или 4 соответственно.");
    }

    IEnumerator Choose()
    {
        bool isStop = true;

        while (isStop)
        {
            if (Input.GetKey(KeyCode.Alpha4))
            {
                Bring(1);
                isStop = false;
            }

            if (Input.GetKey(KeyCode.Alpha5))
            {
                Bring(0);
                isStop = false;
            }
            yield return new WaitForSeconds(0.01f);
        }
    }

}
