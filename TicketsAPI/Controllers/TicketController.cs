using DbOperations.Operations;
using DbOperations.ResponseObject;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Persistance.Models;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using Route = Persistance.Models.Route;
using Newtonsoft.Json;

namespace TicketsAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TicketController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;

        public TicketController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        public TicketController()
        {
        }

        [HttpGet("GetUser")]
        public ResponseObject<List<User>> GetUser()
        {
            ResponseObject<List<User>> response = new ResponseObject<List<User>>();
            try
            {
                //Memory management
                using (Operations op = new Operations())
                {
                    List<User> users = new List<User>();
                    // Operations class is the part of DAL layer where all Databse related operations are carried out.
                    // Here we call GetUsers method of DAL -> Operations and it will perform Database interaction (Read data from Users)
                    users = op.GetUsers();
                    response.SetResponeData(users, ResultCode.Success, "");
                }
            }
            catch (Exception ex)
            {
                // Setting ResponseObject with ResultCode of Failure and exact Exception message for further handling and different layer
                // where error handling is taking place
                response.SetResponeData(null, ResultCode.Error, ex.Message);
            }
            finally
            {

            }
            return response;
        }

    
        [HttpPost("CreateUser")]
        public ResponseObject<User> CreateUser([FromBody] User user)
        {
            ResponseObject<User> response = new ResponseObject<User>();
            try
            {
                //Memory management
                using (Operations op = new Operations())
                {
                    // Operations class is the part of DAL layer where all Databse related operations are carried out.
                    // Here we call CreateUser method of DAL -> Operations and it will perform Database interaction (Insert data into User)
                    response = op.CreateUser(user);
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {

            }
            return response;
        }

        [HttpDelete("RemoveUser")]
        public ResponseObject<Boolean> RemoveUser([FromBody] User user)
        {
            ResponseObject<Boolean> response = new ResponseObject<Boolean>();
            try
            {
                //Memory management
                using (Operations op = new Operations())
                {
                    // Operations class is the part of DAL layer where all Databse related operations are carried out.
                    // Here we call RemoveUser method of DAL -> Operations and it will perform Database interaction (Remove data from User)
                    response = op.DeleteUser(user);
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {

            }
            return response;
        }

        [HttpPut("UpdateUser")]
        public ResponseObject<User> UpdateUser([FromBody] User user)
        {
            ResponseObject<User> response = new ResponseObject<User>();
            try
            {
                //Memory management
                using (Operations op = new Operations())
                {
                    // Operations class is the part of DAL layer where all Databse related operations are carried out.
                    // Here we call CreateUser method of DAL -> Operations and it will perform Database interaction (Insert data into User)
                    response = op.UpdateUser(user);
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {

            }
            return response;
        }

        [HttpGet("GetTickets")]
        public ResponseObject<List<Ticket>> GetTickets()
        {
            ResponseObject<List<Ticket>> response = new ResponseObject<List<Ticket>>();
            try
            {
                //Memory management
                using (Operations op = new Operations())
                {
                    List<Ticket> users = new List<Ticket>();
                    // Operations class is the part of DAL layer where all Databse related operations are carried out.
                    // Here we call GetUsers method of DAL -> Operations and it will perform Database interaction (Read data from Tickets)
                    users = op.GetTickets();
                    response.SetResponeData(users, ResultCode.Success, "");
                }
            }
            catch (Exception ex)
            {
                // Setting ResponseObject with ResultCode of Failure and exact Exception message for further handling and different layer
                // where error handling is taking place
                response.SetResponeData(null, ResultCode.Error, ex.Message);
            }
            finally
            {

            }
            return response;
        }

        [HttpPost("CreateTickets")]
        public ResponseObject<Ticket> CreateTickets([FromBody] Ticket ticket)
        {
            ResponseObject<Ticket> response = new ResponseObject<Ticket>();
            try
            {
                //Memory management
                using (Operations op = new Operations())
                {
                    // Operations class is the part of DAL layer where all Databse related operations are carried out.
                    // Here we call CreateUser method of DAL -> Operations and it will perform Database interaction (Insert data into User)
                    response = op.GenerateTicket(ticket);
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {

            }
            return response;
        }

        [HttpPut("UpdateTickets")]
        public ResponseObject<Ticket> UpdateTickets([FromBody] Ticket ticket)
        {
            ResponseObject<Ticket> response = new ResponseObject<Ticket>();
            try
            {
                //Memory management
                using (Operations op = new Operations())
                {
                    // Operations class is the part of DAL layer where all Databse related operations are carried out.
                    // Here we call UpdateUser method of DAL -> Operations and it will perform Database interaction (Update data into Tickets)
                    response = op.UpdateTicket(ticket);
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {

            }
            return response;
        }

        [HttpDelete("DeleteTickets")]
        public ResponseObject<Boolean> DeleteTickets([FromBody] Ticket ticket)
        {
            ResponseObject<Boolean> response = new ResponseObject<Boolean>();
            try
            {
                //Memory management
                using (Operations op = new Operations())
                {
                    // Operations class is the part of DAL layer where all Databse related operations are carried out.
                    // Here we call DeleteTicket method of DAL -> Operations and it will perform Database interaction (Remove data from Tickets)
                    response = op.DeleteTicket(ticket);
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {

            }
            return response;
        }

    }
}
