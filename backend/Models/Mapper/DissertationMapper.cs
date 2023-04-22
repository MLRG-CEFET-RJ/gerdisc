using gerdisc.Models.DTOs;
using gerdisc.Models.Entities;

namespace gerdisc.Models.Mapper
{
    /// <summary>
    /// A static class containing mapper methods for converting between <see cref="DissertationDto"/> and <see cref="DissertationEntity"/> objects.
    /// </summary>
    public static class DissertationMapper
    {
        /// <summary>
        /// Converts a <see cref="DissertationDto"/> object to a <see cref="DissertationEntity"/> object.
        /// </summary>
        /// <param name="self">The <see cref="DissertationDto"/> object to convert.</param>
        /// <returns>A new <see cref="DissertationEntity"/> object with the values from the <paramref name="self"/> object.</returns>
        public static DissertationEntity ToEntity(this DissertationDto self) =>
            self is null ? new DissertationEntity() : new DissertationEntity
            {
                Name = self.Name,
                ProjectId = self.ProjectId,
                StudentId = self.StudentId,
            };

        /// <summary>
        /// Updates the values of an existing <see cref="DissertationEntity"/> object using the values from a <see cref="DissertationDto"/> object.
        /// </summary>
        /// <param name="self">The <see cref="DissertationDto"/> object containing the updated values.</param>
        /// <param name="entityToUpdate">The existing <see cref="DissertationEntity"/> object to update.</param>
        /// <returns>The updated <see cref="DissertationEntity"/> object.</returns>
        public static DissertationEntity ToEntity(this DissertationDto self, DissertationEntity entityToUpdate)
        {
            entityToUpdate.Name = self.Name;
            entityToUpdate.ProjectId = self.ProjectId;
            entityToUpdate.StudentId = self.StudentId;
            return entityToUpdate;
        }

        /// <summary>
        /// Converts a <see cref="DissertationEntity"/> object to a <see cref="DissertationDto"/> object.
        /// </summary>
        /// <param name="self">The <see cref="DissertationEntity"/> object to convert.</param>
        /// <returns>A new <see cref="DissertationDto"/> object with the values from the <paramref name="self"/> object.</returns>
        public static DissertationDto ToDto(this DissertationEntity self) =>
            self is null ? new DissertationDto() : new DissertationDto
            {
                Id = self.Id,
                Name = self.Name,
                ProjectId = self.ProjectId,
                StudentId = self.StudentId,
            };
    }
}
