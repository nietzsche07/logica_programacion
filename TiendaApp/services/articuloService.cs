using System.Collections.Generic;
using System.Linq;
using TiendaApp.Models;

namespace TiendaApp.Services
{
    public class ArticuloService
    {
        private List<Articulo> _articulos = new List<Articulo>();
        private int _nextId = 1;
        private const int MaxArticulos = 15;

        public List<Articulo> ObtenerTodos() => _articulos;
        
        public Articulo Crear(Articulo articulo)
        {
            if (_articulos.Count >= MaxArticulos)
                throw new System.Exception("No se pueden crear más artículos. Límite alcanzado.");
                
            articulo.Id = _nextId++;
            _articulos.Add(articulo);
            return articulo;
        }
        
        public Articulo BuscarPorId(int id) => 
            _articulos.FirstOrDefault(a => a.Id == id);
            
        public void Actualizar(Articulo articuloActualizado)
        {
            var articulo = BuscarPorId(articuloActualizado.Id);
            if (articulo == null) throw new System.Exception("Artículo no encontrado");
            
            articulo.Nombre = articuloActualizado.Nombre;
            articulo.ValorUnitario = articuloActualizado.ValorUnitario;
            articulo.CantidadStock = articuloActualizado.CantidadStock;
        }
        
        public void ReducirStock(int idArticulo, int cantidad)
        {
            var articulo = BuscarPorId(idArticulo);
            if (articulo == null) throw new System.Exception("Artículo no encontrado");
            if (articulo.CantidadStock < cantidad) throw new System.Exception("Stock insuficiente");
            
            articulo.CantidadStock -= cantidad;
        }
    }
}