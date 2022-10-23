using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CovidDTO;
using CovidBL;
using Microsoft.AspNetCore.Cors;

namespace CovidProg.Controllers
{
    public class ClientController : ApiController
    {
       
        [HttpPost]
        [Route("addClient")]
        public ClientsDTO AddClient([FromBody] ClientsDTO client)
        {
            DateTime d = new DateTime();
            if (client == null)
            {
                return null;
            }
            else if(client.BirthDate>d||client.BirthDate<d.AddYears(-120)){
                return null;
            }
            else { 
                ClientsDTO c1 = ClientsBL.AddClient(client);
                return c1;
            }
            
        }
        [HttpPost]
        [Route("deleteClient")]
        public void DeleteClient([FromBody]ClientsDTO client)
        {
           ClientsBL.DeleteClient(client);            
        }
        [HttpPut]
        [Route("updateClient")]
        public void UpdateClient([FromBody]ClientsDTO client)
        {
            DateTime d = new DateTime();
            if (!(client == null|| client.BirthDate > d || client.BirthDate < d.AddYears(-120)))
           
           
                ClientsBL.UpdateClient(client);
            
        }
        [HttpGet]
        [Route("getAllClients")]
        public List<ClientsDTO> GetAllClients()
        {            
            List<ClientsDTO> lc = ClientsBL.GetAllClients();
            if (lc != null)
                return lc;
            else
                return null;
        }
        [HttpPost]
        [Route("getClientVac")]
        public List<VaccinationDTO> GetVacDates(ClientsDTO client)
        {           
            List<VaccinationDTO> dates = ClientsBL.GetDates(client);
            if (dates != null)
            {
                return dates;
            }
            return null;
        }
        [HttpPost]
        [Route("getClientSick")]
        public List<DateTime> GetSickDates(ClientsDTO client)
        {
            List<DateTime> dates = ClientsBL.GetSickDates(client);
            if (dates != null)
            {
                return dates;
            }
            return null;
        }
        [HttpGet]
        [Route("getSickPerDay")]
        public int[] GetSickPerDay()
        {
            int[] ill = ClientsBL.SickPerDay();
            return ill;
        }
        [HttpGet]
        [Route("notVaccinated")]
        public int CountNotVaccinated()
        {
            int count = ClientsBL.NotVaccinated();
            return count;
        }
    }
}
