using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseWeapon : MonoBehaviour {

    public GameObject projectile;
    public GameObject bulletsOut;
    public GameObject reloadingIndicator;

    public bool equipped = true;

    public int projectileCountMax = 3;
    public int projectileCountMin = 5;
    public float reloadTime = 1;
    private float reloadProgress = 1000;
    public float shootInterval = 0.2f;
    private float shootIntervalProgress = 1000;
    public float clipSize = 10;
    private float ammoInClip = 10;

    public AudioClip fireSound;
    public AudioClip reloadSound;
    private AudioSource audioSource;

    // Use this for initialization
    void Start () {
        ammoInClip = clipSize;
        shootIntervalProgress = shootInterval + 1;
        reloadProgress = reloadTime + 1;

        audioSource = gameObject.GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (!equipped) return;

        AimWeapon();

        // Reloading
        if (reloadProgress <= reloadTime)
        {
            PerformReload();
        }

        // Shooting cooldown
        if (shootIntervalProgress <= shootInterval) shootIntervalProgress += Time.deltaTime;

        // Debug fire mechanic
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;
            Fire(mousePos);
        }
    }

    private void AimWeapon()
    {
        Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        diff.Normalize();

        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
    }

    public virtual void Fire(Vector2 target)
    {
        if(ammoInClip <= 0 || reloadProgress < reloadTime || shootIntervalProgress < shootInterval)
        {
            // reloading or waiting
            return;
        }

        ammoInClip -= 1;
        AudioSource.PlayClipAtPoint(fireSound, transform.position);

        int projectileCount = Random.Range(projectileCountMin, projectileCountMax);
        for(int i = 0; i < projectileCount; i++)
        {
            var projectileGO = Instantiate(projectile, bulletsOut.transform.position, new Quaternion(), null);
            projectileGO.SetActive(true);
            var newProjectile = projectileGO.GetComponent<BaseProjectile>();
            newProjectile.Fire(target);
        }

        shootIntervalProgress = 0;
        if (ammoInClip <= 0) StartReload();
    }

    public virtual void StartReload()
    {
        AudioSource.PlayClipAtPoint(reloadSound, transform.position);

        reloadProgress = 0;
        if (reloadingIndicator != null) reloadingIndicator.SetActive(true);
    }

    private void PerformReload()
    {
        reloadProgress += Time.deltaTime;

        // Complete
        if (reloadProgress > reloadTime)
        {
            ammoInClip = clipSize;
            if (reloadingIndicator != null) reloadingIndicator.SetActive(false);
        }
    }
}
