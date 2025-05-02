using GymManagement.Domain.Entities.Admins;

namespace GymManagement.Application.Services.Common.Interfaces;

public interface IAdminsRepository
{
    Task<Admin?> GetByIdAsync(Guid adminId);
    Task UpdateAsync(Admin admin);
}