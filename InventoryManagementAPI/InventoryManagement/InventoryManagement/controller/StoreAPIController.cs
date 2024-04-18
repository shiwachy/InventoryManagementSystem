using InventoryManagement.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InventoryManagement.controller
{
    [EnableCors("allowInventoryCors")]
    [Route("api/[controller]")]
    [ApiController]
    public class StoreAPIController : ControllerBase
    {
        string connectionString = "Server=SHIWA\\SQLEXPRESS;Database=InventoryManagement;Trusted_Connection=True;TrustServerCertificate=True;";
        TblStore store = new TblStore();
        // GET: api/<StoreAPIController>

        [HttpGet]
        public IActionResult Get()
        {
            List<TblStore> Stores = new List<TblStore>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("getStorelist", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                TblStore store = new TblStore();
                                store.StoreId = reader["storeId"].ToString();
                                store.StoreName = reader["storeName"].ToString();
                                store.IsActive = Convert.ToBoolean(reader["isActive"]);
                                Stores.Add(store);
                            }
                        }
                    }
                }
                if (Stores.Count > 0)
                {
                    return Ok(Stores);
                }
                else
                {
                    return NotFound(); // or any other appropriate response
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }

        // GET api/<StoreAPIController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<StoreAPIController>
        [HttpPost]
        public IActionResult Post([FromBody] TblStore newStore)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("addNewStore", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@storeId", newStore.StoreId);
                        command.Parameters.AddWithValue("@storeName", newStore.StoreName);
                        command.Parameters.AddWithValue("@isActive", newStore.IsActive);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            return Ok("Store added successfully.");
                        }
                        else
                        {
                            return StatusCode(500, "Failed to add store.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }

        // PUT api/<StoreAPIController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int storeId, [FromBody] TblStore updatedStore)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("updateStore", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@StoreId", updatedStore.StoreId); // Assuming storeId is the primary key used for updating
                        command.Parameters.AddWithValue("@StoreName", updatedStore.StoreName);
                        command.Parameters.AddWithValue("@IsActive", updatedStore.IsActive);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            return Ok("Store updated successfully.");
                        }
                        else
                        {
                            return StatusCode(500, "Failed to update store.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }


        // DELETE api/<StoreAPIController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
