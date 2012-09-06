using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wumpus
{
    class Room
    {
        private int roomNumber = -1;        // Room Number
        private Room[] adjacentRooms = null; // Adjacent Rooms
        private bool player = false;        // Is the player in the room?
        private bool wumpus = false;        // Is the Wumpus in the room?
        private string hazard = "None";     // What hazard is in the room?

        /* Constructors */
        // All parameters with default values
        public Room(int room, Room[] adjRooms = null, bool player = false, bool wumpus = false, string hazard = "None")
        {
            roomNumber = room;
            adjacentRooms = adjRooms;
            this.player = player;
            this.wumpus = wumpus;
            this.hazard = hazard;
        }

        /* Properties */

        // Room number
        public int Name
        {
            get
            {
                return roomNumber;
            }
            set
            {
                roomNumber = value;
            }
        }

        // Adjacent rooms
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
        }

        // Player in room
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
        }

        // Wumpus in room
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
        }

        // Hazard in room
        public string Hazard
        {
            get
            {
                return hazard;
            }
            set
            {
                hazard = value;
            }
        }

        public override string ToString()
        {
            string returnString = "Room " + roomNumber + " (Adjacent Rooms: ";
            foreach (Room room in adjacentRooms)
            {
                returnString += room.Name + " ";
            }
            returnString += ", Player: " + player 
                + ", Wumpus: " + wumpus 
                + ", Hazard: " + hazard + ")";

            return returnString;
        }
    }
}
