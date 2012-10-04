/************************************************************************************************** 
* Player
* 
* Author: Sean Malone
* 
* Description: This class contains the attributes and behaviors for each room in the map.
**************************************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wumpus
{
    class Room
    {
        /******************************************************************************************
         * Attributes
         * 
         * @property roomNumber    - Room number
         * @property adjacentRooms - Rooms next to this one 
         * @property player        - Is player in room?
         * @property wumpus        - Is wumpus in room?
         * @property wumpus        - Which hazard is in the room if any?
         *****************************************************************************************/
        private int roomNumber;       // Room Number
        private Room[] adjacentRooms; // Adjacent Rooms
        private bool player;          // Is the player in the room?
        private bool wumpus;          // Is the Wumpus in the room?
        private Hazard hazard;        // What hazard is in the room?

        /******************************************************************************************
         * Constructors
         *****************************************************************************************/
        // No parameters
        public Room() 
        {
            roomNumber = -1;
            adjacentRooms = null;
            player = false;
            wumpus = false;
            hazard = null;
        }

        // All parameters with default values
        public Room(int room, Room[] adjRooms = null, bool player = false, bool wumpus = false, 
            Hazard hazard = null)
        {
            roomNumber = room;
            adjacentRooms = adjRooms;
            this.player = player;
            this.wumpus = wumpus;
            this.hazard = hazard;
        }

        /******************************************************************************************
         * Name Property
         * 
         * Room number for the room.
         *****************************************************************************************/
        public int Number
        {
            get
            {
                return roomNumber;
            }
            set
            {
                roomNumber = value;
            }
        } // End Number

        /******************************************************************************************
         * Adjacent Rooms Property
         * 
         * List (array) or adjacent rooms.
         *****************************************************************************************/
        public Room[] AdjRooms
        {
            get
            {
                return adjacentRooms;
            }
            set
            {
                adjacentRooms = value;
            }
        } // End adjRooms

        /******************************************************************************************
         * Player Property
         * 
         * Boolean => Is the player in this room?
         *****************************************************************************************/
        public bool Player
        {
            get
            {
                return player;
            }
            set
            {
                player = value;
            }
        } // End Player

        /******************************************************************************************
         * Wumpus Property
         * 
         * Boolean => Is the Wumpus in this room?
         *****************************************************************************************/
        public bool Wumpus
        {
            get
            {
                return wumpus;
            }
            set
            {
                wumpus = value;
            }
        } // End Wumpus

        /******************************************************************************************
         * Hazard Property
         * 
         * Which hazard is in the room.
         *****************************************************************************************/
        public Hazard Hazard
        {
            get
            {
                return hazard;
            }
            set
            {
                hazard = value;
            }
        } // End Hazard

        /******************************************************************************************
         * Random Room
         * 
         * @property random - Random generator
         * 
         * Randomly picks a room and returns it.
         *****************************************************************************************/
        public Room randomRoom()
        {
            Random random = new Random();
            return adjacentRooms[random.Next(0, 2)];
        } // End randomRoom

        /******************************************************************************************
         * Object to string
         * 
         * Returns a string representing the room object.
         *****************************************************************************************/
        public override string ToString()
        {
            string returnString = "Room " + roomNumber + " (Adjacent Rooms: ";
            foreach (Room room in adjacentRooms)
            {
                returnString += room.Number + " ";
            }
            returnString += ", Player: " + player
                + ", Wumpus: " + wumpus;
 
            if(Hazard != null)
                returnString += ", Hazard: " + hazard.Type + ")";
            else
                returnString += ", Hazard: None)";

            return returnString;
        } // End ToString
    } // End Room
} // End document
