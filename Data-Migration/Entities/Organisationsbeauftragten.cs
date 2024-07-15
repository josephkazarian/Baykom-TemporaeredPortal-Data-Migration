using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Migration.Entities
{
    public class Organisationsbeauftragten
    {
        [Key]
        [Ignore]
        public long Id { get; set; }
        [Ignore]
        public bool istVerarbeitet { get; set; } = false;
        [Name("UUID")]
        public string UUID {  get; set; }
        [Name("Abteilung - zentraler Asp.")]
        public string Abteilung_Zentraler_Asp {  get; set; }
        [Name("Anrede - zentraler Asp.")]
        public string Anrede_Zentraler_Asp { get; set; }
        [Name("Titel - zentraler Asp.")]
        public string Titel_Zentraler_Asp { get; set; }
        [Name("Vorname - zentraler Asp.")]
        public string Vorname_zentraler_Asp { get; set; }
        [Name("Name - zentraler Asp.")]
        public string Name_Zentraler_Asp { get; set; }
        [Name("Email - zentraler Asp.")]
        public string Email_Zentraler_Asp { get; set; }
        [Name("Telefon - zentraler Asp.")]
        public string Telefon_Zentraler_Asp { get; set; }
        [Name("Mobilfunknummer")]
        public string Mobilfunknummer {  get; set; }
        [Name("Funktions-postfach")]
        public string Funktions_postfach {  get; set; }
        [Ignore]
        public string MigrationSkript_Info { get; set; }
    }
}
