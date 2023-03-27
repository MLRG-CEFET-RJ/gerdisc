using gerdisc.Models.DTOs;

namespace gerdisc.Services.Project
{
    /// <summary>
    /// Defines methods for managing projects.
    /// </summary>
    public interface IProjectService
    {
        /// <summary>
        /// Creates a new project.
        /// </summary>
        /// <param name="projectDto">The project DTO containing the project details.</param>
        /// <returns>The created project DTO.</returns>
        Task<ProjectDto> CreateProjectAsync(ProjectDto projectDto);

        /// <summary>
        /// Retrieves a project by ID.
        /// </summary>
        /// <param name="id">The ID of the project to retrieve.</param>
        /// <returns>The project DTO with the specified ID.</returns>
        Task<ProjectDto> GetProjectAsync(int id);

        /// <summary>
        /// Updates a project.
        /// </summary>
        /// <param name="id">The ID of the project to update.</param>
        /// <param name="projectDto">The project DTO containing the updated project details.</param>
        /// <returns>The updated project DTO.</returns>
        Task<ProjectDto> UpdateProjectAsync(int id, ProjectDto projectDto);

        /// <summary>
        /// Deletes a project.
        /// </summary>
        /// <param name="id">The ID of the project to delete.</param>
        Task DeleteProjectAsync(int id);
    }
}