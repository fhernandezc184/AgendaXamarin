using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Base.Modelo
{
    [Table("Agenda")]
    public class Agenda
    {
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }
        public string Linea { get; set; }
        public string Importantia { get; set; }
    }
}
