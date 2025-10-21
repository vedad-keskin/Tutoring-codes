using RS1_2024_25.API.Helper;
using RS1_2024_25.API.Helper.BaseClasses;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RS1_2024_25.API.Data.Models.SharedTables;

public class Activity : SharedTableBase
{
    public string Name { get; set; }

}