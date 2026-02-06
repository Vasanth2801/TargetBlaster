using UnityEngine;

[CreateAssetMenu(fileName = "NewWeaponData",menuName = "Weapons")]
public class WepaonData : ScriptableObject
{
    public string weapaonName;
    public int damage;
    public float fireRate;
    public int size;
}
