namespace Bib_Mulinski_Piotr
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                App app = new App();
                app.Run();
            }
            catch (Exception e)
            {
                Console.WriteLine("Fatal error ! " + e.Message);
            }


            //Magazine newMagazine = new Magazine("mojmagazyn super", "supperikke", 12, 2024);

            //Console.WriteLine($"{newMagazine.Title}");
            //Console.WriteLine($"{newMagazine.Publisher}");
            //Console.WriteLine($"{newMagazine.Month}");
            //Console.WriteLine($"{newMagazine.Year}");

            //Console.WriteLine();
            //Console.WriteLine();

            //Console.WriteLine($"{newMagazine.Identification}");
            //Console.WriteLine();
            //Console.WriteLine($"{newMagazine.Categorie}");




        }

    }

}



