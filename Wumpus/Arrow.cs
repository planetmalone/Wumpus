/************************************************************************************************** 
* Arrow
* 
* Author: Sean Malone
* 
* Description: This class contains the attributes and behaviors for the Player's arrows.
**************************************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wumpus
{
    class Arrow
    {
        /******************************************************************************************
         * Attributes
         * 
         * @property trajectory - Rooms where the arrow will traverse
         * @property shot       - Boolean whether arrow has been shot
         * @property killWumpus - Boolean whether arrow killed Wumpus
         *****************************************************************************************/
        private Room[] trajectory; 
        private bool shot;
        private bool killWumpus;

        /******************************************************************************************
         * Constructors
         *****************************************************************************************/
        // No parameters
        public Arrow()
        {
            trajectory = null;
            shot = false;
            killWumpus = false;
        }

        // Trajectory
        public Arrow(Room[] traj)
        {
            trajectory = traj;
            shot = true;
            killWumpus = false;
        }

        /******************************************************************************************
         * Has the arrow been shot
         *****************************************************************************************/
        public bool Shot
        {
            get
            {
                return shot;
            }
            set
            {
                shot = value;
            }
        } // End Shot


        /******************************************************************************************
         * The setter processes the trajectory and adjusts it if necessary. It
         * also sets the killWumpus to true of the arrow enters a room that
         * contains the Wumpus.
         *****************************************************************************************/
        public Room[] Trajectory
        {
            get
            {
                return trajectory;
            }
            set
            {
                trajectory = value; // Get trajectory
                shot = true;        // Arrow has been shot

                // Wake the Wumpus
                Game.Wumpus.Awake = true;

                // For each room
                for (int i = 0; i < trajectory.Length; i++)
                {
                    Room room = trajectory[i];

                    // Check for next rooms as long as it's not the last room
                    if (i < trajectory.Length - 1)
                    {
                        Room nextRoom = trajectory[i + 1];

                        // If the next room is not adjacent, then retrieve
                        if (Array.IndexOf(room.AdjRooms, nextRoom) < 0)
                        {
                            trajectory[i + 1] = room.randomRoom();
                        }
                    }

                    // Check for Wumpus
                    if (room.Wumpus)
                    {
                        killWumpus = true;
                    }

                    // Check to see if arrow shot player
                    if (room.Player)
                    {
                        Game.Player.Alive = false;
                    }

                } // End Room loop
            } // End Trajectory setter
        } // End Trajectory

        /******************************************************************************************
         * This is a read-only property. The value is set by the Trajectory property. It returns
         * whether or not the Wumpus was killed by the arrow.
         *****************************************************************************************/
        public bool KillWumpus
        {
            get
            {
                return killWumpus;
            }
        } // End KillWumpus
    } // End Arrow
} // End document
