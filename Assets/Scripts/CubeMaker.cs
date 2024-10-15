using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMaker : MonoBehaviour
{
    public GameObject cube;

    // Start is called before the first frame update
    void Awake()
    {
        for (int i = 0; i < 9; i++)
        {
            cube = Instantiate(cube, new Vector3(i - 4, 0, transform.position.z), Quaternion.identity, transform);
            cube.transform.parent = null;
            cube.transform.localScale = new Vector3(1f, 1f, 1f);
            cube.transform.parent = this.transform;
        }
    }
}
