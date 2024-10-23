using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyRotate : MonoBehaviour
{
    public EnemyController controller;

    void Start()
    {
        controller = GetComponentInParent<EnemyController>();

        if(controller.tileType == 1 || controller.tileType == 4)
        {
            if (controller.enemyDir == 0)
                transform.rotation = Quaternion.Euler(0, 90, 0);
            else if (controller.enemyDir == 1)
                transform.rotation = Quaternion.Euler(0, -90, 0);
        }
        else if (controller.tileType == 2)
        {
            if (controller.enemyDir == 0)
                transform.rotation = Quaternion.Euler(0, 180, 0);
            else if (controller.enemyDir == 1)
                transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
}
