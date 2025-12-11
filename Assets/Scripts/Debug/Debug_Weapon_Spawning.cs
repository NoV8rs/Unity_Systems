using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(Debug_Weapon_Spawning))]
[ExecuteAlways]
public class Debug_Weapon_Spawning : MonoBehaviour
{
    public Weapon_Data weaponData;
    public Transform spawnPoint;
    
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    SpawnWeapon();
        //}
    }
    
    private void SpawnWeapon()
    {
        if (weaponData != null && weaponData.projectilePrefab != null && spawnPoint != null)
        {
            Instantiate(weaponData.projectilePrefab, spawnPoint.position, spawnPoint.rotation);
        }
        else
        {
            Debug.LogWarning("Weapon data, projectile prefab, or spawn point is not assigned.");
        }
    }
}
