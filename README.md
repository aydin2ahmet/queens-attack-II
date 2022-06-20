# Queens Attack II

You will be given a square chess board with one queen and a number of obstacles placed on it. Determine how  many squares the queen can attack. A queen is standing on an n x n chessboard. The chess board's rows are numbered from 1 to n, going from  bottom to top. Its columns are numbered from 1 to n, going from left to right. Each square is referenced by a tuple, (r, c), describing the row, r, and column, c, where the square is located. The queen is standing at position (rq, cq). In a single move, she can attack any square in any of the eight directions (left, right, up, down, and the four diagonals)


Function Description

Complete the queensAttack function in the editor below.

queensAttack has the following parameters:
- int n: the number of rows and columns in the board
- nt k: the number of obstacles on the board
- int r_q: the row number of the queen's position
- int c_q: the column number of the queen's position
- int obstacles[k][2]: each element is an array of  integers, the row and column of an obstacle


Returns
- int: the number of squares the queen can attack
