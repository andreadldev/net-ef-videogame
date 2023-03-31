using net_ef_videogame;


while (true)
{
    int opzione = 0;

    while (opzione is 0)
    {
        Console.WriteLine("Menù");
        Console.WriteLine("1. Inserisci videogioco");
        Console.WriteLine("2. Inserisci software house");
        Console.WriteLine("3. Ricerca gioco per id");
        Console.WriteLine("4. Esci");
        var input = Console.ReadLine();
        opzione = Menu(input);
    }

    switch (opzione)
    {
        case 1:
            Console.WriteLine("Nome:");
            var name = Console.ReadLine();

            Console.WriteLine("Descrizione:");
            var overview = Console.ReadLine();

            Console.WriteLine("Data di uscita (yyyy-MM-dd):");
            var releaseDate = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Id software house:");
            var softwareHouseId = Convert.ToInt64(Console.ReadLine());

            using (VideogameContext db = new VideogameContext())
            {
                var game = new Videogame(name, overview, releaseDate, softwareHouseId);
                db.Add(game);
                db.SaveChanges();
            }
            Console.WriteLine("Videogioco inserito");
            Console.WriteLine();
            break;
        case 2:
            using (VideogameContext db = new VideogameContext())
            {
                Console.WriteLine("Inserisci il nome della software house:");
                string shname = Console.ReadLine();

                SoftwareHouse softwareHouse = new SoftwareHouse { Name = shname };
                db.SoftwareHouses.Add(softwareHouse);
                db.SaveChanges();
            }
            Console.WriteLine("Operazione completata");
            Console.WriteLine();
            break;
        case 3:
            Console.WriteLine("Inserisci l'ID del gioco");
            var gameID = Convert.ToInt64(Console.ReadLine());
            using (VideogameContext db = new VideogameContext())
            {
                Videogame vg = db.Videogames.FirstOrDefault(vg => vg.Id == gameID);

                if (vg == null)
                {
                    break;
                }
                Console.WriteLine($"Dettagli: {vg.Name} \n{vg.Overview} \n{vg.ReleaseDate}");
            }
            break;
        case 4:
            Environment.Exit(0);
            break;
            //case 4:
            //    break;
            //case 5:
            //    break;
    }
}

int Menu(string? input)
{
    switch (input)
    {
        case "1":
        case "inserisci videogioco":
            return 1;
        case "2":
        case "inserisci software house":
            return 2;
        case "3":
            return 3;
        case "4":
        case "esci":
        case "exit":
            return 4;
        //case "5":
        //    return 5;
        default:
            Console.WriteLine("Input non valido");
            return 0;
    }
}