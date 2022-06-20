var result = queensAttack(5, 2, 3, 3, new List<List<int>>() { new List<int>() { 2,4 }, new List<int>() { 2, 2 }, new List<int>() { 4, 4 }, new List<int>() { 4, 2 },
                                                                     new List<int>() { 3,4 }, new List<int>() { 3, 2 }, new List<int>() { 2, 3 }, new List<int>() { 4, 3 },
                                                                     new List<int>() { 3,5 }, new List<int>() { 3, 1 }, new List<int>() { 1, 3 }, new List<int>() { 5, 3 },
                                                                     new List<int>() { 1,5 }, new List<int>() { 1, 1 }, new List<int>() { 5, 5 }, new List<int>() { 5, 1 }});

Console.WriteLine(result);

result = queensAttack(4, 0, 4, 4, new List<List<int>>());

Console.WriteLine(result);

int queensAttack(int n, int k, int r_q, int c_q, List<List<int>> obstacles)
{
    int attackCount = 0;

    attackCount += left((r_q, c_q), n, obstacles);
    attackCount += right((r_q, c_q), n, obstacles);
    attackCount += top((r_q, c_q), n, obstacles);
    attackCount += bottom((r_q, c_q), n, obstacles);
    attackCount += leftTop((r_q, c_q), n, obstacles);
    attackCount += rightTop((r_q, c_q), n, obstacles);
    attackCount += leftBottom((r_q, c_q), n, obstacles);
    attackCount += rightBottom((r_q, c_q), n, obstacles);

    return attackCount;
}

int left((int, int) queen_location, int boardSize, List<List<int>> obstacles)
{
    var obstacleList = obstacles.Where(x => (x[0] == queen_location.Item1) && x[1] < queen_location.Item2);

    return (queen_location.Item2 - 1) - (obstacleList.Count() == 0 ? 0 : obstacleList.Select(x => x[1]).Max());
}

int right((int, int) queen_location, int boardSize, List<List<int>> obstacles)
{
    var obstacleList = obstacles.Where(x => (x[0] == queen_location.Item1) && x[1] > queen_location.Item2);

    var c = obstacleList.Count();
    return boardSize - queen_location.Item2 - (boardSize - (obstacleList.Count() == 0 ? boardSize : obstacleList.Select(x => x[1]).Min() - 1));
}

int top((int, int) queen_location, int boardSize, List<List<int>> obstacles)
{
    var obstacleList = obstacles.Where(x => (x[1] == queen_location.Item2) && x[0] > queen_location.Item1);

    return boardSize - queen_location.Item1 - (boardSize - (obstacleList.Count() == 0 ? boardSize : obstacleList.Select(x => x[0]).Min() - 1));
}

int bottom((int, int) queen_location, int boardSize, List<List<int>> obstacles)
{
    var obstacleList = obstacles.Where(x => (x[1] == queen_location.Item2) && x[0] < queen_location.Item1);

    return (queen_location.Item1 - 1) - (obstacleList.Count() == 0 ? 0 : obstacleList.Select(x => x[0]).Max());
}

int leftTop((int, int) queen_location, int boardSize, List<List<int>> obstacles)
{
    var obstacleList = obstacles.Where(x => ((x[0] - queen_location.Item1) == (queen_location.Item2) - x[1]) && x[1] < queen_location.Item2);

    var leftCount = queen_location.Item2 - 1;
    var topCount = boardSize - queen_location.Item1;

    var qAttack = leftCount > topCount ? topCount : leftCount;

    var oAttack = 0;

    if (obstacleList.Count() > 0)
    {
        var maxColumn = obstacleList.Select(x => x[1]).Max();
        leftCount = maxColumn;
        topCount = boardSize - (queen_location.Item1 + queen_location.Item2 - maxColumn) + 1;

        oAttack = leftCount > topCount ? topCount : leftCount;
    }

    return qAttack - oAttack;
}

int rightTop((int, int) queen_location, int boardSize, List<List<int>> obstacles)
{
    var obstacleList = obstacles.Where(x => ((x[0] - queen_location.Item1) == (x[1] - queen_location.Item2)) && x[1] > queen_location.Item2);

    var rightCount = boardSize - queen_location.Item2;
    var topCount = boardSize - queen_location.Item1;

    var qAttack = rightCount > topCount ? topCount : rightCount;

    var oAttack = 0;

    if (obstacleList.Count() > 0)
    {
        var minColumn = obstacleList.Select(x => x[1]).Min();
        rightCount = boardSize - minColumn + 1;
        topCount = boardSize - (queen_location.Item1 - queen_location.Item2 + minColumn) + 1;

        oAttack = rightCount > topCount ? topCount : rightCount;
    }

    return qAttack - oAttack;
}

int leftBottom((int, int) queen_location, int boardSize, List<List<int>> obstacles)
{
    var obstacleList = obstacles.Where(x => ((x[0] - queen_location.Item1) == (x[1] - queen_location.Item2)) && x[1] < queen_location.Item2);

    var leftCount = queen_location.Item2 - 1;
    var bottomCount = queen_location.Item1 - 1;

    var qAttack = leftCount > bottomCount ? bottomCount : leftCount;

    var oAttack = 0;

    if (obstacleList.Count() > 0)
    {
        var maxColumn = obstacleList.Select(x => x[1]).Max();
        leftCount = maxColumn;
        bottomCount = (queen_location.Item1 - queen_location.Item2 + maxColumn);

        oAttack = leftCount > bottomCount ? bottomCount : leftCount;
    }

    return qAttack - oAttack;
}

int rightBottom((int, int) queen_location, int boardSize, List<List<int>> obstacles)
{
    var obstacleList = obstacles.Where(x => ((x[0] - queen_location.Item1) == (queen_location.Item2) - x[1]) && x[1] > queen_location.Item2);

    var rightCount = boardSize - queen_location.Item2;
    var topCount = queen_location.Item1 - 1;

    var qAttack = rightCount > topCount ? topCount : rightCount;

    var oAttack = 0;

    if (obstacleList.Count() > 0)
    {
        var minColumn = obstacleList.Select(x => x[1]).Min();
        rightCount = boardSize - minColumn + 1;
        topCount = (queen_location.Item1 + queen_location.Item2 - minColumn);

        oAttack = rightCount > topCount ? topCount : rightCount;
    }

    return qAttack - oAttack;
}