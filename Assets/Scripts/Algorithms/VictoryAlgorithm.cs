using System;
using MoonActive.Board;

namespace MoonActive.Algorithms
{
    /*
     * I built an algorithm that instead of checking the entire board on each turn, I only check if the last move was the winning move.
     * The algorithm works very simply, every time something puts a disk into the board I take its position and check every possible combination with the new point.
     * I divided the Algorithms into 5 parts:
     * Horizontal,
     * Vertical,
     * DiagonalVictoryBottomRightToTopLeft,
     * DiagonalVictoryBottomLeftToTopRight,
     * Draw
     *
     * Every time I have to find my starting point and my ending point, the points are basically the minimum in each direction according to the streak number.
     * The calculation for each starting point and end point is different for each test type.
     * After I found the start and end points, I start running my tests, I check each time from the starting point and counting the number of streaks and if there was no win(meaning that not every object I passed belonged to the player I am checking now) I move on to the next starting point.
     * If I went through all the possible combinations and there was no win, I move on to the next test.
     * A victory is defined by the fact that if I managed to pass one check and all its objects belonged to the player who played the last turn.
     */
    public class VictoryAlgorithm
    {
        private readonly int _streakCount;
        private int _currentTopRaw = 0;

        public VictoryAlgorithm(int streakCount)
        {
            _streakCount = streakCount;
        }

        public int CheckForVictory(int[,] board, DropPoint lastDropPoint, int player)
        {
            return CheckForVictory(board, lastDropPoint.Colum, lastDropPoint.Raw,player);
        }

        public int CheckForVictory(int[,] board, int newDiskColum, int newDiskRaw, int player)
        {
            
            //Here I have defined what is the highest row at the moment, because if the top row has not passed the number of streakCount then there is no reason to check Vertical and diagonals
            if (newDiskRaw > _currentTopRaw)
                _currentTopRaw = newDiskRaw;

            int maxColums = board.GetLength(0);
            int maxRows = board.GetLength(1);


            if (CheckForHorizontalVictory() == player)
                return player;

            if (_currentTopRaw < _streakCount - 1)
                return -1;

            if (CheckForVerticalVictory() == player)
                return player;
            if (CheckForDiagonalVictoryBottomRightToTopLeft() == player)
                return player;
            if (CheckForDiagonalVictoryBottomLeftToTopRight() == player)
                return player;
        
            if (_currentTopRaw < maxRows - 1)
                return -1;
        
            if (CheckForDraw() == 0)
                return 0;
        
            return -1;
            
            //I split my tests into 5 local functions
            
            int CheckForHorizontalVictory()
            {
                int startColum;
                int endColum;
                /*
                 * Here I find the starting column,
                 * basically my starting point is to take my streak number minus one objects to the left (towards the 0)
                 * and from there start checking to the right (towards the maximum column)
                 */
                if (newDiskColum - (_streakCount - 1) < 0)
                    startColum = 0;
                else
                    startColum = newDiskColum - (_streakCount - 1);
                /*
                 * Finding my end point works on the same concept,
                 * only that once I check that I haven't reached the maximum column
                 */
                if (newDiskColum + _streakCount - 1 >= maxColums - 1)
                    endColum = maxColums - 1;
                else
                    endColum = newDiskColum + _streakCount;
            
                /*
                 * The outer loop goes through each possible combination
                 * by increasing the points by one each time a new combination is entered.
                 */
                for (var i = startColum; i <= endColum - (_streakCount - 1); i++)
                {
                    int streakCount; //Number of times I was able to find a matching object in the sequence
                    /*
                     * The inner loop checks the current combination
                     * and as soon as it finds that one of the objects is not equal to the number
                     * representing the current player, it exits and fails
                     */
                    for (streakCount = 0; streakCount < _streakCount; streakCount++)
                    {
                        if (board[i + streakCount,newDiskRaw] != player)
                        {
                            break;
                        }
                    }
                    /*
                     * After each coincidence check I check if my streak number matched the defined streak number,
                     * if so I found a win and I return the number representing the player
                     */
                    if (streakCount == _streakCount)
                    {
                        return player;
                    }
                }
                //If I went through all the combinations and didn't find a win I return -1 from the current check
                return -1;
            }
        
            int CheckForVerticalVictory()
            {
                /*
                 * The vertical test is just like the horizontal test
                 * except that I find my start and end raw
                 */
                int startRaw = 0;
                int endRaw = 0;
            
                if (newDiskRaw - _streakCount < 0)
                    startRaw = 0;
                else
                    startRaw = newDiskRaw - _streakCount;
            
                if (newDiskRaw + _streakCount >= maxRows)
                    endRaw = maxRows;
                else
                    endRaw = newDiskRaw + _streakCount;

            
                for (var i = startRaw; i < endRaw - 3; i++)
                {
                    int streakCount;

                    for (streakCount = 0; streakCount < _streakCount; streakCount++)
                    {
                        if (board[newDiskColum,i + streakCount] != player)
                        {
                            break;
                        }
                    }

                    if (streakCount == _streakCount)
                    {
                        return player;
                    }
                }

                return -1;
            }
            
            /*
           * Here we enter the more creative part of the algorithm. In this part,
           * I had to find the starting point of a diagonal,
           * which is a little more problematic than a straight line.
           */
            
            int CheckForDiagonalVictoryBottomRightToTopLeft()
            {
                int startColum = 0;
                int startRaw = 0;
                
                /*
                 * In order to find my starting point I had to use very simple graph mathematics,
                 * with the help of subtractions and additions of the point where my new object is in I reached the my starting point.
                 */
                if (newDiskColum == maxColums - 1)//If I'm in my maximum column because I check that bottom right to top left I have no reason to change them and I can start from the point of the new object
                {
                    startColum = newDiskColum; 
                    startRaw = newDiskRaw;
                }
                else
                {
                    /*
                     * The calculation I do is a additions between the new row and the new column to find my starting point,
                     * in the event that the result is greater than the maximum column,
                     * I perform a subtraction between the additions of the new row and the new column to the maximum column to find the remainder and that is my starting point
                     */
                    if ((newDiskRaw + newDiskColum) > maxColums - 1)
                    {
                        startColum = maxColums - 1;
                        startRaw = (newDiskRaw + newDiskColum) - (maxColums - 1);
                    }
                    else
                    {
                        startColum = newDiskRaw + newDiskColum;
                        startRaw = 0;
                    }
                }
                /*
                 * The concept of the test itself is very similar to the other tests,
                 * only the way I get my starting point is different
                 */
                for (var i = 0; i < maxColums - 3; i++)
                {
                    int streakCount;

                    for (streakCount = 0; streakCount < _streakCount; streakCount++) 
                    {
                        if (startColum - (i + streakCount) < 0 || startRaw + i + streakCount >= maxRows)
                            return -1;

                        if (board[startColum - (i + streakCount),startRaw + i + streakCount] != player) break;
                    }
            
                    if (streakCount == _streakCount)
                    {
                        return player;
                    }
                }

                return -1;
            }
        
            int CheckForDiagonalVictoryBottomLeftToTopRight()
            {
                int startColum = 0;
                int startRaw = 0;
            
        
                if (newDiskColum == 0)//As in the previous test, if I'm at the end of the board (column 0) I don't need to do any calculations
                {
                    startColum = newDiskColum;
                    startRaw = newDiskRaw;
                }
                else
                {
                    /*
                     * The concept of the calculation is similar to the previous test, only slightly different implementation
                     */
                    if ((newDiskRaw - newDiskColum) < 0)
                    {
                        startColum = Math.Abs(newDiskRaw - newDiskColum);
                        startRaw = 0;
                    }
                    else
                    {
                        startRaw = newDiskRaw - newDiskColum;
                        startColum = 0;
                    }
                }
        
                for (var i = 0; i < maxColums - (_streakCount - 1); i++)
                {
                    int streakCount;

                    for (streakCount = 0; streakCount < _streakCount; streakCount++)
                    {
                        if (startColum + i + streakCount >= maxColums || startRaw + i + streakCount >= maxRows)
                            return -1;
                        
                        if (board[startColum + i + streakCount,startRaw + i + streakCount] != player)
                            break;
                    }
            
                    if (streakCount == _streakCount)
                    {
                        return player;
                    }
                }
        
                return -1;
            }
            //To check for a draw it was very simple to check if all the objects in the last row were full and there was no win
            int CheckForDraw()
            {
                for (int colum = 0; colum < maxColums; colum++)
                {
                    if (board[colum, maxRows - 1] == 0)
                    {
                        return -1;
                    }
                }

                return 0;
            }
        }
    
#if UNITY_EDITOR
        public void OverrideCurrentTopRaw(int currentTopRaw)
        {
            _currentTopRaw = currentTopRaw;
        }
#endif
    }
}