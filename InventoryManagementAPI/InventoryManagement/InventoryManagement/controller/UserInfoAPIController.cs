using InventoryManagement.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Drawing.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Microsoft.Data.SqlClient;



// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InventoryManagement.controller
{
    [EnableCors("allowInventoryCors")]
    [Route("api/[controller]")]
    [ApiController]
    public class UserInfoAPIController : ControllerBase
    {
        readonly private InventoryManagementContext _inventoryManagementContext;
        TblUsersInfo employees = new TblUsersInfo();
        string connectionString = "Server=SHIWA\\SQLEXPRESS;Database=InventoryManagement;Trusted_Connection=True;TrustServerCertificate=True;";

        public UserInfoAPIController(InventoryManagementContext inventoryManagementContext)
        {
            _inventoryManagementContext = inventoryManagementContext;

        }
        // GET: api/<UserInfoAPIController>

        //[HttpGet]
        //public IActionResult get()
        //{
        //    var data = _inventoryManagementContext.TblUsersInfos.ToList();
        //    return Ok(data);
        //}

        [HttpGet]
        public IActionResult Get()
        {
            List<TblUsersInfo> lstEmp = new List<TblUsersInfo>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("getEmpList", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                TblUsersInfo emp = new TblUsersInfo();
                                emp.UserId = Convert.ToInt32(reader["userId"]);
                                emp.UserName = reader["userName"].ToString();
                                emp.FullName = reader["fullname"].ToString();
                                emp.Password = reader["password"].ToString();
                                emp.Role = reader["role"].ToString();
                                emp.IsActive = Convert.ToBoolean(reader["isActive"]);
                                lstEmp.Add(emp);
                            }
                        }
                    }
                }
                if (lstEmp.Count > 0)
                {
                    return Ok(lstEmp);
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

        // GET api/UserInfoAPI/5
        [HttpGet("{UserName}")]
        public IActionResult  Get(string UserName)
        {
            TblUsersInfo emp = null;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("getUserByUserName", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@UserName", UserName);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                emp = new TblUsersInfo();
                               // emp.UserId = Convert.ToInt32(reader["userId"]);
                                emp.UserName = reader["userName"].ToString();
                                //emp.FullName = reader["fullname"].ToString();
                                emp.Password = reader["password"].ToString();
                                emp.Role = reader["role"].ToString();
                                emp.IsActive = Convert.ToBoolean(reader["isActive"]);
                            }
                        }
                    }
                }
                if (emp != null)
                {
                    return Ok(emp);
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

        // POST api/UserInfoAPI
        [HttpPost]
        public IActionResult Post([FromBody] TblUsersInfo newUser)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("addUser", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@UserId", newUser.UserId);
                        command.Parameters.AddWithValue("@UserName", newUser.UserName);
                        command.Parameters.AddWithValue("@FullName", newUser.FullName);
                        command.Parameters.AddWithValue("@Password", newUser.Password);
                        command.Parameters.AddWithValue("@Role", newUser.Role);
                        command.Parameters.AddWithValue("@IsActive", newUser.IsActive);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            return Ok("User added successfully.");
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

        // PUT api/UserInfoAPI/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] TblUsersInfo updatedUserInfo)
        {
            try
            {
                var userInfoToUpdate = _inventoryManagementContext.TblUsersInfos.FirstOrDefault(u => u.UserId == id);

                if (userInfoToUpdate == null)
                {
                    return NotFound(); // Return 404 if the user is not found
                }

                // Update user properties with the values from updatedUserInfo
                userInfoToUpdate.UserName = updatedUserInfo.UserName;
                userInfoToUpdate.FullName = updatedUserInfo.FullName;
                userInfoToUpdate.Password = updatedUserInfo.Password;
                userInfoToUpdate.Role = updatedUserInfo.Role;
                userInfoToUpdate.IsActive = updatedUserInfo.IsActive;

                _inventoryManagementContext.SaveChanges();

                return Ok("User Updated Successfully"); // Return 200 OK if update is successful
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}"); // Return 500 Internal Server Error for exceptions
            }
        }
    }

}