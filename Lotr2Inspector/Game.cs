using Lotr2Inspector.Structs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lotr2Inspector
{
	/**
	 * Let's just call this rudimentary DI. A container for an active game.
	 * 
	 */
	public class Game
	{
		public const int DEFAULT_THREAD_SLEEP = 50;

		public static List<List<String>> MapTowns
		{
			get; set;
		}

		static Viewport Viewport
		{
			get; set;
		}

		public static Maps Maps
		{
			get; set;
		}

		public static CurrentGame CurrentGame
		{
			get; set;
		}

		public static State State
		{
			get; set;
		}

		public static Calendar Calendar
		{
			get; set;
		}

		public static Town[] Towns
		{
			get; set;
		}

		public static Player[] Players
		{
			get; set;
		}

		public static Tile[,] Tiles
		{
			get; set;
		}

		private static bool initialized = false;

		static public void init()
		{
			if (initialized == false)
			{
				Maps = null; // Initialized in the dashboard
				MapTowns = null; // Initialized in the dashboard
				CurrentGame = new CurrentGame();
				Viewport = new Viewport();
				State = new State();
				Calendar = new Calendar();
				Towns = new Town[Config.MAX_TOWNS];
				Players = new Player[Config.MAX_PLAYERS];
				Tiles = new Tile[Config.TILES_X, Config.TILES_Y];

				for(int i = 0; i < Config.MAX_PLAYERS; i++)
				{
					Players[i] = new Player(i);
				}

				for (int i = 0; i < Config.MAX_TOWNS; i++)
				{
					Towns[i] = new Town(i);
				}

				for (int x = 0; x < Config.TILES_X; x++)
				{
					for (int y = 0; y < Config.TILES_Y; y++)
					{
						Tiles[x, y] = new Tile(x + 1, y + 1);
					}
				}

				initialized = true;
			}
		}
	}
}
