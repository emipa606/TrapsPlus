using System;
using System.Reflection;
using UnityEngine;
using Verse;
using BetaTraps;

namespace RimWorld
{
	// Token: 0x02000004 RID: 4
	public class Building_BodySlicerTrap : Building_TrapRearmable
	{
		// Token: 0x06000009 RID: 9 RVA: 0x00002328 File Offset: 0x00000528
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

		// Token: 0x0600000A RID: 10 RVA: 0x000023B4 File Offset: 0x000005B4
		private void DamagePawn(Pawn p)
		{
			BodyPartHeight height = BodyPartHeight.Middle;
			int num = Mathf.RoundToInt(this.GetStatValue(StatDefOf.TrapMeleeDamage, true) * Building_BodySlicerTrap.TrapDamageFactor.RandomInRange);
			int randomInRange = Building_BodySlicerTrap.DamageCount.RandomInRange;
			for (int i = 0; i < randomInRange; i++)
			{
				bool flag = num <= 0;
				if (flag)
				{
					break;
				}
				int num2 = Mathf.Max(1, Mathf.RoundToInt(Rand.Value * (float)num));
				num -= num2;
				DamageInfo damageInfo = new DamageInfo(DamageDefOf.Cut, num2, 0, -1f, this, null, null, DamageInfo.SourceCategory.ThingOrUnknown);
				damageInfo.SetBodyRegion(height, BodyPartDepth.Outside);
				p.TakeDamage(damageInfo);
			}
		}

		// Token: 0x04000006 RID: 6
		private static readonly FloatRange TrapDamageFactor = new FloatRange(0.7f, 1.3f);

		// Token: 0x04000007 RID: 7
		private static readonly IntRange DamageCount = new IntRange(1, 2);
	}
}
