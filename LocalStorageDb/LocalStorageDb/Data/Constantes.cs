namespace LocalStorageDb
{
    internal class Constantes
    {
        internal static readonly string RutaBaseDatos = "ClientesSQLLite.db3";
        internal static readonly SQLite.SQLiteOpenFlags Banderas 
            =       SQLite.SQLiteOpenFlags.ReadWrite | 
                    SQLite.SQLiteOpenFlags.Create |
                    SQLite.SQLiteOpenFlags.SharedCache;
    }
}