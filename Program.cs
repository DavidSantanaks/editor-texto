namespace TextoEditor
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
            Console.WriteLine("1- Abrir arquivo de texto");
            Console.WriteLine("2- Criar um novo arquivo");
            Console.WriteLine("0- Sair");
            short valor = short.Parse(Console.ReadLine());

            switch (valor)
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
            Console.WriteLine("Qual o caminho do arquivo?");
            string path = Console.ReadLine();
            //O using sempre abre uma conexão e fecha assim que finalizada.
            //StreamReader objeto para ler arquivos
            using (StreamReader file = new StreamReader(path))
            {
                //Lendo o arquivo e salvando em uma string
                string text = file.ReadToEnd();
                //Mostrando o texto
                Console.WriteLine(text);
            }

            Console.WriteLine();
            Console.ReadLine();
            Menu();
        }

        static void Editar()
        {
            Console.Clear();
            Console.WriteLine("Digite seu texto abaixo. (ESC para sair) ");
            Console.WriteLine("--------------------------");

            //String onde armazenaremos oque usuario digitar
            String text = "";

            //While para escrever no texto e parametro para sair do editor
            do
            {
                //Adicionando o texto dentro da variavel
                text += Console.ReadLine();
                //Adicionando quebra de linha
                text += Environment.NewLine;

            } while (Console.ReadKey().Key != ConsoleKey.Escape);

            //Chamando a função de salvar texto
            Salvar(text);
            Thread.Sleep(1000);
        }

        static void Salvar(string text)
        {
            Console.Clear();
            Console.WriteLine("Qual caminho para salvar o arquivo");
            var path = Console.ReadLine();

            //abrindo arquivo -//USING SERVE PARA ABRIR ATÉ CONEXÃO PARA SALVAR DADOS NO BANCO
            //StreamWriter escreve no arquivo.
            using (StreamWriter file = new StreamWriter(path))
            {
                //Escrevendo no arquivo
                file.Write(text);
            }

            Console.WriteLine($"Arquivo {path} salvo com sucesso.");
            Console.ReadLine();
            Menu();
        }
    }
}

