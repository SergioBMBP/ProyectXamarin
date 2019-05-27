﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ProyectXamarin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ProyectXamarin.Tools
{
    public class ApiConnect
    {
        private String uriapi;
        private MediaTypeWithQualityHeaderValue headerjson;

        public ApiConnect()
        {
            this.uriapi = "https://apicopycore.azurewebsites.net/";
           // this.uriapi = "https://apicopycoredvb.azurewebsites.net/";
            this.headerjson = new MediaTypeWithQualityHeaderValue("application/json");
        }


        public async Task<T> CallApi<T>(String peticion)
        {
            using (HttpClient cliente = new HttpClient())
            {
                cliente.BaseAddress = new Uri(this.uriapi);
                cliente.DefaultRequestHeaders.Accept.Clear();
                cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await cliente.GetAsync(peticion);
                if (response.IsSuccessStatusCode)
                {
                    String json = await response.Content.ReadAsStringAsync();
                    T datos = JsonConvert.DeserializeObject<T>(json);
                    return (T)Convert.ChangeType(datos, typeof(T));
                }
                else
                {
                    return default(T);
                }
            }
        }


        public async Task CallApiPost(Object obj, String peticion, String token)
        {
            using (HttpClient cliente = new HttpClient())
            {
                cliente.BaseAddress = new Uri(this.uriapi);
                cliente.DefaultRequestHeaders.Accept.Clear();
                cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                

                String json = JsonConvert.SerializeObject(obj, Formatting.Indented);
                byte[] arrayBuffer = Encoding.UTF8.GetBytes(json);

                ByteArrayContent content = new ByteArrayContent(arrayBuffer);
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                if (token != null)
                {
                    cliente.DefaultRequestHeaders.Add("Authorization", "bearer " + token);
                    
                }


                Uri uri = new Uri(this.uriapi + peticion);

                HttpResponseMessage response = await cliente.PostAsync(uri, content);
            }
        }


        public async Task ApiDelete(String peticion, String token)
        {
            using (HttpClient cliente = new HttpClient())
            {
                cliente.BaseAddress = new Uri(this.uriapi);
                cliente.DefaultRequestHeaders.Accept.Clear();
                cliente.DefaultRequestHeaders.Accept.Add(headerjson);

                if (token != null)
                {
                    cliente.DefaultRequestHeaders.Add("Authorization", "bearer " + token);
                }
                HttpResponseMessage responseMessage = await cliente.DeleteAsync(peticion);
            }
        }

        public async Task<String> GetToken(String usuario, String password)
        {
            using (HttpClient client = new HttpClient())
            {
                //setup client
                client.BaseAddress = new Uri(this.uriapi);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(headerjson);

                Usuarios user = new Usuarios();
                user.Nombre = usuario;
                user.Password = password;
                String json = JsonConvert.SerializeObject(user);

                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                String peticion = "api/Auth/Login";
                HttpResponseMessage response = await client.PostAsync(peticion, content);
                if (response.IsSuccessStatusCode)
                {
                    String contenido = await response.Content.ReadAsStringAsync();
                    var jObject = JObject.Parse(contenido);
                    return jObject.GetValue("response").ToString();
                }
                else
                {
                    return null;
                }
            }
        }


    }
}
