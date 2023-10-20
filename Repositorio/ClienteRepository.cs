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

        public bool Apagar(int id)
        {
            ClienteModel cliente = BuscarPorId(id);
            if(cliente == null) { throw new Exception("Cliente nãop localizado"); }
            _context.Cliente.Remove(cliente);
            _context.SaveChanges();
            return true;
        }

        public ClienteModel Atualziar(ClienteModel cliente)
        {
            ClienteModel clienteModel = BuscarPorId(cliente.Id);
            if(clienteModel == null) { throw new Exception("Cliente não localizado em nossa base de dados"); }
           
            clienteModel.Nome = cliente.Nome;
            clienteModel.Telefone = cliente.Telefone;
            clienteModel.DataNascimento = cliente.DataNascimento;
            clienteModel.Endereco = cliente.Endereco;

            _context.Cliente.Update(clienteModel);
            _context.SaveChanges();

            return clienteModel;
        }

        public ClienteModel BuscarPorId(int id)
        {
            return _context.Cliente.FirstOrDefault(x => x.Id == id);
        }

        public List<ClienteModel> BuscarTodos()
        {
            List<ClienteModel> clientes = _context.Cliente.ToList();
            return clientes;
        }


    }
}
 
