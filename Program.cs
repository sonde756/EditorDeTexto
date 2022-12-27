using System.IO;
internal class Program
{
    private static void Main(string[] args)
    {
        Menu();
    }
     static void Menu()
        {
            Console.Clear();

            Console.WriteLine("Vai fazer oque??");
            Console.WriteLine("1 - Abrir arquivo");
            Console.WriteLine("2 - Criar novo arquivo");
            Console.WriteLine("0 -Sair");
        int opcao = int.Parse(Console.ReadLine());

        switch(opcao){
            case 0: System.Environment.Exit(0); break;
            case 1: Abrir(); break;
            case 2: Editar(); break;
            default: Menu(); break;
        }
    }

    static void Abrir(){
        Console.Clear();
        Console.WriteLine("Qual caminho do arquivo?");
        string path = Console.ReadLine();

        using(var file = new StreamReader(path)){
            string texto = file.ReadToEnd();
            Console.WriteLine(texto);
        }
        Console.WriteLine("");
        Console.ReadLine();
        Menu();

    }

    static void Editar()
    {
        Console.Clear();

        Console.WriteLine("Digite seu texto abaixo (ESC para sair)");
        Console.WriteLine("-----------------------");

        string texto = "";
        do{
            texto += Console.ReadLine();
            texto += Environment.NewLine;
        }
        while(Console.ReadKey().Key != ConsoleKey.Escape);

        Console.WriteLine("");
        Salvar(texto);

    }

    static void Salvar(string texto)
    {
        Console.Clear();
        Console.WriteLine("Qual caminha para salvar arquivo?");
        var path = Console.ReadLine();

        using(var file = new StreamWriter(path))
        {
            file.Write(texto);
        }

        Console.WriteLine($"Arquivo {path} salvo com sucesso");
        Console.ReadLine();
        Menu();


    }
}