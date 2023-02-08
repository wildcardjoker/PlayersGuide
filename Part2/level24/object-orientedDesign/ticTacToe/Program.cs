// Ideally, we'd put these classes into separate files.
// As the book hasn't introduced that feature yet, we'll stick with the "All classes in one file" design.

Console.Title = "Tic Tac Toe";
var board         = new Board();
var turn          = 0;
var player1       = new Player(Cell.X);
var player2       = new Player(Cell.O);
var currentplayer = player1;

// Allow 9 turns only - 3x3 grid = 9 turns. If no winner, it's a draw
while (turn < 9)
{
    DisplayBoard();
    Console.WriteLine($"\nIt's {currentplayer.Symbol}'s turn");
    currentplayer.GetSquare(board);
    currentplayer = currentplayer == player1 ? player2 : player1;
    turn++;
}

DisplayBoard();
Console.WriteLine("\nIt's a draw. Let's play again...");

void DisplayBoard()
{
    Console.Clear();
    var separator = "---+---+---";
    Console.WriteLine($" {board.GetCellValue(0, 0)} | {board.GetCellValue(0, 1)} | {board.GetCellValue(0, 2)}");
    Console.WriteLine(separator);
    Console.WriteLine($" {board.GetCellValue(1, 0)} | {board.GetCellValue(1, 1)} | {board.GetCellValue(1, 2)}");
    Console.WriteLine(separator);
    Console.WriteLine($" {board.GetCellValue(2, 0)} | {board.GetCellValue(2, 1)} | {board.GetCellValue(2, 2)}");
}

public class Board
{
    #region Fields
    private readonly Cell[,] _cells = new Cell[3, 3];
    #endregion

    public string GetCellValue(int x, int y) => _cells[x, y] switch
    {
        Cell.Empty => " ",
        Cell.O     => "O",
        Cell.X     => "X",
        _          => " "
    };

    public bool IsEmpty(Square square)   => IsEmpty(square.X, square.Y);
    public bool IsEmpty(int    x, int y) => _cells[x, y] == Cell.Empty;

    public void SetCell(Square square, Cell value)         => SetCell(square.X, square.Y, value);
    public void SetCell(int    x,      int  y, Cell value) => _cells[x, y] = value;
}

public class Player
{
    #region Constructors
    public Player(Cell symbol) => Symbol = symbol;
    #endregion

    #region Properties
    public Cell Symbol {get; set;}
    #endregion

    public void GetSquare(Board board)
    {
        var    isValidSquare = false;
        Square square;
        do
        {
            Console.WriteLine("Please use the number pad to select a square: ");
            square = Console.ReadKey().Key switch
            {
                ConsoleKey.NumPad7 => new Square(0,  0),
                ConsoleKey.NumPad8 => new Square(0,  1),
                ConsoleKey.NumPad9 => new Square(0,  2),
                ConsoleKey.NumPad4 => new Square(1,  0),
                ConsoleKey.NumPad5 => new Square(1,  1),
                ConsoleKey.NumPad6 => new Square(1,  2),
                ConsoleKey.NumPad1 => new Square(2,  0),
                ConsoleKey.NumPad2 => new Square(2,  1),
                ConsoleKey.NumPad3 => new Square(2,  2),
                _                  => new Square(-1, -1)
            };
            if (square.X == -1 || square.Y == -1)
            {
                Console.WriteLine("Invalid selection");
            }
            else if (!board.IsEmpty(square))
            {
                Console.WriteLine("That square is already taken");
            }
            else
            {
                isValidSquare = true;
            }
        }
        while (!isValidSquare);

        board.SetCell(square, Symbol);
    }
}

public class Square
{
    #region Constructors
    public Square(int x, int y)
    {
        X = x;
        Y = y;
    }
    #endregion

    #region Properties
    public int X {get;}
    public int Y {get;}
    #endregion
}

/// <summary>
///     Possible values for each cell
/// </summary>
public enum Cell
{
    Empty,
    X,
    O
}