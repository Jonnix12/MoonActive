using System;
using MoonActive.Board;

namespace MoonActive.Algorithms
{
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

            int CheckForHorizontalVictory()
            {
                int startColum;
                int endColum;

                if (newDiskColum - (_streakCount - 1) < 0)
                    startColum = 0;
                else
                    startColum = newDiskColum - (_streakCount - 1);
            
                if (newDiskColum + _streakCount - 1 >= maxColums - 1)
                    endColum = maxColums - 1;
                else
                    endColum = newDiskColum + _streakCount;
            

                for (var i = startColum; i <= endColum - (_streakCount - 1); i++)
                {
                    int streakCount;

                    for (streakCount = 0; streakCount < _streakCount; streakCount++)
                    {
                        if (board[i + streakCount,newDiskRaw] != player)
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
        
            int CheckForVerticalVictory()
            {
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
        
            int CheckForDiagonalVictoryBottomRightToTopLeft()
            {
                int startColum = 0;
                int startRaw = 0;
            
        
                if (newDiskColum == maxColums - 1)
                {
                    startColum = newDiskColum; 
                    startRaw = newDiskRaw;
                }
                else
                {
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
            
        
                if (newDiskColum == 0)
                {
                    startColum = newDiskColum;
                    startRaw = newDiskRaw;
                }
                else
                {
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