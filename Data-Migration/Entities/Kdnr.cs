using CsvHelper.Configuration.Attributes;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Migration.Entities
{
    public class Kdnr
    {
        [Key]
        [Ignore]
        public long Id { get; set; }
        [Ignore]
        public bool istVerarbeitet { get; set; } = false;
        [Name("RV_Los")]
        public string RV_Los {  get; set; }
        [Name("Kunden-Nr (AB) rel")]
        public string Kunden_Nr_AB_rel { get; set; }
        [Name("UUID")]
        public string UUID {  get; set; }
        [Name("Anrede")]
        public string Anrede {  get; set; }
        [Name("Name des Unternehmens")]
        public string Name_des_Unternehmens { get; set; }
        [Name("zusätzlicher Text")]
        public string zusaetzlicher_Text {  get; set; }
        [Name("Rechtsform")]
        public string Rechtsform {  get; set; }
        [Name("Hausnr.")]
        public string Hausnr {  get; set; }
        [Name("PLZ")]
        public string PLZ { get; set; }
        [Name("Ort")]
        public string Ort { get; set; }
        [Ignore]
        public string MigrationSkript_Info { get; set; }
    }
}
