/************************************************************************************************** 
* Player
* 
* Author: Sean Malone
* 
* Description: This class contains the attributes and behaviors for the Player.
**************************************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wumpus
{
    class Player
    {
        /******************************************************************************************
         * Attributes
         * 
         * @property arrows  - Array of arrows
         * @property room    - Current room where the player resides
         * @property alive   - Is the player alive?
         *****************************************************************************************/
        private Arrow[] arrows;
        private Room room;
        private bool alive;

        /******************************************************************************************
         * Constructors
         *****************************************************************************************/
        // No parameters
        public Player()
        {
            room = null;

            arrows = new Arrow[]{
                new Arrow(),
                new Arrow(),
                new Arrow(),
                new Arrow(),
                new Arrow()
            };
        }

        // Start room
        public Player(Room start)
        {
            room = start;

            arrows = new Arrow[]{
                new Arrow(),
                new Arrow(),
                new Arrow(),
                new Arrow(),
                new Arrow()
            };
        }

        // Start room and arrows
        public Player(Room start, Arrow[] arrows)
        {
            room = start;
            this.arrows = arrows;
        }

        /******************************************************************************************
         * room Property
         * 
         * This property hold this room where the player is roomly
         *****************************************************************************************/
        public Room Room
        {
            get
            {
                return room;
            }
            set
            {
                room = value;
            }
        } // End Room

        /******************************************************************************************
         * Arrows Property
         * 
         * This property hold this list of arrows the player has
         *****************************************************************************************/
        public Arrow[] Arrows
        {
            get
            {
                return arrows;
            }
            set
            {
                arrows = value;
            }
        } // End Arrows

        /******************************************************************************************
         * Alive Property
         * 
         * Is the player alive?
         *****************************************************************************************/
        public bool Alive
        {
            get
            {
                return alive;
            }
            set
            {
                alive = value;
            }
        } // End Alive

        /******************************************************************************************
         * Remaining Arrows Property
         * 
         * This property is the number of arrows remaining in the quiver.
         *****************************************************************************************/
        public int RemainingArrows
        {
            get
            {
                int count = 0;

                foreach (Arrow arrow in arrows)
                {
                    if (!arrow.Shot)
                        count++;
                }

                return count;
            }
        } // End Remaining arrows

        /******************************************************************************************
         * Remaining Arrows Method
         * 
         * This method retrieves the next arrow if available
         *****************************************************************************************/
        public Arrow nextArrow()
        {
            // Check if any arrows are left
            foreach (Arrow arrow in arrows)
            {
                if (!arrow.Shot)
                    return arrow;
            }

            // If not arrows are left
            return null;
        } // End nextArrow

        /******************************************************************************************
         * Shoot Arrow
         * 
         * @property rooms - Array of rooms to send to trajectory
         * 
         * First convert the integer room numbers to Room objects via the map. Then set the 
         * trajectory for the arrow. The arrow will check if it hit the Wumpus and return the
         * result.
         *****************************************************************************************/
        public bool shoot(Arrow arrow, int[] roomNumbers)
        {
            Room[] rooms = new Room[5];

            // Convert each roomNumber into a room
            foreach (int room in roomNumbers)
            {
                rooms[room - 1] = Game.Map[room];
            }

            // Set trajectory (Shoot arrow)
            arrow.Trajectory = rooms;

            // Return whether the arrow killed the Wumpus
            return arrow.KillWumpus;
        } // End shoot

        /******************************************************************************************
         * Move Player
         * 
         * @property rooms - Array of rooms to send to trajectory
         * 
         * Sets the room room for the player to the Room object in the map corresponding to
         * the integer room number entered.
         *****************************************************************************************/
        public void move(int roomNumber)
        {
            room = Game.Map[roomNumber];
        } // End move
    } // End Player
} // End Document
