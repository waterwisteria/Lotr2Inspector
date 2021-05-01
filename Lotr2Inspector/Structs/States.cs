using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lotr2Inspector.Structs
{
    public class State : MemStruct
    {
        public Dictionary<long, bool> jumpySnapshots = new Dictionary<long, bool>();
        private long lastSnapshot = DateTimeOffset.Now.ToUnixTimeMilliseconds();
        private bool IsJumpy = false;
        private int resetJumpyness = 500; // in ms

        public State()
        {
            Item = 0;
            Offset = 0x0;
            BaseStructAddress = 0xEAC50;
            StructAddress = getStructAddress();
            Properties = StructProperties();
        }

        protected override Dictionary<string, MemStructProperty> StructProperties()
        {
            return new Dictionary<string, MemStructProperty>
            {
                {
                    "state",
                    new MemStructProperty(0x0, 1) // Refer to STATES for values and meaning
                },

                {
                    "active", // more like... logging? But accurately tells if game is inactive
                    new MemStructProperty(0x16C, 15) // Can be among many others: "OK :Not active", "OK :Active", "OK :Window move" for a split second when switching to desktop
                },

                {
                    "Jumpy",
                    new MemStructProperty(0xC3F00, 1)
                },

                {
                    "Fraggy",
                    new MemStructProperty(0xDE650, 36)
                }
            };
        }

        /**
         * Is app active
         * 
         */
        public bool IsActive()
        {
            String a = Get("active", true);

            // When game is closed the value of active becomes a bunch of null chars
            // which trim doesn't trim fully
            // is game is being played: if(a.Equals("OK :Sys2 Gfx loaded") || a.Equals("OK :Active. d."))
            if (a.Equals("OK :Not active.") || a.Equals("OK :Window move.") || a.Equals(""))
            {
                return false;
            }

            return true;
        }

        public bool IsPlaying()
        {
            String a = Get("active", true);

            // @TODO Doesn't work for alt-tabbing, not tested first
            if(a.Equals("OK :Sys2 Gfx loaded") || a.Equals("OK :Active. d."))
            {
                return true;
            }

            return false;
        }

        public bool IsJumpyJumpy()
        {
            return IsJumpy;
        }

        public void JumpySnapshot()
        {
            long timestamp = DateTimeOffset.Now.ToUnixTimeMilliseconds();

            // Reset every second
            if(timestamp > lastSnapshot + resetJumpyness)
            {
                // Calculate jumpyness. When it's stable it appears to jump around only 2 values.
                // Hover label jumps between 3 and 4
                // Menus at 5
                if(jumpySnapshots.Count() > 3)
                {
                    IsJumpy = true;
                }

                else
                {
                    IsJumpy = false;
                }

                jumpySnapshots.Clear();
                lastSnapshot = timestamp;
            }

            jumpySnapshots[Get("Jumpy")] = true;
        }

        // Some popups just don't register in the following address but these addresses do fricking wiggle
        // when a popup is open.
        // 5C 92 A0 (AKA fraggy): String that contains fragment of the popup message, stops at last value when closed
        // Lords2+1AEB50 (AKA jumpy): Usually (usually) stays at 32 (sometimes 2) and wiggles around (same values) when popup is raised

        /**
         * Not meant to be functional, just the values and meaning of the states located at 0x4EAC50
         * 
         */
        public static readonly Dictionary<String, int> STATES = new Dictionary<String, int>()
        {
            { "game", 0 }, // yup, that's why they're not ids
            { "world map", 0 }, // another case of yup
            { "town hall", 2 },
            { "tile help", 4 },
            { "merchant", 8 },
            { "court", 9 },
            { "armory", 10 },
            { "send message", 11 },
            { "merchant trading", 12 },
            { "weapon raise", 13 },
            { "blacksmith", 15 }, // another one! These people!!
            { "castle building", 15 },   // Althought it makes sense since this would be the in-game not-game full screen state
            { "town hall pop up", 15 }, // while game and world map are kinda the same state since only the map view changes
            { "army movement", 16 },   // However, the town hall popup having a state of 15 doesn't make sense
            { "battle", 18 },
            { "battle decided", 19 },
            { "population", 20 },
            { "tax", 21 },
            { "happiness", 22 },
            { "hire in the county", 23 },
            { "send supplies", 24 },
            { "rations", 25 },
            { "write message", 26 },
            { "castle", 27 },
            { "main menus", 31 },
            { "intro", 34 },
            { "country won", 34 }, // a video state maybe?
            { "end turn", 35 },
            { "start new game", 36 },
            { "popups", 39 },
            { "battle field", 41 },
            { "drop down menu selected", 50 }
        };
    }
}
