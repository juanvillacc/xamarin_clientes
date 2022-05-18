using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace LocalStorageDb.Models
{
    public class Cliente
    {
        [PrimaryKey,AutoIncrement]
        public int ID { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public bool EstaActivo { get; set; }
    }
}
