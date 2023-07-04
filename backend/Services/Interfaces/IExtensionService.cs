using gerdisc.Models.DTOs;

namespace gerdisc.Services.Interfaces
{
    /// <summary>
    /// Defines methods for managing extensions.
    /// </summary>
    public interface IExtensionService
    {
        /// <summary>
        /// Creates a new extension.
        /// </summary>
        /// <param name="extensionDto">The extension DTO containing the extension details.</param>
        /// <returns>The created extension DTO.</returns>
        Task<ExtensionDto> CreateExtensionAsync(CreateExtensionDto extensionDto);

        /// <summary>
        /// Retrieves a extension by ID.
        /// </summary>
        /// <param name="id">The ID of the extension to retrieve.</param>
        /// <returns>The extension DTO with the specified ID.</returns>
        Task<ExtensionDto> GetExtensionAsync(Guid id);

        /// <summary>
        /// Gets a list of all extension entities.
        /// </summary>
        /// <returns>A list of all extension entities.</returns>
        Task<IEnumerable<ExtensionDto>> GetAllExtensionsAsync();

        /// <summary>
        /// Updates a extension.
        /// </summary>
        /// <param name="id">The ID of the extension to update.</param>
        /// <param name="extensionDto">The extension DTO containing the updated extension details.</param>
        /// <returns>The updated extension DTO.</returns>
        Task<ExtensionDto> UpdateExtensionAsync(Guid id, CreateExtensionDto extensionDto);

        /// <summary>
        /// Deletes a extension.
        /// </summary>
        /// <param name="id">The ID of the extension to delete.</param>
        Task DeleteExtensionAsync(Guid id);
    }
}
