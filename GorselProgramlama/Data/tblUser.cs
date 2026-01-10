using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
using System.Text;
using Microsoft.Data.SqlClient;

namespace GorselProgramlama.Data;

public class tblUser
{
    [Key]
    public int ID { get; set; }
    public  string PlateNumber { get; set; }

    public string Password { get; set; }

    public  string Name { get; set; }

    public  string Surname { get; set; }
}
