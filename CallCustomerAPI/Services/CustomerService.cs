using CallCustomerAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CallCustomerAPI.Services
{
    public interface ICustomerService
    {
        Task<IEnumerable<Customer>> GetCustomersAsync();
        Task<Customer> CreateCustomerAsync(Customer customer);
        Task<Customer> EditCustomerAsync(string id, Customer customer);
        Task<Customer> GetCustomerByIdAsync(string id);
        Task DeleteCustomerAsync(string id);
    }
    public class CustomerService : ICustomerService
    {
        private readonly HttpClient _httpClient;

        public CustomerService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("InvoiceApi");
        }

        public async Task<IEnumerable<Customer>> GetCustomersAsync()
        {
            var response = await _httpClient.GetAsync("Customers");
            response.EnsureSuccessStatusCode();
            var customers = await response.Content.ReadAsAsync<IEnumerable<Customer>>();
            return customers;
        }

        public async Task<Customer> GetCustomerByIdAsync(string id)
        {
            var response = await _httpClient.GetAsync($"Customer/{id}");
            response.EnsureSuccessStatusCode();
            var customer = await response.Content.ReadAsAsync<Customer>();
            return customer;
        }

        public async Task<Customer> CreateCustomerAsync(Customer customer)
        {
            var response = await _httpClient.PostAsJsonAsync("Customer", customer);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<Customer>();
        }

        public async Task<Customer> EditCustomerAsync(string id, Customer customer)
        {
            var response = await _httpClient.PostAsJsonAsync($"Customer/{id}", customer);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<Customer>();
        }

        public async Task DeleteCustomerAsync(string id)
        {
            var response = await _httpClient.DeleteAsync($"Customer/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}