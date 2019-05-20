using Newtonsoft.Json;
using ProyectXamarin.Models;
using ProyectXamarin.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace ProyectXamarin.Tools
{
    public class StorageSession
    {

        public async Task StorageUser(Usuarios usuario, String token)
        {
            String json = JsonConvert.SerializeObject(usuario, Formatting.Indented);
            await SecureStorage.SetAsync("user", json);
            await SecureStorage.SetAsync("token", token);
        }

        public async Task<Usuarios> GetStorageUser()
        {
            var authUser = await SecureStorage.GetAsync("user");
            Usuarios usuario = JsonConvert.DeserializeObject<Usuarios>(authUser);
            return usuario;
        }

        public async Task<String> GetStorageToken()
        {
            String token = await SecureStorage.GetAsync("token");
            return token;
        }

        public void RemoveAllStorage()
        {
            SecureStorage.RemoveAll();
        }
    }
}
