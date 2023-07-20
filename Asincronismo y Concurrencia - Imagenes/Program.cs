using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

class Program
{
    static async Task<byte[]> DownloadImageAsync(string URLImagen)
    {
        using (HttpClient client = new HttpClient())
        {
            byte[] imageData = await client.GetByteArrayAsync(URLImagen);
            return imageData;
        }
    }

    static async Task Main(string[] args)
    {
        List<string> URLsImagenes = new List<string>
        {
            "https://media.ambito.com/p/82a335546b26ff4b09c9499dc97a4259/adjuntos/239/imagenes/038/514/0038514704/el-fiat-mobi-easy-es-el-auto-mas-economico-del-mercado-automotor-argentino.jpg",
            "https://i.blogs.es/b1be28/autos-electricos-en-mexico_1/1366_2000.jpg",
            "http://4.bp.blogspot.com/-POO7m1EeCJM/UlQa2fg56VI/AAAAAAAA6-U/d2gUj_Tl51Q/w1200-h630-p-nu/Nissan-Skyline-Tuning_Carros-Modificados-1920x1080.jpg"
   
        };

        List<Task<byte[]>> downloadTasks = new List<Task<byte[]>>();

        foreach (string url in URLsImagenes)
        {
            Task<byte[]> downloadTask = DownloadImageAsync(url);
            downloadTasks.Add(downloadTask);
        }

        await Task.WhenAll(downloadTasks);

        Console.WriteLine("Todas las imágenes han sido descargadas correctamente.");

    }
}
