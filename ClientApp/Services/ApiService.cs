using ClientApp.MVVM.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ClientApp.Services
{
    public class ApiService
    {
        private static readonly Lazy<ApiService> _instance = new Lazy<ApiService>(() => new ApiService(new HttpClient()));
        public static ApiService Instance => _instance.Value;

        private readonly HttpClient _httpClient;

        public ApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        /// <summary>
        /// прошели ли запрос
        /// </summary>
        /// <param name="httpResponseMessage"></param>
        /// <returns></returns>
        private bool SuccessStatusRequest(HttpResponseMessage httpResponseMessage)
        {
            if (!httpResponseMessage.IsSuccessStatusCode)
            {
                return false;
            }
            else
                return true;
        }


        /// <summary>
        /// получает список все клиентов
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<string> GetPatientsAsync()
        {
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(EndPoint.GetPatientsEndpoint);
                if (SuccessStatusRequest(response))
                {
                    return await response.Content.ReadAsStringAsync(); ;
                }
                else
                    throw new Exception("Запрос не прошел!");
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        /// <summary>
        /// получает информацию о клиенте по GUID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<string> GetPatientByIdAsync(Guid id)
        {
            try
            {
                var jsonContent = $"\"{id}\"";
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await _httpClient.PostAsync(EndPoint.GetPatientByIdEndpoint, content);
                if (SuccessStatusRequest(response))
                {
                    return await response.Content.ReadAsStringAsync();
                }
                else throw new Exception("Запрос не прошел!"); 
            }
            catch (Exception e) { throw new Exception(e.Message); };
        }


        /// <summary>
        /// получает информацию о пользователе по имени
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<string> GetPatientByNameAsync(string name)
        {
            try
            {
                var jsonContent = $"\"{name}\""; // Обратите внимание на двойные кавычки вокруг имени
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await _httpClient.PostAsync(EndPoint.GetPatientByNameEndpoint, content);
                if (SuccessStatusRequest(response))
                {
                    return await response.Content.ReadAsStringAsync();
                }
                else
                    throw new Exception("Запрос не прошел!");               
            }
            catch(Exception e) { throw new Exception(e.Message); }
            
        }
        /// <summary>
        /// Добавить пациента
        /// </summary>
        /// <param name="patient"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<Patient> AddPatientAsync(Patient patient)
        {
            try
            {
                var patientJson = JsonConvert.SerializeObject(patient);
                var content = new StringContent(patientJson, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await _httpClient.PostAsync(EndPoint.AddPatientEndpoint, content);
                if (SuccessStatusRequest(response))
                    return patient;
                else
                    throw new Exception("Запрос не прошел!");
            }
            catch(Exception e) { throw new Exception(e.Message); }
        }

        /// <summary>
        /// Обновить пациента
        /// </summary>
        /// <param name="patient"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task <string> UpdatePatientAsync(Patient patient)
        {
            try
            {
                var json = JsonConvert.SerializeObject(patient);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await _httpClient.PutAsync(EndPoint.UpdatePatientEndpoint, content);
                if (SuccessStatusRequest(response))
                    return await response.Content.ReadAsStringAsync();
                else
                    throw new Exception("Запрос не прошел!");
                
            }
            catch (Exception e) { throw new Exception(e.Message) ; }
        }

        /// <summary>
        /// Удаление пациента
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<string> DeletePatientAsync(Guid id)
        {
            try
            {
                var json = JsonConvert.SerializeObject(id);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await _httpClient.PostAsync(EndPoint.DeletePatientEndpoint, content);
                if (SuccessStatusRequest(response))
                    return await response.Content.ReadAsStringAsync();
                else
                    throw new Exception("Запрос не прошел");
            }
            catch(Exception e) { throw new Exception(e.Message); };
          
        }
    }
}
