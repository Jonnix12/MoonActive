using MoonActive.Algorithms;
using NUnit.Framework;

public class VictoryAlgorithmTest
{
    VictoryAlgorithm _victoryAlgorithm = new VictoryAlgorithm(4);

    #region Horizontal

    [Test,Category("Horizontal")]
    public void VictoryAlgorithm_MidTopHorizontal_Victory()
    {
        _victoryAlgorithm.OverrideCurrentTopRaw(4);
        int[,] board = new int[,]
        {
            {0,0,0,0,0,0},
            {0,0,0,0,1,0},
            {0,0,0,0,1,0},
            {0,0,0,0,1,0},
            {0,0,0,0,1,0},
            {0,0,0,0,0,0},
            {0,0,0,0,0,0}
        };

        var result = _victoryAlgorithm.CheckForVictory(board, 1, 4, 1);

        Assert.AreEqual(1, result);
    }
    
    [Test]
    public void VictoryAlgorithm_RightTopHorizontal_Victory()
    {
        _victoryAlgorithm.OverrideCurrentTopRaw(4);

        int[,] board = new int[,]
        {
            {0,0,0,0,0,0},
            {0,0,0,0,0,0},
            {0,0,0,0,0,0},
            {0,0,0,0,1,0},
            {0,0,0,0,1,0},
            {0,0,0,0,1,0},
            {0,0,0,0,1,0}
        };

        var result = _victoryAlgorithm.CheckForVictory(board, 3, 4, 1);

        Assert.AreEqual(1, result);
    }
    
    [Test,Category("Horizontal")]
    public void VictoryAlgorithm_RightTopHorizontal_Loss()
    {
        _victoryAlgorithm.OverrideCurrentTopRaw(4);

        int[,] board = new int[,]
        {
            {0,0,0,0,0,0},
            {0,0,0,0,0,0},
            {0,0,0,0,0,0},
            {0,0,0,0,1,0},
            {0,0,0,0,1,0},
            {0,0,0,0,1,0},
            {0,0,0,0,0,0}
        };

        var result = _victoryAlgorithm.CheckForVictory(board, 3, 4, 1);

        Assert.AreEqual(-1, result);
    }
    
    [Test,Category("Horizontal")]
    public void VictoryAlgorithm_MidTopHorizontal_Loss()
    {
        _victoryAlgorithm.OverrideCurrentTopRaw(4);

        int[,] board = new int[,]
        {
            {0,0,0,0,0,0},
            {0,0,0,0,0,0},
            {0,0,0,0,1,0},
            {0,0,0,0,1,0},
            {0,0,0,0,0,0},
            {0,0,0,0,1,0},
            {0,0,0,0,0,0}
        };

        var result = _victoryAlgorithm.CheckForVictory(board, 2, 4, 1);

        Assert.AreEqual(-1, result);
    }
    
    [Test,Category("Horizontal")]
    public void VictoryAlgorithm_MidMidHorizontal_Victory()
    {
        _victoryAlgorithm.OverrideCurrentTopRaw(4);

        int[,] board = new int[,]
        {
            {0,0,0,0,0,0},
            {0,0,0,0,0,0},
            {0,0,1,0,0,0},
            {0,0,1,0,0,0},
            {0,0,1,0,0,0},
            {0,0,1,0,0,0},
            {0,0,0,0,0,0}
        };

        var result = _victoryAlgorithm.CheckForVictory(board, 2, 2, 1);

        Assert.AreEqual(1, result);
    }
    

    #endregion

    #region Vertical

    [Test,Category("Vertical")]
    public void VictoryAlgorithm_MidTopVertical_Victory()
    {
        _victoryAlgorithm.OverrideCurrentTopRaw(4);

        int[,] board = new int[,]
        {
            {0,0,0,0,0,0},
            {0,0,0,0,0,0},
            {0,0,1,1,1,1},
            {0,0,0,0,0,0},
            {0,0,0,0,0,0},
            {0,0,0,0,0,0},
            {0,0,0,0,0,0}
        };

        var result = _victoryAlgorithm.CheckForVictory(board, 2, 5, 1);

        Assert.AreEqual(1, result);
    }
    
    [Test,Category("Vertical")]
    public void VictoryAlgorithm_MidMidVertical_Victory()
    {
        _victoryAlgorithm.OverrideCurrentTopRaw(4);

        int[,] board = new int[,]
        {
            {0,0,0,0,0,0},
            {0,0,0,0,0,0},
            {0,0,0,0,0,0},
            {0,1,1,1,1,0},
            {0,0,0,0,0,0},
            {0,0,0,0,0,0},
            {0,0,0,0,0,0}
        };

        var result = _victoryAlgorithm.CheckForVictory(board, 3, 4, 1);

        Assert.AreEqual(1, result);
    }
    
    [Test,Category("Vertical")]
    public void VictoryAlgorithm_LeftMidVertical_Victory()
    {
        _victoryAlgorithm.OverrideCurrentTopRaw(4);

        int[,] board = new int[,]
        {
            {0,1,1,1,1,0},
            {0,0,0,0,0,0},
            {0,0,0,0,0,0},
            {0,0,0,0,0,0},
            {0,0,0,0,0,0},
            {0,0,0,0,0,0},
            {0,0,0,0,0,0}
        };

        var result = _victoryAlgorithm.CheckForVictory(board, 0, 4, 1);

        Assert.AreEqual(1, result);
    }

    #endregion

    #region DiagonalBottomLeftToTopRight
    
    //BLTR = Bottom Left To Top Right
    
    [Test,Category("Diagonal Bottom Left To Top Right")]
    public void VictoryAlgorithm_MidMidDiagonal_BLTR_Victory()
    {
        _victoryAlgorithm.OverrideCurrentTopRaw(4);

        int[,] board = new int[,]
        {
            {0,0,0,0,0,0},
            {0,1,0,0,0,0},
            {0,0,1,0,0,0},
            {0,0,0,1,0,0},
            {0,0,0,0,1,0},
            {0,0,0,0,0,0},
            {0,0,0,0,0,0}
        };

        var result = _victoryAlgorithm.CheckForVictory(board, 4, 4, 1);

        Assert.AreEqual(1, result);
    }
    
    [Test,Category("Diagonal Bottom Left To Top Right")]
    public void VictoryAlgorithm_RightMidDiagonal_BLTR_Victory()
    {
        _victoryAlgorithm.OverrideCurrentTopRaw(4);

        int[,] board = new int[,]
        {
            {0,0,0,0,0,0},
            {0,0,0,0,0,0},
            {0,0,0,0,0,0},
            {0,1,0,0,0,0},
            {0,0,1,0,0,0},
            {0,0,0,1,0,0},
            {0,0,0,0,1,0}
        };

        var result = _victoryAlgorithm.CheckForVictory(board, 6, 4, 1);

        Assert.AreEqual(1, result);
    }
    
    [Test,Category("Diagonal Bottom Left To Top Right")]
    public void VictoryAlgorithm_RightTopDiagonal_BLTR_Victory()
    {
        _victoryAlgorithm.OverrideCurrentTopRaw(4);

        int[,] board = new int[,]
        {
            {0,0,0,0,0,0},
            {0,0,0,0,0,0},
            {0,0,0,0,0,0},
            {0,0,1,0,0,0},
            {0,0,0,1,0,0},
            {0,0,0,0,1,0},
            {0,0,0,0,0,1}
        };

        var result = _victoryAlgorithm.CheckForVictory(board, 6, 5, 1);

        Assert.AreEqual(1, result);
    }
    
    [Test,Category("Diagonal Bottom Left To Top Right")]
    public void VictoryAlgorithm_LeftTopDiagonal_BLTR_Victory()
    {
        _victoryAlgorithm.OverrideCurrentTopRaw(4);

        int[,] board = new int[,]
        {
            {0,0,1,0,0,0},
            {0,0,0,1,0,0},
            {0,0,0,0,1,0},
            {0,0,0,0,0,1},
            {0,0,0,0,0,0},
            {0,0,0,0,0,0},
            {0,0,0,0,0,0}
        };

        var result = _victoryAlgorithm.CheckForVictory(board, 3, 5, 1);

        Assert.AreEqual(1, result);
    }
    
    [Test,Category("Diagonal Bottom Left To Top Right")]
    public void VictoryAlgorithm_RightBottomDiagonal_BLTR_Victory()
    {
        _victoryAlgorithm.OverrideCurrentTopRaw(4);

        int[,] board = new int[,]
        {
            {0,0,0,0,0,0},
            {0,0,0,0,0,0},
            {0,0,0,0,0,0},
            {1,0,0,0,0,0},
            {0,1,0,0,0,0},
            {0,0,1,0,0,0},
            {0,0,0,1,0,0}
        };

        var result = _victoryAlgorithm.CheckForVictory(board, 6, 3, 1);

        Assert.AreEqual(1, result);
    }

    #endregion

    #region DiagonalBottomRightToTopLeft
    
    //BRTL = Bottom Right To Top Left
    
    [Test,Category("Diagonal Bottom Right To Top Left")]
    public void VictoryAlgorithm_MidMidDiagonal_BRTL_Victory()
    {
        _victoryAlgorithm.OverrideCurrentTopRaw(4);

        int[,] board = new int[,]
        {
            {0,0,0,0,0,0},
            {0,0,0,0,1,0},
            {0,0,0,1,0,0},
            {0,0,1,0,0,0},
            {0,1,0,0,0,0},
            {0,0,0,0,0,0},
            {0,0,0,0,0,0}
        };

        var result = _victoryAlgorithm.CheckForVictory(board, 1, 4, 1);

        Assert.AreEqual(1, result);
    }
    
    [Test,Category("Diagonal Bottom Right To Top Left")]
    public void VictoryAlgorithm_RightMidDiagonal_BRTL_Victory()
    {
        _victoryAlgorithm.OverrideCurrentTopRaw(4);

        int[,] board = new int[,]
        {
            {0,0,0,0,0,0},
            {0,0,0,0,0,0},
            {0,0,0,0,0,0},
            {0,0,0,0,1,0},
            {0,0,0,1,0,0},
            {0,0,1,0,0,0},
            {0,1,0,0,0,0}
        };

        var result = _victoryAlgorithm.CheckForVictory(board, 6, 1, 1);

        Assert.AreEqual(1, result);
    }
    
    [Test,Category("Diagonal Bottom Right To Top Left")]
    public void VictoryAlgorithm_RightTopDiagonal_BRTL_Victory()
    {
        _victoryAlgorithm.OverrideCurrentTopRaw(4);

        int[,] board = new int[,]
        {
            {0,0,0,0,0,0},
            {0,0,0,0,0,0},
            {0,0,0,0,0,0},
            {0,0,0,0,0,1},
            {0,0,0,0,1,0},
            {0,0,0,1,0,0},
            {0,0,1,0,0,0}
        };

        var result = _victoryAlgorithm.CheckForVictory(board, 3, 5, 1);

        Assert.AreEqual(1, result);
    }
    
    [Test,Category("Diagonal Bottom Right To Top Left")]
    public void VictoryAlgorithm_LeftTopDiagonal_BRTL_Victory()
    {
        _victoryAlgorithm.OverrideCurrentTopRaw(4);

        int[,] board = new int[,]
        {
            {0,0,0,0,0,1},
            {0,0,0,0,1,0},
            {0,0,0,1,0,0},
            {0,0,1,0,0,0},
            {0,0,0,0,0,0},
            {0,0,0,0,0,0},
            {0,0,0,0,0,0}
        };

        var result = _victoryAlgorithm.CheckForVictory(board, 0, 5, 1);

        Assert.AreEqual(1, result);
    }
    
    [Test,Category("Diagonal Bottom Right To Top Left")]
    public void VictoryAlgorithm_RightTopDiagonal_BRTL_Loss()
    {
        _victoryAlgorithm.OverrideCurrentTopRaw(4);

        int[,] board = new int[,]
        {
            {0,0,0,0,0,0},
            {0,0,0,0,0,0},
            {0,0,0,0,0,0},
            {0,0,0,0,0,0},
            {0,0,0,0,0,1},
            {0,0,0,0,1,0},
            {0,0,0,1,0,0}
        };

        var result = _victoryAlgorithm.CheckForVictory(board, 4, 5, 1);

        Assert.AreEqual(-1, result);
    }

    #endregion
}
