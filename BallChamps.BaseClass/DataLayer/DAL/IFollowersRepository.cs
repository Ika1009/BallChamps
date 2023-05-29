using BallChamps.Domain;
using DataLayer.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataLayer.DAL
{
    public interface IFollowersRepository : IDisposable
    {
        Task<List<FollowDTO>> GetCurrentFollowersUserProfiles(string UserProfileId, string connStr);
        Task<List<FollowDTO>> GetCurrentFollowingUserProfiles(string UserProfileId, string connStr);
        Task Follow(Followers followers);
        Task UnFollow(string followersId,string userProfileId);
        Task<int> FollowersCount(string UserProfileId);
        Task<int> FollowingCount(string UserProfileId);
        Task<bool> IsFollowingUserProfile(string userProfileId, string followingUserProfileId);
        Task<int> Save();

    }
}
