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
    public class StockAPIController : ControllerBase
    {
        string connectionString = "Server=SHIWA\\SQLEXPRESS;Database=InventoryManagement;Trusted_Connection=True;TrustServerCertificate=True;";
        TblStock stock = new TblStock();
        // GET: api/<StockAPIController>
        [HttpGet]
        public IActionResult Get()
        {
            List<TblStock> stocks = new List<TblStock>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("getStocklist", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                TblStock stock = new TblStock();
                                stock.StockId = reader["stockId"].ToString();
                                stock.StoreId = reader["storeId"].ToString();
                                stock.ItemId = reader["itemId"].ToString();
                                stock.Quantity = Convert.ToInt32(reader["quantity"]);
                                stock.ExpiaryDate = reader["expiaryDate"].ToString();
                                stocks.Add(stock);
                            }
                        }
                    }
                }
                if (stocks.Count > 0)
                {
                    return Ok(stocks);
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

        // GET api/<StockAPIController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<StockAPIController>
        [HttpPost]
        public IActionResult Post([FromBody] TblStock newStock)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("addStock", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Assuming "insertStock" stored procedure expects parameters for the new stock item
                        command.Parameters.AddWithValue("@StockId", newStock.StockId);
                        command.Parameters.AddWithValue("@StoreId", newStock.StoreId);
                        command.Parameters.AddWithValue("@ItemId", newStock.ItemId);
                        command.Parameters.AddWithValue("@Quantity", newStock.Quantity);
                        command.Parameters.AddWithValue("@ExpiryDate", newStock.ExpiaryDate); // Assuming the database field name is ExpiryDate

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            return CreatedAtAction("Get", new { id = newStock.StockId }, newStock); // Assuming you have a Get method to retrieve the newly added item
                        }
                        else
                        {
                            return StatusCode(500, "Failed to insert the new stock item.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }


        // PUT api/<StockAPIController>/5
        [HttpPut("{id}")]
        public IActionResult Put(string id, TblStock updatedStock)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("updateStock", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Assuming "updateStock" stored procedure expects parameters for updating a stock item
                        command.Parameters.AddWithValue("@StockId", id); // Assuming the stock ID is passed separately
                        command.Parameters.AddWithValue("@StoreId", updatedStock.StoreId);
                        command.Parameters.AddWithValue("@ItemId", updatedStock.ItemId);
                        command.Parameters.AddWithValue("@Quantity", updatedStock.Quantity);
                        command.Parameters.AddWithValue("@ExpiryDate", updatedStock.ExpiaryDate); // Assuming the database field name is ExpiryDate

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            return Ok("Stock item updated successfully.");
                        }
                        else
                        {
                            return NotFound("Stock item not found.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }


        // DELETE api/<StockAPIController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
