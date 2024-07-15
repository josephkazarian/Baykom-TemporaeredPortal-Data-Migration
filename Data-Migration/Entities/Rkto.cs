using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Migration.Entities
{
    public class Rkto
    {
        [Key]
        [Ignore]
        public long Id { get; set; }
        [Ignore]
        public bool istVerarbeitet { get; set; } = false;
        [Name("Kunden-Nr (AB) rel")]
        public string Kunden_NrAB_rel { get; set; }
        [Name("Rechungskonto_2017")]
        public string Rechungskonto_2017 { get; set; }
        [Name("Rechnungskonto_2024")]
        public string Rechnungskonto_2024 { get; set; }
        [Name("InfoRKTO")]
        public string InfoRKTO {  get; set; }
        [Ignore]
        public string MigrationSkript_Info { get; set; }
    }
}
