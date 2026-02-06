using TMPro;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [Header("Bullet Settings")]
    public Transform firePoint;
    public float bulletForce = 20f;

    [Header("references")]
    public ObjectPooler pooler;

    [Header("Weapon Settings")]
    public WepaonData weaponName;
    public WepaonData[] weapons;
    int currentWeaponIndex;
    [SerializeField] int currentMag;
    float nextTimeToFire;
    int[] ammoCount;

    [Header("UI")]
    public TextMeshProUGUI weaponNameText;
    public TextMeshProUGUI weaponSizeText;

    private void Start()
    {
        currentWeaponIndex = 0;
        ammoCount = new int[weapons.Length];
        for(int i = 0; i < weapons.Length; i++)
        {
            ammoCount[i] = weapons[i].size;
        }

        EquipWeapon(0);
    }

    void EquipWeapon(int index)
    {
        if(index < 0 || index >= weapons.Length)
        {
            return;
        }

        currentWeaponIndex = index;
        weaponName = weapons[index];
        currentMag = ammoCount[index];

        Debug.Log("Equipped " +  weaponName.name);

        UpdateUI();
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Shoot();
        }

        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            EquipWeapon(0);
        }

        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            EquipWeapon(1);
        }

        if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            EquipWeapon(2);
        }

        UpdateUI();
    }

    void Shoot()
    {
        if(Time.time < nextTimeToFire)
        {
            return;
        }

        if (currentMag > 0)
        {
            GameObject bullet = pooler.SpawnFromPools("Bullet", firePoint.position, firePoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
            }
            currentMag--;
            ammoCount[currentWeaponIndex] = currentMag;
            nextTimeToFire = Time.time + 1f / weaponName.fireRate;
            Debug.Log(weaponName.name + " Fired " + weaponName.size + " Remaining");
        }
        else
        {
            Debug.Log("Out of Ammo");
        }
    }

    void UpdateUI()
    {
        if(weaponNameText != null)
        {
            weaponNameText.text = "WeaponName: " +  weaponName.name;
        }
        
        if(weaponSizeText != null)
        {
            weaponSizeText.text =  $"WeaponSize : {currentMag}/{weaponName.size}"; 
        }
    }
}