using ProjetRobinF.Models;
using System.Collections.Generic;


namespace ProjetRobinF.dal
{
    public class ProjetInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<ProjetContext>
    {
        protected override void Seed(ProjetContext context)
        {

            var Villes = new List<Ville>
            {
                new Ville {ID="604-851",Nom="Kyoto",Region="Kansai"},
                new Ville {ID="100-000",Nom="Tokyo",Region="Kantō"},
                new Ville {ID="530-8201",Nom="Osaka",Region="Kansai"},
                new Ville {ID="730-0000",Nom="Hiroshima",Region="Chūgoku"},
                new Ville {ID="160-8501",Nom="Nagoya",Region="Chūbu"},
                new Ville {ID="160-0022",Nom="Shinjuku",Region="Kantō"},
                new Ville {ID="150-0000",Nom="Shibuya",Region="Kantō"}

            };
            Villes.ForEach(v => context.Villes.Add(v));
            context.SaveChanges();

            var Hotels = new List<Hotel>
            {
                new Hotel {Nom="The Hotel Seiryu Kyoto Kiyomizu",Etoile=5,Prix=736,VilleID="604-851"},
                new Hotel {Nom="The HotelImagine Kyoto",Etoile=3,Prix=179,VilleID="604-851"},
                new Hotel {Nom="Hotel New Otani Osaka",Etoile=3,Prix=182,VilleID="530-8201"},
                new Hotel {Nom="Hotel Granvia Osaka",Etoile=4,Prix=100,VilleID="530-8201"},
                new Hotel {Nom="Red Planet Nagoya Nishiki",Etoile=3,Prix=50,VilleID="160-8501"},
                new Hotel {Nom="RIHGA Royal Hotel Hiroshima",Etoile=4,Prix=127,VilleID="730-0000"}

            };
            Hotels.ForEach(h => context.Hotels.Add(h));
            context.SaveChanges();

            var Activites = new List<Activite>
            {
                new Activite{Nom="Kinkaku-ji",Addresse="1 Kinkakujicho, Kita ward",Description="Temple bouddhiste",VilleID="604-851"},
                new Activite{Nom="Fushimi Inari-taisha",Addresse="68 Fukakusa Yabunouchicho, Fushimi Ward",Description="Sanctuaire religieux",VilleID="604-851"},
                new Activite{Nom="Santuaire Asakusa",Addresse="2 Chrome-3-1 Asakusa, Taito City",Description="Temple",VilleID="100-000"},
                new Activite{Nom="Parc Memorial de la Paix de Hiroshima",Addresse="1 Chome-1 Nakajimacho, Naka ward",Description="Parc Commemoratif",VilleID="730-0000"},
                new Activite{Nom="Dome de Genbaku",Addresse="1-10 Otemachi, Naka Ward",Description="Dome de la bombe atomique",VilleID="730-0000"}
            };
            Activites.ForEach(s => context.Activites.Add(s));
            context.SaveChanges();


            var Admin = new List<Admin>
            {
                new Admin{Pseudo="admin",Password="admin123"},
            };
            Admin.ForEach(s => context.Admins.Add(s));
            context.SaveChanges();

        }


    }
}
