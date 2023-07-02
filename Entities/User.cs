using System.ComponentModel.DataAnnotations;
using JwtWebApi.Entities.Enum;

namespace JwtWebApi.Entities
{
    public class User
    {
        [Key]
        private int id;
        private string firstName;
        private string lastName;
        private string username;
        private Role role;
        private byte[] passwordHash;
        private byte[] passwordSalt;

        public int Id { get => id; set => id = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string Username { get => username; set => username = value; }
        public Role Role { get => role; set => role = value; }
        public byte[] PasswordHash { get => passwordHash; set => passwordHash = value; }
        public byte[] PasswordSalt { get => passwordSalt; set => passwordSalt = value; }
    }
}
