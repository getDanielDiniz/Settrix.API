using Settrix.Domain.Security.Criptography;

namespace Settrix.Infraestructure.Security.Criptography;

/// <summary>
/// This class contains methods to hash and verify passwords. 
/// </summary>
internal class CriptographyHanddle: ICriptographyHanddle
{
    /// <summary>
    /// Hash your password before persist it.
    /// </summary>
    /// <param name="password">"password gives it from the user"</param>
    /// <returns name="password hash">"password encrypted"</returns>
    public string HashPassword(string password)
    {
        return BCrypt.Net.BCrypt.HashPassword(password);
    }

    /// <summary>
    /// Verify if the given password is the same that the hashed password in the database.
    /// </summary>
    /// <param name="password">password gives it from the user</param>
    /// <param name="hashedPassword">password encrypted</param>
    /// <returns></returns>
    public bool VerifyPassword(string password, string hashedPassword)
    {
        return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
    }
}