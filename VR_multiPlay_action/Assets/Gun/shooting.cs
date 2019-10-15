using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float shotSpeed;
    public int shotCount = 5;
    public float reloadtime = 3.0f;
    public float time = 0f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (shotCount > 0)
            {
                shotCount -= 1;

                GameObject bullet = (GameObject)Instantiate(bulletPrefab, transform.position, Quaternion.Euler(transform.parent.eulerAngles.x, transform.parent.eulerAngles.y, 0));
                Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
                bulletRb.AddForce(transform.forward * shotSpeed);

                //射撃されてから1秒後に銃弾のオブジェクトを破壊する.

                Destroy(bullet, 1.0f);
            }

        }
        else if (shotCount < 5)
        {
            time += Time.deltaTime;

            if (time >= reloadtime)
            {
                shotCount += 1;
                time = 0f;
            }
        }

    }
}