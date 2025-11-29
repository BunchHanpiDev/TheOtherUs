using UnityEngine;

namespace TheOtherRoles.Roles.Crewmate
{
	public static class Crewmate
	{
		public static PlayerControl crewmate;
		public static Color color = Palette.White;
		public static void clearAndReload()
		{
			crewmate = null;
		}
	}
}
