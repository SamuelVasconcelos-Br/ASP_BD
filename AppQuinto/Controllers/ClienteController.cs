using AppQuinto.Models;
using AppQuinto.Repository;
using AppQuinto.Repository.Contract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AppQuinto.Controllers
{
    public class ClienteController : Controller
    {
        private ClienteRepository _clienteRepository;

        public ClienteController(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository as ClienteRepository;
        }
        public IActionResult Index()
        {
            return View(_clienteRepository.ObterTodosClientes());
        }
        [HttpGet]
        public IActionResult CadastrarCliente()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CadastrarCliente(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _clienteRepository.Cadastrar(cliente);
            }
            return View();
        }
        [HttpGet]
        public IActionResult AtualizarCliente(int id)
        {
            return View(_clienteRepository.ObterCliente(id));
        }
        [HttpPost]
        public IActionResult AtualizarCliente(Cliente cliente)
        {
            _clienteRepository.Atualizar(cliente);

            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult DetalhesCliente(int id)
        {
            return View(_clienteRepository.ObterCliente(id));
        }
        [HttpPost]
        public IActionResult DetalhesCliente(Cliente cliente)
        {
            _clienteRepository.Atualizar(cliente);

            return RedirectToAction(nameof(Index));
        }
        public IActionResult ExcluirCliente(int id)
        {
            _clienteRepository.Excluir(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
