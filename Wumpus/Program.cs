/************************************************************************************************** 
* Main Program
* 
* Author: Sean Malone
* 
* Description: This class contains the Main method and the interface for the player. This class
*              does not contain any functionality for the game. That is handled in the other
*              classes. This class is for the structure of the game.
**************************************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wumpus
{
    class Program
    {
        static void Main(string[] args)
        {
            /**************************************************************************************
             * New instance of Game
             * 
             * This is not used because all of the attributes and methods needed are static.
             * Creating the instance is needed to initialize everything in the class.
             * 
             * @property game        - Initialized Game singleton
             * @property quit        - Did the player choose to quit?
             * @property gameNum     - Check if first game or not for certain messages
             * @property playerStart - The start room for the player
             * @property wumpusStart - The start room for the wumpus.
             *************************************************************************************/
            Game game = new Game();
            bool quit = false;
            int gameNum = 0;
            Room playerStart = Game.Player.Room;
            Room wumpusStart = Game.Wumpus.Room;

            /**************************************************************************************
             * Welcome Message
             *************************************************************************************/
            Console.WriteLine("       **********************************************************" +
                              "*******");
            Console.WriteLine("\n                         Welcome to Hunt the Wumpus!\n");
            Console.WriteLine("       **********************************************************" +
                              "*******");
            Console.WriteLine("\nYour mission is to explore the maze of caves in search of the " +
                "legendary creatureknown as the Wumpus. You'll encounter many perils along your " +
                "journey, but don't despair. You can do it.!");
            Console.WriteLine("\n\nPress any key to continue...");

            /**************************************************************************************
             * Wait for player to press "ANY" key
             *************************************************************************************/
            wait();

            /**************************************************************************************
             * Game Loop
             * 
             * Loop through the game until the player chooses to quit (q or Q)
             * 
             * @property input - String input from player
             *************************************************************************************/
            while (!quit)
            {
                string input;

                /**********************************************************************************
                 * Clear Screen
                 *********************************************************************************/
                Console.Clear();

                /**********************************************************************************
                 * Main Menu
                 *********************************************************************************/
                Console.WriteLine("       **********************************************************" +
                              "*******");
                Console.WriteLine("\n                                  Main Menu\n");
                Console.WriteLine("       **********************************************************" +
                                  "*******");
                Console.WriteLine(Game.Status);
                Game.Status = "";

                Console.WriteLine("\nPlease select an option below:");
                Console.WriteLine("I: Instructions\tP: Play\tQ: Quit");
                input = Console.ReadLine();
                Console.WriteLine();

                /**********************************************************************************
                 * Check input from user:
                 *     I(i) - Display instructions
                 *     P(p) - Play the game
                 *     Q(q) - Quit the game
                 *********************************************************************************/
                if (input.ToLower() == "i")
                {
                    instructions();
                }
                else if (input.ToLower() == "p")
                {
                    /******************************************************************************
                     * If the player chooses to replay, they are given the option to keep the same
                     * setup or start with a fresh setup.
                     *****************************************************************************/
                    if (gameNum > 0)
                    {
                        do
                        {
                            Console.WriteLine("Would you like to use the same setup or play a " +
                                              "new Game?");
                            Console.WriteLine("S: Same\tN: New");
                            input = Console.ReadLine();
                            Console.Clear();

                            if (input.ToLower() == "n")
                            {
                                newGame(ref playerStart, ref wumpusStart);
                            }
                            else if (input.ToLower() == "s")
                            {
                                Console.WriteLine("Keeping same setup...");
                            }
                            else
                            {
                                Console.WriteLine("Invalid input");
                            }

                        } while (input.ToLower() != "n" && input.ToLower() != "s");
                    }

                    /******************************************************************************
                     * Reset the Player and the Wumpus the to start state of the game
                     *****************************************************************************/
                    Game.Player.Room = playerStart;
                    Game.Player.Alive = true;
                    foreach (Arrow arrow in Game.Player.Arrows)
                        arrow.Shot = false;
                    Game.Wumpus.Room = wumpusStart;
                    Game.Wumpus.Alive = true;

                    /******************************************************************************
                     * Start the game
                     *****************************************************************************/
                    play();

                    /******************************************************************************
                     * Iterate game number
                     *****************************************************************************/
                    gameNum++;
                }
                else if (input.ToLower() == "q")
                {
                    quit = true;
                }
                else
                    Game.Status = "That is not a valid choice.";
               
            } // End Main loop

            /**************************************************************************************
             * Game Over message
             *************************************************************************************/
            Console.WriteLine("Thank you for playing \"Hunt the Wumpus\"");
            Console.WriteLine("Press any key to exit.");

            /**************************************************************************************
             * Wait for player to press "ANY" key
             *************************************************************************************/
            wait();
        } // End Main

        /******************************************************************************************
         * Wait
         * 
         * This method simply waits for an input from the user. Your basic everyday "ANY" key.
         *****************************************************************************************/
        static void wait()
        {
            Console.ReadKey();
        } // End Wait

        /******************************************************************************************
         * Instructions
         *****************************************************************************************/
        static void instructions()
        {
            /**************************************************************************************
             * First page
             *************************************************************************************/
            Console.WriteLine(
                "The wumpus lives in a cave of 20 rooms. Each room has 3 tunnels leading to\n" +     
                "other rooms. (Look at a dodecahedron to see how this works - if you don't know\n" + 
                "what a dodecahedron is, ask someone).\n\n" +                                          
                                                                               
                "Hazards\n" +                                                                        
                "Bottomless pits - two rooms have bottomless pits in them. If you go there, you\n" + 
                "fall into the pit (& lose!)\n\n" +                                                    
                "Super bats - two other rooms have super bats.  If you go there, a bat grabs you\n" +
                "and takes you to some other room at random. (Which may be troublesome).\n\n" +        
                                                                               
                "Wumpus\n" +                                                                         
                "The wumpus is not bothered by hazards (he has sucker feet and is too big for a\n" +
                "bat to lift).  Usually he is asleep.  Two things wake him up: you shooting an\n" + 
                "arrow or you entering his room. \n\n" +                                                
                                                                               
                "If the wumpus wakes he moves (p=.75) one room or stays still (p=.25).  After\n" +   
                "that, if he is where you are, he eats you up and you lose!\n\n" +                     
                                                                               
                "You\n" +                                                                            
                "Each turn you may move or shoot a crooked arrow.\n" +                               
                "Moving: you can move one room (thru one tunnel).\n" +                               
                "*** MORE ***"
            );

            /**************************************************************************************
             * Wait for player to press "ANY" key
             *************************************************************************************/
            wait();

            /**************************************************************************************
             * Erase *** MORE *** to give a more seamless feel
             *************************************************************************************/
            Console.SetCursorPosition(0, Console.CursorTop - 1);

            /**************************************************************************************
             * Second page
             *************************************************************************************/
            Console.WriteLine(                               
                "Arrows: you have 5 arrows. You lose when you run out. Each arrow can go from 1\n" + 
                "to 5 rooms. You aim by telling the computer the rooms you want the arrow to go\n" + 
                "to.  If the arrow can't go that way (if no tunnel) it moves at random to the\n" +   
                "next room. If the arrow hits the wumpus, you win.  If the arrow hits you, you\n" +  
                "lose.\n\n" +                                                                          
                                                                               
                "Warnings\n" +                                                                       
                "When you are one room away from a wumpus or hazard, the computer says:\n\n" +         
                                                                               
                "Wumpus: \"I smell a wumpus\"\n" +                                                     
                "Bat: \"Bats nearby\"\n" +                                                             
                "Pit: \"I feel a draft\"\n" +
                "\n\nPress any key to return..."
            );

            /**************************************************************************************
             * Wait for player to press "ANY" key
             *************************************************************************************/
            wait();

        } // End Instructions

        /******************************************************************************************
         * Play Game
         * 
         * This method is the interface for the play option in the menu. This method does not
         * perform any game actions. It assumes that all actions will be taken care of in the
         * appropriate objects and methods.
         * 
         * The game is setup in turns. The game will continue until either the player chooses to
         * quit, the player kills the Wumpus, or the player dies. Before the beginning of each
         * turn the game checks to see what rooms are adjacent to the current room and what 
         * hazards reside in those rooms. The game will inform the player of these rooms and
         * hazards before prompting the player to choose an option.
         * 
         * The player has three choices at the beginning of each turn:
         *     S(s) - Shoot: The player can shoot an arrow into up to 5 rooms
         *     M(m) - Move:  The player can move into anyone of the 3 adjacent rooms.
         *     Q(q) - Quit:  The player can quit the current game instance.
         *     
         * After the player's turn is over, it is the Wumpus' turn to move. The Wumpus is
         * controlled by the game, so the player has no options during it's turn.
         * 
         * Once the player and the Wumpus end their turns, the game checks to see if the player 
         * or the Wumpus has died. If so, the game displays the appropriate message and the
         * game is over.
         * 
         * @property gameOver - Boolean determining whether the game is over
         * @property input    - String input from the player
         *****************************************************************************************/
        static void play()
        {
            bool gameOver = false;  // Is the game over
            string input = "z";     // Input from user

            /**************************************************************************************
             * Loop through each turn until the Game Over signal has been triggered
             *************************************************************************************/
            while (!gameOver)
            {
                /**********************************************************************************
                 * Clear the screen
                 *********************************************************************************/
                Console.Clear();

                /**********************************************************************************
                 * Player's Turn
                 * 
                 * Prompt the player for theirchoice. Continue looping through prompt until a 
                 * valid input is received. The game takes the appropriate action based on the 
                 * player's choice.
                 *********************************************************************************/
                while (input.ToLower() != "s" && input.ToLower() != "m" && input.ToLower() != "q")
                {
                    /******************************************************************************
                     * Turn Status
                     *****************************************************************************/
                    turnStatus();

                    Console.WriteLine("Shoot, Move, or Quit (S-M-Q) ?");
                    input = Console.ReadLine();

                    if (input.ToLower() == "s")
                    {
                        // Call Shoot method
                        shoot();
                    }
                    else if (input.ToLower() == "m")
                    {
                        // Call move method
                        move();
                    }
                    else if (input.ToLower() == "q")
                    {
                        // Set gameover to true to exit loop
                        gameOver = true;
                    }
                    else
                        Game.Status = "That is not a valid input.";
                } // End S-M-Q loop

                // Reset input so loop isn't infinite
                input = "z"; 

                /**********************************************************************************
                 * Check if player killed the Wumpus
                 *********************************************************************************/
                if (!Game.Wumpus.Alive)
                {
                    gameOver = true;
                }

                /**********************************************************************************
                 * Wumpus' Turn
                 * 
                 * Call the move method for the Wumpus. The move method takes care of checking
                 * whether the Wumpus kills the player.
                 *********************************************************************************/
                if(Game.Wumpus.Awake)
                    Game.Wumpus.move();

                /**********************************************************************************
                 * Check if player has died
                 *********************************************************************************/
                if (!Game.Player.Alive)
                {
                    Console.WriteLine("You are dead!");

                    gameOver = true;
                }

                /**********************************************************************************
                 * Check if out of arrows
                 *********************************************************************************/
                if (Game.Player.RemainingArrows == 0)
                {
                    Console.WriteLine("\nYou Ran out of arrows. Game Over!");

                    gameOver = true;
                }

            } // End Game Over loop

            /**************************************************************************************
             * End of game message
             *************************************************************************************/
            Console.WriteLine("\nThanks for playing!\n");
            Console.WriteLine("Press any key to continue...");

            /**************************************************************************************
             * Wait for player to press "ANY" key
             *************************************************************************************/
            wait();

        } // End Play

        /******************************************************************************************
         * Turn Status
         * 
         * This method displays all of the status messages for the current turn. It checks each
         * room for a hazard and displays the proper warning if present. It then displays the 
         * players current room and the 3 adjacent rooms.
         *****************************************************************************************/
        static void turnStatus()
        {
            /**************************************************************************************
             * Clear screen
             *************************************************************************************/
            Console.Clear();

            /**************************************************************************************
             * Game Header
             *************************************************************************************/
            gameHeader();
            
            /**************************************************************************************
             * Warnings
             *************************************************************************************/
            foreach (Room room in Game.Player.Room.AdjRooms)
            {
                if (room.Wumpus)
                    Console.WriteLine("I smell a Wumpus!");
                else if (room.Hazard != null && room.Hazard.Type == "superbat")
                    Console.WriteLine("Bats nearby..");
                else if (room.Hazard != null && room.Hazard.Type == "pit")
                    Console.WriteLine("I feel a draft");
            } // End warnings

            /**************************************************************************************
             * Room status
             *************************************************************************************/
            Console.WriteLine("\nYou are in room {0}", Game.Player.Room.Number);
            Console.WriteLine(
                "Tunnels lead to: {0} {1} {2}",
                Game.Player.Room.AdjRooms[0].Number,
                Game.Player.Room.AdjRooms[1].Number,
                Game.Player.Room.AdjRooms[2].Number
            );
        } // End turn Status

        /******************************************************************************************
         * Game Header
         * 
         * Displays the title of the game and any status message
         *****************************************************************************************/
        static void gameHeader()
        {
            /**************************************************************************************
             * Header
             *************************************************************************************/
            Console.WriteLine("       **********************************************************" +
                              "*******");
            Console.WriteLine("\n                                Hunt the Wumpus!\n");
            Console.WriteLine("       **********************************************************" +
                              "*******");

            /**************************************************************************************
             * Status messages
             *************************************************************************************/
            Console.WriteLine("\n{0}\n", Game.Status);
            Game.Status = "";   // Clear status
        } // End Game header

        /******************************************************************************************
         * Shoot
         * 
         * This method is for the player interface for the shoot action of the game. 
         * This method does not check if there are any remaining arrows left. That is checked in 
         * the play() method above. This method assumes that all checks have been made. This 
         * method also does not perform the shoot action. That is done in the Trajectory property 
         * in the Arrow class. This method is for the preliminary interface for the player.
         * 
         * The player is first prompted for the number of rooms. The game checkes the input from
         * the user and prompts the user if it is invalid. The player is able to try again. Once
         * the number of arrows has been entered, the player then proceeds to enter the room 
         * numbers individually. Again, the game checks for valid input for each room 
         * individually. Once the rooms have been entered, the method calls the Trajectory 
         * property for the arrow.
         * 
         * @property roomString - String input from the player
         * @property numRooms   - Integer once parsed of the number of rooms to shoot the arrow.
         *****************************************************************************************/
        static void shoot()
        {
            /**************************************************************************************
             * If out of arrows, return
             *************************************************************************************/
            if (Game.Player.RemainingArrows == 0)
                return;

            /**************************************************************************************
             * Get number of rooms to shoot arrow.
             *************************************************************************************/
            int numRooms = numberRooms(); 

            /**************************************************************************************
             * Select Rooms
             *************************************************************************************/
            Room[] rooms = selectRooms(numRooms);
            
            /**************************************************************************************
             * Shoot the arrow
             *************************************************************************************/
            Arrow arrow = Game.Player.nextArrow();
            arrow.Trajectory = rooms;

            /**************************************************************************************
             * Check to see if the arrow hit the Wumpus
             *************************************************************************************/
            if (arrow.KillWumpus)
            {
                Console.WriteLine("\nAha! You got the Wumpus!");
                Console.WriteLine("\nHee hee hee! The Wumpus'll getcha next time.");

                Game.Wumpus.Alive = false;

                // Also check if player shot himself
                if (!Game.Player.Alive)
                {
                    Console.WriteLine("\nBut you also shot yourself. Ouch!");
                }
            }
            else if (!Game.Player.Alive)
            {
                Console.WriteLine("\nOutch! Arrow got you!");
            }
            else
            {
                Game.Status = "Missed!";
            }
        } // End Shoot

        /******************************************************************************************
         * Move
         * 
         * This method is for the player interface for the move action of the game. This method
         * does not perform the actual move action. That is performed in the move method of the
         * Player class. This method assumes all move actions are taken care of there.
         * 
         * The player is prompted for the room they wish to enter. If they player does not enter
         * a number of a valid room to enter, they are prompted to try again. Once a valid input
         * is received, the game moves the player to the new room. The game then checks to see
         * if the player wandered into a room with the Wumpus or another hazard. If so, the 
         * appropriate action is taken.
         * 
         * @property roomString - String input from the player
         * @property roomNumber - The integer once parsed of the room to enter
         *****************************************************************************************/
        static void move()
        {
            string roomString = "a";
            int roomNumber = -1;

            /**************************************************************************************
             * Prompt player for the room they wish to enter. Loop through the prompt until
             * a valid input is received.
             *************************************************************************************/
            while(!int.TryParse(roomString, out roomNumber) || roomNumber < 0 || roomNumber > 20)
            {
                /**********************************************************************************
                 * Turn Status
                 *********************************************************************************/
                turnStatus();

                Console.Write("Enter the room you wish to enter: ");
                roomString = Console.ReadLine();

                /**********************************************************************************
                 * Make sure input is a number
                 *********************************************************************************/
                if (!int.TryParse(roomString, out roomNumber) || roomNumber < 0 || roomNumber > 20
                    || Array.IndexOf(Game.Player.Room.AdjRooms, Game.Map[roomNumber]) < 0)
                {
                    Game.Status = "Invalid room number - Try again!";
                    roomString = "a";
                    continue;
                }

                /**********************************************************************************
                 * Go back to Action menu
                 *********************************************************************************/
                if (roomNumber == 0)
                {
                    play();
                }
            } // End get room number

            /**************************************************************************************
             * Move Player
             *************************************************************************************/
            Game.Player.move(roomNumber);

            /**************************************************************************************
             * Check for Hazards
             *************************************************************************************/
            if (Game.Player.Room.Hazard != null && Game.Player.Room.Hazard.Type == "superbat")
            {
                Game.Status = "\nZAP! -- SuperBat snatch! Elsewhereville for you!\n";

                Game.movePlayerRandom();
            }
            else if (Game.Player.Room.Hazard != null && Game.Player.Room.Hazard.Type == "pit")
            {
                Console.WriteLine("\nYYYIIIIEEEEE... fell in a pit!\n");

                Game.Player.Alive = false;
            }

            /**************************************************************************************
             * Check for Wumpus
             *************************************************************************************/
            if (Game.Player.Room.Wumpus)
            {
                Game.Status = "Oops! Bumped a wumpus!\n";
                Game.Wumpus.Awake = true;
            }

        } // End Move

        /******************************************************************************************
         * Number of Rooms
         * 
         * Prompt player for the number of rooms they wish to shoot the arrow. Loop through
         * the prompt until valid input is received. If not, then prompt the user to try again.
         * 
         * Return number of rooms
         * 
         * @property roomString - String input from the player
         * @property numRooms   - The integer once parsed of the number of rooms
         *****************************************************************************************/
        static int numberRooms()
        {
            string roomString = "a";
            int numRooms = -1;

            while (!int.TryParse(roomString, out numRooms) ||numRooms < 0 || numRooms > 5)
            {
                /**********************************************************************************
                 * Turn Status
                 *********************************************************************************/
                turnStatus();

                Console.WriteLine("Number of rooms? (0-5) ? ");
                roomString = Console.ReadLine();

                /**********************************************************************************
                 * If invalid input
                 *********************************************************************************/
                if ((!int.TryParse(roomString, out numRooms))
                    || numRooms < 0 || numRooms > 5)
                {
                    Game.Status = "Invalid number - Try again!";
                    roomString = "a";
                }
            } // End number of arrows loop

            return numRooms;
        } // End Number of rooms

        /******************************************************************************************
         * Select Rooms
         * 
         * Prompt user for room number. If invalid input is received, prompt user to try
         * again. Valid input must be a number and cannot be in the the previously
         * selected room. 
         * 
         * Return selected rooms
         * 
         * @parameter numRooms - Number of rooms to select
         * @property rooms     - Array holding the rooms
         *****************************************************************************************/
        static Room[] selectRooms(int numRooms) 
        {
            Room[] rooms = new Room[numRooms];

            /**************************************************************************************
             * Process each room
             * 
             * @property roomInput - String input from the player
             * @property room      - The integer once parsed of the room number
             *************************************************************************************/
            for (int i = 0; i < numRooms; i++)
            {
                string roomInput = "a";
                int room = -1;

                while (!int.TryParse(roomInput, out room) || (room < 0 || room > 20))
                {
                    /******************************************************************************
                    * Turn Status
                    ******************************************************************************/
                    turnStatus();

                    Console.Write("Room{0} #: ", i+1);
                    roomInput = Console.ReadLine();

                    /******************************************************************************
                     * Is the input valid?
                     *****************************************************************************/
                    if (!int.TryParse(roomInput, out room) || room < 0 || room > 20)
                        Game.Status = "Invalid room number - Try again!";

                    /******************************************************************************
                     * Is the arrow path valid?
                     *****************************************************************************/
                    if ((i > 1 && room == rooms[i-2].Number) 
                        || (i < 2 && room == Game.Player.Room.Number))
                    {
                        Game.Status = "Arrows are not that crooked! Try again!";
                        roomInput = "Invalid"; // Force the loop to continue
                    }
                } // End get room number

                /**********************************************************************************
                * Add room to the array of rooms
                **********************************************************************************/
                rooms[i] = Game.Map[room];

            } // End get room numbers loop

            return rooms;
        } // End Select rooms

        /******************************************************************************************
         * Instructions
         *****************************************************************************************/
        static void newGame(ref Room playerStart, ref Room wumpusStart)
        {
            /**************************************************************************************
             * Create new instanaces of the game pieces
             *************************************************************************************/
            Game.Player = new Player();
            Game.Wumpus = new Wumpus();
            Game.Superbats = new Hazard[]{
                new Hazard("superbat"),
                new Hazard("superbat"),
            };
            Game.Pits = new Hazard[] {
                new Hazard("pit"),
                new Hazard("pit"),
            };

            /**************************************************************************************
             * Reinitialize the board
             *************************************************************************************/
            Game.initBoard();

            /**************************************************************************************
             * Change the start room for the player and the Wumpus
             *************************************************************************************/
            playerStart = Game.Player.Room;
            wumpusStart = Game.Wumpus.Room;
        } // End New game

    } // End Program
} // End Document