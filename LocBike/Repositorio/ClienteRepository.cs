using LocBike.Data;
using LocBike.Models;
using LocBike.Repositorio.Interface;
using Microsoft.EntityFrameworkCore;

namespace LocBike.Repositorio
{
    public class ClienteRepository: IClienteRepository
    {
        private readonly AppDbContext _context;
        public ClienteRepository(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }

        public ClienteModel Adicionar(ClienteModel cliente)
        {
            _context.Cliente.Add(cliente);
            _context.SaveChanges();
            return cliente;
        }

        public List<ClienteModel> BuscarTodos()
        {
            List<ClienteModel> clientes = _context.Cliente.ToList();
            return clientes;
        }
    }
}
 
