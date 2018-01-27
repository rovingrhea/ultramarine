using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseWeapon : MonoBehaviour {

    public GameObject projectile;
    public GameObject bulletsOut;

    public int projectileCountMax = 3;
    public int projectileCountMin = 5;

    public float reloadTime = 1;
    public float reloadProgress = 1000;

    public float shootInterval = 0.2f;
    public float shootIntervalProgress = 1000;

    public float clipSize = 10;
    public float ammoInClip = 10;

    // Use this for initialization
    void Start () {
        Fire((Vector2)transform.position + (Vector2.right * 10));
	}
	
	// Update is called once per frame
	void Update () {
        Debug.DrawLine(transform.position, transform.position + (Vector3)Vector2.right, Color.red);

        if(reloadProgress < reloadTime)
        {
            reloadProgress += Time.deltaTime;
        }

        if (shootIntervalProgress < shootInterval)
        {
            shootInterval += Time.deltaTime;
        }
    }

    public virtual void Fire(Vector2 target)
    {
        if(ammoInClip <= 0 || reloadProgress < reloadTime || shootIntervalProgress < shootInterval)
        {
            // reloading or waiting
            return;
        }

        ammoInClip -= 1;

        int projectileCount = Random.Range(projectileCountMin, projectileCountMax);
        for(int i = 0; i < projectileCount; i++)
        {
            var projectileGO = Instantiate(projectile, bulletsOut.transform.position, new Quaternion(), null);
            projectileGO.SetActive(true);
            var newProjectile = projectileGO.GetComponent<BaseProjectile>();
            newProjectile.Fire(target);
        }

    }
}
