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
    public class ItemsAPIController : ControllerBase
    {

        string connectionString = "Server=SHIWA\\SQLEXPRESS;Database=InventoryManagement;Trusted_Connection=True;TrustServerCertificate=True;";
        TblItem Item = new TblItem();

         // GET: api/<ItemsAPIController>
         [HttpGet]
        public IActionResult Get()
        {
            List<TblItem> Items = new List<TblItem>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("getItemlist", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                TblItem item = new TblItem();
                                item.ItemId = reader["itemId"].ToString();
                                item.ItemCode = reader["itemCode"].ToString();
                                item.ItemName = reader["itemName"].ToString();
                                item.BrandName = reader["brandName"].ToString();
                                item.UnitOfMeasurement = reader["unitOfMeasurement"].ToString();
                                item.PurchaseRate = Convert.ToInt32(reader["purchaseRate"]);
                                item.SalesRate = Convert.ToInt32(reader["salesRate"]);
                                item.IsActive = Convert.ToBoolean(reader["isActive"]);
                                Items.Add(item);
                            }
                        }
                    }
                }
                if (Items.Count > 0)
                {
                    return Ok(Items);
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

        // GET api/<ItemsAPIController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ItemsAPIController>
        [HttpPost]
        public IActionResult Post([FromBody] TblItem NewItem)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("addNewItem", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@itemId", NewItem.ItemId);
                        command.Parameters.AddWithValue("@itemCode", NewItem.ItemCode);
                        command.Parameters.AddWithValue("@itemName", NewItem.ItemName);
                        command.Parameters.AddWithValue("@brandName", NewItem.BrandName);
                        command.Parameters.AddWithValue("@unitOfMeasurement", NewItem.UnitOfMeasurement);
                        command.Parameters.AddWithValue("@purchaseRate", NewItem.PurchaseRate);
                        command.Parameters.AddWithValue("@salesRate", NewItem.SalesRate);
                        command.Parameters.AddWithValue("@IsActive", NewItem.IsActive);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            return Ok("Item added successfully.");
                        }
                        else
                        {
                            return StatusCode(500, "Failed to add user.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }

        // PUT api/<ItemsAPIController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] TblItem ItemToUpdate)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("updateItem", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@itemId", id);
                        command.Parameters.AddWithValue("@itemCode", ItemToUpdate.ItemCode);
                        command.Parameters.AddWithValue("@itemName", ItemToUpdate.ItemName);
                        command.Parameters.AddWithValue("@brandName", ItemToUpdate.BrandName);
                        command.Parameters.AddWithValue("@unitOfMeasurement", ItemToUpdate.UnitOfMeasurement);
                        command.Parameters.AddWithValue("@purchaseRate", ItemToUpdate.PurchaseRate);
                        command.Parameters.AddWithValue("@salesRate", ItemToUpdate.SalesRate);
                        command.Parameters.AddWithValue("@IsActive", ItemToUpdate.IsActive);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            return Ok("Item updated successfully.");
                        }
                        else
                        {
                            return StatusCode(500, "Failed to update item.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }

        // DELETE api/<ItemsAPIController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
