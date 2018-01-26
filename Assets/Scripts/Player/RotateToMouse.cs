using UnityEngine;
using System.Collections;

public class RotateToMouse : MonoBehaviour
{
    public GameObject player;
    public GameObject laser;
    public GameObject hook;
    public GameObject spawnPoint1;
    public GameObject spawnPoint2;
    public Rigidbody2D rb;
    public Rigidbody2D rb2;
    public Rigidbody2D rb3;
    public Rigidbody2D rbHook;
    public float speed;
    public float hookSpeed;
    public bool hasHooked;
    public Vector2 hookDirection;
    private PlayerMovement playerMovement;
    public Vector2 direction;
    public Quaternion rotation;
    private Quaternion rotation2;
    private Vector3 direction2;
    private Quaternion rotation3;
    private Vector3 direction3;
    public Transform weaponPos;

    
    


    private void Start()
    {
        playerMovement = player.GetComponent<PlayerMovement>();
        

    }

    void Update()
    {
        Vector2 target = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
        
        
        Vector2 exitPoint = new Vector2(spawnPoint1.transform.position.x, spawnPoint1.transform.position.y);
        
        

        Vector2 playerPos = new Vector2(player.transform.position.x, player.transform.position.y);
        Vector2 direction = target - playerPos;
        
        
        direction.Normalize();
        Quaternion rotation = Quaternion.Euler(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg);

        GunCheck();
        if (weaponPos != null)
        {
            weaponPos.rotation = rotation;
        }
        
        
        

        


    }
    private void GunCheck()
    {
        Transform[] children = GetComponentsInChildren<Transform>();
        foreach (Transform child in children)
        {
            if (child.CompareTag("Weapon"))
            {
                weaponPos = child.transform;
                spawnPoint1.transform.parent = child.transform;
            }
        }

    }
}