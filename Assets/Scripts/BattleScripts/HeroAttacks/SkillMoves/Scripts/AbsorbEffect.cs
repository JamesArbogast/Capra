using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*public class AbsorbEffect : MonoBehaviour {

    public float absorbTimeLimit = 9f;
    public float absorbCurrentTime = 0f;
    public float meleeDamageAbsorbed;
    public float zuliumDamageAbsorbed;
    public HeroStateMachine heroStateMachine;
    public BattleStateMachine battleStateMachine;
    public float speedDecrease = 10f;
    public float currentHeroesSpeed;
    public float currentHeroesPhysDefense;
    public float currentHeroesZuliumDefense;
    public bool absorbEffectIsActive;
    public BattleStateMachine battleState;


    public void Start()
    {
        currentHeroesSpeed = battleState.PerformList[0].attackersTarget.GetComponent<HeroStateMachine>().hero.speed;
        currentHeroesPhysDefense = battleState.PerformList[0].attackersTarget.gameObject.GetComponent<HeroStateMachine>().hero.physDefense;
        currentHeroesZuliumDefense = battleState.PerformList[0].attackersTarget.gameObject.GetComponent<HeroStateMachine>().hero.zuliumDefense;
        meleeDamageAbsorbed = battleState.PerformList[0].attackersTarget.GetComponent<HeroStateMachine>().hero.absorbCurrentAmount;
        zuliumDamageAbsorbed = battleState.PerformList[0].attackersTarget.GetComponent<HeroStateMachine>().hero.absorbCurrentAmount;
        absorbEffectIsActive = battleState.PerformList[0].attackersTarget.GetComponent<HeroStateMachine>().absorbActive;
        absorbEffectIsActive = false;
    }

    public void Update()
    {
        if (absorbEffectIsActive == true)
        {
            Debug.Log("Absorb Is Active!");
            UseAbsorbEffect();
            absorbCurrentTime = +Time.deltaTime;
            Debug.Log(absorbCurrentTime);

            if (absorbCurrentTime <= absorbTimeLimit)
            {
                StatChanges();
                AbsorbMeleeDamage(meleeDamageAbsorbed);
                AbsorbZuliumDamage(zuliumDamageAbsorbed);
                //this.gameObject.GetComponent<HeroStateMachine>().progressBar.material.color = new Color32(105, 105, 105, 255);
            }
            else
            {
                absorbEffectIsActive = false;
                Debug.Log("Absorb Is  NOT Active!");
            }
        }
    }

    public void UseAbsorbEffect()
    {
        absorbEffectIsActive = true;
    }

    public void StatChanges()
    {
        currentHeroesSpeed = currentHeroesSpeed - 0.003f;
        currentHeroesPhysDefense = currentHeroesPhysDefense + 10;
        currentHeroesZuliumDefense += 10;
    }

    public void AbsorbMeleeDamage(float getAbsorbMeleeAmount)
    {
        if(absorbEffectIsActive)
        {
            meleeDamageAbsorbed =+ getAbsorbMeleeAmount;
        }
    }

    public void AbsorbZuliumDamage(float getAbsorbZuliumAmount)
    {
        if (absorbEffectIsActive)
        {
           meleeDamageAbsorbed =+ getAbsorbZuliumAmount;
        }
    }
}*/
