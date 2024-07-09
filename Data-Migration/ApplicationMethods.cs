using Data_Migration.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace Data_Migration
{
    public class ApplicationMethods
    {
        public static bool readDataToDatabase()
        {
            List<Abrufberechtigte> listeAbrufBerechtigte = HelperMethods.ReadCsv<Abrufberechtigte>("Abrufberechtigte.csv");
            List<Organisationsbeauftragten> listeOrganisationBeauftragten = HelperMethods.ReadCsv<Organisationsbeauftragten>("Organisationsbeauftragten.csv");
            List<Kdnr> listeKdnr = HelperMethods.ReadCsv<Kdnr>("Kdnr.csv");
            List<Rkto> listeRkto = HelperMethods.ReadCsv<Rkto>("Rkto.csv");

            using (var context = DbContextSetup.CreateServiceProvider().GetRequiredService<MigrationDBContext>())
            {
                context.Abrufberechtigtes.AddRange(listeAbrufBerechtigte);
                context.Organisationsbeauftragtens.AddRange(listeOrganisationBeauftragten);
                context.Kdnrs.AddRange(listeKdnr);
                context.Rktos.AddRange(listeRkto);
                if (context.SaveChanges() > 0)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool emptyDatabase()
        {
            using (var context = DbContextSetup.CreateServiceProvider().GetRequiredService<MigrationDBContext>())
            {
                context.Abrufberechtigtes.RemoveRange(context.Abrufberechtigtes);
                context.Organisationsbeauftragtens.RemoveRange(context.Organisationsbeauftragtens);
                context.Kdnrs.RemoveRange(context.Kdnrs);
                context.Rktos.RemoveRange(context.Rktos);
                if (context.SaveChanges() > 0)
                {
                    return true;
                }
            }
            return false;
        }

        public async static Task<bool> transferDataToDirectus()
        {
            Console.Clear();
            Console.WriteLine("wird Gestartet...");

            using (var abrufBerechtigte_context = DbContextSetup.CreateServiceProvider().GetRequiredService<MigrationDBContext>())
            using (var organisationsBeauftragten_context = DbContextSetup.CreateServiceProvider().GetRequiredService<MigrationDBContext>())
            using (var kndrn_context = DbContextSetup.CreateServiceProvider().GetRequiredService<MigrationDBContext>())
            using (var rkto_context = DbContextSetup.CreateServiceProvider().GetRequiredService<MigrationDBContext>())
            {
                Console.WriteLine("Abrufberechtigten verarbeiten...");
                var listeAbrufBerechtigten = abrufBerechtigte_context.Abrufberechtigtes.Where(x=>!x.istVerarbeitet);
                List<Dictionary<string, object>> requestBody = new();
                
                foreach(var abrufBerechtigte in listeAbrufBerechtigten)
                {
                    Console.WriteLine($"Abrufberechtigte -> {abrufBerechtigte.Name}");

                    Dictionary<string, object> requestItem = new Dictionary<string, object>();
                    HelperMethods.AddIfNotNullOrEmpty(requestItem, "AbrufberechtigterName", abrufBerechtigte.Name);
                    HelperMethods.AddIfNotNullOrEmpty(requestItem, "Adresse", abrufBerechtigte.adresse);
                    HelperMethods.AddIfNotNullOrEmpty(requestItem, "AB_Gruppe", abrufBerechtigte.AB_gruppe);


                    var listeOrganisationsBeauftragten = organisationsBeauftragten_context.Organisationsbeauftragtens.Where(x => x.UUID == abrufBerechtigte.UUID && !x.istVerarbeitet);
                    List<Dictionary<string,object>> listeorganisationBeauftragteZuAbrufberechtigte = new List<Dictionary<string,object>>();
                    foreach (var beauftagte in listeOrganisationsBeauftragten)
                    {
                        Dictionary<string, object> organisationBeauftragteZuAbrufberechtigteItem = new Dictionary<string, object>
                        {
                            { "Abteilung", beauftagte.Abteilung_Zentraler_Asp },
                            { "Anrede", beauftagte.Anrede_Zentraler_Asp },
                            { "Titel", beauftagte.Titel_Zentraler_Asp },
                            { "Vorname", beauftagte.Vorname_zentraler_Asp},
                            { "Name", beauftagte.Name_Zentraler_Asp },
                            { "Telefon", beauftagte.Telefon_Zentraler_Asp },
                            { "Email", beauftagte.Email_Zentraler_Asp.ToLower() }
                        };
                        listeorganisationBeauftragteZuAbrufberechtigte.Add(organisationBeauftragteZuAbrufberechtigteItem);
                    }

                    requestItem.Add("Organisationsbeauftragte", listeorganisationBeauftragteZuAbrufberechtigte);


                    var listeKdnr = kndrn_context.Kdnrs.Where(x => x.UUID == abrufBerechtigte.UUID && !x.istVerarbeitet);
                    var listeRkto = rkto_context.Kdnrs.Where(x=> x.UUID == abrufBerechtigte.UUID && !x.istVerarbeitet);

                    bool abrufBerechtigte_result = await DirectusClient.PostDataToDirectus("Abrufberechtigte", requestItem);

                    if(abrufBerechtigte_result)
                    {
                        abrufBerechtigte.istVerarbeitet = true;
                        abrufBerechtigte_context.SaveChanges();
                    }

                }
                
               

            }
            return false;
        }
    }
}
