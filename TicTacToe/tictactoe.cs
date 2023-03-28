public class TicTacToe
{
    const char player_1 = 'o';
    const char player_2 = 'x';

    char[,] tabuleiro = new char[3, 3]{
            { ' ', ' ', ' ' },
            { ' ', ' ', ' ' },
            { ' ', ' ', ' ' },
            };

    Dictionary<int, (int, int)> pos_map = new Dictionary<int, (int, int)>()
    {
        [1] = (0, 0),
        [2] = (1, 0),
        [3] = (2, 0),
        [4] = (0, 1),
        [5] = (1, 1),
        [6] = (2, 1),
        [7] = (0, 2),
        [8] = (1, 2),
        [9] = (2, 2),
    };

    public void Executar()
    {
        while (true)
        {
            Console.Clear();
            Console.Write("\n\n\n\n");
            ImprimirTabuleiro();
            if (DoPlayerWon(player_2))
            {
                Console.SetCursorPosition(0, 8);
                Console.WriteLine($"Player 2 ({player_2}) venceu!");
                break;
            }

            if (DoPlayerWon(player_1))
            {
                Console.SetCursorPosition(0, 8);
                Console.WriteLine($"Player 1 ({player_1}) venceu!");
                break;
            }
            Console.WriteLine();
            Console.SetCursorPosition(0, 0);
            int op = PerguntarOpcao();
            (int x, int y) pos = pos_map[op];
            tabuleiro[pos.x, pos.y] = player_1;
            //BotPlay();



        }
    }

    public bool MakePlay(Coord pos, char player)
    {
        if (tabuleiro[pos.x, pos.y] != ' ') return false;
        tabuleiro[pos.x, pos.y] = player;
        return true;
    }

    public bool MakePlay(int pos_number, char player)
    {
        Coord pos = new Coord(pos_map[pos_number]);
        if (tabuleiro[pos.x, pos.y] != ' ') return false;
        tabuleiro[pos.x, pos.y] = player;
        return true;
    }

    void BotPlay()
    {
        int highest = int.MinValue;
        (int x, int y) highest_pos = (-1, -1);
        for (int y = 0; y < 3; y++)
        {
            for (int x = 0; x < 3; x++)
            {
                if (tabuleiro[x, y] != ' ') continue;
                int v = ValidarPosicao(x, y, false);
                if (v > highest)
                {
                    highest = v;
                    highest_pos = (x, y);
                }
            }
        }
        MakePlay(new Coord(highest_pos), player_2);
        //tabuleiro[highest_pos.x, highest_pos.y] = player_2;
    }

    int ValidarPosicao(int x, int y, bool isPlayer1)
    {
        int pontuacao = 0;
        char player_enemy = isPlayer1 ? player_2 : player_1;
        char player_itself = isPlayer1 ? player_1 : player_2;

        char[] linha = GetLinha(x);
        char[] coluna = GetColuna(y);
        int total_count = GetCountOfChar(linha, player_enemy) + GetCountOfChar(coluna, player_enemy);
        //Se estiver no meio
        if (x == 1 && y == 1)
        {
            pontuacao += 2;

            // verifica as duas diagonais
            total_count += GetCountOfChar(GetDiagonal(1), player_enemy);
            total_count += GetCountOfChar(GetDiagonal(2), player_enemy);
        }

        //Se estiver em um dos cantos
        if (x == 0 || x == 2 || y == 0 || y == 2)
        {
            // ganha um ponto se estiver no canto
            pontuacao += 1;

            // verifica qual diagonal ele está e adiciona a pontuação
            total_count += GetCountOfChar(GetDiagonal(x == y ? 1 : 2), player_enemy);

        }

        // perde dois pontos se já tiver alguma posição inimiga na linha, diagonal ou 
        pontuacao -= total_count > 0 ? 2 : 0;

        // verifica se o player impede o inimigo de ganhar marcando a posição
        tabuleiro[x, y] = player_enemy;
        pontuacao += DoPlayerWon(player_enemy) ? 4 : 0;

        // verifica se o player ganha marcando a posição
        tabuleiro[x, y] = player_itself;
        pontuacao += DoPlayerWon(player_itself) ? 4 : 0;

        //reseta
        tabuleiro[x, y] = ' ';

        return pontuacao;
    }

    int GetCountOfChar(char[] arr, char c)
    {
        int count = 0;
        for (int i = 0; i < arr.Length; i++)
            if (arr[i] == c)
                count++;
        return count;
    }

    char[] GetLinha(int linha)
    {
        char[] _linha = new char[3];

        for (int col = 0; col < 3; col++)
            _linha[col] = tabuleiro[linha, col];

        return _linha;
    }
    char[] GetColuna(int coluna)
    {
        char[] _coluna = new char[3];

        for (int row = 0; row < 3; row++)
            _coluna[row] = tabuleiro[row, coluna];

        return _coluna;
    }
    char[] GetDiagonal(int diagonal)
    {
        char[] _diagonal = new char[0];

        if (diagonal == 1)
            _diagonal = new char[3] { tabuleiro[0, 0], tabuleiro[1, 1], tabuleiro[2, 2] };

        if (diagonal == 2)
            _diagonal = new char[3] { tabuleiro[2, 0], tabuleiro[1, 1], tabuleiro[0, 2] };

        return _diagonal;
    }

    bool DoPlayerWon(char player)
    {
        //verifica as 3 linhas
        if (GetCountOfChar(GetLinha(0), player) == 3) return true;
        if (GetCountOfChar(GetLinha(1), player) == 3) return true;
        if (GetCountOfChar(GetLinha(2), player) == 3) return true;

        //verfica as 3 colunas
        if (GetCountOfChar(GetColuna(0), player) == 3) return true;
        if (GetCountOfChar(GetColuna(1), player) == 3) return true;
        if (GetCountOfChar(GetColuna(2), player) == 3) return true;

        //verifica a diagonal
        if (GetCountOfChar(GetDiagonal(1), player) == 3) return true;
        if (GetCountOfChar(GetDiagonal(2), player) == 3) return true;

        return false;
    }

    void ImprimirTabuleiro()
    {
        for (int y = 0; y < 3; y++)
            for (int x = 0; x < 3; x++)
                Console.Write($"{tabuleiro[x, y]}{(x == 2 ? "\n" : " | ")}");
    }

    int PerguntarOpcao()
    {
        Console.WriteLine(" 1 | 2 | 3");
        Console.WriteLine(" 4 | 5 | 6");
        Console.WriteLine(" 7 | 8 | 9");

        return int.Parse(Console.ReadLine());

    }

}
