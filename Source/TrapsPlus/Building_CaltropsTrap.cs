using UnityEngine;
using Verse;

namespace RimWorld;

public class Building_CaltropsTrap : Building_Trap
{
    private static readonly FloatRange TrapDamageFactor = new(0.7f, 1.3f);

    private static readonly IntRange DamageCount = new(1, 2);

    private bool hitCount;

    private void damagePawn(Pawn p)
    {
        const BodyPartHeight height = BodyPartHeight.Bottom;
        var statValue = this.GetStatValue(StatDefOf.TrapMeleeDamage);
        var num = Mathf.RoundToInt(statValue * TrapDamageFactor.RandomInRange);
        var randomInRange = DamageCount.RandomInRange;
        for (var i = 0; i < randomInRange; i++)
        {
            if (!(num > 0))
            {
                break;
            }

            var num2 = Mathf.Max(1, Mathf.RoundToInt(Rand.Value * num));
            num -= num2;
            var damageInfo = new DamageInfo(DamageDefOf.Stab, num2, 0, -1f, this);
            damageInfo.SetBodyRegion(height, BodyPartDepth.Outside);
            p.TakeDamage(damageInfo);
            p.health.AddHediff(HediffDefOfTrap.SlowedTrap);
        }
    }

    protected override void SpringSub(Pawn p)
    {
        if (p != null && !hitCount)
        {
            damagePawn(p);
            hitCount = true;
        }
        else
        {
            if (hitCount)
            {
                hitCount = false;
            }
        }
    }
}