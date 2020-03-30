using System;
using System.Reflection;
using UnityEngine;
using Verse;
using BetaTraps;

namespace RimWorld
{
	// Token: 0x02000002 RID: 2
	public class Building_BearTrap : Building_TrapRearmable
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		protected override void SpringSub(Pawn p)
		{
			typeof(Building_TrapRearmable).GetField("armedInt", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(this, false);
			bool flag = p != null;
			if (flag)
			{
				this.DamagePawn(p);
			}
			bool flag2 = (bool)typeof(Building_TrapRearmable).GetField("autoRearm", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(this);
			if (flag2)
			{
				base.Map.designationManager.AddDesignation(new Designation(this, BetaTrapDefOf.RearmTrap));
			}
		}

		// Token: 0x06000002 RID: 2 RVA: 0x000020DC File Offset: 0x000002DC
		private void DamagePawn(Pawn p)
		{
			BodyPartHeight height = BodyPartHeight.Bottom;
			int num = Mathf.RoundToInt(this.GetStatValue(StatDefOf.TrapMeleeDamage, true) * Building_BearTrap.TrapDamageFactor.RandomInRange);
			int randomInRange = Building_BearTrap.DamageCount.RandomInRange;
			for (int i = 0; i < randomInRange; i++)
			{
				bool flag = num <= 0;
				if (flag)
				{
					break;
				}
				int num2 = Mathf.Max(1, Mathf.RoundToInt(Rand.Value * (float)num));
				num -= num2;
				DamageInfo damageInfo = new DamageInfo(DamageDefOf.Stab, num2, 0, -1f, this, null, null, DamageInfo.SourceCategory.ThingOrUnknown);
				DamageInfo damageInfo2 = new DamageInfo(DamageDefOf.Stun, num2, 0, -1f, this, null, null, DamageInfo.SourceCategory.ThingOrUnknown);
				damageInfo.SetBodyRegion(height, BodyPartDepth.Outside);
				p.TakeDamage(damageInfo2);
				p.TakeDamage(damageInfo);
			}
		}

		// Token: 0x04000001 RID: 1
		private static readonly FloatRange TrapDamageFactor = new FloatRange(0.7f, 1.3f);

		// Token: 0x04000002 RID: 2
		private static readonly IntRange DamageCount = new IntRange(1, 2);
	}
}
