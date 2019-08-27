using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopCube_Generator : MonoBehaviour
{
    public GameObject[] Throw_Object;
    private int dice;

    public void OnClick()
    {
        this.dice = Random.Range(0, Throw_Object.Length);
        int x = Random.Range(-1, 2);
        int y = 60;
        int z = Random.Range(-1, 2);
        GameObject go = Instantiate(Throw_Object[dice], new Vector3(x, y, z), Quaternion.identity) as GameObject;
    }
}
