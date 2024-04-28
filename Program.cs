namespace _2024_OX_Game_Text_Version
{
    internal class Program
    {
        static void Main(string[] args)
        {
            OXGameEngine engine = new OXGameEngine();
            char OX = 'X';//預設首玩家為X
            while (engine.IsWinner() == ' ') //當贏家出現遊戲將會結束
            {
                Console.WriteLine($"玩家{engine.CurrentPlayer} 請輸入橫向縱向座標(例如: 0 1,0 2)");//讓玩家輸入橫向縱向座標
                string[] Location = Console.ReadLine().Split(' ');//建立字串陣列存放座標
                int a = int.Parse(Location[0]);//將座標轉換成整數並存放到ab中
                int b = int.Parse(Location[1]);
                engine.SetMarker(a, b, engine.CurrentPlayer);//設定、紀錄座標數據
            }
            Console.WriteLine($"贏家為: {engine.IsWinner()}");//退出迴圈代表玩家出現，所以輸出贏家為?
        }
        public class OXGameEngine
        {
            //建立gameMarkers欄位，二維陣列紀錄OX座標
            private char[,] gameMarkers;
            //建立CurrentPlayer欄位，紀錄OX
            public char CurrentPlayer = 'X';

            public OXGameEngine()
            {
                gameMarkers = new char[3, 3];
                ResetGame();
            }
            //呼叫副程式紀錄OX座標
            public void SetMarker(int x, int y, char player)
            {
                if (IsValidMove(x, y))//先判斷判斷玩家下的位置是否合理，合理才會記錄、顯示遊戲畫面、輪換OX
                {
                    gameMarkers[x, y] = player;
                    DisplayBoard();//呼叫方法，在控制台上顯示當前遊戲畫面
                    ChangeOX();//呼叫方法，輪換OX
                }
                else
                {
                    Console.WriteLine("Invalid move! Please enter again.");
                }
            }
            //重製遊戲
            public void ResetGame()
            {
                gameMarkers = new char[3, 3];
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        gameMarkers[i, j] = ' ';
                    }
                }
            }
            //判斷誰是贏家
            public char IsWinner()
            {
                // 檢查橫向
                for (int i = 0; i < 3; i++)
                {
                    if (gameMarkers[i, 0] != ' ' && gameMarkers[i, 0] == gameMarkers[i, 1] && gameMarkers[i, 1] == gameMarkers[i, 2])
                    {
                        return gameMarkers[i, 0];
                    }
                }

                // 檢查縱向
                for (int j = 0; j < 3; j++)
                {
                    if (gameMarkers[0, j] != ' ' && gameMarkers[0, j] == gameMarkers[1, j] && gameMarkers[1, j] == gameMarkers[2, j])
                    {
                        return gameMarkers[0, j];
                    }
                }

                // 檢查對角線
                if (gameMarkers[0, 0] != ' ' && gameMarkers[0, 0] == gameMarkers[1, 1] && gameMarkers[1, 1] == gameMarkers[2, 2])
                {
                    return gameMarkers[0, 0];
                }

                if (gameMarkers[0, 2] != ' ' && gameMarkers[0, 2] == gameMarkers[1, 1] && gameMarkers[1, 1] == gameMarkers[2, 0])
                {
                    return gameMarkers[0, 2];
                }

                return ' '; // 沒有贏家出現
            }
            //判斷玩家下的位置是否合理
            public bool IsValidMove(int x, int y)
            {
                if (x < 0 || x >= 3 || y < 0 || y >= 3)
                {
                    return false;
                }

                if (gameMarkers[x, y] != ' ')
                {
                    return false;
                }

                return true;
            }
            //呼叫副程式取得座標
            public char GetMarker(int x, int y)
            {
                return gameMarkers[x, y];
            }
            //印出遊戲畫面的方法
            public void DisplayBoard()
            {
                Console.WriteLine("   |   |   ");
                Console.WriteLine($" {gameMarkers[0, 0]} | {gameMarkers[0, 1]} | {gameMarkers[0, 2]} ");
                Console.WriteLine("---+---+---");
                Console.WriteLine($" {gameMarkers[1, 0]} | {gameMarkers[1, 1]} | {gameMarkers[1, 2]} ");
                Console.WriteLine("---+---+---");
                Console.WriteLine($" {gameMarkers[2, 0]} | {gameMarkers[2, 1]} | {gameMarkers[2, 2]} ");
                Console.WriteLine("   |   |   ");
            }
            //輪換玩家OX的方法
            public void ChangeOX()
            {
                CurrentPlayer = (CurrentPlayer == 'X') ? 'O' : 'X';
            }
        }
    }
}
