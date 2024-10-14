using System;
using System.IO;

namespace TextEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }

        static void Menu()
        {
            Console.Clear();
            Console.WriteLine("O que você deseja fazer?");
            Console.WriteLine("1 - Abrir arquivo");
            Console.WriteLine("2 - Criar novo arquivo");
            Console.WriteLine("0 - Sair");
            short option = short.Parse(Console.ReadLine());

            switch (option)
            {
                case 0: System.Environment.Exit(0); break;
                case 1: Abrir(); break;
                case 2: Editar(); break;
                default: Menu(); break;
            }
        }

        static void Abrir()
        {
            Console.Clear();
            Console.WriteLine("Qual caminho do arquivo?");
            string path = Console.ReadLine();

            using (var file = new StreamReader(path))
            {
                string text = file.ReadToEnd();
                Console.WriteLine(text);
            }

            Console.WriteLine("");
            Console.ReadLine();
            Menu();
        }

        static void Editar()
        {
            Console.Clear();
            Console.WriteLine("Digite seu texto abaixo (ESC para sair)");
            Console.WriteLine("--------------------------------------");
            string text = "";

            while (true)
            {
                var keyInfo = Console.ReadKey(true); // Lê a tecla pressionada

                // Se a tecla ESC for pressionada, interrompe o loop
                if (keyInfo.Key == ConsoleKey.Escape)
                    break;

                // Se a tecla Enter for pressionada, adiciona uma nova linha
                if (keyInfo.Key == ConsoleKey.Enter)
                {
                    text += Environment.NewLine;
                    Console.WriteLine(); // Move o cursor para a linha de baixo
                }
                else
                {
                    // Adiciona o caractere ao texto e escreve na tela
                    text += keyInfo.KeyChar;
                    Console.Write(keyInfo.KeyChar);
                }
            }

            Salvar(text);
        }

        static void Salvar(string text)
        {
            Console.Clear();
            Console.WriteLine("Qual caminho para salvar o arquivo?");
            var path = Console.ReadLine();

            using (var file = new StreamWriter(path))
            {
                file.Write(text);
            }

            Console.WriteLine($"Arquivo {path} salvo com sucesso!");
            Console.ReadLine();
            Menu();
        }
    }
}
