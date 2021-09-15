using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInformation : MonoBehaviour
{



    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    public static List<BaseAbility> playersAbilities;

    //public static BaseEquipment Equipment1 { get; set; }
    public static string CharacterName { get; set; }
    public static string CharacterBio { get; set; }
    public static int CharacterLevel { get; set; }
    public static BaseCharacterClass CharacterClass { get; set; }
    public static int HealthPoints { get; set; }
    public static int ZuliumPoints { get; set; }
    public static int Speed { get; set; }
    public static int PhysAttack { get; set; }
    public static int PhysDefense { get; set; }
    public static int Dodge { get; set; }
    public static int ZuliumAttack { get; set; }
    public static int ZuliumDefense { get; set; }
    public static int ZuliumHeal { get; set; }
    public static int Resist { get; set; }
    public static int Energy { get; set; }
    public static int Luck { get; set; }
    public static int Intelligence { get; set; }
    public static int CurrentXP { get; set; }
    public static int RequiredXP { get; set; }
    public static int Quol { get; set; }

    public static BaseAbility playerMoveOne = new Attack();
    public static BaseAbility playerMoveTwo = new SwordSlash();

    public static int PlayerHealth { get; set; }
    public static int PlayerEnergy { get; set; }

   
}
