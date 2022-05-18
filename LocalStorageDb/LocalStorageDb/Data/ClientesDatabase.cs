using LocalStorageDb.Models;
using LocalStorageDb.Utilities;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LocalStorageDb.Data
{
    public class ClientesDatabase
    {
        static SQLiteAsyncConnection BaseDatos;

        public static readonly AzyncLazy<ClientesDatabase> Instance = new AzyncLazy<ClientesDatabase>(async () => {
            var instance = new ClientesDatabase();
            // relacionan las tablas 
            CreateTableResult result = await BaseDatos.CreateTableAsync<Cliente>();
            return instance;
        });

        public ClientesDatabase()
        {
            var ruta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), Constantes.RutaBaseDatos);
            BaseDatos = new SQLiteAsyncConnection(ruta, Constantes.Banderas);

        }

        internal Task GuardarCliente(Cliente cliente)
        {
            if (cliente.ID == 0)
            {
                // ingresando cliente
                return BaseDatos.InsertAsync(cliente);
            } else
            {
                // estamos actualizando
                return BaseDatos.UpdateAsync(cliente);
            }
        }

        public Task<List<Cliente>> ClientesObtenerTodos()
        {
            return BaseDatos.Table<Cliente>().ToListAsync();

        }
        public Task<List<Cliente>> ClientesActivosObtenerTodos()
        {
            return BaseDatos.Table<Cliente>().Where(x => x.EstaActivo).ToListAsync();
        }

    }
}
