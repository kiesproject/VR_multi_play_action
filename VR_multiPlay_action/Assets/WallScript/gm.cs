using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gm : MonoBehaviour
{
    public wall _wall;
    public Weak _weak;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _wall.HP -= 1;
        }
        if (Input.GetMouseButtonDown(1))
        {
            _weak.wHP -= 1;

        }
    }
}
