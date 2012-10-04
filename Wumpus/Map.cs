/************************************************************************************************** 
* Map
* 
* Author: Sean Malone
* 
* Description: This class holds the list of Room objects for the game. 
**************************************************************************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wumpus
{
    class Map: IEnumerable<Room>
    {
        private List<Room> rooms;

        /****************************************************************************************** 
         * Constructors
         * 
         * The map is hardcoded, so the map is constructed
         * manually.
         *****************************************************************************************/
        // No parameters
        public Map()
        {
            rooms = new List<Room>();

            // Add rooms to map
            rooms.Add(new Room(0)); // Used as a null room
            rooms.Add(new Room(1));
            rooms.Add(new Room(2));
            rooms.Add(new Room(3));
            rooms.Add(new Room(4));
            rooms.Add(new Room(5));
            rooms.Add(new Room(6));
            rooms.Add(new Room(7));
            rooms.Add(new Room(8));
            rooms.Add(new Room(9));
            rooms.Add(new Room(10));
            rooms.Add(new Room(11));
            rooms.Add(new Room(12));
            rooms.Add(new Room(13));
            rooms.Add(new Room(14));
            rooms.Add(new Room(15));
            rooms.Add(new Room(16));
            rooms.Add(new Room(17));
            rooms.Add(new Room(18));
            rooms.Add(new Room(19));
            rooms.Add(new Room(20));

            // Add adjacent rooms to each room (Hardcoded)
            rooms[1].AdjRooms  = new Room[] { rooms[2], rooms[3], rooms[6] };
            rooms[2].AdjRooms  = new Room[] { rooms[1], rooms[4], rooms[8] };
            rooms[3].AdjRooms  = new Room[] { rooms[1], rooms[5], rooms[10] };
            rooms[4].AdjRooms  = new Room[] { rooms[2], rooms[5], rooms[13] };
            rooms[5].AdjRooms  = new Room[] { rooms[3], rooms[4], rooms[14] };
            rooms[6].AdjRooms  = new Room[] { rooms[1], rooms[7], rooms[9] };
            rooms[7].AdjRooms  = new Room[] { rooms[6], rooms[8], rooms[15] };
            rooms[8].AdjRooms  = new Room[] { rooms[2], rooms[7], rooms[11] };
            rooms[9].AdjRooms  = new Room[] { rooms[6], rooms[10], rooms[16] };
            rooms[10].AdjRooms = new Room[] { rooms[3], rooms[9], rooms[12] };
            rooms[11].AdjRooms = new Room[] { rooms[8], rooms[13], rooms[17] };
            rooms[12].AdjRooms = new Room[] { rooms[10], rooms[14], rooms[18] };
            rooms[13].AdjRooms = new Room[] { rooms[4], rooms[11], rooms[20] };
            rooms[14].AdjRooms = new Room[] { rooms[5], rooms[12], rooms[20] };
            rooms[15].AdjRooms = new Room[] { rooms[7], rooms[16], rooms[17] };
            rooms[16].AdjRooms = new Room[] { rooms[9], rooms[15], rooms[18] };
            rooms[17].AdjRooms = new Room[] { rooms[11], rooms[15], rooms[19] };
            rooms[18].AdjRooms = new Room[] { rooms[12], rooms[16], rooms[19] };
            rooms[19].AdjRooms = new Room[] { rooms[17], rooms[18], rooms[20] };
            rooms[20].AdjRooms = new Room[] { rooms[13], rooms[14], rooms[19] };
        }

        /****************************************************************************************** 
         * Allow access to rooms directly through Map object
         * Ex. Room1 => map[1]
         *****************************************************************************************/
        public Room this[int index]
        {
            get
            {
                return rooms[index];
            }
            set
            {
                rooms[index] = value;
            }
        } // End Indexer

        /****************************************************************************************** 
         * Primitive property to get room (READ-ONLY)
         *****************************************************************************************/
        public List<Room> Rooms
        {
            get
            {
                return rooms;
            }
        } // End Room


        /****************************************************************************************** 
         * Enumerable<Room>
         *****************************************************************************************/
        public IEnumerator<Room> GetEnumerator()
        {
            return rooms.GetEnumerator();
        } // End GetEnumerator

        /****************************************************************************************** 
         * Enumerable
         *****************************************************************************************/
        IEnumerator<Room> IEnumerable<Room>.GetEnumerator()
        {
            return GetEnumerator();
        } // End <Room>.GetEnumerator

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        } // End General.GetEnumerator
    } // End Map
} // End Document
