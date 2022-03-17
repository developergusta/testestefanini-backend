//using Microsoft.EntityFrameworkCore;
//using Stefanini_API.Repository;

//namespace Stefanini_API.Services
//{
//    public class PessoaService
//    {
//        readonly AppDbContext _dbContext = new();
//        public PessoaService(AppDbContext dbContext)
//        {
//            _dbContext = dbContext;
//        }

//        public async Task<IEnumerable<Pessoa>> ListarPessoas()
//        {
//            try
//            {
//                return await _dbContext.Pessoas.ToListAsync();
//            }
//            catch (Exception e)
//            {
//                Console.WriteLine(e.Message);
//                throw;
//            }
//        }

//        public async Task<IEnumerable<Pessoa>> BuscarPessoa(int id)
//        {
//            try
//            {
//                return await _dbContext.Pessoas
//                    .Where(p => p.Id == id)
//                    .ToListAsync();
//            }
//            catch (Exception e)
//            {
//                Console.WriteLine(e.Message);
//                throw;
//            }
//        }

//        public async Task IncluirPessoa(Pessoa pessoa)
//        {
//            try
//            {
//                await _dbContext.Pessoas.AddAsync(pessoa);
//            }
//            catch (Exception e)
//            {
//                Console.WriteLine(e.Message);
//                throw;
//            }
//        }

//        public async Task AlterarPessoa(Pessoa pessoa)
//        {
//            try
//            {
//                await _dbContext.Pessoas.AddAsync(pessoa);
//            }
//            catch (Exception e)
//            {
//                Console.WriteLine(e.Message);
//                throw;
//            }
//        }

//        public async Task ExcluirPessoa(int id)
//        {
//            try
//            {
//                Pessoa pessoa = new Pessoa { Id = id };
//                _dbContext.Pessoas.Attach(pessoa);
//                _dbContext.Pessoas.Remove(pessoa);
//                await _dbContext.SaveChangesAsync();
//            }
//            catch (Exception e)
//            {
//                Console.WriteLine(e.Message);
//                throw;
//            }
//        }
//    }
//}
