using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using WebPrestamoFront1.Models;

namespace WebPrestamoFront1.Controllers
{
    [Route("/Clientes")]
    public class ClienteController : Controller
    {
        Uri baseAddres = new Uri("http://localhost:5260");
        private readonly HttpClient _client;

        public ClienteController()
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAddres;
        }
        [HttpGet]
        public async Task<IActionResult> ListaClientes()
        {
            List<ClienteView> vistacliente = new List<ClienteView>();
            HttpResponseMessage response = await _client.GetAsync("/api/Clientes/GetClientes");
            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();
                vistacliente = JsonConvert.DeserializeObject<List<ClienteView>>(data);
            }

            return View(vistacliente);
        }

        [HttpGet("register")]
        public IActionResult Createcliente()
        {
            return View();
        }
        [HttpPost("register")]
        public async Task<IActionResult> Createcliente(ClienteView model)
        {
            if (!ModelState.IsValid)
            {
                TempData["errorMessage"] = "Hay errores en el formulario.";
                return View(model);
            }
            string data = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _client.PostAsync("/api/Clientes/PostCliente", content);
            return View(model);
        }

        [HttpGet("edit/{id}")]
        public async Task<IActionResult> EditCliente(int id)
        {
            ClienteView cliente = new ClienteView();
            HttpResponseMessage response = await _client.GetAsync($"/api/Clientes/GetCliente/{id}");
            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();
                cliente = JsonConvert.DeserializeObject<ClienteView>(data);
            }
            return View(cliente);
        }

        [HttpPost("edit/{id}")]
        public async Task<IActionResult> EditCliente(ClienteView model, int id)
        {
            if (!ModelState.IsValid)
            {
                TempData["errorMessage"] = "Hay errores en el formulario.";
                return View(model);
            }

            string data = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _client.PutAsync($"/api/Clientes/PutCliente/{id}", content);

            if (response.IsSuccessStatusCode)
            {
                TempData["successMessage"] = "Cliente actualizado correctamente.";
                return RedirectToAction("ListaClientes");
            }
            else
            {
                TempData["errorMessage"] = "Error al actualizar el cliente.";
                return View(model);
            }
        }

        [HttpGet("delete/{id}")]
        public async Task<IActionResult> DeleteCliente(int id)
        {
            HttpResponseMessage response = await _client.GetAsync($"/api/Clientes/GetCliente/{id}");
            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();
                ClienteView cliente = JsonConvert.DeserializeObject<ClienteView>(data);
                return View(cliente);
            }
            return RedirectToAction("ListaClientes");
        }

        [HttpPost("delete/{id}"), ActionName("DeleteCliente")]
        public async Task<IActionResult> ConfirmDeleteCliente(int id)
        {
            HttpResponseMessage response = await _client.DeleteAsync($"/api/Clientes/DeleteCliente/{id}");

            if (response.IsSuccessStatusCode)
            {
                TempData["successMessage"] = "Cliente eliminado correctamente.";
                return RedirectToAction("ListaClientes");
            }
            else
            {
                TempData["errorMessage"] = "Error al eliminar el cliente.";
                return RedirectToAction("ListaClientes");
            }
        }

    }
}
