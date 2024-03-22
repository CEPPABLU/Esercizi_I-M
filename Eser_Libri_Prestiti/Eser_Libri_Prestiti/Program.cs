using Eser_Libri_Prestiti.Utilities;

namespace Eser_Libri_Prestiti
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine(Config.getIstanza().GetConnectionString());
        }
    }
}
