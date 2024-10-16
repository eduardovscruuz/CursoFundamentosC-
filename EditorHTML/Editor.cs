using System;
using System.Text;

namespace EditorHTML
{
    public static class Editor
    {
        public static void Show()
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.WriteLine("----- MODO EDITOR -----");
            Console.WriteLine("------------------------");
            Start();
        }

        public static void Start()
        {
            var file = new StringBuilder();

            while (true)
            {
                var keyInfo = Console.ReadKey(true);

                if (keyInfo.Key == ConsoleKey.Escape)
                {
                    break;
                }


                if (keyInfo.Key == ConsoleKey.Enter)
                {
                    file.Append(Environment.NewLine);
                    Console.WriteLine();
                }

                else
                {
                    file.Append(keyInfo.KeyChar);
                    Console.Write(keyInfo.KeyChar);
                }
            }

            Console.WriteLine("------------------------");
            Console.WriteLine("Deseja salvar o arquivo?");
            Visualizador.Show(file.ToString());
        }
    }
}