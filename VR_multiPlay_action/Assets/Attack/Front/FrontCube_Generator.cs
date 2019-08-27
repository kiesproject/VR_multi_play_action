using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrontCube_Generator : MonoBehaviour
{
    public GameObject[] Throw_Object;
    private int dice;

    public void OnClick()
    {
        this.dice = Random.Range(0, Throw_Object.Length);
        int x = Random.Range(-1, 2);
        int y = Random.Range(-1, 2);
        int z = 60;
        GameObject go = Instantiate(Throw_Object[dice], new Vector3(x, y, z), Quaternion.identity) as GameObject;
    }
}
