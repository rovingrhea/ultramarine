using UnityEngine;
using UnityEngine.UI;

public class WeaponUI : MonoBehaviour {

    BaseWeapon weapon;

    public Text title;
    public Text ammo;
    public Text clip;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(weapon != null)
        {
            ammo.text = weapon.ammoInClip.ToString();
            clip.text = weapon.clipSize.ToString();
        }
	}

    public void Equip(BaseWeapon weapon)
    {
        this.weapon = weapon;
        if(weapon == null)
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
            title.text = weapon.weaponName;
        }
    }
}
