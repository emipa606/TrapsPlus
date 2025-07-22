using System.Reflection;
using BetaTraps;
using UnityEngine;
using Verse;

namespace RimWorld;

public class Building_BearTrap : Building_TrapRearmable
{
    private static readonly FloatRange TrapDamageFactor = new(0.7f, 1.3f);

    private new static readonly IntRange DamageCount = new(1, 2);

    protected override void SpringSub(Pawn p)
    {
        typeof(Building_TrapRearmable).GetField("armedInt", BindingFlags.Instance | BindingFlags.NonPublic)
            ?.SetValue(this, false);
        if (p != null)
        {
            damagePawn(p);
        }

        if ((bool)typeof(Building_TrapRearmable)
                .GetField("autoRearm", BindingFlags.Instance | BindingFlags.NonPublic)
                ?.GetValue(this)!)
        {
            Map.designationManager.AddDesignation(new Designation(this, BetaTrapDefOf.RearmTrap));
        }
    }

    private void damagePawn(Pawn p)
    {
        const BodyPartHeight height = BodyPartHeight.Bottom;
        var num = Mathf.RoundToInt(this.GetStatValue(StatDefOf.TrapMeleeDamage) * TrapDamageFactor.RandomInRange);
        var randomInRange = DamageCount.RandomInRange;
        for (var i = 0; i < randomInRange; i++)
        {
            if (num <= 0)
            {
                break;
            }

            var num2 = Mathf.Max(1, Mathf.RoundToInt(Rand.Value * num));
            num -= num2;
            var damageInfo = new DamageInfo(DamageDefOf.Stab, num2, 0, -1f, this);
            var damageInfo2 = new DamageInfo(DamageDefOf.Stun, num2, 0, -1f, this);
            damageInfo.SetBodyRegion(height, BodyPartDepth.Outside);
            p.TakeDamage(damageInfo2);
            p.TakeDamage(damageInfo);
        }
    }
}