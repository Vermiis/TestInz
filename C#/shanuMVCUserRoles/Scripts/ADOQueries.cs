using Microsoft.AspNet.Identity;
using System.Data;
using System.Data.SqlClient;
using zarzadzanieTematami.Areas.Admin.Models.ViewModels;
using zarzadzanieTematami.Models;

class GetSelectedUser
{
    public GetSelectedUser( ApplicationUser applicationUser)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.Text;
        string query = "select * from AspNetUsers where ID = @id";
        SqlParameter param = new SqlParameter("@id", applicationUser.Id);
        cmd.CommandText = query;
    }
}


class EditSelectedUser
{
    public EditSelectedUser(ApplicationUser applicationUser, string newName)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.Text;
        string query = "update AspNetUsers set Name = @name where ID = @id";
        SqlParameter param1 = new SqlParameter("@name", newName);
        SqlParameter param = new SqlParameter("@id", applicationUser.Id);
        cmd.CommandText = query;
    }
}