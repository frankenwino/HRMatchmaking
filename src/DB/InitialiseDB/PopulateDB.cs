namespace DB.Setup;
// using Faker;
using System.Data.SqlClient;
using Dapper;
using Model;

public class PopulateDB
{
    private Random random;

    public PopulateDB()
    {
        random = new Random();
    }



    public void AddCities()
    {
        List<string> cities = new List<string> {
            "Ale", "Alingsås", "Alvesta", "Aneby", "Arboga", "Arjeplog",
            "Arvidsjaur", "Arvika", "Askersund", "Avesta", "Bengtfors", "Berg",
            "Bjurholm", "Bjuv", "Boden", "Bollebygd", "Bollnäs", "Borgholm",
            "Borlänge", "Borås", "Botkyrka", "Boxholm", "Bromölla", "Bräcke",
            "Burlöv", "Båstad", "DalsEd", "Danderyd", "Degerfors", "Dorotea",
            "Eda", "Ekerö", "Eksjö", "Emmaboda", "Enköping", "Eskilstuna",
            "Eslöv", "Essunga", "Fagersta", "Falkenberg", "Falköping", "Falun",
            "Filipstad", "Finspång", "Flen", "Forshaga", "Färgelanda", "Gagnef",
            "Gislaved", "Gnesta", "Gnosjö", "Gotland", "Grums", "Grästorp",
            "Gullspång", "Gällivare", "Gävle", "Göteborg", "Götene", "Habo",
            "Hagfors", "Hallsberg", "Hallstahammar", "Halmstad", "Hammarö",
            "Haninge", "Haparanda", "Heby", "Hedemora", "Helsingborg",
            "Herrljunga", "Hjo", "Hofors", "Huddinge", "Hudiksvall", "Hultsfred",
            "Hylte", "Hällefors", "Härjedalen", "Härnösand", "Härryda",
            "Hässleholm", "Håbo", "Höganäs", "Högsby", "Hörby", "Höör",
            "Jokkmokk", "Järfälla", "Jönköping", "Kalix", "Kalmar", "Karlsborg",
            "Karlshamn", "Karlskoga", "Karlskrona", "Karlstad", "Katrineholm",
            "Kil", "Kinda", "Kiruna", "Klippan", "Knivsta", "Kramfors",
            "Kristianstad", "Kristinehamn", "Krokom", "Kumla", "Kungsbacka",
            "Kungsör", "Kungälv", "Kävlinge", "Köping", "Laholm", "Landskrona",
            "Laxå", "Lekeberg", "Leksand", "Lerum", "Lessebo", "Lidingö",
            "Lidköping", "LillaEdet", "Lindesberg", "Linköping", "Ljungby",
            "Ljusdal", "Ljusnarsberg", "Lomma", "Ludvika", "Luleå", "Lund",
            "Lycksele", "Lysekil", "Malmö", "Malung", "Malå", "Mariestad",
            "Mark", "Markaryd", "Mellerud", "Mjölby", "Mora", "Motala",
            "Mullsjö", "Munkedal", "Munkfors", "Mölndal", "Mönsterås",
            "Mörbylånga", "Nacka", "Nora", "Norberg", "Nordanstig",
            "Nordmaling", "Norrköping", "Norrtälje", "Norsjö", "Nybro",
            "Nykvarn", "Nyköping", "Nynäshamn", "Nässjö", "Ockelbo", "Olofström",
            "Orsa", "Orust", "Osby", "Oskarshamn", "Ovanåker", "Oxelösund",
            "Pajala", "Partille", "Perstorp", "Piteå", "Ragunda", "Robertsfors",
            "Ronneby", "Rättvik", "Sala", "Salem", "Sandviken", "Sigtuna",
            "Simrishamn", "Sjöbo", "Skara", "Skellefteå", "Skinnskatteberg",
            "Skurup", "Skövde", "Smedjebacken", "Sollefteå", "Sollentuna",
            "Solna", "Sorsele", "Sotenäs", "Staffanstorp", "Stenungsund",
            "Stockholm", "Storfors", "Storuman", "Strängnäs", "Strömstad",
            "Strömsund", "Sundbyberg", "Sundsvall", "Sunne", "Surahammar",
            "Svalöv", "Svedala", "Svenljunga", "Säffle", "Sälen", "Säter",
            "Sävsjö", "Söderhamn", "Söderköping", "Södertälje", "Sölvesborg",
            "Tanum", "Tibro", "Tidaholm", "Tierp", "Timrå", "Tingsryd", "Tjörn",
            "Tomelilla", "Torsby", "Torsås", "Tranemo", "Tranås", "Trelleborg",
            "Trollhättan", "Trosa", "Tyresö", "Täby", "Töreboda", "Uddevalla",
            "Ulricehamn", "Umeå", "UpplandsBro", "UpplandsVäsby", "Uppsala",
            "Uppvidinge", "Vadstena", "Vaggeryd", "Valdemarsvik", "Vallentuna",
            "Vansbro", "Vara", "Varberg", "Vaxholm", "Vellinge", "Vetlanda",
            "Vilhelmina", "Vimmerby", "Vindeln", "Vingåker", "Vänersborg",
            "Vännäs", "Värmdö", "Värnamo", "Västervik", "Västerås", "Växjö",
            "Vårgårda", "Ydre", "Ystad", "Älmhult", "Älvdalen", "Älvkarleby",
            "Älvsbyn", "Ängelholm", "Åmål", "Ånge", "Åre", "Årjäng", "Åsele",
            "Åstorp", "Åtvidaberg", "Öckerö", "Ödeshög", "Örebro", "Örkelljunga",
            "Örnsköldsvik", "Östersund", "Österåker", "Östhammar", "ÖstraGöinge",
            "Överkalix", "Övertorneå"
            };

        int rowsAffected = 0;
        DatabaseConnectionManager dbConnectionManager = new();

        using (SqlConnection connection = dbConnectionManager.GetOpenConnection())
        {
            foreach (string city in cities)
            {
                City newCity = new City(city);

                try
                {
                    string sqlcode = $"INSERT INTO city(name) VALUES (@Name)";
                    int count = connection.Execute(sqlcode, newCity);
                    rowsAffected += count;
                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    if (ex.Number == 2601 || ex.Number == 2627)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    else
                    {
                        Console.WriteLine($"An SqlException occurred: {ex.Message}");
                    }
                }
            }
        }
        System.Console.WriteLine("Populating city table");
        System.Console.WriteLine($"{rowsAffected} rows affected");
    }



    public void AddIndustries()
    {
        List<string> industries = new List<string> {
            "Advertising", "Agriculture", "Banking", "Construction", "Education",
            "Energy", "Engineering", "Entertainment", "Finance", "Food",
            "Government", "Healthcare", "Hospitality", "InformationTechnology",
            "LegalServices", "Manufacturing", "Marketing", "Media", "Medical",
            "Nonprofit", "Property", "PublicAdministration", "RealEstate",
            "Retail", "Sales", "SocialServices", "Telecommunications",
            "Tourism", "Transportation", "Utilities", "Other"
            };

        int rowsAffected = 0;

        DatabaseConnectionManager dbConnectionManager = new();

        using (SqlConnection connection = dbConnectionManager.GetOpenConnection())
        {
            foreach (string industry in industries)
            {
                Industry i = new Industry(industry);
                try
                {
                    string sqlcode = $"INSERT INTO industry(name) VALUES (@Name)";
                    int count = connection.Execute(sqlcode, i);
                    rowsAffected += count;
                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    if (ex.Number == 2601 || ex.Number == 2627)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    else
                    {
                        Console.WriteLine($"An SqlException occurred: {ex.Message}");
                    }
                }
            }
        }
        System.Console.WriteLine("Populating industry table");
        System.Console.WriteLine($"{rowsAffected} rows affected");
    }


    public void AddVehicleLicenses()
    {
        List<VehicleLicense> vehicleLicences = new();

        vehicleLicences.Add(new VehicleLicense("AM", "Moped class 1 and 2"));
        vehicleLicences.Add(new VehicleLicense("A1", "Light motorcycle"));
        vehicleLicences.Add(new VehicleLicense("A2", "Medium-sized motorcycle"));
        vehicleLicences.Add(new VehicleLicense("A", "Heavy motorcycle"));
        vehicleLicences.Add(new VehicleLicense("B", "Car, light trailer"));
        vehicleLicences.Add(new VehicleLicense("Utökad B", "Car, heavier trailer than a regular B license"));
        vehicleLicences.Add(new VehicleLicense("BE", "Car, heavy trailer"));
        vehicleLicences.Add(new VehicleLicense("C1", "Medium-weight truck < 7.5 tons"));
        vehicleLicences.Add(new VehicleLicense("C1E", "Medium-weight truck < 12 tons with a trailer"));
        vehicleLicences.Add(new VehicleLicense("C", "Heavy truck"));
        vehicleLicences.Add(new VehicleLicense("CE", "Heavy truck with a trailer"));
        vehicleLicences.Add(new VehicleLicense("D1", "Medium-sized bus, one trailer"));
        vehicleLicences.Add(new VehicleLicense("D1E", "Medium-sized bus, multiple trailers"));
        vehicleLicences.Add(new VehicleLicense("D", "Bus"));
        vehicleLicences.Add(new VehicleLicense("DE", "Bus, trailer"));

        int rowsAffected = 0;

        DatabaseConnectionManager dbConnectionManager = new();

        using (SqlConnection connection = dbConnectionManager.GetOpenConnection())
        {
            foreach (VehicleLicense vehicleLicence in vehicleLicences)
            {
                try
                {
                    string sql = $"INSERT INTO vehicle_license(code, description) VALUES (@Code, @Description)";
                    int count = connection.Execute(sql, vehicleLicence);
                    rowsAffected += count;
                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    if (ex.Number == 2601 || ex.Number == 2627)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    else
                    {
                        Console.WriteLine($"An SqlException occurred: {ex.Message}");
                    }
                }
            }
        }
        System.Console.WriteLine("Populating vehicle_license table");
        System.Console.WriteLine($"{rowsAffected} rows affected");
    }


    public void AddJobSeekers(int totalJobSeekers = 10)
    {
        DatabaseConnectionManager dbConnectionManager = new();
        JobSeekerRepository jsr = new();

        int rowsAffected = 0;

        using (SqlConnection connection = dbConnectionManager.GetOpenConnection())
        {
            for (int i = 0; i < totalJobSeekers; i++)
            {
                int cityId = random.Next(1, 250);
                string name = Faker.Name.FullName();
                DateTime dateOfBirth = Faker.Identification.DateOfBirth();
                int lastFourNumbers = random.Next(1111, 9999);
                PersonNumber personNumber = new PersonNumber(dateOfBirth, lastFourNumbers.ToString());

                JobSeeker j = new JobSeeker(name, dateOfBirth, personNumber.PNumber, cityId, Faker.Phone.Number(), Faker.Internet.Email());
                int count = jsr.AddJobSeeker(j);
                rowsAffected += count;
            }
        }

        System.Console.WriteLine("Populating jobseeker table");
        System.Console.WriteLine($"{rowsAffected} rows affected");
    }

    public void AddJobEmployers(int totalEmployers = 10)
    {
        DatabaseConnectionManager dbConnectionManager = new();

        EmployerRepository er = new();

        int rowsAffected = 0;

        using (SqlConnection connection = dbConnectionManager.GetOpenConnection())
        {
            for (int i = 0; i < totalEmployers; i++)
            {
                int cityId = random.Next(1, 292);
                int industryId = random.Next(1, 32);
                string name = Faker.Company.Name();
                int organisationNumberHalf = random.Next(100000, 999999);
                string orgNumber = $"{organisationNumberHalf.ToString()}{organisationNumberHalf.ToString()}";

                Employer e = new Employer(name, orgNumber, industryId, Faker.Internet.Email(), cityId);

                int count = er.AddEmployer(e);
                rowsAffected += count;
            }
        }

        System.Console.WriteLine("Populating employer table");
        System.Console.WriteLine($"{rowsAffected} rows affected");
    }
}