using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Migration.Entities
{
    public class Abrufberechtigte
    {
        [Key]
        [Ignore]
        public long Id { get; set; }
        [Ignore]
        public bool istVerarbeitet { get; set; } = false;
        [Name("UUID")]
        public string UUID { get; set; }
        [Name("AB_gruppe")]
        public string AB_gruppe { get; set; }
        [Name("adresse")]
        public string adresse { get; set; }
        [Name("Name")]
        public string Name { get; set; }
        [Name("Info AB")]
        public string Info_AB { get; set; }
        [Ignore]
        public string MigrationSkript_Info {  get; set; }
    }
}
