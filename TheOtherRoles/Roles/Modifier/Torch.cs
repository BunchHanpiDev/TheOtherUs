using System.Collections.Generic;

namespace TheOtherRoles.Roles.Modifier
{
	public static class Torch
	{
		public static List<PlayerControl> torch = new List<PlayerControl>();
		public static int vision = 1;

		public static void clearAndReload()
		{
			torch = new List<PlayerControl>();
		}
	}
}
