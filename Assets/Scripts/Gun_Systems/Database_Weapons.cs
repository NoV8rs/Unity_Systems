using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// Simple database to hold all weapon data entries.
/// Allows for easy access and management of weapons in the game.
/// Also can be useful for spawning the right weapon based on player choice or level design.
/// </summary>
public class Database_Weapons : MonoBehaviour
{
    // List of all weapon data entries in the game
    public List<Weapon_Data> allWeapons;
    
    // Singleton instance for easy access
    private static Database_Weapons Instance { get; set; }
    
    // Awake is called when the script instance is being loaded
    void Awake()
    {
        // Ensure only one instance of the database exists
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Optional: Persist across scenes
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    /// <summary>
    /// Gets weapon data by weapon name. Might be better to use IDs in the future.
    /// </summary>
    /// <param name="weaponName">Has to be the right name</param>
    /// <returns></returns>
    public static Weapon_Data GetWeaponByName(string weaponName)
    {
        if (Instance == null)
        {
            Debug.LogError("Database_Weapons instance is not initialized.");
            return null;
        }
        
        foreach (var weapon in Instance.allWeapons)
        {
            if (weapon.weaponName == weaponName)
            {
                return weapon;
            }
        }
        
        Debug.LogWarning($"Weapon with name {weaponName} not found in database.");
        return null;
    }
}
