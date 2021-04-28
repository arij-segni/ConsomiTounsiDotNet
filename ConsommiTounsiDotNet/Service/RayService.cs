using ConsommiTounsiDotNet.Models;
using ConsommiTounsiDotNet.Service.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;


namespace ConsommiTounsiDotNet.Service
{
    public class RayService
    {
        HttpClient httpClient;
        public RayService()
        {
        httpClient = new HttpClient();
        httpClient.BaseAddress = new Uri(Statics.baseAddress);
        httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        httpClient.DefaultRequestHeaders.Add("Authorization", String.Format(Statics._AccessToken));
        }
    public Boolean Add(Ray ray)
    {
        try
        {
            var APIResponse = httpClient.PostAsJsonAsync<Ray>(Statics.baseAddress + "/consomitounsi/servlet/addRay",
                ray).ContinueWith(postTask => postTask.Result.EnsureSuccessStatusCode());
            System.Diagnostics.Debug.WriteLine(APIResponse.Result);
            return true;
        }
        catch
        {
            return false;
        }
    }
    public Ray getRayById(long id)
    {
        Ray Ray = null;
        var response = httpClient.GetAsync(Statics.baseAddress + "/retrieve-all-rays" + id).Result;
        if (response.IsSuccessStatusCode)
        {
            var ray = response.Content.ReadAsAsync<Ray>().Result;
            return ray;
        }
        return Ray;
    }
    public bool Update(long idRay, Ray ray)
    {
        try
        {
            var APIResponse = httpClient.PutAsJsonAsync<Ray>(Statics.baseAddress + "/updateRay" + idRay, ray).ContinueWith(postTask => postTask.Result.EnsureSuccessStatusCode());
            System.Diagnostics.Debug.WriteLine(APIResponse.Result);
            return true;
        }
        catch
        {
            return false;
        }
    }
    public bool deleteRayById(long idRay)
    {
        try
        {
            var APIResponse = httpClient.DeleteAsync(Statics.baseAddress + "/consomitounsi/servlet/deleteRay/{id_ray}"+ idRay);
            return true;
        }
        catch
        {
            return false;
        }
    }
    public IEnumerable<Ray> GetAll()
    {
        var response = httpClient.GetAsync(Statics.baseAddress + "/consomitounsi/servlet/retrieve-all-rays").Result;
        if (response.IsSuccessStatusCode)
        {
            var ray = response.Content.ReadAsAsync<IEnumerable<Ray>>().Result;
            return ray;
        }
        return new List<Ray>();
    }
}
}