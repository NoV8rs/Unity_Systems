using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon Data", menuName = "Gun Systems/Weapon Data")]
public class Weapon_Data : ScriptableObject
{
    public enum WeaponType
    {
        Pistol,
        Rifle,
        Shotgun,
        Sniper,
        SMG
    }

    public enum FiringMode
    {
        SemiAutomatic,
        Automatic,
        Burst
    }

    public enum Rarity
    {
        Common,
        Uncommon,
        Rare,
        Epic,
        Legendary
    }
    
    [Header("Weapon Details")]
    public string weaponName = "New Weapon";
    public Sprite weaponSprite;
    public Weapon_Projectile projectilePrefab;
    
    [Header("Weapon Type")]
    public WeaponType weaponType = WeaponType.Pistol;
    public FiringMode firingMode = FiringMode.SemiAutomatic;
    public Rarity rarity = Rarity.Common;
    
    [Header("Weapon Stats")]
    public int weaponLevel = 1;
    public int damage = 10;
    public float growthFactor = 1.1f; // Damage growth per level
    public float fireRate = 0.5f; // Shots per second
    public int magazineSize = 30;
    public float reloadTime = 2f; // Seconds to reload
    public float recoilForce = 5f;
    
    
    // Methods for getting values

    #region Calculated Stats

    private float CalculateDamage()
    {
        DamageLevelScaling();
        RarityScaling();
        return DamageLevelScaling() * RarityScaling();
    }

    private float DamageLevelScaling()
    {
        // Damage is scaled by the growthFactor per level
        return damage * Mathf.Pow(growthFactor, weaponLevel - 1);
    }
    
    /// <summary>
    /// Returns a multiplier based on the weapon's rarity.
    /// </summary>
    /// <returns>Returns a number for the scaling the damage.</returns>
    private float RarityScaling()
    {
        float commonMultiplier = 1.0f;
        float uncommonMultiplier = 1.1f;
        float rareMultiplier = 1.25f;
        float epicMultiplier = 1.5f;
        float legendaryMultiplier = 2.0f;
        
        switch (rarity)
        {
            case Rarity.Common:
                return commonMultiplier;
            case Rarity.Uncommon:
                return uncommonMultiplier;
            case Rarity.Rare:
                return rareMultiplier;
            case Rarity.Epic:
                return epicMultiplier;
            case Rarity.Legendary:
                return legendaryMultiplier;
            default:
                return 1.0f;
        }
    }

    #endregion
}
