using System;
using Microsoft.Data.SqlClient;
using SGU_CSharp_User.Core;
using Xunit;

namespace SGU_CSharp_User.Tests.Core
{
    public class DatabaseTests
    {
        [Fact]
        public void GetConnection_ShouldReturnValidSqlConnection()
        {
            // Arrange
            var database = Database.Instance;

            // Act
            using (var connection = database.GetConnection())
            {
                // Assert
                Assert.NotNull(connection);
                Assert.IsType<SqlConnection>(connection);
                Assert.Equal("Closed", connection.State.ToString());
            }
        }
    }
}
