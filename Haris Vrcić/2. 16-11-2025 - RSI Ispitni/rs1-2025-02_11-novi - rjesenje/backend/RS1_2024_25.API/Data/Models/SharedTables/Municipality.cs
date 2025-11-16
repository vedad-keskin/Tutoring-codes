using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RS1_2024_25.API.Helper.BaseClasses;

namespace RS1_2024_25.API.Data.Models.SharedTables;

// opstina - Opštine
public class Municipality : SharedTableBase // kroz nasljedjivanje dobijes PK 
{


    public string Name { get; set; } = string.Empty; // Naziv opštine ---> ""

    public int CityId { get; set; } // FK na grad
    [ForeignKey(nameof(CityId))]
    public City? City { get; set; } // ? -> NULLABLE -> podatak moze biti NULL NA BAZI 

}
