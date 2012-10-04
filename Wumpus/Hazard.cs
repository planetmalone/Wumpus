/************************************************************************************************** 
* Hazard
* 
* Author: Sean Malone
* 
* Description: This class contains the attributes and behaviors for all hazards in the game.
**************************************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wumpus
{
    class Hazard
    {
        /******************************************************************************************
         * Attributes
         * 
         * @property room  - The room where the hazard resides
         * @property type  - the type of Hazard
         *****************************************************************************************/
        protected Room room;
        protected string type;

        /******************************************************************************************
         * Constructors
         *****************************************************************************************/
        // No parameters
        public Hazard() 
        {
            room = null;
            type = "None";
        }

        // Type
        public Hazard(string type)
        {
            room = null;
            this.type = type;
        }

        // Type and room
        public Hazard(string type, Room room)
        {
            this.type = type;
            this.room = room;
        }

        /******************************************************************************************
         * Room Property
         * 
         * Room where the hazard resides
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
         * Room Property
         * 
         * The type of hazard
         *****************************************************************************************/
        public string Type
        {
            get
            {
                return type;
            }
            set
            {
                type = value;
            }
        } // End Type
    } // End Hazard
} // End Document
