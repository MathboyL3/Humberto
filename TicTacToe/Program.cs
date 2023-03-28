using MyLib.ConsoleDisplayer;
using MyLib.ConsoleDisplayer.Geometry;
using MyLib.ConsoleDisplayer.Media;
using MyLib.SpecialFonts;

static class Program
{
    static Displayer displayer;
    static CoordP coord_converter;
    static TicTacToe ttt = new TicTacToe();
    public static void Main()
    {
        displayer = new Displayer();
        coord_converter = new CoordP(displayer.size);
        CustomFonts.LoadDefaulFonts (ref displayer);

        CreateTitle();
        CreateButtons();
        Console.ReadKey();
    }
    static void MouseTest()
    {
        int l = displayer.CreateNewLayer();
        int size = 20;
        string[] square = SimpleGeometry.FullSquare(size, 'R');
        Coord old_top_left = new Coord(100, 100);
        Coord old_bottom_right = old_top_left.Add(size, size);
        while (true)
        {
            Displayer.MouseStatus current_status = displayer.GetCurrentMouseStatus();
            Coord pos = displayer.GetMousePosition();

            if (displayer.isMouseInsideBounds(old_top_left, old_bottom_right))
            {
                if (current_status == Displayer.MouseStatus.Holding || current_status == Displayer.MouseStatus.Clicked)
                    displayer.GetLayer(l).InsertAt(old_top_left, square, 'g');
                else
                    displayer.GetLayer(l).InsertAt(old_top_left, square, 'w');

            }
            else
                displayer.GetLayer(l).InsertAt(old_top_left, square, 'w');

            displayer.BufferedFastRefresh(old_top_left, old_bottom_right);
        }
    }

    static void CreateTitle()
    {
        displayer.CreateNewLayer();
        Coord font_size = CustomFonts.GetFont(CustomFonts.default_name, 5).info.letter_size;
        string text = "Bem vindo ao jogo da velha #";
        Coord position = coord_converter.PercentageToCoord(50, 0).Sub(text.Length * font_size.x / 2, 0).Add(0, 150);
        displayer.DisplayTextAt(text, position, 0, 5, 'w', true);
    }


    static void CreateButtons()
    {
        displayer.ChangeStateTo("menu");
        Coord font_size = CustomFonts.GetFont(CustomFonts.default_name, 3).info.letter_size;
        int letter_layer = displayer.CreateNewLayer();
        Coord button_size = new Coord(150, 30);
        string[] button_bg = SimpleGeometry.FullSquare(button_size.x, button_size.y, 'w');
        string[] hover_button_bg = SimpleGeometry.FullSquare(button_size.x, button_size.y, 'g');

        Coord position = coord_converter.PercentageToCoord(50, 0).Sub(button_bg[0].Length / 2, 0);
        ScreenElement single_player_btn = new ScreenElement(button_bg, position.Add(0, 200), 0, delegate { StartSinglePlayerGame(); });
        ScreenElement multi_player_btn = new ScreenElement(button_bg, position.Add(0, 280), 0);

        ConsoleImage unselected = new ConsoleImage(button_bg);
        ConsoleImage selected = new ConsoleImage(hover_button_bg);

        displayer.RegisterNewScreenElement("menu", single_player_btn);
        string t1 = "Single Player";
        Coord sp_pos = position.Add(0, 200).Add(button_size.x / 2 - (t1.Length * font_size.x + t1.Length) / 2 , button_size.y / 2 - font_size.y / 2);
        displayer.DisplayTextAt(t1, sp_pos, letter_layer, 3, 'A');

        displayer.RegisterNewScreenElement("menu", multi_player_btn);
        string t2 = "Multi Player";
        Coord mp_pos = position.Add(0, 280).Add(button_size.x / 2 - (t2.Length * font_size.x + t2.Length) / 2 , button_size.y / 2 - font_size.y / 2);
        displayer.DisplayTextAt(t2, mp_pos, letter_layer, 3, 'A');
        displayer.BufferedFastRefresh();

        bool is_inside = false;
        Coord last_anchor = new Coord(0, 0);
        while (true)
        {

            ScreenElement element = displayer.HoveringElement("menu");
            if (element == null) {
                if(is_inside)
                    displayer.DisplayImageAt(unselected, last_anchor, 0, true);
                is_inside = false;
                continue;
            }

            if (!is_inside)
            {
                last_anchor = element.anchor_position;
                displayer.DisplayImageAt(selected, last_anchor, 0, true);
                is_inside = true;
            }

            Displayer.MouseStatus current_status = displayer.GetCurrentMouseStatus();
            if (current_status == Displayer.MouseStatus.StoppedClicked)
            {
                element.ExecuteSelectAction();
                break;
            }
        }
    }

    static void StartSinglePlayerGame()
    {
        displayer.Clear();
        displayer.ChangeStateTo("game");
        CreateGameBoard();
    }
    
    static void CreateGameBoard()
    { 
        int cell_size = 60;
        int cell_spacing = 20;
        int board_size = (cell_size * 3) + (cell_spacing + 2);
        Coord board_anchor = coord_converter.PercentageToCoord(50, 50).Sub(board_size / 2, board_size / 2);
        string[] unselected_cell = SimpleGeometry.FullSquare(cell_size, 'w');
        string[] selected_cell = SimpleGeometry.FullSquare(cell_size, 'T');

        ConsoleImage unselected_cell_img = new ConsoleImage(unselected_cell);
        ConsoleImage selected_cell_img = new ConsoleImage(selected_cell);

        int b_layer = displayer.CreateNewLayer();

        int plus_1 = cell_spacing + cell_size;
        int plus_2 = plus_1 + plus_1;

        Dictionary<int, Coord> positions = new Dictionary<int, Coord>()
        {
            [1] = board_anchor,
            [2] = board_anchor.Add(plus_1,      0),
            [3] = board_anchor.Add(plus_2,      0),
            [4] = board_anchor.Add(     0, plus_1),
            [5] = board_anchor.Add(plus_1, plus_1),
            [6] = board_anchor.Add(plus_2, plus_1),
            [7] = board_anchor.Add(     0, plus_2),
            [8] = board_anchor.Add(plus_1, plus_2),
            [9] = board_anchor.Add(plus_2, plus_2),
        };

        ScreenElement cell_1 = new ScreenElement(unselected_cell, positions[1], b_layer);
        ScreenElement cell_2 = new ScreenElement(unselected_cell, positions[2], b_layer);
        ScreenElement cell_3 = new ScreenElement(unselected_cell, positions[3], b_layer);

        ScreenElement cell_4 = new ScreenElement(unselected_cell, positions[4], b_layer);
        ScreenElement cell_5 = new ScreenElement(unselected_cell, positions[5], b_layer);
        ScreenElement cell_6 = new ScreenElement(unselected_cell, positions[6], b_layer);

        ScreenElement cell_7 = new ScreenElement(unselected_cell, positions[7], b_layer);
        ScreenElement cell_8 = new ScreenElement(unselected_cell, positions[8], b_layer);
        ScreenElement cell_9 = new ScreenElement(unselected_cell, positions[9], b_layer);

        displayer.RegisterNewScreenElements("game", new ScreenElement[] { cell_1, cell_2, cell_3, cell_4, cell_5, cell_6, cell_7, cell_8, cell_9 });
        displayer.BufferedFastRefresh();

        bool is_inside = false;
        Coord last_anchor = new Coord(0, 0);
        while (true)
        {
            ScreenElement element = displayer.HoveringElement("game");
            if (element == null)
            {
                if (is_inside)
                    displayer.DisplayImageAt(unselected_cell_img, last_anchor, 0, true);
                is_inside = false;
                continue;
            }

            if (!is_inside)
            {
                last_anchor = element.anchor_position;
                displayer.DisplayImageAt(selected_cell_img, last_anchor, 0, true);
                is_inside = true;
            }

            Displayer.MouseStatus current_status = displayer.GetCurrentMouseStatus();
            if (current_status == Displayer.MouseStatus.StoppedClicked)
            {
                element.ExecuteSelectAction();
                break;
            }
        }

    }

}