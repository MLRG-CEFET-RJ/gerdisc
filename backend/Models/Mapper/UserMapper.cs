using gerdisc.Models.DTOs;
using gerdisc.Models.Entities;

namespace gerdisc.Models.Mapper
{
    /// <summary>
    /// A static class containing mapper methods for converting between <see cref="UserDto"/> and <see cref="UserEntity"/> objects.
    /// </summary>
    public static class UserMapper
    {
        /// <summary>
        /// Converts a <see cref="UserDto"/> object to a <see cref="UserEntity"/> object.
        /// </summary>
        /// <param name="self">The <see cref="UserDto"/> object to convert.</param>
        /// <param name="password">The password hash to set for the <see cref="UserEntity"/> object.</param>
        /// <returns>A new <see cref="UserEntity"/> object with the values from the <paramref name="self"/> object.</returns>
        public static UserEntity ToEntity(this UserDto self, string password) =>
            self is null ? new UserEntity() : new UserEntity
            {
                Id = self.Id,
                FirstName = self.FirstName,
                LastName = self.LastName,
                Email = self.Email,
                CreatedAt = self.CreatedAt,
                PasswordHash = password,
                Role = self.Role
            };

        /// <summary>
        /// Updates the values of an existing <see cref="UserEntity"/> object using the values from a <see cref="UserDto"/> object.
        /// </summary>
        /// <param name="self">The <see cref="UserDto"/> object containing the updated values.</param>
        /// <param name="entityToUpdate">The existing <see cref="UserEntity"/> object to update.</param>
        /// <returns>The updated <see cref="UserEntity"/> object.</returns>
        public static UserEntity ToEntity(this UserDto self, UserEntity entityToUpdate)
        {
            entityToUpdate.FirstName = self.FirstName;
            entityToUpdate.LastName = self.LastName;
            entityToUpdate.Role = self.Role;
            return entityToUpdate;
        }

        /// <summary>
        /// Converts a <see cref="UserEntity"/> object to a <see cref="UserDto"/> object.
        /// </summary>
        /// <param name="self">The <see cref="UserEntity"/> object to convert.</param>
        /// <returns>A new <see cref="UserDto"/> object with the values from the <paramref name="self"/> object.</returns>
        public static UserDto ToDto(this UserEntity self) =>
            self is null ? new UserDto() : new UserDto
            {
                Id = self.Id,
                FirstName = self.FirstName,
                LastName = self.LastName,
                Email = self.Email,
                CreatedAt = self.CreatedAt,
                Role = self.Role
            };
    }
}